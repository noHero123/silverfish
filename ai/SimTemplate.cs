// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimTemplate.cs" company="">
//   
// </copyright>
// <summary>
//   The sim template.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim template.
    /// </summary>
    public class SimTemplate
    {
        /// <summary>
        /// The on secret play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="attacker">
        /// The attacker.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
        }

        /// <summary>
        /// The on secret play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            return;
        }

        /// <summary>
        /// The on secret play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        public virtual void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            return;
        }

        /// <summary>
        /// The on card play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public virtual void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            return;
        }

        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public virtual void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            return;
        }

        /// <summary>
        /// The on aura starts.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public virtual void onAuraStarts(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// The on aura ends.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public virtual void onAuraEnds(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// The on enrage start.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public virtual void onEnrageStart(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// The on enrage stop.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public virtual void onEnrageStop(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// The on a minion got healed trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="ownerOfMinionGotHealed">
        /// The owner of minion got healed.
        /// </param>
        public virtual void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfMinionGotHealed)
        {
            return;
        }

        /// <summary>
        /// The on a hero got healed trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="ownerOfHeroGotHealed">
        /// The owner of hero got healed.
        /// </param>
        public virtual void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfHeroGotHealed)
        {
            return;
        }

        /// <summary>
        /// The on turn ends trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnEndOfOwner">
        /// The turn end of owner.
        /// </param>
        public virtual void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            return;
        }

        /// <summary>
        /// The on turn start trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnStartOfOwner">
        /// The turn start of owner.
        /// </param>
        public virtual void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            return;
        }

        /// <summary>
        /// The on minion got dmg trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="ownDmgdMinion">
        /// The own dmgd minion.
        /// </param>
        public virtual void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, bool ownDmgdMinion)
        {
            return;
        }

        /// <summary>
        /// The on minion died trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="diedMinion">
        /// The died minion.
        /// </param>
        public virtual void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            return;
        }

        /// <summary>
        /// The on minion is summoned.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="summonedMinion">
        /// The summoned minion.
        /// </param>
        public virtual void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        /// <summary>
        /// The on minion was summoned.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="summonedMinion">
        /// The summoned minion.
        /// </param>
        public virtual void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public virtual void onDeathrattle(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// The on card is going to be played.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <param name="wasOwnCard">
        /// The was own card.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        public virtual void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }

        /// <summary>
        /// The on card was played.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <param name="wasOwnCard">
        /// The was own card.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        public virtual void onCardWasPlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }




    }

}
