using HREngine.API;
using HREngine.API.Actions;
using HREngine.API.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
   public class BotBB : IBot
   {
      public BotBB()
      {
         OnBattleStateUpdate = UpdateBattleState;
         OnMulliganStateUpdate = UpdateMulliganState;
         RejectedCardList = new Dictionary<int, HRCard>();
         NextFixedAction = null;
      }

      private HREngine.API.Actions.ActionBase UpdateBattleState()
      {
         HREngine.API.Actions.ActionBase result = NextFixedAction;

         if (result != null)
         {
            NextFixedAction = null;
            return result;
         }

         // If a previous action was not handled successful the Bot remains
         // in target mode. 
         // Target here with 'LastTarget'. If the specified Target is null 
         // the bot automatically selects the best target based on a rule
         // or enemy condition.
         if (HRBattle.IsInTargetMode())
         {
            HRLog.Write("Targeting...");
            return new TargetAction(PlayCardAction.LastTarget != null ? PlayCardAction.LastTarget : GetNextAttackToAttack());
         }

         var localPlayerState = new PlayerState(HRPlayer.GetLocalPlayer());
         var enemyPlayerState = new PlayerState(HRPlayer.GetEnemyPlayer());

         // Fix: Druid: doesn't attack (and even other)
         // https://github.com/Hearthcrawler/HREngine/issues/40
         if (!localPlayerState.Player.HasWeapon()
            && localPlayerState.Player.GetHero().CanAttack()
            && localPlayerState.Player.GetHero().GetATK() > 0
            && HRBattle.CanUseCard(localPlayerState.Player.GetHero()))
         {
            return new AttackAction(
               localPlayerState.Player.GetHero(), GetNextAttackToAttack());
         }

         if (!enemyPlayerState.Player.HasATauntMinion())
         {
            if (enemyPlayerState.Player.GetHero().CanBeAttacked())
            {
               var current = PlayerState.GetPossibleAttack(
                  localPlayerState.Player, enemyPlayerState.Health);

               if (current.Attack >= enemyPlayerState.Health)
               {
                  if (current.Cards.Count > 0)
                     return new AttackAction(current.Cards[0], enemyPlayerState.Player.GetHero());
               }
            }
         }

         if (localPlayerState.Player.GetHero().GetClass() == HRClass.PRIEST)
         {
            if (localPlayerState.Player.GetHeroPower().GetCost() <= localPlayerState.Mana)
            {
               if (localPlayerState.Health <= 17)
               {
                  if (HRBattle.CanUseCard(localPlayerState.Player.GetHeroPower()))
                     return new PlayCardAction(
                        localPlayerState.Player.GetHeroPower().GetCard(),
                        HRPlayer.GetLocalPlayer().GetHero());
               }
               else
               {
                  // FIX: Heal minions if possible
                  // https://github.com/Hearthcrawler/HREngine/issues/27
                  foreach (var item in localPlayerState.ReadyMinions)
                  {
                     if (item.GetRemainingHP() < item.GetHealth())
                     {
                        // Heal damaged minions...
                        if (HRBattle.CanUseCard(localPlayerState.Player.GetHeroPower()))
                           return new PlayCardAction(
                              localPlayerState.Player.GetHeroPower().GetCard(),
                              HRPlayer.GetLocalPlayer().GetHero());
                     }
                  }
               }
            }
         }

         // Next cards to push...
         if (HRPlayer.GetLocalPlayer().GetNumFriendlyMinionsInPlay() < 7)
         {
            result = PlayCardsToField();
            if (result != null)
               return result;
            else
            {
               // There are no cards to play.. 
               if (localPlayerState.Player.GetHero().GetClass() == HRClass.WARLOCK)
               {
                  // Can we use our hero power? 
                  // Warlock should not suicide.
                  // FIX: https://github.com/Hearthcrawler/HREngine/issues/30
                  if (localPlayerState.Health >= 10)
                  {
                     // At least 3 mana left if we draw a card, okay?
                     if (localPlayerState.Player.GetHeroPower().GetCost() + 3 <= localPlayerState.Mana)
                     {
                        if (HRBattle.CanUseCard(localPlayerState.Player.GetHeroPower()))
                           return new PlayCardAction(localPlayerState.Player.GetHeroPower().GetCard());
                     }
                  }

               }
            }
         }

         // Priority: Always attack taunt minions first.
         if (enemyPlayerState.TauntMinions.Count > 0)
         {
            result = AttackTauntMinions(enemyPlayerState);
            if (result != null)
               return result;
         }

         // Bot does not attack when there is stealthed taunts
         // Fix: https://github.com/Hearthcrawler/HREngine/issues/60
         // If AttackTauntMinions() cannot attack because of stealthed - the action is null
         // and the bot should continue with default attack routine.
         //
         // Attack other minions or hero...
         result = Attack();
         if (result != null)
            return result;

         // Use Hero Power that make sense at last...
         if (localPlayerState.Player.GetHeroPower().GetCost() <= localPlayerState.Mana)
         {
            switch (localPlayerState.Player.GetHero().GetClass())
            {
               case HRClass.DRUID:
               case HRClass.WARRIOR:
               case HRClass.MAGE:
               case HRClass.PALADIN:
               case HRClass.HUNTER:
               case HRClass.SHAMAN:
               case HRClass.ROGUE:
                  {
                     if (HRBattle.CanUseCard(localPlayerState.Player.GetHeroPower()))
                        return new PlayCardAction(localPlayerState.Player.GetHeroPower().GetCard());
                  }
                  break;
               default:
                  break;
            }
         }

         return null;
      }

      private ActionBase PlayCardsToField()
      {
         // Get all available cards...
         List<HRCard> availableCards = 
            HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.HAND);

         if (availableCards.Count > 0)
         {
            HRCard coin = null;
            foreach (var item in availableCards)
            {
               #region Skip The Coin
               string cardID = item.GetEntity().GetCardId();
               if (cardID == "GAME_005" || cardID == "GAME_005e")
               {
                  coin = item;
                  continue;
               }
               #endregion

               if (item.GetEntity().GetCost() <= HRPlayer.GetLocalPlayer().GetNumAvailableResources())
                  return new PlayCardAction(item);
            }

            #region The Coin Feature 
            // Feature: The Coin
            // https://github.com/juce-mmocrawlerbots/HREngine/issues/13
            if (coin != null)
            {
               foreach (var card in availableCards)
               {
                  if (card.GetEntity().GetCardId() != coin.GetEntity().GetCardId())
                  {
                     if (card.GetEntity().IsMinion() || card.GetEntity().IsSpell() || (!HRPlayer.GetLocalPlayer().HasWeapon() && card.GetEntity().IsWeapon()))
                     {
                        if (card.GetEntity().GetCost() <= (HRPlayer.GetLocalPlayer().GetNumAvailableResources() + 1))
                        {
                           HRLog.Write(
                              String.Format("Spawn [{0}] and then [{1}]",
                              coin.GetEntity().GetName(), card.GetEntity().GetName()));

                           NextFixedAction = new PlayCardAction(card);
                           return new PlayCardAction(coin);
                        }
                     }
                  }
               }
            }
            #endregion
         }

         return null;
      }

      protected virtual ActionBase Attack()
      {
         HREntity target = GetNextAttackToAttack();

         if (target != null)
         {
            var current = PlayerState.GetPossibleAttack(
               HRPlayer.GetLocalPlayer(),
               target.GetRemainingHP() + target.GetArmor());

            if (current.Cards.Count > 0)
               return new AttackAction(current.Cards[0], target);
         }

         return null;
      }

      protected virtual HREntity GetNextAttackToAttack()
      {
         HREntity result = null;
         if (HRPlayer.GetLocalPlayer().GetNumEnemyMinionsInPlay() <
            HRPlayer.GetLocalPlayer().GetNumFriendlyMinionsInPlay() ||
            HRPlayer.GetLocalPlayer().GetNumEnemyMinionsInPlay() < 4)
         {
            result = HRBattle.GetNextMinionByPriority(MinionPriority.Hero);
         }
         else
            result = HRBattle.GetNextMinionByPriority(MinionPriority.LowestHealth);

         if (result == null)
            return HRPlayer.GetEnemyPlayer().GetHero();

         return result;
      }

      protected virtual ActionBase AttackTauntMinions(PlayerState EnemyState)
      {
         // TODO: Sort list by ATK, descending.
         if (EnemyState.TauntMinions.Count == 0)
            return null;

         foreach (var item in EnemyState.TauntMinions)
         {
            if (!item.IsStealthed())
            {
               var power = PlayerState.GetPossibleAttack(
                  HRPlayer.GetLocalPlayer(), item.GetRemainingHP());

               if (power.Attack >= item.GetRemainingHP())
               {
                  if (power.Cards.Count > 0)
                     return new AttackAction(power.Cards[0], item);
               }

            }
         }

         // There are enemy Taunts but we cannot kill at least one
         // of them. :/
         //
         // Just attack it...
         var nextTaunt = EnemyState.TauntMinions[0];

         // No taunts found that can be killed, attack first one.
         var current = PlayerState.GetPossibleAttack(
            HRPlayer.GetLocalPlayer(), nextTaunt.GetRemainingHP());

         if (current.Cards.Count > 0)
            return new AttackAction(current.Cards[0], nextTaunt);
         return null;
      }

      private HREngine.API.Actions.ActionBase UpdateMulliganState()
      {
         if (HRMulligan.IsMulliganActive())
         {
            var list = HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.HAND);
            foreach (var item in list)
            {
               if (!RejectedCardList.ContainsKey(item.GetEntity().GetEntityId()) && item.GetEntity().GetCost() >= 4)
               {
                  RejectedCardList.Add(item.GetEntity().GetEntityId(), item);
                  return new RejectCardsAction(item);
               }
            }
         }
         return null;
      }

      private Dictionary<int, HRCard> RejectedCardList;

      private PlayCardAction NextFixedAction { get; set; }
   }

   public class PlayerPossibleAttack
   {
      public PlayerPossibleAttack()
      {
         Cards = new List<HREntity>();
      }

      public int Cost { get; set; }
      public int Attack { get; set; }
      public List<HREntity> Cards { get; private set; }
   }

   public class PlayerState
   {
      public PlayerState(HRPlayer Player)
      {
         this.Player = Player;
         TauntMinions = GetTauntMinions();
         AttackableMinions = GetAttackableMinions();
         ReadyMinions = GetReadyMinions();
         ChargeMinions = GetChargeMinions();

         Minions = Player.GetNumFriendlyMinionsInPlay();
         Health = Player.GetHero().GetRemainingHP() + Player.GetHero().GetArmor();
         Mana = Player.GetNumAvailableResources();
      }

      public static PlayerPossibleAttack GetPossibleAttack(HRPlayer Player, int RequiredAttack, int Limit = -1)
      {
         var result = new PlayerPossibleAttack();
         var playerState = new PlayerState(Player);

         // TODO: Sort list by ATK, descending.

         // Loop through all minions that can attack..
         foreach (var item in playerState.ReadyMinions)
         {
            if (HRCardManager.CanAttackWithCard(item.GetCard()))
            {
               if (Limit == -1)
               {
                  result.Attack += item.GetATK();
                  result.Cards.Add(item);
               }
               else if (result.Cards.Count + 1 == Limit)
               {
                  // Try to find a combination that matches...
                  if (result.Attack + item.GetATK() >= RequiredAttack)
                  {
                     result.Attack += item.GetATK();
                     result.Cards.Add(item);
                  }
               }
               else
               {
                  result.Attack += item.GetATK();
                  result.Cards.Add(item);
               }
            }
         }

         if (result.Attack < RequiredAttack)
         {
            int remainingMana = Player.GetNumAvailableResources();

            // Check other resources that can deal damage.

            // Deal damage with hero power?
            if (Player.GetHeroPower().GetATK() > 0)
            {
               if (Player.GetHeroPower().GetCost() <= remainingMana)
               {
                  result.Attack += Player.GetHeroPower().GetATK();
                  result.Cost += Player.GetHeroPower().GetCost();
                  result.Cards.Add(Player.GetHeroPower());
                  remainingMana -= Player.GetHeroPower().GetCost();
               }
            }

            // Hero Card most times: Weapons and other special stuff.
            if (Player.HasWeapon() && Player.GetWeaponCard().GetEntity().GetATK() > 0
               && Player.GetWeaponCard().GetEntity().CanAttack()
               && Player.GetWeaponCard().GetEntity().GetCost() <= remainingMana)
            {
               if (HRCardManager.CanAttackWithCard(Player.GetHero().GetCard()))
               {
                  result.Attack += Player.GetWeaponCard().GetEntity().GetATK();
                  result.Cost += Player.GetWeaponCard().GetEntity().GetCost();
                  result.Cards.Add(Player.GetWeaponCard().GetEntity());

                  remainingMana -= Player.GetHero().GetCost();            
               }
            }

            // Remaining cards on hand?
            List<HRCard> playerHand = HRCard.GetCards(Player, HRCardZone.HAND);
            foreach (var item in playerHand)
            {
               if ((item.GetEntity().IsSpell()  ||
                  (item.GetEntity().IsMinion() && item.GetEntity().HasCharge())) &&
                  item.GetEntity().GetATK() > 0)
               {
                  int cost = item.GetEntity().GetCost();
                  if (cost <= remainingMana)
                  {
                     result.Attack += item.GetEntity().GetATK();
                     result.Cost += cost;
                     result.Cards.Add(item.GetEntity());
                     remainingMana -= cost;
                  }
               }
            }
         }

         return result;
      }

      private List<HREntity> GetChargeMinions()
      {
         List<HREntity> result = new List<HREntity>();
         List<HRCard> list = HRCard.GetCards(Player, HRCardZone.HAND);
         foreach (var item in list)
         {
            if (item.GetEntity().HasCharge())
               result.Add(item.GetEntity());
         }
         return result;
      }

      private List<HREntity> GetReadyMinions()
      {
         List<HREntity> result = new List<HREntity>();
         List<HRCard> list = HRCard.GetCards(Player, HRCardZone.PLAY);
         foreach (var item in list)
         {
            if (item.GetEntity().CanBeAttacked())
               result.Add(item.GetEntity());
         }
         return result;
      }

      private List<HREntity> GetAttackableMinions()
      {
         List<HREntity> result = new List<HREntity>();
         List<HRCard> list = HRCard.GetCards(Player, HRCardZone.PLAY);
         foreach (var item in list)
         {
            if (item.GetEntity().CanBeAttacked())
               result.Add(item.GetEntity());
         }
         return result;
      }

      private List<HREntity> GetTauntMinions()
      {
         List<HREntity> result = new List<HREntity>();
         List<HRCard> list = HRCard.GetCards(Player, HRCardZone.PLAY);
         foreach (var item in list)
         {
            if (item.GetEntity().HasTaunt())
               result.Add(item.GetEntity());
         }
         return result;
      }

      public override string ToString()
      {
         return String.Empty;
      }

      public HRPlayer Player { get; private set; }
      public List<HREntity> TauntMinions { get; private set; }
      public List<HREntity> AttackableMinions { get; private set; }
      public List<HREntity> ReadyMinions { get; private set; }
      public List<HREntity> ChargeMinions { get; private set; }
      public int Minions { get; private set; }
      public int Health { get; private set; }
      public int Mana { get; private set; }
   }
}
