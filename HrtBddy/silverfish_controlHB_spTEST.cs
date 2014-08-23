using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Triton.Bot;
using Triton.Common;
using Triton.Game;

//using System.Linq;

namespace SilverfishControlSPTEST
{
    public class SilverControlSPTEST : ICustomDeck
    {
        private readonly PenalityManager penman = PenalityManager.Instance;
        private readonly Silverfish sf;
        private string choiceCardId = "";
        private int concedeLvl = 20; // the rank, till you want to concede
        private int dirtyTargetSource = -1;
        private int dirtychoice = -1;
        private int dirtytarget = -1;

        Behavior behave = new BehaviorControl();

        public SilverControlSPTEST()
        {
            bool concede = false;
            bool writeToSingleFile = false;

            sf = new Silverfish(writeToSingleFile);
            Mulligan.Instance.setAutoConcede(concede);

            sf.setnewLoggFile();

            int enfacehp = 15;
            Helpfunctions.Instance.ErrorLog("set enemy-face-hp to: " + enfacehp);
            ComboBreaker.Instance.attackFaceHP = enfacehp;

            int mxwde = 3000;
            Ai.Instance.setMaxWide(mxwde);
            Helpfunctions.Instance.ErrorLog("set maxwide to: " + mxwde);

            bool twots = false;
            if (twots)
            {
                Ai.Instance.setTwoTurnSimulation(twots);
                Helpfunctions.Instance.ErrorLog("activated two turn simulation");
            }

            bool playaround = false;
            if (playaround)
            {
                Ai.Instance.setPlayAround(playaround);
                Helpfunctions.Instance.ErrorLog("activated playaround");
            }

            Helpfunctions.Instance.ErrorLog("write to single log file is: " + writeToSingleFile);


            bool teststuff = false;
            // set to true, to run a testfile (requires test.txt file in filder where _cardDB.txt file is located)
            bool printstuff = false; // if true, the best board of the tested file is printet stepp by stepp
            Helpfunctions.Instance.ErrorLog("----------------------------");
            Helpfunctions.Instance.ErrorLog("you are running uai V" + sf.versionnumber);
            Helpfunctions.Instance.ErrorLog("----------------------------");
            if (teststuff)
            {
                Ai.Instance.autoTester(behave, printstuff);
            }
        }

        // you may have to out-comment the code in this function (its for conceding)
        /*
     private void concede()
      {
          int curlvl = HRPlayer.GetLocalPlayer().GetRank();
          if (HREngine.API.Utilities.HRSettings.Get.SelectedGameMode != HRGameMode.RANKED_PLAY) return;
          if (curlvl < this.concedeLvl)
          {
              Helpfunctions.Instance.ErrorLog("not today!");
              HRGame.ConcedeGame();
          }
      }


        // HC mulligan
      private HREngine.API.Actions.ActionBase HandleBattleMulliganPhase()
      {
          Helpfunctions.Instance.ErrorLog("handle mulligan");

          if (HRMulligan.IsMulliganActive())
          {
              var list = HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.HAND);
              if (Mulligan.Instance.hasmulliganrules())
              {
                  HRPlayer enemyPlayer = HRPlayer.GetEnemyPlayer();
                  string enemName = Hrtprozis.Instance.heroIDtoName(enemyPlayer.GetHeroCard().GetEntity().GetCardId());
                  List<Mulligan.CardIDEntity> celist = new List<Mulligan.CardIDEntity>();
                  foreach (var item in list)
                  {
                      if (item.GetEntity().GetCardId() != "GAME_005")// dont mulligan coin
                      {
                          celist.Add(new Mulligan.CardIDEntity(item.GetEntity().GetCardId(), item.GetEntity().GetEntityId()));
                      }
                  }
                  List<int> mullientitys = Mulligan.Instance.whatShouldIMulligan(celist, enemName);
                  foreach (var item in list)
                  {
                      if (mullientitys.Contains(item.GetEntity().GetEntityId()))
                      {
                          Helpfunctions.Instance.ErrorLog("Rejecting Mulligan Card " + item.GetEntity().GetName() + " because of your rules");
                          HRMulligan.ToggleCard(item);
                      }
                  }


              }
              else
              {
                  foreach (var item in list)
                  {
                      if (item.GetEntity().GetCost() >= 4)
                      {
                          Helpfunctions.Instance.ErrorLog("Rejecting Mulligan Card " + item.GetEntity().GetName() + " because it cost is >= 4.");
                          HRMulligan.ToggleCard(item);
                      }
                      if (item.GetEntity().GetCardId() == "EX1_308" || item.GetEntity().GetCardId() == "EX1_622" || item.GetEntity().GetCardId() == "EX1_005")
                      {
                          Helpfunctions.Instance.ErrorLog("Rejecting Mulligan Card " + item.GetEntity().GetName() + " because it is soulfire or shadow word: death");
                          HRMulligan.ToggleCard(item);
                      }
                  }
              }


              sf.setnewLoggFile();

              if (Mulligan.Instance.loserLoserLoser)
              {
                  concede();
              }
              return null;
              //HRMulligan.EndMulligan();
          }
          return null;
      }

        */

        /// <summary>
        ///     [EN]
        ///     This handler is executed when the local player turn is active.
        /// </summary>
        public IEnumerator SelectCard()
        {
            if (TritonHS.IsInTargetMode())
            {
                if (dirtytarget >= 0)
                {
                    Logging.Write("targeting...");
                    HSCard source = null;
                    if (dirtyTargetSource == 9000) // 9000 = ability
                    {
                        source = TritonHS.OurHeroPowerCard;
                    }
                    else
                    {
                        source = getEntityWithNumber(dirtyTargetSource);
                    }
                    HSCard target = getEntityWithNumber(dirtytarget);

                    if (target == null) Logging.Write("error: target is null...");

                    dirtytarget = -1;
                    dirtyTargetSource = -1;

                    if (source == null) TritonHS.DoTarget(target);
                    else source.DoTarget(target);

                    yield break;
                }
                Logging.Write("target failure...");
                TritonHS.CancelTargetingMode();
            }

            if (TritonHS.IsInChoiceMode())
            {
                if (dirtychoice >= 1)
                {
                    //dirtychoice == 1 -> choose left card, 
                    // dirty choice == 2 -> right card

                    Helpfunctions.Instance.logg("chooses the card: " + dirtychoice);
                    if (dirtychoice == 1)
                    {
                        TritonHS.ChooseOneClickLeft();
                    }
                    else
                    {
                        TritonHS.ChooseOneClickRight();
                    }
                    dirtychoice = -1;
                    yield break;
                }
                //Todo: ultimate tracking-simulation!
                var r = new Random();
                int choice = r.Next(0, 2);
                Helpfunctions.Instance.logg("chooses a random card");
                TritonHS.ChooseOneClickLeft();
                yield break;
            }

            sf.updateEverything(behave);
            Action moveTodo = Ai.Instance.bestmove;
            if (moveTodo == null)
            {
                Helpfunctions.Instance.ErrorLog("end turn");
                TritonHS.EndTurn();
                yield break;
            }
            Helpfunctions.Instance.ErrorLog("play action");
            moveTodo.print();

            //play the move#########################################################################

            //play a card form hand
            if (moveTodo.cardplay)
            {
                HSCard cardtoplay = getCardWithNumber(moveTodo.cardEntitiy);
                if (moveTodo.enemytarget >= 0)
                {
                    HSCard target = getEntityWithNumber(moveTodo.enemyEntitiy);
                    Helpfunctions.Instance.ErrorLog("play: " + cardtoplay.Name + " target: " + target.Name);
                    Helpfunctions.Instance.logg("play: " + cardtoplay.Name + " target: " + target.Name + " choice: " +
                                                moveTodo.druidchoice);

                    if (moveTodo.druidchoice >= 1)
                    {
                        if (moveTodo.enemyEntitiy >= 0) dirtytarget = moveTodo.enemyEntitiy;
                        dirtychoice = moveTodo.druidchoice; //1=leftcard, 2= rightcard
                        choiceCardId = moveTodo.handcard.card.cardIDenum.ToString();
                    }

                    //safe targeting stuff for hsbuddy
                    dirtyTargetSource = moveTodo.cardEntitiy;
                    dirtytarget = moveTodo.enemyEntitiy;

                    cardtoplay.DoGrab();
                    if (moveTodo.handcard.card.type == CardDB.cardtype.MOB)
                    {

                        //TEST
                        bool testing = true;
                        int testingtarget = 0;
                        while (testing)
                        {
                            try
                            {
                                TritonHS.SetCursorPos(testingtarget);
                                
                            }
                            catch
                            {
                                testing = false;
                            }
                            yield return Coroutine.Sleep(2000);
                            testingtarget++;
                        }

                        int place = this.localPosToGlobalPos(moveTodo.owntarget, Hrtprozis.Instance.ownMinions.Count);
                        TritonHS.SetCursorPos(place);
                    }
                    
                    yield return Coroutine.Sleep(500);
                    
                    cardtoplay.DoDrop();
                    yield break;
                }

                Helpfunctions.Instance.ErrorLog("play: " + cardtoplay.Name + " target nothing");
                Helpfunctions.Instance.logg("play: " + cardtoplay.Name + " choice: " + moveTodo.druidchoice);
                if (moveTodo.druidchoice >= 1)
                {
                    dirtychoice = moveTodo.druidchoice; //1=leftcard, 2= rightcard
                    choiceCardId = moveTodo.handcard.card.cardIDenum.ToString();
                }

                dirtyTargetSource = -1;
                dirtytarget = -1;

                cardtoplay.DoGrab();
                if (moveTodo.handcard.card.type == CardDB.cardtype.MOB)
                {
                    //TEST
                    bool testing2 = true;
                    int testingtarget2 = 0;
                    while (testing2)
                    {
                        try
                        {
                            TritonHS.SetCursorPos(testingtarget2);

                        }
                        catch
                        {
                            testing2 = false;
                        }
                        yield return Coroutine.Sleep(2000);
                        testingtarget2++;
                    }

                    int place = this.localPosToGlobalPos(moveTodo.owntarget, Hrtprozis.Instance.ownMinions.Count);
                    TritonHS.SetCursorPos(place);
                }
                yield return Coroutine.Sleep(500);
                cardtoplay.DoDrop();
                yield break;
            }

            //attack with minion
            if (moveTodo.minionplay)
            {
                HSCard attacker = getEntityWithNumber(moveTodo.ownEntitiy);
                HSCard target = getEntityWithNumber(moveTodo.enemyEntitiy);
                Helpfunctions.Instance.ErrorLog("minion attack: " + attacker.Name + " target: " + target.Name);
                Helpfunctions.Instance.logg("minion attack: " + attacker.Name + " target: " + target.Name);
                attacker.DoAttack(target);
                yield break;
            }
            //attack with hero
            if (moveTodo.heroattack)
            {
                HSCard attacker = getEntityWithNumber(moveTodo.ownEntitiy);
                HSCard target = getEntityWithNumber(moveTodo.enemyEntitiy);
                dirtytarget = moveTodo.enemyEntitiy;
                Helpfunctions.Instance.ErrorLog("heroattack: " + attacker.Name + " target: " + target.Name);
                Helpfunctions.Instance.logg("heroattack: " + attacker.Name + " target: " + target.Name);

                //safe targeting stuff for hsbuddy
                dirtyTargetSource = moveTodo.ownEntitiy;
                dirtytarget = moveTodo.enemyEntitiy;
                attacker.DoAttack(target);
                yield break;
            }

            //use ability
            if (moveTodo.useability)
            {
                HSCard cardtoplay = TritonHS.OurHeroPowerCard;

                if (moveTodo.enemytarget >= 0)
                {
                    HSCard target = getEntityWithNumber(moveTodo.enemyEntitiy);
                    dirtyTargetSource = 9000;
                    dirtytarget = moveTodo.enemyEntitiy;

                    Helpfunctions.Instance.ErrorLog("use ablitiy: " + cardtoplay.Name + " target " + target.Name);
                    Helpfunctions.Instance.logg("use ablitiy: " + cardtoplay.Name + " target " + target.Name);
                }
                else
                {
                    Helpfunctions.Instance.ErrorLog("use ablitiy: " + cardtoplay.Name +
                                                    " target nothing");
                    Helpfunctions.Instance.logg("use ablitiy: " + cardtoplay.Name + " target nothing");
                }
                cardtoplay.DoGrab();
                yield return Coroutine.Sleep(500);
                cardtoplay.DoDrop();
                yield break;
            }

            TritonHS.EndTurn();
        }

        private int localPosToGlobalPos(int lp, int numMins)
        {
            int gp = lp;
            string place = "left of your first minion";
            if (lp == 1) place = "right of your first minion";
            if (lp == 2) place = "right of your second minion";
            if (lp == 3) place = "right of your third minion";
            if (lp == 4) place = "right of your 4th minion";
            if (lp == 5) place = "right of your 5th minion";
            if (lp == 6) place = "right of your 6th minion";
            if (lp == 7) place = "right of your 7th minion";

            
            if (numMins == 6) { gp = lp; }
            if (numMins == 4) { gp = lp + 1; }
            if (numMins == 2) { gp = lp + 2; }
            if (numMins == 1) { gp = lp + 2; }
            if (numMins == 3) { gp = lp + 1; }
            if (numMins == 5) { gp = lp + 0; }
            if (numMins == 0) { gp = 5; }
            Helpfunctions.Instance.ErrorLog("should place minion " + place + " (" + lp + " " + numMins+") " );
            Helpfunctions.Instance.logg("should place minion " + place + " (" + lp + " " + numMins + ") ");
            return gp;
        }

        private HSCard getEntityWithNumber(int number)
        {
            foreach (HSCard e in getallEntitys())
            {
                if (number == e.EntityId) return e;
            }
            return null;
        }

        private HSCard getCardWithNumber(int number)
        {
            foreach (HSCard e in getallHandCards())
            {
                if (number == e.EntityId) return e;
            }
            return null;
        }

        private List<HSCard> getallEntitys()
        {
            var result = new List<HSCard>();
            HSCard ownhero = TritonHS.OurHero;
            HSCard enemyhero = TritonHS.EnemyHero;
            HSCard ownHeroAbility = TritonHS.OurHeroPowerCard;
            List<HSCard> list2 = TritonHS.GetCards(CardZone.Battlefield, true);
            List<HSCard> list3 = TritonHS.GetCards(CardZone.Battlefield, false);

            result.Add(ownhero);
            result.Add(enemyhero);
            result.Add(ownHeroAbility);

            result.AddRange(list2);
            result.AddRange(list3);

            return result;
        }

        private List<HSCard> getallHandCards()
        {
            List<HSCard> list = TritonHS.GetCards(CardZone.Hand, true);
            return list;
        }

        protected virtual void SafeHandleBattleLocalPlayerTurnHandler()
        {
        }

        protected virtual HSCard GetMinionByPriority(HSCard lastMinion = null)
        {
            return null;
        }
    }

    public class Silverfish
    {
        public int versionnumber = 89;

        private readonly List<Minion> enemyMinions = new List<Minion>();
        private readonly List<Handmanager.Handcard> handCards = new List<Handmanager.Handcard>();
        private readonly List<Minion> ownMinions = new List<Minion>();
        private readonly bool singleLog;


        private readonly Settings sttngs = Settings.Instance;
        private int anzcards;
        private int cardsPlayedThisTurn;
        private int currentMana;
        private CardDB.Card enemyAbility = new CardDB.Card();
        private int enemyAnzCards;
        private int enemyAtk;
        private int enemyDecksize = 0;
        private int enemyDefence;
        private int enemyHeroFatigue;
        private bool enemyHeroImmune;

        private string enemyHeroWeapon = "";
        private string enemyHeroname = "";
        private int enemyHp = 30;
        private int enemyMaxMana;
        private int enemySecretCount;
        private int enemyWeaponAttack;
        private int enemyWeaponDurability;
        private bool enemyfrozen;

        private CardDB.Card heroAbility = new CardDB.Card();

        private int heroAtk;
        private int heroDefence;
        private bool heroHasWindfury;
        private int heroHp = 30;
        private bool heroImmune;
        private bool heroImmuneToDamageWhileAttacking;
        private int heroNumAttacksThisTurn;
        private int heroWeaponAttack;
        private int heroWeaponDurability;
        private bool herofrozen;
        private string heroname = "";
        private int numMinionsPlayedThisTurn;

        private bool ownAbilityisReady;
        private int ownDecksize = 0;
        private int ownHeroFatigue;
        private string ownHeroWeapon = "";
        private int ownMaxMana;
        private int ownPlayerController;
        private int ourSecretsCount;
        private List<string> ownSecretList = new List<string>();
        private bool ownheroisread;
        private int ueberladung;


        public Silverfish(bool snglLg)
        {
            singleLog = snglLg;
            Helpfunctions.Instance.ErrorLog("init Silverfish");

            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                               Environment.OSVersion.Platform == PlatformID.MacOSX)
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            string p = "./CustomDecks/Silverfish/";//homePath + Path.DirectorySeparatorChar + "uaiFiles" + Path.DirectorySeparatorChar;

            // change this two paths!!!!! (the (HRSettings.Get.CustomRuleFilePath).Remove(HRSettings.Get.CustomRuleFilePath.Length - 13))
            string path = p + "UltimateLogs" + Path.DirectorySeparatorChar;
            Directory.CreateDirectory(path);
            sttngs.setFilePath(p + "Data" + Path.DirectorySeparatorChar);

            if (!singleLog)
            {
                sttngs.setLoggPath(path);
            }
            else
            {
                sttngs.setLoggPath(p);
                sttngs.setLoggFile("UILogg.txt");
                Helpfunctions.Instance.createNewLoggfile();
            }
            PenalityManager.Instance.setCombos();
            Mulligan m = Mulligan.Instance; // read the mulligan list
        }

        public void setnewLoggFile()
        {
            if (!singleLog)
            {
                sttngs.setLoggFile("UILogg" + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss") + ".txt");
                Helpfunctions.Instance.createNewLoggfile();
                Helpfunctions.Instance.ErrorLog("#######################################################");
                Helpfunctions.Instance.ErrorLog("fight is logged in: " + sttngs.logpath + sttngs.logfile);
                Helpfunctions.Instance.ErrorLog("#######################################################");
            }
            else
            {
                sttngs.setLoggFile("UILogg.txt");
            }
        }

        public void updateEverything(Behavior botbase)
        {
            ownPlayerController = TritonHS.OurHero.ControllerId;
            // create hero + minion data
            getHerostuff();

            //small fix for not knowing when to mulligan:
            if (ownMaxMana == 1 && numMinionsPlayedThisTurn == 0 && cardsPlayedThisTurn == 0) setnewLoggFile();

            getMinions();
            getHandcards();

            // send ai the data:
            Hrtprozis.Instance.clearAll();
            Handmanager.Instance.clearAll();

            Hrtprozis.Instance.setOwnPlayer(ownPlayerController);
            Handmanager.Instance.setOwnPlayer(ownPlayerController);

            Hrtprozis.Instance.updatePlayer(ownMaxMana, currentMana, cardsPlayedThisTurn, numMinionsPlayedThisTurn,
                ueberladung, TritonHS.OurHero.EntityId, TritonHS.EnemyHero.EntityId);
            Hrtprozis.Instance.updateSecretStuff(ownSecretList, enemySecretCount);

            Hrtprozis.Instance.updateOwnHero(ownHeroWeapon, heroWeaponAttack, heroWeaponDurability,
                heroImmuneToDamageWhileAttacking, heroAtk, heroHp, heroDefence, heroname, ownheroisread, herofrozen,
                heroAbility, ownAbilityisReady, heroNumAttacksThisTurn, heroHasWindfury, heroImmune);
            Hrtprozis.Instance.updateEnemyHero(enemyHeroWeapon, enemyWeaponAttack, enemyWeaponDurability, enemyAtk,
                enemyHp, enemyDefence, enemyHeroname, enemyfrozen, enemyAbility, enemyHeroImmune, enemyMaxMana);

            Hrtprozis.Instance.updateMinions(ownMinions, enemyMinions);
            Handmanager.Instance.setHandcards(handCards, anzcards, enemyAnzCards);

            Hrtprozis.Instance.updateFatigueStats(ownDecksize, ownHeroFatigue, enemyDecksize, enemyHeroFatigue);

            // print data
            Hrtprozis.Instance.printHero();
            Hrtprozis.Instance.printOwnMinions();
            Hrtprozis.Instance.printEnemyMinions();
            Handmanager.Instance.printcards();

            // calculate stuff
            Helpfunctions.Instance.ErrorLog("calculating stuff... " + DateTime.Now.ToString("HH:mm:ss.ffff"));
            Ai.Instance.dosomethingclever(botbase);
            Helpfunctions.Instance.ErrorLog("calculating ended! " + DateTime.Now.ToString("HH:mm:ss.ffff"));
        }

        private void getHerostuff()
        {
            //player stuff#########################
            //this.currentMana =ownPlayer.GetTag(HRGameTag.RESOURCES) - ownPlayer.GetTag(HRGameTag.RESOURCES_USED) + ownPlayer.GetTag(HRGameTag.TEMP_RESOURCES);
            currentMana = TritonHS.CurrentMana;
            ownMaxMana = TritonHS.Resources;
            enemyMaxMana = ownMaxMana;
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("start calculations, current time: " + DateTime.Now.ToString("HH:mm:ss") + " V" +
                                        versionnumber);
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("mana " + currentMana + "/" + ownMaxMana);
            Helpfunctions.Instance.logg("emana " + enemyMaxMana);

            //count own secrets
            ownSecretList = new List<string>(); // the CARDIDS of the secrets
            ourSecretsCount = 0;
            Helpfunctions.Instance.logg("own secretsCount: " + ourSecretsCount);
            //count enemy secrets
            enemySecretCount = 0;
            Helpfunctions.Instance.logg("enemy secretsCount: " + enemySecretCount);


            numMinionsPlayedThisTurn = TritonHS.NumMinionsPlayedThisTurn;
            cardsPlayedThisTurn = TritonHS.NumCardsPlayedThisTurn;
            ueberladung = TritonHS.RecallOwed;

            //get weapon stuff
            ownHeroWeapon = "";
            heroWeaponAttack = 0;
            heroWeaponDurability = 0;

            ownHeroFatigue = TritonHS.Fatigue;
            enemyHeroFatigue = 0; // hankerspace has only one value for fatigue

            //this.ownDecksize = Triton.Game.TritonHS.GetCards(Triton.Game.CardZone.Deck, true).Count;// or something like this :D
            //this.enemyDecksize = Triton.Game.TritonHS.GetCards(Triton.Game.CardZone.Deck, false).Count;// or something like this :D

            heroImmune = TritonHS.OurHero.IsImmune;
            enemyHeroImmune = TritonHS.EnemyHero.IsImmune;

            enemyHeroWeapon = "";
            enemyWeaponAttack = 0;
            enemyWeaponDurability = 0;

            if (TritonHS.DoesEnemyHasWeapon)
            {
                HSCard weapon = TritonHS.EnemyWeaponCard;
                enemyHeroWeapon =
                    CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(weapon.Id)).name.ToString();
                enemyWeaponAttack = weapon.Attack;
                enemyWeaponDurability = weapon.Durability;
            }


            //own hero stuff###########################
            heroAtk = TritonHS.OurHeroAttack;
            heroHp = TritonHS.OurHeroHealthAndArmor - TritonHS.OurHeroArmor;
            heroDefence = TritonHS.OurHeroArmor;
            heroname = Hrtprozis.Instance.heroIDtoName(TritonHS.OurHero.Id);
            bool exausted = false;
            exausted = TritonHS.OurHero.IsExhausted;
            ownheroisread = true;

            heroImmuneToDamageWhileAttacking = (TritonHS.OurHero.IsImmune) ? true : false;
            herofrozen = TritonHS.OurHero.IsFrozen;
            heroNumAttacksThisTurn = TritonHS.OurHero.NumAttackThisTurn;
            heroHasWindfury = TritonHS.OurHero.HasWindfury;

            //Helpfunctions.Instance.ErrorLog(ownhero.GetName() + " ready params ex: " + exausted + " " + heroAtk + " " + numberofattacks + " " + herofrozen);

            if (exausted)
            {
                ownheroisread = false;
            }
            if (exausted == false && heroAtk == 0)
            {
                ownheroisread = false;
            }
            if (herofrozen) ownheroisread = false;


            if (TritonHS.DoWeHaveWeapon)
            {
                HSCard weapon = TritonHS.OurWeaponCard;
                ownHeroWeapon =
                    CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(weapon.Id)).name.ToString();
                heroWeaponAttack = weapon.Attack;
                heroWeaponDurability = weapon.Durability; //weapon.GetDurability();
                heroImmuneToDamageWhileAttacking = false;
                if (ownHeroWeapon == "gladiatorslongbow")
                {
                    heroImmuneToDamageWhileAttacking = true;
                }

                //Helpfunctions.Instance.ErrorLog("weapon: " + ownHeroWeapon + " " + heroWeaponAttack + " " + heroWeaponDurability);
            }

            //enemy hero stuff###############################################################
            enemyAtk = TritonHS.EnemyHeroAttack; //lol should be zero :D

            enemyHp = TritonHS.EnemyHeroHealthAndArmor - TritonHS.EnemyHeroArmor;

            enemyHeroname = Hrtprozis.Instance.heroIDtoName(TritonHS.EnemyHero.Id);

            enemyDefence = TritonHS.EnemyHeroArmor;

            enemyfrozen = TritonHS.EnemyHero.IsFrozen;


            //own hero ablity stuff###########################################################

            heroAbility =
                CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(TritonHS.OurHeroPowerCard.Id));
            ownAbilityisReady = (TritonHS.OurHeroPowerCard.IsExhausted) ? false : true;
            // if exhausted, ability is NOT ready

            enemyAbility =
                CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(TritonHS.OurHeroPowerCard.Id));
            // not correct :D
        }

        private void getMinions()
        {
            ownMinions.Clear();
            enemyMinions.Clear();

            // ALL minions on Playfield:
            List<HSCard> list = TritonHS.GetCards(CardZone.Battlefield, true);
            list.AddRange(TritonHS.GetCards(CardZone.Battlefield, false));

            var enchantments = new List<HSCard>();


            foreach (HSCard entitiy in list)
            {
                int zp = entitiy.ZonePosition;

                if (entitiy.IsMinion && zp >= 1)
                {
                    //Helpfunctions.Instance.ErrorLog("zonepos " + zp);
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.Id));
                    var m = new Minion();
                    m.name = c.name;
                    m.handcard.card = c;

                    m.Angr = entitiy.Attack;
                    m.maxHp = entitiy.MaxHp;
                    m.Hp = entitiy.Health;

                    m.wounded = false;
                    if (m.maxHp > m.Hp) m.wounded = true;

                    m.exhausted = entitiy.IsExhausted;

                    m.taunt = (entitiy.HasTaunt) ? true : false;

                    m.charge = (entitiy.HasCharge) ? true : false;

                    m.numAttacksThisTurn = entitiy.NumAttackThisTurn;

                    m.playedThisTurn = (entitiy.IsRecentlyArrived) ? true : false;

                    m.windfury = (entitiy.HasWindfury) ? true : false;

                    m.frozen = (entitiy.IsFrozen) ? true : false;

                    m.divineshild = (entitiy.HasDivineShield) ? true : false;

                    m.stealth = (entitiy.IsStealthed) ? true : false;

                    m.poisonous = (entitiy.IsPoisonous) ? true : false;

                    m.immune = (entitiy.IsImmune) ? true : false;

                    m.silenced = (entitiy.IsSilenced) ? true : false;


                    m.zonepos = zp;
                    m.id = m.zonepos - 1;

                    m.entitiyID = entitiy.EntityId;

                    m.enchantments.Clear();

                    //Helpfunctions.Instance.ErrorLog(  m.name + " ready params ex: " + m.exhausted + " charge: " +m.charge + " attcksthisturn: " + m.numAttacksThisTurn + " playedthisturn " + m.playedThisTurn );

                    m.Ready = false; // if exhausted, he is NOT ready

                    if (!m.playedThisTurn && !m.exhausted && !m.frozen &&
                        (m.numAttacksThisTurn == 0 || (m.numAttacksThisTurn == 1 && m.windfury)))
                    {
                        m.Ready = true;
                    }

                    if (m.playedThisTurn && m.charge &&
                        (m.numAttacksThisTurn == 0 || (m.numAttacksThisTurn == 1 && m.windfury)))
                    {
                        //m.exhausted = false;
                        m.Ready = true;
                    }

                    if (!m.silenced &&
                        (m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord))
                    {
                        m.Ready = false;
                    }

                    //adding the enchantments

                    foreach (HSCard enchi in entitiy.AttachedCards)
                    {
                        if (!enchi.IsNull())
                        {
                            Enchantment ench = CardDB.getEnchantmentFromCardID(CardDB.Instance.cardIdstringToEnum(enchi.Id));
                            ench.creator = enchi.CreatorId;
                            ench.controllerOfCreator = enchi.ControllerId;
                            ench.cantBeDispelled = false;
                            m.enchantments.Add(ench);
                        }
                        else
                        {
                            Logging.Write("Attachedcard is null...");
                        }
                    }


                    if (entitiy.ControllerId == ownPlayerController) // OWN minion
                    {
                        ownMinions.Add(m);
                    }
                    else
                    {
                        enemyMinions.Add(m);
                    }
                }
                // minions added
            }
        }

        private void getHandcards()
        {
            handCards.Clear();
            anzcards = 0;
            enemyAnzCards = 0;
            List<HSCard> list = TritonHS.GetCards(CardZone.Hand);
            //List<HRCard> list = HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.HAND);

            foreach (HSCard entitiy in list)
            {
                if (entitiy.ZonePosition >= 1) // own handcard 
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.Id));
                    //c.cost = entitiy.GetCost();
                    //c.entityID = entitiy.GetEntityId();

                    var hc = new Handmanager.Handcard();
                    hc.card = c;
                    hc.position = entitiy.ZonePosition;
                    hc.entity = entitiy.EntityId;
                    hc.manacost = entitiy.Cost;
                    handCards.Add(hc);
                    anzcards++;
                }
            }

            enemyAnzCards = TritonHS.GetCards(CardZone.Hand, false).Count;
            // dont know if you can count the enemys-handcars in this way :D
        }
    }

    public abstract class Behavior
    {
        public virtual int getPlayfieldValue(Playfield p)
        {
            return 0;
        }

        public virtual int getEnemyMinionValue(Minion m, Playfield p)
        {
            return 0;
        }

    }

    public class BehaviorControl : Behavior
    {
        PenalityManager penman = PenalityManager.Instance;

        public override int getPlayfieldValue(Playfield p)
        {
            if (p.value >= -2000000) return p.value;
            int retval = 0;
            int hpboarder = 10;
            if (p.ownHeroName == HeroEnum.warlock && p.enemyHeroName != HeroEnum.mage) hpboarder = 6;
            int aggroboarder = 11;

            retval -= p.evaluatePenality;
            retval += p.owncards.Count * 1;

            retval += p.ownMaxMana;
            retval -= p.enemyMaxMana;

            retval += p.ownMinions.Count * 10;

            retval += p.ownMaxMana * 20 - p.enemyMaxMana * 20;

            if (p.ownHeroHp + p.ownHeroDefence > hpboarder)
            {
                retval += p.ownHeroHp + p.ownHeroDefence;
            }
            else
            {
                retval -= (hpboarder + 1 - p.ownHeroHp - p.ownHeroDefence) * (hpboarder + 1 - p.ownHeroHp - p.ownHeroDefence);
            }


            if (p.enemyHeroHp + p.enemyHeroDefence > aggroboarder)
            {
                retval += -p.enemyHeroHp - p.enemyHeroDefence;
            }
            else
            {
                retval += (int)Math.Pow((aggroboarder + 1 - p.enemyHeroHp - p.enemyHeroDefence), 2);
            }

            if (p.ownWeaponAttack >= 1)
            {
                retval += p.ownWeaponAttack * p.ownWeaponDurability;
            }

            if (!p.enemyHeroFrozen)
            {
                retval -= p.enemyWeaponDurability * p.enemyWeaponAttack;
            }
            else
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    retval += 12;
                }
            }

            retval += p.owncarddraw * 5;
            retval -= p.enemycarddraw * 15;

            int owntaunt = 0;
            int ownMinionsCount = 0;
            foreach (Minion m in p.ownMinions)
            {
                retval += m.Hp * 1;
                retval += m.Angr * 2;
                retval += m.handcard.card.rarity;
                if (m.windfury) retval += m.Angr;
                if (m.divineshild) retval += 1;
                if (m.stealth) retval += 1;
                if (!m.taunt && m.stealth && penman.specialMinions.ContainsKey(m.name)) retval += 20;
                //if (m.poisonous) retval += 1;
                if (m.divineshild && m.taunt) retval += 4;
                if (m.taunt && m.handcard.card.name == CardDB.cardName.frog) owntaunt++;
                if (m.Angr > 1 || m.Hp > 1) ownMinionsCount++;
                if (m.handcard.card.hasEffect) retval += 1;
                if (m.handcard.card.name == CardDB.cardName.silverhandrecruit && m.Angr == 1 && m.Hp == 1) retval -= 5;
                if (m.handcard.card.name == CardDB.cardName.direwolfalpha || m.handcard.card.name == CardDB.cardName.flametonguetotem || m.handcard.card.name == CardDB.cardName.stormwindchampion || m.handcard.card.name == CardDB.cardName.raidleader) retval += 10;
                if (m.handcard.card.name == CardDB.cardName.bloodmagethalnos) retval += 10;
            }

            /*if (p.enemyMinions.Count >= 0)
            {
                int anz = p.enemyMinions.Count;
                if (owntaunt == 0) retval -= 10 * anz;
                retval += owntaunt * 10 - 11 * anz;
            }*/

            int playmobs = 0;
            bool useAbili = false;
            bool usecoin = false;
            foreach (Action a in p.playactions)
            {
                if (a.heroattack && p.enemyHeroHp <= p.attackFaceHP) retval++;
                if (a.useability) useAbili = true;
                if (p.ownHeroName == HeroEnum.warrior && a.heroattack && useAbili) retval -= 1;
                if (a.useability && a.handcard.card.name == CardDB.cardName.lesserheal && ((a.enemytarget >= 10 && a.enemytarget <= 20) || a.enemytarget == 200)) retval -= 5;
                if (!a.cardplay) continue;
                if ((a.handcard.card.name == CardDB.cardName.thecoin || a.handcard.card.name == CardDB.cardName.innervate)) usecoin = true;
                if (a.handcard.card.type == CardDB.cardtype.MOB) playmobs++;
                //if (a.handcard.card.name == "arcanemissiles" && a.numEnemysBeforePlayed == 0) retval -= 10; // arkane missles on enemy hero is bad :D

                if (a.handcard.card.name == CardDB.cardName.flamestrike && a.numEnemysBeforePlayed <= 2) retval -= 20;
                //save spell for all classes: (except for rouge if he has no combo)
                if (p.ownHeroName != HeroEnum.thief && a.handcard.card.type == CardDB.cardtype.SPELL && (a.numEnemysBeforePlayed == 0 || a.enemytarget == 200) && a.handcard.card.name != CardDB.cardName.shieldblock) retval -= 11;
                if (p.ownHeroName == HeroEnum.thief && a.handcard.card.type == CardDB.cardtype.SPELL && (a.enemytarget == 200)) retval -= 11;
            }
            if (usecoin && useAbili && p.ownMaxMana <= 2) retval -= 40;
            //if (usecoin && p.mana >= 1) retval -= 20;

            int mobsInHand = 0;
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.type == CardDB.cardtype.MOB && hc.card.Attack >= 3) mobsInHand++;
            }

            if (ownMinionsCount - p.enemyMinions.Count >= 4 && mobsInHand >= 1)
            {
                retval += mobsInHand * 25;
            }



            foreach (Minion m in p.enemyMinions)
            {
                retval -= this.getEnemyMinionValue(m, p);
            }

            retval -= p.enemySecretCount;
            retval -= p.lostDamage;//damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            retval -= p.lostWeaponDamage;
            //if (p.ownMinions.Count == 0) retval -= 20;
            //if (p.enemyMinions.Count == 0) retval += 20;
            if (p.enemyHeroHp <= 0) retval = 10000;
            //soulfire etc
            int deletecardsAtLast = 0;
            foreach (Action a in p.playactions)
            {
                if (!a.cardplay) continue;
                if (a.handcard.card.name == CardDB.cardName.soulfire || a.handcard.card.name == CardDB.cardName.doomguard || a.handcard.card.name == CardDB.cardName.succubus) deletecardsAtLast = 1;
                if (deletecardsAtLast == 1 && !(a.handcard.card.name == CardDB.cardName.soulfire || a.handcard.card.name == CardDB.cardName.doomguard || a.handcard.card.name == CardDB.cardName.succubus)) retval -= 20;
            }
            if (p.enemyHeroHp >= 1 && p.guessingHeroHP <= 0)
            {
                retval += p.owncarddraw * 500;
                retval -= 1000;
            }
            if (p.ownHeroHp <= 0) retval = -10000;

            p.value = retval;
            return retval;
        }



        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            int retval = 10;
            retval += m.Hp * 2;
            if (!m.frozen && !(m.handcard.card.name == CardDB.cardName.ancientwatcher && !m.silenced))
            {
                retval += m.Angr * 2;
                if (m.windfury) retval += m.Angr * 2;
                if (m.Angr >= 4) retval += 10;
                if (m.Angr >= 7) retval += 50;
            }

            if (m.Angr == 0) retval -= 7;

            retval += m.handcard.card.rarity;
            if (m.taunt) retval += 5;
            if (m.divineshild) retval += m.Angr;
            if (m.divineshild && m.taunt) retval += 5;
            if (m.stealth) retval += 1;

            if (m.poisonous) retval += 4;

            if (penman.priorityTargets.ContainsKey(m.name) && !m.silenced) retval += penman.priorityTargets[m.name];
            if (m.name == CardDB.cardName.nerubianegg && m.Angr == 0 && !m.taunt) retval = 0;
            return retval;
        }

    }

    public class BehaviorRush : Behavior
    {
        PenalityManager penman = PenalityManager.Instance;

        public override int getPlayfieldValue(Playfield p)
        {
            if (p.value >= -2000000) return p.value;
            int retval = 0;
            retval -= p.evaluatePenality;
            retval += p.owncards.Count * 1;

            retval += p.ownHeroHp + p.ownHeroDefence;
            retval += -(p.enemyHeroHp + p.enemyHeroDefence);

            retval += p.ownMaxMana * 15 - p.enemyMaxMana * 15;

            if (p.ownWeaponAttack >= 1)
            {
                retval += p.ownWeaponAttack * p.ownWeaponDurability;
            }

            if (!p.enemyHeroFrozen)
            {
                retval -= p.enemyWeaponDurability * p.enemyWeaponAttack;
            }
            else
            {
                if (p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.priest)
                {
                    retval += 11;
                }
            }

            retval += p.owncarddraw * 5;
            retval -= p.enemycarddraw * 15;

            bool useAbili = false;
            bool usecoin = false;
            foreach (Action a in p.playactions)
            {
                if (a.heroattack && p.enemyHeroHp <= p.attackFaceHP) retval++;
                if (a.useability) useAbili = true;
                if (p.ownHeroName == HeroEnum.warrior && a.heroattack && useAbili) retval -= 1;
                if (a.useability && a.handcard.card.name == CardDB.cardName.lesserheal && ((a.enemytarget >= 10 && a.enemytarget <= 20) || a.enemytarget == 200)) retval -= 5;
                if (!a.cardplay) continue;
                if ((a.handcard.card.name == CardDB.cardName.thecoin || a.handcard.card.name == CardDB.cardName.innervate)) usecoin = true;
                if (a.handcard.card.name == CardDB.cardName.flamestrike && a.numEnemysBeforePlayed <= 2) retval -= 20;
            }
            if (usecoin && useAbili && p.ownMaxMana <= 2) retval -= 40;
            //if (usecoin && p.mana >= 1) retval -= 20;

            foreach (Minion m in p.ownMinions)
            {
                retval += m.Hp * 1;
                retval += m.Angr * 2;
                retval += m.handcard.card.rarity;
                if (m.windfury) retval += m.Angr;
                if (m.taunt) retval += 1;
                if (!m.taunt && m.stealth && penman.specialMinions.ContainsKey(m.name)) retval += 20;
                if (m.handcard.card.name == CardDB.cardName.silverhandrecruit && m.Angr == 1 && m.Hp == 1) retval -= 5;
                if (m.handcard.card.name == CardDB.cardName.direwolfalpha || m.handcard.card.name == CardDB.cardName.flametonguetotem || m.handcard.card.name == CardDB.cardName.stormwindchampion || m.handcard.card.name == CardDB.cardName.raidleader) retval += 10;
            }

            foreach (Minion m in p.enemyMinions)
            {
                retval -= this.getEnemyMinionValue(m, p);
            }

            retval -= p.enemySecretCount;
            retval -= p.lostDamage;//damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            retval -= p.lostWeaponDamage;
            if (p.ownMinions.Count == 0) retval -= 20;
            if (p.enemyMinions.Count >= 4) retval -= 20;
            if (p.enemyHeroHp <= 0) retval = 10000;
            //soulfire etc
            int deletecardsAtLast = 0;
            foreach (Action a in p.playactions)
            {
                if (!a.cardplay) continue;
                if (a.handcard.card.name == CardDB.cardName.soulfire || a.handcard.card.name == CardDB.cardName.doomguard || a.handcard.card.name == CardDB.cardName.succubus) deletecardsAtLast = 1;
                if (deletecardsAtLast == 1 && !(a.handcard.card.name == CardDB.cardName.soulfire || a.handcard.card.name == CardDB.cardName.doomguard || a.handcard.card.name == CardDB.cardName.succubus)) retval -= 20;
            }
            if (p.enemyHeroHp >= 1 && p.guessingHeroHP <= 0)
            {
                retval += p.owncarddraw * 500;
                retval -= 1000;
            }
            if (p.ownHeroHp <= 0) retval = -10000;

            p.value = retval;
            return retval;
        }

        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            int retval = 0;
            if (p.enemyMinions.Count >= 4 || m.taunt || (penman.priorityTargets.ContainsKey(m.name) && !m.silenced) || m.Angr >= 5)
            {
                retval += m.Hp;
                if (!m.frozen && !(m.handcard.card.name == CardDB.cardName.ancientwatcher && !m.silenced))
                {
                    retval += m.Angr * 2;
                    if (m.windfury) retval += 2 * m.Angr;
                }
                if (m.taunt) retval += 5;
                if (m.divineshild) retval += m.Angr;
                if (m.frozen) retval -= 1; // because its bad for enemy :D
                if (m.poisonous) retval += 4;
                retval += m.handcard.card.rarity;
            }


            if (penman.priorityTargets.ContainsKey(m.name) && !m.silenced) retval += penman.priorityTargets[m.name];
            if (m.Angr >= 4) retval += 20;
            if (m.Angr >= 7) retval += 50;
            if (m.name == CardDB.cardName.nerubianegg && m.Angr == 0 && !m.taunt) retval = 0;
            return retval;
        }


    }


    // the ai :D
    //please ask/write me if you use this in your project

    public class Action
    {
        public bool cardplay = false;
        public bool heroattack = false;
        public bool useability = false;
        public bool minionplay = false;
        public Handmanager.Handcard handcard;
        public int cardEntitiy = -1;
        public int owntarget = -1; //= target where card/minion is placed
        public int ownEntitiy = -1;
        public int enemytarget = -1; // target where red arrow is placed
        public int enemyEntitiy = -1;
        public int druidchoice = 0; // 1 left card, 2 right card
        public int numEnemysBeforePlayed = 0;
        public bool comboBeforePlayed = false;
        public int penalty = 0;

        public void print()
        {
            Helpfunctions help = Helpfunctions.Instance;
            help.logg("current Action: ");
            if (this.cardplay)
            {
                help.logg("play " + this.handcard.card.name);
                if (this.druidchoice >= 1) help.logg("choose choise " + this.druidchoice);
                help.logg("with entityid " + this.cardEntitiy);
                if (this.owntarget >= 0)
                {
                    help.logg("on position " + this.owntarget);
                }
                if (this.enemytarget >= 0)
                {
                    help.logg("and target to " + this.enemytarget + " " + this.enemyEntitiy);
                }
                if (this.penalty > 0)
                {
                    help.logg("penality for playing " + this.penalty);
                }
            }
            if (this.minionplay)
            {
                help.logg("attacker: " + this.owntarget + " enemy: " + this.enemytarget);
                help.logg("targetplace " + this.enemyEntitiy);
            }
            if (this.heroattack)
            {
                help.logg("attack with hero, enemy: " + this.enemytarget);
                help.logg("targetplace " + this.enemyEntitiy);
            }
            if (this.useability)
            {
                help.logg("useability ");
                if (this.enemytarget >= 0)
                {
                    help.logg("on enemy: " + this.enemytarget + "targetplace " + this.enemyEntitiy);
                }
            }
            help.logg("");
        }

    }

    public class Playfield
    {
        public bool logging = false;
        public bool sEnemTurn = false;

        public int attackFaceHP = 15;

        public int evaluatePenality = 0;
        public int ownController = 0;

        public int ownHeroEntity = -1;
        public int enemyHeroEntity = -1;

        public int hashcode = 0;
        public int value = Int32.MinValue;
        public int guessingHeroHP = 30;

        public int mana = 0;
        public int enemyHeroHp = 30;
        public HeroEnum ownHeroName = HeroEnum.druid;
        public HeroEnum enemyHeroName = HeroEnum.druid;
        public bool ownHeroReady = false;
        public bool enemyHeroReady = false;
        public int ownHeroNumAttackThisTurn = 0;
        public int enemyHeroNumAttackThisTurn = 0;
        public bool ownHeroWindfury = false;
        public bool enemyHeroWindfury = false;

        public List<CardDB.cardIDEnum> ownSecretsIDList = new List<CardDB.cardIDEnum>();
        public int enemySecretCount = 0;

        public int ownHeroHp = 30;
        public int ownheroAngr = 0;
        public int enemyheroAngr = 0;
        public bool ownHeroFrozen = false;
        public bool enemyHeroFrozen = false;
        public bool heroImmuneWhileAttacking = false;
        public bool enemyheroImmuneWhileAttacking = false;
        public bool heroImmune = false;
        public bool enemyHeroImmune = false;
        public int ownWeaponDurability = 0;
        public int ownWeaponAttack = 0;
        public CardDB.cardName ownWeaponName = CardDB.cardName.unknown;
        public CardDB.cardName enemyWeaponName = CardDB.cardName.unknown;

        public int enemyWeaponAttack = 0;
        public int enemyWeaponDurability = 0;
        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();

        public List<Minion> diedMinions = null;
        public bool ownhasorcanplayKelThuzad = false;
        public bool enemyhasorcanplayKelThuzad = false;

        public List<Handmanager.Handcard> owncards = new List<Handmanager.Handcard>();
        public List<Action> playactions = new List<Action>();
        public bool complete = false;
        public int owncarddraw = 0;
        public int ownHeroDefence = 0;
        public int enemycarddraw = 0;
        public int enemyAnzCards = 0;
        public int enemyHeroDefence = 0;

        public int doublepriest = 0;
        public int enemydoublepriest = 0;
        public int spellpower = 0;

        public int enemyspellpower = 0;


        public bool auchenaiseelenpriesterin = false;
        public bool ownBaronRivendare = false;
        public bool enemyBaronRivendare = false;

        public bool playedmagierinderkirintor = false;
        public bool playedPreparation = false;

        public bool loatheb = false;
        public int winzigebeschwoererin = 0;
        public int startedWithWinzigebeschwoererin = 0;
        public int zauberlehrling = 0;
        public int startedWithZauberlehrling = 0;
        public int managespenst = 0;
        public int startedWithManagespenst = 0;
        public int soeldnerDerVenture = 0;
        public int startedWithsoeldnerDerVenture = 0;
        public int beschwoerungsportal = 0;
        public int startedWithbeschwoerungsportal = 0;
        public int nerubarweblord = 0;
        public int startedWithnerubarweblord = 0;

        public int ownWeaponAttackStarted = 0;
        public int ownMobsCountStarted = 0;
        public int ownCardsCountStarted = 0;
        public int ownHeroHpStarted = 30;
        public int enemyHeroHpStarted = 30;

        public int mobsplayedThisTurn = 0;
        public int startedWithMobsPlayedThisTurn = 0;

        public int cardsPlayedThisTurn = 0;
        public int ueberladung = 0; //=recall

        public int ownMaxMana = 0;
        public int enemyMaxMana = 0;

        public int lostDamage = 0;
        public int lostHeal = 0;
        public int lostWeaponDamage = 0;

        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int ownHeroFatigue = 0;
        public int enemyHeroFatigue = 0;

        public bool ownAbilityReady = false;
        public CardDB.Card ownHeroAblility;
        public bool enemyAbilityReady = false;
        public CardDB.Card enemyHeroAblility;

        //Helpfunctions help = Helpfunctions.Instance;

        private void addMinionsReal(List<Minion> source, List<Minion> trgt)
        {
            foreach (Minion m in source)
            {
                trgt.Add(new Minion(m));
            }

        }

        private void addCardsReal(List<Handmanager.Handcard> source)
        {

            foreach (Handmanager.Handcard m in source)
            {
                this.owncards.Add(new Handmanager.Handcard(m));
            }

        }

        public Playfield()
        {
            //this.simulateEnemyTurn = Ai.Instance.simulateEnemyTurn;
            this.ownController = Hrtprozis.Instance.getOwnController();
            this.ownHeroEntity = Hrtprozis.Instance.ownHeroEntity;
            this.enemyHeroEntity = Hrtprozis.Instance.enemyHeroEntitiy;
            this.mana = Hrtprozis.Instance.currentMana;
            this.ownMaxMana = Hrtprozis.Instance.ownMaxMana;
            this.enemyMaxMana = Hrtprozis.Instance.enemyMaxMana;
            this.evaluatePenality = 0;
            this.ownSecretsIDList = Hrtprozis.Instance.ownSecretList;
            this.enemySecretCount = Hrtprozis.Instance.enemySecretCount;

            this.heroImmune = Hrtprozis.Instance.heroImmune;
            this.enemyHeroImmune = Hrtprozis.Instance.enemyHeroImmune;

            this.attackFaceHP = Hrtprozis.Instance.attackFaceHp;

            addMinionsReal(Hrtprozis.Instance.ownMinions, ownMinions);
            addMinionsReal(Hrtprozis.Instance.enemyMinions, enemyMinions);
            addCardsReal(Handmanager.Instance.handCards);
            this.enemyHeroHp = Hrtprozis.Instance.enemyHp;
            this.ownHeroName = Hrtprozis.Instance.heroname;
            this.enemyHeroName = Hrtprozis.Instance.enemyHeroname;
            this.ownHeroHp = Hrtprozis.Instance.heroHp;
            this.complete = false;
            this.ownHeroReady = Hrtprozis.Instance.ownheroisread;
            this.ownHeroWindfury = Hrtprozis.Instance.ownHeroWindfury;
            this.ownHeroNumAttackThisTurn = Hrtprozis.Instance.ownHeroNumAttacksThisTurn;

            this.ownHeroFrozen = Hrtprozis.Instance.herofrozen;
            this.enemyHeroFrozen = Hrtprozis.Instance.enemyfrozen;
            this.ownheroAngr = Hrtprozis.Instance.heroAtk;
            this.heroImmuneWhileAttacking = Hrtprozis.Instance.heroImmuneToDamageWhileAttacking;
            this.ownWeaponDurability = Hrtprozis.Instance.heroWeaponDurability;
            this.ownWeaponAttack = Hrtprozis.Instance.heroWeaponAttack;
            this.ownWeaponName = Hrtprozis.Instance.ownHeroWeapon;
            this.owncarddraw = 0;
            this.ownHeroDefence = Hrtprozis.Instance.heroDefence;
            this.enemyHeroDefence = Hrtprozis.Instance.enemyDefence;
            this.enemyWeaponAttack = Hrtprozis.Instance.enemyWeaponAttack;//dont know jet
            this.enemyWeaponName = Hrtprozis.Instance.enemyHeroWeapon;
            this.enemyWeaponDurability = Hrtprozis.Instance.enemyWeaponDurability;
            this.enemycarddraw = 0;
            this.enemyAnzCards = Handmanager.Instance.enemyAnzCards;
            this.ownAbilityReady = Hrtprozis.Instance.ownAbilityisReady;
            this.ownHeroAblility = Hrtprozis.Instance.heroAbility;
            this.enemyHeroAblility = Hrtprozis.Instance.enemyAbility;
            this.doublepriest = 0;
            this.spellpower = 0;
            this.mobsplayedThisTurn = Hrtprozis.Instance.numMinionsPlayedThisTurn;
            this.startedWithMobsPlayedThisTurn = Hrtprozis.Instance.numMinionsPlayedThisTurn;// only change mobsplayedthisturm
            this.cardsPlayedThisTurn = Hrtprozis.Instance.cardsPlayedThisTurn;
            this.ueberladung = Hrtprozis.Instance.ueberladung;

            this.ownHeroFatigue = Hrtprozis.Instance.ownHeroFatigue;
            this.enemyHeroFatigue = Hrtprozis.Instance.enemyHeroFatigue;
            this.ownDeckSize = Hrtprozis.Instance.ownDeckSize;
            this.enemyDeckSize = Hrtprozis.Instance.enemyDeckSize;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = this.ownHeroHp;
            this.enemyHeroHpStarted = this.enemyHeroHp;
            this.ownWeaponAttackStarted = this.ownWeaponAttack;
            this.ownCardsCountStarted = this.owncards.Count;
            this.ownMobsCountStarted = this.ownMinions.Count + this.enemyMinions.Count;


            this.playedmagierinderkirintor = false;
            this.playedPreparation = false;

            this.zauberlehrling = 0;
            this.winzigebeschwoererin = 0;
            this.managespenst = 0;
            this.soeldnerDerVenture = 0;
            this.beschwoerungsportal = 0;
            this.nerubarweblord = 0;

            this.startedWithnerubarweblord = 0;
            this.startedWithbeschwoerungsportal = 0;
            this.startedWithManagespenst = 0;
            this.startedWithWinzigebeschwoererin = 0;
            this.startedWithZauberlehrling = 0;
            this.startedWithsoeldnerDerVenture = 0;

            this.ownBaronRivendare = false;
            this.enemyBaronRivendare = false;

            ownhasorcanplayKelThuzad = false;
            enemyhasorcanplayKelThuzad = false;
            this.loatheb = false;

            foreach (Minion m in this.ownMinions)
            {
                if (m.playedThisTurn && m.name == CardDB.cardName.loatheb) this.loatheb = true;

                if (m.silenced) continue;

                if (m.name == CardDB.cardName.prophetvelen) this.doublepriest++;
                spellpower = spellpower + m.handcard.card.spellpowervalue;
                if (m.name == CardDB.cardName.auchenaisoulpriest) this.auchenaiseelenpriesterin = true;

                if (m.name == CardDB.cardName.pintsizedsummoner)
                {
                    this.winzigebeschwoererin++;
                    this.startedWithWinzigebeschwoererin++;
                }
                if (m.name == CardDB.cardName.sorcerersapprentice)
                {
                    this.zauberlehrling++;
                    this.startedWithZauberlehrling++;
                }
                if (m.name == CardDB.cardName.manawraith)
                {
                    this.managespenst++;
                    this.startedWithManagespenst++;
                }
                if (m.name == CardDB.cardName.nerubarweblord)
                {
                    this.nerubarweblord++;
                    this.startedWithnerubarweblord++;
                }
                if (m.name == CardDB.cardName.venturecomercenary)
                {
                    this.soeldnerDerVenture++;
                    this.startedWithsoeldnerDerVenture++;
                }
                if (m.name == CardDB.cardName.summoningportal)
                {
                    this.beschwoerungsportal++;
                    this.startedWithbeschwoerungsportal++;
                }

                if (m.handcard.card.name == CardDB.cardName.baronrivendare)
                {
                    this.ownBaronRivendare = true;
                }
                if (m.handcard.card.name == CardDB.cardName.kelthuzad)
                {
                    this.ownhasorcanplayKelThuzad = true;
                }

                foreach (Enchantment e in m.enchantments)// only at first init needed, after that its copied
                {
                    if (e.CARDID == CardDB.cardIDEnum.NEW1_036e || e.CARDID == CardDB.cardIDEnum.NEW1_036e2) m.cantLowerHPbelowONE = true;
                }

            }
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.card.name == CardDB.cardName.kelthuzad)
                {
                    this.ownhasorcanplayKelThuzad = true;
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced) continue;
                this.enemyspellpower = this.enemyspellpower + m.handcard.card.spellpowervalue;
                if (m.name == CardDB.cardName.prophetvelen) this.enemydoublepriest++;
                if (m.name == CardDB.cardName.manawraith)
                {
                    this.managespenst++;
                    this.startedWithManagespenst++;
                }
                if (m.name == CardDB.cardName.nerubarweblord)
                {
                    this.nerubarweblord++;
                    this.startedWithnerubarweblord++;
                }
                if (m.handcard.card.name == CardDB.cardName.baronrivendare)
                {
                    this.enemyBaronRivendare = true;
                }
                if (m.handcard.card.name == CardDB.cardName.kelthuzad)
                {
                    this.enemyhasorcanplayKelThuzad = true;
                }
            }
            if (this.ownhasorcanplayKelThuzad || this.enemyhasorcanplayKelThuzad) this.diedMinions = new List<Minion>();

        }

        public Playfield(Playfield p)
        {
            this.sEnemTurn = p.sEnemTurn;
            this.ownController = p.ownController;
            this.ownHeroEntity = p.ownHeroEntity;
            this.enemyHeroEntity = p.enemyHeroEntity;

            this.evaluatePenality = p.evaluatePenality;

            foreach (CardDB.cardIDEnum s in p.ownSecretsIDList)
            { this.ownSecretsIDList.Add(s); }
            this.enemySecretCount = p.enemySecretCount;
            this.mana = p.mana;
            this.ownMaxMana = p.ownMaxMana;
            this.enemyMaxMana = p.enemyMaxMana;
            addMinionsReal(p.ownMinions, ownMinions);
            addMinionsReal(p.enemyMinions, enemyMinions);
            addCardsReal(p.owncards);
            this.enemyHeroHp = p.enemyHeroHp;
            this.ownHeroName = p.ownHeroName;
            this.enemyHeroName = p.enemyHeroName;
            this.ownHeroHp = p.ownHeroHp;
            this.playactions.AddRange(p.playactions);
            this.complete = false;
            this.ownHeroReady = p.ownHeroReady;
            this.enemyHeroReady = p.enemyHeroReady;
            this.ownHeroNumAttackThisTurn = p.ownHeroNumAttackThisTurn;
            this.enemyHeroNumAttackThisTurn = p.enemyHeroNumAttackThisTurn;
            this.ownHeroWindfury = p.ownHeroWindfury;

            this.attackFaceHP = p.attackFaceHP;

            this.heroImmune = p.heroImmune;
            this.enemyHeroImmune = p.enemyHeroImmune;

            this.ownheroAngr = p.ownheroAngr;
            this.enemyheroAngr = p.enemyheroAngr;
            this.ownHeroFrozen = p.ownHeroFrozen;
            this.enemyHeroFrozen = p.enemyHeroFrozen;
            this.heroImmuneWhileAttacking = p.heroImmuneWhileAttacking;
            this.enemyheroImmuneWhileAttacking = p.enemyheroImmuneWhileAttacking;
            this.owncarddraw = p.owncarddraw;
            this.ownHeroDefence = p.ownHeroDefence;
            this.enemyWeaponAttack = p.enemyWeaponAttack;
            this.enemyWeaponDurability = p.enemyWeaponDurability;
            this.enemyWeaponName = p.enemyWeaponName;
            this.enemycarddraw = p.enemycarddraw;
            this.enemyAnzCards = p.enemyAnzCards;
            this.enemyHeroDefence = p.enemyHeroDefence;
            this.ownWeaponDurability = p.ownWeaponDurability;
            this.ownWeaponAttack = p.ownWeaponAttack;
            this.ownWeaponName = p.ownWeaponName;

            this.lostDamage = p.lostDamage;
            this.lostWeaponDamage = p.lostWeaponDamage;
            this.lostHeal = p.lostHeal;

            this.ownAbilityReady = p.ownAbilityReady;
            this.enemyAbilityReady = p.enemyAbilityReady;
            this.ownHeroAblility = p.ownHeroAblility;
            this.enemyHeroAblility = p.enemyHeroAblility;
            this.doublepriest = 0;
            this.spellpower = 0;
            this.mobsplayedThisTurn = p.mobsplayedThisTurn;
            this.startedWithMobsPlayedThisTurn = p.startedWithMobsPlayedThisTurn;
            this.cardsPlayedThisTurn = p.cardsPlayedThisTurn;
            this.ueberladung = p.ueberladung;

            this.ownDeckSize = p.ownDeckSize;
            this.enemyDeckSize = p.enemyDeckSize;
            this.ownHeroFatigue = p.ownHeroFatigue;
            this.enemyHeroFatigue = p.enemyHeroFatigue;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = p.ownHeroHpStarted;
            this.enemyHeroHp = p.enemyHeroHp;
            this.ownWeaponAttackStarted = p.ownWeaponAttackStarted;
            this.ownCardsCountStarted = p.ownCardsCountStarted;
            this.ownMobsCountStarted = p.ownMobsCountStarted;

            this.startedWithWinzigebeschwoererin = p.startedWithWinzigebeschwoererin;
            this.playedmagierinderkirintor = p.playedmagierinderkirintor;

            this.startedWithZauberlehrling = p.startedWithZauberlehrling;
            this.startedWithWinzigebeschwoererin = p.startedWithWinzigebeschwoererin;
            this.startedWithManagespenst = p.startedWithManagespenst;
            this.startedWithsoeldnerDerVenture = p.startedWithsoeldnerDerVenture;
            this.startedWithbeschwoerungsportal = p.startedWithbeschwoerungsportal;
            this.startedWithnerubarweblord = p.startedWithnerubarweblord;

            this.ownBaronRivendare = false;
            this.enemyBaronRivendare = false;

            this.nerubarweblord = 0;
            this.zauberlehrling = 0;
            this.winzigebeschwoererin = 0;
            this.managespenst = 0;
            this.soeldnerDerVenture = 0;
            this.enemyhasorcanplayKelThuzad = false;
            this.ownhasorcanplayKelThuzad = false;
            this.loatheb = false;

            foreach (Minion m in this.ownMinions)
            {
                if (m.playedThisTurn && m.name == CardDB.cardName.loatheb) this.loatheb = true;

                if (m.silenced) continue;

                if (m.handcard.card.name == CardDB.cardName.prophetvelen) this.doublepriest++;
                spellpower = spellpower + m.handcard.card.spellpowervalue;
                if (m.handcard.card.name == CardDB.cardName.auchenaisoulpriest) this.auchenaiseelenpriesterin = true;
                if (m.handcard.card.name == CardDB.cardName.pintsizedsummoner) this.winzigebeschwoererin++;
                if (m.handcard.card.name == CardDB.cardName.sorcerersapprentice) this.zauberlehrling++;
                if (m.handcard.card.name == CardDB.cardName.manawraith) this.managespenst++;
                if (m.handcard.card.name == CardDB.cardName.venturecomercenary) this.soeldnerDerVenture++;
                if (m.handcard.card.name == CardDB.cardName.summoningportal) this.beschwoerungsportal++;
                if (m.handcard.card.name == CardDB.cardName.baronrivendare)
                {
                    this.ownBaronRivendare = true;
                }
                if (m.handcard.card.name == CardDB.cardName.kelthuzad)
                {
                    this.ownhasorcanplayKelThuzad = true;
                }
                if (m.name == CardDB.cardName.nerubarweblord)
                {
                    this.nerubarweblord++;
                }
            }
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.card.name == CardDB.cardName.kelthuzad)
                {
                    this.ownhasorcanplayKelThuzad = true;
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced) continue;
                this.enemyspellpower = this.enemyspellpower + m.handcard.card.spellpowervalue;
                if (m.handcard.card.name == CardDB.cardName.prophetvelen) this.enemydoublepriest++;
                if (m.handcard.card.name == CardDB.cardName.manawraith) this.managespenst++;
                if (m.name == CardDB.cardName.nerubarweblord)
                {
                    this.nerubarweblord++;
                }
                if (m.handcard.card.name == CardDB.cardName.baronrivendare)
                {
                    this.enemyBaronRivendare = true;
                }
                if (m.handcard.card.name == CardDB.cardName.kelthuzad)
                {
                    this.enemyhasorcanplayKelThuzad = true;
                }
            }
            if (this.ownhasorcanplayKelThuzad || this.enemyhasorcanplayKelThuzad) this.diedMinions = new List<Minion>();
        }

        public bool isEqual(Playfield p, bool logg)
        {
            if (logg)
            {
                if (this.value != p.value) return false;
            }
            if (this.enemySecretCount != p.enemySecretCount)
            {

                if (logg) Helpfunctions.Instance.logg("enemy secrets changed ");
                return false;
            }

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana)
            {
                if (logg) Helpfunctions.Instance.logg("mana changed " + this.mana + " " + p.mana + " " + this.enemyMaxMana + " " + p.enemyMaxMana + " " + this.ownMaxMana + " " + p.ownMaxMana);
                return false;
            }

            if (this.ownDeckSize != p.ownDeckSize || this.enemyDeckSize != p.enemyDeckSize || this.ownHeroFatigue != p.ownHeroFatigue || this.enemyHeroFatigue != p.enemyHeroFatigue)
            {
                if (logg) Helpfunctions.Instance.logg("deck/fatigue changed " + this.ownDeckSize + " " + p.ownDeckSize + " " + this.enemyDeckSize + " " + p.enemyDeckSize + " " + this.ownHeroFatigue + " " + p.ownHeroFatigue + " " + this.enemyHeroFatigue + " " + p.enemyHeroFatigue);
            }

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsplayedThisTurn != p.mobsplayedThisTurn || this.ueberladung != p.ueberladung)
            {
                if (logg) Helpfunctions.Instance.logg("stuff changed " + this.cardsPlayedThisTurn + " " + p.cardsPlayedThisTurn + " " + this.mobsplayedThisTurn + " " + p.mobsplayedThisTurn + " " + this.ueberladung + " " + p.ueberladung);
                return false;
            }

            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName)
            {
                if (logg) Helpfunctions.Instance.logg("hero name changed ");
                return false;
            }

            if (this.ownHeroHp != p.ownHeroHp || this.ownheroAngr != p.ownheroAngr || this.ownHeroDefence != p.ownHeroDefence || this.ownHeroFrozen != p.ownHeroFrozen || this.heroImmuneWhileAttacking != p.heroImmuneWhileAttacking || this.heroImmune != p.heroImmune)
            {
                if (logg) Helpfunctions.Instance.logg("ownhero changed " + this.ownHeroHp + " " + p.ownHeroHp + " " + this.ownheroAngr + " " + p.ownheroAngr + " " + this.ownHeroDefence + " " + p.ownHeroDefence + " " + this.ownHeroFrozen + " " + p.ownHeroFrozen + " " + this.heroImmuneWhileAttacking + " " + p.heroImmuneWhileAttacking + " " + this.heroImmune + " " + p.heroImmune);
                return false;
            }
            if (this.ownHeroReady != p.ownHeroReady || this.ownWeaponAttack != p.ownWeaponAttack || this.ownWeaponDurability != p.ownWeaponDurability || this.ownHeroNumAttackThisTurn != p.ownHeroNumAttackThisTurn || this.ownHeroWindfury != p.ownHeroWindfury)
            {
                if (logg) Helpfunctions.Instance.logg("weapon changed " + this.ownHeroReady + " " + p.ownHeroReady + " " + this.ownWeaponAttack + " " + p.ownWeaponAttack + " " + this.ownWeaponDurability + " " + p.ownWeaponDurability + " " + this.ownHeroNumAttackThisTurn + " " + p.ownHeroNumAttackThisTurn + " " + this.ownHeroWindfury + " " + p.ownHeroWindfury);
                return false;
            }
            if (this.enemyHeroHp != p.enemyHeroHp || this.enemyWeaponAttack != p.enemyWeaponAttack || this.enemyHeroDefence != p.enemyHeroDefence || this.enemyWeaponDurability != p.enemyWeaponDurability || this.enemyHeroFrozen != p.enemyHeroFrozen || this.enemyHeroImmune != p.enemyHeroImmune)
            {
                if (logg) Helpfunctions.Instance.logg("enemyhero changed " + this.enemyHeroHp + " " + p.enemyHeroHp + " " + this.enemyWeaponAttack + " " + p.enemyWeaponAttack + " " + this.enemyHeroDefence + " " + p.enemyHeroDefence + " " + this.enemyWeaponDurability + " " + p.enemyWeaponDurability + " " + this.enemyHeroFrozen + " " + p.enemyHeroFrozen + " " + this.enemyHeroImmune + " " + p.enemyHeroImmune);
                return false;
            }

            /*if (this.auchenaiseelenpriesterin != p.auchenaiseelenpriesterin || this.winzigebeschwoererin != p.winzigebeschwoererin || this.zauberlehrling != p.zauberlehrling || this.managespenst != p.managespenst || this.soeldnerDerVenture != p.soeldnerDerVenture || this.beschwoerungsportal != p.beschwoerungsportal || this.doublepriest != p.doublepriest)
            {
                Helpfunctions.Instance.logg("special minions changed " + this.auchenaiseelenpriesterin + " " + p.auchenaiseelenpriesterin + " " + this.winzigebeschwoererin + " " + p.winzigebeschwoererin + " " + this.zauberlehrling + " " + p.zauberlehrling + " " + this.managespenst + " " + p.managespenst + " " + this.soeldnerDerVenture + " " + p.soeldnerDerVenture + " " + this.beschwoerungsportal + " " + p.beschwoerungsportal + " " + this.doublepriest + " " + p.doublepriest);
                return false;
            }*/

            if (this.ownHeroAblility.name != p.ownHeroAblility.name)
            {
                if (logg) Helpfunctions.Instance.logg("hero ability changed ");
                return false;
            }

            if (this.spellpower != p.spellpower)
            {
                if (logg) Helpfunctions.Instance.logg("spellpower changed");
                return false;
            }

            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count)
            {
                if (logg) Helpfunctions.Instance.logg("minions count or hand changed");
                return false;
            }

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.wounded != pis.wounded || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;

            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("ownminions changed");
                return false;
            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.wounded != pis.wounded || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("enemyminions changed");
                return false;
            }

            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard dishc = this.owncards[i]; Handmanager.Handcard pishc = p.owncards[i];
                if (dishc.position != pishc.position || dishc.entity != pishc.entity || dishc.getManaCost(this) != pishc.getManaCost(p))
                {
                    if (logg) Helpfunctions.Instance.logg("handcard changed: " + dishc.card.name);
                    return false;
                }
            }

            return true;
        }

        public bool isEqualf(Playfield p)
        {
            if (this.value != p.value) return false;

            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count) return false;

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsplayedThisTurn != p.mobsplayedThisTurn || this.ueberladung != p.ueberladung) return false;

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana) return false;

            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName) return false;

            if (this.ownHeroHp != p.ownHeroHp || this.ownheroAngr != p.ownheroAngr || this.ownHeroDefence != p.ownHeroDefence || this.ownHeroFrozen != p.ownHeroFrozen || this.heroImmuneWhileAttacking != p.heroImmuneWhileAttacking || this.heroImmune != p.heroImmune) return false;

            if (this.ownHeroReady != p.ownHeroReady || this.ownWeaponAttack != p.ownWeaponAttack || this.ownWeaponDurability != p.ownWeaponDurability || this.ownHeroNumAttackThisTurn != p.ownHeroNumAttackThisTurn || this.ownHeroWindfury != p.ownHeroWindfury) return false;

            if (this.enemyHeroHp != p.enemyHeroHp || this.enemyWeaponAttack != p.enemyWeaponAttack || this.enemyHeroDefence != p.enemyHeroDefence || this.enemyWeaponDurability != p.enemyWeaponDurability || this.enemyHeroFrozen != p.enemyHeroFrozen || this.enemyHeroImmune != p.enemyHeroImmune) return false;

            if (this.ownHeroAblility.name != p.ownHeroAblility.name || this.spellpower != p.spellpower) return false;

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.wounded != pis.wounded || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (minionbool == false) break;
            }
            if (minionbool == false)
            {

                return false;
            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.wounded != pis.wounded || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (minionbool == false) break;
            }
            if (minionbool == false)
            {
                return false;
            }

            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard dishc = this.owncards[i]; Handmanager.Handcard pishc = p.owncards[i];
                if (dishc.position != pishc.position || dishc.entity != pishc.entity || dishc.manacost != pishc.manacost)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int retval = 0;
            retval += 10000 * this.ownMinions.Count + 100 * this.enemyMinions.Count + 1000 * this.mana + 100000 * (this.ownHeroHp + this.enemyHeroHp) + this.owncards.Count + this.enemycarddraw + this.cardsPlayedThisTurn + this.mobsplayedThisTurn + this.ownheroAngr + this.ownHeroDefence + this.ownWeaponAttack + this.enemyWeaponDurability;
            return retval;
        }


        public void simulateEnemysTurn(bool simulateTwoTurns, bool playaround, bool print)
        {
            int maxwide = 20;

            this.enemyAbilityReady = true;
            this.enemyHeroNumAttackThisTurn = 0;
            this.enemyHeroWindfury = false;
            if (this.enemyWeaponName == CardDB.cardName.doomhammer) this.enemyHeroWindfury = true;
            this.enemyheroImmuneWhileAttacking = false;
            if (this.enemyWeaponName == CardDB.cardName.gladiatorslongbow) this.enemyheroImmuneWhileAttacking = true;
            if (!this.enemyHeroFrozen && this.enemyWeaponDurability > 0) this.enemyHeroReady = true;
            this.enemyheroAngr = this.enemyWeaponAttack;
            bool havedonesomething = true;
            List<Playfield> posmoves = new List<Playfield>();
            posmoves.Add(new Playfield(this));
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;
            int enemMana = Math.Min(this.enemyMaxMana + 1, 10);

            if (playaround && !this.loatheb)
            {
                int oldval = Ai.Instance.botBase.getPlayfieldValue(posmoves[0]);
                posmoves[0].value = int.MinValue;
                enemMana = posmoves[0].EnemyCardPlaying(this.enemyHeroName, enemMana, this.enemycarddraw + this.enemyAnzCards);
                int newval = Ai.Instance.botBase.getPlayfieldValue(posmoves[0]);
                posmoves[0].value = int.MinValue;
                if (oldval < newval)
                {
                    posmoves.Clear();
                    posmoves.Add(new Playfield(this));
                }
            }

            foreach (Minion m in posmoves[0].enemyMinions)
            {
                if (m.frozen || (m.handcard.card.name == CardDB.cardName.ancientwatcher && !m.silenced))
                {
                    m.Ready = false;
                }
                m.Ready = true;
                m.numAttacksThisTurn = 0;
            }

            //play ability!
            if (posmoves[0].enemyAbilityReady && enemMana >= 2 && posmoves[0].enemyHeroAblility.canplayCard(posmoves[0], 0) && !loatheb)
            {
                int abilityPenality = 0;

                havedonesomething = true;
                // if we have mage or priest, we have to target something####################################################
                if (posmoves[0].enemyHeroName == HeroEnum.mage || posmoves[0].enemyHeroName == HeroEnum.priest)
                {

                    List<targett> trgts = posmoves[0].enemyHeroAblility.getTargetsForCardEnemy(posmoves[0]);
                    foreach (targett trgt in trgts)
                    {
                        if (trgt.target >= 100) continue;
                        Playfield pf = new Playfield(posmoves[0]);
                        //havedonesomething = true;
                        //Helpfunctions.Instance.logg("use ability on " + trgt.target + " " + trgt.targetEntity);
                        pf.ENEMYactivateAbility(posmoves[0].enemyHeroAblility, trgt.target, trgt.targetEntity);
                        posmoves.Add(pf);
                    }
                }
                else
                {
                    // the other classes dont have to target####################################################
                    Playfield pf = new Playfield(posmoves[0]);

                    //havedonesomething = true;
                    posmoves[0].ENEMYactivateAbility(posmoves[0].enemyHeroAblility, -1, -1);
                    posmoves.Add(pf);
                }

            }

            while (havedonesomething)
            {

                temp.Clear();
                temp.AddRange(posmoves);
                havedonesomething = false;
                Playfield bestold = null;
                int bestoldval = 20000000;
                foreach (Playfield p in temp)
                {

                    if (p.complete)
                    {
                        continue;
                    }
                    List<Minion> playedMinions = new List<Minion>(8);

                    foreach (Minion m in p.enemyMinions)
                    {

                        if (m.Ready && m.Angr >= 1 && !m.frozen)
                        {
                            //BEGIN:cut (double/similar) attacking minions out#####################################
                            // DONT LET SIMMILAR MINIONS ATTACK IN ONE TURN (example 3 unlesh the hounds-hounds doesnt need to simulated hole)
                            List<Minion> tempoo = new List<Minion>(playedMinions);
                            bool dontattacked = true;
                            bool isSpecial = PenalityManager.Instance.specialMinions.ContainsKey(m.name);
                            foreach (Minion mnn in tempoo)
                            {
                                // special minions are allowed to attack in silended and unsilenced state!
                                //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.cardName.ContainsKey(m.name));

                                bool otherisSpecial = PenalityManager.Instance.specialMinions.ContainsKey(mnn.name);

                                if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                                {
                                    if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                    continue;
                                }

                                if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                                {
                                    if (m.name != mnn.name) // different name -> take it
                                    {
                                        continue;
                                    }
                                    // same name -> test whether they are equal
                                    if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                    continue;
                                }

                            }

                            if (dontattacked)
                            {
                                playedMinions.Add(m);
                            }
                            else
                            {
                                //help.logg(m.name + " doesnt need to attack!");
                                continue;
                            }
                            //END: cut (double/similar) attacking minions out#####################################

                            //help.logg(m.name + " is going to attack!");
                            List<targett> trgts = p.getAttackTargets(false);



                            if (true)//(this.useCutingTargets)
                            {
                                trgts = Ai.Instance.nextTurnSimulator.cutAttackTargets(trgts, p, false);
                            }

                            foreach (targett trgt in trgts)
                            {

                                Playfield pf = new Playfield(p);
                                havedonesomething = true;
                                pf.ENEMYattackWithMinion(m, trgt.target, trgt.targetEntity);
                                posmoves.Add(pf);


                            }
                            if (trgts.Count == 1 && trgts[0].target == 100)//only enemy hero is available als attack
                            {
                                break;
                            }
                        }

                    }
                    // attacked with minions done
                    // attack with hero
                    if (p.enemyHeroReady)
                    {
                        List<targett> trgts = p.getAttackTargets(false);

                        havedonesomething = true;


                        if (true)//(this.useCutingTargets)
                        {
                            trgts = Ai.Instance.nextTurnSimulator.cutAttackTargets(trgts, p, false);
                        }

                        foreach (targett trgt in trgts)
                        {
                            Playfield pf = new Playfield(p);
                            pf.ENEMYattackWithWeapon(trgt.target, trgt.targetEntity, 0);
                            posmoves.Add(pf);
                        }
                    }

                    // use ability
                    /// TODO check if ready after manaup

                    p.endEnemyTurn();
                    p.guessingHeroHP = this.guessingHeroHP;
                    if (Ai.Instance.botBase.getPlayfieldValue(p) < bestoldval) // want the best enemy-play-> worst for us
                    {
                        bestoldval = Ai.Instance.botBase.getPlayfieldValue(p);
                        bestold = p;
                    }
                    posmoves.Remove(p);

                    if (posmoves.Count >= maxwide) break;
                }

                if (bestoldval <= 10000 && bestold != null)
                {
                    posmoves.Add(bestold);
                }

                deep++;
                if (posmoves.Count >= maxwide) break;
            }

            foreach (Playfield p in posmoves)
            {
                if (!p.complete) p.endEnemyTurn();
            }

            int bestval = int.MaxValue;
            Playfield bestplay = posmoves[0];
            if (print) bestplay.printBoard();
            foreach (Playfield p in posmoves)
            {
                p.guessingHeroHP = this.guessingHeroHP;
                int val = Ai.Instance.botBase.getPlayfieldValue(p);
                if (bestval > val)// we search the worst value
                {
                    bestplay = p;
                    bestval = val;
                }
            }

            this.value = bestplay.value;
            if (simulateTwoTurns)
            {
                bestplay.prepareNextTurn();
                this.value = (int)(0.5 * bestval + 0.5 * Ai.Instance.nextTurnSimulator.doallmoves(bestplay, false));
            }



        }


        private int EnemyCardPlaying(HeroEnum enemyHeroNamee, int currmana, int cardcount)
        {
            int mana = currmana;
            if (cardcount == 0) return currmana;

            bool useAOE = false;
            int mobscount = 0;
            foreach (Minion min in this.ownMinions)
            {
                if (min.maxHp >= 2 && min.Angr >= 2) mobscount++;
            }

            if (mobscount >= 3) useAOE = true;

            if (enemyHeroNamee == HeroEnum.warrior)
            {
                bool usewhirlwind = true;
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.Hp == 1) usewhirlwind = false;
                }
                if (this.ownMinions.Count <= 3) usewhirlwind = false;

                if (usewhirlwind)
                {
                    mana = EnemyPlaysACard(CardDB.cardName.whirlwind, mana);
                }
            }

            if (!useAOE) return mana;

            if (enemyHeroNamee == HeroEnum.mage)
            {
                mana = EnemyPlaysACard(CardDB.cardName.flamestrike, mana);
                mana = EnemyPlaysACard(CardDB.cardName.blizzard, mana);
            }

            if (enemyHeroNamee == HeroEnum.hunter)
            {
                mana = EnemyPlaysACard(CardDB.cardName.unleashthehounds, mana);
            }

            if (enemyHeroNamee == HeroEnum.priest)
            {
                mana = EnemyPlaysACard(CardDB.cardName.holynova, mana);
            }

            if (enemyHeroNamee == HeroEnum.shaman)
            {
                mana = EnemyPlaysACard(CardDB.cardName.lightningstorm, mana);
            }

            if (enemyHeroNamee == HeroEnum.pala)
            {
                mana = EnemyPlaysACard(CardDB.cardName.consecration, mana);
            }

            if (enemyHeroNamee == HeroEnum.druid)
            {
                mana = EnemyPlaysACard(CardDB.cardName.swipe, mana);
            }



            return mana;
        }

        private int EnemyPlaysACard(CardDB.cardName cardname, int currmana)
        {

            //todo manacosts

            if (cardname == CardDB.cardName.flamestrike && currmana >= 7)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                int damage = getEnemySpellDamageDamage(4);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true, true);
                }

                currmana -= 7;
                return currmana;
            }

            if (cardname == CardDB.cardName.blizzard && currmana >= 6)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                int damage = getEnemySpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    enemy.frozen = true;
                    minionGetDamagedOrHealed(enemy, damage, 0, true, true);
                }

                currmana -= 6;
                return currmana;
            }


            if (cardname == CardDB.cardName.unleashthehounds && currmana >= 5)
            {
                int anz = this.ownMinions.Count;
                int posi = this.enemyMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_538t);//hound
                for (int i = 0; i < anz; i++)
                {
                    callKid(kid, posi, false);
                }
                currmana -= 5;
                return currmana;
            }





            if (cardname == CardDB.cardName.holynova && currmana >= 5)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int heal = 2;
                int damage = getEnemySpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal, false, true);
                }
                attackOrHealHero(-heal, false);
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true, true);
                }
                attackOrHealHero(damage, true);
                currmana -= 5;
                return currmana;
            }




            if (cardname == CardDB.cardName.lightningstorm && currmana >= 4)//3
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                int damage = getEnemySpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true, true);
                }
                currmana -= 3;
                return currmana;
            }



            if (cardname == CardDB.cardName.whirlwind && currmana >= 3)//1
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getEnemySpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }
                temp.Clear();
                temp = new List<Minion>(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true, true);
                }
                currmana -= 1;
                return currmana;
            }



            if (cardname == CardDB.cardName.consecration && currmana >= 4)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                int damage = getEnemySpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true, true);
                }

                attackOrHealHero(damage, true);
                currmana -= 4;
                return currmana;
            }



            if (cardname == CardDB.cardName.swipe && currmana >= 4)
            {
                int damage = getEnemySpellDamageDamage(4);
                // all others get 1 spelldamage
                int damage1 = getEnemySpellDamageDamage(1);

                List<Minion> temp = new List<Minion>(this.ownMinions);
                int target = 10;
                foreach (Minion mnn in temp)
                {
                    if (mnn.Hp <= damage || PenalityManager.Instance.specialMinions.ContainsKey(mnn.name))
                    {
                        target = mnn.id;
                    }
                }
                foreach (Minion mnn in temp)
                {
                    if (mnn.id + 10 != target)
                    {
                        minionGetDamagedOrHealed(mnn, damage1, 0, false);
                    }
                }
                currmana -= 4;
                return currmana;
            }





            return currmana;
        }

        private int getEnemySpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.enemyspellpower;
            if (this.enemydoublepriest >= 1) retval *= (2 * this.enemydoublepriest);
            return retval;
        }

        public void prepareNextTurn()
        {
            this.ownMaxMana = Math.Min(10, this.ownMaxMana + 1);
            this.mana = this.ownMaxMana - this.ueberladung;
            foreach (Minion m in ownMinions)
            {
                m.Ready = true;
                m.numAttacksThisTurn = 0;
                m.playedThisTurn = false;
            }

            if (this.ownWeaponName != CardDB.cardName.unknown) this.ownHeroReady = true;
            this.ownheroAngr = this.ownWeaponAttack;
            this.ownHeroFrozen = false;
            this.ownAbilityReady = true;
            this.complete = false;
            this.sEnemTurn = false;
            this.value = int.MinValue;
        }

        public List<targett> getAttackTargets(bool own)
        {
            List<targett> trgts = new List<targett>();
            List<targett> trgts2 = new List<targett>();
            bool hastanks = false;
            if (own)
            {
                trgts2.Add(new targett(200, this.enemyHeroEntity));
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.stealth) continue; // cant target stealth

                    if (m.taunt)
                    {
                        hastanks = true;
                        trgts.Add(new targett(m.id + 10, m.entitiyID));
                    }
                    else
                    {
                        trgts2.Add(new targett(m.id + 10, m.entitiyID));
                    }
                }
            }
            else
            {

                foreach (Minion m in this.ownMinions)
                {
                    if (m.stealth) continue; // cant target stealth

                    if (m.taunt)
                    {
                        hastanks = true;
                        trgts.Add(new targett(m.id, m.entitiyID));
                    }
                    else
                    {
                        trgts2.Add(new targett(m.id, m.entitiyID));
                    }
                }

                //if (trgts2.Count == 0) trgts2.Add(new targett(100, this.ownHeroEntity));
            }

            if (hastanks) return trgts;

            return trgts2;


        }

        public int getBestPlace(CardDB.Card card, bool lethal)
        {
            if (card.type != CardDB.cardtype.MOB) return 0;
            if (this.ownMinions.Count == 0) return 0;
            if (this.ownMinions.Count == 1) return 1;

            int[] places = new int[this.ownMinions.Count];
            int i = 0;
            int tempval = 0;
            if (lethal && card.name == CardDB.cardName.defenderofargus)
            {
                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (m.Ready)
                    {
                        tempval -= m.Angr - 1;
                        if (m.windfury) tempval -= m.Angr - 1;
                    }
                    places[i] = tempval;

                    i++;
                }


                i = 0;
                int bestpl = 7;
                int bestval = 10000;
                foreach (Minion m in this.ownMinions)
                {
                    int prev = 0;
                    int next = 0;
                    if (i >= 1) prev = places[i - 1];
                    next = places[i];
                    if (bestval > prev + next)
                    {
                        bestval = prev + next;
                        bestpl = i;
                    }
                    i++;
                }
                return bestpl;
            }
            if (card.name == CardDB.cardName.sunfuryprotector || card.name == CardDB.cardName.defenderofargus) // bestplace, if right and left minions have no taunt + lots of hp, dont make priority-minions to taunt
            {
                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (!m.taunt)
                    {
                        tempval -= m.Hp;
                    }
                    else
                    {
                        tempval -= m.Hp + 2;
                    }

                    if (m.handcard.card.name == CardDB.cardName.flametonguetotem) tempval += 50;
                    if (m.handcard.card.name == CardDB.cardName.raidleader) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.grimscaleoracle) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.direwolfalpha) tempval += 50;
                    if (m.handcard.card.name == CardDB.cardName.murlocwarleader) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.southseacaptain) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.stormwindchampion) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.timberwolf) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.leokk) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.northshirecleric) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.sorcerersapprentice) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.pintsizedsummoner) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.summoningportal) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.scavenginghyena) tempval += 10;

                    places[i] = tempval;

                    i++;
                }


                i = 0;
                int bestpl = 7;
                int bestval = 10000;
                foreach (Minion m in this.ownMinions)
                {
                    int prev = 0;
                    int next = 0;
                    if (i >= 1) prev = places[i - 1];
                    next = places[i];
                    if (bestval > prev + next)
                    {
                        bestval = prev + next;
                        bestpl = i;
                    }
                    i++;
                }
                return bestpl;
            }

            int cardIsBuffer = 0;
            bool placebuff = false;
            if (card.name == CardDB.cardName.flametonguetotem || card.name == CardDB.cardName.direwolfalpha)
            {
                placebuff = true;
                if (card.name == CardDB.cardName.flametonguetotem) cardIsBuffer = 2;
                if (card.name == CardDB.cardName.direwolfalpha) cardIsBuffer = 1;
            }
            bool commander = false;
            foreach (Minion m in this.ownMinions)
            {
                if (m.handcard.card.name == CardDB.cardName.warsongcommander) commander = true;
            }
            foreach (Minion m in this.ownMinions)
            {
                if (m.handcard.card.name == CardDB.cardName.flametonguetotem || m.handcard.card.name == CardDB.cardName.direwolfalpha) placebuff = true;
            }
            //attackmaxing :D
            if (placebuff)
            {


                int cval = 0;
                if (card.Charge || (card.Attack <= 3 && commander))
                {
                    cval = card.Attack;
                    if (card.windfury) cval = card.Attack;
                }
                i = 0;
                int[] buffplaces = new int[this.ownMinions.Count];
                int gesval = 0;
                foreach (Minion m in this.ownMinions)
                {
                    buffplaces[i] = 0;
                    places[i] = 0;
                    if (m.Ready)
                    {
                        tempval = m.Angr;
                        if (m.windfury && m.numAttacksThisTurn == 0) tempval += m.Angr;

                    }
                    if (m.handcard.card.name == CardDB.cardName.flametonguetotem)
                    {
                        buffplaces[i] = 2;
                    }
                    if (m.handcard.card.name == CardDB.cardName.direwolfalpha)
                    {
                        buffplaces[i] = 1;
                    }
                    places[i] = tempval;
                    gesval += tempval;
                    i++;
                }

                int bplace = 0;
                int bvale = 0;
                tempval = 0;
                i = 0;
                for (int j = 0; j <= this.ownMinions.Count; j++)
                {
                    tempval = gesval;
                    int current = cval;
                    int prev = 0;
                    int next = 0;
                    if (i >= 1)
                    {
                        tempval -= places[i - 1];
                        prev = places[i - 1];
                        prev += cardIsBuffer;
                        current += buffplaces[i - 1];
                        if (i < this.ownMinions.Count)
                        {
                            prev -= buffplaces[i];
                        }
                    }
                    if (i < this.ownMinions.Count)
                    {
                        tempval -= places[i];
                        next = places[i];
                        next += cardIsBuffer;
                        current += buffplaces[i];
                        if (i >= 1)
                        {
                            next -= buffplaces[i - 1];
                        }
                    }
                    tempval += current + prev + next;
                    if (tempval > bvale)
                    {
                        bplace = i;
                        bvale = tempval;
                    }
                    i++;
                }
                return bplace;

            }

            // normal placement
            int cardvalue = card.Attack * 2 + card.Health;
            if (card.tank)
            {
                cardvalue += 5;
                cardvalue += card.Health;
            }

            if (card.name == CardDB.cardName.flametonguetotem) cardvalue += 90;
            if (card.name == CardDB.cardName.raidleader) cardvalue += 10;
            if (card.name == CardDB.cardName.grimscaleoracle) cardvalue += 10;
            if (card.name == CardDB.cardName.direwolfalpha) cardvalue += 90;
            if (card.name == CardDB.cardName.murlocwarleader) cardvalue += 10;
            if (card.name == CardDB.cardName.southseacaptain) cardvalue += 10;
            if (card.name == CardDB.cardName.stormwindchampion) cardvalue += 10;
            if (card.name == CardDB.cardName.timberwolf) cardvalue += 10;
            if (card.name == CardDB.cardName.leokk) cardvalue += 10;
            if (card.name == CardDB.cardName.northshirecleric) cardvalue += 10;
            if (card.name == CardDB.cardName.sorcerersapprentice) cardvalue += 10;
            if (card.name == CardDB.cardName.pintsizedsummoner) cardvalue += 10;
            if (card.name == CardDB.cardName.summoningportal) cardvalue += 10;
            if (card.name == CardDB.cardName.scavenginghyena) cardvalue += 10;
            if (card.name == CardDB.cardName.faeriedragon) cardvalue += 40;
            cardvalue += 1;

            i = 0;
            foreach (Minion m in this.ownMinions)
            {
                places[i] = 0;
                tempval = m.Angr * 2 + m.maxHp;
                if (m.taunt)
                {
                    tempval += 6;
                    tempval += m.maxHp;
                }
                if (!m.silenced)
                {
                    if (m.handcard.card.name == CardDB.cardName.flametonguetotem) tempval += 90;
                    if (m.handcard.card.name == CardDB.cardName.raidleader) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.grimscaleoracle) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.direwolfalpha) tempval += 90;
                    if (m.handcard.card.name == CardDB.cardName.murlocwarleader) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.southseacaptain) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.stormwindchampion) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.timberwolf) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.leokk) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.northshirecleric) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.sorcerersapprentice) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.pintsizedsummoner) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.summoningportal) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.scavenginghyena) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.faeriedragon) tempval += 40;
                    if (m.stealth) tempval += 40;
                }
                places[i] = tempval;

                i++;
            }

            //bigminion if >=10
            int bestplace = 0;
            int bestvale = 0;
            tempval = 0;
            i = 0;
            for (int j = 0; j <= this.ownMinions.Count; j++)
            {
                int prev = cardvalue;
                int next = cardvalue;
                if (i >= 1) prev = places[i - 1];
                if (i < this.ownMinions.Count) next = places[i];


                if (cardvalue >= prev && cardvalue >= next)
                {
                    tempval = 2 * cardvalue - prev - next;
                    if (tempval > bestvale)
                    {
                        bestplace = i;
                        bestvale = tempval;
                    }
                }
                if (cardvalue <= prev && cardvalue <= next)
                {
                    tempval = -2 * cardvalue + prev + next;
                    if (tempval > bestvale)
                    {
                        bestplace = i;
                        bestvale = tempval;
                    }
                }

                i++;
            }

            return bestplace;
        }

        private void endEnemyTurn()
        {
            endTurnEffect(false);//own turn ends
            endTurnBuffs(false);//end enemy turn
            startTurnEffect(true);//start your turn
            this.complete = true;
            //Ai.Instance.botBase.getPlayfieldValue(this);

        }

        public void endTurn(bool simulateTwoTurns, bool playaround, bool print = false)
        {
            this.value = int.MinValue;

            //penalty for destroying combo

            this.evaluatePenality += ComboBreaker.Instance.checkIfComboWasPlayed(this.playactions, this.ownWeaponName, this.ownHeroName);

            if (this.complete) return;
            endTurnEffect(true);//own turn ends
            endTurnBuffs(true);//end own buffs 
            startTurnEffect(false);//enemy turn begins
            simulateTraps();
            if (!sEnemTurn)
            {
                guessHeroDamage();
                endTurnEffect(false);//own turn ends
                endTurnBuffs(false);//end enemy turn
                startTurnEffect(true);//start your turn
                this.complete = true;
            }
            else
            {
                guessHeroDamage();
                if (this.guessingHeroHP >= 1)
                {
                    simulateEnemysTurn(simulateTwoTurns, playaround, print);
                }
                this.complete = true;
            }

        }

        private void guessHeroDamage()
        {
            int ghd = 0;
            foreach (Minion m in this.enemyMinions)
            {
                if (m.frozen) continue;
                if (m.name == CardDB.cardName.ancientwatcher && !m.silenced)
                {
                    continue;
                }
                ghd += m.Angr;
                if (m.windfury) ghd += m.Angr;
            }

            if (this.enemyHeroName == HeroEnum.druid) ghd++;
            if (this.enemyHeroName == HeroEnum.mage) ghd++;
            if (this.enemyHeroName == HeroEnum.thief) ghd++;
            if (this.enemyHeroName == HeroEnum.hunter) ghd += 2;
            ghd += enemyWeaponAttack;

            foreach (Minion m in this.ownMinions)
            {
                if (m.frozen) continue;
                if (m.taunt) ghd -= m.Hp;
                if (m.taunt && m.divineshild) ghd -= 1;
            }

            int guessingHeroDamage = Math.Max(0, ghd);
            this.guessingHeroHP = this.ownHeroHp + this.ownHeroDefence - guessingHeroDamage;
        }

        private void simulateTraps()
        {
            // DONT KILL ENEMY HERO (cause its only guessing)
            foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
            {
                //hunter secrets############
                if (secretID == CardDB.cardIDEnum.EX1_554) //snaketrap
                {

                    //call 3 snakes (if possible)
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t);//snake
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                }
                if (secretID == CardDB.cardIDEnum.EX1_609) //snipe
                {
                    //kill weakest minion of enemy
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionGetDamagedOrHealed(m, 4, 0, false);
                }
                if (secretID == CardDB.cardIDEnum.EX1_610) //explosive trap
                {
                    //take 2 damage to each enemy
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    foreach (Minion m in temp)
                    {
                        minionGetDamagedOrHealed(m, 2, 0, false);
                    }
                    attackEnemyHeroWithoutKill(2);
                }
                if (secretID == CardDB.cardIDEnum.EX1_611) //freezing trap
                {
                    //return weakest enemy minion to hand
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionReturnToHand(m, false, 0);
                }
                if (secretID == CardDB.cardIDEnum.EX1_533) // missdirection
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => -a.Angr.CompareTo(b.Angr));//take the strongest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    m.Angr = 0;
                    this.evaluatePenality -= this.enemyMinions.Count;// the more the enemy minions has on board, the more the posibility to destroy something other :D
                }

                //mage secrets############
                if (secretID == CardDB.cardIDEnum.EX1_287) //counterspell
                {
                    // what should we do?
                    this.evaluatePenality -= 8;
                }

                if (secretID == CardDB.cardIDEnum.EX1_289) //ice barrier
                {
                    this.ownHeroDefence += 8;
                }

                if (secretID == CardDB.cardIDEnum.EX1_295) //ice barrier
                {
                    //set the guessed Damage to zero
                    foreach (Minion m in this.enemyMinions)
                    {
                        m.Angr = 0;
                    }
                }

                if (secretID == CardDB.cardIDEnum.EX1_294) //mirror entity
                {
                    //summon snake ( a weak minion)
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t);//snake
                    callKid(kid, posi, true);
                }
                if (secretID == CardDB.cardIDEnum.tt_010) //spellbender
                {
                    //whut???
                    // add 2 to your defence (most attack-buffs give +2, lots of damage spells too)
                    this.evaluatePenality -= 4;
                }
                if (secretID == CardDB.cardIDEnum.EX1_594) // vaporize
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage and destroy weakest minion
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionGetDestroyed(m, false);
                }
                if (secretID == CardDB.cardIDEnum.FP1_018) // duplicate
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage and destroy weakest minion
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    drawACard(m.name, true);
                    drawACard(m.name, true);
                }

                //pala secrets############
                if (secretID == CardDB.cardIDEnum.EX1_132) // eye for an eye
                {
                    // enemy takes one damage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    attackEnemyHeroWithoutKill(m.Angr);
                }
                if (secretID == CardDB.cardIDEnum.EX1_130) // noble sacrifice
                {
                    //spawn a 2/1 taunt!
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_121);//frostwolfgrunt
                    callKid(kid, posi, true);
                    this.ownMinions[this.ownMinions.Count - 1].maxHp = 1;
                    this.ownMinions[this.ownMinions.Count - 1].Hp = 1;

                }

                if (secretID == CardDB.cardIDEnum.EX1_136) // redemption
                {
                    // we give our weakest minion a divine shield :D
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;
                    foreach (Minion m in temp)
                    {
                        if (m.divineshild) continue;
                        m.divineshild = true;
                        break;
                    }
                }

                if (secretID == CardDB.cardIDEnum.EX1_379) // repentance
                {
                    // set his current lowest hp minion to x/1
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    m.Hp = 1;
                    m.maxHp = 1;
                }

                if (secretID == CardDB.cardIDEnum.FP1_020) // avenge
                {
                    // we give our weakest minion +3/+2 :D
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;
                    foreach (Minion m in temp)
                    {
                        minionGetBuffed(m, 3, 2, true);
                        break;
                    }
                }
            }


        }

        private void endTurnBuffs(bool own)
        {

            List<Minion> temp = new List<Minion>();

            if (own)
            {
                temp.AddRange(this.ownMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
            }
            // end buffs
            foreach (Minion m in temp)
            {
                m.cantLowerHPbelowONE = false;
                m.immune = false;
                List<Enchantment> tempench = new List<Enchantment>(m.enchantments);
                foreach (Enchantment e in tempench)
                {

                    if (e.CARDID == CardDB.cardIDEnum.NEW1_036e || e.CARDID == CardDB.cardIDEnum.NEW1_036e2)//commanding shout
                    {
                        debuff(m, e, own);
                    }

                    if (e.CARDID == CardDB.cardIDEnum.EX1_316e)//ueberwaeltigende macht
                    {
                        minionGetDestroyed(m, own);
                    }

                    if (e.CARDID == CardDB.cardIDEnum.CS2_046e)//kampfrausch
                    {
                        debuff(m, e, own);
                    }

                    if (e.CARDID == CardDB.cardIDEnum.CS2_045e)// waffe felsbeiser
                    {
                        debuff(m, e, own);
                    }

                    if (e.CARDID == CardDB.cardIDEnum.EX1_046e)// dunkeleisenzwerg
                    {
                        debuff(m, e, own);
                    }
                    if (e.CARDID == CardDB.cardIDEnum.CS2_188o)// ruchloserunteroffizier
                    {
                        debuff(m, e, own);
                    }
                    if (e.CARDID == CardDB.cardIDEnum.EX1_055o)//  manasuechtige
                    {
                        debuff(m, e, own);
                    }
                    if (e.CARDID == CardDB.cardIDEnum.EX1_549o)//zorn des wildtiers
                    {
                        debuff(m, e, own);
                    }
                    if (e.CARDID == CardDB.cardIDEnum.EX1_334e)// dunkler wahnsin (control minion till end of turn)
                    {
                        //"uncontrol minion"
                        minionGetControlled(m, !own, true);
                    }
                }


            }

            temp.Clear();
            if (own)
            {
                temp.AddRange(this.enemyMinions);

            }
            else
            {
                temp.AddRange(this.ownMinions);
            }

            foreach (Minion m in temp)
            {
                m.cantLowerHPbelowONE = false;
                m.immune = false;
                List<Enchantment> tempench = new List<Enchantment>(m.enchantments);
                foreach (Enchantment e in tempench)
                {

                    if (e.CARDID == CardDB.cardIDEnum.EX1_046e)// dunkeleisenzwerg
                    {
                        debuff(m, e, !own);
                    }
                    if (e.CARDID == CardDB.cardIDEnum.CS2_188o)// ruchloserunteroffizier
                    {
                        debuff(m, e, !own);
                    }
                    if (e.CARDID == CardDB.cardIDEnum.EX1_549o)//zorn des wildtiers
                    {
                        debuff(m, e, !own);
                    }

                }
            }

        }


        private void endTurnEffect(bool own)
        {

            List<Minion> temp = new List<Minion>();
            List<Minion> ownmins = new List<Minion>();
            List<Minion> enemymins = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
                ownmins.AddRange(this.ownMinions);
                enemymins.AddRange(this.enemyMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
                ownmins.AddRange(this.enemyMinions);
                enemymins.AddRange(this.ownMinions);
            }



            foreach (Minion m in temp)
            {
                if (m.silenced) continue;

                if (m.name == CardDB.cardName.barongeddon) // all other chards get dmg get 2 dmg
                {
                    List<Minion> temp2 = new List<Minion>(this.ownMinions);
                    foreach (Minion mm in temp2)
                    {
                        if (mm.entitiyID != m.entitiyID)
                        {
                            minionGetDamagedOrHealed(mm, 2, 0, true);
                        }
                    }
                    temp2.Clear();
                    temp2.AddRange(this.enemyMinions);
                    foreach (Minion mm in temp2)
                    {
                        if (mm.entitiyID != m.entitiyID)
                        {
                            minionGetDamagedOrHealed(mm, 2, 0, false);
                        }
                    }
                    attackOrHealHero(2, true);
                    attackOrHealHero(2, false);

                }

                if (m.name == CardDB.cardName.bloodimp || m.name == CardDB.cardName.youngpriestess) // buff a minion
                {
                    List<Minion> temp2 = new List<Minion>(ownmins);
                    temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//buff the weakest
                    foreach (Minion mins in temp2)
                    {
                        if (m.id == mins.id) continue;
                        minionGetBuffed(mins, 0, 1, own);
                        break;
                    }
                }

                if (m.name == CardDB.cardName.masterswordsmith) // buff a minion
                {
                    List<Minion> temp2 = new List<Minion>(ownmins);
                    temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));//buff the weakest
                    foreach (Minion mins in temp2)
                    {
                        if (m.id == mins.id) continue;
                        minionGetBuffed(mins, 1, 0, own);
                        break;
                    }
                }

                if (m.name == CardDB.cardName.emboldener3000) // buff a minion
                {
                    bool buffown = false;
                    List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                    if (temp2.Count == 0)
                    {
                        temp2.AddRange(this.ownMinions);
                        buffown = true;
                    }
                    temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));//buff the strongest enemy
                    foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                    {
                        minionGetBuffed(mins, 1, 0, buffown);//buff alyways enemy :D
                    }
                }

                if (m.name == CardDB.cardName.gruul) // gain +1/+1
                {
                    minionGetBuffed(m, 1, 1, own);
                }

                if (m.name == CardDB.cardName.etherealarcanist) // gain +2/+2
                {
                    if (own && this.ownSecretsIDList.Count >= 1)
                    {
                        minionGetBuffed(m, 2, 2, own);
                    }
                    if (!own && this.enemySecretCount >= 1)
                    {
                        minionGetBuffed(m, 2, 2, own);
                    }
                }


                if (m.name == CardDB.cardName.manatidetotem) // draw card
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                }

                if (m.name == CardDB.cardName.healingtotem) // heal
                {
                    List<Minion> temp2 = new List<Minion>(ownmins);
                    foreach (Minion mins in temp2)
                    {
                        minionGetDamagedOrHealed(mins, 0, 1, own);
                    }
                }

                if (m.name == CardDB.cardName.hogger) // summon
                {
                    int posi = m.id;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_040t);//gnoll
                    callKid(kid, posi, own);
                }

                if (m.name == CardDB.cardName.impmaster) // damage itself and summon 
                {
                    int posi = m.id;
                    if (m.Hp == 1) posi--;
                    minionGetDamagedOrHealed(m, 1, 0, own);

                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_598);//imp
                    callKid(kid, posi, own);
                    m.stealth = false;
                }

                if (m.name == CardDB.cardName.natpagle) // draw card
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                }

                if (m.name == CardDB.cardName.ragnarosthefirelord) // summon
                {
                    if (this.enemyMinions.Count >= 1)
                    {
                        List<Minion> temp2 = new List<Minion>(enemymins);
                        temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the stronges
                        foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                        {
                            minionGetDamagedOrHealed(mins, 8, 0, !own);
                        }
                    }
                    else
                    {
                        attackOrHealHero(8, !own);
                    }
                    m.stealth = false;
                }


                if (m.name == CardDB.cardName.repairbot) // heal damaged char
                {

                    attackOrHealHero(-6, false);
                }
                if (m.handcard.card.cardIDenum == CardDB.cardIDEnum.EX1_tk9) //treant which is destroyed
                {
                    minionGetDestroyed(m, own);
                }

                if (m.name == CardDB.cardName.ysera) // draw card
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard(CardDB.cardName.yseraawakens, own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard(CardDB.cardName.yseraawakens, own);
                    }
                }
                if (m.name == CardDB.cardName.echoingooze) // draw card
                {
                    this.callKid(m.handcard.card, m.id, own);
                    foreach (Minion mnn in temp)
                    {
                        if (mnn.name == CardDB.cardName.echoingooze && m.entitiyID != mnn.entitiyID)
                        {
                            mnn.setMinionTominion(m);
                            break;
                        }
                    }

                }
                if (m.name == CardDB.cardName.kelthuzad) // summon death minion
                {
                    foreach (Minion mnn in this.diedMinions)
                    {
                        if (own)
                        {
                            if (m.id >= 0 && m.id <= 9) callKid(m.handcard.card, m.id, true);
                        }
                        else
                        {
                            if (m.id >= 10 && m.id <= 19) callKid(m.handcard.card, m.id, false);
                        }
                    }
                }

            }

            foreach (Minion m in enemymins)
            {
                if (m.name == CardDB.cardName.gruul) // gain +1/+1
                {
                    minionGetBuffed(m, 1, 1, !own);
                }

                if (m.name == CardDB.cardName.kelthuzad) // summon death minion
                {
                    foreach (Minion mnn in this.diedMinions)
                    {
                        if (own)
                        {
                            if (m.id >= 0 && m.id <= 9) callKid(m.handcard.card, m.id, true);
                        }
                        else
                        {
                            if (m.id >= 10 && m.id <= 19) callKid(m.handcard.card, m.id, false);
                        }
                    }
                }
            }

        }

        private void startTurnEffect(bool own)
        {
            List<Minion> temp = new List<Minion>();
            List<Minion> ownmins = new List<Minion>();
            List<Minion> enemymins = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
                ownmins.AddRange(this.ownMinions);
                enemymins.AddRange(this.enemyMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
                ownmins.AddRange(this.enemyMinions);
                enemymins.AddRange(this.ownMinions);
            }

            bool untergang = false;
            foreach (Minion m in temp)
            {
                if (m.silenced) continue;

                if (m.name == CardDB.cardName.demolisher) // deal 2 dmg
                {
                    List<Minion> temp2 = new List<Minion>(enemymins);
                    foreach (Minion mins in temp2)
                    {
                        minionGetDamagedOrHealed(mins, 2, 0, !own);
                    }
                }

                if (m.name == CardDB.cardName.shadeofnaxxramas) // buff itself
                {
                    minionGetBuffed(m, 1, 1, own);
                }

                if (m.name == CardDB.cardName.doomsayer) // destroy
                {
                    untergang = true;
                }

                if (m.name == CardDB.cardName.homingchicken) // ok
                {
                    minionGetDestroyed(m, own);
                    if (own)
                    {
                        //this.owncarddraw += 3;
                        this.drawACard(CardDB.cardName.unknown, own);
                        this.drawACard(CardDB.cardName.unknown, own);
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                    else
                    {
                        //this.enemycarddraw += 3 ;
                        this.drawACard(CardDB.cardName.unknown, own);
                        this.drawACard(CardDB.cardName.unknown, own);
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                }

                if (m.name == CardDB.cardName.lightwell) // heal
                {
                    if (ownmins.Count >= 1)
                    {
                        List<Minion> temp2 = new List<Minion>(ownmins);
                        bool healed = false;
                        foreach (Minion mins in temp2)
                        {
                            if (mins.wounded)
                            {
                                minionGetDamagedOrHealed(mins, 0, 3, own);
                                healed = true;
                                break;
                            }
                        }

                        if (!healed) attackOrHealHero(-3, own);
                    }
                    else
                    {
                        attackOrHealHero(-3, own);
                    }
                }

                if (m.name == CardDB.cardName.poultryizer) // 
                {
                    if (own)
                    {
                        if (this.enemyMinions.Count >= 1)
                        {
                            List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//damage the lowest
                            foreach (Minion mins in temp2)
                            {
                                CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka4t);
                                minionTransform(mins, c, false);
                                break;
                            }

                        }
                        else
                        {

                            List<Minion> temp2 = new List<Minion>(this.ownMinions);
                            temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the stronges
                            foreach (Minion mins in temp2)
                            {
                                CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka4t);
                                minionTransform(mins, c, true);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (this.ownMinions.Count >= 1)
                        {
                            List<Minion> temp2 = new List<Minion>(this.ownMinions);
                            temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the stronges
                            foreach (Minion mins in temp2)
                            {
                                CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka4t);
                                minionTransform(mins, c, true);
                                break;
                            }
                        }
                    }
                }

                if (m.name == CardDB.cardName.alarmobot) // 
                {
                    if (own)
                    {
                        List<Handmanager.Handcard> temp2 = new List<Handmanager.Handcard>();
                        foreach (Handmanager.Handcard hc in this.owncards)
                        {
                            if (hc.card.type == CardDB.cardtype.MOB) temp2.Add(hc);
                        }
                        temp2.Sort((a, b) => -a.card.Attack.CompareTo(b.card.Attack));//damage the stronges
                        foreach (Handmanager.Handcard mins in temp2)
                        {
                            CardDB.Card c = CardDB.Instance.getCardDataFromID(mins.card.cardIDenum);
                            minionTransform(m, c, true);
                            this.removeCard(mins);
                            this.drawACard(CardDB.cardName.alarmobot, true);
                            break;
                        }
                    }
                    else
                    {
                        minionGetBuffed(m, 4, 4, false);
                        m.Hp = m.maxHp;
                    }

                }

                if (m.name == CardDB.cardName.stoneskingargoyle) // 
                {
                    m.Hp = m.maxHp;
                    m.wounded = false;

                }


            }


            foreach (Minion m in enemymins) // search for corruption in other minions
            {
                List<Enchantment> elist = new List<Enchantment>(m.enchantments);
                foreach (Enchantment e in elist)
                {

                    if (e.CARDID == CardDB.cardIDEnum.CS2_063e)//corruption
                    {
                        if (own && e.controllerOfCreator == this.ownController) // own turn + we owner of curruption
                        {
                            minionGetDestroyed(m, false);
                        }
                        if (!own && e.controllerOfCreator != this.ownController)
                        {
                            minionGetDestroyed(m, true);
                        }
                    }
                }
            }

            if (untergang)
            {
                foreach (Minion mins in ownmins)
                {
                    minionGetDestroyed(mins, own);

                }
                foreach (Minion mins in enemymins)
                {
                    minionGetDestroyed(mins, !own);
                }
            }

            this.drawACard(CardDB.cardName.unknown, own);
        }

        private int getSpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.spellpower;
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }



        private int getSpellHeal(int heal)
        {
            int retval = heal;
            retval += this.spellpower;
            if (this.auchenaiseelenpriesterin) retval *= -1;
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        private void attackEnemyHeroWithoutKill(int dmg)
        {
            if (this.enemyHeroImmune && dmg > 0) return;
            int oldHp = this.enemyHeroHp;
            if (dmg < 0 && this.enemyHeroHp <= 0) return;
            if (this.enemyHeroDefence <= 0)
            {
                this.enemyHeroHp = Math.Min(30, this.enemyHeroHp - dmg);
            }
            else
            {
                if (this.enemyHeroDefence > 0)
                {

                    int rest = enemyHeroDefence - dmg;
                    if (rest < 0)
                    {
                        this.enemyHeroHp += rest;
                    }
                    this.enemyHeroDefence = Math.Max(0, this.enemyHeroDefence - dmg);

                }
            }

            if (oldHp >= 1 && this.enemyHeroHp == 0) this.enemyHeroHp = 1;
        }

        private void attackOrHealHero(int dmg, bool own) // negative damage is heal
        {
            if (own)
            {
                if (this.heroImmune && dmg > 0) return;
                if (dmg < 0 || this.ownHeroDefence <= 0)
                {
                    if (dmg < 0 && this.ownHeroHp <= 0) return;
                    //heal
                    int copy = this.ownHeroHp;

                    if (dmg < 0 && this.ownHeroHp - dmg > 30) this.lostHeal += this.ownHeroHp - dmg - 30;

                    this.ownHeroHp = Math.Min(30, this.ownHeroHp - dmg);
                    if (copy < this.ownHeroHp)
                    {
                        triggerAHeroGetHealed(own);
                    }
                }
                else
                {
                    if (this.ownHeroDefence > 0 && dmg > 0)
                    {

                        int rest = this.ownHeroDefence - dmg;
                        if (rest < 0)
                        {
                            this.ownHeroHp += rest;
                        }
                        this.ownHeroDefence = Math.Max(0, this.ownHeroDefence - dmg);

                    }
                }


            }
            else
            {
                if (this.enemyHeroImmune && dmg > 0) return;
                if (dmg < 0 || this.enemyHeroDefence <= 0)
                {
                    if (dmg < 0 && this.enemyHeroHp <= 0) return;
                    int copy = this.enemyHeroHp;
                    if (dmg < 0 && this.enemyHeroHp - dmg > 30) this.lostHeal += this.enemyHeroHp - dmg - 30;
                    this.enemyHeroHp = Math.Min(30, this.enemyHeroHp - dmg);
                    if (copy < this.enemyHeroHp)
                    {
                        triggerAHeroGetHealed(own);
                    }
                }
                else
                {
                    if (this.enemyHeroDefence > 0 && dmg > 0)
                    {

                        int rest = enemyHeroDefence - dmg;
                        if (rest < 0)
                        {
                            this.enemyHeroHp += rest;
                        }
                        this.enemyHeroDefence = Math.Max(0, this.enemyHeroDefence - dmg);

                    }
                }

            }

        }

        private void debuff(Minion m, Enchantment e, bool own)
        {
            int anz = m.enchantments.RemoveAll(x => x.creator == e.creator && x.CARDID == e.CARDID);
            if (anz >= 1)
            {
                for (int i = 0; i < anz; i++)
                {

                    if (e.charge && !m.handcard.card.Charge && m.enchantments.FindAll(x => x.charge == true).Count == 0)
                    {
                        m.charge = false;
                    }
                    if (e.taunt && !m.handcard.card.tank && m.enchantments.FindAll(x => x.taunt == true).Count == 0)
                    {
                        m.taunt = false;
                    }
                    if (e.divineshild && m.enchantments.FindAll(x => x.divineshild == true).Count == 0)
                    {
                        m.divineshild = false;
                    }
                    if (e.windfury && !m.handcard.card.windfury && m.enchantments.FindAll(x => x.windfury == true).Count == 0)
                    {
                        m.divineshild = false;
                    }
                    if (e.imune && m.enchantments.FindAll(x => x.imune == true).Count == 0)
                    {
                        m.immune = false;
                    }
                    minionGetBuffed(m, -e.angrbuff, -e.hpbuff, own);
                }
            }
        }

        private void deleteEffectOf(CardDB.cardIDEnum CardID, int creator)
        {
            // deletes the effect of the cardID with creator from all minions 
            Enchantment e = CardDB.getEnchantmentFromCardID(CardID);
            e.creator = creator;
            List<Minion> temp = new List<Minion>(this.ownMinions);
            foreach (Minion m in temp)
            {
                debuff(m, e, true);
            }
            temp.Clear();
            temp.AddRange(this.enemyMinions);
            foreach (Minion m in temp)
            {
                debuff(m, e, false);
            }
        }

        private void deleteEffectOfWithExceptions(CardDB.cardIDEnum CardID, int creator, List<int> exeptions)
        {
            // deletes the effect of the cardID with creator from all minions 
            Enchantment e = CardDB.getEnchantmentFromCardID(CardID);
            e.creator = creator;
            foreach (Minion m in this.ownMinions)
            {
                if (!exeptions.Contains(m.id))
                {
                    debuff(m, e, true);
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (!exeptions.Contains(m.id))
                {
                    debuff(m, e, false);
                }
            }
        }

        private void addEffectToMinionNoDoubles(Minion m, Enchantment e, bool own)
        {
            foreach (Enchantment es in m.enchantments)
            {
                if (es.CARDID == e.CARDID && es.creator == e.creator) return;
            }
            m.enchantments.Add(e);
            if (e.angrbuff >= 1 || e.hpbuff >= 1)
            {
                minionGetBuffed(m, e.angrbuff, e.hpbuff, own);
            }
            if (e.charge) minionGetCharge(m);
            if (e.divineshild) m.divineshild = true;
            if (e.taunt) m.taunt = true;
            if (e.windfury) minionGetWindfurry(m);
            if (e.imune) m.immune = true;
        }

        private void adjacentBuffer(Minion m, CardDB.cardIDEnum enchantment, int before, int after, bool own)
        {
            List<Minion> lm = new List<Minion>();
            if (own)
            {
                lm.AddRange(this.ownMinions);
            }
            else
            {
                lm.AddRange(this.enemyMinions);
            }
            List<int> exeptions = new List<int>();
            exeptions.Add(before);
            exeptions.Add(after);
            deleteEffectOfWithExceptions(enchantment, m.entitiyID, exeptions);
            Enchantment e = CardDB.getEnchantmentFromCardID(enchantment);
            e.creator = m.entitiyID;
            e.controllerOfCreator = this.ownController;
            if (before >= 0)
            {
                Minion bef = lm[before];
                addEffectToMinionNoDoubles(bef, e, own);
            }
            if (after < lm.Count)
            {
                Minion bef = lm[after];
                addEffectToMinionNoDoubles(bef, e, own);
            }
        }

        private void adjacentBuffUpdate(bool own)
        {
            List<Minion> lm = new List<Minion>();
            if (own)
            {
                lm.AddRange(this.ownMinions);
            }
            else
            {
                lm.AddRange(this.enemyMinions);
            }
            foreach (Minion m in lm)
            {
                getNewEffects(m, own, m.id, false);
            }

        }

        private void endEffectsDueToDeath(Minion m, bool own)
        { // minion which grants effect died
            if (m.handcard.card.name == CardDB.cardName.raidleader) // if he dies, lower attack of all minions of his side
            {
                deleteEffectOf(CardDB.cardIDEnum.CS2_122e, m.entitiyID);
            }

            if (m.handcard.card.name == CardDB.cardName.flametonguetotem)
            {
                deleteEffectOf(CardDB.cardIDEnum.EX1_565o, m.entitiyID);
            }

            if (m.handcard.card.name == CardDB.cardName.grimscaleoracle)
            {
                deleteEffectOf(CardDB.cardIDEnum.EX1_508o, m.entitiyID);
            }

            if (m.handcard.card.name == CardDB.cardName.direwolfalpha)
            {
                deleteEffectOf(CardDB.cardIDEnum.EX1_162o, m.entitiyID);
            }
            if (m.handcard.card.name == CardDB.cardName.murlocwarleader)
            {
                deleteEffectOf(CardDB.cardIDEnum.EX1_507e, m.entitiyID);
            }
            if (m.handcard.card.name == CardDB.cardName.southseacaptain)
            {
                deleteEffectOf(CardDB.cardIDEnum.NEW1_027e, m.entitiyID);
            }
            if (m.handcard.card.name == CardDB.cardName.stormwindchampion)
            {
                deleteEffectOf(CardDB.cardIDEnum.CS2_222o, m.entitiyID);
            }
            if (m.handcard.card.name == CardDB.cardName.timberwolf)
            {
                deleteEffectOf(CardDB.cardIDEnum.DS1_175o, m.entitiyID);
            }
            if (m.handcard.card.name == CardDB.cardName.leokk)
            {
                deleteEffectOf(CardDB.cardIDEnum.NEW1_033o, m.entitiyID);
            }

            //lowering truebaugederalte

            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.handcard.card.name == CardDB.cardName.oldmurkeye && m.handcard.card.race == 14)
                {
                    minionGetBuffed(mnn, -1, 0, true);
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.handcard.card.name == CardDB.cardName.oldmurkeye && m.handcard.card.race == 14)
                {
                    minionGetBuffed(mnn, -1, 0, false);
                }
            }

            //no deathrattle, but lowering the weapon
            if (m.handcard.card.name == CardDB.cardName.spitefulsmith && m.wounded)// remove weapon changes form hasserfuelleschmiedin
            {
                if (own && this.ownWeaponDurability >= 1)
                {
                    this.ownWeaponAttack -= 2;
                    this.ownheroAngr -= 2;
                }
                if (!own && this.enemyWeaponDurability >= 1)
                {
                    this.enemyWeaponAttack -= 2;
                    this.enemyheroAngr -= 2;
                }
            }
        }

        private void getNewEffects(Minion m, bool own, int placeOfNewMob, bool isSummon)
        {
            bool havekriegshymnenanfuehrerin = false;
            List<Minion> temp = new List<Minion>(this.ownMinions);
            int controller = this.ownController;
            if (!own)
            {
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                controller = 0;
            }
            int ownanz = temp.Count;

            if (own && isSummon && this.ownWeaponName == CardDB.cardName.swordofjustice)
            {
                minionGetBuffed(m, 1, 1, own);
                this.lowerWeaponDurability(1, true);
            }

            int adjacentplace = 1;
            if (isSummon) adjacentplace = 0;

            foreach (Minion ownm in temp)
            {
                if (ownm.silenced) continue; // silenced minions dont buff

                if (isSummon && ownm.handcard.card.name == CardDB.cardName.warsongcommander)
                {
                    havekriegshymnenanfuehrerin = true;
                }

                if (ownm.handcard.card.name == CardDB.cardName.raidleader && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.CS2_122e);
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);

                }
                if (ownm.handcard.card.name == CardDB.cardName.leokk && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.NEW1_033o);
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);

                }
                if (ownm.handcard.card.name == CardDB.cardName.stormwindchampion && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.CS2_222o);
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.handcard.card.name == CardDB.cardName.grimscaleoracle && m.handcard.card.race == 14 && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_508o);
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.handcard.card.name == CardDB.cardName.murlocwarleader && m.handcard.card.race == 14 && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_507e);
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.handcard.card.name == CardDB.cardName.southseacaptain && m.handcard.card.race == 23)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.NEW1_027e);
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }


                if (ownm.handcard.card.name == CardDB.cardName.timberwolf && (TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.DS1_175o);
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }

                if (isSummon && ownm.handcard.card.name == CardDB.cardName.tundrarhino && (TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                {
                    minionGetCharge(m);
                }

                if (ownm.handcard.card.name == CardDB.cardName.direwolfalpha)
                {
                    if (ownm.id == placeOfNewMob + 1 || ownm.id == placeOfNewMob - adjacentplace)
                    {
                        Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_162o);
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = controller;
                        addEffectToMinionNoDoubles(m, e, own);
                    }
                    else
                    {
                        //remove effect!!
                        Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_162o);
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = controller;
                        debuff(m, e, own);
                    }
                }
                if (ownm.handcard.card.name == CardDB.cardName.flametonguetotem)
                {
                    if (ownm.id == placeOfNewMob + 1 || ownm.id == placeOfNewMob - adjacentplace)
                    {
                        Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_565o);
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = controller;
                        addEffectToMinionNoDoubles(m, e, own);
                    }
                    else
                    {
                        //remove effect!!
                        Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_565o);
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = controller;
                        debuff(m, e, own);
                    }

                }
            }
            //buff oldmurk
            if (isSummon && m.handcard.card.name == CardDB.cardName.oldmurkeye && own)
            {
                int murlocs = 0;
                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.handcard.card.race == 14) murlocs++;
                }
                foreach (Minion mnn in this.enemyMinions)
                {
                    if (mnn.handcard.card.race == 14) murlocs++;
                }

                minionGetBuffed(m, murlocs, 0, true);
            }

            // minions that gave ALL minions buffs
            temp.Clear();
            if (own)
            {
                temp.AddRange(this.enemyMinions);
                controller = 0;
            }
            else
            {
                temp.AddRange(this.ownMinions);
                controller = this.ownController;
            }

            foreach (Minion ownm in temp) // the enemy grimmschuppenorakel!
            {
                if (ownm.silenced) continue; // silenced minions dont buff

                if (ownm.handcard.card.name == CardDB.cardName.grimscaleoracle && m.handcard.card.race == 14 && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_508o);
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.handcard.card.name == CardDB.cardName.murlocwarleader && m.handcard.card.race == 14 && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_507e);
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }

            }

            if (isSummon && havekriegshymnenanfuehrerin && m.Angr <= 3)
            {
                minionGetCharge(m);
            }

        }

        private void deathrattle(Minion m, bool own)
        {

            if (!m.silenced)
            {

                //real deathrattles
                if (m.handcard.card.cardIDenum == CardDB.cardIDEnum.EX1_534)//m.name == CardDB.cardName.savannenhochmaehne"
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_534t);//hyena
                    callKid(c, m.id - 1, own);
                    callKid(c, m.id - 1, own);
                }

                if (m.name == CardDB.cardName.harvestgolem)
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.skele21);//damagedgolem
                    callKid(c, m.id - 1, own);
                }

                if (m.name == CardDB.cardName.cairnebloodhoof)
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_110);//bainebloodhoof
                    callKid(c, m.id - 1, own);
                    //penaltity for summon this thing :D (so we dont kill it only to have a new minion)
                    this.evaluatePenality += 5;


                }

                if (m.name == CardDB.cardName.thebeast)
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_finkle);//finkleeinhorn
                    int place = this.enemyMinions.Count - 1;
                    if (!own) place = this.ownMinions.Count - 1;
                    callKid(c, place, !own);

                }

                if (m.name == CardDB.cardName.lepergnome)
                {
                    attackOrHealHero(2, !own);
                }

                if (m.name == CardDB.cardName.loothoarder)
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                    else
                    {
                        this.drawACard(CardDB.cardName.unknown, own);
                        //this.enemycarddraw++;
                    }
                }




                if (m.name == CardDB.cardName.bloodmagethalnos)
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                }

                if (m.name == CardDB.cardName.abomination)
                {
                    if (logging) Helpfunctions.Instance.logg("deathrattle monstrositaet:");
                    attackOrHealHero(2, false);
                    attackOrHealHero(2, true);
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    foreach (Minion mnn in temp)
                    {
                        minionGetDamagedOrHealed(mnn, 2, 0, true);
                    }
                    temp.Clear();
                    temp.AddRange(this.enemyMinions);
                    foreach (Minion mnn in temp)
                    {
                        minionGetDamagedOrHealed(mnn, 2, 0, false);
                    }

                }


                if (m.name == CardDB.cardName.tirionfordring)
                {
                    if (own)
                    {
                        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_383t);//ashbringer
                        this.equipWeapon(c);
                    }
                    else
                    {
                        this.enemyWeaponAttack = 5;
                        this.enemyWeaponDurability = 3;
                    }
                }

                if (m.name == CardDB.cardName.sylvanaswindrunner)
                {
                    List<Minion> temp = new List<Minion>();
                    if (own)
                    {
                        List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                        temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                        temp.AddRange(Helpfunctions.TakeList(temp2, Math.Min(2, this.enemyMinions.Count)));
                    }
                    else
                    {
                        List<Minion> temp2 = new List<Minion>(this.ownMinions);
                        temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));
                        temp.AddRange(temp2);
                    }
                    if (temp.Count >= 1)
                    {
                        if (own)
                        {
                            Minion target = new Minion();
                            target = temp[0];
                            if (temp.Count >= 2 && target.taunt && !temp[1].taunt) target = temp[1];
                            minionGetControlled(target, true, false);
                        }
                        else
                        {
                            Minion target = new Minion();

                            target = temp[0];
                            foreach (Minion mnn in temp)
                            {
                                if (mnn.Ready)
                                {
                                    target = mnn;
                                    break;
                                }
                            }
                            minionGetControlled(target, false, false);
                        }
                    }
                }

                if (m.handcard.card.name == CardDB.cardName.nerubianegg)
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_007t);//nerubian
                    callKid(c, m.id - 1, own);
                }
                if (m.handcard.card.name == CardDB.cardName.dancingswords)
                {
                    this.drawACard(CardDB.cardName.unknown, !own);
                }

                if (m.handcard.card.name == CardDB.cardName.voidcaller)
                {
                    if (own)
                    {
                        List<Handmanager.Handcard> temp = new List<Handmanager.Handcard>();
                        foreach (Handmanager.Handcard hc in this.owncards)
                        {
                            if ((TAG_RACE)hc.card.race == TAG_RACE.DEMON)
                            {
                                temp.Add(hc);
                            }
                        }

                        temp.Sort((x, y) => x.card.Attack.CompareTo(y.card.Attack));

                        foreach (Handmanager.Handcard mnn in temp)
                        {
                            callKid(mnn.card, this.ownMinions.Count - 1, true);
                            removeCard(mnn);
                            break;
                        }

                    }
                    else
                    {
                        if (enemyAnzCards + enemycarddraw >= 1)
                        {
                            CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_301);//felguard
                            callKid(c, this.ownMinions.Count - 1, true);
                        }
                    }
                }

                if (m.handcard.card.name == CardDB.cardName.anubarambusher)
                {
                    if (own)
                    {
                        List<Minion> temp = new List<Minion>();

                        if (own)
                        {
                            List<Minion> temp2 = new List<Minion>(this.ownMinions);
                            temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));
                            temp.AddRange(temp2);
                        }
                        else
                        {
                            List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                            temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                            temp.AddRange(temp2);
                        }

                        if (temp.Count >= 1)
                        {
                            if (own)
                            {
                                Minion target = new Minion();
                                target = temp[0];
                                if (temp.Count >= 2 && !target.taunt && temp[1].taunt) target = temp[1];
                                minionReturnToHand(target, own, 0);
                            }
                            else
                            {
                                Minion target = new Minion();

                                target = temp[0];
                                if (temp.Count >= 2 && target.taunt && !temp[1].taunt) target = temp[1];
                                minionReturnToHand(target, own, 0);
                            }
                        }
                    }
                }

                if (m.handcard.card.name == CardDB.cardName.darkcultist)
                {
                    if (own)
                    {
                        List<Minion> temp = new List<Minion>();

                        if (own)
                        {
                            List<Minion> temp2 = new List<Minion>(this.ownMinions);
                            temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));
                            temp.AddRange(temp2);
                        }
                        else
                        {
                            List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                            temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                            temp.AddRange(temp2);
                        }

                        if (temp.Count >= 1)
                        {
                            if (own)
                            {
                                Minion target = new Minion();
                                target = temp[0];
                                if (temp.Count >= 2 && target.taunt && !temp[1].taunt) target = temp[1];
                                minionGetBuffed(target, 0, 3, own);
                            }
                            else
                            {
                                Minion target = new Minion();

                                target = temp[0];
                                if (temp.Count >= 2 && !target.taunt && temp[1].taunt) target = temp[1];
                                minionGetBuffed(target, 0, 3, own);
                            }
                        }
                    }
                }

                if (m.handcard.card.name == CardDB.cardName.webspinner)
                {
                    if (own)
                    {
                        this.drawACard(CardDB.cardName.rivercrocolisk, true);
                    }
                    else
                    {
                        this.drawACard(CardDB.cardName.rivercrocolisk, false);
                    }
                }

                if (m.handcard.card.name == CardDB.cardName.deathlord)
                {
                    int place = this.enemyMinions.Count - 1;
                    if (!own) place = this.ownMinions.Count - 1;
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_017);//nerubian
                    callKid(c, place, !own);

                }

                if (m.handcard.card.name == CardDB.cardName.hauntedcreeper)
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_002t);
                    callKid(c, m.id - 1, own);
                    callKid(c, m.id - 1, own);
                }

                if (m.handcard.card.name == CardDB.cardName.madscientist)
                {
                    if (own)
                    {
                        if (ownHeroName == HeroEnum.mage)
                        {
                            this.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_289);
                        }
                        if (ownHeroName == HeroEnum.hunter)
                        {
                            this.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_554);
                        }
                        if (ownHeroName == HeroEnum.pala)
                        {
                            this.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_130);
                        }
                    }
                    else
                    {
                        if (enemyHeroName == HeroEnum.mage || enemyHeroName == HeroEnum.hunter || enemyHeroName == HeroEnum.pala)
                        {
                            this.enemySecretCount++;
                        }
                    }
                }
                if (m.handcard.card.name == CardDB.cardName.sludgebelcher)
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_012t);
                    callKid(c, m.id - 1, own);
                }
                if (m.handcard.card.name == CardDB.cardName.unstableghoul)
                {
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    foreach (Minion mnn in temp)
                    {
                        minionGetDamagedOrHealed(mnn, 1, 0, false, true);
                    }
                    temp.Clear();
                    temp.AddRange(this.ownMinions);
                    foreach (Minion mnn in temp)
                    {
                        minionGetDamagedOrHealed(mnn, 1, 0, true, true);
                    }
                }

                if (m.handcard.card.name == CardDB.cardName.zombiechow)
                {
                    this.attackOrHealHero(-5, !own);
                }



            }

            //deathrattle enchantments // these can be triggered after an silence (if they are casted after the silence)
            bool geistderahnen = false;
            foreach (Enchantment e in m.enchantments)
            {
                if (e.CARDID == CardDB.cardIDEnum.CS2_038e && !geistderahnen)
                {
                    //revive minion due to "geist der ahnen"
                    CardDB.Card kid = m.handcard.card;
                    int pos = this.ownMinions.Count - 1;
                    if (!own) pos = this.enemyMinions.Count - 1;
                    callKid(kid, pos, own);
                    geistderahnen = true;
                }
                //Seele des Waldes
                if (e.CARDID == CardDB.cardIDEnum.EX1_158e)
                {
                    //revive minion due to "geist der ahnen"
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant
                    int pos = this.ownMinions.Count - 1;
                    if (!own) pos = this.enemyMinions.Count - 1;
                    callKid(kid, pos, own);
                }
            }


        }

        private void triggerAMinionDied(Minion m, bool own)
        {
            List<Minion> temp = new List<Minion>();
            List<Minion> temp2 = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
                temp2.AddRange(this.enemyMinions);
                if (this.ownhasorcanplayKelThuzad)
                {
                    this.diedMinions.Add(m);
                }
            }
            else
            {
                temp.AddRange(this.enemyMinions);
                temp2.AddRange(this.ownMinions);

                if (this.enemyhasorcanplayKelThuzad)
                {
                    this.diedMinions.Add(m);
                }

                bool ancestral = false;
                if (m.enchantments.Count >= 1)
                {
                    foreach (Enchantment e in m.enchantments)
                    {
                        if (e.CARDID == CardDB.cardIDEnum.CS2_038e)
                        {
                            ancestral = true;
                            break;
                        }
                    }
                }

                if (m.handcard.card.name == CardDB.cardName.cairnebloodhoof || m.handcard.card.name == CardDB.cardName.harvestgolem || ancestral)
                {
                    this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1;
                }
            }

            foreach (Minion mnn in temp)
            {
                if (mnn.silenced) continue;

                if (mnn.handcard.card.name == CardDB.cardName.scavenginghyena && m.handcard.card.race == 20)
                {
                    mnn.Angr += 2; mnn.Hp += 1;
                }
                if (mnn.handcard.card.name == CardDB.cardName.flesheatingghoul)
                {
                    mnn.Angr += 1;
                }
                if (mnn.handcard.card.name == CardDB.cardName.cultmaster)
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard(CardDB.cardName.unknown, own);
                    }
                }
            }

            foreach (Minion mnn in temp2)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.flesheatingghoul)
                {
                    mnn.Angr += 1;
                }
            }

        }

        private void minionGetDestroyed(Minion m, bool own)
        {

            if (own)
            {
                removeMinionFromList(m, this.ownMinions, true);

            }
            else
            {
                removeMinionFromList(m, this.enemyMinions, false);
            }

        }

        private void minionReturnToHand(Minion m, bool own, int manachange)
        {

            if (own)
            {
                removeMinionFromListNoDeath(m, this.ownMinions, true);
                CardDB.Card c = m.handcard.card;
                Handmanager.Handcard hc = new Handmanager.Handcard();
                hc.card = c;
                hc.position = this.owncards.Count + 1;
                hc.entity = m.entitiyID;
                hc.manacost = c.calculateManaCost(this) + manachange;
                this.owncards.Add(hc);
            }
            else
            {
                removeMinionFromListNoDeath(m, this.enemyMinions, false);
                this.enemycarddraw++;
            }

        }

        private void minionTransform(Minion m, CardDB.Card c, bool own)
        {
            Handmanager.Handcard hc = new Handmanager.Handcard(c);
            hc.entity = m.entitiyID;
            bool ancestral = false;
            if (m.enchantments.Count >= 1)
            {
                foreach (Enchantment e in m.enchantments)
                {
                    if (e.CARDID == CardDB.cardIDEnum.CS2_038e)
                    {
                        ancestral = true;
                        break;
                    }
                }
            }
            if (m.handcard.card.name == CardDB.cardName.cairnebloodhoof || m.handcard.card.name == CardDB.cardName.harvestgolem || ancestral)
            {
                this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1;
            }
            Minion tranform = createNewMinion(hc, m.id, own);
            Minion temp = new Minion();
            temp.setMinionTominion(m);
            m.setMinionTominion(tranform);
            m.entitiyID = -2;
            this.endEffectsDueToDeath(temp, own);
            adjacentBuffUpdate(own);
            if (logging) Helpfunctions.Instance.logg("minion got sheep" + m.name + " " + m.Angr);
        }


        private void minionGetSilenced(Minion m, bool own)
        {
            //TODO

            m.taunt = false;
            m.stealth = false;
            m.charge = false;

            m.divineshild = false;
            m.poisonous = false;

            //delete enrage (if minion is silenced the first time)
            if (m.wounded && m.handcard.card.Enrage && !m.silenced)
            {
                deleteWutanfall(m, own);
            }

            //delete enrage (if minion is silenced the first time)

            if (m.frozen && m.numAttacksThisTurn == 0 && !(m.handcard.card.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord) && !m.playedThisTurn)
            {
                m.Ready = true;
            }


            m.frozen = false;

            if (!m.silenced && (m.handcard.card.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord) && !m.playedThisTurn && m.numAttacksThisTurn == 0)
            {
                m.Ready = true;
            }

            endEffectsDueToDeath(m, own);//the minion doesnt die, but its effect is ending

            m.enchantments.Clear();

            m.Angr = m.handcard.card.Attack;
            if (m.maxHp < m.handcard.card.Health)//minion has lower maxHp as his card -> heal his hp
            {
                m.Hp += m.handcard.card.Health - m.maxHp; //heal minion

            }
            m.maxHp = m.handcard.card.Health;
            if (m.Hp > m.maxHp) m.Hp = m.maxHp;

            getNewEffects(m, own, m.id, false);// minion get effects of others 

            m.silenced = true;
        }

        private void minionGetControlled(Minion m, bool newOwner, bool canAttack)
        {
            List<Minion> newOwnerList = new List<Minion>();

            if (newOwner) { newOwnerList = new List<Minion>(this.ownMinions); }
            else { newOwnerList.AddRange(this.enemyMinions); }

            if (newOwnerList.Count >= 7) return;

            if (newOwner)
            {
                removeMinionFromListNoDeath(m, this.enemyMinions, !newOwner);
                m.Ready = false;
                m.playedThisTurn = true;
                this.getNewEffects(m, newOwner, newOwnerList.Count, false);

                addMiniontoList(m, this.ownMinions, newOwnerList.Count, newOwner);
                if (m.charge || canAttack)
                {
                    m.charge = false;
                    minionGetCharge(m);
                }

            }
            else
            {
                removeMinionFromListNoDeath(m, this.ownMinions, !newOwner);
                //m.Ready=false;
                addMiniontoList(m, this.enemyMinions, newOwnerList.Count, newOwner);
                //if (m.charge) minionGetCharge(m);
            }

        }


        private void minionGetWindfurry(Minion m)
        {
            if (m.windfury) return;
            m.windfury = true;
            if (m.frozen) return;
            if (!m.playedThisTurn && m.numAttacksThisTurn <= 1)
            {
                m.Ready = true;
            }
            if (!m.charge && m.numAttacksThisTurn <= 1)
            {
                m.Ready = true;
            }
        }

        private void minionGetCharge(Minion m)
        {
            if (m.charge) return;
            m.charge = true;
            if (m.playedThisTurn && (m.numAttacksThisTurn == 0 || (m.numAttacksThisTurn == 1 && m.windfury)))
            {
                m.Ready = true;
            }
        }

        private void minionGetReady(Minion m) // minion get ready due to attack-buff
        {
            if (!m.silenced && (m.handcard.card.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord)) return;

            if (!m.playedThisTurn && !m.frozen && (m.numAttacksThisTurn == 0 || (m.numAttacksThisTurn == 1 && m.windfury)))
            {
                m.Ready = true;
            }
        }

        private void minionGetBuffed(Minion m, int attackbuff, int hpbuff, bool own)
        {
            if (m.Angr == 0 && attackbuff >= 1) minionGetReady(m);

            m.Angr = Math.Max(0, m.Angr + attackbuff);

            if (hpbuff >= 1)
            {
                m.Hp = m.Hp + hpbuff;
                m.maxHp = m.maxHp + hpbuff;
            }
            else
            {
                //debuffing hp, lower only maxhp (unless maxhp < hp)
                m.maxHp = m.maxHp + hpbuff;
                if (m.maxHp < m.Hp)
                {
                    m.Hp = m.maxHp;
                }
            }


            if (m.maxHp == m.Hp)
            {
                m.wounded = false;
            }
            else
            {
                m.wounded = true;
            }

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }

            if (m.Hp <= 0)
            {
                if (own)
                {
                    this.removeMinionFromList(m, this.ownMinions, true);
                    if (logging) Helpfunctions.Instance.logg("own " + m.name + " died");
                }
                else
                {
                    this.removeMinionFromList(m, this.enemyMinions, false);
                    if (logging) Helpfunctions.Instance.logg("enemy " + m.name + " died");
                }
            }
        }


        private void deleteWutanfall(Minion m, bool own)
        {
            if (m.name == CardDB.cardName.angrychicken)
            {
                minionGetBuffed(m, -5, 0, own);
            }
            if (m.name == CardDB.cardName.amaniberserker)
            {
                minionGetBuffed(m, -3, 0, own);
            }
            if (m.name == CardDB.cardName.taurenwarrior)
            {
                minionGetBuffed(m, -3, 0, own);
            }
            if (m.name == CardDB.cardName.grommashhellscream)
            {
                minionGetBuffed(m, -6, 0, own);
            }
            if (m.name == CardDB.cardName.ragingworgen)
            {
                minionGetBuffed(m, -1, 0, own);
                minionGetWindfurry(m);
            }
            if (m.name == CardDB.cardName.spitefulsmith)
            {
                if (own && this.ownWeaponDurability >= 1)
                {
                    this.ownWeaponAttack -= 2;
                    this.ownheroAngr -= 2;
                }
                if (!own && this.enemyWeaponDurability >= 1)
                {
                    this.enemyWeaponAttack -= 2;
                    this.enemyheroAngr -= 2;
                }
            }
        }

        private void wutanfall(Minion m, bool woundedBefore, bool own) // = enrange effects
        {
            if (!m.handcard.card.Enrage) return; // if minion has no enrange, do nothing
            if (woundedBefore == m.wounded || m.silenced) return; // if he was wounded, and still is (or was unwounded) do nothing

            if (m.wounded && m.Hp >= 1) //is wounded, wasnt wounded before, grant wutanfall
            {
                if (m.name == CardDB.cardName.angrychicken)
                {
                    minionGetBuffed(m, 5, 0, own);
                }
                if (m.name == CardDB.cardName.amaniberserker)
                {
                    minionGetBuffed(m, 3, 0, own);
                }
                if (m.name == CardDB.cardName.taurenwarrior)
                {
                    minionGetBuffed(m, 3, 0, own);
                }
                if (m.name == CardDB.cardName.grommashhellscream)
                {
                    minionGetBuffed(m, 6, 0, own);
                }
                if (m.name == CardDB.cardName.ragingworgen)
                {
                    minionGetBuffed(m, 1, 0, own);
                    minionGetWindfurry(m);
                }
                if (m.name == CardDB.cardName.spitefulsmith)
                {
                    if (own && this.ownWeaponDurability >= 1)
                    {
                        this.ownWeaponAttack += 2;
                        this.ownheroAngr += 2;
                    }
                    if (!own && this.enemyWeaponDurability >= 1)
                    {
                        this.enemyWeaponAttack += 2;
                        this.enemyheroAngr += 2;
                    }
                }

            }

            if (!m.wounded) // reverse buffs
            {
                deleteWutanfall(m, own);
            }
        }

        private void triggerAHeroGetHealed(bool own)
        {
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.lightwarden)
                {
                    minionGetBuffed(mnn, 2, 0, true);
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.lightwarden)
                {
                    minionGetBuffed(mnn, 2, 0, false);
                }
            }
        }

        private void triggerAMinionGetHealed(Minion m, bool own)
        {
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.northshirecleric)
                {
                    //this.owncarddraw++;
                    this.drawACard(CardDB.cardName.unknown, true);
                }
                if (mnn.handcard.card.name == CardDB.cardName.lightwarden)
                {
                    minionGetBuffed(mnn, 2, 0, true);
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.northshirecleric)
                {
                    //this.enemycarddraw++;
                    this.drawACard(CardDB.cardName.unknown, false);
                }
                if (mnn.handcard.card.name == CardDB.cardName.lightwarden)
                {
                    minionGetBuffed(mnn, 2, 0, false);
                }
            }

        }

        private void triggerAMinionGetDamage(Minion m, bool own)
        {
            //minion take dmg
            if (m.handcard.card.name == CardDB.cardName.acolyteofpain && !m.silenced)
            {
                if (own)
                {
                    //this.owncarddraw++;
                    this.drawACard(CardDB.cardName.unknown, own);
                }
                else
                {
                    //this.enemycarddraw++;
                    this.drawACard(CardDB.cardName.unknown, own);
                }
            }
            if (m.handcard.card.name == CardDB.cardName.gurubashiberserker && !m.silenced)
            {
                minionGetBuffed(m, 3, 0, own);
            }
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.frothingberserker)
                {
                    mnn.Angr++;
                }
                if (own)
                {
                    if (mnn.handcard.card.name == CardDB.cardName.armorsmith)
                    {
                        this.ownHeroDefence++;
                    }
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.frothingberserker)
                {
                    mnn.Angr++;
                }
                if (!own)
                {
                    if (mnn.handcard.card.name == CardDB.cardName.armorsmith)
                    {
                        this.enemyHeroDefence++;
                    }
                }
            }
        }

        /*private void minionGetDamagedOrHealed(Minion m, int damages, int heals, bool own)
        {
            minionGetDamagedOrHealed(m, damages, heals, own, false);
        }*/

        private void minionGetDamagedOrHealed(Minion m, int damages, int heals, bool own, bool dontCalcLostDmg = false, bool isMinionattack = false)
        {
            int damage = damages;
            int heal = heals;

            bool woundedbefore = m.wounded;
            if (heal < 0) // heal was shifted in damage
            {
                damage = -1 * heal;
                heal = 0;
            }

            if (damage >= 1 && m.divineshild)
            {
                m.divineshild = false;
                if (!own && !dontCalcLostDmg)
                {
                    if (isMinionattack)
                    {
                        this.lostDamage += damage - 1;
                    }
                    else
                    {
                        this.lostDamage += (damage - 1) * (damage - 1);
                    }
                }
                return;
            }

            if (m.cantLowerHPbelowONE && damage >= 1 && damage >= m.Hp) damage = m.Hp - 1;

            if (!own && !dontCalcLostDmg && m.Hp < damage)
            {
                if (isMinionattack)
                {
                    this.lostDamage += (damage - m.Hp);
                }
                else
                {
                    this.lostDamage += (damage - m.Hp) * (damage - m.Hp);
                }
            }

            int hpcopy = m.Hp;

            if (damage >= 1)
            {
                m.Hp = m.Hp - damage;
            }

            if (heal >= 1)
            {
                if (own && !dontCalcLostDmg && heal <= 999 && m.Hp + heal > m.maxHp) this.lostHeal += m.Hp + heal - m.maxHp;

                m.Hp = m.Hp + Math.Min(heal, m.maxHp - m.Hp);
            }



            if (m.Hp > hpcopy)
            {
                //minionWasHealed
                triggerAMinionGetHealed(m, own);
            }

            if (m.Hp < hpcopy)
            {
                triggerAMinionGetDamage(m, own);
            }

            if (m.maxHp == m.Hp)
            {
                m.wounded = false;
            }
            else
            {
                m.wounded = true;
            }

            this.wutanfall(m, woundedbefore, own);

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }


            if (m.Hp <= 0)
            {
                if (own)
                {
                    this.removeMinionFromList(m, this.ownMinions, true);
                    if (logging) Helpfunctions.Instance.logg("own " + m.name + " died");
                }
                else
                {
                    this.removeMinionFromList(m, this.enemyMinions, false);
                    if (logging) Helpfunctions.Instance.logg("enemy " + m.name + " died");
                }
            }
        }

        private void copyMinion(Minion target, Minion source)
        {
            target.name = source.name;
            target.Angr = source.Angr;
            target.handcard.card = CardDB.Instance.getCardDataFromID(source.handcard.card.cardIDenum);
            target.charge = source.charge;
            target.divineshild = source.divineshild;
            target.exhausted = source.exhausted;
            target.frozen = source.frozen;
            target.Hp = source.Hp;
            target.immune = source.immune;
            target.maxHp = source.maxHp;
            target.playedThisTurn = source.playedThisTurn;
            target.poisonous = source.poisonous;
            target.silenced = source.silenced;
            target.stealth = source.stealth;
            target.taunt = source.taunt;
            target.windfury = source.windfury;
            target.wounded = source.wounded;
            target.Ready = false;
            if (target.charge) target.Ready = true;
            foreach (Enchantment e in source.enchantments)
            {
                Enchantment ne = CardDB.getEnchantmentFromCardID(e.CARDID);
                target.enchantments.Add(ne);
            }
        }

        private void removeMinionFromListNoDeath(Minion m, List<Minion> l, bool own)
        {
            l.Remove(m);
            int i = 0;
            foreach (Minion mnn in l)
            {
                mnn.id = i;
                mnn.zonepos = i + 1;
                i++;
            }
            this.endEffectsDueToDeath(m, own);
            adjacentBuffUpdate(own);
        }

        private void removeMinionFromList(Minion m, List<Minion> l, bool own)
        {
            l.Remove(m);
            int i = 0;
            foreach (Minion mnn in l)
            {
                mnn.id = i;
                mnn.zonepos = i + 1;
                i++;
            }

            this.endEffectsDueToDeath(m, own);
            this.deathrattle(m, own);
            if (own)
            {
                if (this.ownBaronRivendare && m.name != CardDB.cardName.baronrivendare) this.deathrattle(m, own);
            }
            else
            {
                if (this.enemyBaronRivendare && m.name != CardDB.cardName.baronrivendare) this.deathrattle(m, own);
            }
            this.triggerAMinionDied(m, own);
            adjacentBuffUpdate(own);

        }

        private void attack(int attacker, int target, bool dontcount)
        {
            Minion m = new Minion();
            bool attackOwn = true;
            if (attacker < 10)
            {
                m = this.ownMinions[attacker];
                attackOwn = true;
            }
            if (attacker >= 10 && attacker < 20)
            {
                m = this.enemyMinions[attacker - 10];
                attackOwn = false;
            }

            if (!dontcount)
            {
                m.numAttacksThisTurn++;
                m.stealth = false;
                if (m.windfury && m.numAttacksThisTurn == 2)
                {
                    m.Ready = false;
                }
                if (!m.windfury)
                {
                    m.Ready = false;
                }
            }

            if (logging) Helpfunctions.Instance.logg(".attck with" + m.name + " A " + m.Angr + " H " + m.Hp);

            if (target == 200)//target is hero
            {
                int oldhp = this.ownHeroHp;
                attackOrHealHero(m.Angr, false);
                if (oldhp > this.ownHeroHp)
                {
                    if (!m.silenced && m.handcard.card.name == CardDB.cardName.waterelemental) this.ownHeroFrozen = true;
                }
                return;
            }

            bool enemyOwn = false;
            Minion enemy = new Minion();
            if (target < 10)
            {
                enemy = this.ownMinions[target];
                enemyOwn = true;
            }

            if (target >= 10 && target < 20)
            {
                enemy = this.enemyMinions[target - 10];
                enemyOwn = false;
            }




            int ownAttack = m.Angr;
            int enemyAttack = enemy.Angr;
            // defender take damage
            if (m.handcard.card.poisionous)
            {
                minionGetDestroyed(enemy, enemyOwn);
            }
            else
            {
                int oldHP = enemy.Hp;
                minionGetDamagedOrHealed(enemy, ownAttack, 0, enemyOwn, false, true);
                if (!m.silenced && oldHP > enemy.Hp && m.handcard.card.name == CardDB.cardName.waterelemental) enemy.frozen = true;
            }


            //attacker take damage
            if (!m.immune && !dontcount)
            {
                if (enemy.handcard.card.poisionous)
                {
                    minionGetDestroyed(m, attackOwn);
                }
                else
                {
                    int oldHP = m.Hp;
                    minionGetDamagedOrHealed(m, enemyAttack, 0, attackOwn, false, true);
                    if (!enemy.silenced && oldHP > m.Hp && enemy.handcard.card.name == CardDB.cardName.waterelemental) m.frozen = true;
                }
            }
        }

        public void attackWithMinion(Minion ownMinion, int target, int targetEntity, int penality)
        {
            this.evaluatePenality += penality;
            Action a = new Action();
            a.minionplay = true;
            a.owntarget = ownMinion.id;
            a.ownEntitiy = ownMinion.entitiyID;
            a.enemytarget = target;
            a.enemyEntitiy = targetEntity;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;
            this.playactions.Add(a);
            if (logging) Helpfunctions.Instance.logg("attck with" + ownMinion.name + " " + ownMinion.id + " trgt " + target + " A " + ownMinion.Angr + " H " + ownMinion.Hp);


            attack(ownMinion.id, target, false);

            //draw a card if the minion has enchantment from: Segen der weisheit 
            int segenderweisheitAnz = 0;
            int segenderweisheitAnzEnemy = 0;
            foreach (Enchantment e in ownMinion.enchantments)
            {
                if (e.CARDID == CardDB.cardIDEnum.EX1_363e2)
                {
                    if (e.controllerOfCreator == this.ownController)
                    {
                        segenderweisheitAnz++;
                    }
                    else
                    {
                        segenderweisheitAnzEnemy++;
                    }
                }
            }
            for (int i = 0; i < segenderweisheitAnz; i++)
            {
                this.drawACard(CardDB.cardName.unknown, true);
            }
            for (int i = 0; i < segenderweisheitAnzEnemy; i++)
            {
                this.drawACard(CardDB.cardName.unknown, false);
            }
        }

        public void ENEMYattackWithMinion(Minion ownMinion, int target, int targetEntity)
        {

            if (logging) Helpfunctions.Instance.logg("ennemy attck with" + ownMinion.name + " " + ownMinion.id + " trgt " + target + " A " + ownMinion.Angr + " H " + ownMinion.Hp);
            attack(ownMinion.id + 10, target, false);
            //draw a card if the minion has enchantment from: Segen der weisheit 
            int segenderweisheitAnz = 0;
            int segenderweisheitAnzEnemy = 0;
            foreach (Enchantment e in ownMinion.enchantments)
            {
                if (e.CARDID == CardDB.cardIDEnum.EX1_363e2)
                {
                    if (e.controllerOfCreator == this.ownController)
                    {
                        segenderweisheitAnz++;
                    }
                    else
                    {
                        segenderweisheitAnzEnemy++;
                    }
                }
            }
            for (int i = 0; i < segenderweisheitAnz; i++)
            {
                this.drawACard(CardDB.cardName.unknown, true);
            }
            for (int i = 0; i < segenderweisheitAnzEnemy; i++)
            {
                this.drawACard(CardDB.cardName.unknown, false);
            }
        }

        private void addMiniontoList(Minion m, List<Minion> l, int pos, bool own)
        {
            List<Minion> newmins = new List<Minion>(l);
            l.Clear();

            int i = 0;
            foreach (Minion mnn in newmins)
            {

                if (pos == i)
                {
                    m.id = i;
                    m.zonepos = i + 1;
                    l.Add(m);
                    i++;
                }
                mnn.id = i;
                mnn.zonepos = i + 1;
                l.Add(mnn);
                i++;
            }
            // maybe he is last mob
            if (pos == i)
            {
                m.id = i;
                m.zonepos = i + 1;
                l.Add(m);
                i++;
            }
            adjacentBuffUpdate(own);
            triggerPlayedAMinion(m.handcard, own);

        }

        private Minion createNewMinion(Handmanager.Handcard hc, int placeOfNewMob, bool own)
        {
            Minion m = new Minion();
            m.handcard = new Handmanager.Handcard(hc);
            m.entitiyID = hc.entity;
            m.Posix = 0;
            m.Posiy = 0;
            m.Angr = hc.card.Attack;
            m.Hp = hc.card.Health;
            m.maxHp = hc.card.Health;
            m.name = hc.card.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.id = placeOfNewMob;
            m.zonepos = placeOfNewMob + 1;


            if (hc.card.windfury) m.windfury = true;
            if (hc.card.tank) m.taunt = true;
            if (hc.card.Charge)
            {
                m.Ready = true;
                m.charge = true;
            }
            if (hc.card.Shield) m.divineshild = true;
            if (hc.card.poisionous) m.poisonous = true;

            if (hc.card.Stealth) m.stealth = true;

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }

            this.getNewEffects(m, own, placeOfNewMob, true);

            return m;
        }

        private void doBattleCryWithTargeting(Minion c, int target, int choice)
        {

            //target is the target AFTER spawning mobs
            int attackbuff = 0;
            int hpbuff = 0;
            int heal = 0;
            int damage = 0;
            bool spott = false;
            bool divineshild = false;
            bool windfury = false;
            bool silence = false;
            bool destroy = false;
            bool frozen = false;
            bool stealth = false;
            bool backtohand = false;
            int backtoHandManaChange = 0;

            bool own = true;

            if (target >= 10 && target < 20)
            {
                own = false;
            }
            Minion m = new Minion();
            if (target < 10)
            {
                m = this.ownMinions[target];
            }
            if (target >= 10 && target < 20)
            {
                m = this.enemyMinions[target - 10];
            }


            if (c.name == CardDB.cardName.ancientoflore)
            {
                if (choice == 2)
                {
                    heal = 5;
                }
            }


            if (c.name == CardDB.cardName.keeperofthegrove)
            {
                if (choice == 1)
                {
                    damage = 2;
                }

                if (choice == 2)
                {
                    silence = true;
                }
            }

            if (c.name == CardDB.cardName.crazedalchemist)
            {
                if (target < 10)
                {
                    bool woundedbef = m.wounded;
                    int temp = m.Angr;
                    m.Angr = m.Hp;
                    m.Hp = temp;
                    m.maxHp = temp;
                    m.wounded = false;
                    wutanfall(m, woundedbef, true);
                    if (m.Hp <= 0) minionGetDestroyed(m, true);
                }

                if (target >= 10 && target < 20)
                {
                    bool woundedbef = m.wounded;
                    int temp = m.Angr;
                    m.Angr = m.Hp;
                    m.Hp = temp;
                    m.maxHp = temp;
                    m.wounded = false;
                    wutanfall(m, woundedbef, false);
                    if (m.Hp <= 0) minionGetDestroyed(m, false);
                }

            }

            if (c.name == CardDB.cardName.si7agent && this.cardsPlayedThisTurn >= 1)
            {
                damage = 2;
            }
            if (c.name == CardDB.cardName.kidnapper && this.cardsPlayedThisTurn >= 1)
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }
            if (c.name == CardDB.cardName.masterofdisguise)
            {
                stealth = true;
            }

            if (c.name == CardDB.cardName.cabalshadowpriest)
            {
                minionGetControlled(m, true, false);
            }


            if (c.name == CardDB.cardName.ironbeakowl || c.name == CardDB.cardName.spellbreaker) //eisenschnabeleule, zauberbrecher
            {
                silence = true;
            }

            if (c.name == CardDB.cardName.shatteredsuncleric)
            {
                attackbuff = 1;
                hpbuff = 1;
            }

            if (c.name == CardDB.cardName.ancientbrewmaster)
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }
            if (c.name == CardDB.cardName.youthfulbrewmaster)
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }

            if (c.name == CardDB.cardName.darkirondwarf)
            {
                //attackbuff = 2;
                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_046e);
                e.creator = c.entitiyID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
            }

            if (c.name == CardDB.cardName.hungrycrab)
            {
                destroy = true;
                /*Enchantment e = CardDB.getEnchantmentFromCardID("NEW1_017e");
                e.creator = c.entitiyID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(c, e, true);//buff own hungrige krabbe*/
                minionGetBuffed(c, 2, 2, true);
            }

            if (c.name == CardDB.cardName.abusivesergeant)
            {
                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.CS2_188o);
                e.creator = c.entitiyID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
            }
            if (c.name == CardDB.cardName.crueltaskmaster)
            {
                attackbuff = 2;
                damage = 1;
            }

            if (c.name == CardDB.cardName.frostelemental)
            {
                frozen = true;
            }

            if (c.name == CardDB.cardName.elvenarcher)
            {
                damage = 1;
            }
            if (c.name == CardDB.cardName.voodoodoctor)
            {
                if (this.auchenaiseelenpriesterin)
                { damage = 2; }
                else { heal = 2; }
            }
            if (c.name == CardDB.cardName.templeenforcer)
            {
                hpbuff = 3;
            }
            if (c.name == CardDB.cardName.ironforgerifleman)
            {
                damage = 1;
            }
            if (c.name == CardDB.cardName.stormpikecommando)
            {
                damage = 2;
            }
            if (c.name == CardDB.cardName.houndmaster)
            {
                attackbuff = 2;
                hpbuff = 2;
                spott = true;
            }

            if (c.name == CardDB.cardName.aldorpeacekeeper)
            {
                attackbuff = 1 - m.Angr;
            }

            if (c.name == CardDB.cardName.theblackknight)
            {
                destroy = true;
            }

            if (c.name == CardDB.cardName.argentprotector)
            {
                divineshild = true; // Grants NO buff
            }

            if (c.name == CardDB.cardName.windspeaker)
            {
                windfury = true;
            }
            if (c.name == CardDB.cardName.fireelemental)
            {
                damage = 3;
            }
            if (c.name == CardDB.cardName.earthenringfarseer)
            {
                if (this.auchenaiseelenpriesterin)
                { damage = 3; }
                else { heal = 3; }
            }
            if (c.name == CardDB.cardName.biggamehunter)
            {
                destroy = true;
            }

            if (c.name == CardDB.cardName.alexstrasza)
            {
                if (target == 100)
                {
                    this.ownHeroHp = 15;

                }
                if (target == 200)
                {
                    this.enemyHeroHp = 15;
                }
            }

            if (c.name == CardDB.cardName.facelessmanipulator)
            {//todo, test this :D

                copyMinion(c, m);
            }

            //make effect on target
            //ownminion
            if (target < 10)
            {
                if (attackbuff != 0 || hpbuff != 0)
                {
                    minionGetBuffed(m, attackbuff, hpbuff, true);
                }
                if (damage != 0 || heal != 0)
                {
                    minionGetDamagedOrHealed(m, damage, heal, true);
                }
                if (spott) m.taunt = true;
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, true);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, true, backtoHandManaChange);
                if (silence) minionGetSilenced(m, true);

            }
            //enemyminion
            if (target >= 10 && target < 20)
            {
                if (attackbuff != 0 || hpbuff != 0)
                {
                    minionGetBuffed(m, attackbuff, hpbuff, false);
                }
                if (damage != 0 || heal != 0)
                {
                    minionGetDamagedOrHealed(m, damage, heal, false);
                }
                if (spott) m.taunt = true;
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, false);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, false, backtoHandManaChange);
                if (silence) minionGetSilenced(m, false);
            }
            if (target == 100)
            {
                if (frozen) this.ownHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, true);
                if (heal >= 1) attackOrHealHero(-heal, true);
            }
            if (target == 200)
            {
                if (frozen) this.enemyHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, false);
                if (heal >= 1) attackOrHealHero(-heal, false);
            }

        }

        private void doBattleCryWithoutTargeting(Minion c, int position, bool own, int choice)
        {
            //only nontargetable battlecrys!

            //druid choices

            //urtum des krieges:
            if (c.name == CardDB.cardName.ancientofwar)
            {
                if (choice == 1)
                {
                    minionGetBuffed(c, 5, 0, true);
                }
                if (choice == 2)
                {
                    minionGetBuffed(c, 0, 5, true);
                    c.taunt = true;
                }
            }

            if (c.name == CardDB.cardName.ancientoflore)
            {
                if (choice == 1)
                {
                    //this.owncarddraw += 2;
                    this.drawACard(CardDB.cardName.unknown, own);
                    this.drawACard(CardDB.cardName.unknown, own);
                }

            }

            if (c.name == CardDB.cardName.druidoftheclaw)
            {
                if (choice == 1)
                {
                    minionGetCharge(c);
                }
                if (choice == 2)
                {
                    minionGetBuffed(c, 0, 2, true);
                    c.taunt = true;
                }
            }

            if (c.name == CardDB.cardName.cenarius)
            {
                if (choice == 1)
                {
                    foreach (Minion m in this.ownMinions)
                    {
                        minionGetBuffed(m, 2, 2, true);
                    }
                }
                //choice 2 = spawn 2 kids
            }

            //normal ones

            if (c.name == CardDB.cardName.mindcontroltech)
            {
                if (this.enemyMinions.Count >= 4)
                {
                    List<Minion> temp = new List<Minion>();

                    List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                    temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));//we take the weekest

                    temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                    Minion target = new Minion();
                    target = temp[0];
                    if (target.taunt && !temp[1].taunt) target = temp[1];
                    minionGetControlled(target, true, false);

                }
            }

            if (c.name == CardDB.cardName.felguard)
            {
                this.ownMaxMana--;
            }
            if (c.name == CardDB.cardName.arcanegolem)
            {
                this.enemyMaxMana++;
            }

            if (c.name == CardDB.cardName.edwinvancleef && this.cardsPlayedThisTurn >= 1)
            {
                minionGetBuffed(c, this.cardsPlayedThisTurn * 2, this.cardsPlayedThisTurn * 2, own);
            }

            if (c.name == CardDB.cardName.doomguard)
            {
                this.owncarddraw -= Math.Min(2, this.owncards.Count);
                this.owncards.RemoveRange(0, Math.Min(2, this.owncards.Count));
            }

            if (c.name == CardDB.cardName.succubus)
            {
                this.owncarddraw -= Math.Min(1, this.owncards.Count);
                this.owncards.RemoveRange(0, Math.Min(1, this.owncards.Count));
            }

            if (c.name == CardDB.cardName.lordjaraxxus)
            {
                this.ownHeroAblility = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk33);
                this.ownHeroName = HeroEnum.lordjaraxxus;
                this.ownHeroHp = c.Hp;
            }

            if (c.name == CardDB.cardName.flameimp)
            {
                attackOrHealHero(3, own);
            }

            if (c.name == CardDB.cardName.pitlord)
            {
                attackOrHealHero(5, own);
            }

            if (c.name == CardDB.cardName.voidterror)
            {
                List<Minion> temp = new List<Minion>();
                if (own)
                {
                    temp.AddRange(this.ownMinions);
                }
                else
                {
                    temp.AddRange(this.enemyMinions);
                }

                int angr = 0;
                int hp = 0;
                foreach (Minion m in temp)
                {
                    if (m.id == position || m.id == position - 1)
                    {
                        angr += m.Angr;
                        hp += m.Hp;
                    }
                }
                foreach (Minion m in temp)
                {
                    if (m.id == position || m.id == position - 1)
                    {
                        minionGetDestroyed(m, own);
                    }
                }
                minionGetBuffed(c, angr, hp, own);

            }

            if (c.name == CardDB.cardName.frostwolfwarlord)
            {
                minionGetBuffed(c, this.ownMinions.Count, this.ownMinions.Count, own);
            }
            if (c.name == CardDB.cardName.bloodsailraider)
            {
                c.Angr += this.ownWeaponAttack;
            }

            if (c.name == CardDB.cardName.southseadeckhand && this.ownWeaponDurability >= 1)
            {
                minionGetCharge(c);
            }



            if (c.name == CardDB.cardName.bloodknight)
            {
                int shilds = 0;
                foreach (Minion m in this.ownMinions)
                {
                    if (m.divineshild)
                    {
                        m.divineshild = false;
                        shilds++;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.divineshild)
                    {
                        m.divineshild = false;
                        shilds++;
                    }
                }
                minionGetBuffed(c, 3 * shilds, 3 * shilds, own);

            }

            if (c.name == CardDB.cardName.kingmukla)
            {
                this.enemycarddraw += 2;
            }

            if (c.name == CardDB.cardName.coldlightoracle)
            {
                //this.enemycarddraw += 2;
                //this.owncarddraw += 2;
                this.drawACard(CardDB.cardName.unknown, true);
                this.drawACard(CardDB.cardName.unknown, true);
                this.drawACard(CardDB.cardName.unknown, false);
                this.drawACard(CardDB.cardName.unknown, false);
            }

            if (c.name == CardDB.cardName.arathiweaponsmith)
            {
                CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_398t);//battleaxe
                this.equipWeapon(wcard);


            }
            if (c.name == CardDB.cardName.bloodsailcorsair)
            {
                this.lowerWeaponDurability(1, false);
            }

            if (c.name == CardDB.cardName.acidicswampooze)
            {
                this.lowerWeaponDurability(1000, false);
            }
            if (c.name == CardDB.cardName.noviceengineer)
            {
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
            }
            if (c.name == CardDB.cardName.gnomishinventor)
            {
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
            }

            if (c.name == CardDB.cardName.darkscalehealer)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {

                    if (this.auchenaiseelenpriesterin)
                    { minionGetDamagedOrHealed(m, 2, 0, true); }
                    else { minionGetDamagedOrHealed(m, 0, 2, true); }

                }
                if (this.auchenaiseelenpriesterin)
                { attackOrHealHero(2, true); }
                else { attackOrHealHero(-2, true); }

            }
            if (c.name == CardDB.cardName.nightblade)
            {
                attackOrHealHero(3, !own);
            }

            if (c.name == CardDB.cardName.twilightdrake)
            {
                minionGetBuffed(c, 0, this.owncards.Count, true);
            }

            if (c.name == CardDB.cardName.azuredrake)
            {
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
            }

            if (c.name == CardDB.cardName.harrisonjones)
            {
                this.enemyWeaponAttack = 0;
                //this.owncarddraw += enemyWeaponDurability;
                for (int i = 0; i < enemyWeaponDurability; i++)
                {
                    drawACard(CardDB.cardName.unknown, true);
                }
                this.enemyWeaponDurability = 0;
            }

            if (c.name == CardDB.cardName.guardianofkings)
            {
                attackOrHealHero(-6, true);
            }

            if (c.name == CardDB.cardName.captaingreenskin)
            {
                if (this.ownWeaponName != CardDB.cardName.unknown)
                {
                    this.ownheroAngr += 1;
                    this.ownWeaponAttack++;
                    this.ownWeaponDurability++;
                }
            }

            if (c.name == CardDB.cardName.priestessofelune)
            {
                attackOrHealHero(-4, true);
            }
            if (c.name == CardDB.cardName.injuredblademaster)
            {
                minionGetDamagedOrHealed(c, 4, 0, true);
            }

            if (c.name == CardDB.cardName.dreadinfernal)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    minionGetDamagedOrHealed(m, 1, 0, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion m in temp)
                {
                    minionGetDamagedOrHealed(m, 1, 0, false);
                }
                attackOrHealHero(1, false);
                attackOrHealHero(1, true);
            }

            if (c.name == CardDB.cardName.madbomber)
            {

                for (int i = 0; i < 3; i++)
                {
                    if (this.ownHeroHp <= 3)
                    {
                        attackOrHealHero(1, true);
                        continue;
                    }
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.AddRange(this.enemyMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//destroys the weakest

                    foreach (Minion m in temp)
                    {
                        bool target = true;
                        if (m.id >= 10) target = false;
                        minionGetDamagedOrHealed(m, 1, 0, target);
                        break;
                    }
                    attackOrHealHero(1, false);
                }
            }

            if (c.name == CardDB.cardName.tinkmasteroverspark)
            {
                int oc = this.ownMinions.Count;
                int ec = this.enemyMinions.Count;
                if (oc == 0 && ec == 0) return;
                if (oc > ec)
                {
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.AddRange(this.enemyMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//transform the weakest
                    foreach (Minion m in temp)
                    {
                        minionTransform(m, CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk29), true);
                        break;
                    }
                }
                else
                {
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.AddRange(this.enemyMinions);
                    temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//transform the strongest
                    foreach (Minion m in temp)
                    {
                        minionTransform(m, CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk28), true);
                        break;
                    }
                }
            }

            if (c.name == CardDB.cardName.tundrarhino)
            {
                minionGetCharge(c);
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                    {
                        minionGetCharge(m);
                    }
                }
            }

            if (c.name == CardDB.cardName.stampedingkodo)
            {
                List<Minion> temp = new List<Minion>();
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//destroys the weakest
                temp.AddRange(temp2);
                foreach (Minion enemy in temp)
                {
                    if (enemy.Angr <= 2)
                    {
                        minionGetDestroyed(enemy, false);
                        break;
                    }
                }
            }

            if (c.name == CardDB.cardName.sunfuryprotector)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.id == position - 1 || m.id == position)
                    {
                        m.taunt = true;
                    }
                }
            }

            if (c.name == CardDB.cardName.ancientmage)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.id == position - 1 || m.id == position)
                    {
                        m.handcard.card.spellpowervalue++;
                    }
                }
            }

            if (c.name == CardDB.cardName.defenderofargus)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.id == position - 1 || m.id == position)//position and position -1 because its not placed jet
                    {
                        Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_093e);
                        e.creator = c.entitiyID;
                        e.controllerOfCreator = this.ownController;
                        addEffectToMinionNoDoubles(m, e, own);
                    }
                }
            }

            if (c.name == CardDB.cardName.coldlightseer)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC)
                    {
                        minionGetBuffed(m, 0, 2, true);
                    }
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC)
                    {
                        minionGetBuffed(m, 0, 2, false);
                    }
                }
            }

            if (c.name == CardDB.cardName.deathwing)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, false);
                }
                this.owncards.Clear();
                this.owncarddraw = 0;
                this.enemyAnzCards = 0;
                this.enemycarddraw = 0;

            }

            if (c.name == CardDB.cardName.captainsparrot)
            {
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);

            }
            if (c.name == CardDB.cardName.wailingsoul)
            {
                //this.owncarddraw++;
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    minionGetSilenced(m, true);
                }

            }



        }

        private int spawnKids(CardDB.Card c, int position, bool own, int choice)
        {
            int kids = 0;
            if (c.name == CardDB.cardName.murloctidehunter)
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_506a);//murlocscout
                callKid(kid, position, own, true);

            }
            if (c.name == CardDB.cardName.razorfenhunter)
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_boar);//boar
                callKid(kid, position, own, true);

            }
            if (c.name == CardDB.cardName.dragonlingmechanic)
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_025t);//mechanicaldragonling
                callKid(kid, position, own, true);

            }
            if (c.name == CardDB.cardName.leeroyjenkins)
            {
                kids = 2;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_116t);//whelp
                int pos = this.ownMinions.Count - 1;
                if (own) pos = this.enemyMinions.Count - 1;
                callKid(kid, pos, !own);
                callKid(kid, pos, !own);

            }

            if (c.name == CardDB.cardName.cenarius && choice == 2)
            {
                kids = 2;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_573t); //special treant
                int pos = this.ownMinions.Count - 1;
                if (!own) pos = this.enemyMinions.Count - 1;
                callKid(kid, pos, own, true);
                callKid(kid, pos, own, true);

            }
            if (c.name == CardDB.cardName.silverhandknight)
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_152);//squire
                callKid(kid, position, own, true);

            }
            if (c.name == CardDB.cardName.gelbinmekkatorque)
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka1);//homingchicken
                callKid(kid, position, own, true);

            }

            if (c.name == CardDB.cardName.defiasringleader && this.cardsPlayedThisTurn >= 1) //needs combo for spawn
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_131t);//defiasbandit
                callKid(kid, position, own, true);

            }
            if (c.name == CardDB.cardName.onyxia)
            {
                kids = 7 - this.ownMinions.Count;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_116t);//whelp
                for (int i = 0; i < kids; i++)
                {
                    callKid(kid, position, own, true);
                }

            }
            return kids;
        }

        private void callKid(CardDB.Card c, int placeoffather, bool own, bool spawnKid = false)
        {
            if (own)
            {
                if (!spawnKid && this.ownMinions.Count >= 7) return;
                if (spawnKid && this.ownMinions.Count >= 6)
                {
                    this.evaluatePenality += 20;
                    return;
                }
            }
            if (!own && this.enemyMinions.Count >= 7) return;
            int mobplace = placeoffather + 1;
            /*if (own && this.ownMinions.Count >= 1)
            {
                retval.X = ownMinions[mobplace - 1].Posix + 85;
                retval.Y = ownMinions[mobplace - 1].Posiy;
            }
            if (!own && this.enemyMinions.Count >= 1)
            {
                retval.X = enemyMinions[mobplace - 1].Posix + 85;
                retval.Y = enemyMinions[mobplace - 1].Posiy;
            }*/

            Minion m = createNewMinion(new Handmanager.Handcard(c), mobplace, own);

            if (own)
            {
                addMiniontoList(m, this.ownMinions, mobplace, own);// additional minions span next to it!
            }
            else
            {
                addMiniontoList(m, this.enemyMinions, mobplace, own);// additional minions span next to it!
            }

        }

        private Action placeAmobSomewhere(Handmanager.Handcard hc, int cardpos, int target, int choice, int placepos)
        {

            Action a = new Action();
            a.cardplay = true;
            //a.card = new CardDB.Card(c);
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;

            //we place him on the right!
            int mobplace = placepos;


            //create the minion out of the card + effects from other minions, which higher his hp/angr


            // but before additional minions span next to it! (because we buff the minion in createNewMinion and swordofjustice gives summeond minons his buff first!
            int spawnkids = spawnKids(hc.card, mobplace - 1, true, choice); //  if a mob targets something, it doesnt spawn minions!?


            //create the new minion
            Minion m = createNewMinion(hc, mobplace, true);




            //do the battlecry (where you dont need a target)
            doBattleCryWithoutTargeting(m, mobplace, true, choice);
            if (target >= 0)
            {
                doBattleCryWithTargeting(m, target, choice);

            }


            addMiniontoList(m, this.ownMinions, mobplace, true);
            if (logging) Helpfunctions.Instance.logg("added " + m.handcard.card.name);

            //only for fun :D
            if (target >= 0)
            {
                // the OWNtargets right of the placed mobs are going up :D
                if (target < 10 && target > mobplace + spawnkids) target++;
            }

            a.enemytarget = target;
            a.owntarget = mobplace + 1; //1==before the 1.minion on board , 2 ==before the 2. minion o board (from left)
            return a;
        }

        private void lowerWeaponDurability(int value, bool own)
        {
            if (own)
            {
                this.ownWeaponDurability -= value;
                if (this.ownWeaponDurability <= 0)
                {
                    //deathrattle deathsbite
                    if (this.ownWeaponName == CardDB.cardName.deathsbite)
                    {
                        int anz = 1;
                        if (this.ownBaronRivendare) anz = 2;
                        for (int i = 0; i < anz; i++)
                        {
                            int dmg = getSpellDamageDamage(1);
                            List<Minion> temp = new List<Minion>(this.ownMinions);
                            foreach (Minion m in temp)
                            {
                                minionGetDamagedOrHealed(m, 1, 0, true);
                            }
                            temp.Clear();
                            temp.AddRange(this.enemyMinions);
                            foreach (Minion m in temp)
                            {
                                minionGetDamagedOrHealed(m, 1, 0, false);
                            }
                        }

                    }


                    this.ownheroAngr -= this.ownWeaponAttack;
                    this.ownWeaponDurability = 0;
                    this.ownWeaponAttack = 0;
                    this.ownWeaponName = CardDB.cardName.unknown;

                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.playedThisTurn && m.name == CardDB.cardName.southseadeckhand)
                        {
                            m.Ready = false;
                            m.charge = false;
                        }
                    }
                }
            }
            else
            {
                this.enemyWeaponDurability -= value;
                if (this.enemyWeaponDurability <= 0)
                {
                    //deathrattle deathsbite
                    if (this.enemyWeaponName == CardDB.cardName.deathsbite)
                    {
                        int anz = 1;
                        if (this.enemyBaronRivendare) anz = 2;
                        for (int i = 0; i < anz; i++)
                        {
                            int dmg = getSpellDamageDamage(1);
                            List<Minion> temp = new List<Minion>(this.ownMinions);
                            foreach (Minion m in temp)
                            {
                                minionGetDamagedOrHealed(m, 1, 0, true);
                            }
                            temp.Clear();
                            temp.AddRange(this.enemyMinions);
                            foreach (Minion m in temp)
                            {
                                minionGetDamagedOrHealed(m, 1, 0, false);
                            }
                        }

                    }

                    this.enemyheroAngr -= this.enemyWeaponAttack;
                    this.enemyWeaponDurability = 0;
                    this.enemyWeaponAttack = 0;
                    this.enemyWeaponName = CardDB.cardName.unknown;
                }
            }
        }


        private void equipWeapon(CardDB.Card c)
        {
            if (this.ownWeaponDurability >= 1)
            {
                this.lostWeaponDamage += this.ownWeaponDurability * this.ownWeaponAttack * this.ownWeaponAttack;
                this.lowerWeaponDurability(1000, true);
            }

            this.ownheroAngr = c.Attack;
            this.ownWeaponAttack = c.Attack;
            this.ownWeaponDurability = c.Durability;
            this.ownWeaponName = c.name;
            if (c.name == CardDB.cardName.doomhammer)
            {
                this.ownHeroWindfury = true;
            }
            else
            {
                this.ownHeroWindfury = false;
            }
            if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
            {
                this.ownHeroReady = true;
            }
            if (c.name == CardDB.cardName.gladiatorslongbow)
            {
                this.heroImmuneWhileAttacking = true;
            }
            else
            {
                this.heroImmuneWhileAttacking = false;
            }

            foreach (Minion m in this.ownMinions)
            {
                if (m.playedThisTurn && m.name == CardDB.cardName.southseadeckhand)
                {
                    minionGetCharge(m);
                }
            }

        }

        private void playCardWithTarget(Handmanager.Handcard hc, int target, int choice)
        {
            CardDB.Card c = hc.card;
            //play card with target
            int attackbuff = 0;
            int hpbuff = 0;
            int heal = 0;
            int damage = 0;
            bool spott = false;
            bool divineshild = false;
            bool windfury = false;
            bool silence = false;
            bool destroy = false;
            bool frozen = false;
            bool stealth = false;
            bool backtohand = false;
            int backtoHandManaChange = 0;
            bool charge = false;
            bool setHPtoONE = false;
            bool immune = false;
            int adjacentDamage = 0;
            bool sheep = false;
            bool frogg = false;
            //special
            bool geistderahnen = false;
            bool ueberwaeltigendemacht = false;

            bool own = true;

            if (target >= 10 && target < 20)
            {
                own = false;
            }
            Minion m = new Minion();
            if (target < 10)
            {
                m = this.ownMinions[target];
            }
            if (target >= 10 && target < 20)
            {
                m = this.enemyMinions[target - 10];
            }


            //warrior###########################################################################

            if (c.name == CardDB.cardName.execute)
            {
                destroy = true;
            }

            if (c.name == CardDB.cardName.innerrage)
            {
                damage = 1;
                attackbuff = 2;
            }

            if (c.name == CardDB.cardName.slam)
            {
                damage = 2;
                if (m.Hp >= 3)
                {
                    //this.owncarddraw++;
                    drawACard(CardDB.cardName.unknown, true);
                }
            }

            if (c.name == CardDB.cardName.mortalstrike)
            {
                damage = 4;
                if (ownHeroHp <= 12) damage = 6;
            }

            if (c.name == CardDB.cardName.shieldslam)
            {
                damage = this.ownHeroDefence;
            }

            if (c.name == CardDB.cardName.charge)
            {
                charge = true;
                attackbuff = 2;
            }

            if (c.name == CardDB.cardName.rampage)
            {
                attackbuff = 3;
                hpbuff = 3;
            }

            //hunter#################################################################################

            if (c.name == CardDB.cardName.huntersmark)
            {
                setHPtoONE = true;
            }
            if (c.name == CardDB.cardName.arcaneshot)
            {
                damage = 2;
            }
            if (c.name == CardDB.cardName.killcommand)
            {
                damage = 3;
                foreach (Minion mnn in this.ownMinions)
                {
                    if ((TAG_RACE)mnn.handcard.card.race == TAG_RACE.PET)
                    {
                        damage = 5;
                    }
                }
            }
            if (c.name == CardDB.cardName.bestialwrath)
            {

                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_549o);
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
            }

            if (c.name == CardDB.cardName.explosiveshot)
            {
                damage = 5;
                adjacentDamage = 2;
            }

            //mage###############################################################################

            if (c.name == CardDB.cardName.icelance)
            {
                if (target >= 0 && target <= 19)
                {
                    if (m.frozen)
                    {
                        damage = 4;
                    }
                    else { frozen = true; }
                }
                else
                {
                    if (target == 100)
                    {
                        if (this.ownHeroFrozen)
                        {
                            damage = 4;
                        }
                        else
                        {
                            frozen = true;
                        }
                    }
                    if (target == 200)
                    {
                        if (this.enemyHeroFrozen)
                        {
                            damage = 4;
                        }
                        else
                        {
                            frozen = true;
                        }
                    }
                }
            }

            if (c.name == CardDB.cardName.coneofcold)
            {
                damage = 1;
                adjacentDamage = 1;
                frozen = true;
            }
            if (c.name == CardDB.cardName.fireball)
            {
                damage = 6;
            }
            if (c.name == CardDB.cardName.polymorph)
            {
                sheep = true;
            }

            if (c.name == CardDB.cardName.pyroblast)
            {
                damage = 10;
            }

            if (c.name == CardDB.cardName.frostbolt)
            {
                damage = 3;
                frozen = true;
            }

            //pala######################################################################

            if (c.name == CardDB.cardName.humility)
            {
                m.Angr = 1;
            }
            if (c.name == CardDB.cardName.handofprotection)
            {
                divineshild = true;
            }
            if (c.name == CardDB.cardName.blessingofmight)
            {
                attackbuff = 3;
            }
            if (c.name == CardDB.cardName.holylight)
            {
                heal = 6;
            }

            if (c.name == CardDB.cardName.hammerofwrath)
            {
                damage = 3;
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
            }

            if (c.name == CardDB.cardName.blessingofkings)
            {
                attackbuff = 4;
                hpbuff = 4;
            }

            if (c.name == CardDB.cardName.blessingofwisdom)
            {
                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_363e2);
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                m.enchantments.Add(e);
            }

            if (c.name == CardDB.cardName.blessedchampion)
            {
                m.Angr *= 2;
            }
            if (c.name == CardDB.cardName.holywrath)
            {
                damage = 3;
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
            }
            if (c.name == CardDB.cardName.layonhands)
            {
                for (int i = 0; i < 3; i++)
                {
                    //this.owncarddraw++;
                    drawACard(CardDB.cardName.unknown, true);
                }
                heal = 8;
            }

            //priest ##########################################

            if (c.name == CardDB.cardName.shadowmadness)
            {

                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_334e);
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
                this.minionGetControlled(m, true, true);
            }

            if (c.name == CardDB.cardName.mindcontrol)
            {
                this.minionGetControlled(m, true, false);
            }

            if (c.name == CardDB.cardName.holysmite)
            {
                damage = 2;
            }
            if (c.name == CardDB.cardName.powerwordshield)
            {
                hpbuff = 2;
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
            }
            if (c.name == CardDB.cardName.silence)
            {
                silence = true;
            }
            if (c.name == CardDB.cardName.divinespirit)
            {
                hpbuff = m.Hp;
            }
            if (c.name == CardDB.cardName.innerfire)
            {
                m.Angr = m.Hp;
            }
            if (c.name == CardDB.cardName.holyfire)
            {
                damage = 5;
                int ownheal = getSpellHeal(5);
                attackOrHealHero(-ownheal, true);
            }
            if (c.name == CardDB.cardName.shadowwordpain)
            {
                destroy = true;
            }
            if (c.name == CardDB.cardName.shadowworddeath)
            {
                destroy = true;
            }
            //rogue ##########################################
            if (c.name == CardDB.cardName.shadowstep)
            {
                backtohand = true;
                backtoHandManaChange = -2;
                //m.handcard.card.cost = Math.Max(0, m.handcard.card.cost -= 2);
            }
            if (c.name == CardDB.cardName.sap)
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }
            if (c.name == CardDB.cardName.shiv)
            {
                damage = 1;
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
            }
            if (c.name == CardDB.cardName.coldblood)
            {
                attackbuff = 2;
                if (this.cardsPlayedThisTurn >= 1) attackbuff = 4;
            }
            if (c.name == CardDB.cardName.conceal)
            {
                stealth = true;
            }
            if (c.name == CardDB.cardName.eviscerate)
            {
                damage = 2;
                if (this.cardsPlayedThisTurn >= 1) damage = 4;
            }
            if (c.name == CardDB.cardName.betrayal)
            {
                //attack right neightbor
                if (target >= 10 && target < 20 && target < this.enemyMinions.Count + 10 - 1)
                {
                    attack(target, target + 1, true);
                }
                if (target < 10 && target < this.ownMinions.Count - 1)
                {
                    attack(target, target + 1, true);
                }

                //attack left neightbor
                if (target >= 11 || (target < 10 && target >= 1))
                {
                    attack(target, target - 1, true);
                }

            }

            if (c.name == CardDB.cardName.perditionsblade)
            {
                damage = 1;
                if (this.cardsPlayedThisTurn >= 1) damage = 2;
            }

            if (c.name == CardDB.cardName.backstab)
            {
                damage = 2;
            }

            if (c.name == CardDB.cardName.assassinate)
            {
                destroy = true;
            }
            //shaman ##########################################
            if (c.name == CardDB.cardName.lightningbolt)
            {
                damage = 3;
            }
            if (c.name == CardDB.cardName.frostshock)
            {
                frozen = true;
                damage = 1;
            }
            if (c.name == CardDB.cardName.rockbiterweapon)
            {
                if (target <= 20)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.CS2_045e);
                    e.creator = hc.entity;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                else
                {
                    if (target == 100)
                    {
                        this.ownheroAngr += 3;
                        if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                        {
                            this.ownHeroReady = true;
                        }
                    }
                }
            }
            if (c.name == CardDB.cardName.windfury)
            {
                windfury = true;
            }
            if (c.name == CardDB.cardName.hex)
            {
                frogg = true;
            }
            if (c.name == CardDB.cardName.earthshock)
            {
                silence = true;
                damage = 1;
            }
            if (c.name == CardDB.cardName.ancestralspirit)
            {
                geistderahnen = true;
            }
            if (c.name == CardDB.cardName.lavaburst)
            {
                damage = 5;
            }

            if (c.name == CardDB.cardName.ancestralhealing)
            {
                heal = 1000;
                spott = true;
            }

            //hexenmeister ##########################################

            if (c.name == CardDB.cardName.sacrificialpact)
            {
                destroy = true;
                this.attackOrHealHero(getSpellHeal(5), true); // heal own hero
            }

            if (c.name == CardDB.cardName.soulfire)
            {
                damage = 4;
                this.owncarddraw--;
                this.owncards.RemoveRange(0, Math.Min(1, this.owncards.Count));


            }
            if (c.name == CardDB.cardName.poweroverwhelming)
            {
                //only to own mininos
                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_316e);
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, true);
            }
            if (c.name == CardDB.cardName.corruption)
            {
                //only to enemy mininos
                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.CS2_063e);
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, false);
            }
            if (c.name == CardDB.cardName.mortalcoil)
            {
                damage = 1;
                if (getSpellDamageDamage(1) >= m.Hp && !m.divineshild && !m.immune)
                {
                    //this.owncarddraw++;
                    drawACard(CardDB.cardName.unknown, true);
                }
            }
            if (c.name == CardDB.cardName.drainlife)
            {
                damage = 2;
                attackOrHealHero(2, true);
            }
            if (c.name == CardDB.cardName.shadowbolt)
            {
                damage = 4;
            }
            if (c.name == CardDB.cardName.shadowflame)
            {
                int damage1 = getSpellDamageDamage(m.Angr);
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDamagedOrHealed(mnn, damage1, 0, false);
                }
                //destroy own mininon
                destroy = true;
            }

            if (c.name == CardDB.cardName.demonfire)
            {
                if (m.handcard.card.race == 15 && own)
                {
                    attackbuff = 2;
                    hpbuff = 2;
                }
                else
                {
                    damage = 2;
                }
            }
            if (c.name == CardDB.cardName.baneofdoom)
            {
                damage = 2;
                if (getSpellDamageDamage(2) >= m.Hp && !m.divineshild && !m.immune)
                {
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_059);//bloodimp
                    callKid(kid, posi, true);
                }
            }

            if (c.name == CardDB.cardName.siphonsoul)
            {
                destroy = true;
                int h = getSpellHeal(3);
                attackOrHealHero(-h, true);

            }


            //druid #######################################################################

            if (c.name == CardDB.cardName.moonfire && c.cardIDenum == CardDB.cardIDEnum.CS2_008)// nicht zu verwechseln mit cenarius choice nummer 1
            {
                damage = 1;
            }

            if (c.name == CardDB.cardName.markofthewild)
            {
                spott = true;
                attackbuff = 2;
                hpbuff = 2;
            }

            if (c.name == CardDB.cardName.healingtouch)
            {
                heal = 8;
            }

            if (c.name == CardDB.cardName.starfire)
            {
                damage = 5;
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
            }

            if (c.name == CardDB.cardName.naturalize)
            {
                destroy = true;
                this.enemycarddraw += 2;
            }

            if (c.name == CardDB.cardName.savagery)
            {
                damage = this.ownheroAngr;
            }

            if (c.name == CardDB.cardName.swipe)
            {
                damage = 4;
                // all others get 1 spelldamage
                int damage1 = getSpellDamageDamage(1);
                if (target != 200)
                {
                    attackOrHealHero(damage1, false);
                }
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    if (mnn.id + 10 != target)
                    {
                        minionGetDamagedOrHealed(mnn, damage1, 0, false);
                    }
                }
            }

            //druid choices##################################################################################
            if (c.name == CardDB.cardName.wrath)
            {
                if (choice == 1)
                {
                    damage = 3;
                }
                if (choice == 2)
                {
                    damage = 1;
                    //this.owncarddraw++;
                    drawACard(CardDB.cardName.unknown, true);
                }
            }

            if (c.name == CardDB.cardName.markofnature)
            {
                if (choice == 1)
                {
                    attackbuff = 4;
                }
                if (choice == 2)
                {
                    spott = true;
                    hpbuff = 4;
                }
            }

            if (c.name == CardDB.cardName.starfall)
            {
                if (choice == 1)
                {
                    damage = 5;
                }

            }


            //special cards#########################################################################################

            if (c.name == CardDB.cardName.nightmare)
            {
                //only to own mininos
                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_316e);
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, true);
            }

            if (c.name == CardDB.cardName.dream)
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }

            if (c.name == CardDB.cardName.bananas)
            {
                attackbuff = 1;
                hpbuff = 1;
            }

            if (c.name == CardDB.cardName.barreltoss)
            {
                damage = 2;
            }

            if (c.cardIDenum == CardDB.cardIDEnum.PRO_001b)// i am murloc
            {
                damage = 4;
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);

            } if (c.name == CardDB.cardName.willofmukla)
            {
                heal = 6;
            }

            //NaxxCards###################################################################################
            if (c.name == CardDB.cardName.reincarnate)
            {
                int place = m.id;
                if (place >= 10) place -= 10;
                CardDB.Card d = m.handcard.card;
                minionGetDestroyed(m, own);
                callKid(d, place, own);
            }

            //make effect on target
            //ownminion

            if (damage >= 1) damage = getSpellDamageDamage(damage);
            if (adjacentDamage >= 1) adjacentDamage = getSpellDamageDamage(adjacentDamage);
            if (heal >= 1 && heal < 1000) heal = getSpellHeal(heal);

            if (target < 10)
            {
                if (silence) minionGetSilenced(m, true);
                minionGetBuffed(m, attackbuff, hpbuff, true);
                minionGetDamagedOrHealed(m, damage, heal, true);
                if (spott) m.taunt = true;
                if (charge) minionGetCharge(m);
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, true);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, true, backtoHandManaChange);
                if (immune) m.immune = true;
                if (adjacentDamage >= 1)
                {
                    List<Minion> tempolist = new List<Minion>(this.ownMinions);
                    foreach (Minion mnn in tempolist)
                    {
                        if (mnn.id == target + 1 || mnn.id == target - 1)
                        {
                            minionGetDamagedOrHealed(m, adjacentDamage, 0, own);
                            if (frozen) mnn.frozen = true;
                        }
                    }
                }
                if (sheep) minionTransform(m, CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_tk1), own);
                if (frogg) minionTransform(m, CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.hexfrog), own);
                if (setHPtoONE)
                {
                    m.Hp = 1; m.maxHp = 1;
                }

                if (geistderahnen)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.CS2_038e);
                    e.creator = hc.entity;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, true);
                }


            }
            //enemyminion
            if (target >= 10 && target < 20)
            {
                if (silence) minionGetSilenced(m, false);
                minionGetBuffed(m, attackbuff, hpbuff, false);
                minionGetDamagedOrHealed(m, damage, heal, false);
                if (spott) m.taunt = true;
                if (charge) minionGetCharge(m);
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, false);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, false, backtoHandManaChange);
                if (immune) m.immune = true;
                if (adjacentDamage >= 1)
                {
                    List<Minion> tempolist = new List<Minion>(this.enemyMinions);
                    foreach (Minion mnn in tempolist)
                    {
                        if (mnn.id + 10 == target + 1 || mnn.id + 10 == target - 1)
                        {
                            minionGetDamagedOrHealed(m, adjacentDamage, 0, own);
                            if (frozen) mnn.frozen = true;
                        }
                    }
                }
                if (sheep) minionTransform(m, CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_tk1), own);
                if (frogg) minionTransform(m, CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.hexfrog), own);
                if (setHPtoONE)
                {
                    m.Hp = 1; m.maxHp = 1;
                }
                if (geistderahnen)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.CS2_038e);
                    e.creator = hc.entity;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, false);
                }

            }
            if (target == 100)
            {
                if (frozen) this.ownHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, true);
                if (heal >= 1) attackOrHealHero(-heal, true);
            }
            if (target == 200)
            {
                if (frozen) this.enemyHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, false);
                if (heal >= 1) attackOrHealHero(-heal, false);
            }

        }

        private void playCardWithoutTarget(Handmanager.Handcard hc, int choice)
        {
            CardDB.Card c = hc.card;
            //todo faehrtenlesen!

            //play card without target
            if (c.name == CardDB.cardName.thecoin)
            {
                this.mana++;

            }
            //hunter#########################################################################
            if (c.name == CardDB.cardName.multishot && this.enemyMinions.Count >= 2)
            {
                List<Minion> temp = new List<Minion>();
                int damage = getSpellDamageDamage(3);
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the strongest
                temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }
            if (c.name == CardDB.cardName.animalcompanion)
            {
                CardDB.Card c2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_032);//misha
                int placeoffather = this.ownMinions.Count - 1;
                callKid(c2, placeoffather, true);
            }

            if (c.name == CardDB.cardName.flare)
            {
                foreach (Minion m in this.ownMinions)
                {
                    m.stealth = false;
                }
                foreach (Minion m in this.enemyMinions)
                {
                    m.stealth = false;
                }
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
                this.enemySecretCount = 0;
            }

            if (c.name == CardDB.cardName.unleashthehounds)
            {
                int anz = this.enemyMinions.Count;
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_538t);//hound
                for (int i = 0; i < anz; i++)
                {
                    callKid(kid, posi, true);
                }
            }

            if (c.name == CardDB.cardName.deadlyshot && this.enemyMinions.Count >= 1)
            {
                List<Minion> temp = new List<Minion>();
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                temp.AddRange(Helpfunctions.TakeList(temp2, 1));
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, false);
                }

            }

            //warrior#########################################################################
            if (c.name == CardDB.cardName.commandingshout)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                Enchantment e1 = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.NEW1_036e);
                e1.creator = hc.entity;
                e1.controllerOfCreator = this.ownController;
                Enchantment e2 = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.NEW1_036e2);
                e2.creator = hc.entity;
                e2.controllerOfCreator = this.ownController;
                foreach (Minion mnn in temp)
                {//cantLowerHPbelowONE
                    addEffectToMinionNoDoubles(mnn, e1, true);
                    addEffectToMinionNoDoubles(mnn, e2, true);
                    mnn.cantLowerHPbelowONE = true;
                }

            }

            if (c.name == CardDB.cardName.battlerage)
            {
                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.wounded)
                    {
                        //this.owncarddraw++;
                        drawACard(CardDB.cardName.unknown, true);
                    }
                }

            }

            if (c.name == CardDB.cardName.brawl)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDestroyed(mnn, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDestroyed(mnn, false);
                }

            }


            if (c.name == CardDB.cardName.cleave && this.enemyMinions.Count >= 2)
            {
                List<Minion> temp = new List<Minion>();
                int damage = getSpellDamageDamage(2);
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }

            if (c.name == CardDB.cardName.upgrade)
            {
                if (this.ownWeaponName != CardDB.cardName.unknown)
                {
                    this.ownWeaponAttack++;
                    this.ownheroAngr++;
                    this.ownWeaponDurability++;
                }
                else
                {
                    CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_409t);//heavyaxe
                    this.equipWeapon(wcard);
                }

            }



            if (c.name == CardDB.cardName.whirlwind)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                temp.Clear();
                temp = new List<Minion>(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true);
                }
            }

            if (c.name == CardDB.cardName.heroicstrike)
            {
                this.ownheroAngr = this.ownheroAngr + 4;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                {
                    this.ownHeroReady = true;
                }
            }

            if (c.name == CardDB.cardName.shieldblock)
            {
                this.ownHeroDefence = this.ownHeroDefence + 5;
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
            }



            //mage#########################################################################################

            if (c.name == CardDB.cardName.blizzard)
            {
                int damage = getSpellDamageDamage(2);
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int maxHp = 0;
                foreach (Minion enemy in temp)
                {
                    enemy.frozen = true;
                    if (maxHp < enemy.Hp) maxHp = enemy.Hp;

                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }

                this.lostDamage += Math.Max(0, damage - maxHp);

            }

            if (c.name == CardDB.cardName.arcanemissiles)
            {
                /*List<Minion> temp = new List<Minion>(this.enemyMinions);
                temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                int damage = 1;
                int ammount = getSpellDamageDamage(3);
                int i = 0;
                int hp = 0;
                foreach (Minion enemy in temp)
                {
                    if (enemy.Hp >= 2)
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                        i++;
                        hp += enemy.Hp;
                        if (i == ammount) break;
                    }
                    
                }
                if (i < ammount) attackOrHealHero(ammount - i, false);*/

                int damage = 1;
                int i = 0;
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int times = this.getSpellDamageDamage(3);
                while (i < times)
                {
                    if (temp.Count >= 1)
                    {
                        temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                        if (temp[0].Hp == 1 && this.enemyHeroHp >= 2)
                        {
                            attackOrHealHero(damage, false);
                        }
                        else
                        {
                            minionGetDamagedOrHealed(temp[0], damage, 0, false);
                        }
                    }
                    else
                    {
                        attackOrHealHero(damage, false);
                    }
                    i++;
                }



            }
            if (c.name == CardDB.cardName.arcaneintellect)
            {
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);
                drawACard(CardDB.cardName.unknown, true);
            }

            if (c.name == CardDB.cardName.mirrorimage)
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_mirror);
                callKid(kid, posi, true);
                callKid(kid, posi, true);
            }

            if (c.name == CardDB.cardName.arcaneexplosion)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
            }
            if (c.name == CardDB.cardName.frostnova)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    enemy.frozen = true;
                }

            }
            if (c.name == CardDB.cardName.flamestrike)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(4);
                int maxHp = 0;
                foreach (Minion enemy in temp)
                {
                    if (maxHp < enemy.Hp) maxHp = enemy.Hp;

                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }
                this.lostDamage += Math.Max(0, damage - maxHp);

            }

            //pala#################################################################
            if (c.name == CardDB.cardName.consecration)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

                attackOrHealHero(damage, false);
            }

            if (c.name == CardDB.cardName.equality)
            {
                foreach (Minion m in this.ownMinions)
                {
                    m.Hp = 1;
                    m.maxHp = 1;
                }
                foreach (Minion m in this.enemyMinions)
                {
                    m.Hp = 1;
                    m.maxHp = 1;
                }

            }
            if (c.name == CardDB.cardName.divinefavor)
            {
                int enemcardsanz = this.enemyAnzCards + this.enemycarddraw;
                int diff = enemcardsanz - this.owncards.Count;
                if (diff >= 1)
                {
                    for (int i = 0; i < diff; i++)
                    {
                        //this.owncarddraw++;
                        drawACard(CardDB.cardName.unknown, true);
                    }
                }
            }

            if (c.name == CardDB.cardName.avengingwrath)
            {

                int damage = 1;
                int i = 0;
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int times = this.getSpellDamageDamage(8);
                while (i < times)
                {
                    if (temp.Count >= 1)
                    {
                        temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                        if (temp[0].Hp == 1 && this.enemyHeroHp >= 2)
                        {
                            attackOrHealHero(damage, false);
                        }
                        else
                        {
                            minionGetDamagedOrHealed(temp[0], damage, 0, false);
                        }
                    }
                    else
                    {
                        attackOrHealHero(damage, false);
                    }
                    i++;
                }

            }


            //priest ####################################################
            if (c.name == CardDB.cardName.circleofhealing)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int heal = getSpellHeal(4);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal, true);
                }

            }
            if (c.name == CardDB.cardName.thoughtsteal)
            {
                //this.owncarddraw++;
                this.drawACard(CardDB.cardName.unknown, true, true);
                //this.owncarddraw++;
                this.drawACard(CardDB.cardName.unknown, true, true);
            }
            if (c.name == CardDB.cardName.mindvision)
            {
                if (this.enemyAnzCards + this.enemycarddraw >= 1)
                {
                    //this.owncarddraw++;
                    this.drawACard(CardDB.cardName.unknown, true, true);
                }
            }

            if (c.name == CardDB.cardName.shadowform)
            {
                if (this.ownHeroAblility.cardIDenum == CardDB.cardIDEnum.CS1h_001) // lesser heal becomes mind spike
                {
                    this.ownHeroAblility = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_625t);
                    this.ownAbilityReady = true;
                }
                else
                {
                    this.ownHeroAblility = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_625t2);  // mindspike becomes mind shatter
                    this.ownAbilityReady = true;
                }
            }

            if (c.name == CardDB.cardName.mindgames)
            {
                CardDB.Card copymin = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_152); //we draw a knappe :D (worst case)
                callKid(copymin, this.ownMinions.Count - 1, true);
            }

            if (c.name == CardDB.cardName.massdispel)
            {
                foreach (Minion m in this.enemyMinions)
                {
                    minionGetSilenced(m, false);
                }
            }
            if (c.name == CardDB.cardName.mindblast)
            {
                int damage = getSpellDamageDamage(5);
                attackOrHealHero(damage, false);
            }

            if (c.name == CardDB.cardName.holynova)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                int heal = getSpellHeal(2);
                int damage = getSpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal, true, true);
                }
                attackOrHealHero(-heal, true);
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }
                attackOrHealHero(damage, false);

            }
            //rogue #################################################
            if (c.name == CardDB.cardName.preparation)
            {
                this.playedPreparation = true;
            }

            if (c.name == CardDB.cardName.bladeflurry)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = this.getSpellDamageDamage(this.ownWeaponAttack);
                int maxhp = 0;
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true);
                    if (maxhp < enemy.Hp) maxhp = Math.Min(enemy.Hp, damage);
                }
                this.lostDamage += (damage - maxhp) * (damage - maxhp);
                attackOrHealHero(damage, false);

                //destroy own weapon
                this.lowerWeaponDurability(1000, true);
            }

            if (c.name == CardDB.cardName.headcrack)
            {
                int damage = getSpellDamageDamage(2);
                attackOrHealHero(damage, false);
                if (this.cardsPlayedThisTurn >= 1) this.owncarddraw++; // DONT DRAW A CARD WITH (drawAcard()) because we get this NEXT turn 
            }
            if (c.name == CardDB.cardName.sinisterstrike)
            {
                int damage = getSpellDamageDamage(3);
                attackOrHealHero(damage, false);
            }
            if (c.name == CardDB.cardName.deadlypoison)
            {
                if (this.ownWeaponName != CardDB.cardName.unknown)
                {
                    this.ownWeaponAttack += 2;
                    this.ownheroAngr += 2;

                }
            }
            if (c.name == CardDB.cardName.fanofknives)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                drawACard(CardDB.cardName.unknown, true);
            }

            if (c.name == CardDB.cardName.sprint)
            {
                for (int i = 0; i < 4; i++)
                {
                    //this.owncarddraw++;
                    drawACard(CardDB.cardName.unknown, true);
                }

            }

            if (c.name == CardDB.cardName.vanish)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int heal = getSpellHeal(4);
                foreach (Minion enemy in temp)
                {
                    minionReturnToHand(enemy, false, 0);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionReturnToHand(enemy, true, 0);
                }

            }

            //shaman #################################################
            if (c.name == CardDB.cardName.forkedlightning && this.enemyMinions.Count >= 2)
            {
                List<Minion> temp = new List<Minion>();
                int damage = getSpellDamageDamage(2);
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }

            if (c.name == CardDB.cardName.farsight)
            {
                //this.owncarddraw++;
                drawACard(CardDB.cardName.unknown, true);

            }

            if (c.name == CardDB.cardName.lightningstorm)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(2);

                int maxHp = 0;
                foreach (Minion enemy in temp)
                {
                    if (maxHp < enemy.Hp) maxHp = enemy.Hp;

                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }
                this.lostDamage += Math.Max(0, damage - maxHp);

            }

            if (c.name == CardDB.cardName.feralspirit)
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk11);//spiritwolf
                callKid(kid, posi, true);
                callKid(kid, posi, true);
            }

            if (c.name == CardDB.cardName.totemicmight)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.handcard.card.race == 21) // if minion is a totem, buff it
                    {
                        minionGetBuffed(m, 0, 2, true);
                    }
                }

            }

            if (c.name == CardDB.cardName.bloodlust)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.CS2_046e);
                    e.creator = this.ownController;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, true);
                }
            }


            //hexenmeister #################################################
            if (c.name == CardDB.cardName.sensedemons)
            {
                //this.owncarddraw += 2;
                this.drawACard(CardDB.cardName.unknown, true);
                this.drawACard(CardDB.cardName.unknown, true);


            }
            if (c.name == CardDB.cardName.twistingnether)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, true);
                }

            }

            if (c.name == CardDB.cardName.hellfire)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(3);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true);
                }
                attackOrHealHero(damage, true);
                attackOrHealHero(damage, false);

            }


            //druid #################################################
            if (c.name == CardDB.cardName.souloftheforest)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.EX1_158e);
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                foreach (Minion enemy in temp)
                {
                    addEffectToMinionNoDoubles(enemy, e, true);
                }
            }

            if (c.name == CardDB.cardName.innervate)
            {
                this.mana = Math.Min(this.mana + 2, 10);

            }

            if (c.name == CardDB.cardName.bite)
            {
                this.ownheroAngr += 4;
                this.ownHeroDefence += 4;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                {
                    this.ownHeroReady = true;
                }

            }

            if (c.name == CardDB.cardName.claw)
            {
                this.ownheroAngr += 2;
                this.ownHeroDefence += 2;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                {
                    this.ownHeroReady = true;
                }

            }

            if (c.name == CardDB.cardName.forceofnature)
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk9);//Treant
                callKid(kid, posi, true);
                callKid(kid, posi, true);
                callKid(kid, posi, true);
            }

            if (c.name == CardDB.cardName.powerofthewild)// macht der wildnis with summoning
            {
                if (choice == 1)
                {
                    foreach (Minion m in this.ownMinions)
                    {
                        minionGetBuffed(m, 1, 1, true);
                    }
                }
                if (choice == 2)
                {
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160t);//panther
                    callKid(kid, posi, true);
                }
            }

            if (c.name == CardDB.cardName.starfall)
            {
                if (choice == 2)
                {
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    int damage = getSpellDamageDamage(2);
                    foreach (Minion enemy in temp)
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                    }
                }

            }

            if (c.name == CardDB.cardName.nourish)
            {
                if (choice == 1)
                {
                    if (this.ownMaxMana == 10)
                    {
                        //this.owncarddraw++;
                        this.drawACard(CardDB.cardName.excessmana, true);
                    }
                    else
                    {
                        this.ownMaxMana++;
                        this.mana++;
                    }
                    if (this.ownMaxMana == 10)
                    {
                        //this.owncarddraw++;
                        this.drawACard(CardDB.cardName.excessmana, true);
                    }
                    else
                    {
                        this.ownMaxMana++;
                        this.mana++;
                    }
                }
                if (choice == 2)
                {
                    //this.owncarddraw+=3;
                    this.drawACard(CardDB.cardName.unknown, true);
                    this.drawACard(CardDB.cardName.unknown, true);
                    this.drawACard(CardDB.cardName.unknown, true);
                }
            }

            if (c.name == CardDB.cardName.savageroar)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.cardIDEnum.CS2_011o);
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                foreach (Minion m in temp)
                {
                    addEffectToMinionNoDoubles(m, e, true);
                }
                this.ownheroAngr += 2;
            }

            //special cards#######################

            if (c.cardIDenum == CardDB.cardIDEnum.PRO_001a)// i am murloc
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.PRO_001at);//panther
                callKid(kid, posi, true);
                callKid(kid, posi, true);
                callKid(kid, posi, true);

            }

            if (c.cardIDenum == CardDB.cardIDEnum.PRO_001c)// i am murloc
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_021);//scharfseher
                callKid(kid, posi, true);

            }

            if (c.name == CardDB.cardName.wildgrowth)
            {
                if (this.ownMaxMana == 10)
                {
                    //this.owncarddraw++;
                    this.drawACard(CardDB.cardName.excessmana, true);
                }
                else
                {
                    this.ownMaxMana++;
                }

            }

            if (c.name == CardDB.cardName.excessmana)
            {
                //this.owncarddraw++;
                this.drawACard(CardDB.cardName.unknown, true);
            }

            if (c.name == CardDB.cardName.yseraawakens)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(5);
                foreach (Minion enemy in temp)
                {
                    if (enemy.name != CardDB.cardName.ysera)// dont attack ysera
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                    }
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    if (enemy.name != CardDB.cardName.ysera)//dont attack ysera
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                    }
                }
                attackOrHealHero(damage, true);
                attackOrHealHero(damage, false);

            }

            if (c.name == CardDB.cardName.stomp)
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }

            //NaxxCards###################################################################################

            if (c.name == CardDB.cardName.poisonseeds)
            {
                int ownanz = this.ownMinions.Count;
                int enemanz = this.enemyMinions.Count;
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDestroyed(mnn, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDestroyed(mnn, false);
                }
                for (int i = 0; i < ownanz; i++)
                {
                    CardDB.Card d = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);
                    callKid(d, 0, true);
                }
                for (int i = 0; i < enemanz; i++)
                {
                    CardDB.Card d = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);
                    callKid(d, 0, false);
                }
            }

        }

        private void drawACard(CardDB.cardName ss, bool own, bool nopen = false)
        {
            CardDB.cardName s = ss;

            // cant hold more than 10 cards

            if (own)
            {
                if (s == CardDB.cardName.unknown && !nopen) // draw a card from deck :D
                {
                    if (ownDeckSize == 0)
                    {
                        this.ownHeroFatigue++;
                        this.attackOrHealHero(this.ownHeroFatigue, true);
                    }
                    else
                    {
                        this.ownDeckSize--;
                        if (this.owncards.Count >= 10)
                        {
                            this.evaluatePenality += 5;
                            return;
                        }
                        this.owncarddraw++;
                    }

                }
                else
                {
                    if (this.owncards.Count >= 10)
                    {
                        this.evaluatePenality += 5;
                        return;
                    }
                    this.owncarddraw++;

                }


            }
            else
            {
                if (s == CardDB.cardName.unknown && !nopen) // draw a card from deck :D
                {
                    if (enemyDeckSize == 0)
                    {
                        this.enemyHeroFatigue++;
                        this.attackOrHealHero(this.enemyHeroFatigue, false);
                    }
                    else
                    {
                        this.enemyDeckSize--;
                        if (this.enemyAnzCards + this.enemycarddraw >= 10)
                        {
                            this.evaluatePenality -= 50;
                            return;
                        }
                        this.enemycarddraw++;
                    }

                }
                else
                {
                    if (this.enemyAnzCards + this.enemycarddraw >= 10)
                    {
                        this.evaluatePenality -= 50;
                        return;
                    }
                    this.enemycarddraw++;

                }
                return;
            }

            if (s == CardDB.cardName.unknown)
            {
                CardDB.Card plchldr = new CardDB.Card();
                plchldr.name = CardDB.cardName.unknown;
                Handmanager.Handcard hc = new Handmanager.Handcard();
                hc.card = plchldr;
                hc.position = this.owncards.Count + 1;
                hc.manacost = 1000;
                this.owncards.Add(hc);
            }
            else
            {
                CardDB.Card c = CardDB.Instance.getCardData(s);
                Handmanager.Handcard hc = new Handmanager.Handcard();
                hc.card = c;
                hc.position = this.owncards.Count + 1;
                hc.manacost = c.calculateManaCost(this);
                this.owncards.Add(hc);
            }

        }

        private void triggerPlayedAMinion(Handmanager.Handcard hc, bool own)
        {
            if (own) // effects only for OWN minons
            {
                List<Minion> tempo = new List<Minion>(this.ownMinions);
                foreach (Minion m in tempo)
                {
                    if (m.silenced) continue;

                    if (m.handcard.card.name == CardDB.cardName.knifejuggler && m.entitiyID != hc.entity)
                    {
                        if (this.enemyMinions.Count >= 1)
                        {
                            List<Minion> temp = new List<Minion>();
                            int damage = 1;
                            List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                            temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                            bool dmgdone = false;
                            foreach (Minion enemy in temp2)
                            {
                                if (enemy.Hp > 1)
                                {
                                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                                    dmgdone = true;
                                    break;
                                }
                                if (!dmgdone) this.attackOrHealHero(1, false);
                            }
                            m.stealth = false;

                        }
                        else
                        {
                            this.attackOrHealHero(1, false);
                        }
                    }

                    if (own && m.handcard.card.name == CardDB.cardName.starvingbuzzard && (TAG_RACE)hc.card.race == TAG_RACE.PET && m.entitiyID != hc.entity)
                    {
                        //this.owncarddraw++;
                        this.drawACard(CardDB.cardName.unknown, true);
                    }

                    if (own && m.handcard.card.name == CardDB.cardName.undertaker && hc.card.deathrattle)
                    {
                        minionGetBuffed(m, 1, 1, own);
                    }

                }


            }


            //effects for ALL minons
            List<Minion> tempoo = new List<Minion>(this.ownMinions);
            foreach (Minion m in tempoo)
            {
                if (m.silenced) continue;
                if (m.handcard.card.name == CardDB.cardName.murloctidecaller && hc.card.race == 14 && m.entitiyID != hc.entity)
                {
                    minionGetBuffed(m, 1, 0, true);
                }
                if (m.handcard.card.name == CardDB.cardName.oldmurkeye && hc.card.race == 14 && m.entitiyID != hc.entity)
                {
                    minionGetBuffed(m, 1, 0, true);
                }
            }
            tempoo.Clear();
            tempoo.AddRange(this.enemyMinions);
            foreach (Minion m in tempoo)
            {
                if (m.silenced) continue;
                //truebaugederalte
                if (m.handcard.card.name == CardDB.cardName.murloctidecaller && hc.card.race == 14 && m.entitiyID != hc.entity)
                {
                    minionGetBuffed(m, 1, 0, false);
                }
                if (m.handcard.card.name == CardDB.cardName.oldmurkeye && hc.card.race == 14 && m.entitiyID != hc.entity)
                {
                    minionGetBuffed(m, 1, 0, false);
                }
            }


        }

        private void triggerPlayedASpell(CardDB.Card c)
        {

            bool wilderpyro = false;
            List<Minion> temp = new List<Minion>(this.ownMinions);
            foreach (Minion m in temp)
            {
                if (m.silenced) continue;

                if (m.handcard.card.name == CardDB.cardName.manawyrm)
                {
                    minionGetBuffed(m, 1, 0, true);
                }

                if (m.handcard.card.name == CardDB.cardName.manaaddict)
                {
                    minionGetBuffed(m, 2, 0, true);
                }

                if (m.handcard.card.name == CardDB.cardName.secretkeeper && c.Secret)
                {
                    minionGetBuffed(m, 1, 1, true);
                }

                if (m.handcard.card.name == CardDB.cardName.archmageantonidas)
                {
                    drawACard(CardDB.cardName.fireball, true);
                }

                if (m.handcard.card.name == CardDB.cardName.violetteacher)
                {

                    CardDB.Card d = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_026t);//violetapprentice
                    callKid(d, m.id, true);
                }

                if (m.handcard.card.name == CardDB.cardName.gadgetzanauctioneer)
                {
                    //this.owncarddraw++;
                    drawACard(CardDB.cardName.unknown, true);
                }
                if (m.handcard.card.name == CardDB.cardName.wildpyromancer)
                {
                    wilderpyro = true;
                }
            }

            foreach (Minion m in this.enemyMinions)
            {

                if (m.handcard.card.name == CardDB.cardName.secretkeeper && c.Secret)
                {
                    minionGetBuffed(m, 1, 1, true);
                }
            }

            if (wilderpyro)
            {
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.silenced) continue;

                    if (m.handcard.card.name == CardDB.cardName.wildpyromancer)
                    {
                        List<Minion> temp2 = new List<Minion>(this.ownMinions);
                        foreach (Minion mnn in temp2)
                        {
                            minionGetDamagedOrHealed(mnn, 1, 0, true);
                        }
                        temp2.Clear();
                        temp2.AddRange(this.enemyMinions);
                        foreach (Minion mnn in temp2)
                        {
                            minionGetDamagedOrHealed(mnn, 1, 0, false);
                        }
                    }
                }
            }

        }

        public void removeCard(Handmanager.Handcard hcc)
        {

            this.owncards.RemoveAll(x => x.entity == hcc.entity);
            int i = 1;
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                hc.position = i;
                i++;
            }

        }

        public void playCard(Handmanager.Handcard hc, int cardpos, int cardEntity, int target, int targetEntity, int choice, int placepos, int penality)
        {
            CardDB.Card c = hc.card;
            this.evaluatePenality += penality;
            // lock at frostnova (click) / frostblitz (no click)
            this.mana = this.mana - hc.getManaCost(this);

            removeCard(hc);// remove card

            if (c.Secret)
            {
                this.ownSecretsIDList.Add(c.cardIDenum);
                this.playedmagierinderkirintor = false;
            }
            if (c.type == CardDB.cardtype.SPELL) this.playedPreparation = false;

            //Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);
            if (logging) Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);

            if (c.type == CardDB.cardtype.MOB)
            {
                Action b = this.placeAmobSomewhere(hc, cardpos, target, choice, placepos);
                b.handcard = new Handmanager.Handcard(hc);
                b.druidchoice = choice;
                b.owntarget = placepos;
                b.enemyEntitiy = targetEntity;
                b.cardEntitiy = cardEntity;
                b.penalty = penality;
                this.playactions.Add(b);
                this.mobsplayedThisTurn++;
                if (c.name == CardDB.cardName.kirintormage) this.playedmagierinderkirintor = true;

            }
            else
            {
                Action a = new Action();
                a.cardplay = true;
                a.handcard = new Handmanager.Handcard(hc);
                a.cardEntitiy = cardEntity;
                a.numEnemysBeforePlayed = this.enemyMinions.Count;
                a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;
                a.owntarget = 0;
                a.penalty = penality;
                if (target >= 0)
                {
                    a.owntarget = -1;
                }
                a.enemytarget = target;
                a.enemyEntitiy = targetEntity;
                a.druidchoice = choice;

                if (target == -1)
                {
                    //card with no target
                    if (c.type == CardDB.cardtype.WEAPON)
                    {
                        equipWeapon(c);
                    }
                    playCardWithoutTarget(hc, choice);
                }
                else //before : if(target >=0 && target < 20)
                {
                    if (c.type == CardDB.cardtype.WEAPON)
                    {
                        equipWeapon(c);
                    }
                    playCardWithTarget(hc, target, choice);
                }

                this.playactions.Add(a);

                if (c.type == CardDB.cardtype.SPELL)
                {
                    this.triggerPlayedASpell(c);
                }
            }

            triggerACardGetPlayed(c);

            this.ueberladung += c.recallValue;

            this.cardsPlayedThisTurn++;

        }

        private void triggerACardGetPlayed(CardDB.Card c)
        {
            List<Minion> temp = new List<Minion>(this.ownMinions);
            foreach (Minion mnn in temp)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.illidanstormrage)
                {
                    CardDB.Card d = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_614t);//flameofazzinoth
                    callKid(d, mnn.id, true);
                }
                if (mnn.handcard.card.name == CardDB.cardName.questingadventurer)
                {
                    minionGetBuffed(mnn, 1, 1, true);
                }
                if (mnn.handcard.card.name == CardDB.cardName.unboundelemental && c.recallValue >= 1)
                {
                    minionGetBuffed(mnn, 1, 1, true);
                }
            }
        }

        public void attackWithWeapon(int target, int targetEntity, int penality)
        {
            this.evaluatePenality += penality;
            //this.ownHeroAttackedInRound = true;
            this.ownHeroNumAttackThisTurn++;
            if ((this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 2) || (!this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1))
            {
                this.ownHeroReady = false;
            }
            Action a = new Action();
            a.heroattack = true;
            a.enemytarget = target;
            a.enemyEntitiy = targetEntity;
            a.owntarget = 100;
            a.ownEntitiy = this.ownHeroEntity;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;
            this.playactions.Add(a);

            if (this.ownWeaponName == CardDB.cardName.truesilverchampion)
            {
                this.attackOrHealHero(-2, true);
            }

            if (logging) Helpfunctions.Instance.logg("attck with weapon " + a.owntarget + " " + a.ownEntitiy + " trgt: " + a.enemytarget + " " + a.enemyEntitiy);

            if (target == 200)
            {
                attackOrHealHero(this.ownheroAngr, false);
            }
            else
            {

                Minion enemy = this.enemyMinions[target - 10];

                int enem_attack = enemy.Angr;

                minionGetDamagedOrHealed(enemy, this.ownheroAngr, 0, false);

                if (!this.heroImmuneWhileAttacking)
                {
                    int oldhp = this.ownHeroHp;
                    attackOrHealHero(enem_attack, true);
                    if (oldhp > this.ownHeroHp)
                    {
                        if (!enemy.silenced && enemy.handcard.card.name == CardDB.cardName.waterelemental)
                        {
                            this.ownHeroFrozen = true;
                        }
                    }
                }
            }

            //todo
            if (ownWeaponName == CardDB.cardName.gorehowl && target != 200)
            {
                this.ownWeaponAttack--;
                this.ownheroAngr--;
            }
            else
            {
                this.lowerWeaponDurability(1, true);
            }

        }

        public void ENEMYattackWithWeapon(int target, int targetEntity, int penality)
        {
            //this.ownHeroAttackedInRound = true;
            this.enemyHeroNumAttackThisTurn++;
            if ((this.enemyHeroWindfury && this.enemyHeroNumAttackThisTurn == 2) || (!this.enemyHeroWindfury && this.enemyHeroNumAttackThisTurn == 1))
            {
                this.enemyHeroReady = false;
            }

            if (this.enemyWeaponName == CardDB.cardName.truesilverchampion)
            {
                this.attackOrHealHero(-2, false);
            }

            if (logging) Helpfunctions.Instance.logg("enemy attck with weapon trgt: " + target + " " + targetEntity);

            if (target == 100)
            {
                attackOrHealHero(this.enemyheroAngr, true);
            }
            else
            {

                Minion enemy = this.ownMinions[target];
                minionGetDamagedOrHealed(enemy, this.enemyheroAngr, 0, true);

                if (!this.enemyheroImmuneWhileAttacking)
                {
                    attackOrHealHero(enemy.Angr, false);
                    if (!enemy.silenced && enemy.handcard.card.name == CardDB.cardName.waterelemental)
                    {
                        this.enemyHeroFrozen = true;
                    }
                }
            }

            //todo
            if (enemyWeaponName == CardDB.cardName.gorehowl && target != 100)
            {
                this.enemyWeaponAttack--;
                this.enemyheroAngr--;
            }
            else
            {
                this.lowerWeaponDurability(1, false);
            }

        }

        public void activateAbility(CardDB.Card c, int target, int targetEntity, int penality)
        {
            this.evaluatePenality += penality;
            HeroEnum heroname = this.ownHeroName;
            this.ownAbilityReady = false;
            this.mana -= 2;
            Action a = new Action();
            a.useability = true;
            a.handcard = new Handmanager.Handcard(c);
            a.enemytarget = target;
            a.enemyEntitiy = targetEntity;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;
            this.playactions.Add(a);
            if (logging) Helpfunctions.Instance.logg("play ability on target " + target);

            if (heroname == HeroEnum.mage)
            {
                int damage = 1;
                if (target == 100)
                {
                    attackOrHealHero(damage, true);
                }
                else
                {
                    if (target == 200)
                    {
                        attackOrHealHero(damage, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, damage, 0, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, damage, 0, false);
                        }
                    }
                }

            }

            if (heroname == HeroEnum.priest)
            {
                int heal = 2;
                if (this.auchenaiseelenpriesterin) heal = -2;

                if (c.name == CardDB.cardName.mindspike)
                {
                    heal = -1 * 2;
                }
                if (c.name == CardDB.cardName.mindshatter)
                {
                    heal = -1 * 3;
                }

                if (target == 100)
                {
                    attackOrHealHero(-1 * heal, true);
                }
                else
                {
                    if (target == 200)
                    {
                        attackOrHealHero(-1 * heal, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, 0, heal, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, 0, heal, false);
                        }
                    }
                }

            }

            if (heroname == HeroEnum.warrior)
            {
                this.ownHeroDefence += 2;
            }

            if (heroname == HeroEnum.warlock)
            {
                //this.owncarddraw++;
                this.drawACard(CardDB.cardName.unknown, true);
                this.attackOrHealHero(2, true);
            }


            if (heroname == HeroEnum.thief)
            {

                CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_082);
                this.equipWeapon(wcard);
            }

            if (heroname == HeroEnum.druid)
            {
                this.ownheroAngr += 1;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                {
                    this.ownHeroReady = true;
                }
                this.ownHeroDefence += 1;
            }


            if (heroname == HeroEnum.hunter)
            {
                this.attackOrHealHero(2, false);
            }

            if (heroname == HeroEnum.pala)
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);//silverhandrecruit
                callKid(kid, posi, true);
            }

            if (heroname == HeroEnum.shaman)
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_009);//healingtotem
                callKid(kid, posi, true);
            }

            if (heroname == HeroEnum.lordjaraxxus)
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk34);//infernal
                callKid(kid, posi, true);
            }


        }

        public void ENEMYactivateAbility(CardDB.Card c, int target, int targetEntity)
        {
            HeroEnum heroname = this.enemyHeroName;
            this.enemyAbilityReady = false;
            if (logging) Helpfunctions.Instance.logg("enemy play ability on target " + target);

            if (heroname == HeroEnum.mage)
            {
                int damage = 1;
                if (target == 100)
                {
                    attackOrHealHero(damage, true);
                }
                else
                {
                    if (target == 200)
                    {
                        attackOrHealHero(damage, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, damage, 0, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, damage, 0, false);
                        }
                    }
                }

            }

            if (heroname == HeroEnum.priest)
            {
                int heal = 2;
                if (this.auchenaiseelenpriesterin) heal = -2;

                if (c.name == CardDB.cardName.mindspike)
                {
                    heal = -1 * 2;
                }
                if (c.name == CardDB.cardName.mindshatter)
                {
                    heal = -1 * 3;
                }

                if (target == 100)
                {
                    if (heal >= 1) return;
                    attackOrHealHero(-1 * heal, true);
                }
                else
                {
                    if (target == 200)
                    {
                        if (heal >= 1)
                        {
                            bool haslightwarden = false;
                            foreach (Minion mnn in this.enemyMinions)
                            {
                                if (mnn.handcard.card.name == CardDB.cardName.lightwarden)
                                {
                                    haslightwarden = true;
                                    break;
                                }
                            }
                            if (!haslightwarden) return;
                        }
                        attackOrHealHero(-1 * heal, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, 0, heal, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, 0, heal, false);
                        }
                    }
                }

            }

            if (heroname == HeroEnum.warrior)
            {
                this.enemyHeroDefence += 2;
            }

            if (heroname == HeroEnum.warlock)
            {
                //this.owncarddraw++;
                this.drawACard(CardDB.cardName.unknown, false);
                this.attackOrHealHero(2, false);
            }


            if (heroname == HeroEnum.thief)
            {

                CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_082);//wickedknife
                this.enemyheroAngr = wcard.Attack;
                this.enemyWeaponAttack = wcard.Attack;
                this.enemyWeaponDurability = wcard.Durability;
                this.enemyHeroWindfury = false;
                if ((this.enemyHeroNumAttackThisTurn == 0 || (this.enemyHeroWindfury && this.enemyHeroNumAttackThisTurn == 1)) && !this.enemyHeroFrozen)
                {
                    this.enemyHeroReady = true;
                }
            }

            if (heroname == HeroEnum.druid)
            {
                this.enemyheroAngr += 1;
                if ((this.enemyHeroNumAttackThisTurn == 0 || (this.enemyHeroWindfury && this.enemyHeroNumAttackThisTurn == 1)) && !this.enemyHeroFrozen)
                {
                    this.enemyHeroReady = true;
                }
                this.enemyHeroDefence += 1;
            }


            if (heroname == HeroEnum.hunter)
            {
                this.attackOrHealHero(2, true);
            }

            if (heroname == HeroEnum.pala)
            {
                int posi = this.enemyMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);//silverhandrecruit
                callKid(kid, posi, false);
            }

            if (heroname == HeroEnum.shaman)
            {
                int posi = this.enemyMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_050);//searingtotem
                callKid(kid, posi, false);
            }

            if (heroname == HeroEnum.lordjaraxxus)
            {
                int posi = this.enemyMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk34);//infernal
                callKid(kid, posi, false);
            }


        }

        public void doAction()
        {
            /*if (this.playactions.Count >= 1)
            {
                Action a = this.playactions[0];

                if (a.cardplay)
                {
                    if (logging) help.logg("play " + a.handcard.card.name);
                    if (logging) help.logg("with position " + a.cardplace.X + "," + a.cardplace.Y);
                    help.clicklauf(a.cardplace.X, a.cardplace.Y);
                    if (a.owntarget >= 0)
                    {
                        if (logging) help.logg("on position " + a.ownplace.X + "," + a.ownplace.Y);
                        help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    }
                    if (a.enemytarget >= 0)
                    {
                        if (logging) help.logg("and target to " + a.enemytarget + ": on " + a.targetplace.X + ", " + a.targetplace.Y);
                        help.clicklauf(a.targetplace.X, a.targetplace.Y);
                    }
                }
                if (a.minionplay)
                {
                    if (logging) help.logg("attacker: " + a.owntarget + " enemy: " + a.enemytarget);
                    help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    System.Threading.Thread.Sleep(500);
                    if (logging) help.logg("targetplace " + a.targetplace.X + ", " + a.targetplace.Y);
                    help.clicklauf(a.targetplace.X, a.targetplace.Y);
                }
                if (a.heroattack)
                {
                    if (logging) help.logg("attack with hero, enemy: " + a.enemytarget);
                    help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    if (logging) help.logg("targetplace " + a.targetplace.X + ", " + a.targetplace.Y);
                    help.clicklauf(a.targetplace.X, a.targetplace.Y);
                }
                if (a.useability)
                {
                    if (logging) help.logg("useability ");
                    help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    if (a.enemytarget >= 0)
                    {
                        if (logging) help.logg("on enemy: " + a.enemytarget + "targetplace " + a.targetplace.X + ", " + a.targetplace.Y);
                        help.clicklauf(a.targetplace.X, a.targetplace.Y);
                    }
                }

            }
            else
            {
                // click endturnbutton
                help.clicklauf(939, 353);
            }
            help.laufmaus(915, 400, 6);
             */
        }


        private void debugMinions()
        {
            Helpfunctions.Instance.logg("OWN MINIONS################");

            foreach (Minion m in this.ownMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp, maxhp: " + m.name + ", " + m.Angr + ", " + m.Hp + ", " + m.maxHp);
                foreach (Enchantment e in m.enchantments)
                {
                    Helpfunctions.Instance.logg("enchment: " + e.CARDID + " " + e.creator + " " + e.controllerOfCreator);
                }
            }

            Helpfunctions.Instance.logg("ENEMY MINIONS############");
            foreach (Minion m in this.enemyMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
            }
        }

        public void printBoard()
        {
            Helpfunctions.Instance.logg("board: " + value);
            Helpfunctions.Instance.logg("pen " + this.evaluatePenality);
            Helpfunctions.Instance.logg("cardsplayed: " + this.cardsPlayedThisTurn + " handsize: " + this.owncards.Count);
            Helpfunctions.Instance.logg("ownhero: ");
            Helpfunctions.Instance.logg("ownherohp: " + this.ownHeroHp + " + " + this.ownHeroDefence);
            Helpfunctions.Instance.logg("ownheroattac: " + this.ownheroAngr);
            Helpfunctions.Instance.logg("ownheroweapon: " + this.ownWeaponAttack + " " + this.ownWeaponDurability + " " + this.ownWeaponName);
            Helpfunctions.Instance.logg("ownherostatus: frozen" + this.ownHeroFrozen + " ");
            Helpfunctions.Instance.logg("enemyherohp: " + this.enemyHeroHp + " + " + this.enemyHeroDefence);
            Helpfunctions.Instance.logg("OWN MINIONS################");

            foreach (Minion m in this.ownMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
                foreach (Enchantment e in m.enchantments)
                {
                    Helpfunctions.Instance.logg("enchment " + e.CARDID + " " + e.creator + " " + e.controllerOfCreator);
                }
            }

            Helpfunctions.Instance.logg("ENEMY MINIONS############");
            foreach (Minion m in this.enemyMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
            }


            Helpfunctions.Instance.logg("");
        }

        public Action getNextAction()
        {
            if (this.playactions.Count >= 1) return this.playactions[0];
            return null;
        }

        public void printActions()
        {
            foreach (Action a in this.playactions)
            {
                if (a.cardplay)
                {
                    Helpfunctions.Instance.logg("play " + a.handcard.card.name);
                    if (a.druidchoice >= 1) Helpfunctions.Instance.logg("choose choise " + a.druidchoice);
                    Helpfunctions.Instance.logg("with entity " + a.cardEntitiy);
                    if (a.owntarget >= 0)
                    {
                        Helpfunctions.Instance.logg("on position " + a.owntarget);
                    }
                    if (a.enemytarget >= 0)
                    {
                        Helpfunctions.Instance.logg("and target to " + a.enemytarget + " " + a.enemyEntitiy);
                    }
                    if (a.penalty != 0)
                    {
                        Helpfunctions.Instance.logg("penality for playing " + a.penalty);
                    }
                }
                if (a.minionplay)
                {
                    Helpfunctions.Instance.logg("attacker: " + a.owntarget + " enemy: " + a.enemytarget);
                    Helpfunctions.Instance.logg("targetplace " + a.enemyEntitiy);
                }
                if (a.heroattack)
                {
                    Helpfunctions.Instance.logg("attack with hero, enemy: " + a.enemytarget);
                    Helpfunctions.Instance.logg("targetplace " + a.enemyEntitiy);
                }
                if (a.useability)
                {
                    Helpfunctions.Instance.logg("useability ");
                    if (a.enemytarget >= 0)
                    {
                        Helpfunctions.Instance.logg("on enemy: " + a.enemytarget + "targetplace " + a.enemyEntitiy);
                    }
                }
                Helpfunctions.Instance.logg("");
            }
        }

    }

    public class Ai
    {
        private int maxdeep = 12;
        private int maxwide = 3000;
        public bool simulateEnemyTurn = true;
        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;

        public MiniSimulator nextTurnSimulator;
        MiniSimulator mainTurnSimulator;

        PenalityManager penman = PenalityManager.Instance;

        List<Playfield> posmoves = new List<Playfield>(7000);

        Hrtprozis hp = Hrtprozis.Instance;
        Handmanager hm = Handmanager.Instance;
        Helpfunctions help = Helpfunctions.Instance;

        public Action bestmove = new Action();
        public int bestmoveValue = 0;
        Playfield bestboard = new Playfield();
        Playfield nextMoveGuess = new Playfield();
        public Behavior botBase = null;

        private bool secondturnsim = false;
        private bool playaround = false;

        private static Ai instance;

        public static Ai Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Ai();
                }
                return instance;
            }
        }

        private Ai()
        {
            this.nextMoveGuess = new Playfield();
            this.nextMoveGuess.mana = -1;
            this.nextTurnSimulator = new MiniSimulator();
            this.mainTurnSimulator = new MiniSimulator(maxdeep, maxwide, 0); // 0 for unlimited
            this.mainTurnSimulator.setPrintingstuff(true);
        }

        public void setMaxWide(int mw)
        {
            this.maxwide = mw;
            if (maxwide <= 100) this.maxwide = 100;
            this.mainTurnSimulator.updateParams(maxdeep, maxwide, 0);
        }

        public void setTwoTurnSimulation(bool stts)
        {
            this.mainTurnSimulator.setSecondTurnSimu(stts);
            this.secondturnsim = stts;
        }

        public void setPlayAround(bool spa)
        {
            this.mainTurnSimulator.setPlayAround(spa);
            this.playaround = spa;
        }

        private void doallmoves(bool test, bool isLethalCheck)
        {
            this.mainTurnSimulator.doallmoves(this.posmoves[0], isLethalCheck);

            Playfield bestplay = this.mainTurnSimulator.bestboard;
            int bestval = this.mainTurnSimulator.bestmoveValue;

            help.loggonoff(true);
            help.logg("-------------------------------------");
            help.logg("bestPlayvalue " + bestval);

            bestplay.printActions();
            this.bestmove = bestplay.getNextAction();
            this.bestmoveValue = bestval;
            this.bestboard = new Playfield(bestplay);

            if (bestmove != null) // save the guessed move, so we doesnt need to recalc!
            {
                this.nextMoveGuess = new Playfield();
                if (bestmove.cardplay)
                {
                    //pf.playCard(c, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, 0, bestplace, cardplayPenality);
                    Handmanager.Handcard hc = this.nextMoveGuess.owncards.Find(x => x.entity == bestmove.cardEntitiy);

                    if (bestmove.owntarget >= 0 && bestmove.enemytarget >= 0 && bestmove.enemytarget <= 9 && bestmove.owntarget < bestmove.enemytarget)
                    {
                        this.nextMoveGuess.playCard(bestmove.handcard, hc.position - 1, hc.entity, bestmove.enemytarget - 1, bestmove.enemyEntitiy, bestmove.druidchoice, bestmove.owntarget, 0);
                    }
                    else
                    {
                        this.nextMoveGuess.playCard(bestmove.handcard, hc.position - 1, hc.entity, bestmove.enemytarget, bestmove.enemyEntitiy, bestmove.druidchoice, bestmove.owntarget, 0);
                    }
                    //this.nextMoveGuess.playCard(bestmove.card, hc.position - 1, hc.entity, bestmove.enemytarget, bestmove.enemyEntitiy, bestmove.druidchoice, bestmove.owntarget, 0);

                }

                if (bestmove.minionplay)
                {
                    //.attackWithMinion(m, trgt.target, trgt.targetEntity, attackPenality);
                    Minion m = this.nextMoveGuess.ownMinions.Find(x => x.entitiyID == bestmove.ownEntitiy);
                    this.nextMoveGuess.attackWithMinion(m, bestmove.enemytarget, bestmove.enemyEntitiy, 0);

                }

                if (bestmove.heroattack)
                {
                    this.nextMoveGuess.attackWithWeapon(bestmove.enemytarget, bestmove.enemyEntitiy, 0);
                }

                if (bestmove.useability)
                {
                    //.activateAbility(p.ownHeroAblility, trgt.target, trgt.targetEntity, abilityPenality);
                    this.nextMoveGuess.activateAbility(this.nextMoveGuess.ownHeroAblility, bestmove.enemytarget, bestmove.enemyEntitiy, 0);
                }

                this.bestboard.playactions.RemoveAt(0);
            }
            else
            {
                nextMoveGuess.mana = -1;
            }

        }

        private void doNextCalcedMove()
        {
            help.logg("noRecalcNeeded!!!-----------------------------------");
            this.bestboard.printActions();
            this.bestmove = this.bestboard.getNextAction();

            if (bestmove != null) // save the guessed move, so we doesnt need to recalc!
            {
                this.nextMoveGuess = new Playfield();
                if (bestmove.cardplay)
                {
                    //pf.playCard(c, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, 0, bestplace, cardplayPenality);
                    Handmanager.Handcard hc = this.nextMoveGuess.owncards.Find(x => x.entity == bestmove.cardEntitiy);
                    if (bestmove.owntarget >= 0 && bestmove.enemytarget >= 0 && bestmove.enemytarget <= 9 && bestmove.owntarget < bestmove.enemytarget)
                    {
                        this.nextMoveGuess.playCard(bestmove.handcard, hc.position - 1, hc.entity, bestmove.enemytarget - 1, bestmove.enemyEntitiy, bestmove.druidchoice, bestmove.owntarget, 0);
                    }
                    else
                    {
                        this.nextMoveGuess.playCard(bestmove.handcard, hc.position - 1, hc.entity, bestmove.enemytarget, bestmove.enemyEntitiy, bestmove.druidchoice, bestmove.owntarget, 0);
                    }


                }

                if (bestmove.minionplay)
                {
                    //.attackWithMinion(m, trgt.target, trgt.targetEntity, attackPenality);
                    Minion m = this.nextMoveGuess.ownMinions.Find(x => x.entitiyID == bestmove.ownEntitiy);
                    this.nextMoveGuess.attackWithMinion(m, bestmove.enemytarget, bestmove.enemyEntitiy, 0);

                }

                if (bestmove.heroattack)
                {
                    this.nextMoveGuess.attackWithWeapon(bestmove.enemytarget, bestmove.enemyEntitiy, 0);
                }

                if (bestmove.useability)
                {
                    //.activateAbility(p.ownHeroAblility, trgt.target, trgt.targetEntity, abilityPenality);
                    this.nextMoveGuess.activateAbility(this.nextMoveGuess.ownHeroAblility, bestmove.enemytarget, bestmove.enemyEntitiy, 0);
                }

                this.bestboard.playactions.RemoveAt(0);
            }
            else
            {
                nextMoveGuess.mana = -1;
            }

        }

        public void dosomethingclever(Behavior bbase)
        {
            //return;
            //turncheck
            //help.moveMouse(950,750);
            //help.Screenshot();
            this.botBase = bbase;
            hp.updatePositions();

            posmoves.Clear();
            posmoves.Add(new Playfield());
            posmoves[0].sEnemTurn = this.simulateEnemyTurn;
            /* foreach (var item in this.posmoves[0].owncards)
             {
                 help.logg("card " + item.handcard.card.name + " is playable :" + item.handcard.card.canplayCard(posmoves[0]) + " cost/mana: " + item.handcard.card.cost + "/" + posmoves[0].mana);
             }
             */
            //help.logg("is hero ready?" + posmoves[0].ownHeroReady);

            help.loggonoff(false);
            //do we need to recalc?
            help.logg("recalc-check###########");
            if (this.dontRecalc && posmoves[0].isEqual(this.nextMoveGuess, true))
            {
                doNextCalcedMove();
            }
            else
            {
                help.logg("Leathal-check###########");
                bestmoveValue = -1000000;
                DateTime strt = DateTime.Now;
                if (useLethalCheck)
                {
                    strt = DateTime.Now;
                    doallmoves(false, true);
                    help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
                }

                if (bestmoveValue < 10000)
                {
                    posmoves.Clear();
                    posmoves.Add(new Playfield());
                    posmoves[0].sEnemTurn = this.simulateEnemyTurn;
                    help.logg("no lethal, do something random######");
                    strt = DateTime.Now;
                    doallmoves(false, false);
                    help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);

                }
            }


            //help.logging(true);

        }

        public void autoTester(Behavior bbase, bool printstuff)
        {
            help.logg("simulating board ");

            BoardTester bt = new BoardTester();
            this.botBase = bbase;
            hp.printHero();
            hp.printOwnMinions();
            hp.printEnemyMinions();
            hm.printcards();
            //calculate the stuff
            posmoves.Clear();
            posmoves.Add(new Playfield());
            posmoves[0].sEnemTurn = this.simulateEnemyTurn;
            foreach (Playfield p in this.posmoves)
            {
                p.printBoard();
            }
            help.logg("ownminionscount " + posmoves[0].ownMinions.Count);
            help.logg("owncardscount " + posmoves[0].owncards.Count);

            foreach (var item in this.posmoves[0].owncards)
            {
                help.logg("card " + item.card.name + " is playable :" + item.canplayCard(posmoves[0]) + " cost/mana: " + item.manacost + "/" + posmoves[0].mana);
            }
            help.logg("ability " + posmoves[0].ownHeroAblility.name + " is playable :" + posmoves[0].ownHeroAblility.canplayCard(posmoves[0], 2) + " cost/mana: " + posmoves[0].ownHeroAblility.getManaCost(posmoves[0], 2) + "/" + posmoves[0].mana);

            // lethalcheck + normal
            DateTime strt = DateTime.Now;
            doallmoves(false, true);
            help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
            if (bestmoveValue < 10000)
            {
                posmoves.Clear();
                posmoves.Add(new Playfield());
                posmoves[0].sEnemTurn = this.simulateEnemyTurn;
                strt = DateTime.Now;
                doallmoves(false, false);
                help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
            }

            this.mainTurnSimulator.printPosmoves();

            help.logg("bestfield");
            bestboard.printBoard();
            if (printstuff) simmulateWholeTurn();
        }

        public void simmulateWholeTurn()
        {
            help.logg("simulate best board");
            //this.bestboard.printActions();

            Playfield tempbestboard = new Playfield();

            if (bestmove != null) // save the guessed move, so we doesnt need to recalc!
            {
                bestmove.print();
                if (bestmove.cardplay)
                {
                    help.logg("card");
                    //pf.playCard(c, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, 0, bestplace, cardplayPenality);
                    Handmanager.Handcard hc = tempbestboard.owncards.Find(x => x.entity == bestmove.cardEntitiy);
                    if (bestmove.owntarget >= 0 && bestmove.enemytarget >= 0 && bestmove.enemytarget <= 9 && bestmove.owntarget < bestmove.enemytarget)
                    {
                        tempbestboard.playCard(bestmove.handcard, hc.position - 1, hc.entity, bestmove.enemytarget - 1, bestmove.enemyEntitiy, bestmove.druidchoice, bestmove.owntarget, 0);
                    }
                    else
                    {
                        tempbestboard.playCard(bestmove.handcard, hc.position - 1, hc.entity, bestmove.enemytarget, bestmove.enemyEntitiy, bestmove.druidchoice, bestmove.owntarget, 0);
                    }
                }

                if (bestmove.minionplay)
                {
                    help.logg("min");
                    //.attackWithMinion(m, trgt.target, trgt.targetEntity, attackPenality);
                    Minion mm = tempbestboard.ownMinions.Find(x => x.entitiyID == bestmove.ownEntitiy);
                    tempbestboard.attackWithMinion(mm, bestmove.enemytarget, bestmove.enemyEntitiy, 0);
                }

                if (bestmove.heroattack)
                {
                    help.logg("hero");
                    tempbestboard.attackWithWeapon(bestmove.enemytarget, bestmove.enemyEntitiy, 0);
                }

                if (bestmove.useability)
                {
                    help.logg("abi");
                    //.activateAbility(p.ownHeroAblility, trgt.target, trgt.targetEntity, abilityPenality);
                    tempbestboard.activateAbility(this.nextMoveGuess.ownHeroAblility, bestmove.enemytarget, bestmove.enemyEntitiy, 0);
                }

            }
            else
            {
                tempbestboard.mana = -1;
            }
            help.logg("-------------");
            tempbestboard.printBoard();

            foreach (Action bestmovee in bestboard.playactions)
            {

                help.logg("stepp");


                if (bestmovee != null) // save the guessed move, so we doesnt need to recalc!
                {
                    bestmovee.print();
                    if (bestmovee.cardplay)
                    {
                        help.logg("card");
                        //pf.playCard(c, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, 0, bestplace, cardplayPenality);
                        Handmanager.Handcard hc = tempbestboard.owncards.Find(x => x.entity == bestmovee.cardEntitiy);
                        if (bestmovee.owntarget >= 0 && bestmovee.enemytarget >= 0 && bestmovee.enemytarget <= 9 && bestmovee.owntarget < bestmovee.enemytarget)
                        {
                            tempbestboard.playCard(bestmovee.handcard, hc.position - 1, hc.entity, bestmovee.enemytarget - 1, bestmovee.enemyEntitiy, bestmovee.druidchoice, bestmovee.owntarget, 0);
                        }
                        else
                        {
                            tempbestboard.playCard(bestmovee.handcard, hc.position - 1, hc.entity, bestmovee.enemytarget, bestmovee.enemyEntitiy, bestmovee.druidchoice, bestmovee.owntarget, 0);
                        }
                    }

                    if (bestmovee.minionplay)
                    {
                        help.logg("min");
                        //.attackWithMinion(m, trgt.target, trgt.targetEntity, attackPenality);
                        Minion mm = tempbestboard.ownMinions.Find(x => x.entitiyID == bestmovee.ownEntitiy);
                        tempbestboard.attackWithMinion(mm, bestmovee.enemytarget, bestmovee.enemyEntitiy, 0);
                    }

                    if (bestmovee.heroattack)
                    {
                        help.logg("hero");
                        tempbestboard.attackWithWeapon(bestmovee.enemytarget, bestmovee.enemyEntitiy, 0);
                    }

                    if (bestmovee.useability)
                    {
                        help.logg("abi");
                        //.activateAbility(p.ownHeroAblility, trgt.target, trgt.targetEntity, abilityPenality);
                        tempbestboard.activateAbility(this.nextMoveGuess.ownHeroAblility, bestmovee.enemytarget, bestmovee.enemyEntitiy, 0);
                    }

                }
                else
                {
                    tempbestboard.mana = -1;
                }
                help.logg("-------------");
                tempbestboard.printBoard();
            }

            help.logg("AFTER ENEMY TURN:");
            tempbestboard.sEnemTurn = this.simulateEnemyTurn;
            tempbestboard.endTurn(this.secondturnsim, this.playaround, true);
        }

    }

    public class MiniSimulator
    {
        //#####################################################################################################################
        private int maxdeep = 6;
        private int maxwide = 10;
        private int totalboards = 50;
        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;

        private bool printNormalstuff = false;

        List<Playfield> posmoves = new List<Playfield>(7000);

        public Action bestmove = new Action();
        public int bestmoveValue = 0;
        public Playfield bestboard = new Playfield();

        public Behavior botBase = null;
        private int calculated = 0;

        private bool simulateSecondTurn = false;
        private bool playaround = false;

        PenalityManager pen = PenalityManager.Instance;

        public MiniSimulator()
        {
        }
        public MiniSimulator(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        public void updateParams(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        public void setPrintingstuff(bool sp)
        {
            this.printNormalstuff = sp;
        }

        public void setSecondTurnSimu(bool sts)
        {
            this.simulateSecondTurn = sts;
        }

        public void setPlayAround(bool spa)
        {
            this.playaround = spa;
        }

        private void addToPosmoves(Playfield pf)
        {
            if (pf.ownHeroHp <= 0) return;
            /*foreach (Playfield p in this.posmoves)
            {
                if (pf.isEqual(p, false)) return;
            }*/
            this.posmoves.Add(pf);
            //posmoves.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));//want to keep the best
            //if (posmoves.Count > this.maxwide) posmoves.RemoveAt(this.maxwide);
            if (this.totalboards >= 1)
            {
                this.calculated++;
            }
        }

        private bool doAllChoices(Playfield p, Handmanager.Handcard hc, bool lethalcheck)
        {
            bool havedonesomething = false;

            for (int i = 1; i < 3; i++)
            {
                CardDB.Card c = hc.card;
                if (c.name == CardDB.cardName.keeperofthegrove)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_166a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_166b);
                    }
                }

                if (c.name == CardDB.cardName.starfall)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_007b);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_007a);
                    }
                }

                if (c.name == CardDB.cardName.ancientoflore)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_008a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_008b);
                    }
                }

                if (c.name == CardDB.cardName.powerofthewild)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160b);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160a);
                    }
                }
                if (c.name == CardDB.cardName.ancientofwar)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_178a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_178b);
                    }
                }
                if (c.name == CardDB.cardName.druidoftheclaw)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t1);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t2);
                    }
                }
                //cenarius dont need
                if (c.name == CardDB.cardName.keeperofthegrove)//keeper of the grove
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_166a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_166b);
                    }
                }
                if (c.name == CardDB.cardName.markofnature)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_155a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_155b);
                    }
                }
                if (c.name == CardDB.cardName.nourish)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_164a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_164b);
                    }
                }
                if (c.name == CardDB.cardName.wrath)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_154a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_154b);
                    }
                }

                if (c.canplayCard(p, hc.manacost))
                {
                    havedonesomething = true;



                    int bestplace = p.getBestPlace(c, lethalcheck);
                    List<targett> trgts = c.getTargetsForCard(p);
                    int cardplayPenality = 0;
                    if (trgts.Count == 0)
                    {


                        if (usePenalityManager)
                        {
                            cardplayPenality = pen.getPlayCardPenality(hc.card, -1, p, i, lethalcheck);
                            if (cardplayPenality <= 499)
                            {
                                //help.logg(hc.card.name + " is played");
                                Playfield pf = new Playfield(p);
                                pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, i, bestplace, cardplayPenality);
                                addToPosmoves(pf);
                            }
                        }
                        else
                        {
                            Playfield pf = new Playfield(p);
                            pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, i, bestplace, cardplayPenality);
                            addToPosmoves(pf);
                        }

                    }
                    else
                    {
                        foreach (targett trgt in trgts)
                        {

                            if (usePenalityManager)
                            {
                                cardplayPenality = pen.getPlayCardPenality(hc.card, trgt.target, p, 0, lethalcheck);
                                if (cardplayPenality <= 499)
                                {
                                    //help.logg(hc.card.name + " is played");
                                    Playfield pf = new Playfield(p);
                                    pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, i, bestplace, cardplayPenality);
                                    addToPosmoves(pf);
                                }
                            }
                            else
                            {
                                Playfield pf = new Playfield(p);
                                pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, i, bestplace, cardplayPenality);
                                addToPosmoves(pf);
                            }

                        }
                    }

                }

            }


            return havedonesomething;
        }

        public int doallmoves(Playfield playf, bool isLethalCheck)
        {
            //Helpfunctions.Instance.logg("NXTTRN" + playf.mana);
            if (botBase == null) botBase = Ai.Instance.botBase;
            bool test = false;
            this.posmoves.Clear();
            this.addToPosmoves(playf);
            bool havedonesomething = true;
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;
            //Helpfunctions.Instance.logg("NXTTRN" + playf.mana + " " + posmoves.Count);
            this.calculated = 0;
            while (havedonesomething)
            {
                if (this.printNormalstuff) Helpfunctions.Instance.logg("ailoop");
                GC.Collect();
                temp.Clear();
                temp.AddRange(this.posmoves);
                havedonesomething = false;
                Playfield bestold = null;
                int bestoldval = -20000000;
                foreach (Playfield p in temp)
                {

                    if (p.complete || p.ownHeroHp <= 0)
                    {
                        continue;
                    }

                    //take a card and play it
                    List<CardDB.cardName> playedcards = new List<CardDB.cardName>();

                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (this.calculated > this.totalboards) continue;
                        CardDB.Card c = hc.card;
                        //help.logg("try play crd" + c.name + " " + c.getManaCost(p) + " " + c.canplayCard(p));
                        if (playedcards.Contains(c.name)) continue; // dont play the same card in one loop
                        playedcards.Add(c.name);
                        if (c.choice)
                        {
                            if (doAllChoices(p, hc, isLethalCheck))
                            {
                                havedonesomething = true;
                            }
                        }
                        else
                        {
                            int bestplace = p.getBestPlace(c, isLethalCheck);
                            if (hc.canplayCard(p))
                            {
                                havedonesomething = true;
                                List<targett> trgts = c.getTargetsForCard(p);

                                if (isLethalCheck && (pen.DamageTargetDatabase.ContainsKey(c.name) || pen.DamageTargetSpecialDatabase.ContainsKey(c.name)))// only target enemy hero during Lethal check!
                                {
                                    targett trg = trgts.Find(x => x.target == 200);
                                    if (trg != null)
                                    {
                                        trgts.Clear();
                                        trgts.Add(trg);
                                    }
                                    else
                                    {
                                        // no enemy hero -> enemy have taunts ->kill the taunts from left to right
                                        if (trgts.Count >= 1)
                                        {
                                            trg = trgts[0];
                                            trgts.Clear();
                                            trgts.Add(trg);
                                        }
                                    }
                                }


                                int cardplayPenality = 0;

                                if (trgts.Count == 0)
                                {


                                    if (usePenalityManager)
                                    {
                                        cardplayPenality = pen.getPlayCardPenality(c, -1, p, 0, isLethalCheck);
                                        if (cardplayPenality <= 499)
                                        {
                                            Playfield pf = new Playfield(p);
                                            havedonesomething = true;
                                            pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, 0, bestplace, cardplayPenality);
                                            addToPosmoves(pf);
                                        }
                                    }
                                    else
                                    {
                                        Playfield pf = new Playfield(p);
                                        havedonesomething = true;
                                        pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, 0, bestplace, cardplayPenality);
                                        addToPosmoves(pf);
                                    }


                                }
                                else
                                {
                                    if (isLethalCheck)// only target enemy hero during Lethal check!
                                    {
                                        targett trg = trgts.Find(x => x.target == 200);
                                        if (trg != null)
                                        {
                                            trgts.Clear();
                                            trgts.Add(trg);
                                        }
                                    }

                                    foreach (targett trgt in trgts)
                                    {


                                        if (usePenalityManager)
                                        {
                                            cardplayPenality = pen.getPlayCardPenality(c, trgt.target, p, 0, isLethalCheck);
                                            if (cardplayPenality <= 499)
                                            {
                                                Playfield pf = new Playfield(p);
                                                havedonesomething = true;
                                                pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, 0, bestplace, cardplayPenality);
                                                addToPosmoves(pf);
                                            }
                                        }
                                        else
                                        {
                                            Playfield pf = new Playfield(p);
                                            havedonesomething = true;
                                            pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, 0, bestplace, cardplayPenality);
                                            addToPosmoves(pf);
                                        }

                                    }

                                }


                            }
                        }
                    }

                    //attack with a minion

                    List<Minion> playedMinions = new List<Minion>(8);

                    foreach (Minion m in p.ownMinions)
                    {
                        if (this.calculated > this.totalboards) continue;

                        if (m.Ready && m.Angr >= 1 && !m.frozen)
                        {
                            //BEGIN:cut (double/similar) attacking minions out#####################################
                            // DONT LET SIMMILAR MINIONS ATTACK IN ONE TURN (example 3 unlesh the hounds-hounds doesnt need to simulated hole)
                            List<Minion> tempoo = new List<Minion>(playedMinions);
                            bool dontattacked = true;
                            bool isSpecial = pen.specialMinions.ContainsKey(m.name);
                            foreach (Minion mnn in tempoo)
                            {
                                // special minions are allowed to attack in silended and unsilenced state!
                                //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                                bool otherisSpecial = pen.specialMinions.ContainsKey(mnn.name);

                                if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                                {
                                    if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                    continue;
                                }

                                if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                                {
                                    if (m.name != mnn.name) // different name -> take it
                                    {
                                        continue;
                                    }
                                    // same name -> test whether they are equal
                                    if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                    continue;
                                }

                            }

                            if (dontattacked)
                            {
                                playedMinions.Add(m);
                            }
                            else
                            {
                                //help.logg(m.name + " doesnt need to attack!");
                                continue;
                            }
                            //END: cut (double/similar) attacking minions out#####################################

                            //help.logg(m.name + " is going to attack!");
                            List<targett> trgts = p.getAttackTargets(true);


                            if (isLethalCheck)// only target enemy hero during Lethal check!
                            {
                                targett trg = trgts.Find(x => x.target == 200);
                                if (trg != null)
                                {
                                    trgts.Clear();
                                    trgts.Add(trg);
                                }
                                else
                                {
                                    // no enemy hero -> enemy have taunts ->kill the taunts from left to right
                                    if (trgts.Count >= 1)
                                    {
                                        trg = trgts[0];
                                        trgts.Clear();
                                        trgts.Add(trg);
                                    }
                                }
                            }
                            else
                            {
                                if (this.useCutingTargets) trgts = this.cutAttackTargets(trgts, p, true);
                            }

                            foreach (targett trgt in trgts)
                            {


                                int attackPenality = 0;

                                if (usePenalityManager)
                                {
                                    attackPenality = pen.getAttackWithMininonPenality(m, p, trgt.target, isLethalCheck);
                                    if (attackPenality <= 499)
                                    {
                                        Playfield pf = new Playfield(p);
                                        havedonesomething = true;
                                        pf.attackWithMinion(m, trgt.target, trgt.targetEntity, attackPenality);
                                        addToPosmoves(pf);
                                    }
                                }
                                else
                                {
                                    Playfield pf = new Playfield(p);
                                    havedonesomething = true;
                                    pf.attackWithMinion(m, trgt.target, trgt.targetEntity, attackPenality);
                                    addToPosmoves(pf);
                                }


                            }
                            if ((!m.stealth || isLethalCheck) && p.enemySecretCount == 0 && trgts.Count == 1 && trgts[0].target == 200)//only enemy hero is available als attack
                            {
                                break;
                            }
                        }

                    }

                    // attack with hero
                    if (p.ownHeroReady)
                    {
                        if (this.calculated > this.totalboards) continue;
                        List<targett> trgts = p.getAttackTargets(true);

                        havedonesomething = true;

                        if (isLethalCheck)// only target enemy hero during Lethal check!
                        {
                            targett trg = trgts.Find(x => x.target == 200);
                            if (trg != null)
                            {
                                trgts.Clear();
                                trgts.Add(trg);
                            }
                            else
                            {
                                // no enemy hero -> enemy have taunts ->kill the taunts from left to right
                                if (trgts.Count >= 1)
                                {
                                    trg = trgts[0];
                                    trgts.Clear();
                                    trgts.Add(trg);
                                }
                            }
                        }
                        else
                        {
                            if (this.useCutingTargets) trgts = this.cutAttackTargets(trgts, p, true);
                        }

                        foreach (targett trgt in trgts)
                        {
                            Playfield pf = new Playfield(p);
                            int heroAttackPen = 0;
                            if (usePenalityManager)
                            {
                                heroAttackPen = pen.getAttackWithHeroPenality(trgt.target, p, isLethalCheck);
                            }
                            pf.attackWithWeapon(trgt.target, trgt.targetEntity, heroAttackPen);
                            addToPosmoves(pf);
                        }
                    }

                    // use ability
                    /// TODO check if ready after manaup
                    if (p.ownAbilityReady && p.mana >= 2 && p.ownHeroAblility.canplayCard(p, 2))
                    {
                        if (this.calculated > this.totalboards) continue;
                        int abilityPenality = 0;

                        havedonesomething = true;
                        // if we have mage or priest, we have to target something####################################################
                        if (p.ownHeroName == HeroEnum.mage || p.ownHeroName == HeroEnum.priest)
                        {

                            List<targett> trgts = p.ownHeroAblility.getTargetsForCard(p);

                            if (isLethalCheck && (p.ownHeroName == HeroEnum.mage || (p.ownHeroName == HeroEnum.priest && p.ownHeroAblility.name != CardDB.cardName.lesserheal)))// only target enemy hero during Lethal check!
                            {
                                targett trg = trgts.Find(x => x.target == 200);
                                if (trg != null)
                                {
                                    trgts.Clear();
                                    trgts.Add(trg);
                                }
                                else
                                {
                                    // no enemy hero -> enemy have taunts ->kill the taunts from left to right
                                    if (trgts.Count >= 1)
                                    {
                                        trg = trgts[0];
                                        trgts.Clear();
                                        trgts.Add(trg);
                                    }
                                }
                            }

                            foreach (targett trgt in trgts)
                            {



                                if (usePenalityManager)
                                {
                                    abilityPenality = pen.getPlayCardPenality(p.ownHeroAblility, trgt.target, p, 0, isLethalCheck);
                                    if (abilityPenality <= 499)
                                    {
                                        Playfield pf = new Playfield(p);
                                        havedonesomething = true;
                                        pf.activateAbility(p.ownHeroAblility, trgt.target, trgt.targetEntity, abilityPenality);
                                        addToPosmoves(pf);
                                    }
                                }
                                else
                                {
                                    Playfield pf = new Playfield(p);
                                    havedonesomething = true;
                                    pf.activateAbility(p.ownHeroAblility, trgt.target, trgt.targetEntity, abilityPenality);
                                    addToPosmoves(pf);
                                }

                            }
                        }
                        else
                        {
                            // the other classes dont have to target####################################################
                            Playfield pf = new Playfield(p);

                            if (usePenalityManager)
                            {
                                abilityPenality = pen.getPlayCardPenality(p.ownHeroAblility, -1, pf, 0, isLethalCheck);
                                if (abilityPenality <= 499)
                                {
                                    havedonesomething = true;
                                    pf.activateAbility(p.ownHeroAblility, -1, -1, abilityPenality);
                                    addToPosmoves(pf);
                                }
                            }
                            else
                            {
                                havedonesomething = true;
                                pf.activateAbility(p.ownHeroAblility, -1, -1, abilityPenality);
                                addToPosmoves(pf);
                            }

                        }

                    }


                    if (isLethalCheck)
                    {
                        p.complete = true;
                    }
                    else
                    {
                        p.endTurn(this.simulateSecondTurn, this.playaround);
                    }

                    //sort stupid stuff ouf

                    if (botBase.getPlayfieldValue(p) > bestoldval)
                    {
                        bestoldval = botBase.getPlayfieldValue(p);
                        bestold = p;
                    }
                    if (!test)
                    {
                        posmoves.Remove(p);
                    }

                    if (this.calculated > this.totalboards) break;
                }

                if (!test && bestoldval >= -10000 && bestold != null)
                {
                    this.posmoves.Add(bestold);
                }

                //Helpfunctions.Instance.loggonoff(true);
                if (this.printNormalstuff)
                {
                    int donec = 0;
                    foreach (Playfield p in posmoves)
                    {
                        if (p.complete) donec++;
                    }
                    Helpfunctions.Instance.logg("deep " + deep + " len " + this.posmoves.Count + " dones " + donec);
                }

                if (!test)
                {
                    cuttingposibilities();
                }

                if (this.printNormalstuff)
                {
                    Helpfunctions.Instance.logg("cut to len " + this.posmoves.Count);
                }
                //Helpfunctions.Instance.loggonoff(false);
                deep++;

                if (this.calculated > this.totalboards) break;
                if (deep >= this.maxdeep) break;//remove this?
            }

            foreach (Playfield p in posmoves)//temp
            {
                if (!p.complete)
                {
                    if (isLethalCheck)
                    {
                        p.complete = true;
                    }
                    else
                    {
                        p.endTurn(this.simulateSecondTurn, this.playaround);
                    }
                }
            }
            // Helpfunctions.Instance.logg("find best ");
            if (posmoves.Count >= 1)
            {
                int bestval = int.MinValue;
                int bestanzactions = 1000;
                Playfield bestplay = posmoves[0];//temp[0]
                foreach (Playfield p in posmoves)//temp
                {
                    int val = botBase.getPlayfieldValue(p);
                    if (bestval <= val)
                    {
                        if (bestval == val && bestanzactions < p.playactions.Count) continue;
                        bestplay = p;
                        bestval = val;
                        bestanzactions = p.playactions.Count;
                    }

                }

                this.bestmove = bestplay.getNextAction();
                this.bestmoveValue = bestval;
                this.bestboard = new Playfield(bestplay);
                //Helpfunctions.Instance.logg("return");
                return bestval;
            }
            //Helpfunctions.Instance.logg("return");
            this.bestmove = null;
            this.bestmoveValue = -100000;
            this.bestboard = playf;
            return -10000;
        }

        public void cuttingposibilities()
        {
            // take the x best values
            int takenumber = this.maxwide;
            List<Playfield> temp = new List<Playfield>();
            posmoves.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));//want to keep the best

            if (this.useComparison)
            {
                int i = 0;
                int max = Math.Min(posmoves.Count, this.maxwide);

                Playfield p = null;
                Playfield pp = null;
                //foreach (Playfield p in posmoves)
                for (i = 0; i < max; i++)
                {
                    p = posmoves[i];
                    int hash = p.GetHashCode();
                    p.hashcode = hash;
                    bool found = false;
                    //foreach (Playfield pp in temp)
                    for (int j = 0; j < temp.Count; j++)
                    {
                        pp = temp[j];
                        if (pp.hashcode == p.hashcode)
                        {
                            if (pp.isEqualf(p))
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found) temp.Add(p);
                    //i++;
                    //if (i >= this.maxwide) break;

                }


            }
            else
            {
                temp.AddRange(posmoves);
            }
            posmoves.Clear();
            posmoves.AddRange(temp.GetRange(0, Math.Min(takenumber, temp.Count)));
            //posmoves.Clear();
            //posmoves.AddRange(Helpfunctions.TakeList(temp, takenumber));

        }

        public List<targett> cutAttackTargets(List<targett> oldlist, Playfield p, bool own)
        {
            List<targett> retvalues = new List<targett>();
            List<Minion> addedmins = new List<Minion>(8);

            bool priomins = false;
            List<targett> retvaluesPrio = new List<targett>();
            foreach (targett t in oldlist)
            {
                if ((own && t.target == 200) || (!own && t.target == 100))
                {
                    retvalues.Add(t);
                    continue;
                }
                if ((own && t.target >= 10 && t.target <= 19) || (!own && t.target >= 0 && t.target <= 9))
                {
                    Minion m = null;
                    if (own) m = p.enemyMinions[t.target - 10];
                    if (!own) m = p.ownMinions[t.target];
                    /*if (penman.priorityDatabase.ContainsKey(m.name))
                    {
                        //retvalues.Add(t);
                        retvaluesPrio.Add(t);
                        priomins = true;
                        //help.logg(m.name + " is added to targetlist");
                        continue;
                    }*/


                    bool goingtoadd = true;
                    List<Minion> temp = new List<Minion>(addedmins);
                    bool isSpecial = pen.specialMinions.ContainsKey(m.name);
                    foreach (Minion mnn in temp)
                    {
                        // special minions are allowed to attack in silended and unsilenced state!
                        //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                        bool otherisSpecial = pen.specialMinions.ContainsKey(mnn.name);

                        if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                        {
                            if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) goingtoadd = false;
                            continue;
                        }

                        if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                        {
                            if (m.name != mnn.name) // different name -> take it
                            {
                                continue;
                            }
                            // same name -> test whether they are equal
                            if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) goingtoadd = false;
                            continue;
                        }

                    }

                    if (goingtoadd)
                    {
                        addedmins.Add(m);
                        retvalues.Add(t);
                        //help.logg(m.name + " " + m.id +" is added to targetlist");
                    }
                    else
                    {
                        //help.logg(m.name + " is not needed to attack");
                        continue;
                    }

                }
            }
            //help.logg("end targetcutting");
            if (priomins) return retvaluesPrio;

            return retvalues;
        }

        public void printPosmoves()
        {
            foreach (Playfield p in this.posmoves)
            {
                p.printBoard();
            }
        }

    }

    public class Handmanager
    {
        public class Cardsposi
        {
            public int Amount = 0;
            public int DetectPosix = 0;
            public int DetectPosiy = 0;
            public int cardsHooverPosx = 0;
            public int cardsHooverdiff = 0;
            public int cardsBigPosx = 0;
            public int cardsBigdiff = 0;
            public int hoovery = 750;
            public int bigreadydetecty = 510;

        }

        public class Handcard
        {
            public int position = 0;
            public int entity = -1;
            public int manacost = 1000;
            public CardDB.Card card;

            public Handcard()
            {
                card = CardDB.Instance.unknownCard;
            }
            public Handcard(Handcard hc)
            {
                this.position = hc.position;
                this.entity = hc.entity;
                this.manacost = hc.manacost;
                this.card = hc.card;
            }
            public Handcard(CardDB.Card c)
            {
                this.position = 0;
                this.entity = -1;
                this.card = c;
            }
            public int getManaCost(Playfield p)
            {
                return this.card.getManaCost(p, this.manacost);
            }
            public bool canplayCard(Playfield p)
            {
                return this.card.canplayCard(p, this.manacost);
            }
        }

        public List<Cardsposi> cardsdata = new List<Cardsposi>();

        public List<Handcard> handCards = new List<Handcard>();

        public int anzcards = 0;

        public int enemyAnzCards = 0;

        private int ownPlayerController = 0;

        Helpfunctions help;
        Cardsposi currentCarddata = new Cardsposi();
        CardDB cdb = CardDB.Instance;

        private static Handmanager instance;

        public static Handmanager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Handmanager();
                }
                return instance;
            }
        }


        private Handmanager()
        {
            this.help = Helpfunctions.Instance;

            int i = 0;
            Cardsposi c = new Cardsposi();
            c.Amount = 1;
            c.DetectPosix = 450;
            c.DetectPosiy = 675;
            c.cardsHooverPosx = 490;
            c.cardsHooverdiff = 1;
            c.cardsBigPosx = 366;
            c.cardsBigdiff = 1;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 2;
            c.DetectPosix = 403;
            c.DetectPosiy = 674;
            c.cardsHooverPosx = 438;
            c.cardsHooverdiff = 100;
            c.cardsBigPosx = 317;
            c.cardsBigdiff = 99;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 3;
            c.DetectPosix = 356;
            c.DetectPosiy = 675;
            c.cardsHooverPosx = 390;
            c.cardsHooverdiff = 100;
            c.cardsBigPosx = 267;
            c.cardsBigdiff = 99;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 4;
            c.DetectPosix = 291;
            c.DetectPosiy = 715;
            c.cardsHooverPosx = 350;
            c.cardsHooverdiff = 90;
            c.cardsBigPosx = 220;
            c.cardsBigdiff = 97;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 5;
            c.DetectPosix = 280;
            c.DetectPosiy = 712;
            c.cardsHooverPosx = 340;
            c.cardsHooverdiff = 75;
            c.cardsBigPosx = 210;
            c.cardsBigdiff = 78;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 6;
            c.DetectPosix = 273;
            c.DetectPosiy = 726;
            c.cardsHooverPosx = 323;
            c.cardsHooverdiff = 65;
            c.cardsBigPosx = 204;
            c.cardsBigdiff = 65;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 7;
            c.DetectPosix = 267;
            c.DetectPosiy = 724;
            c.cardsHooverPosx = 314;
            c.cardsHooverdiff = 56;
            c.cardsBigPosx = 199;
            c.cardsBigdiff = 56;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 8;
            c.DetectPosix = 262;
            c.DetectPosiy = 740;
            c.cardsHooverPosx = 300;
            c.cardsHooverdiff = 47;
            c.cardsBigPosx = 196;
            c.cardsBigdiff = 49;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 9;
            c.DetectPosix = 260;
            c.DetectPosiy = 738;
            c.cardsHooverPosx = 295;
            c.cardsHooverdiff = 42;
            c.cardsBigPosx = 193;
            c.cardsBigdiff = 43;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 10;
            c.DetectPosix = 257;
            c.DetectPosiy = 752;
            c.cardsHooverPosx = 286;
            c.cardsHooverdiff = 38;
            c.cardsBigPosx = 191;
            c.cardsBigdiff = 39;
            this.cardsdata.Add(c);

        }

        public void clearAll()
        {
            this.handCards.Clear();
            this.anzcards = 0;
            this.enemyAnzCards = 0;
            this.ownPlayerController = 0;
        }

        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }



        public Cardsposi getCardposi(int anzcard)
        {
            if (anzcard == 0) return new Cardsposi();
            int k = anzcard - 1;
            Cardsposi returnval = new Cardsposi();
            returnval.Amount = this.cardsdata[k].Amount;
            returnval.cardsBigdiff = this.cardsdata[k].cardsBigdiff;
            returnval.cardsBigPosx = this.cardsdata[k].cardsBigPosx;
            returnval.cardsHooverdiff = this.cardsdata[k].cardsHooverdiff;
            returnval.cardsHooverPosx = this.cardsdata[k].cardsHooverPosx;
            returnval.DetectPosix = this.cardsdata[k].DetectPosix;
            returnval.DetectPosiy = this.cardsdata[k].DetectPosiy;
            return returnval;
        }

        public void setHandcards(List<Handcard> hc, int anzown, int anzenemy)
        {
            this.handCards.Clear();
            foreach (Handcard h in hc)
            {
                this.handCards.Add(new Handcard(h));
            }
            //this.handCards.AddRange(hc);
            this.handCards.Sort((a, b) => a.position.CompareTo(b.position));
            this.anzcards = anzown;
            this.enemyAnzCards = anzenemy;
            this.currentCarddata = this.getCardposi(this.anzcards);
        }


        public void printcards()
        {
            help.logg("Own Handcards: ");
            foreach (Handmanager.Handcard c in this.handCards)
            {
                help.logg("pos " + c.position + " " + c.card.name + " " + c.manacost + " entity " + c.entity + " " + c.card.cardIDenum);
            }
        }


    }

    public enum HeroEnum
    {
        None,
        druid,
        hogger,
        hunter,
        priest,
        warlock,
        thief,
        pala,
        warrior,
        shaman,
        mage,
        lordjaraxxus
    }

    public class Hrtprozis
    {


        public int attackFaceHp = 15;
        public int ownHeroFatigue = 0;
        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int enemyHeroFatigue = 0;

        public int ownHeroEntity = -1;
        public int enemyHeroEntitiy = -1;
        public DateTime roundstart = DateTime.Now;
        bool tempwounded = false;
        public int currentMana = 0;
        public int heroHp = 30, enemyHp = 30;
        public int heroAtk = 0, enemyAtk = 0;
        public int heroDefence = 0, enemyDefence = 0;
        public bool ownheroisread = false;
        public bool ownAbilityisReady = false;
        public int ownHeroNumAttacksThisTurn = 0;
        public bool ownHeroWindfury = false;

        public List<CardDB.cardIDEnum> ownSecretList = new List<CardDB.cardIDEnum>();
        public int enemySecretCount = 0;



        public HeroEnum heroname = HeroEnum.druid, enemyHeroname = HeroEnum.druid;
        public CardDB.Card heroAbility;
        public CardDB.Card enemyAbility;
        public int anzEnemys = 0;
        public int anzOwn = 0;
        public bool herofrozen = false;
        public bool enemyfrozen = false;
        public int numMinionsPlayedThisTurn = 0;
        public int cardsPlayedThisTurn = 0;
        public int ueberladung = 0;

        public int ownMaxMana = 0;
        public int enemyMaxMana = 0;

        public int enemyWeaponDurability = 0;
        public int enemyWeaponAttack = 0;
        public CardDB.cardName enemyHeroWeapon = CardDB.cardName.unknown;

        public int heroWeaponDurability = 0;
        public int heroWeaponAttack = 0;
        public CardDB.cardName ownHeroWeapon = CardDB.cardName.unknown;
        public bool heroImmuneToDamageWhileAttacking = false;
        public bool heroImmune = false;
        public bool enemyHeroImmune = false;

        public bool minionsFailure = false;

        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();

        int manadiff = 23;

        int detectmin = 30, detectmax = 130;

        Helpfunctions help = Helpfunctions.Instance;
        //Imagecomparer icom = Imagecomparer.Instance;
        //HrtNumbers hrtnumbers = HrtNumbers.Instance;
        CardDB cdb = CardDB.Instance;

        private int ownPlayerController = 0;

        private static Hrtprozis instance;

        public static Hrtprozis Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Hrtprozis();
                }
                return instance;
            }
        }



        private Hrtprozis()
        {
        }

        public void setAttackFaceHP(int hp)
        {
            this.attackFaceHp = hp;
        }

        public void clearAll()
        {
            ownHeroEntity = -1;
            enemyHeroEntitiy = -1;
            tempwounded = false;
            currentMana = 0;
            heroHp = 30;
            enemyHp = 30;
            heroAtk = 0;
            enemyAtk = 0;
            heroDefence = 0; enemyDefence = 0;
            ownheroisread = false;
            ownAbilityisReady = false;
            ownHeroNumAttacksThisTurn = 0;
            ownHeroWindfury = false;
            ownSecretList.Clear();
            enemySecretCount = 0;
            heroname = HeroEnum.druid;
            enemyHeroname = HeroEnum.druid;
            heroAbility = new CardDB.Card();
            enemyAbility = new CardDB.Card();
            anzEnemys = 0;
            anzOwn = 0;
            herofrozen = false;
            enemyfrozen = false;
            numMinionsPlayedThisTurn = 0;
            cardsPlayedThisTurn = 0;
            ueberladung = 0;
            ownMaxMana = 0;
            enemyMaxMana = 0;
            enemyWeaponDurability = 0;
            enemyWeaponAttack = 0;
            heroWeaponDurability = 0;
            heroWeaponAttack = 0;
            heroImmuneToDamageWhileAttacking = false;
            ownMinions.Clear();
            enemyMinions.Clear();
            heroImmune = false;
            enemyHeroImmune = false;
            this.ownHeroWeapon = CardDB.cardName.unknown;
            this.enemyHeroWeapon = CardDB.cardName.unknown;
        }


        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }

        public int getOwnController()
        {
            return this.ownPlayerController;
        }

        public string heroIDtoName(string s)
        {
            string retval = "druid";

            if (s == "XXX_040")
            {
                retval = "hogger";
            }
            if (s == "HERO_05")
            {
                retval = "hunter";
            }
            if (s == "HERO_09")
            {
                retval = "priest";
            }
            if (s == "HERO_06")
            {
                retval = "druid";
            }
            if (s == "HERO_07")
            {
                retval = "warlock";
            }
            if (s == "HERO_03")
            {
                retval = "thief";
            }
            if (s == "HERO_04")
            {
                retval = "pala";
            }
            if (s == "HERO_01")
            {
                retval = "warrior";
            }
            if (s == "HERO_02")
            {
                retval = "shaman";
            }
            if (s == "HERO_08")
            {
                retval = "mage";
            }
            if (s == "EX1_323h")
            {
                retval = "lordjaraxxus";
            }

            return retval;
        }

        public HeroEnum heroNametoEnum(string s)
        {

            if (s == "hogger")
            {
                return HeroEnum.hogger;
            }
            if (s == "hunter")
            {
                return HeroEnum.hunter;
            }
            if (s == "priest")
            {
                return HeroEnum.priest;
            }
            if (s == "druid")
            {
                return HeroEnum.druid;
            }
            if (s == "warlock")
            {
                return HeroEnum.warlock;
            }
            if (s == "thief")
            {
                return HeroEnum.thief;
            }
            if (s == "pala")
            {
                return HeroEnum.pala;
            }
            if (s == "warrior")
            {
                return HeroEnum.warrior;
            }
            if (s == "shaman")
            {
                return HeroEnum.shaman;
            }
            if (s == "mage")
            {
                return HeroEnum.mage;
            }
            if (s == "lordjaraxxus")
            {
                return HeroEnum.lordjaraxxus;
            }

            return HeroEnum.None;
        }


        public void updateMinions(List<Minion> om, List<Minion> em)
        {
            this.ownMinions.Clear();
            this.enemyMinions.Clear();
            foreach (var item in om)
            {
                this.ownMinions.Add(new Minion(item));
            }
            //this.ownMinions.AddRange(om);
            foreach (var item in em)
            {
                this.enemyMinions.Add(new Minion(item));
            }
            //this.enemyMinions.AddRange(em);

            //sort them 
            updatePositions();
        }

        public void updateSecretStuff(List<string> ownsecs, int numEnemSec)
        {
            this.ownSecretList.Clear();
            foreach (string s in ownsecs)
            {
                this.ownSecretList.Add(CardDB.Instance.cardIdstringToEnum(s));
            }
            this.enemySecretCount = numEnemSec;
        }

        public void updatePlayer(int maxmana, int currentmana, int cardsplayedthisturn, int numMinionsplayed, int recall, int heroentity, int enemyentity)
        {
            this.currentMana = currentmana;
            this.ownMaxMana = maxmana;
            this.cardsPlayedThisTurn = cardsplayedthisturn;
            this.numMinionsPlayedThisTurn = numMinionsplayed;
            this.ueberladung = recall;
            this.ownHeroEntity = heroentity;
            this.enemyHeroEntitiy = enemyentity;


        }

        public void updateOwnHero(string weapon, int watt, int wdur, bool heroimunewhileattack, int heroatt, int herohp, int herodef, string heron, bool heroready, bool frozen, CardDB.Card hab, bool habrdy, int numAttacksTTurn, bool windfury, bool hisim)
        {
            this.ownHeroWeapon = CardDB.Instance.cardNamestringToEnum(weapon);
            this.heroWeaponAttack = watt;
            this.heroWeaponDurability = wdur;
            this.heroImmuneToDamageWhileAttacking = heroimunewhileattack;
            this.heroAtk = heroatt;
            this.heroHp = herohp;
            this.heroDefence = herodef;
            this.heroname = this.heroNametoEnum(heron);
            this.ownheroisread = heroready;
            this.herofrozen = frozen;
            this.heroAbility = hab;
            this.ownAbilityisReady = habrdy;
            this.ownHeroWindfury = windfury;
            this.ownHeroNumAttacksThisTurn = numAttacksTTurn;
            this.heroImmune = hisim;
        }

        public void updateEnemyHero(string weapon, int watt, int wdur, int heroatt, int herohp, int herodef, string heron, bool frozen, CardDB.Card eab, bool ehisim, int enemMM)
        {
            this.enemyHeroWeapon = CardDB.Instance.cardNamestringToEnum(weapon);
            this.enemyWeaponAttack = watt;
            this.enemyWeaponDurability = wdur;
            this.enemyAtk = heroatt;
            this.enemyHp = herohp;
            this.enemyHeroname = this.heroNametoEnum(heron);
            this.enemyDefence = herodef;
            this.enemyfrozen = frozen;
            this.enemyAbility = eab;
            this.enemyHeroImmune = ehisim;
            this.enemyMaxMana = enemMM;
        }

        public void updateFatigueStats(int ods, int ohf, int eds, int ehf)
        {
            this.ownDeckSize = 30;// ods;
            this.ownHeroFatigue = ohf;
            this.enemyDeckSize = 30;// eds;
            this.enemyHeroFatigue = ehf;
        }

        public void updatePositions()
        {
            this.ownMinions.Sort((a, b) => a.zonepos.CompareTo(b.zonepos));
            this.enemyMinions.Sort((a, b) => a.zonepos.CompareTo(b.zonepos));
            int i = 0;
            foreach (Minion m in this.ownMinions)
            {
                m.id = i;
                i++;
                m.zonepos = i;

            }
            i = 0;
            foreach (Minion m in this.enemyMinions)
            {
                m.id = i;
                i++;
                m.zonepos = i;
            }

            /*List<Minion> temp = new List<Minion>();
            temp.AddRange(ownMinions);
            this.ownMinions.Clear();
            this.ownMinions.AddRange(temp.OrderBy(x => x.zonepos).ToList());
            temp.Clear();
            temp.AddRange(enemyMinions);
            this.enemyMinions.Clear();
            this.enemyMinions.AddRange(temp.OrderBy(x => x.zonepos).ToList());*/

        }

        private Minion createNewMinion(Handmanager.Handcard hc, int id)
        {
            Minion m = new Minion();
            m.handcard = new Handmanager.Handcard(hc);
            m.id = id;
            m.zonepos = id + 1;
            m.entitiyID = hc.entity;
            m.Posix = 0;
            m.Posiy = 0;
            m.Angr = hc.card.Attack;
            m.Hp = hc.card.Health;
            m.maxHp = hc.card.Health;
            m.name = hc.card.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;


            if (hc.card.windfury) m.windfury = true;
            if (hc.card.tank) m.taunt = true;
            if (hc.card.Charge)
            {
                m.Ready = true;
                m.charge = true;
            }
            if (hc.card.Shield) m.divineshild = true;
            if (hc.card.poisionous) m.poisonous = true;

            if (hc.card.Stealth) m.stealth = true;

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }


            return m;
        }


        public void printHero()
        {
            help.logg("player:");
            help.logg(this.numMinionsPlayedThisTurn + " " + this.cardsPlayedThisTurn + " " + this.ueberladung + " " + this.ownPlayerController);

            help.logg("ownhero:");
            help.logg(this.heroname + " " + heroHp + " " + heroDefence + " " + this.heroImmuneToDamageWhileAttacking + " " + this.heroImmune);
            help.logg("ready: " + this.ownheroisread + " alreadyattacked: " + this.ownHeroNumAttacksThisTurn + " frzn: " + this.herofrozen + " attack: " + heroAtk + " " + heroWeaponAttack + " " + heroWeaponDurability + " " + ownHeroWeapon);
            help.logg("ability: " + this.ownAbilityisReady + " " + this.heroAbility.cardIDenum);
            string secs = "";
            foreach (CardDB.cardIDEnum sec in this.ownSecretList)
            {
                secs += sec + " ";
            }
            help.logg("osecrets: " + secs);
            help.logg("enemyhero:");
            help.logg(this.enemyHeroname + " " + enemyHp + " " + enemyDefence + " " + this.enemyfrozen + " " + this.enemyHeroImmune);
            help.logg(this.enemyWeaponAttack + " " + this.enemyWeaponDurability + " " + this.enemyHeroWeapon);
            help.logg("ability: " + "true" + " " + this.enemyAbility.cardIDenum);
            help.logg("fatigue: " + this.ownDeckSize + " " + this.ownHeroFatigue + " " + this.enemyDeckSize + " " + this.enemyHeroFatigue);

        }


        public void printOwnMinions()
        {
            help.logg("OwnMinions:");
            foreach (Minion m in this.ownMinions)
            {
                help.logg(m.name + " " + m.handcard.card.cardIDenum + " id:" + m.id + " zp:" + m.zonepos + " e:" + m.entitiyID + " A:" + m.Angr + " H:" + m.Hp + " mH:" + m.maxHp + " rdy:" + m.Ready + " tnt:" + m.taunt + " frz:" + m.frozen + " silenced:" + m.silenced + " divshield:" + m.divineshild + " ptt:" + m.playedThisTurn + " wndfr:" + m.windfury + " natt:" + m.numAttacksThisTurn + " stl:" + m.stealth + " poi:" + m.poisonous + " imm:" + m.immune + " ex:" + m.exhausted + " chrg:" + m.charge);
                foreach (Enchantment e in m.enchantments)
                {
                    help.logg(e.CARDID + " " + e.creator + " " + e.controllerOfCreator);
                }
            }

        }

        public void printEnemyMinions()
        {
            help.logg("EnemyMinions:");
            foreach (Minion m in this.enemyMinions)
            {
                help.logg(m.name + " " + m.handcard.card.cardIDenum + " id:" + m.id + " zp:" + m.zonepos + " e:" + m.entitiyID + " A:" + m.Angr + " H:" + m.Hp + " mH:" + m.maxHp + " rdy:" + m.Ready + " tnt:" + m.taunt + " frz:" + m.frozen + " silenced:" + m.silenced + " divshield:" + m.divineshild + " wndfr:" + m.windfury + " stl:" + m.stealth + " poi:" + m.poisonous + " imm:" + m.immune + " ex:" + m.exhausted + " chrg:" + m.charge);
                foreach (Enchantment e in m.enchantments)
                {
                    help.logg(e.CARDID + " " + e.creator + " " + e.controllerOfCreator);
                }
            }

        }


    }

    public class PenalityManager
    {
        //todo acolyteofpain
        //todo better aoe-penality

        ComboBreaker cb;

        public Dictionary<CardDB.cardName, int> priorityDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> HealTargetDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> HealHeroDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> HealAllDatabase = new Dictionary<CardDB.cardName, int>();

        public Dictionary<CardDB.cardName, int> DamageTargetDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> DamageTargetSpecialDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageAllDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageHeroDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageRandomDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageAllEnemysDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> enrageDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> silenceDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> heroAttackBuffDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> attackBuffDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> healthBuffDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> tauntBuffDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> cardDrawBattleCryDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> cardDiscardDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> destroyOwnDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> destroyDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> buffingMinionsDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> buffing1TurnDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> heroDamagingAoeDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> randomEffects = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> returnHandDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> priorityTargets = new Dictionary<CardDB.cardName, int>();

        public Dictionary<CardDB.cardName, int> specialMinions = new Dictionary<CardDB.cardName, int>(); //minions with cardtext, but no battlecry


        private static PenalityManager instance;

        public static PenalityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PenalityManager();
                }
                return instance;
            }
        }

        private PenalityManager()
        {
            setupHealDatabase();
            setupEnrageDatabase();
            setupDamageDatabase();
            setupPriorityList();
            setupsilenceDatabase();
            setupAttackBuff();
            setupHealthBuff();
            setupCardDrawBattlecry();
            setupDiscardCards();
            setupDestroyOwnCards();
            setupSpecialMins();
            setupEnemyTargetPriority();
            setupHeroDamagingAOE();
            setupBuffingMinions();
            setupRandomCards();
        }

        public void setCombos()
        {
            this.cb = ComboBreaker.Instance;
        }

        public int getAttackWithMininonPenality(Minion m, Playfield p, int target, bool lethal)
        {
            int pen = 0;
            pen = getAttackSecretPenality(m, p, target);
            if (!lethal && m.name == CardDB.cardName.bloodimp) pen = 50;
            if (m.name == CardDB.cardName.leeroyjenkins)
            {
                if (target >= 10 && target <= 19)
                {
                    Minion t = p.enemyMinions[target - 10];
                    if (t.name == CardDB.cardName.whelp) return 500;
                }

            }
            return pen;
        }

        public int getAttackWithHeroPenality(int target, Playfield p, bool leathal)
        {
            int retval = 0;

            if (!leathal && p.ownWeaponName == CardDB.cardName.swordofjustice)
            {
                return 28;
            }

            if (p.ownWeaponDurability == 1 && p.ownWeaponName == CardDB.cardName.eaglehornbow)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.arcaneshot || hc.card.name == CardDB.cardName.killcommand) return -p.ownWeaponAttack - 1;
                }
                if (p.ownSecretsIDList.Count >= 1) return 20;

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.Secret) return 20;
                }
            }

            //no penality, but a bonus, if he has weapon on hand!
            if (target == 200 && p.ownWeaponName == CardDB.cardName.gorehowl && p.ownWeaponAttack >= 3)
            {
                return 10;
            }
            if (p.ownWeaponDurability >= 1)
            {
                bool hasweapon = false;
                foreach (Handmanager.Handcard c in p.owncards)
                {
                    if (c.card.type == CardDB.cardtype.WEAPON) hasweapon = true;
                }
                if (p.ownWeaponAttack == 1 && p.ownHeroName == HeroEnum.thief) hasweapon = true;
                if (hasweapon) retval = -p.ownWeaponAttack - 1; // so he doesnt "lose" the weapon in evaluation :D
            }
            if (p.ownWeaponAttack == 1 && p.ownHeroName == HeroEnum.thief) retval += -1;
            return retval;
        }

        public int getPlayCardPenality(CardDB.Card card, int target, Playfield p, int choice, bool lethal)
        {
            int retval = 0;
            CardDB.cardName name = card.name;
            //there is no reason to buff HP of minon (because it is not healed)

            int abuff = getAttackBuffPenality(card, target, p, choice, lethal);
            int tbuff = getTauntBuffPenality(name, target, p, choice);
            if (name == CardDB.cardName.markofthewild && ((abuff >= 500 && tbuff == 0) || (abuff == 0 && tbuff >= 500)))
            {
                retval = 0;
            }
            else
            {
                retval += abuff + tbuff;
            }
            retval += getHPBuffPenality(card, target, p, choice);
            retval += getSilencePenality(name, target, p, choice, lethal);
            retval += getDamagePenality(name, target, p, choice, lethal);
            retval += getHealPenality(name, target, p, choice, lethal);
            retval += getCardDrawPenality(name, target, p, choice);
            retval += getCardDrawofEffectMinions(card, p);
            //retval += getCardDiscardPenality( name,  p);
            retval += getDestroyOwnPenality(name, target, p, lethal);

            retval += getDestroyPenality(name, target, p, lethal);
            retval += getSpecialCardComboPenalitys(card, target, p, lethal, choice);
            retval += playSecretPenality(card, p);
            retval += getPlayCardSecretPenality(card, p);
            retval += getRandomPenaltiy(card, p, target);
            if (!lethal)
            {
                retval += cb.getPenalityForDestroyingCombo(card, p);
                retval += cb.getPlayValue(card.cardIDenum);
            }

            return retval;
        }

        private int getAttackBuffPenality(CardDB.Card card, int target, Playfield p, int choice, bool lethal)
        {
            CardDB.cardName name = card.name;
            int pen = 0;
            //buff enemy?

            if (!lethal && (card.name == CardDB.cardName.savageroar || card.name == CardDB.cardName.bloodlust))
            {
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Ready) targets++;
                }
                if ((p.ownHeroReady || p.ownHeroNumAttackThisTurn == 0) && card.name == CardDB.cardName.savageroar) targets++;

                if (targets <= 2)
                {
                    return 20;
                }
            }

            if (!this.attackBuffDatabase.ContainsKey(name)) return 0;
            if (target >= 10 && target <= 19)
            {
                if (card.type == CardDB.cardtype.MOB && p.ownMinions.Count == 0) return 0;
                //allow it if you have biggamehunter
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.biggamehunter) return pen;
                    if (hc.card.name == CardDB.cardName.shadowworddeath) return pen;
                }
                if (card.name == CardDB.cardName.crueltaskmaster || card.name == CardDB.cardName.innerrage)
                {
                    Minion m = p.enemyMinions[target - 10];

                    if (m.Hp == 1)
                    {
                        return 0;
                    }

                    if (!m.wounded && (m.Angr >= 4 || m.Hp >= 5))
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.execute) return 0;
                        }
                    }
                    pen = 30;
                }
                else
                {
                    pen = 500;
                }
            }
            if (target >= 0 && target <= 9)
            {
                Minion m = p.ownMinions[target];
                if (!m.Ready)
                {
                    return 50;
                }
                if (m.Hp == 1 && !m.divineshild && !this.buffing1TurnDatabase.ContainsKey(name))
                {
                    return 10;
                }
            }
            return pen;
        }

        private int getHPBuffPenality(CardDB.Card card, int target, Playfield p, int choice)
        {
            CardDB.cardName name = card.name;
            int pen = 0;
            //buff enemy?
            if (!this.healthBuffDatabase.ContainsKey(name)) return 0;
            if (target >= 10 && target <= 19 && !this.tauntBuffDatabase.ContainsKey(name))
            {
                pen = 500;
            }

            return pen;
        }


        private int getTauntBuffPenality(CardDB.cardName name, int target, Playfield p, int choice)
        {
            int pen = 0;
            //buff enemy?
            if (!this.tauntBuffDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.cardName.markofnature && choice != 2) return 0;

            if (target >= 10 && target <= 19)
            {
                //allow it if you have black knight
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.theblackknight) return 0;
                }

                // allow taunting if target is priority and others have taunt
                bool enemyhasTaunts = false;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.taunt)
                    {
                        enemyhasTaunts = true;
                        break;
                    }
                }
                Minion m = p.enemyMinions[target - 10];
                if (enemyhasTaunts && this.priorityDatabase.ContainsKey(m.name))
                {
                    return 0;
                }

                pen = 500;
            }

            return pen;
        }

        private int getSilencePenality(CardDB.cardName name, int target, Playfield p, int choice, bool lethal)
        {
            int pen = 0;
            if (name == CardDB.cardName.keeperofthegrove && choice != 2) return 0; // look at damage penality in this case

            if (target >= 0 && target <= 9)
            {
                if (this.silenceDatabase.ContainsKey(name))
                {
                    // no pen if own is enrage
                    Minion m = p.ownMinions[target];

                    if ((!m.silenced && (m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord)) || m.Angr < m.handcard.card.Attack || m.maxHp < m.handcard.card.Health || (m.frozen && !m.playedThisTurn && m.numAttacksThisTurn == 0))
                    {
                        return 0;
                    }


                    pen += 500;
                }
            }

            if (target == -1)
            {
                if (name == CardDB.cardName.ironbeakowl || name == CardDB.cardName.spellbreaker)
                {

                    return 20;
                }
            }

            if (target >= 10 && target <= 19)
            {
                if (this.silenceDatabase.ContainsKey(name))
                {
                    // no pen if own is enrage
                    Minion m = p.enemyMinions[target - 10];//

                    if (!m.silenced && (m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord))
                    {
                        return 500;
                    }

                    if (lethal)
                    {
                        //during lethal we only silence taunt, or if its a mob (owl/spellbreaker) + we can give him charge
                        if (m.taunt || (name == CardDB.cardName.ironbeakowl && (p.ownMinions.Find(x => x.name == CardDB.cardName.tundrarhino) != null || p.ownMinions.Find(x => x.name == CardDB.cardName.warsongcommander) != null || p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null)) || (name == CardDB.cardName.spellbreaker && p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null)) return 0;

                        return 500;
                    }
                    if (m.handcard.card.name == CardDB.cardName.venturecomercenary && !m.silenced && (m.Angr <= m.handcard.card.Attack && m.maxHp <= m.handcard.card.Health))
                    {
                        return 30;
                    }

                    if (priorityDatabase.ContainsKey(m.name) && !m.silenced)
                    {
                        return -10;
                    }

                    //silence nothing
                    if (m.Angr <= m.handcard.card.Attack && m.maxHp <= m.handcard.card.Health && !m.taunt && !m.windfury && !m.divineshild && !m.poisonous && m.enchantments.Count == 0 && !this.specialMinions.ContainsKey(name))
                    {
                        return 30;
                    }



                    pen = 0;
                }
            }

            return pen;

        }

        private int getDamagePenality(CardDB.cardName name, int target, Playfield p, int choice, bool lethal)
        {
            int pen = 0;

            if (name == CardDB.cardName.shieldslam && p.ownHeroDefence == 0) return 500;
            if (name == CardDB.cardName.savagery && p.ownheroAngr == 0) return 500;
            if (name == CardDB.cardName.keeperofthegrove && choice != 1) return 0; // look at silence penality

            if (this.DamageAllDatabase.ContainsKey(name) || (p.auchenaiseelenpriesterin && HealAllDatabase.ContainsKey(name))) // aoe penality
            {

                foreach (Minion m in p.enemyMinions)
                {
                    if ((m.Angr >= 4 || m.Hp >= 5) && !m.wounded)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.execute) return 0;
                        }
                    }
                }

                if (p.enemyMinions.Count <= 1 || p.enemyMinions.Count + 1 <= p.ownMinions.Count || p.ownMinions.Count >= 3)
                {
                    return 30;
                }
            }

            if (this.DamageAllEnemysDatabase.ContainsKey(name)) // aoe penality
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if ((m.Angr >= 4 || m.Hp >= 5) && !m.wounded)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.execute) return 0;
                        }
                    }
                }

                if (name == CardDB.cardName.holynova)
                {
                    int targets = p.enemyMinions.Count;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.wounded) targets++;
                    }
                    if (targets <= 2)
                    {
                        return 20;
                    }

                }
                if (p.enemyMinions.Count <= 2)
                {
                    return 20 * (3 - p.enemyMinions.Count);
                }
            }

            if (target == 100)
            {
                if (DamageTargetDatabase.ContainsKey(name) || DamageTargetSpecialDatabase.ContainsKey(name) || (p.auchenaiseelenpriesterin && HealTargetDatabase.ContainsKey(name)))
                {
                    pen = 500;
                }
            }

            if (!lethal && target == 200)
            {
                if (name == CardDB.cardName.baneofdoom)
                {
                    pen = 500;
                }
            }

            if (target >= 0 && target <= 9)
            {
                if (DamageTargetDatabase.ContainsKey(name) || (p.auchenaiseelenpriesterin && HealTargetDatabase.ContainsKey(name)))
                {
                    // no pen if own is enrage
                    Minion m = p.ownMinions[target];

                    //standard ones :D (mostly carddraw
                    if (enrageDatabase.ContainsKey(m.name) && !m.wounded && m.Ready)
                    {
                        return pen;
                    }

                    // no pen if we have battlerage for example
                    int dmg = 0;
                    if (DamageTargetDatabase.ContainsKey(name))
                    {
                        dmg = DamageTargetDatabase[name];
                    }
                    else
                    {
                        dmg = HealTargetDatabase[name];
                    }
                    if (m.handcard.card.deathrattle) return 10;
                    if (m.Hp > dmg)
                    {
                        if (m.name == CardDB.cardName.acolyteofpain && p.owncards.Count <= 3) return 0;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.battlerage) return pen;
                            if (hc.card.name == CardDB.cardName.rampage) return pen;
                        }
                    }


                    pen = 500;
                }

                //special cards
                if (DamageTargetSpecialDatabase.ContainsKey(name))
                {
                    int dmg = DamageTargetSpecialDatabase[name];
                    Minion m = p.ownMinions[target];
                    if ((name == CardDB.cardName.crueltaskmaster || name == CardDB.cardName.innerrage) && m.Hp >= 2) return 0;
                    if (name == CardDB.cardName.demonfire && (TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) return 0;
                    if (name == CardDB.cardName.earthshock && m.Hp >= 2)
                    {
                        if (priorityDatabase.ContainsKey(m.name) && !m.silenced)
                        {
                            return 500;
                        }

                        if ((!m.silenced && (m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord)) || m.Angr < m.handcard.card.Attack || m.maxHp < m.handcard.card.Health || (m.frozen && !m.playedThisTurn && m.numAttacksThisTurn == 0))
                            return 0;
                    }
                    if (name == CardDB.cardName.earthshock)//dont silence other own minions
                    {
                        return 500;
                    }

                    // no pen if own is enrage
                    if (enrageDatabase.ContainsKey(m.name) && !m.wounded)
                    {
                        return pen;
                    }

                    // no pen if we have battlerage for example

                    if (m.Hp > dmg)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.battlerage) return pen;
                            if (hc.card.name == CardDB.cardName.rampage) return pen;
                        }
                    }

                    pen = 500;
                }
            }
            if (target >= 10 && target <= 19)
            {
                if (DamageTargetSpecialDatabase.ContainsKey(name) || DamageTargetDatabase.ContainsKey(name))
                {
                    Minion m = p.enemyMinions[target - 10];
                    if (name == CardDB.cardName.soulfire && m.maxHp <= 2) pen = 10;

                    if (name == CardDB.cardName.baneofdoom && m.Hp >= 3) pen = 10;

                    if (name == CardDB.cardName.shieldslam && (m.Hp <= 4 || m.Angr <= 4)) pen = 20;
                }
            }

            return pen;
        }

        private int getHealPenality(CardDB.cardName name, int target, Playfield p, int choice, bool lethal)
        {
            ///Todo healpenality for aoe heal
            ///todo auchenai soulpriest
            if (p.auchenaiseelenpriesterin) return 0;
            if (name == CardDB.cardName.ancientoflore && choice != 2) return 0;
            int pen = 0;
            int heal = 0;
            /*if (HealHeroDatabase.ContainsKey(name))
            {
                heal = HealHeroDatabase[name];
                if (target == 200) pen = 500; // dont heal enemy
                if ((target == 100 || target == -1) && p.ownHeroHp + heal > 30) pen = p.ownHeroHp + heal - 30;
            }*/

            if (name == CardDB.cardName.circleofhealing)
            {
                int mheal = 0;
                int wounded = 0;
                foreach (Minion mi in p.ownMinions)
                {
                    mheal += Math.Min((mi.maxHp - mi.Hp), 4);
                    if (mi.wounded) wounded++;
                }
                if (mheal <= 7 && wounded <= 2) return 20;
            }

            if (HealTargetDatabase.ContainsKey(name))
            {
                heal = HealTargetDatabase[name];
                if (target == 200) return 500; // dont heal enemy
                if ((target == 100) && p.ownHeroHp == 30) return 150;
                if ((target == 100) && p.ownHeroHp + heal > 30) pen = p.ownHeroHp + heal - 30;
                Minion m = new Minion();

                if (target >= 0 && target < 10)
                {
                    m = p.ownMinions[target];
                    int wasted = 0;
                    if (m.Hp == m.maxHp) return 500;
                    if (m.Hp + heal - 1 > m.maxHp) wasted = m.Hp + heal - m.maxHp;
                    pen = wasted;

                    if (m.taunt && wasted <= 2 && m.Hp < m.maxHp) pen -= 5; // if we heal a taunt, its good :D

                    if (m.Hp + heal <= m.maxHp) pen = -1;
                }

                if (target >= 10 && target < 20)
                {
                    m = p.enemyMinions[target - 10];
                    if (m.Hp == m.maxHp) return 500;
                    // no penality if we heal enrage enemy
                    if (enrageDatabase.ContainsKey(m.name))
                    {
                        return pen;
                    }
                    // no penality if we have heal-trigger :D
                    int i = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.name == CardDB.cardName.northshirecleric) i++;
                        if (mnn.name == CardDB.cardName.lightwarden) i++;
                    }
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.name == CardDB.cardName.northshirecleric) i--;
                        if (mnn.name == CardDB.cardName.lightwarden) i--;
                    }
                    if (i >= 1) return pen;

                    // no pen if we have slam

                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardDB.cardName.slam && m.Hp < 2) return pen;
                        if (hc.card.name == CardDB.cardName.backstab) return pen;
                    }

                    pen = 500;
                }


            }

            return pen;
        }

        private int getCardDrawPenality(CardDB.cardName name, int target, Playfield p, int choice)
        {
            // penality if carddraw is late or you have enough cards
            int pen = 0;
            if (!cardDrawBattleCryDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.cardName.ancientoflore && choice != 1) return 0;
            if (name == CardDB.cardName.wrath && choice != 2) return 0;
            if (name == CardDB.cardName.nourish && choice != 2) return 0;
            int carddraw = cardDrawBattleCryDatabase[name];
            if (name == CardDB.cardName.harrisonjones)
            {
                carddraw = p.enemyWeaponDurability;
                if (carddraw == 0 && (p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.warlock && p.enemyHeroName != HeroEnum.priest)) return 5;
            }
            if (name == CardDB.cardName.divinefavor)
            {
                carddraw = p.enemyAnzCards + p.enemycarddraw - (p.owncards.Count);
                if (carddraw == 0) return 500;
            }

            if (name == CardDB.cardName.battlerage)
            {
                carddraw = 0;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.wounded) carddraw++;
                }
                if (carddraw == 0) return 500;
            }

            if (name == CardDB.cardName.slam)
            {
                Minion m = new Minion();
                if (target >= 0 && target <= 9)
                {
                    m = p.ownMinions[target];
                }
                if (target >= 10 && target <= 19)
                {
                    m = p.enemyMinions[target - 10];
                }
                carddraw = 0;
                if (m.Hp >= 3) carddraw = 1;
                if (carddraw == 0) return 4;
            }

            if (name == CardDB.cardName.mortalcoil)
            {
                Minion m = new Minion();
                if (target >= 0 && target <= 9)
                {
                    m = p.ownMinions[target];
                }
                if (target >= 10 && target <= 19)
                {
                    m = p.enemyMinions[target - 10];
                }
                carddraw = 0;
                if (m.Hp == 1) carddraw = 1;
                if (carddraw == 0) return 15;
            }

            if (name == CardDB.cardName.lifetap)
            {
                return Math.Max(-carddraw + 2 * p.playactions.Count + p.ownMaxMana - p.mana, 0);
            }

            if (p.owncards.Count + carddraw > 10) return 15 * (p.owncarddraw + p.owncards.Count - 10);
            if (p.owncards.Count + p.cardsPlayedThisTurn > 5) return 5;

            return -carddraw + 2 * p.playactions.Count + p.ownMaxMana - p.mana;
            /*pen = -carddraw + p.ownMaxMana - p.mana;
            return pen;*/
        }

        private int getCardDrawofEffectMinions(CardDB.Card card, Playfield p)
        {
            int pen = 0;
            int carddraw = 0;
            if (card.type == CardDB.cardtype.SPELL)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.cardName.gadgetzanauctioneer) carddraw++;
                }
            }

            if (card.type == CardDB.cardtype.MOB && (TAG_RACE)card.race == TAG_RACE.PET)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.cardName.starvingbuzzard) carddraw++;
                }
            }

            if (carddraw == 0) return 0;

            if (p.owncards.Count >= 5) return 0;
            pen = -carddraw + p.ownMaxMana - p.mana + p.playactions.Count;

            return pen;
        }

        private int getRandomPenaltiy(CardDB.Card card, Playfield p, int target)
        {
            if (!this.randomEffects.ContainsKey(card.name)) return 0;
            if (card.name == CardDB.cardName.brawl && p.playactions.Count >= 1 && p.enemyHeroName != HeroEnum.mage) return 100;
            if ((card.name == CardDB.cardName.cleave || card.name == CardDB.cardName.multishot) && p.enemyMinions.Count == 2) return 0;
            if ((card.name == CardDB.cardName.deadlyshot) && p.enemyMinions.Count == 1) return 0;
            if ((card.name == CardDB.cardName.arcanemissiles || card.name == CardDB.cardName.avengingwrath) && p.enemyMinions.Count == 0) return 0;
            int cards = randomEffects[card.name];
            bool first = true;
            bool hasgadget = false;
            bool hasstarving = false;
            bool hasknife = false;
            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.name == CardDB.cardName.gadgetzanauctioneer) hasgadget = true;
                if (mnn.name == CardDB.cardName.starvingbuzzard) hasstarving = true;
                if (mnn.name == CardDB.cardName.knifejuggler) hasknife = true;
            }
            foreach (Action a in p.playactions)
            {
                if (a.heroattack)
                {
                    first = false;
                    continue;
                }
                if (a.useability && p.ownHeroName != HeroEnum.shaman)
                {
                    first = false;
                    continue;
                }
                if (a.minionplay)
                {
                    first = false;
                    continue;
                }
                if (a.cardplay)
                {
                    if (card.name == CardDB.cardName.knifejuggler && card.type == CardDB.cardtype.MOB)
                    {
                        first = false;
                        continue;
                    }
                    if (cardDrawBattleCryDatabase.ContainsKey(a.handcard.card.name)) continue;
                    if (hasgadget && card.type == CardDB.cardtype.SPELL) continue;
                    if (hasstarving && (TAG_RACE)card.race == TAG_RACE.PET) continue;
                    if (hasknife && card.type == CardDB.cardtype.MOB) continue;

                    first = false;
                    continue;
                }
            }
            if (first == false) return cards;

            return 0;
        }

        private int getCardDiscardPenality(CardDB.cardName name, Playfield p)
        {
            if (p.owncards.Count <= 1) return 0;
            int pen = 0;
            if (this.cardDiscardDatabase.ContainsKey(name))
            {
                int newmana = p.mana - cardDiscardDatabase[name];
                bool canplayanothercard = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (this.cardDiscardDatabase.ContainsKey(hc.card.name)) continue;
                    if (hc.card.getManaCost(p, hc.manacost) <= newmana)
                    {
                        canplayanothercard = true;
                    }
                }
                if (canplayanothercard) pen += 20;

            }

            return pen;
        }

        private int getDestroyOwnPenality(CardDB.cardName name, int target, Playfield p, bool lethal)
        {
            if (!this.destroyOwnDatabase.ContainsKey(name)) return 0;
            int pen = 0;
            if ((name == CardDB.cardName.brawl || name == CardDB.cardName.deathwing || name == CardDB.cardName.twistingnether) && p.mobsplayedThisTurn >= 1) return 500;

            if (name == CardDB.cardName.brawl || name == CardDB.cardName.twistingnether)
            {
                if (name == CardDB.cardName.brawl && p.ownMinions.Count + p.enemyMinions.Count <= 1) return 500;
                int highminion = 0;
                int veryhighminion = 0;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Angr >= 5 || m.Hp >= 5) highminion++;
                    if (m.Angr >= 8 || m.Hp >= 8) veryhighminion++;
                }

                if (highminion >= 2 || veryhighminion >= 1)
                {
                    return 0;
                }

                if (p.enemyMinions.Count <= 2 || p.enemyMinions.Count + 2 <= p.ownMinions.Count || p.ownMinions.Count >= 3)
                {
                    return 30;
                }
            }

            if (target >= 0 && target <= 9)
            {
                // dont destroy owns ;_; (except mins with deathrattle effects)

                Minion m = p.ownMinions[target];
                if (m.handcard.card.deathrattle) return 10;
                if (lethal && name == CardDB.cardName.sacrificialpact)
                {
                    int beasts = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && mm.handcard.card.name == CardDB.cardName.lightwarden) beasts++;
                    }
                    if (beasts == 0) return 500;
                }
                else
                {

                    return 500;
                }
            }

            return pen;
        }

        private int getDestroyPenality(CardDB.cardName name, int target, Playfield p, bool lethal)
        {
            if (!this.destroyDatabase.ContainsKey(name) || lethal) return 0;
            int pen = 0;
            if (target >= 0 && target <= 9)
            {
                Minion m = p.ownMinions[target];
                if (!m.handcard.card.deathrattle)
                {
                    pen = 500;
                }
            }
            if (target >= 10 && target <= 19)
            {
                // dont destroy owns ;_; (except mins with deathrattle effects)

                Minion m = p.enemyMinions[target - 10];

                if (m.Angr >= 4 || m.Hp >= 5)
                {
                    pen = 0; // so we dont destroy cheap ones :D
                }
                else
                {
                    pen = 30;
                }

                if (name == CardDB.cardName.mindcontrol && (m.name == CardDB.cardName.direwolfalpha || m.name == CardDB.cardName.raidleader || m.name == CardDB.cardName.flametonguetotem) && p.enemyMinions.Count == 1)
                {
                    pen = 50;
                }

            }

            return pen;
        }

        private int getSpecialCardComboPenalitys(CardDB.Card card, int target, Playfield p, bool lethal, int choice)
        {
            CardDB.cardName name = card.name;

            if (lethal && card.type == CardDB.cardtype.MOB)
            {

                if (this.buffingMinionsDatabase.ContainsKey(name))
                {
                    if (name == CardDB.cardName.timberwolf || name == CardDB.cardName.houndmaster)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PET) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }
                    if (name == CardDB.cardName.southseacaptain)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }
                    if (name == CardDB.cardName.murlocwarleader || name == CardDB.cardName.grimscaleoracle || name == CardDB.cardName.coldlightseer)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }
                }
                else
                {
                    if (name == CardDB.cardName.theblackknight)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.enemyMinions)
                        {
                            if (mm.taunt) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }
                    else
                    {
                        if ((this.HealTargetDatabase.ContainsKey(name) || this.HealHeroDatabase.ContainsKey(name) || this.HealAllDatabase.ContainsKey(name)))
                        {
                            int beasts = 0;
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.Ready && mm.handcard.card.name == CardDB.cardName.lightwarden) beasts++;
                            }
                            if (beasts == 0) return 500;
                        }
                        else
                        {
                            if (!(name == CardDB.cardName.nightblade || card.Charge || this.silenceDatabase.ContainsKey(name) || ((TAG_RACE)card.race == TAG_RACE.PET && p.ownMinions.Find(x => x.name == CardDB.cardName.tundrarhino) != null) || (p.ownMinions.Find(x => x.name == CardDB.cardName.warsongcommander) != null && card.Attack <= 3) || p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null))
                            {
                                return 500;
                            }
                        }
                    }
                }
            }


            //some effects, which are bad :D
            int pen = 0;
            Minion m = new Minion();
            if (target >= 0 && target <= 9)
            {
                m = p.ownMinions[target];
            }
            if (target >= 10 && target <= 19)
            {
                m = p.enemyMinions[target - 10];
            }

            if (card.name == CardDB.cardName.flametonguetotem && p.ownMinions.Count == 0)
            {
                return 100;
            }

            if (card.name == CardDB.cardName.stampedingkodo)
            {
                bool found = false;
                foreach (Minion mi in p.enemyMinions)
                {
                    if (mi.Angr <= 2) found = true;
                }
                if (!found) return 20;
            }

            if (name == CardDB.cardName.windfury && !m.Ready) return 500;

            if ((name == CardDB.cardName.wildgrowth || name == CardDB.cardName.nourish) && p.ownMaxMana == 9 && !(p.ownHeroName == HeroEnum.thief && p.cardsPlayedThisTurn == 0))
            {
                return 500;
            }

            if (name == CardDB.cardName.sylvanaswindrunner)
            {
                if (p.enemyMinions.Count == 0)
                {
                    return 10;
                }
            }

            if (name == CardDB.cardName.betrayal && target >= 10 && target <= 19)
            {
                if (m.Angr == 0) return 30;
                if (p.enemyMinions.Count == 1) return 30;
            }


            if (name == CardDB.cardName.houndmaster)
            {
                if (target == -1) return 50;
            }

            if (name == CardDB.cardName.bite)
            {
                if ((p.ownHeroNumAttackThisTurn == 0 || (p.ownHeroWindfury && p.ownHeroNumAttackThisTurn == 1)) && !p.ownHeroFrozen)
                {

                }
                else
                {
                    return 20;
                }
            }

            if (name == CardDB.cardName.deadlypoison)
            {
                return p.ownWeaponDurability * 2;
            }

            if (name == CardDB.cardName.coldblood)
            {
                if (lethal) return 0;
                return 25;
            }

            if (name == CardDB.cardName.bloodmagethalnos)
            {
                return 10;
            }

            if (name == CardDB.cardName.frostbolt)
            {
                if (target >= 10 && target <= 19)
                {
                    if (m.handcard.card.cost <= 2)
                        return 15;
                }
                return 15;
            }

            if (!lethal && choice == 1 && name == CardDB.cardName.druidoftheclaw)
            {
                return 20;
            }


            if (name == CardDB.cardName.poweroverwhelming)
            {
                if (target >= 0 && target <= 9 && !m.Ready)
                {
                    return 500;
                }
            }

            if (name == CardDB.cardName.frothingberserker)
            {
                if (p.cardsPlayedThisTurn >= 1) pen = 5;
            }

            if (name == CardDB.cardName.handofprotection)
            {
                if (m.Hp == 1) pen = 15;
            }

            if (lethal)
            {
                if (name == CardDB.cardName.corruption)
                {
                    int beasts = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && (mm.handcard.card.name == CardDB.cardName.questingadventurer || mm.handcard.card.name == CardDB.cardName.archmageantonidas || mm.handcard.card.name == CardDB.cardName.manaaddict || mm.handcard.card.name == CardDB.cardName.manawyrm || mm.handcard.card.name == CardDB.cardName.wildpyromancer)) beasts++;
                    }
                    if (beasts == 0) return 500;
                }
            }

            if (name == CardDB.cardName.divinespirit)
            {
                if (lethal)
                {
                    if (target >= 10 && target <= 19)
                    {
                        if (!m.taunt)
                        {
                            return 500;
                        }
                        else
                        {
                            // combo for killing with innerfire and biggamehunter
                            if (p.owncards.Find(x => x.card.name == CardDB.cardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.cardName.innerfire) != null && (m.Hp >= 4 || (p.owncards.Find(x => x.card.name == CardDB.cardName.divinespirit) != null && m.Hp >= 2)))
                            {
                                return 0;
                            }
                            return 500;
                        }
                    }
                }
                else
                {
                    if (target >= 10 && target <= 19)
                    {

                        // combo for killing with innerfire and biggamehunter
                        if (p.owncards.Find(x => x.card.name == CardDB.cardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.cardName.innerfire) != null && m.Hp >= 4)
                        {
                            return 0;
                        }
                        return 500;
                    }

                }

                if (target >= 0 && target <= 9)
                {

                    if (m.Hp >= 4)
                    {
                        return 0;
                    }
                    return 15;
                }

            }

            if (name == CardDB.cardName.facelessmanipulator)
            {
                if (target == -1)
                {
                    return 50;
                }
                if (m.Angr >= 5 || m.handcard.card.cost >= 5 || (m.handcard.card.rarity == 5 || m.handcard.card.cost >= 3))
                {
                    return 0;
                }
                return 49;
            }

            if (name == CardDB.cardName.knifejuggler)
            {
                if (p.mobsplayedThisTurn >= 1)
                {
                    return 10;
                }
            }

            if ((name == CardDB.cardName.polymorph || name == CardDB.cardName.hex))
            {

                if (target >= 0 && target <= 9)
                {
                    return 500;
                }

                if (target >= 10 && target <= 19)
                {
                    Minion frog = p.enemyMinions[target - 10];
                    if (this.priorityTargets.ContainsKey(frog.name)) return 0;
                    if (frog.Angr >= 4 && frog.Hp >= 4) return 0;
                    return 30;
                }

            }

            if ((card.name == CardDB.cardName.biggamehunter) && (target == -1 || target <= 9))
            {
                return 40;
            }

            if ((name == CardDB.cardName.defenderofargus || name == CardDB.cardName.sunfuryprotector) && p.ownMinions.Count == 1)
            {
                return 40;
            }
            if ((name == CardDB.cardName.defenderofargus || name == CardDB.cardName.sunfuryprotector) && p.ownMinions.Count == 0)
            {
                return 50;
            }

            if (name == CardDB.cardName.unleashthehounds)
            {
                if (p.enemyMinions.Count <= 1)
                {
                    return 20;
                }
            }

            if (name == CardDB.cardName.equality) // aoe penality
            {
                if (p.enemyMinions.Count <= 2 || (p.ownMinions.Count - p.enemyMinions.Count >= 1))
                {
                    return 20;
                }
            }

            if (name == CardDB.cardName.bloodsailraider && p.ownWeaponDurability == 0)
            {
                //if you have bloodsailraider and no weapon equiped, but own a weapon:
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.WEAPON) return 10;
                }
            }

            if (name == CardDB.cardName.theblackknight)
            {
                if (target == -1)
                {
                    return 50;
                }

                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.taunt && (m.Angr >= 3 || m.Hp >= 3)) return 0;
                }
                return 20;
            }

            if (name == CardDB.cardName.innerfire)
            {
                if (m.name == CardDB.cardName.lightspawn) pen = 500;
            }

            if (name == CardDB.cardName.huntersmark)
            {
                if (target >= 0 && target <= 9) pen = 500; // dont use on own minions
                if (target >= 10 && target <= 19 && (p.enemyMinions[target - 10].Hp <= 4) && p.enemyMinions[target - 10].Angr <= 4) // only use on strong minions
                {
                    pen = 20;
                }
            }
            if (name == CardDB.cardName.aldorpeacekeeper && target == -1)
            {
                pen = 30;
            }
            if ((name == CardDB.cardName.aldorpeacekeeper || name == CardDB.cardName.humility) && target >= 0 && target <= 19)
            {
                if (target >= 0 && target <= 9) pen = 500; // dont use on own minions
                if (target >= 10 && target <= 19 && p.enemyMinions[target - 10].Angr <= 3) // only use on strong minions
                {
                    pen = 30;
                }
                if (m.name == CardDB.cardName.lightspawn) pen = 500;
            }

            if (name == CardDB.cardName.shatteredsuncleric && target == -1) { pen = 10; }
            if (name == CardDB.cardName.argentprotector && target == -1) { pen = 10; }

            if (name == CardDB.cardName.defiasringleader && p.cardsPlayedThisTurn == 0)
            { pen = 10; }
            if (name == CardDB.cardName.bloodknight)
            {
                int shilds = 0;
                foreach (Minion min in p.ownMinions)
                {
                    if (min.divineshild)
                    {
                        shilds++;
                    }
                }
                foreach (Minion min in p.enemyMinions)
                {
                    if (min.divineshild)
                    {
                        shilds++;
                    }
                }
                if (shilds == 0)
                {
                    pen = 10;
                }
            }
            if (name == CardDB.cardName.direwolfalpha)
            {
                int ready = 0;
                foreach (Minion min in p.ownMinions)
                {
                    if (min.Ready)
                    { ready++; }
                }
                if (ready == 0)
                { pen = 5; }
            }
            if (name == CardDB.cardName.abusivesergeant)
            {
                int ready = 0;
                foreach (Minion min in p.ownMinions)
                {
                    if (min.Ready)
                    { ready++; }
                }
                if (ready == 0)
                {
                    pen = 5;
                }
            }


            if (returnHandDatabase.ContainsKey(name))
            {
                if (name == CardDB.cardName.vanish)
                {
                    //dont vanish if we have minons on board wich are ready
                    bool haveready = false;
                    foreach (Minion mins in p.ownMinions)
                    {
                        if (mins.Ready) haveready = true;
                    }
                    if (haveready) pen += 10;
                }

                if (target >= 0 && target <= 9)
                {
                    Minion mnn = p.ownMinions[target];
                    if (mnn.Ready) pen += 10;
                }
            }

            return pen;
        }

        private int playSecretPenality(CardDB.Card card, Playfield p)
        {
            //penality if we play secret and have playable kirintormage
            int pen = 0;
            if (card.Secret)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.kirintormage && p.mana >= hc.getManaCost(p))
                    {
                        pen = 500;
                    }
                }
            }

            return pen;
        }

        ///secret strategys pala
        /// -Attack lowest enemy. If you can’t, use noncombat means to kill it. 
        /// -attack with something able to withstand 2 damage. 
        /// -Then play something that had low health to begin with to dodge Repentance. 
        /// 
        ///secret strategys hunter
        /// - kill enemys with your minions with 2 or less heal.
        ///  - Use the smallest minion available for the first attack 
        ///  - Then smack them in the face with whatever’s left. 
        ///  - If nothing triggered until then, it’s a Snipe, so throw something in front of it that won’t die or is expendable.
        /// 
        ///secret strategys mage
        /// - Play a small minion to trigger Mirror Entity.
        /// Then attack the mage directly with the smallest minion on your side. 
        /// If nothing triggered by that point, it’s either Spellbender or Counterspell, so hold your spells until you can (and have to!) deal with either. 

        private int getPlayCardSecretPenality(CardDB.Card c, Playfield p)
        {
            int pen = 0;
            if (p.enemySecretCount == 0)
            {
                return 0;
            }

            int attackedbefore = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1) attackedbefore++;
            }

            if (c.name == CardDB.cardName.acidicswampooze && (p.enemyHeroName == HeroEnum.warrior || p.enemyHeroName == HeroEnum.thief || p.enemyHeroName == HeroEnum.pala))
            {
                if (p.enemyHeroName == HeroEnum.thief && p.enemyWeaponAttack <= 2)
                {
                    pen += 100;
                }
                else
                {
                    if (p.enemyWeaponAttack <= 1)
                    {
                        pen += 100;
                    }
                }
            }

            if (p.enemyHeroName == HeroEnum.hunter)
            {
                if (c.type == CardDB.cardtype.MOB && (attackedbefore == 0 || c.Health <= 4 || (p.enemyHeroHp >= p.enemyHeroHpStarted && attackedbefore >= 1)))
                {
                    pen += 10;
                }
            }

            if (p.enemyHeroName == HeroEnum.mage)
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    Minion m = new Minion();
                    m.Hp = c.Health;
                    m.maxHp = c.Health;
                    m.Angr = c.Attack;
                    m.taunt = c.tank;
                    m.name = c.name;
                    //play first the small minion:
                    if ((!isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0) || (p.mobsplayedThisTurn == 0 && attackedbefore >= 1)) pen += 10;
                }

                if (c.type == CardDB.cardtype.SPELL && p.cardsPlayedThisTurn == p.mobsplayedThisTurn)
                {
                    pen += 10;
                }

            }

            if (p.enemyHeroName == HeroEnum.pala)
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    Minion m = new Minion();
                    m.Hp = c.Health;
                    m.maxHp = c.Health;
                    m.Angr = c.Attack;
                    m.taunt = c.tank;
                    m.name = c.name;
                    if ((!isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0) || attackedbefore == 0) pen += 10;
                }


            }



            return pen;
        }

        private int getAttackSecretPenality(Minion m, Playfield p, int target)
        {
            if (p.enemySecretCount == 0)
            {
                return 0;
            }

            int pen = 0;

            int attackedbefore = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1) attackedbefore++;
            }

            if (p.enemyHeroName == HeroEnum.hunter)
            {
                bool islow = isOwnLowest(m, p);
                if (attackedbefore == 0 && islow) pen -= 20;
                if (attackedbefore == 0 && !islow) pen += 10;

                if (target == 200 && p.enemyMinions.Count >= 1)
                {
                    //penality if we doestn attacked before
                    if (hasMinionsWithLowHeal(p)) pen += 10; //penality if we doestn attacked minions before
                }
            }

            if (p.enemyHeroName == HeroEnum.mage)
            {
                if (p.mobsplayedThisTurn == 0) pen += 10;

                bool islow = isOwnLowest(m, p);

                if (target == 200 && !islow)
                {
                    pen += 10;
                }
                if (target == 200 && islow && p.mobsplayedThisTurn >= 1)
                {
                    pen -= 20;
                }

            }

            if (p.enemyHeroName == HeroEnum.pala)
            {

                bool islow = isOwnLowest(m, p);

                if (target >= 10 && target <= 20 && attackedbefore == 0)
                {
                    Minion enem = p.enemyMinions[target - 10];
                    if (!isEnemyLowest(enem, p) || m.Hp <= 2) pen += 5;
                }

                if (target == 200 && !islow)
                {
                    pen += 5;
                }

                if (target == 200 && p.enemyMinions.Count >= 1 && attackedbefore == 0)
                {
                    pen += 5;
                }

            }


            return pen;
        }






        private int getValueOfMinion(Minion m)
        {
            int ret = 0;
            ret += 2 * m.Angr + m.Hp;
            if (m.taunt) ret += 2;
            if (this.priorityDatabase.ContainsKey(m.name)) ret += 20 + priorityDatabase[m.name];
            return ret;
        }

        private bool isOwnLowest(Minion mnn, Playfield p)
        {
            bool ret = true;
            int val = getValueOfMinion(mnn);
            foreach (Minion m in p.ownMinions)
            {
                if (!m.Ready) continue;
                if (getValueOfMinion(m) < val) ret = false;
            }
            return ret;
        }

        private bool isOwnLowestInHand(Minion mnn, Playfield p)
        {
            bool ret = true;
            Minion m = new Minion();
            int val = getValueOfMinion(mnn);
            foreach (Handmanager.Handcard card in p.owncards)
            {
                if (card.card.type != CardDB.cardtype.MOB) continue;
                CardDB.Card c = card.card;
                m.Hp = c.Health;
                m.maxHp = c.Health;
                m.Angr = c.Attack;
                m.taunt = c.tank;
                m.name = c.name;
                if (getValueOfMinion(m) < val) ret = false;
            }
            return ret;
        }

        private int getValueOfEnemyMinion(Minion m)
        {
            int ret = 0;
            ret += m.Hp;
            if (m.taunt) ret -= 2;
            return ret;
        }

        private bool isEnemyLowest(Minion mnn, Playfield p)
        {
            bool ret = true;
            List<targett> litt = p.getAttackTargets(true);
            int val = getValueOfEnemyMinion(mnn);
            foreach (Minion m in p.enemyMinions)
            {
                if (litt.Find(x => x.target == m.id) == null) continue;
                if (getValueOfEnemyMinion(m) < val) ret = false;
            }
            return ret;
        }

        private bool hasMinionsWithLowHeal(Playfield p)
        {
            bool ret = false;
            foreach (Minion m in p.ownMinions)
            {
                if (m.Hp <= 2 && (m.Ready || this.priorityDatabase.ContainsKey(m.name))) ret = true;
            }
            return ret;
        }



        private void setupEnrageDatabase()
        {
            enrageDatabase.Add(CardDB.cardName.amaniberserker, 0);
            enrageDatabase.Add(CardDB.cardName.angrychicken, 0);
            enrageDatabase.Add(CardDB.cardName.grommashhellscream, 0);
            enrageDatabase.Add(CardDB.cardName.ragingworgen, 0);
            enrageDatabase.Add(CardDB.cardName.spitefulsmith, 0);
            enrageDatabase.Add(CardDB.cardName.taurenwarrior, 0);
        }

        private void setupHealDatabase()
        {
            HealAllDatabase.Add(CardDB.cardName.holynova, 2);//to all own minions
            HealAllDatabase.Add(CardDB.cardName.circleofhealing, 4);//allminions
            HealAllDatabase.Add(CardDB.cardName.darkscalehealer, 2);//all friends

            HealHeroDatabase.Add(CardDB.cardName.drainlife, 2);//tohero
            HealHeroDatabase.Add(CardDB.cardName.guardianofkings, 6);//tohero
            HealHeroDatabase.Add(CardDB.cardName.holyfire, 5);//tohero
            HealHeroDatabase.Add(CardDB.cardName.priestessofelune, 4);//tohero
            HealHeroDatabase.Add(CardDB.cardName.sacrificialpact, 5);//tohero
            HealHeroDatabase.Add(CardDB.cardName.siphonsoul, 3); //tohero

            HealTargetDatabase.Add(CardDB.cardName.ancestralhealing, 1000);
            HealTargetDatabase.Add(CardDB.cardName.ancientsecrets, 5);
            HealTargetDatabase.Add(CardDB.cardName.holylight, 6);
            HealTargetDatabase.Add(CardDB.cardName.earthenringfarseer, 3);
            HealTargetDatabase.Add(CardDB.cardName.healingtouch, 8);
            HealTargetDatabase.Add(CardDB.cardName.layonhands, 8);
            HealTargetDatabase.Add(CardDB.cardName.lesserheal, 2);
            HealTargetDatabase.Add(CardDB.cardName.voodoodoctor, 2);
            HealTargetDatabase.Add(CardDB.cardName.willofmukla, 8);
            HealTargetDatabase.Add(CardDB.cardName.ancientoflore, 5);
            //HealTargetDatabase.Add(CardDB.cardName.divinespirit, 2);
        }

        private void setupDamageDatabase()
        {

            DamageHeroDatabase.Add(CardDB.cardName.headcrack, 2);

            DamageAllDatabase.Add(CardDB.cardName.abomination, 2);
            DamageAllDatabase.Add(CardDB.cardName.dreadinfernal, 1);
            DamageAllDatabase.Add(CardDB.cardName.hellfire, 3);
            DamageAllDatabase.Add(CardDB.cardName.whirlwind, 1);
            DamageAllDatabase.Add(CardDB.cardName.yseraawakens, 5);

            DamageAllEnemysDatabase.Add(CardDB.cardName.arcaneexplosion, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.consecration, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.fanofknives, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.flamestrike, 4);
            DamageAllEnemysDatabase.Add(CardDB.cardName.holynova, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.lightningstorm, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.stomp, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.madbomber, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.swipe, 4);//1 to others
            DamageAllEnemysDatabase.Add(CardDB.cardName.bladeflurry, 1);

            DamageRandomDatabase.Add(CardDB.cardName.arcanemissiles, 1);
            DamageRandomDatabase.Add(CardDB.cardName.avengingwrath, 1);
            DamageRandomDatabase.Add(CardDB.cardName.cleave, 2);
            DamageRandomDatabase.Add(CardDB.cardName.forkedlightning, 2);
            DamageRandomDatabase.Add(CardDB.cardName.multishot, 3);

            DamageTargetSpecialDatabase.Add(CardDB.cardName.crueltaskmaster, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardDB.cardName.innerrage, 1); // gives 2 attack

            DamageTargetSpecialDatabase.Add(CardDB.cardName.demonfire, 2); // friendly demon get +2/+2
            DamageTargetSpecialDatabase.Add(CardDB.cardName.earthshock, 1); //SILENCE /good for raggy etc or iced
            DamageTargetSpecialDatabase.Add(CardDB.cardName.hammerofwrath, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.holywrath, 2);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.roguesdoit, 4);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.shiv, 1);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.savagery, 1);//dmg=herodamage
            DamageTargetSpecialDatabase.Add(CardDB.cardName.shieldslam, 1);//dmg=armor
            DamageTargetSpecialDatabase.Add(CardDB.cardName.slam, 2);//draw card if it survives
            DamageTargetSpecialDatabase.Add(CardDB.cardName.soulfire, 4);//delete a card


            DamageTargetDatabase.Add(CardDB.cardName.keeperofthegrove, 2); // or silence
            DamageTargetDatabase.Add(CardDB.cardName.wrath, 3);//or 1 + card

            DamageTargetDatabase.Add(CardDB.cardName.coneofcold, 1);
            DamageTargetDatabase.Add(CardDB.cardName.arcaneshot, 2);
            DamageTargetDatabase.Add(CardDB.cardName.backstab, 2);
            DamageTargetDatabase.Add(CardDB.cardName.baneofdoom, 2);
            DamageTargetDatabase.Add(CardDB.cardName.barreltoss, 2);
            DamageTargetDatabase.Add(CardDB.cardName.blizzard, 2);
            DamageTargetDatabase.Add(CardDB.cardName.drainlife, 2);
            DamageTargetDatabase.Add(CardDB.cardName.elvenarcher, 1);
            DamageTargetDatabase.Add(CardDB.cardName.eviscerate, 3);
            DamageTargetDatabase.Add(CardDB.cardName.explosiveshot, 5);
            DamageTargetDatabase.Add(CardDB.cardName.fireelemental, 3);
            DamageTargetDatabase.Add(CardDB.cardName.fireball, 6);
            DamageTargetDatabase.Add(CardDB.cardName.fireblast, 1);
            DamageTargetDatabase.Add(CardDB.cardName.frostshock, 1);
            DamageTargetDatabase.Add(CardDB.cardName.frostbolt, 1);
            DamageTargetDatabase.Add(CardDB.cardName.hoggersmash, 4);
            DamageTargetDatabase.Add(CardDB.cardName.holyfire, 5);
            DamageTargetDatabase.Add(CardDB.cardName.holysmite, 2);
            DamageTargetDatabase.Add(CardDB.cardName.icelance, 4);//only if iced
            DamageTargetDatabase.Add(CardDB.cardName.ironforgerifleman, 1);
            DamageTargetDatabase.Add(CardDB.cardName.killcommand, 3);//or 5
            DamageTargetDatabase.Add(CardDB.cardName.lavaburst, 5);
            DamageTargetDatabase.Add(CardDB.cardName.lightningbolt, 2);
            DamageTargetDatabase.Add(CardDB.cardName.mindshatter, 3);
            DamageTargetDatabase.Add(CardDB.cardName.mindspike, 2);
            DamageTargetDatabase.Add(CardDB.cardName.moonfire, 1);
            DamageTargetDatabase.Add(CardDB.cardName.mortalcoil, 1);
            DamageTargetDatabase.Add(CardDB.cardName.mortalstrike, 4);
            DamageTargetDatabase.Add(CardDB.cardName.perditionsblade, 1);
            DamageTargetDatabase.Add(CardDB.cardName.pyroblast, 10);
            DamageTargetDatabase.Add(CardDB.cardName.shadowbolt, 4);
            DamageTargetDatabase.Add(CardDB.cardName.shotgunblast, 1);
            DamageTargetDatabase.Add(CardDB.cardName.si7agent, 2);
            DamageTargetDatabase.Add(CardDB.cardName.starfall, 5);
            DamageTargetDatabase.Add(CardDB.cardName.starfire, 5);//draw a card, but its to strong
            DamageTargetDatabase.Add(CardDB.cardName.stormpikecommando, 5);






        }

        private void setupsilenceDatabase()
        {
            this.silenceDatabase.Add(CardDB.cardName.dispel, 1);
            this.silenceDatabase.Add(CardDB.cardName.earthshock, 1);
            this.silenceDatabase.Add(CardDB.cardName.massdispel, 1);
            this.silenceDatabase.Add(CardDB.cardName.silence, 1);
            this.silenceDatabase.Add(CardDB.cardName.keeperofthegrove, 1);
            this.silenceDatabase.Add(CardDB.cardName.ironbeakowl, 1);
            this.silenceDatabase.Add(CardDB.cardName.spellbreaker, 1);
        }

        private void setupPriorityList()
        {
            this.priorityDatabase.Add(CardDB.cardName.prophetvelen, 5);
            this.priorityDatabase.Add(CardDB.cardName.archmageantonidas, 5);
            this.priorityDatabase.Add(CardDB.cardName.flametonguetotem, 6);
            this.priorityDatabase.Add(CardDB.cardName.raidleader, 5);
            this.priorityDatabase.Add(CardDB.cardName.grimscaleoracle, 5);
            this.priorityDatabase.Add(CardDB.cardName.direwolfalpha, 6);
            this.priorityDatabase.Add(CardDB.cardName.murlocwarleader, 5);
            this.priorityDatabase.Add(CardDB.cardName.southseacaptain, 5);
            this.priorityDatabase.Add(CardDB.cardName.stormwindchampion, 5);
            this.priorityDatabase.Add(CardDB.cardName.timberwolf, 5);
            this.priorityDatabase.Add(CardDB.cardName.leokk, 5);
            this.priorityDatabase.Add(CardDB.cardName.northshirecleric, 5);
            this.priorityDatabase.Add(CardDB.cardName.sorcerersapprentice, 3);
            this.priorityDatabase.Add(CardDB.cardName.summoningportal, 5);
            this.priorityDatabase.Add(CardDB.cardName.pintsizedsummoner, 3);
            this.priorityDatabase.Add(CardDB.cardName.scavenginghyena, 5);
            this.priorityDatabase.Add(CardDB.cardName.manatidetotem, 5);
        }

        private void setupAttackBuff()
        {
            heroAttackBuffDatabase.Add(CardDB.cardName.bite, 4);
            heroAttackBuffDatabase.Add(CardDB.cardName.claw, 2);
            heroAttackBuffDatabase.Add(CardDB.cardName.heroicstrike, 2);

            this.attackBuffDatabase.Add(CardDB.cardName.abusivesergeant, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.bananas, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.bestialwrath, 2); // NEVER ON enemy MINION
            this.attackBuffDatabase.Add(CardDB.cardName.blessingofkings, 4);
            this.attackBuffDatabase.Add(CardDB.cardName.blessingofmight, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.coldblood, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.crueltaskmaster, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.darkirondwarf, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.innerrage, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.markofnature, 4);//choice1 
            this.attackBuffDatabase.Add(CardDB.cardName.markofthewild, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.nightmare, 5); //destroy minion on next turn
            this.attackBuffDatabase.Add(CardDB.cardName.rampage, 3);//only damaged minion 
            this.attackBuffDatabase.Add(CardDB.cardName.uproot, 5);

        }

        private void setupHealthBuff()
        {

            this.healthBuffDatabase.Add(CardDB.cardName.ancientofwar, 5);//choice2
            this.healthBuffDatabase.Add(CardDB.cardName.bananas, 1);
            this.healthBuffDatabase.Add(CardDB.cardName.blessingofkings, 4);
            this.healthBuffDatabase.Add(CardDB.cardName.markofnature, 4);//choice2
            this.healthBuffDatabase.Add(CardDB.cardName.markofthewild, 2);
            this.healthBuffDatabase.Add(CardDB.cardName.nightmare, 5);
            this.healthBuffDatabase.Add(CardDB.cardName.powerwordshield, 2);
            this.healthBuffDatabase.Add(CardDB.cardName.rampage, 3);
            this.healthBuffDatabase.Add(CardDB.cardName.rooted, 5);

            this.tauntBuffDatabase.Add(CardDB.cardName.markofnature, 1);
            this.tauntBuffDatabase.Add(CardDB.cardName.markofthewild, 1);
            this.tauntBuffDatabase.Add(CardDB.cardName.rooted, 1);


        }

        private void setupCardDrawBattlecry()
        {
            cardDrawBattleCryDatabase.Add(CardDB.cardName.wrath, 1); //choice=2
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancientoflore, 2);// choice =1
            cardDrawBattleCryDatabase.Add(CardDB.cardName.nourish, 3); //choice = 2
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancientteachings, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.excessmana, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.starfire, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.azuredrake, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.coldlightoracle, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.gnomishinventor, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.harrisonjones, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.noviceengineer, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.roguesdoit, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.arcaneintellect, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.hammerofwrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.holywrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.layonhands, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.massdispel, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.powerwordshield, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.fanofknives, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shiv, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.sprint, 4);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.farsight, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lifetap, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.commandingshout, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shieldblock, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.slam, 1); //if survives
            cardDrawBattleCryDatabase.Add(CardDB.cardName.mortalcoil, 1);//only if kills
            cardDrawBattleCryDatabase.Add(CardDB.cardName.battlerage, 1);//only if wounded own minions
            cardDrawBattleCryDatabase.Add(CardDB.cardName.divinefavor, 1);//only if enemy has more cards than you
        }

        private void setupDiscardCards()
        {
            cardDiscardDatabase.Add(CardDB.cardName.doomguard, 5);
            cardDiscardDatabase.Add(CardDB.cardName.soulfire, 0);
            cardDiscardDatabase.Add(CardDB.cardName.succubus, 2);
        }

        private void setupDestroyOwnCards()
        {
            this.destroyOwnDatabase.Add(CardDB.cardName.brawl, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.deathwing, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.twistingnether, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.naturalize, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.shadowworddeath, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.shadowwordpain, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.siphonsoul, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.biggamehunter, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.hungrycrab, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.sacrificialpact, 0);//not own mins

            this.destroyDatabase.Add(CardDB.cardName.assassinate, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.corruption, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.execute, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.naturalize, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.siphonsoul, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.mindcontrol, 0);//not own mins

        }

        private void setupReturnBackToHandCards()
        {
            returnHandDatabase.Add(CardDB.cardName.ancientbrewmaster, 0);
            returnHandDatabase.Add(CardDB.cardName.dream, 0);
            returnHandDatabase.Add(CardDB.cardName.kidnapper, 0);//if combo
            returnHandDatabase.Add(CardDB.cardName.shadowstep, 0);
            returnHandDatabase.Add(CardDB.cardName.vanish, 0);
            returnHandDatabase.Add(CardDB.cardName.youthfulbrewmaster, 0);
        }

        private void setupHeroDamagingAOE()
        {
            this.heroDamagingAoeDatabase.Add(CardDB.cardName.unknown, 0);
        }

        private void setupSpecialMins()
        {
            this.specialMinions.Add(CardDB.cardName.amaniberserker, 0);
            this.specialMinions.Add(CardDB.cardName.angrychicken, 0);
            this.specialMinions.Add(CardDB.cardName.abomination, 0);
            this.specialMinions.Add(CardDB.cardName.acolyteofpain, 0);
            this.specialMinions.Add(CardDB.cardName.alarmobot, 0);
            this.specialMinions.Add(CardDB.cardName.archmage, 0);
            this.specialMinions.Add(CardDB.cardName.archmageantonidas, 0);
            this.specialMinions.Add(CardDB.cardName.armorsmith, 0);
            this.specialMinions.Add(CardDB.cardName.auchenaisoulpriest, 0);
            this.specialMinions.Add(CardDB.cardName.azuredrake, 0);
            this.specialMinions.Add(CardDB.cardName.barongeddon, 0);
            this.specialMinions.Add(CardDB.cardName.bloodimp, 0);
            this.specialMinions.Add(CardDB.cardName.bloodmagethalnos, 0);
            this.specialMinions.Add(CardDB.cardName.cairnebloodhoof, 0);
            this.specialMinions.Add(CardDB.cardName.cultmaster, 0);
            this.specialMinions.Add(CardDB.cardName.dalaranmage, 0);
            this.specialMinions.Add(CardDB.cardName.demolisher, 0);
            this.specialMinions.Add(CardDB.cardName.direwolfalpha, 0);
            this.specialMinions.Add(CardDB.cardName.doomsayer, 0);
            this.specialMinions.Add(CardDB.cardName.emperorcobra, 0);
            this.specialMinions.Add(CardDB.cardName.etherealarcanist, 0);
            this.specialMinions.Add(CardDB.cardName.flametonguetotem, 0);
            this.specialMinions.Add(CardDB.cardName.flesheatingghoul, 0);
            this.specialMinions.Add(CardDB.cardName.gadgetzanauctioneer, 0);
            this.specialMinions.Add(CardDB.cardName.grimscaleoracle, 0);
            this.specialMinions.Add(CardDB.cardName.grommashhellscream, 0);
            this.specialMinions.Add(CardDB.cardName.gruul, 0);
            this.specialMinions.Add(CardDB.cardName.gurubashiberserker, 0);
            this.specialMinions.Add(CardDB.cardName.harvestgolem, 0);
            this.specialMinions.Add(CardDB.cardName.hogger, 0);
            this.specialMinions.Add(CardDB.cardName.illidanstormrage, 0);
            this.specialMinions.Add(CardDB.cardName.impmaster, 0);
            this.specialMinions.Add(CardDB.cardName.knifejuggler, 0);
            this.specialMinions.Add(CardDB.cardName.koboldgeomancer, 0);
            this.specialMinions.Add(CardDB.cardName.lepergnome, 0);
            this.specialMinions.Add(CardDB.cardName.lightspawn, 0);
            this.specialMinions.Add(CardDB.cardName.lightwarden, 0);
            this.specialMinions.Add(CardDB.cardName.lightwell, 0);
            this.specialMinions.Add(CardDB.cardName.loothoarder, 0);
            this.specialMinions.Add(CardDB.cardName.lorewalkercho, 0);
            this.specialMinions.Add(CardDB.cardName.malygos, 0);
            this.specialMinions.Add(CardDB.cardName.manaaddict, 0);
            this.specialMinions.Add(CardDB.cardName.manatidetotem, 0);
            this.specialMinions.Add(CardDB.cardName.manawraith, 0);
            this.specialMinions.Add(CardDB.cardName.manawyrm, 0);
            this.specialMinions.Add(CardDB.cardName.masterswordsmith, 0);
            this.specialMinions.Add(CardDB.cardName.murloctidecaller, 0);
            this.specialMinions.Add(CardDB.cardName.murlocwarleader, 0);
            this.specialMinions.Add(CardDB.cardName.natpagle, 0);
            this.specialMinions.Add(CardDB.cardName.northshirecleric, 0);
            this.specialMinions.Add(CardDB.cardName.ogremagi, 0);
            this.specialMinions.Add(CardDB.cardName.oldmurkeye, 0);
            this.specialMinions.Add(CardDB.cardName.patientassassin, 0);
            this.specialMinions.Add(CardDB.cardName.pintsizedsummoner, 0);
            this.specialMinions.Add(CardDB.cardName.prophetvelen, 0);
            this.specialMinions.Add(CardDB.cardName.questingadventurer, 0);
            this.specialMinions.Add(CardDB.cardName.ragingworgen, 0);
            this.specialMinions.Add(CardDB.cardName.raidleader, 0);
            this.specialMinions.Add(CardDB.cardName.savannahhighmane, 0);
            this.specialMinions.Add(CardDB.cardName.scavenginghyena, 0);
            this.specialMinions.Add(CardDB.cardName.secretkeeper, 0);
            this.specialMinions.Add(CardDB.cardName.sorcerersapprentice, 0);
            this.specialMinions.Add(CardDB.cardName.southseacaptain, 0);
            this.specialMinions.Add(CardDB.cardName.spitefulsmith, 0);
            this.specialMinions.Add(CardDB.cardName.starvingbuzzard, 0);
            this.specialMinions.Add(CardDB.cardName.stormwindchampion, 0);
            this.specialMinions.Add(CardDB.cardName.summoningportal, 0);
            this.specialMinions.Add(CardDB.cardName.sylvanaswindrunner, 0);
            this.specialMinions.Add(CardDB.cardName.taurenwarrior, 0);
            this.specialMinions.Add(CardDB.cardName.thebeast, 0);
            this.specialMinions.Add(CardDB.cardName.timberwolf, 0);
            this.specialMinions.Add(CardDB.cardName.tirionfordring, 0);
            this.specialMinions.Add(CardDB.cardName.tundrarhino, 0);
            this.specialMinions.Add(CardDB.cardName.unboundelemental, 0);
            //this.specialMinions.Add(CardDB.cardName.venturecomercenary, 0);
            this.specialMinions.Add(CardDB.cardName.violetteacher, 0);
            this.specialMinions.Add(CardDB.cardName.warsongcommander, 0);
            this.specialMinions.Add(CardDB.cardName.waterelemental, 0);

            // naxx cards
            this.specialMinions.Add(CardDB.cardName.baronrivendare, 0);
            this.specialMinions.Add(CardDB.cardName.undertaker, 0);
            this.specialMinions.Add(CardDB.cardName.dancingswords, 0);
            this.specialMinions.Add(CardDB.cardName.darkcultist, 0);
            this.specialMinions.Add(CardDB.cardName.deathlord, 0);
            this.specialMinions.Add(CardDB.cardName.feugen, 0);
            this.specialMinions.Add(CardDB.cardName.stalagg, 0);
            this.specialMinions.Add(CardDB.cardName.hauntedcreeper, 0);
            this.specialMinions.Add(CardDB.cardName.kelthuzad, 0);
            this.specialMinions.Add(CardDB.cardName.madscientist, 0);
            this.specialMinions.Add(CardDB.cardName.maexxna, 0);
            this.specialMinions.Add(CardDB.cardName.nerubarweblord, 0);
            this.specialMinions.Add(CardDB.cardName.shadeofnaxxramas, 0);
            this.specialMinions.Add(CardDB.cardName.unstableghoul, 0);
            this.specialMinions.Add(CardDB.cardName.voidcaller, 0);
            this.specialMinions.Add(CardDB.cardName.anubarambusher, 0);
            this.specialMinions.Add(CardDB.cardName.webspinner, 0);

        }

        private void setupBuffingMinions()
        {
            buffingMinionsDatabase.Add(CardDB.cardName.abusivesergeant, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.captaingreenskin, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.cenarius, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.coldlightseer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.crueltaskmaster, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.darkirondwarf, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.defenderofargus, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.direwolfalpha, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.flametonguetotem, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.grimscaleoracle, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.houndmaster, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.leokk, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.murlocwarleader, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.raidleader, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.shatteredsuncleric, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.southseacaptain, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.spitefulsmith, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.stormwindchampion, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.templeenforcer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.timberwolf, 0);

            buffing1TurnDatabase.Add(CardDB.cardName.abusivesergeant, 0);
            buffing1TurnDatabase.Add(CardDB.cardName.darkirondwarf, 0);

        }

        private void setupEnemyTargetPriority()
        {
            priorityTargets.Add(CardDB.cardName.angrychicken, 10);
            priorityTargets.Add(CardDB.cardName.lightwarden, 10);
            priorityTargets.Add(CardDB.cardName.secretkeeper, 10);
            priorityTargets.Add(CardDB.cardName.youngdragonhawk, 10);
            priorityTargets.Add(CardDB.cardName.bloodmagethalnos, 10);
            priorityTargets.Add(CardDB.cardName.direwolfalpha, 10);
            priorityTargets.Add(CardDB.cardName.doomsayer, 10);
            priorityTargets.Add(CardDB.cardName.knifejuggler, 10);
            priorityTargets.Add(CardDB.cardName.koboldgeomancer, 10);
            priorityTargets.Add(CardDB.cardName.manaaddict, 10);
            priorityTargets.Add(CardDB.cardName.masterswordsmith, 10);
            priorityTargets.Add(CardDB.cardName.natpagle, 10);
            priorityTargets.Add(CardDB.cardName.murloctidehunter, 10);
            priorityTargets.Add(CardDB.cardName.pintsizedsummoner, 10);
            priorityTargets.Add(CardDB.cardName.wildpyromancer, 10);
            priorityTargets.Add(CardDB.cardName.alarmobot, 10);
            priorityTargets.Add(CardDB.cardName.acolyteofpain, 10);
            priorityTargets.Add(CardDB.cardName.demolisher, 10);
            priorityTargets.Add(CardDB.cardName.flesheatingghoul, 10);
            priorityTargets.Add(CardDB.cardName.impmaster, 10);
            priorityTargets.Add(CardDB.cardName.questingadventurer, 10);
            priorityTargets.Add(CardDB.cardName.raidleader, 10);
            priorityTargets.Add(CardDB.cardName.thrallmarfarseer, 10);
            priorityTargets.Add(CardDB.cardName.cultmaster, 10);
            priorityTargets.Add(CardDB.cardName.leeroyjenkins, 10);
            priorityTargets.Add(CardDB.cardName.violetteacher, 10);
            priorityTargets.Add(CardDB.cardName.gadgetzanauctioneer, 10);
            priorityTargets.Add(CardDB.cardName.hogger, 10);
            priorityTargets.Add(CardDB.cardName.illidanstormrage, 10);
            priorityTargets.Add(CardDB.cardName.barongeddon, 10);
            priorityTargets.Add(CardDB.cardName.stormwindchampion, 10);
            priorityTargets.Add(CardDB.cardName.gurubashiberserker, 10);
            //priorityTargets.Add(CardDB.cardName.cairnebloodhoof, 19);
            //priorityTargets.Add(CardDB.cardName.harvestgolem, 16);

            //warrior cards
            priorityTargets.Add(CardDB.cardName.frothingberserker, 10);
            priorityTargets.Add(CardDB.cardName.warsongcommander, 10);

            //warlock cards
            priorityTargets.Add(CardDB.cardName.summoningportal, 10);

            //shaman cards
            priorityTargets.Add(CardDB.cardName.dustdevil, 10);
            priorityTargets.Add(CardDB.cardName.wrathofairtotem, 1);
            priorityTargets.Add(CardDB.cardName.flametonguetotem, 10);
            priorityTargets.Add(CardDB.cardName.manatidetotem, 10);
            priorityTargets.Add(CardDB.cardName.unboundelemental, 10);

            //rogue cards

            //priest cards
            priorityTargets.Add(CardDB.cardName.northshirecleric, 10);
            priorityTargets.Add(CardDB.cardName.lightwell, 10);
            priorityTargets.Add(CardDB.cardName.auchenaisoulpriest, 10);
            priorityTargets.Add(CardDB.cardName.prophetvelen, 10);

            //paladin cards

            //mage cards
            priorityTargets.Add(CardDB.cardName.manawyrm, 10);
            priorityTargets.Add(CardDB.cardName.sorcerersapprentice, 10);
            priorityTargets.Add(CardDB.cardName.etherealarcanist, 10);
            priorityTargets.Add(CardDB.cardName.archmageantonidas, 10);

            //hunter cards
            priorityTargets.Add(CardDB.cardName.timberwolf, 10);
            priorityTargets.Add(CardDB.cardName.scavenginghyena, 10);
            priorityTargets.Add(CardDB.cardName.starvingbuzzard, 10);
            priorityTargets.Add(CardDB.cardName.leokk, 10);
            priorityTargets.Add(CardDB.cardName.tundrarhino, 10);

            //naxx cards
            priorityTargets.Add(CardDB.cardName.baronrivendare, 10);
            priorityTargets.Add(CardDB.cardName.kelthuzad, 10);
            priorityTargets.Add(CardDB.cardName.nerubarweblord, 10);
            priorityTargets.Add(CardDB.cardName.shadeofnaxxramas, 10);
            priorityTargets.Add(CardDB.cardName.undertaker, 10);

        }

        private void setupRandomCards()
        {
            this.randomEffects.Add(CardDB.cardName.deadlyshot, 1);
            this.randomEffects.Add(CardDB.cardName.multishot, 1);

            this.randomEffects.Add(CardDB.cardName.animalcompanion, 1);
            this.randomEffects.Add(CardDB.cardName.arcanemissiles, 3);
            this.randomEffects.Add(CardDB.cardName.avengingwrath, 8);
            //this.randomEffects.Add(CardDB.cardName.baneofdoom, 1);
            this.randomEffects.Add(CardDB.cardName.brawl, 1);
            this.randomEffects.Add(CardDB.cardName.captainsparrot, 1);
            this.randomEffects.Add(CardDB.cardName.cleave, 1);
            this.randomEffects.Add(CardDB.cardName.forkedlightning, 1);
            this.randomEffects.Add(CardDB.cardName.gelbinmekkatorque, 1);
            this.randomEffects.Add(CardDB.cardName.iammurloc, 3);
            this.randomEffects.Add(CardDB.cardName.lightningstorm, 1);
            this.randomEffects.Add(CardDB.cardName.madbomber, 3);
            this.randomEffects.Add(CardDB.cardName.mindgames, 1);
            this.randomEffects.Add(CardDB.cardName.mindcontroltech, 1);
            this.randomEffects.Add(CardDB.cardName.mindvision, 1);
            this.randomEffects.Add(CardDB.cardName.powerofthehorde, 1);
            this.randomEffects.Add(CardDB.cardName.sensedemons, 2);
            this.randomEffects.Add(CardDB.cardName.tinkmasteroverspark, 1);
            this.randomEffects.Add(CardDB.cardName.totemiccall, 1);
        }

    }

    public class Helpfunctions
    {

        public static List<T> TakeList<T>(IEnumerable<T> source, int limit)
        {
            List<T> retlist = new List<T>();
            int i = 0;

            foreach (T item in source)
            {
                retlist.Add(item);
                i++;

                if (i >= limit) break;
            }
            return retlist;
        }


        public bool runningbot = false;

        private static Helpfunctions instance;

        public static Helpfunctions Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Helpfunctions();
                }
                return instance;
            }
        }

        private Helpfunctions()
        {

            System.IO.File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, "");
        }

        private bool writelogg = true;
        public void loggonoff(bool onoff)
        {
            //writelogg = onoff;
        }

        public void createNewLoggfile()
        {
            System.IO.File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, "");
        }

        public void logg(string s)
        {


            if (!writelogg) return;
            try
            {
                using (StreamWriter sw = File.AppendText(Settings.Instance.logpath + Settings.Instance.logfile))
                {
                    sw.WriteLine(s);
                }
            }
            catch { }
        }

        public DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public void ErrorLog(string s)
        {
            Logging.Write(s);
        }

    }

    public class ComboBreaker
    {

        enum combotype
        {
            combo,
            target,
            weaponuse
        }

        private Dictionary<CardDB.cardIDEnum, int> playByValue = new Dictionary<CardDB.cardIDEnum, int>();

        private List<combo> combos = new List<combo>();
        private static ComboBreaker instance;

        Handmanager hm = Handmanager.Instance;
        Hrtprozis hp = Hrtprozis.Instance;

        public int attackFaceHP = -1;


        class combo
        {
            public combotype type = combotype.combo;
            public int neededMana = 0;
            public Dictionary<CardDB.cardIDEnum, int> combocards = new Dictionary<CardDB.cardIDEnum, int>();
            public Dictionary<CardDB.cardIDEnum, int> cardspen = new Dictionary<CardDB.cardIDEnum, int>();
            public Dictionary<CardDB.cardIDEnum, int> combocardsTurn0Mobs = new Dictionary<CardDB.cardIDEnum, int>();
            public Dictionary<CardDB.cardIDEnum, int> combocardsTurn0All = new Dictionary<CardDB.cardIDEnum, int>();
            public Dictionary<CardDB.cardIDEnum, int> combocardsTurn1 = new Dictionary<CardDB.cardIDEnum, int>();
            public int penality = 0;
            public int combolength = 0;
            public int combot0len = 0;
            public int combot1len = 0;
            public int combot0lenAll = 0;
            public bool twoTurnCombo = false;
            public int bonusForPlaying = 0;
            public int bonusForPlayingT0 = 0;
            public int bonusForPlayingT1 = 0;
            public CardDB.cardName requiredWeapon = CardDB.cardName.unknown;
            public HeroEnum oHero = HeroEnum.None;

            public combo(string s)
            {
                int i = 0;
                this.neededMana = 0;
                requiredWeapon = CardDB.cardName.unknown;
                this.type = combotype.combo;
                this.twoTurnCombo = false;
                bool fixmana = false;
                if (s.Contains("nxttrn")) this.twoTurnCombo = true;
                if (s.Contains("mana:")) fixmana = true;

                /*foreach (string ding in s.Split(':'))
                {
                    if (i == 0)
                    {
                        if (ding == "c") this.type = combotype.combo;
                        if (ding == "t") this.type = combotype.target;
                        if (ding == "w") this.type = combotype.weaponuse;
                    }
                    if (ding == "" || ding == string.Empty) continue;

                    if (i == 1 && type == combotype.combo)
                    {
                        int m = Convert.ToInt32(ding);
                        neededMana = -1;
                        if (m >= 1) neededMana = m;
                    }
                */
                if (type == combotype.combo)
                {
                    this.combolength = 0;
                    this.combot0len = 0;
                    this.combot1len = 0;
                    this.combot0lenAll = 0;
                    int manat0 = 0;
                    int manat1 = -1;
                    bool t1 = false;
                    foreach (string crdl in s.Split(';')) //ding.Split
                    {
                        if (crdl == "" || crdl == string.Empty) continue;
                        if (crdl == "nxttrn")
                        {
                            t1 = true;
                            continue;
                        }
                        if (crdl.StartsWith("mana:"))
                        {
                            this.neededMana = Convert.ToInt32(crdl.Replace("mana:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("hero:"))
                        {
                            this.oHero = Hrtprozis.Instance.heroNametoEnum(crdl.Replace("hero:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("bonus:"))
                        {
                            this.bonusForPlaying = Convert.ToInt32(crdl.Replace("bonus:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("bonusfirst:"))
                        {
                            this.bonusForPlayingT0 = Convert.ToInt32(crdl.Replace("bonusfirst:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("bonussecond:"))
                        {
                            this.bonusForPlayingT1 = Convert.ToInt32(crdl.Replace("bonussecond:", ""));
                            continue;
                        }
                        string crd = crdl.Split(',')[0];
                        if (t1)
                        {
                            manat1 += CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(crd)).cost;
                        }
                        else
                        {
                            manat0 += CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(crd)).cost;
                        }
                        this.combolength++;

                        if (combocards.ContainsKey(CardDB.Instance.cardIdstringToEnum(crd)))
                        {
                            combocards[CardDB.Instance.cardIdstringToEnum(crd)]++;
                        }
                        else
                        {
                            combocards.Add(CardDB.Instance.cardIdstringToEnum(crd), 1);
                            cardspen.Add(CardDB.Instance.cardIdstringToEnum(crd), Convert.ToInt32(crdl.Split(',')[1]));
                        }

                        if (this.twoTurnCombo)
                        {

                            if (t1)
                            {
                                if (this.combocardsTurn1.ContainsKey(CardDB.Instance.cardIdstringToEnum(crd)))
                                {
                                    combocardsTurn1[CardDB.Instance.cardIdstringToEnum(crd)]++;
                                }
                                else
                                {
                                    combocardsTurn1.Add(CardDB.Instance.cardIdstringToEnum(crd), 1);
                                }
                                this.combot1len++;
                            }
                            else
                            {
                                CardDB.Card lolcrd = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(crd));
                                if (lolcrd.type == CardDB.cardtype.MOB)
                                {
                                    if (this.combocardsTurn0Mobs.ContainsKey(CardDB.Instance.cardIdstringToEnum(crd)))
                                    {
                                        combocardsTurn0Mobs[CardDB.Instance.cardIdstringToEnum(crd)]++;
                                    }
                                    else
                                    {
                                        combocardsTurn0Mobs.Add(CardDB.Instance.cardIdstringToEnum(crd), 1);
                                    }
                                    this.combot0len++;
                                }
                                if (lolcrd.type == CardDB.cardtype.WEAPON)
                                {
                                    this.requiredWeapon = lolcrd.name;
                                }
                                if (this.combocardsTurn0All.ContainsKey(CardDB.Instance.cardIdstringToEnum(crd)))
                                {
                                    combocardsTurn0All[CardDB.Instance.cardIdstringToEnum(crd)]++;
                                }
                                else
                                {
                                    combocardsTurn0All.Add(CardDB.Instance.cardIdstringToEnum(crd), 1);
                                }
                                this.combot0lenAll++;
                            }
                        }


                    }
                    if (!fixmana)
                    {
                        this.neededMana = Math.Max(manat1, manat0);
                    }
                }

                /*if (i == 2 && type == combotype.combo)
                {
                    int m = Convert.ToInt32(ding);
                    penality = 0;
                    if (m >= 1) penality = m;
                }

                i++;
            }*/
            }

            public int isInCombo(List<Handmanager.Handcard> hand, int omm)
            {
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocards);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }
                if (cardsincombo == this.combolength && omm < this.neededMana) return 1;
                if (cardsincombo == this.combolength) return 2;
                if (cardsincombo >= 1) return 1;
                return 0;
            }

            public int isMultiTurnComboTurn1(List<Handmanager.Handcard> hand, int omm, List<Minion> ownmins, CardDB.cardName weapon)
            {
                if (!twoTurnCombo) return 0;
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocardsTurn1);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }
                if (cardsincombo == this.combot1len && omm < this.neededMana) return 1;

                if (cardsincombo == this.combot1len)
                {
                    //search for required minions on field
                    int turn0requires = 0;
                    foreach (CardDB.cardIDEnum s in combocardsTurn0Mobs.Keys)
                    {
                        foreach (Minion m in ownmins)
                        {
                            if (!m.playedThisTurn && m.handcard.card.cardIDenum == s)
                            {
                                turn0requires++;
                                break;
                            }
                        }
                    }

                    if (requiredWeapon != CardDB.cardName.unknown && requiredWeapon != weapon) return 1;

                    if (turn0requires >= combot0len) return 2;

                    return 1;
                }
                if (cardsincombo >= 1) return 1;
                return 0;
            }

            public int isMultiTurnComboTurn0(List<Handmanager.Handcard> hand, int omm)
            {
                if (!twoTurnCombo) return 0;
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocardsTurn0All);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }
                if (cardsincombo == this.combot0lenAll && omm < this.neededMana) return 1;

                if (cardsincombo == this.combot0lenAll)
                {
                    return 2;
                }
                if (cardsincombo >= 1) return 1;
                return 0;
            }


            public bool isMultiTurn1Card(CardDB.Card card)
            {
                if (this.combocardsTurn1.ContainsKey(card.cardIDenum))
                {
                    return true;
                }
                return false;
            }

            public bool isCardInCombo(CardDB.Card card)
            {
                if (this.combocards.ContainsKey(card.cardIDenum))
                {
                    return true;
                }
                return false;
            }

            public int hasPlayedCombo(List<Handmanager.Handcard> hand)
            {
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocards);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }

                if (cardsincombo >= this.combolength) return this.bonusForPlaying;
                return 0;
            }

            public int hasPlayedTurn0Combo(List<Handmanager.Handcard> hand)
            {
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocardsTurn0All);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }

                if (cardsincombo >= this.combot0lenAll) return this.bonusForPlayingT0;
                return 0;
            }

            public int hasPlayedTurn1Combo(List<Handmanager.Handcard> hand)
            {
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocardsTurn1);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }

                if (cardsincombo >= this.combot1len) return this.bonusForPlayingT1;
                return 0;
            }

        }

        public static ComboBreaker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComboBreaker();
                }
                return instance;
            }
        }

        private ComboBreaker()
        {
            readCombos();
            if (attackFaceHP != -1)
            {
                hp.setAttackFaceHP(attackFaceHP);
            }
        }

        private void readCombos()
        {
            string[] lines = new string[0] { };
            combos.Clear();
            try
            {
                string path = Settings.Instance.path;
                lines = System.IO.File.ReadAllLines(path + "_combo.txt");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find _combo.txt");
                Helpfunctions.Instance.ErrorLog("cant find _combo.txt (if you dont created your own combos, ignore this message)");
                return;
            }
            Helpfunctions.Instance.logg("read _combo.txt...");
            Helpfunctions.Instance.ErrorLog("read _combo.txt...");
            foreach (string line in lines)
            {

                if (line.Contains("weapon:"))
                {
                    try
                    {
                        this.attackFaceHP = Convert.ToInt32(line.Replace("weapon:", ""));
                    }
                    catch
                    {
                        Helpfunctions.Instance.logg("combomaker cant read: " + line);
                        Helpfunctions.Instance.ErrorLog("combomaker cant read: " + line);
                    }
                }
                else
                {
                    if (line.Contains("cardvalue:"))
                    {
                        try
                        {
                            string cardvalue = line.Replace("cardvalue:", "");
                            CardDB.cardIDEnum ce = CardDB.Instance.cardIdstringToEnum(cardvalue.Split(',')[0]);
                            int val = Convert.ToInt32(cardvalue.Split(',')[1]);
                            if (this.playByValue.ContainsKey(ce)) continue;
                            this.playByValue.Add(ce, val);
                            //Helpfunctions.Instance.ErrorLog("adding: " + line);
                        }
                        catch
                        {
                            Helpfunctions.Instance.logg("combomaker cant read: " + line);
                            Helpfunctions.Instance.ErrorLog("combomaker cant read: " + line);
                        }
                    }
                    else
                    {
                        try
                        {
                            combo c = new combo(line);
                            this.combos.Add(c);
                        }
                        catch
                        {
                            Helpfunctions.Instance.logg("combomaker cant read: " + line);
                            Helpfunctions.Instance.ErrorLog("combomaker cant read: " + line);
                        }
                    }
                }

            }

        }

        public int getPenalityForDestroyingCombo(CardDB.Card crd, Playfield p)
        {
            if (this.combos.Count == 0) return 0;
            int pen = int.MaxValue;
            bool found = false;
            int mana = Math.Max(hp.ownMaxMana, hp.currentMana);
            foreach (combo c in this.combos)
            {
                if ((c.oHero == HeroEnum.None || c.oHero == p.ownHeroName) && c.isCardInCombo(crd))
                {
                    int iia = c.isInCombo(hm.handCards, hp.ownMaxMana);//check if we have all cards for a combo, and if the choosen card is one
                    int iib = c.isMultiTurnComboTurn1(hm.handCards, mana, p.ownMinions, p.ownWeaponName);

                    int iic = Math.Max(iia, iib);
                    if (iia == 2 && iib != 2 && c.isMultiTurn1Card(crd))// it is a card of the combo, is a turn 1 card, but turn 1 is not possible -> we have to play turn 0 cards first
                    {
                        iic = 1;
                    }
                    if (iic == 1) found = true;
                    if (iic == 1 && pen > c.cardspen[crd.cardIDenum]) pen = c.cardspen[crd.cardIDenum];//iic==1 will destroy combo
                    if (iic == 2) pen = 0;//card is ok to play
                }

            }
            if (found) { return pen; }
            return 0;

        }

        public int checkIfComboWasPlayed(List<Action> alist, CardDB.cardName weapon, HeroEnum heroname)
        {
            if (this.combos.Count == 0) return 0;
            //returns a penalty only if the combo could be played, but is not played completely
            List<Handmanager.Handcard> playedcards = new List<Handmanager.Handcard>();
            List<combo> searchingCombo = new List<combo>();
            // only check the cards, that are in a combo that can be played:
            int mana = Math.Max(hp.ownMaxMana, hp.currentMana);
            foreach (Action a in alist)
            {
                if (!a.cardplay) continue;
                CardDB.Card crd = a.handcard.card;
                //playedcards.Add(a.handcard);
                foreach (combo c in this.combos)
                {
                    if ((c.oHero == HeroEnum.None || c.oHero == heroname) && c.isCardInCombo(crd))
                    {
                        int iia = c.isInCombo(hm.handCards, hp.ownMaxMana);
                        int iib = c.isMultiTurnComboTurn1(hm.handCards, mana, hp.ownMinions, weapon);
                        int iic = Math.Max(iia, iib);
                        if (iia == 2 && iib != 2 && c.isMultiTurn1Card(crd))
                        {
                            iic = 1;
                        }
                        if (iic == 2)
                        {
                            playedcards.Add(a.handcard); // add only the cards, which dont get a penalty
                        }
                    }

                }
            }

            if (playedcards.Count == 0) return 0;

            bool wholeComboPlayed = false;

            int bonus = 0;
            foreach (combo c in this.combos)
            {
                int iia = c.hasPlayedCombo(playedcards);
                int iib = c.hasPlayedTurn0Combo(playedcards);
                int iic = c.hasPlayedTurn1Combo(playedcards);
                int iie = iia + iib + iic;
                if (iie >= 1)
                {
                    wholeComboPlayed = true;
                    bonus -= iie;
                }
            }

            if (wholeComboPlayed) return bonus;
            return 250;

        }

        public int getPlayValue(CardDB.cardIDEnum ce)
        {
            if (this.playByValue.Count == 0) return 0;
            if (this.playByValue.ContainsKey(ce))
            {
                return this.playByValue[ce];
            }
            return 0;

        }

    }

    public class Mulligan
    {
        public class CardIDEntity
        {
            public string id = "";
            public int entitiy = 0;
            public CardIDEntity(string id, int entt)
            {
                this.id = id;
                this.entitiy = entt;
            }
        }

        class mulliitem
        {
            public string cardid = "";
            public string enemyclass = "";
            public string ownclass = "";
            public int howmuch = 2;
            public string[] requiresCard = null;
            public int manarule = -1;

            public mulliitem(string id, string own, string enemy, int number, string[] req = null, int mrule = -1)
            {
                this.cardid = id;
                this.ownclass = own;
                this.enemyclass = enemy;
                this.howmuch = number;
                this.requiresCard = req;
                this.manarule = mrule;
            }
        }

        class concedeItem
        {
            public HeroEnum urhero = HeroEnum.None;
            public List<HeroEnum> enemhero = new List<HeroEnum>();
        }

        List<mulliitem> holdlist = new List<mulliitem>();
        List<mulliitem> deletelist = new List<mulliitem>();
        List<concedeItem> concedelist = new List<concedeItem>();
        public bool loserLoserLoser = false;

        private static Mulligan instance;

        public static Mulligan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Mulligan();
                }
                return instance;
            }
        }

        private Mulligan()
        {
            readCombos();
        }

        private void readCombos()
        {
            string[] lines = new string[0] { };
            this.holdlist.Clear();
            this.deletelist.Clear();
            try
            {
                string path = Settings.Instance.path;
                lines = System.IO.File.ReadAllLines(path + "_mulligan.txt");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find _mulligan.txt");
                Helpfunctions.Instance.ErrorLog("cant find _mulligan.txt (if you dont created your own mulliganfile, ignore this message)");
                return;
            }
            Helpfunctions.Instance.logg("read _mulligan.txt...");
            Helpfunctions.Instance.ErrorLog("read _mulligan.txt...");
            foreach (string line in lines)
            {
                if (line.StartsWith("loser"))
                {
                    this.loserLoserLoser = true;
                    continue;
                }

                if (line.StartsWith("concede:"))
                {
                    try
                    {
                        string ownh = line.Split(':')[1];
                        concedeItem ci = new concedeItem();
                        ci.urhero = Hrtprozis.Instance.heroNametoEnum(ownh);
                        string enemlist = line.Split(':')[2];
                        foreach (string s in enemlist.Split(','))
                        {
                            ci.enemhero.Add(Hrtprozis.Instance.heroNametoEnum(s));
                        }
                        concedelist.Add(ci);
                    }
                    catch
                    {
                        Helpfunctions.Instance.logg("mullimaker cant read: " + line);
                        Helpfunctions.Instance.ErrorLog("mullimaker cant read: " + line);
                    }
                    continue;
                }

                if (line.StartsWith("hold;"))
                {
                    try
                    {
                        string ownclass = line.Split(';')[1];
                        string enemyclass = line.Split(';')[2];
                        string cardlist = line.Split(';')[3];
                        foreach (string crd in cardlist.Split(','))
                        {
                            if (crd.Contains(":"))
                            {
                                if ((crd.Split(':')).Length == 3)
                                {
                                    this.holdlist.Add(new mulliitem(crd.Split(':')[0], ownclass, enemyclass, Convert.ToInt32(crd.Split(':')[1]), crd.Split(':')[2].Split('/')));
                                }
                                else
                                {
                                    this.holdlist.Add(new mulliitem(crd.Split(':')[0], ownclass, enemyclass, Convert.ToInt32(crd.Split(':')[1])));
                                }

                            }
                            else
                            {
                                this.holdlist.Add(new mulliitem(crd, ownclass, enemyclass, 2));
                            }
                        }

                        if (line.Split(';').Length == 5)
                        {
                            int manarule = Convert.ToInt32(line.Split(';')[4]);
                            this.holdlist.Add(new mulliitem("#MANARULE", ownclass, enemyclass, 2, null, manarule));
                        }

                    }
                    catch
                    {
                        Helpfunctions.Instance.logg("mullimaker cant read: " + line);
                        Helpfunctions.Instance.ErrorLog("mullimaker cant read: " + line);
                    }
                }
                else
                {
                    if (line.StartsWith("discard;"))
                    {
                        try
                        {
                            string ownclass = line.Split(';')[1];
                            string enemyclass = line.Split(';')[2];
                            string cardlist = line.Split(';')[3];
                            foreach (string crd in cardlist.Split(','))
                            {
                                if (crd == null || crd == "") continue;
                                this.deletelist.Add(new mulliitem(crd, ownclass, enemyclass, 2));
                            }

                            if (line.Split(';').Length == 5)
                            {
                                int manarule = Convert.ToInt32(line.Split(';')[4]);
                                this.deletelist.Add(new mulliitem("#MANARULE", ownclass, enemyclass, 2, null, manarule));
                            }

                        }
                        catch
                        {
                            Helpfunctions.Instance.logg("mullimaker cant read: " + line);
                            Helpfunctions.Instance.ErrorLog("mullimaker cant read: " + line);
                        }
                    }
                    else
                    {

                    }
                }

            }

        }

        public bool hasmulliganrules()
        {
            if (this.holdlist.Count == 0 && this.deletelist.Count == 0) return false;
            return true;
        }

        public List<int> whatShouldIMulligan(List<CardIDEntity> cards, string ownclass, string enemclass)
        {
            List<int> discarditems = new List<int>();

            foreach (mulliitem mi in this.deletelist)
            {
                foreach (CardIDEntity c in cards)
                {
                    if (mi.cardid == "#MANARULE" && (mi.enemyclass == "all" || mi.enemyclass == enemclass) && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {
                        if (CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(c.id)).cost >= mi.manarule)
                        {
                            if (discarditems.Contains(c.entitiy)) continue;
                            discarditems.Add(c.entitiy);
                        }
                        continue;
                    }

                    if (c.id == mi.cardid && (mi.enemyclass == "all" || mi.enemyclass == enemclass) && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {
                        if (discarditems.Contains(c.entitiy)) continue;
                        discarditems.Add(c.entitiy);
                    }
                }
            }

            if (holdlist.Count == 0) return discarditems;

            Dictionary<string, int> holddic = new Dictionary<string, int>();
            foreach (CardIDEntity c in cards)
            {
                bool delete = true;
                foreach (mulliitem mi in this.holdlist)
                {

                    if (mi.cardid == "#MANARULE" && (mi.enemyclass == "all" || mi.enemyclass == enemclass) && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {
                        if (CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(c.id)).cost <= mi.manarule)
                        {
                            delete = false;
                        }
                        continue;
                    }

                    if (c.id == mi.cardid && (mi.enemyclass == "all" || mi.enemyclass == enemclass) && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {

                        if (mi.requiresCard == null)
                        {

                            if (holddic.ContainsKey(c.id)) // we are holding one of the cards
                            {
                                if (mi.howmuch == 2)
                                {
                                    delete = false;
                                }
                            }
                            else
                            {
                                delete = false;
                            }
                        }
                        else
                        {
                            bool hasRequirements = false;
                            foreach (CardIDEntity reqs in cards)
                            {
                                foreach (string s in mi.requiresCard)
                                {
                                    if (s == reqs.id)
                                    {
                                        hasRequirements = true;
                                        break;
                                    }
                                }
                            }
                            if (hasRequirements)
                            {
                                if (holddic.ContainsKey(c.id)) // we are holding one of the cards
                                {
                                    if (mi.howmuch == 2)
                                    {
                                        delete = false;
                                    }
                                }
                                else
                                {
                                    delete = false;
                                }
                            }

                        }
                    }
                }

                if (delete)
                {
                    if (discarditems.Contains(c.entitiy)) continue;
                    discarditems.Add(c.entitiy);
                }
                else
                {
                    discarditems.RemoveAll(x => x == c.entitiy);

                    if (holddic.ContainsKey(c.id))
                    {
                        holddic[c.id]++;
                    }
                    else
                    {
                        holddic.Add(c.id, 1);
                    }
                }

            }

            return discarditems;

        }

        public void setAutoConcede(bool mode)
        {
            this.loserLoserLoser = mode;
        }

        public bool shouldConcede(HeroEnum ownhero, HeroEnum enemHero)
        {

            foreach (concedeItem ci in concedelist)
            {
                if (ci.urhero == ownhero && ci.enemhero.Contains(enemHero)) return true;
            }

            return false;
        }

    }

    public class CardDB
    {
        // Data is stored in hearthstone-folder -> data->win cardxml0
        //(data-> cardxml0 seems outdated (blutelfkleriker has 3hp there >_>)
        public enum cardtype
        {
            NONE,
            MOB,
            SPELL,
            WEAPON,
            HEROPWR,
            ENCHANTMENT,

        }

        public enum cardIDEnum
        {
            None,
            XXX_040,
            NAX5_01H,
            CS2_188o,
            NAX6_02H,
            NEW1_007b,
            NAX6_02e,
            TU4c_003,
            XXX_024,
            EX1_613,
            NAX8_01,
            EX1_295o,
            CS2_059o,
            EX1_133,
            NEW1_018,
            NAX15_03t,
            EX1_012,
            EX1_178a,
            CS2_231,
            EX1_019e,
            CRED_12,
            CS2_179,
            CS2_045e,
            EX1_244,
            EX1_178b,
            XXX_030,
            NAX8_05,
            EX1_573b,
            TU4d_001,
            NEW1_007a,
            NAX12_02H,
            EX1_345t,
            FP1_007t,
            EX1_025,
            EX1_396,
            NAX9_03,
            NEW1_017,
            NEW1_008a,
            EX1_587e,
            EX1_533,
            EX1_522,
            NAX11_04,
            NEW1_026,
            EX1_398,
            NAX4_04,
            EX1_007,
            CS1_112,
            CRED_17,
            NEW1_036,
            NAX3_03,
            EX1_355e,
            EX1_258,
            HERO_01,
            XXX_009,
            NAX6_01H,
            NAX12_04e,
            CS2_087,
            DREAM_05,
            NEW1_036e,
            CS2_092,
            CS2_022,
            EX1_046,
            XXX_005,
            PRO_001b,
            XXX_022,
            PRO_001a,
            NAX6_04,
            NAX7_05,
            CS2_103,
            NEW1_041,
            EX1_360,
            FP1_023,
            NEW1_038,
            CS2_009,
            NAX10_01H,
            EX1_010,
            CS2_024,
            NAX9_05,
            EX1_565,
            CS2_076,
            FP1_004,
            CS2_046e,
            CS2_162,
            EX1_110t,
            CS2_104e,
            CS2_181,
            EX1_309,
            EX1_354,
            NAX10_02H,
            NAX7_04H,
            TU4f_001,
            XXX_018,
            EX1_023,
            XXX_048,
            XXX_049,
            NEW1_034,
            CS2_003,
            HERO_06,
            CS2_201,
            EX1_508,
            EX1_259,
            EX1_341,
            DREAM_05e,
            CRED_09,
            EX1_103,
            FP1_021,
            EX1_411,
            NAX1_04,
            CS2_053,
            CS2_182,
            CS2_008,
            CS2_233,
            EX1_626,
            EX1_059,
            EX1_334,
            EX1_619,
            NEW1_032,
            EX1_158t,
            EX1_006,
            NEW1_031,
            NAX10_03,
            DREAM_04,
            NAX1h_01,
            CS2_022e,
            EX1_611e,
            EX1_004,
            EX1_014te,
            FP1_005e,
            NAX12_03e,
            EX1_095,
            NEW1_007,
            EX1_275,
            EX1_245,
            EX1_383,
            FP1_016,
            EX1_016t,
            CS2_125,
            EX1_137,
            EX1_178ae,
            DS1_185,
            FP1_010,
            EX1_598,
            NAX9_07,
            EX1_304,
            EX1_302,
            XXX_017,
            CS2_011o,
            EX1_614t,
            TU4a_006,
            Mekka3e,
            CS2_108,
            CS2_046,
            EX1_014t,
            NEW1_005,
            EX1_062,
            EX1_366e,
            Mekka1,
            XXX_007,
            tt_010a,
            CS2_017o,
            CS2_072,
            EX1_tk28,
            EX1_604o,
            FP1_014,
            EX1_084e,
            NAX3_01H,
            NAX2_01,
            EX1_409t,
            CRED_07,
            NAX3_02H,
            TU4e_002,
            EX1_507,
            EX1_144,
            CS2_038,
            EX1_093,
            CS2_080,
            CS1_129e,
            XXX_013,
            EX1_005,
            EX1_382,
            NAX13_02e,
            FP1_020e,
            EX1_603e,
            CS2_028,
            TU4f_002,
            EX1_538,
            GAME_003e,
            DREAM_02,
            EX1_581,
            NAX15_01H,
            EX1_131t,
            CS2_147,
            CS1_113,
            CS2_161,
            CS2_031,
            EX1_166b,
            EX1_066,
            TU4c_007,
            EX1_355,
            EX1_507e,
            EX1_534,
            EX1_162,
            TU4a_004,
            EX1_363,
            EX1_164a,
            CS2_188,
            EX1_016,
            NAX6_03t,
            EX1_tk31,
            EX1_603,
            EX1_238,
            EX1_166,
            DS1h_292,
            DS1_183,
            NAX15_03n,
            NAX8_02H,
            NAX7_01H,
            NAX9_02H,
            CRED_11,
            XXX_019,
            EX1_076,
            EX1_048,
            CS2_038e,
            FP1_026,
            CS2_074,
            FP1_027,
            EX1_323w,
            EX1_129,
            NEW1_024o,
            NAX11_02,
            EX1_405,
            EX1_317,
            EX1_606,
            EX1_590e,
            XXX_044,
            CS2_074e,
            TU4a_005,
            FP1_006,
            EX1_258e,
            TU4f_004o,
            NEW1_008,
            CS2_119,
            NEW1_017e,
            EX1_334e,
            TU4e_001,
            CS2_121,
            CS1h_001,
            EX1_tk34,
            NEW1_020,
            CS2_196,
            EX1_312,
            NAX1_01,
            FP1_022,
            EX1_160b,
            EX1_563,
            XXX_039,
            FP1_031,
            CS2_087e,
            EX1_613e,
            NAX9_02,
            NEW1_029,
            CS1_129,
            HERO_03,
            Mekka4t,
            EX1_158,
            XXX_010,
            NEW1_025,
            FP1_012t,
            EX1_083,
            EX1_295,
            EX1_407,
            NEW1_004,
            FP1_019,
            PRO_001at,
            NAX13_03e,
            EX1_625t,
            EX1_014,
            CRED_04,
            NAX12_01H,
            CS2_097,
            EX1_558,
            XXX_047,
            EX1_tk29,
            CS2_186,
            EX1_084,
            NEW1_012,
            FP1_014t,
            NAX1_03,
            EX1_623e,
            EX1_578,
            CS2_073e2,
            CS2_221,
            EX1_019,
            NAX15_04a,
            FP1_019t,
            EX1_132,
            EX1_284,
            EX1_105,
            NEW1_011,
            NAX9_07e,
            EX1_017,
            EX1_249,
            EX1_162o,
            FP1_002t,
            NAX3_02,
            EX1_313,
            EX1_549o,
            EX1_091o,
            CS2_084e,
            EX1_155b,
            NAX11_01,
            NEW1_033,
            CS2_106,
            XXX_002,
            FP1_018,
            NEW1_036e2,
            XXX_004,
            NAX11_02H,
            CS2_122e,
            DS1_233,
            DS1_175,
            NEW1_024,
            CS2_189,
            CRED_10,
            NEW1_037,
            EX1_414,
            EX1_538t,
            FP1_030e,
            EX1_586,
            EX1_310,
            NEW1_010,
            CS2_103e,
            EX1_080o,
            CS2_005o,
            EX1_363e2,
            EX1_534t,
            FP1_028,
            EX1_604,
            EX1_160,
            EX1_165t1,
            CS2_062,
            CS2_155,
            CS2_213,
            TU4f_007,
            GAME_004,
            NAX5_01,
            XXX_020,
            NAX15_02H,
            CS2_004,
            NAX2_03H,
            EX1_561e,
            CS2_023,
            EX1_164,
            EX1_009,
            NAX6_01,
            FP1_007,
            NAX1h_04,
            NAX2_05H,
            NAX10_02,
            EX1_345,
            EX1_116,
            EX1_399,
            EX1_587,
            XXX_026,
            EX1_571,
            EX1_335,
            XXX_050,
            TU4e_004,
            HERO_08,
            EX1_166a,
            NAX2_03,
            EX1_finkle,
            NAX4_03H,
            EX1_164b,
            EX1_283,
            EX1_339,
            CRED_13,
            EX1_178be,
            EX1_531,
            EX1_134,
            EX1_350,
            EX1_308,
            CS2_197,
            skele21,
            CS2_222o,
            XXX_015,
            FP1_013,
            NEW1_006,
            EX1_399e,
            EX1_509,
            EX1_612,
            NAX8_05t,
            NAX9_05H,
            EX1_021,
            CS2_041e,
            CS2_226,
            EX1_608,
            NAX13_05H,
            NAX13_04H,
            TU4c_008,
            EX1_624,
            EX1_616,
            EX1_008,
            PlaceholderCard,
            XXX_016,
            EX1_045,
            EX1_015,
            GAME_003,
            CS2_171,
            CS2_041,
            EX1_128,
            CS2_112,
            HERO_07,
            EX1_412,
            EX1_612o,
            CS2_117,
            XXX_009e,
            EX1_562,
            EX1_055,
            NAX9_06,
            TU4e_007,
            FP1_012,
            EX1_317t,
            EX1_004e,
            EX1_278,
            CS2_tk1,
            EX1_590,
            CS1_130,
            NEW1_008b,
            EX1_365,
            CS2_141,
            PRO_001,
            NAX8_04t,
            CS2_173,
            CS2_017,
            CRED_16,
            EX1_392,
            EX1_593,
            FP1_023e,
            NAX1_05,
            TU4d_002,
            CRED_15,
            EX1_049,
            EX1_002,
            TU4f_005,
            NEW1_029t,
            TU4a_001,
            CS2_056,
            EX1_596,
            EX1_136,
            EX1_323,
            CS2_073,
            EX1_246e,
            NAX12_01,
            EX1_244e,
            EX1_001,
            EX1_607e,
            EX1_044,
            EX1_573ae,
            XXX_025,
            CRED_06,
            Mekka4,
            CS2_142,
            TU4f_004,
            NAX5_02H,
            EX1_411e2,
            EX1_573,
            FP1_009,
            CS2_050,
            NAX4_03,
            CS2_063e,
            NAX2_05,
            EX1_390,
            EX1_610,
            hexfrog,
            CS2_181e,
            NAX6_02,
            XXX_027,
            CS2_082,
            NEW1_040,
            DREAM_01,
            EX1_595,
            CS2_013,
            CS2_077,
            NEW1_014,
            CRED_05,
            GAME_002,
            EX1_165,
            CS2_013t,
            NAX4_04H,
            EX1_tk11,
            EX1_591,
            EX1_549,
            CS2_045,
            CS2_237,
            CS2_027,
            EX1_508o,
            NAX14_03,
            CS2_101t,
            CS2_063,
            EX1_145,
            NAX1h_03,
            EX1_110,
            EX1_408,
            EX1_544,
            TU4c_006,
            NAXM_001,
            CS2_151,
            CS2_073e,
            XXX_006,
            CS2_088,
            EX1_057,
            FP1_020,
            CS2_169,
            EX1_573t,
            EX1_323h,
            EX1_tk9,
            NEW1_018e,
            CS2_037,
            CS2_007,
            EX1_059e2,
            CS2_227,
            NAX7_03H,
            NAX9_01H,
            EX1_570e,
            NEW1_003,
            GAME_006,
            EX1_320,
            EX1_097,
            tt_004,
            EX1_360e,
            EX1_096,
            DS1_175o,
            EX1_596e,
            XXX_014,
            EX1_158e,
            NAX14_01,
            CRED_01,
            CRED_08,
            EX1_126,
            EX1_577,
            EX1_319,
            EX1_611,
            CS2_146,
            EX1_154b,
            skele11,
            EX1_165t2,
            CS2_172,
            CS2_114,
            CS1_069,
            XXX_003,
            XXX_042,
            NAX8_02,
            EX1_173,
            CS1_042,
            NAX8_03,
            EX1_506a,
            EX1_298,
            CS2_104,
            FP1_001,
            HERO_02,
            EX1_316e,
            NAX7_01,
            EX1_044e,
            CS2_051,
            NEW1_016,
            EX1_304e,
            EX1_033,
            NAX8_04,
            EX1_028,
            XXX_011,
            EX1_621,
            EX1_554,
            EX1_091,
            FP1_017,
            EX1_409,
            EX1_363e,
            EX1_410,
            TU4e_005,
            CS2_039,
            NAX12_04,
            EX1_557,
            CS2_105e,
            EX1_128e,
            XXX_021,
            DS1_070,
            CS2_033,
            EX1_536,
            TU4a_003,
            EX1_559,
            XXX_023,
            NEW1_033o,
            NAX15_04H,
            CS2_004e,
            CS2_052,
            EX1_539,
            EX1_575,
            CS2_083b,
            CS2_061,
            NEW1_021,
            DS1_055,
            EX1_625,
            EX1_382e,
            CS2_092e,
            CS2_026,
            NAX14_04,
            NEW1_012o,
            EX1_619e,
            EX1_294,
            EX1_287,
            EX1_509e,
            EX1_625t2,
            CS2_118,
            CS2_124,
            Mekka3,
            NAX13_02,
            EX1_112,
            FP1_011,
            CS2_009e,
            HERO_04,
            EX1_607,
            DREAM_03,
            NAX11_04e,
            EX1_103e,
            XXX_046,
            FP1_003,
            CS2_105,
            FP1_002,
            TU4c_002,
            CRED_14,
            EX1_567,
            TU4c_004,
            NAX10_03H,
            FP1_008,
            DS1_184,
            CS2_029,
            GAME_005,
            CS2_187,
            EX1_020,
            NAX15_01He,
            EX1_011,
            CS2_057,
            EX1_274,
            EX1_306,
            NEW1_038o,
            EX1_170,
            EX1_617,
            CS1_113e,
            CS2_101,
            FP1_015,
            NAX13_03,
            CS2_005,
            EX1_537,
            EX1_384,
            TU4a_002,
            NAX9_04,
            EX1_362,
            NAX12_02,
            FP1_028e,
            TU4c_005,
            EX1_301,
            CS2_235,
            NAX4_05,
            EX1_029,
            CS2_042,
            EX1_155a,
            CS2_102,
            EX1_609,
            NEW1_027,
            CS2_236e,
            CS2_083e,
            NAX6_03te,
            EX1_165a,
            EX1_570,
            EX1_131,
            EX1_556,
            EX1_543,
            XXX_096,
            TU4c_008e,
            EX1_379e,
            NEW1_009,
            EX1_100,
            EX1_274e,
            CRED_02,
            EX1_573a,
            CS2_084,
            EX1_582,
            EX1_043,
            EX1_050,
            TU4b_001,
            FP1_005,
            EX1_620,
            NAX15_01,
            NAX6_03,
            EX1_303,
            HERO_09,
            EX1_067,
            XXX_028,
            EX1_277,
            Mekka2,
            NAX14_01H,
            NAX15_04,
            FP1_024,
            FP1_030,
            CS2_221e,
            EX1_178,
            CS2_222,
            EX1_409e,
            tt_004o,
            EX1_155ae,
            NAX11_01H,
            EX1_160a,
            NAX15_02,
            NAX15_05,
            NEW1_025e,
            CS2_012,
            XXX_099,
            EX1_246,
            EX1_572,
            EX1_089,
            CS2_059,
            EX1_279,
            NAX12_02e,
            CS2_168,
            tt_010,
            NEW1_023,
            CS2_075,
            EX1_316,
            CS2_025,
            CS2_234,
            XXX_043,
            GAME_001,
            NAX5_02,
            EX1_130,
            EX1_584e,
            CS2_064,
            EX1_161,
            CS2_049,
            NAX13_01,
            EX1_154,
            EX1_080,
            NEW1_022,
            NAX2_01H,
            EX1_160be,
            NAX12_03,
            EX1_251,
            FP1_025,
            EX1_371,
            CS2_mirror,
            NAX4_01H,
            EX1_594,
            NAX14_02,
            TU4c_006e,
            EX1_560,
            CS2_236,
            TU4f_006,
            EX1_402,
            NAX3_01,
            EX1_506,
            NEW1_027e,
            DS1_070o,
            XXX_045,
            XXX_029,
            DS1_178,
            XXX_098,
            EX1_315,
            CS2_094,
            NAX13_01H,
            TU4e_002t,
            EX1_046e,
            NEW1_040t,
            GAME_005e,
            CS2_131,
            XXX_008,
            EX1_531e,
            CS2_226e,
            XXX_022e,
            DS1_178e,
            CS2_226o,
            NAX9_04H,
            Mekka4e,
            EX1_082,
            CS2_093,
            EX1_411e,
            NAX8_03t,
            EX1_145o,
            NAX7_04,
            CS2_boar,
            NEW1_019,
            EX1_289,
            EX1_025t,
            EX1_398t,
            NAX12_03H,
            EX1_055o,
            CS2_091,
            EX1_241,
            EX1_085,
            CS2_200,
            CS2_034,
            EX1_583,
            EX1_584,
            EX1_155,
            EX1_622,
            CS2_203,
            EX1_124,
            EX1_379,
            NAX7_02,
            CS2_053e,
            EX1_032,
            NAX9_01,
            TU4e_003,
            CS2_146o,
            NAX8_01H,
            XXX_041,
            NAXM_002,
            EX1_391,
            EX1_366,
            EX1_059e,
            XXX_012,
            EX1_565o,
            EX1_001e,
            TU4f_003,
            EX1_400,
            EX1_614,
            EX1_561,
            EX1_332,
            HERO_05,
            CS2_065,
            ds1_whelptoken,
            EX1_536e,
            CS2_032,
            CS2_120,
            EX1_155be,
            EX1_247,
            EX1_154a,
            EX1_554t,
            CS2_103e2,
            TU4d_003,
            NEW1_026t,
            EX1_623,
            EX1_383t,
            NAX7_03,
            EX1_597,
            TU4f_006o,
            EX1_130a,
            CS2_011,
            EX1_169,
            EX1_tk33,
            NAX11_03,
            NAX4_01,
            NAX10_01,
            EX1_250,
            EX1_564,
            NAX5_03,
            EX1_043e,
            EX1_349,
            XXX_097,
            EX1_102,
            EX1_058,
            EX1_243,
            PRO_001c,
            EX1_116t,
            NAX15_01e,
            FP1_029,
            CS2_089,
            TU4c_001,
            EX1_248,
            NEW1_037e,
            CS2_122,
            EX1_393,
            CS2_232,
            EX1_165b,
            NEW1_030,
            EX1_161o,
            EX1_093e,
            CS2_150,
            CS2_152,
            NAX9_03H,
            EX1_160t,
            CS2_127,
            CRED_03,
            DS1_188,
            XXX_001,
        }

        public cardIDEnum cardIdstringToEnum(string s)
        {
            if (s == "XXX_040") return CardDB.cardIDEnum.XXX_040;
            if (s == "NAX5_01H") return CardDB.cardIDEnum.NAX5_01H;
            if (s == "CS2_188o") return CardDB.cardIDEnum.CS2_188o;
            if (s == "NAX6_02H") return CardDB.cardIDEnum.NAX6_02H;
            if (s == "NEW1_007b") return CardDB.cardIDEnum.NEW1_007b;
            if (s == "NAX6_02e") return CardDB.cardIDEnum.NAX6_02e;
            if (s == "TU4c_003") return CardDB.cardIDEnum.TU4c_003;
            if (s == "XXX_024") return CardDB.cardIDEnum.XXX_024;
            if (s == "EX1_613") return CardDB.cardIDEnum.EX1_613;
            if (s == "NAX8_01") return CardDB.cardIDEnum.NAX8_01;
            if (s == "EX1_295o") return CardDB.cardIDEnum.EX1_295o;
            if (s == "CS2_059o") return CardDB.cardIDEnum.CS2_059o;
            if (s == "EX1_133") return CardDB.cardIDEnum.EX1_133;
            if (s == "NEW1_018") return CardDB.cardIDEnum.NEW1_018;
            if (s == "NAX15_03t") return CardDB.cardIDEnum.NAX15_03t;
            if (s == "EX1_012") return CardDB.cardIDEnum.EX1_012;
            if (s == "EX1_178a") return CardDB.cardIDEnum.EX1_178a;
            if (s == "CS2_231") return CardDB.cardIDEnum.CS2_231;
            if (s == "EX1_019e") return CardDB.cardIDEnum.EX1_019e;
            if (s == "CRED_12") return CardDB.cardIDEnum.CRED_12;
            if (s == "CS2_179") return CardDB.cardIDEnum.CS2_179;
            if (s == "CS2_045e") return CardDB.cardIDEnum.CS2_045e;
            if (s == "EX1_244") return CardDB.cardIDEnum.EX1_244;
            if (s == "EX1_178b") return CardDB.cardIDEnum.EX1_178b;
            if (s == "XXX_030") return CardDB.cardIDEnum.XXX_030;
            if (s == "NAX8_05") return CardDB.cardIDEnum.NAX8_05;
            if (s == "EX1_573b") return CardDB.cardIDEnum.EX1_573b;
            if (s == "TU4d_001") return CardDB.cardIDEnum.TU4d_001;
            if (s == "NEW1_007a") return CardDB.cardIDEnum.NEW1_007a;
            if (s == "NAX12_02H") return CardDB.cardIDEnum.NAX12_02H;
            if (s == "EX1_345t") return CardDB.cardIDEnum.EX1_345t;
            if (s == "FP1_007t") return CardDB.cardIDEnum.FP1_007t;
            if (s == "EX1_025") return CardDB.cardIDEnum.EX1_025;
            if (s == "EX1_396") return CardDB.cardIDEnum.EX1_396;
            if (s == "NAX9_03") return CardDB.cardIDEnum.NAX9_03;
            if (s == "NEW1_017") return CardDB.cardIDEnum.NEW1_017;
            if (s == "NEW1_008a") return CardDB.cardIDEnum.NEW1_008a;
            if (s == "EX1_587e") return CardDB.cardIDEnum.EX1_587e;
            if (s == "EX1_533") return CardDB.cardIDEnum.EX1_533;
            if (s == "EX1_522") return CardDB.cardIDEnum.EX1_522;
            if (s == "NAX11_04") return CardDB.cardIDEnum.NAX11_04;
            if (s == "NEW1_026") return CardDB.cardIDEnum.NEW1_026;
            if (s == "EX1_398") return CardDB.cardIDEnum.EX1_398;
            if (s == "NAX4_04") return CardDB.cardIDEnum.NAX4_04;
            if (s == "EX1_007") return CardDB.cardIDEnum.EX1_007;
            if (s == "CS1_112") return CardDB.cardIDEnum.CS1_112;
            if (s == "CRED_17") return CardDB.cardIDEnum.CRED_17;
            if (s == "NEW1_036") return CardDB.cardIDEnum.NEW1_036;
            if (s == "NAX3_03") return CardDB.cardIDEnum.NAX3_03;
            if (s == "EX1_355e") return CardDB.cardIDEnum.EX1_355e;
            if (s == "EX1_258") return CardDB.cardIDEnum.EX1_258;
            if (s == "HERO_01") return CardDB.cardIDEnum.HERO_01;
            if (s == "XXX_009") return CardDB.cardIDEnum.XXX_009;
            if (s == "NAX6_01H") return CardDB.cardIDEnum.NAX6_01H;
            if (s == "NAX12_04e") return CardDB.cardIDEnum.NAX12_04e;
            if (s == "CS2_087") return CardDB.cardIDEnum.CS2_087;
            if (s == "DREAM_05") return CardDB.cardIDEnum.DREAM_05;
            if (s == "NEW1_036e") return CardDB.cardIDEnum.NEW1_036e;
            if (s == "CS2_092") return CardDB.cardIDEnum.CS2_092;
            if (s == "CS2_022") return CardDB.cardIDEnum.CS2_022;
            if (s == "EX1_046") return CardDB.cardIDEnum.EX1_046;
            if (s == "XXX_005") return CardDB.cardIDEnum.XXX_005;
            if (s == "PRO_001b") return CardDB.cardIDEnum.PRO_001b;
            if (s == "XXX_022") return CardDB.cardIDEnum.XXX_022;
            if (s == "PRO_001a") return CardDB.cardIDEnum.PRO_001a;
            if (s == "NAX6_04") return CardDB.cardIDEnum.NAX6_04;
            if (s == "NAX7_05") return CardDB.cardIDEnum.NAX7_05;
            if (s == "CS2_103") return CardDB.cardIDEnum.CS2_103;
            if (s == "NEW1_041") return CardDB.cardIDEnum.NEW1_041;
            if (s == "EX1_360") return CardDB.cardIDEnum.EX1_360;
            if (s == "FP1_023") return CardDB.cardIDEnum.FP1_023;
            if (s == "NEW1_038") return CardDB.cardIDEnum.NEW1_038;
            if (s == "CS2_009") return CardDB.cardIDEnum.CS2_009;
            if (s == "NAX10_01H") return CardDB.cardIDEnum.NAX10_01H;
            if (s == "EX1_010") return CardDB.cardIDEnum.EX1_010;
            if (s == "CS2_024") return CardDB.cardIDEnum.CS2_024;
            if (s == "NAX9_05") return CardDB.cardIDEnum.NAX9_05;
            if (s == "EX1_565") return CardDB.cardIDEnum.EX1_565;
            if (s == "CS2_076") return CardDB.cardIDEnum.CS2_076;
            if (s == "FP1_004") return CardDB.cardIDEnum.FP1_004;
            if (s == "CS2_046e") return CardDB.cardIDEnum.CS2_046e;
            if (s == "CS2_162") return CardDB.cardIDEnum.CS2_162;
            if (s == "EX1_110t") return CardDB.cardIDEnum.EX1_110t;
            if (s == "CS2_104e") return CardDB.cardIDEnum.CS2_104e;
            if (s == "CS2_181") return CardDB.cardIDEnum.CS2_181;
            if (s == "EX1_309") return CardDB.cardIDEnum.EX1_309;
            if (s == "EX1_354") return CardDB.cardIDEnum.EX1_354;
            if (s == "NAX10_02H") return CardDB.cardIDEnum.NAX10_02H;
            if (s == "NAX7_04H") return CardDB.cardIDEnum.NAX7_04H;
            if (s == "TU4f_001") return CardDB.cardIDEnum.TU4f_001;
            if (s == "XXX_018") return CardDB.cardIDEnum.XXX_018;
            if (s == "EX1_023") return CardDB.cardIDEnum.EX1_023;
            if (s == "XXX_048") return CardDB.cardIDEnum.XXX_048;
            if (s == "XXX_049") return CardDB.cardIDEnum.XXX_049;
            if (s == "NEW1_034") return CardDB.cardIDEnum.NEW1_034;
            if (s == "CS2_003") return CardDB.cardIDEnum.CS2_003;
            if (s == "HERO_06") return CardDB.cardIDEnum.HERO_06;
            if (s == "CS2_201") return CardDB.cardIDEnum.CS2_201;
            if (s == "EX1_508") return CardDB.cardIDEnum.EX1_508;
            if (s == "EX1_259") return CardDB.cardIDEnum.EX1_259;
            if (s == "EX1_341") return CardDB.cardIDEnum.EX1_341;
            if (s == "DREAM_05e") return CardDB.cardIDEnum.DREAM_05e;
            if (s == "CRED_09") return CardDB.cardIDEnum.CRED_09;
            if (s == "EX1_103") return CardDB.cardIDEnum.EX1_103;
            if (s == "FP1_021") return CardDB.cardIDEnum.FP1_021;
            if (s == "EX1_411") return CardDB.cardIDEnum.EX1_411;
            if (s == "NAX1_04") return CardDB.cardIDEnum.NAX1_04;
            if (s == "CS2_053") return CardDB.cardIDEnum.CS2_053;
            if (s == "CS2_182") return CardDB.cardIDEnum.CS2_182;
            if (s == "CS2_008") return CardDB.cardIDEnum.CS2_008;
            if (s == "CS2_233") return CardDB.cardIDEnum.CS2_233;
            if (s == "EX1_626") return CardDB.cardIDEnum.EX1_626;
            if (s == "EX1_059") return CardDB.cardIDEnum.EX1_059;
            if (s == "EX1_334") return CardDB.cardIDEnum.EX1_334;
            if (s == "EX1_619") return CardDB.cardIDEnum.EX1_619;
            if (s == "NEW1_032") return CardDB.cardIDEnum.NEW1_032;
            if (s == "EX1_158t") return CardDB.cardIDEnum.EX1_158t;
            if (s == "EX1_006") return CardDB.cardIDEnum.EX1_006;
            if (s == "NEW1_031") return CardDB.cardIDEnum.NEW1_031;
            if (s == "NAX10_03") return CardDB.cardIDEnum.NAX10_03;
            if (s == "DREAM_04") return CardDB.cardIDEnum.DREAM_04;
            if (s == "NAX1h_01") return CardDB.cardIDEnum.NAX1h_01;
            if (s == "CS2_022e") return CardDB.cardIDEnum.CS2_022e;
            if (s == "EX1_611e") return CardDB.cardIDEnum.EX1_611e;
            if (s == "EX1_004") return CardDB.cardIDEnum.EX1_004;
            if (s == "EX1_014te") return CardDB.cardIDEnum.EX1_014te;
            if (s == "FP1_005e") return CardDB.cardIDEnum.FP1_005e;
            if (s == "NAX12_03e") return CardDB.cardIDEnum.NAX12_03e;
            if (s == "EX1_095") return CardDB.cardIDEnum.EX1_095;
            if (s == "NEW1_007") return CardDB.cardIDEnum.NEW1_007;
            if (s == "EX1_275") return CardDB.cardIDEnum.EX1_275;
            if (s == "EX1_245") return CardDB.cardIDEnum.EX1_245;
            if (s == "EX1_383") return CardDB.cardIDEnum.EX1_383;
            if (s == "FP1_016") return CardDB.cardIDEnum.FP1_016;
            if (s == "EX1_016t") return CardDB.cardIDEnum.EX1_016t;
            if (s == "CS2_125") return CardDB.cardIDEnum.CS2_125;
            if (s == "EX1_137") return CardDB.cardIDEnum.EX1_137;
            if (s == "EX1_178ae") return CardDB.cardIDEnum.EX1_178ae;
            if (s == "DS1_185") return CardDB.cardIDEnum.DS1_185;
            if (s == "FP1_010") return CardDB.cardIDEnum.FP1_010;
            if (s == "EX1_598") return CardDB.cardIDEnum.EX1_598;
            if (s == "NAX9_07") return CardDB.cardIDEnum.NAX9_07;
            if (s == "EX1_304") return CardDB.cardIDEnum.EX1_304;
            if (s == "EX1_302") return CardDB.cardIDEnum.EX1_302;
            if (s == "XXX_017") return CardDB.cardIDEnum.XXX_017;
            if (s == "CS2_011o") return CardDB.cardIDEnum.CS2_011o;
            if (s == "EX1_614t") return CardDB.cardIDEnum.EX1_614t;
            if (s == "TU4a_006") return CardDB.cardIDEnum.TU4a_006;
            if (s == "Mekka3e") return CardDB.cardIDEnum.Mekka3e;
            if (s == "CS2_108") return CardDB.cardIDEnum.CS2_108;
            if (s == "CS2_046") return CardDB.cardIDEnum.CS2_046;
            if (s == "EX1_014t") return CardDB.cardIDEnum.EX1_014t;
            if (s == "NEW1_005") return CardDB.cardIDEnum.NEW1_005;
            if (s == "EX1_062") return CardDB.cardIDEnum.EX1_062;
            if (s == "EX1_366e") return CardDB.cardIDEnum.EX1_366e;
            if (s == "Mekka1") return CardDB.cardIDEnum.Mekka1;
            if (s == "XXX_007") return CardDB.cardIDEnum.XXX_007;
            if (s == "tt_010a") return CardDB.cardIDEnum.tt_010a;
            if (s == "CS2_017o") return CardDB.cardIDEnum.CS2_017o;
            if (s == "CS2_072") return CardDB.cardIDEnum.CS2_072;
            if (s == "EX1_tk28") return CardDB.cardIDEnum.EX1_tk28;
            if (s == "EX1_604o") return CardDB.cardIDEnum.EX1_604o;
            if (s == "FP1_014") return CardDB.cardIDEnum.FP1_014;
            if (s == "EX1_084e") return CardDB.cardIDEnum.EX1_084e;
            if (s == "NAX3_01H") return CardDB.cardIDEnum.NAX3_01H;
            if (s == "NAX2_01") return CardDB.cardIDEnum.NAX2_01;
            if (s == "EX1_409t") return CardDB.cardIDEnum.EX1_409t;
            if (s == "CRED_07") return CardDB.cardIDEnum.CRED_07;
            if (s == "NAX3_02H") return CardDB.cardIDEnum.NAX3_02H;
            if (s == "TU4e_002") return CardDB.cardIDEnum.TU4e_002;
            if (s == "EX1_507") return CardDB.cardIDEnum.EX1_507;
            if (s == "EX1_144") return CardDB.cardIDEnum.EX1_144;
            if (s == "CS2_038") return CardDB.cardIDEnum.CS2_038;
            if (s == "EX1_093") return CardDB.cardIDEnum.EX1_093;
            if (s == "CS2_080") return CardDB.cardIDEnum.CS2_080;
            if (s == "CS1_129e") return CardDB.cardIDEnum.CS1_129e;
            if (s == "XXX_013") return CardDB.cardIDEnum.XXX_013;
            if (s == "EX1_005") return CardDB.cardIDEnum.EX1_005;
            if (s == "EX1_382") return CardDB.cardIDEnum.EX1_382;
            if (s == "NAX13_02e") return CardDB.cardIDEnum.NAX13_02e;
            if (s == "FP1_020e") return CardDB.cardIDEnum.FP1_020e;
            if (s == "EX1_603e") return CardDB.cardIDEnum.EX1_603e;
            if (s == "CS2_028") return CardDB.cardIDEnum.CS2_028;
            if (s == "TU4f_002") return CardDB.cardIDEnum.TU4f_002;
            if (s == "EX1_538") return CardDB.cardIDEnum.EX1_538;
            if (s == "GAME_003e") return CardDB.cardIDEnum.GAME_003e;
            if (s == "DREAM_02") return CardDB.cardIDEnum.DREAM_02;
            if (s == "EX1_581") return CardDB.cardIDEnum.EX1_581;
            if (s == "NAX15_01H") return CardDB.cardIDEnum.NAX15_01H;
            if (s == "EX1_131t") return CardDB.cardIDEnum.EX1_131t;
            if (s == "CS2_147") return CardDB.cardIDEnum.CS2_147;
            if (s == "CS1_113") return CardDB.cardIDEnum.CS1_113;
            if (s == "CS2_161") return CardDB.cardIDEnum.CS2_161;
            if (s == "CS2_031") return CardDB.cardIDEnum.CS2_031;
            if (s == "EX1_166b") return CardDB.cardIDEnum.EX1_166b;
            if (s == "EX1_066") return CardDB.cardIDEnum.EX1_066;
            if (s == "TU4c_007") return CardDB.cardIDEnum.TU4c_007;
            if (s == "EX1_355") return CardDB.cardIDEnum.EX1_355;
            if (s == "EX1_507e") return CardDB.cardIDEnum.EX1_507e;
            if (s == "EX1_534") return CardDB.cardIDEnum.EX1_534;
            if (s == "EX1_162") return CardDB.cardIDEnum.EX1_162;
            if (s == "TU4a_004") return CardDB.cardIDEnum.TU4a_004;
            if (s == "EX1_363") return CardDB.cardIDEnum.EX1_363;
            if (s == "EX1_164a") return CardDB.cardIDEnum.EX1_164a;
            if (s == "CS2_188") return CardDB.cardIDEnum.CS2_188;
            if (s == "EX1_016") return CardDB.cardIDEnum.EX1_016;
            if (s == "NAX6_03t") return CardDB.cardIDEnum.NAX6_03t;
            if (s == "EX1_tk31") return CardDB.cardIDEnum.EX1_tk31;
            if (s == "EX1_603") return CardDB.cardIDEnum.EX1_603;
            if (s == "EX1_238") return CardDB.cardIDEnum.EX1_238;
            if (s == "EX1_166") return CardDB.cardIDEnum.EX1_166;
            if (s == "DS1h_292") return CardDB.cardIDEnum.DS1h_292;
            if (s == "DS1_183") return CardDB.cardIDEnum.DS1_183;
            if (s == "NAX15_03n") return CardDB.cardIDEnum.NAX15_03n;
            if (s == "NAX8_02H") return CardDB.cardIDEnum.NAX8_02H;
            if (s == "NAX7_01H") return CardDB.cardIDEnum.NAX7_01H;
            if (s == "NAX9_02H") return CardDB.cardIDEnum.NAX9_02H;
            if (s == "CRED_11") return CardDB.cardIDEnum.CRED_11;
            if (s == "XXX_019") return CardDB.cardIDEnum.XXX_019;
            if (s == "EX1_076") return CardDB.cardIDEnum.EX1_076;
            if (s == "EX1_048") return CardDB.cardIDEnum.EX1_048;
            if (s == "CS2_038e") return CardDB.cardIDEnum.CS2_038e;
            if (s == "FP1_026") return CardDB.cardIDEnum.FP1_026;
            if (s == "CS2_074") return CardDB.cardIDEnum.CS2_074;
            if (s == "FP1_027") return CardDB.cardIDEnum.FP1_027;
            if (s == "EX1_323w") return CardDB.cardIDEnum.EX1_323w;
            if (s == "EX1_129") return CardDB.cardIDEnum.EX1_129;
            if (s == "NEW1_024o") return CardDB.cardIDEnum.NEW1_024o;
            if (s == "NAX11_02") return CardDB.cardIDEnum.NAX11_02;
            if (s == "EX1_405") return CardDB.cardIDEnum.EX1_405;
            if (s == "EX1_317") return CardDB.cardIDEnum.EX1_317;
            if (s == "EX1_606") return CardDB.cardIDEnum.EX1_606;
            if (s == "EX1_590e") return CardDB.cardIDEnum.EX1_590e;
            if (s == "XXX_044") return CardDB.cardIDEnum.XXX_044;
            if (s == "CS2_074e") return CardDB.cardIDEnum.CS2_074e;
            if (s == "TU4a_005") return CardDB.cardIDEnum.TU4a_005;
            if (s == "FP1_006") return CardDB.cardIDEnum.FP1_006;
            if (s == "EX1_258e") return CardDB.cardIDEnum.EX1_258e;
            if (s == "TU4f_004o") return CardDB.cardIDEnum.TU4f_004o;
            if (s == "NEW1_008") return CardDB.cardIDEnum.NEW1_008;
            if (s == "CS2_119") return CardDB.cardIDEnum.CS2_119;
            if (s == "NEW1_017e") return CardDB.cardIDEnum.NEW1_017e;
            if (s == "EX1_334e") return CardDB.cardIDEnum.EX1_334e;
            if (s == "TU4e_001") return CardDB.cardIDEnum.TU4e_001;
            if (s == "CS2_121") return CardDB.cardIDEnum.CS2_121;
            if (s == "CS1h_001") return CardDB.cardIDEnum.CS1h_001;
            if (s == "EX1_tk34") return CardDB.cardIDEnum.EX1_tk34;
            if (s == "NEW1_020") return CardDB.cardIDEnum.NEW1_020;
            if (s == "CS2_196") return CardDB.cardIDEnum.CS2_196;
            if (s == "EX1_312") return CardDB.cardIDEnum.EX1_312;
            if (s == "NAX1_01") return CardDB.cardIDEnum.NAX1_01;
            if (s == "FP1_022") return CardDB.cardIDEnum.FP1_022;
            if (s == "EX1_160b") return CardDB.cardIDEnum.EX1_160b;
            if (s == "EX1_563") return CardDB.cardIDEnum.EX1_563;
            if (s == "XXX_039") return CardDB.cardIDEnum.XXX_039;
            if (s == "FP1_031") return CardDB.cardIDEnum.FP1_031;
            if (s == "CS2_087e") return CardDB.cardIDEnum.CS2_087e;
            if (s == "EX1_613e") return CardDB.cardIDEnum.EX1_613e;
            if (s == "NAX9_02") return CardDB.cardIDEnum.NAX9_02;
            if (s == "NEW1_029") return CardDB.cardIDEnum.NEW1_029;
            if (s == "CS1_129") return CardDB.cardIDEnum.CS1_129;
            if (s == "HERO_03") return CardDB.cardIDEnum.HERO_03;
            if (s == "Mekka4t") return CardDB.cardIDEnum.Mekka4t;
            if (s == "EX1_158") return CardDB.cardIDEnum.EX1_158;
            if (s == "XXX_010") return CardDB.cardIDEnum.XXX_010;
            if (s == "NEW1_025") return CardDB.cardIDEnum.NEW1_025;
            if (s == "FP1_012t") return CardDB.cardIDEnum.FP1_012t;
            if (s == "EX1_083") return CardDB.cardIDEnum.EX1_083;
            if (s == "EX1_295") return CardDB.cardIDEnum.EX1_295;
            if (s == "EX1_407") return CardDB.cardIDEnum.EX1_407;
            if (s == "NEW1_004") return CardDB.cardIDEnum.NEW1_004;
            if (s == "FP1_019") return CardDB.cardIDEnum.FP1_019;
            if (s == "PRO_001at") return CardDB.cardIDEnum.PRO_001at;
            if (s == "NAX13_03e") return CardDB.cardIDEnum.NAX13_03e;
            if (s == "EX1_625t") return CardDB.cardIDEnum.EX1_625t;
            if (s == "EX1_014") return CardDB.cardIDEnum.EX1_014;
            if (s == "CRED_04") return CardDB.cardIDEnum.CRED_04;
            if (s == "NAX12_01H") return CardDB.cardIDEnum.NAX12_01H;
            if (s == "CS2_097") return CardDB.cardIDEnum.CS2_097;
            if (s == "EX1_558") return CardDB.cardIDEnum.EX1_558;
            if (s == "XXX_047") return CardDB.cardIDEnum.XXX_047;
            if (s == "EX1_tk29") return CardDB.cardIDEnum.EX1_tk29;
            if (s == "CS2_186") return CardDB.cardIDEnum.CS2_186;
            if (s == "EX1_084") return CardDB.cardIDEnum.EX1_084;
            if (s == "NEW1_012") return CardDB.cardIDEnum.NEW1_012;
            if (s == "FP1_014t") return CardDB.cardIDEnum.FP1_014t;
            if (s == "NAX1_03") return CardDB.cardIDEnum.NAX1_03;
            if (s == "EX1_623e") return CardDB.cardIDEnum.EX1_623e;
            if (s == "EX1_578") return CardDB.cardIDEnum.EX1_578;
            if (s == "CS2_073e2") return CardDB.cardIDEnum.CS2_073e2;
            if (s == "CS2_221") return CardDB.cardIDEnum.CS2_221;
            if (s == "EX1_019") return CardDB.cardIDEnum.EX1_019;
            if (s == "NAX15_04a") return CardDB.cardIDEnum.NAX15_04a;
            if (s == "FP1_019t") return CardDB.cardIDEnum.FP1_019t;
            if (s == "EX1_132") return CardDB.cardIDEnum.EX1_132;
            if (s == "EX1_284") return CardDB.cardIDEnum.EX1_284;
            if (s == "EX1_105") return CardDB.cardIDEnum.EX1_105;
            if (s == "NEW1_011") return CardDB.cardIDEnum.NEW1_011;
            if (s == "NAX9_07e") return CardDB.cardIDEnum.NAX9_07e;
            if (s == "EX1_017") return CardDB.cardIDEnum.EX1_017;
            if (s == "EX1_249") return CardDB.cardIDEnum.EX1_249;
            if (s == "EX1_162o") return CardDB.cardIDEnum.EX1_162o;
            if (s == "FP1_002t") return CardDB.cardIDEnum.FP1_002t;
            if (s == "NAX3_02") return CardDB.cardIDEnum.NAX3_02;
            if (s == "EX1_313") return CardDB.cardIDEnum.EX1_313;
            if (s == "EX1_549o") return CardDB.cardIDEnum.EX1_549o;
            if (s == "EX1_091o") return CardDB.cardIDEnum.EX1_091o;
            if (s == "CS2_084e") return CardDB.cardIDEnum.CS2_084e;
            if (s == "EX1_155b") return CardDB.cardIDEnum.EX1_155b;
            if (s == "NAX11_01") return CardDB.cardIDEnum.NAX11_01;
            if (s == "NEW1_033") return CardDB.cardIDEnum.NEW1_033;
            if (s == "CS2_106") return CardDB.cardIDEnum.CS2_106;
            if (s == "XXX_002") return CardDB.cardIDEnum.XXX_002;
            if (s == "FP1_018") return CardDB.cardIDEnum.FP1_018;
            if (s == "NEW1_036e2") return CardDB.cardIDEnum.NEW1_036e2;
            if (s == "XXX_004") return CardDB.cardIDEnum.XXX_004;
            if (s == "NAX11_02H") return CardDB.cardIDEnum.NAX11_02H;
            if (s == "CS2_122e") return CardDB.cardIDEnum.CS2_122e;
            if (s == "DS1_233") return CardDB.cardIDEnum.DS1_233;
            if (s == "DS1_175") return CardDB.cardIDEnum.DS1_175;
            if (s == "NEW1_024") return CardDB.cardIDEnum.NEW1_024;
            if (s == "CS2_189") return CardDB.cardIDEnum.CS2_189;
            if (s == "CRED_10") return CardDB.cardIDEnum.CRED_10;
            if (s == "NEW1_037") return CardDB.cardIDEnum.NEW1_037;
            if (s == "EX1_414") return CardDB.cardIDEnum.EX1_414;
            if (s == "EX1_538t") return CardDB.cardIDEnum.EX1_538t;
            if (s == "FP1_030e") return CardDB.cardIDEnum.FP1_030e;
            if (s == "EX1_586") return CardDB.cardIDEnum.EX1_586;
            if (s == "EX1_310") return CardDB.cardIDEnum.EX1_310;
            if (s == "NEW1_010") return CardDB.cardIDEnum.NEW1_010;
            if (s == "CS2_103e") return CardDB.cardIDEnum.CS2_103e;
            if (s == "EX1_080o") return CardDB.cardIDEnum.EX1_080o;
            if (s == "CS2_005o") return CardDB.cardIDEnum.CS2_005o;
            if (s == "EX1_363e2") return CardDB.cardIDEnum.EX1_363e2;
            if (s == "EX1_534t") return CardDB.cardIDEnum.EX1_534t;
            if (s == "FP1_028") return CardDB.cardIDEnum.FP1_028;
            if (s == "EX1_604") return CardDB.cardIDEnum.EX1_604;
            if (s == "EX1_160") return CardDB.cardIDEnum.EX1_160;
            if (s == "EX1_165t1") return CardDB.cardIDEnum.EX1_165t1;
            if (s == "CS2_062") return CardDB.cardIDEnum.CS2_062;
            if (s == "CS2_155") return CardDB.cardIDEnum.CS2_155;
            if (s == "CS2_213") return CardDB.cardIDEnum.CS2_213;
            if (s == "TU4f_007") return CardDB.cardIDEnum.TU4f_007;
            if (s == "GAME_004") return CardDB.cardIDEnum.GAME_004;
            if (s == "NAX5_01") return CardDB.cardIDEnum.NAX5_01;
            if (s == "XXX_020") return CardDB.cardIDEnum.XXX_020;
            if (s == "NAX15_02H") return CardDB.cardIDEnum.NAX15_02H;
            if (s == "CS2_004") return CardDB.cardIDEnum.CS2_004;
            if (s == "NAX2_03H") return CardDB.cardIDEnum.NAX2_03H;
            if (s == "EX1_561e") return CardDB.cardIDEnum.EX1_561e;
            if (s == "CS2_023") return CardDB.cardIDEnum.CS2_023;
            if (s == "EX1_164") return CardDB.cardIDEnum.EX1_164;
            if (s == "EX1_009") return CardDB.cardIDEnum.EX1_009;
            if (s == "NAX6_01") return CardDB.cardIDEnum.NAX6_01;
            if (s == "FP1_007") return CardDB.cardIDEnum.FP1_007;
            if (s == "NAX1h_04") return CardDB.cardIDEnum.NAX1h_04;
            if (s == "NAX2_05H") return CardDB.cardIDEnum.NAX2_05H;
            if (s == "NAX10_02") return CardDB.cardIDEnum.NAX10_02;
            if (s == "EX1_345") return CardDB.cardIDEnum.EX1_345;
            if (s == "EX1_116") return CardDB.cardIDEnum.EX1_116;
            if (s == "EX1_399") return CardDB.cardIDEnum.EX1_399;
            if (s == "EX1_587") return CardDB.cardIDEnum.EX1_587;
            if (s == "XXX_026") return CardDB.cardIDEnum.XXX_026;
            if (s == "EX1_571") return CardDB.cardIDEnum.EX1_571;
            if (s == "EX1_335") return CardDB.cardIDEnum.EX1_335;
            if (s == "XXX_050") return CardDB.cardIDEnum.XXX_050;
            if (s == "TU4e_004") return CardDB.cardIDEnum.TU4e_004;
            if (s == "HERO_08") return CardDB.cardIDEnum.HERO_08;
            if (s == "EX1_166a") return CardDB.cardIDEnum.EX1_166a;
            if (s == "NAX2_03") return CardDB.cardIDEnum.NAX2_03;
            if (s == "EX1_finkle") return CardDB.cardIDEnum.EX1_finkle;
            if (s == "NAX4_03H") return CardDB.cardIDEnum.NAX4_03H;
            if (s == "EX1_164b") return CardDB.cardIDEnum.EX1_164b;
            if (s == "EX1_283") return CardDB.cardIDEnum.EX1_283;
            if (s == "EX1_339") return CardDB.cardIDEnum.EX1_339;
            if (s == "CRED_13") return CardDB.cardIDEnum.CRED_13;
            if (s == "EX1_178be") return CardDB.cardIDEnum.EX1_178be;
            if (s == "EX1_531") return CardDB.cardIDEnum.EX1_531;
            if (s == "EX1_134") return CardDB.cardIDEnum.EX1_134;
            if (s == "EX1_350") return CardDB.cardIDEnum.EX1_350;
            if (s == "EX1_308") return CardDB.cardIDEnum.EX1_308;
            if (s == "CS2_197") return CardDB.cardIDEnum.CS2_197;
            if (s == "skele21") return CardDB.cardIDEnum.skele21;
            if (s == "CS2_222o") return CardDB.cardIDEnum.CS2_222o;
            if (s == "XXX_015") return CardDB.cardIDEnum.XXX_015;
            if (s == "FP1_013") return CardDB.cardIDEnum.FP1_013;
            if (s == "NEW1_006") return CardDB.cardIDEnum.NEW1_006;
            if (s == "EX1_399e") return CardDB.cardIDEnum.EX1_399e;
            if (s == "EX1_509") return CardDB.cardIDEnum.EX1_509;
            if (s == "EX1_612") return CardDB.cardIDEnum.EX1_612;
            if (s == "NAX8_05t") return CardDB.cardIDEnum.NAX8_05t;
            if (s == "NAX9_05H") return CardDB.cardIDEnum.NAX9_05H;
            if (s == "EX1_021") return CardDB.cardIDEnum.EX1_021;
            if (s == "CS2_041e") return CardDB.cardIDEnum.CS2_041e;
            if (s == "CS2_226") return CardDB.cardIDEnum.CS2_226;
            if (s == "EX1_608") return CardDB.cardIDEnum.EX1_608;
            if (s == "NAX13_05H") return CardDB.cardIDEnum.NAX13_05H;
            if (s == "NAX13_04H") return CardDB.cardIDEnum.NAX13_04H;
            if (s == "TU4c_008") return CardDB.cardIDEnum.TU4c_008;
            if (s == "EX1_624") return CardDB.cardIDEnum.EX1_624;
            if (s == "EX1_616") return CardDB.cardIDEnum.EX1_616;
            if (s == "EX1_008") return CardDB.cardIDEnum.EX1_008;
            if (s == "PlaceholderCard") return CardDB.cardIDEnum.PlaceholderCard;
            if (s == "XXX_016") return CardDB.cardIDEnum.XXX_016;
            if (s == "EX1_045") return CardDB.cardIDEnum.EX1_045;
            if (s == "EX1_015") return CardDB.cardIDEnum.EX1_015;
            if (s == "GAME_003") return CardDB.cardIDEnum.GAME_003;
            if (s == "CS2_171") return CardDB.cardIDEnum.CS2_171;
            if (s == "CS2_041") return CardDB.cardIDEnum.CS2_041;
            if (s == "EX1_128") return CardDB.cardIDEnum.EX1_128;
            if (s == "CS2_112") return CardDB.cardIDEnum.CS2_112;
            if (s == "HERO_07") return CardDB.cardIDEnum.HERO_07;
            if (s == "EX1_412") return CardDB.cardIDEnum.EX1_412;
            if (s == "EX1_612o") return CardDB.cardIDEnum.EX1_612o;
            if (s == "CS2_117") return CardDB.cardIDEnum.CS2_117;
            if (s == "XXX_009e") return CardDB.cardIDEnum.XXX_009e;
            if (s == "EX1_562") return CardDB.cardIDEnum.EX1_562;
            if (s == "EX1_055") return CardDB.cardIDEnum.EX1_055;
            if (s == "NAX9_06") return CardDB.cardIDEnum.NAX9_06;
            if (s == "TU4e_007") return CardDB.cardIDEnum.TU4e_007;
            if (s == "FP1_012") return CardDB.cardIDEnum.FP1_012;
            if (s == "EX1_317t") return CardDB.cardIDEnum.EX1_317t;
            if (s == "EX1_004e") return CardDB.cardIDEnum.EX1_004e;
            if (s == "EX1_278") return CardDB.cardIDEnum.EX1_278;
            if (s == "CS2_tk1") return CardDB.cardIDEnum.CS2_tk1;
            if (s == "EX1_590") return CardDB.cardIDEnum.EX1_590;
            if (s == "CS1_130") return CardDB.cardIDEnum.CS1_130;
            if (s == "NEW1_008b") return CardDB.cardIDEnum.NEW1_008b;
            if (s == "EX1_365") return CardDB.cardIDEnum.EX1_365;
            if (s == "CS2_141") return CardDB.cardIDEnum.CS2_141;
            if (s == "PRO_001") return CardDB.cardIDEnum.PRO_001;
            if (s == "NAX8_04t") return CardDB.cardIDEnum.NAX8_04t;
            if (s == "CS2_173") return CardDB.cardIDEnum.CS2_173;
            if (s == "CS2_017") return CardDB.cardIDEnum.CS2_017;
            if (s == "CRED_16") return CardDB.cardIDEnum.CRED_16;
            if (s == "EX1_392") return CardDB.cardIDEnum.EX1_392;
            if (s == "EX1_593") return CardDB.cardIDEnum.EX1_593;
            if (s == "FP1_023e") return CardDB.cardIDEnum.FP1_023e;
            if (s == "NAX1_05") return CardDB.cardIDEnum.NAX1_05;
            if (s == "TU4d_002") return CardDB.cardIDEnum.TU4d_002;
            if (s == "CRED_15") return CardDB.cardIDEnum.CRED_15;
            if (s == "EX1_049") return CardDB.cardIDEnum.EX1_049;
            if (s == "EX1_002") return CardDB.cardIDEnum.EX1_002;
            if (s == "TU4f_005") return CardDB.cardIDEnum.TU4f_005;
            if (s == "NEW1_029t") return CardDB.cardIDEnum.NEW1_029t;
            if (s == "TU4a_001") return CardDB.cardIDEnum.TU4a_001;
            if (s == "CS2_056") return CardDB.cardIDEnum.CS2_056;
            if (s == "EX1_596") return CardDB.cardIDEnum.EX1_596;
            if (s == "EX1_136") return CardDB.cardIDEnum.EX1_136;
            if (s == "EX1_323") return CardDB.cardIDEnum.EX1_323;
            if (s == "CS2_073") return CardDB.cardIDEnum.CS2_073;
            if (s == "EX1_246e") return CardDB.cardIDEnum.EX1_246e;
            if (s == "NAX12_01") return CardDB.cardIDEnum.NAX12_01;
            if (s == "EX1_244e") return CardDB.cardIDEnum.EX1_244e;
            if (s == "EX1_001") return CardDB.cardIDEnum.EX1_001;
            if (s == "EX1_607e") return CardDB.cardIDEnum.EX1_607e;
            if (s == "EX1_044") return CardDB.cardIDEnum.EX1_044;
            if (s == "EX1_573ae") return CardDB.cardIDEnum.EX1_573ae;
            if (s == "XXX_025") return CardDB.cardIDEnum.XXX_025;
            if (s == "CRED_06") return CardDB.cardIDEnum.CRED_06;
            if (s == "Mekka4") return CardDB.cardIDEnum.Mekka4;
            if (s == "CS2_142") return CardDB.cardIDEnum.CS2_142;
            if (s == "TU4f_004") return CardDB.cardIDEnum.TU4f_004;
            if (s == "NAX5_02H") return CardDB.cardIDEnum.NAX5_02H;
            if (s == "EX1_411e2") return CardDB.cardIDEnum.EX1_411e2;
            if (s == "EX1_573") return CardDB.cardIDEnum.EX1_573;
            if (s == "FP1_009") return CardDB.cardIDEnum.FP1_009;
            if (s == "CS2_050") return CardDB.cardIDEnum.CS2_050;
            if (s == "NAX4_03") return CardDB.cardIDEnum.NAX4_03;
            if (s == "CS2_063e") return CardDB.cardIDEnum.CS2_063e;
            if (s == "NAX2_05") return CardDB.cardIDEnum.NAX2_05;
            if (s == "EX1_390") return CardDB.cardIDEnum.EX1_390;
            if (s == "EX1_610") return CardDB.cardIDEnum.EX1_610;
            if (s == "hexfrog") return CardDB.cardIDEnum.hexfrog;
            if (s == "CS2_181e") return CardDB.cardIDEnum.CS2_181e;
            if (s == "NAX6_02") return CardDB.cardIDEnum.NAX6_02;
            if (s == "XXX_027") return CardDB.cardIDEnum.XXX_027;
            if (s == "CS2_082") return CardDB.cardIDEnum.CS2_082;
            if (s == "NEW1_040") return CardDB.cardIDEnum.NEW1_040;
            if (s == "DREAM_01") return CardDB.cardIDEnum.DREAM_01;
            if (s == "EX1_595") return CardDB.cardIDEnum.EX1_595;
            if (s == "CS2_013") return CardDB.cardIDEnum.CS2_013;
            if (s == "CS2_077") return CardDB.cardIDEnum.CS2_077;
            if (s == "NEW1_014") return CardDB.cardIDEnum.NEW1_014;
            if (s == "CRED_05") return CardDB.cardIDEnum.CRED_05;
            if (s == "GAME_002") return CardDB.cardIDEnum.GAME_002;
            if (s == "EX1_165") return CardDB.cardIDEnum.EX1_165;
            if (s == "CS2_013t") return CardDB.cardIDEnum.CS2_013t;
            if (s == "NAX4_04H") return CardDB.cardIDEnum.NAX4_04H;
            if (s == "EX1_tk11") return CardDB.cardIDEnum.EX1_tk11;
            if (s == "EX1_591") return CardDB.cardIDEnum.EX1_591;
            if (s == "EX1_549") return CardDB.cardIDEnum.EX1_549;
            if (s == "CS2_045") return CardDB.cardIDEnum.CS2_045;
            if (s == "CS2_237") return CardDB.cardIDEnum.CS2_237;
            if (s == "CS2_027") return CardDB.cardIDEnum.CS2_027;
            if (s == "EX1_508o") return CardDB.cardIDEnum.EX1_508o;
            if (s == "NAX14_03") return CardDB.cardIDEnum.NAX14_03;
            if (s == "CS2_101t") return CardDB.cardIDEnum.CS2_101t;
            if (s == "CS2_063") return CardDB.cardIDEnum.CS2_063;
            if (s == "EX1_145") return CardDB.cardIDEnum.EX1_145;
            if (s == "NAX1h_03") return CardDB.cardIDEnum.NAX1h_03;
            if (s == "EX1_110") return CardDB.cardIDEnum.EX1_110;
            if (s == "EX1_408") return CardDB.cardIDEnum.EX1_408;
            if (s == "EX1_544") return CardDB.cardIDEnum.EX1_544;
            if (s == "TU4c_006") return CardDB.cardIDEnum.TU4c_006;
            if (s == "NAXM_001") return CardDB.cardIDEnum.NAXM_001;
            if (s == "CS2_151") return CardDB.cardIDEnum.CS2_151;
            if (s == "CS2_073e") return CardDB.cardIDEnum.CS2_073e;
            if (s == "XXX_006") return CardDB.cardIDEnum.XXX_006;
            if (s == "CS2_088") return CardDB.cardIDEnum.CS2_088;
            if (s == "EX1_057") return CardDB.cardIDEnum.EX1_057;
            if (s == "FP1_020") return CardDB.cardIDEnum.FP1_020;
            if (s == "CS2_169") return CardDB.cardIDEnum.CS2_169;
            if (s == "EX1_573t") return CardDB.cardIDEnum.EX1_573t;
            if (s == "EX1_323h") return CardDB.cardIDEnum.EX1_323h;
            if (s == "EX1_tk9") return CardDB.cardIDEnum.EX1_tk9;
            if (s == "NEW1_018e") return CardDB.cardIDEnum.NEW1_018e;
            if (s == "CS2_037") return CardDB.cardIDEnum.CS2_037;
            if (s == "CS2_007") return CardDB.cardIDEnum.CS2_007;
            if (s == "EX1_059e2") return CardDB.cardIDEnum.EX1_059e2;
            if (s == "CS2_227") return CardDB.cardIDEnum.CS2_227;
            if (s == "NAX7_03H") return CardDB.cardIDEnum.NAX7_03H;
            if (s == "NAX9_01H") return CardDB.cardIDEnum.NAX9_01H;
            if (s == "EX1_570e") return CardDB.cardIDEnum.EX1_570e;
            if (s == "NEW1_003") return CardDB.cardIDEnum.NEW1_003;
            if (s == "GAME_006") return CardDB.cardIDEnum.GAME_006;
            if (s == "EX1_320") return CardDB.cardIDEnum.EX1_320;
            if (s == "EX1_097") return CardDB.cardIDEnum.EX1_097;
            if (s == "tt_004") return CardDB.cardIDEnum.tt_004;
            if (s == "EX1_360e") return CardDB.cardIDEnum.EX1_360e;
            if (s == "EX1_096") return CardDB.cardIDEnum.EX1_096;
            if (s == "DS1_175o") return CardDB.cardIDEnum.DS1_175o;
            if (s == "EX1_596e") return CardDB.cardIDEnum.EX1_596e;
            if (s == "XXX_014") return CardDB.cardIDEnum.XXX_014;
            if (s == "EX1_158e") return CardDB.cardIDEnum.EX1_158e;
            if (s == "NAX14_01") return CardDB.cardIDEnum.NAX14_01;
            if (s == "CRED_01") return CardDB.cardIDEnum.CRED_01;
            if (s == "CRED_08") return CardDB.cardIDEnum.CRED_08;
            if (s == "EX1_126") return CardDB.cardIDEnum.EX1_126;
            if (s == "EX1_577") return CardDB.cardIDEnum.EX1_577;
            if (s == "EX1_319") return CardDB.cardIDEnum.EX1_319;
            if (s == "EX1_611") return CardDB.cardIDEnum.EX1_611;
            if (s == "CS2_146") return CardDB.cardIDEnum.CS2_146;
            if (s == "EX1_154b") return CardDB.cardIDEnum.EX1_154b;
            if (s == "skele11") return CardDB.cardIDEnum.skele11;
            if (s == "EX1_165t2") return CardDB.cardIDEnum.EX1_165t2;
            if (s == "CS2_172") return CardDB.cardIDEnum.CS2_172;
            if (s == "CS2_114") return CardDB.cardIDEnum.CS2_114;
            if (s == "CS1_069") return CardDB.cardIDEnum.CS1_069;
            if (s == "XXX_003") return CardDB.cardIDEnum.XXX_003;
            if (s == "XXX_042") return CardDB.cardIDEnum.XXX_042;
            if (s == "NAX8_02") return CardDB.cardIDEnum.NAX8_02;
            if (s == "EX1_173") return CardDB.cardIDEnum.EX1_173;
            if (s == "CS1_042") return CardDB.cardIDEnum.CS1_042;
            if (s == "NAX8_03") return CardDB.cardIDEnum.NAX8_03;
            if (s == "EX1_506a") return CardDB.cardIDEnum.EX1_506a;
            if (s == "EX1_298") return CardDB.cardIDEnum.EX1_298;
            if (s == "CS2_104") return CardDB.cardIDEnum.CS2_104;
            if (s == "FP1_001") return CardDB.cardIDEnum.FP1_001;
            if (s == "HERO_02") return CardDB.cardIDEnum.HERO_02;
            if (s == "EX1_316e") return CardDB.cardIDEnum.EX1_316e;
            if (s == "NAX7_01") return CardDB.cardIDEnum.NAX7_01;
            if (s == "EX1_044e") return CardDB.cardIDEnum.EX1_044e;
            if (s == "CS2_051") return CardDB.cardIDEnum.CS2_051;
            if (s == "NEW1_016") return CardDB.cardIDEnum.NEW1_016;
            if (s == "EX1_304e") return CardDB.cardIDEnum.EX1_304e;
            if (s == "EX1_033") return CardDB.cardIDEnum.EX1_033;
            if (s == "NAX8_04") return CardDB.cardIDEnum.NAX8_04;
            if (s == "EX1_028") return CardDB.cardIDEnum.EX1_028;
            if (s == "XXX_011") return CardDB.cardIDEnum.XXX_011;
            if (s == "EX1_621") return CardDB.cardIDEnum.EX1_621;
            if (s == "EX1_554") return CardDB.cardIDEnum.EX1_554;
            if (s == "EX1_091") return CardDB.cardIDEnum.EX1_091;
            if (s == "FP1_017") return CardDB.cardIDEnum.FP1_017;
            if (s == "EX1_409") return CardDB.cardIDEnum.EX1_409;
            if (s == "EX1_363e") return CardDB.cardIDEnum.EX1_363e;
            if (s == "EX1_410") return CardDB.cardIDEnum.EX1_410;
            if (s == "TU4e_005") return CardDB.cardIDEnum.TU4e_005;
            if (s == "CS2_039") return CardDB.cardIDEnum.CS2_039;
            if (s == "NAX12_04") return CardDB.cardIDEnum.NAX12_04;
            if (s == "EX1_557") return CardDB.cardIDEnum.EX1_557;
            if (s == "CS2_105e") return CardDB.cardIDEnum.CS2_105e;
            if (s == "EX1_128e") return CardDB.cardIDEnum.EX1_128e;
            if (s == "XXX_021") return CardDB.cardIDEnum.XXX_021;
            if (s == "DS1_070") return CardDB.cardIDEnum.DS1_070;
            if (s == "CS2_033") return CardDB.cardIDEnum.CS2_033;
            if (s == "EX1_536") return CardDB.cardIDEnum.EX1_536;
            if (s == "TU4a_003") return CardDB.cardIDEnum.TU4a_003;
            if (s == "EX1_559") return CardDB.cardIDEnum.EX1_559;
            if (s == "XXX_023") return CardDB.cardIDEnum.XXX_023;
            if (s == "NEW1_033o") return CardDB.cardIDEnum.NEW1_033o;
            if (s == "NAX15_04H") return CardDB.cardIDEnum.NAX15_04H;
            if (s == "CS2_004e") return CardDB.cardIDEnum.CS2_004e;
            if (s == "CS2_052") return CardDB.cardIDEnum.CS2_052;
            if (s == "EX1_539") return CardDB.cardIDEnum.EX1_539;
            if (s == "EX1_575") return CardDB.cardIDEnum.EX1_575;
            if (s == "CS2_083b") return CardDB.cardIDEnum.CS2_083b;
            if (s == "CS2_061") return CardDB.cardIDEnum.CS2_061;
            if (s == "NEW1_021") return CardDB.cardIDEnum.NEW1_021;
            if (s == "DS1_055") return CardDB.cardIDEnum.DS1_055;
            if (s == "EX1_625") return CardDB.cardIDEnum.EX1_625;
            if (s == "EX1_382e") return CardDB.cardIDEnum.EX1_382e;
            if (s == "CS2_092e") return CardDB.cardIDEnum.CS2_092e;
            if (s == "CS2_026") return CardDB.cardIDEnum.CS2_026;
            if (s == "NAX14_04") return CardDB.cardIDEnum.NAX14_04;
            if (s == "NEW1_012o") return CardDB.cardIDEnum.NEW1_012o;
            if (s == "EX1_619e") return CardDB.cardIDEnum.EX1_619e;
            if (s == "EX1_294") return CardDB.cardIDEnum.EX1_294;
            if (s == "EX1_287") return CardDB.cardIDEnum.EX1_287;
            if (s == "EX1_509e") return CardDB.cardIDEnum.EX1_509e;
            if (s == "EX1_625t2") return CardDB.cardIDEnum.EX1_625t2;
            if (s == "CS2_118") return CardDB.cardIDEnum.CS2_118;
            if (s == "CS2_124") return CardDB.cardIDEnum.CS2_124;
            if (s == "Mekka3") return CardDB.cardIDEnum.Mekka3;
            if (s == "NAX13_02") return CardDB.cardIDEnum.NAX13_02;
            if (s == "EX1_112") return CardDB.cardIDEnum.EX1_112;
            if (s == "FP1_011") return CardDB.cardIDEnum.FP1_011;
            if (s == "CS2_009e") return CardDB.cardIDEnum.CS2_009e;
            if (s == "HERO_04") return CardDB.cardIDEnum.HERO_04;
            if (s == "EX1_607") return CardDB.cardIDEnum.EX1_607;
            if (s == "DREAM_03") return CardDB.cardIDEnum.DREAM_03;
            if (s == "NAX11_04e") return CardDB.cardIDEnum.NAX11_04e;
            if (s == "EX1_103e") return CardDB.cardIDEnum.EX1_103e;
            if (s == "XXX_046") return CardDB.cardIDEnum.XXX_046;
            if (s == "FP1_003") return CardDB.cardIDEnum.FP1_003;
            if (s == "CS2_105") return CardDB.cardIDEnum.CS2_105;
            if (s == "FP1_002") return CardDB.cardIDEnum.FP1_002;
            if (s == "TU4c_002") return CardDB.cardIDEnum.TU4c_002;
            if (s == "CRED_14") return CardDB.cardIDEnum.CRED_14;
            if (s == "EX1_567") return CardDB.cardIDEnum.EX1_567;
            if (s == "TU4c_004") return CardDB.cardIDEnum.TU4c_004;
            if (s == "NAX10_03H") return CardDB.cardIDEnum.NAX10_03H;
            if (s == "FP1_008") return CardDB.cardIDEnum.FP1_008;
            if (s == "DS1_184") return CardDB.cardIDEnum.DS1_184;
            if (s == "CS2_029") return CardDB.cardIDEnum.CS2_029;
            if (s == "GAME_005") return CardDB.cardIDEnum.GAME_005;
            if (s == "CS2_187") return CardDB.cardIDEnum.CS2_187;
            if (s == "EX1_020") return CardDB.cardIDEnum.EX1_020;
            if (s == "NAX15_01He") return CardDB.cardIDEnum.NAX15_01He;
            if (s == "EX1_011") return CardDB.cardIDEnum.EX1_011;
            if (s == "CS2_057") return CardDB.cardIDEnum.CS2_057;
            if (s == "EX1_274") return CardDB.cardIDEnum.EX1_274;
            if (s == "EX1_306") return CardDB.cardIDEnum.EX1_306;
            if (s == "NEW1_038o") return CardDB.cardIDEnum.NEW1_038o;
            if (s == "EX1_170") return CardDB.cardIDEnum.EX1_170;
            if (s == "EX1_617") return CardDB.cardIDEnum.EX1_617;
            if (s == "CS1_113e") return CardDB.cardIDEnum.CS1_113e;
            if (s == "CS2_101") return CardDB.cardIDEnum.CS2_101;
            if (s == "FP1_015") return CardDB.cardIDEnum.FP1_015;
            if (s == "NAX13_03") return CardDB.cardIDEnum.NAX13_03;
            if (s == "CS2_005") return CardDB.cardIDEnum.CS2_005;
            if (s == "EX1_537") return CardDB.cardIDEnum.EX1_537;
            if (s == "EX1_384") return CardDB.cardIDEnum.EX1_384;
            if (s == "TU4a_002") return CardDB.cardIDEnum.TU4a_002;
            if (s == "NAX9_04") return CardDB.cardIDEnum.NAX9_04;
            if (s == "EX1_362") return CardDB.cardIDEnum.EX1_362;
            if (s == "NAX12_02") return CardDB.cardIDEnum.NAX12_02;
            if (s == "FP1_028e") return CardDB.cardIDEnum.FP1_028e;
            if (s == "TU4c_005") return CardDB.cardIDEnum.TU4c_005;
            if (s == "EX1_301") return CardDB.cardIDEnum.EX1_301;
            if (s == "CS2_235") return CardDB.cardIDEnum.CS2_235;
            if (s == "NAX4_05") return CardDB.cardIDEnum.NAX4_05;
            if (s == "EX1_029") return CardDB.cardIDEnum.EX1_029;
            if (s == "CS2_042") return CardDB.cardIDEnum.CS2_042;
            if (s == "EX1_155a") return CardDB.cardIDEnum.EX1_155a;
            if (s == "CS2_102") return CardDB.cardIDEnum.CS2_102;
            if (s == "EX1_609") return CardDB.cardIDEnum.EX1_609;
            if (s == "NEW1_027") return CardDB.cardIDEnum.NEW1_027;
            if (s == "CS2_236e") return CardDB.cardIDEnum.CS2_236e;
            if (s == "CS2_083e") return CardDB.cardIDEnum.CS2_083e;
            if (s == "NAX6_03te") return CardDB.cardIDEnum.NAX6_03te;
            if (s == "EX1_165a") return CardDB.cardIDEnum.EX1_165a;
            if (s == "EX1_570") return CardDB.cardIDEnum.EX1_570;
            if (s == "EX1_131") return CardDB.cardIDEnum.EX1_131;
            if (s == "EX1_556") return CardDB.cardIDEnum.EX1_556;
            if (s == "EX1_543") return CardDB.cardIDEnum.EX1_543;
            if (s == "XXX_096") return CardDB.cardIDEnum.XXX_096;
            if (s == "TU4c_008e") return CardDB.cardIDEnum.TU4c_008e;
            if (s == "EX1_379e") return CardDB.cardIDEnum.EX1_379e;
            if (s == "NEW1_009") return CardDB.cardIDEnum.NEW1_009;
            if (s == "EX1_100") return CardDB.cardIDEnum.EX1_100;
            if (s == "EX1_274e") return CardDB.cardIDEnum.EX1_274e;
            if (s == "CRED_02") return CardDB.cardIDEnum.CRED_02;
            if (s == "EX1_573a") return CardDB.cardIDEnum.EX1_573a;
            if (s == "CS2_084") return CardDB.cardIDEnum.CS2_084;
            if (s == "EX1_582") return CardDB.cardIDEnum.EX1_582;
            if (s == "EX1_043") return CardDB.cardIDEnum.EX1_043;
            if (s == "EX1_050") return CardDB.cardIDEnum.EX1_050;
            if (s == "TU4b_001") return CardDB.cardIDEnum.TU4b_001;
            if (s == "FP1_005") return CardDB.cardIDEnum.FP1_005;
            if (s == "EX1_620") return CardDB.cardIDEnum.EX1_620;
            if (s == "NAX15_01") return CardDB.cardIDEnum.NAX15_01;
            if (s == "NAX6_03") return CardDB.cardIDEnum.NAX6_03;
            if (s == "EX1_303") return CardDB.cardIDEnum.EX1_303;
            if (s == "HERO_09") return CardDB.cardIDEnum.HERO_09;
            if (s == "EX1_067") return CardDB.cardIDEnum.EX1_067;
            if (s == "XXX_028") return CardDB.cardIDEnum.XXX_028;
            if (s == "EX1_277") return CardDB.cardIDEnum.EX1_277;
            if (s == "Mekka2") return CardDB.cardIDEnum.Mekka2;
            if (s == "NAX14_01H") return CardDB.cardIDEnum.NAX14_01H;
            if (s == "NAX15_04") return CardDB.cardIDEnum.NAX15_04;
            if (s == "FP1_024") return CardDB.cardIDEnum.FP1_024;
            if (s == "FP1_030") return CardDB.cardIDEnum.FP1_030;
            if (s == "CS2_221e") return CardDB.cardIDEnum.CS2_221e;
            if (s == "EX1_178") return CardDB.cardIDEnum.EX1_178;
            if (s == "CS2_222") return CardDB.cardIDEnum.CS2_222;
            if (s == "EX1_409e") return CardDB.cardIDEnum.EX1_409e;
            if (s == "tt_004o") return CardDB.cardIDEnum.tt_004o;
            if (s == "EX1_155ae") return CardDB.cardIDEnum.EX1_155ae;
            if (s == "NAX11_01H") return CardDB.cardIDEnum.NAX11_01H;
            if (s == "EX1_160a") return CardDB.cardIDEnum.EX1_160a;
            if (s == "NAX15_02") return CardDB.cardIDEnum.NAX15_02;
            if (s == "NAX15_05") return CardDB.cardIDEnum.NAX15_05;
            if (s == "NEW1_025e") return CardDB.cardIDEnum.NEW1_025e;
            if (s == "CS2_012") return CardDB.cardIDEnum.CS2_012;
            if (s == "XXX_099") return CardDB.cardIDEnum.XXX_099;
            if (s == "EX1_246") return CardDB.cardIDEnum.EX1_246;
            if (s == "EX1_572") return CardDB.cardIDEnum.EX1_572;
            if (s == "EX1_089") return CardDB.cardIDEnum.EX1_089;
            if (s == "CS2_059") return CardDB.cardIDEnum.CS2_059;
            if (s == "EX1_279") return CardDB.cardIDEnum.EX1_279;
            if (s == "NAX12_02e") return CardDB.cardIDEnum.NAX12_02e;
            if (s == "CS2_168") return CardDB.cardIDEnum.CS2_168;
            if (s == "tt_010") return CardDB.cardIDEnum.tt_010;
            if (s == "NEW1_023") return CardDB.cardIDEnum.NEW1_023;
            if (s == "CS2_075") return CardDB.cardIDEnum.CS2_075;
            if (s == "EX1_316") return CardDB.cardIDEnum.EX1_316;
            if (s == "CS2_025") return CardDB.cardIDEnum.CS2_025;
            if (s == "CS2_234") return CardDB.cardIDEnum.CS2_234;
            if (s == "XXX_043") return CardDB.cardIDEnum.XXX_043;
            if (s == "GAME_001") return CardDB.cardIDEnum.GAME_001;
            if (s == "NAX5_02") return CardDB.cardIDEnum.NAX5_02;
            if (s == "EX1_130") return CardDB.cardIDEnum.EX1_130;
            if (s == "EX1_584e") return CardDB.cardIDEnum.EX1_584e;
            if (s == "CS2_064") return CardDB.cardIDEnum.CS2_064;
            if (s == "EX1_161") return CardDB.cardIDEnum.EX1_161;
            if (s == "CS2_049") return CardDB.cardIDEnum.CS2_049;
            if (s == "NAX13_01") return CardDB.cardIDEnum.NAX13_01;
            if (s == "EX1_154") return CardDB.cardIDEnum.EX1_154;
            if (s == "EX1_080") return CardDB.cardIDEnum.EX1_080;
            if (s == "NEW1_022") return CardDB.cardIDEnum.NEW1_022;
            if (s == "NAX2_01H") return CardDB.cardIDEnum.NAX2_01H;
            if (s == "EX1_160be") return CardDB.cardIDEnum.EX1_160be;
            if (s == "NAX12_03") return CardDB.cardIDEnum.NAX12_03;
            if (s == "EX1_251") return CardDB.cardIDEnum.EX1_251;
            if (s == "FP1_025") return CardDB.cardIDEnum.FP1_025;
            if (s == "EX1_371") return CardDB.cardIDEnum.EX1_371;
            if (s == "CS2_mirror") return CardDB.cardIDEnum.CS2_mirror;
            if (s == "NAX4_01H") return CardDB.cardIDEnum.NAX4_01H;
            if (s == "EX1_594") return CardDB.cardIDEnum.EX1_594;
            if (s == "NAX14_02") return CardDB.cardIDEnum.NAX14_02;
            if (s == "TU4c_006e") return CardDB.cardIDEnum.TU4c_006e;
            if (s == "EX1_560") return CardDB.cardIDEnum.EX1_560;
            if (s == "CS2_236") return CardDB.cardIDEnum.CS2_236;
            if (s == "TU4f_006") return CardDB.cardIDEnum.TU4f_006;
            if (s == "EX1_402") return CardDB.cardIDEnum.EX1_402;
            if (s == "NAX3_01") return CardDB.cardIDEnum.NAX3_01;
            if (s == "EX1_506") return CardDB.cardIDEnum.EX1_506;
            if (s == "NEW1_027e") return CardDB.cardIDEnum.NEW1_027e;
            if (s == "DS1_070o") return CardDB.cardIDEnum.DS1_070o;
            if (s == "XXX_045") return CardDB.cardIDEnum.XXX_045;
            if (s == "XXX_029") return CardDB.cardIDEnum.XXX_029;
            if (s == "DS1_178") return CardDB.cardIDEnum.DS1_178;
            if (s == "XXX_098") return CardDB.cardIDEnum.XXX_098;
            if (s == "EX1_315") return CardDB.cardIDEnum.EX1_315;
            if (s == "CS2_094") return CardDB.cardIDEnum.CS2_094;
            if (s == "NAX13_01H") return CardDB.cardIDEnum.NAX13_01H;
            if (s == "TU4e_002t") return CardDB.cardIDEnum.TU4e_002t;
            if (s == "EX1_046e") return CardDB.cardIDEnum.EX1_046e;
            if (s == "NEW1_040t") return CardDB.cardIDEnum.NEW1_040t;
            if (s == "GAME_005e") return CardDB.cardIDEnum.GAME_005e;
            if (s == "CS2_131") return CardDB.cardIDEnum.CS2_131;
            if (s == "XXX_008") return CardDB.cardIDEnum.XXX_008;
            if (s == "EX1_531e") return CardDB.cardIDEnum.EX1_531e;
            if (s == "CS2_226e") return CardDB.cardIDEnum.CS2_226e;
            if (s == "XXX_022e") return CardDB.cardIDEnum.XXX_022e;
            if (s == "DS1_178e") return CardDB.cardIDEnum.DS1_178e;
            if (s == "CS2_226o") return CardDB.cardIDEnum.CS2_226o;
            if (s == "NAX9_04H") return CardDB.cardIDEnum.NAX9_04H;
            if (s == "Mekka4e") return CardDB.cardIDEnum.Mekka4e;
            if (s == "EX1_082") return CardDB.cardIDEnum.EX1_082;
            if (s == "CS2_093") return CardDB.cardIDEnum.CS2_093;
            if (s == "EX1_411e") return CardDB.cardIDEnum.EX1_411e;
            if (s == "NAX8_03t") return CardDB.cardIDEnum.NAX8_03t;
            if (s == "EX1_145o") return CardDB.cardIDEnum.EX1_145o;
            if (s == "NAX7_04") return CardDB.cardIDEnum.NAX7_04;
            if (s == "CS2_boar") return CardDB.cardIDEnum.CS2_boar;
            if (s == "NEW1_019") return CardDB.cardIDEnum.NEW1_019;
            if (s == "EX1_289") return CardDB.cardIDEnum.EX1_289;
            if (s == "EX1_025t") return CardDB.cardIDEnum.EX1_025t;
            if (s == "EX1_398t") return CardDB.cardIDEnum.EX1_398t;
            if (s == "NAX12_03H") return CardDB.cardIDEnum.NAX12_03H;
            if (s == "EX1_055o") return CardDB.cardIDEnum.EX1_055o;
            if (s == "CS2_091") return CardDB.cardIDEnum.CS2_091;
            if (s == "EX1_241") return CardDB.cardIDEnum.EX1_241;
            if (s == "EX1_085") return CardDB.cardIDEnum.EX1_085;
            if (s == "CS2_200") return CardDB.cardIDEnum.CS2_200;
            if (s == "CS2_034") return CardDB.cardIDEnum.CS2_034;
            if (s == "EX1_583") return CardDB.cardIDEnum.EX1_583;
            if (s == "EX1_584") return CardDB.cardIDEnum.EX1_584;
            if (s == "EX1_155") return CardDB.cardIDEnum.EX1_155;
            if (s == "EX1_622") return CardDB.cardIDEnum.EX1_622;
            if (s == "CS2_203") return CardDB.cardIDEnum.CS2_203;
            if (s == "EX1_124") return CardDB.cardIDEnum.EX1_124;
            if (s == "EX1_379") return CardDB.cardIDEnum.EX1_379;
            if (s == "NAX7_02") return CardDB.cardIDEnum.NAX7_02;
            if (s == "CS2_053e") return CardDB.cardIDEnum.CS2_053e;
            if (s == "EX1_032") return CardDB.cardIDEnum.EX1_032;
            if (s == "NAX9_01") return CardDB.cardIDEnum.NAX9_01;
            if (s == "TU4e_003") return CardDB.cardIDEnum.TU4e_003;
            if (s == "CS2_146o") return CardDB.cardIDEnum.CS2_146o;
            if (s == "NAX8_01H") return CardDB.cardIDEnum.NAX8_01H;
            if (s == "XXX_041") return CardDB.cardIDEnum.XXX_041;
            if (s == "NAXM_002") return CardDB.cardIDEnum.NAXM_002;
            if (s == "EX1_391") return CardDB.cardIDEnum.EX1_391;
            if (s == "EX1_366") return CardDB.cardIDEnum.EX1_366;
            if (s == "EX1_059e") return CardDB.cardIDEnum.EX1_059e;
            if (s == "XXX_012") return CardDB.cardIDEnum.XXX_012;
            if (s == "EX1_565o") return CardDB.cardIDEnum.EX1_565o;
            if (s == "EX1_001e") return CardDB.cardIDEnum.EX1_001e;
            if (s == "TU4f_003") return CardDB.cardIDEnum.TU4f_003;
            if (s == "EX1_400") return CardDB.cardIDEnum.EX1_400;
            if (s == "EX1_614") return CardDB.cardIDEnum.EX1_614;
            if (s == "EX1_561") return CardDB.cardIDEnum.EX1_561;
            if (s == "EX1_332") return CardDB.cardIDEnum.EX1_332;
            if (s == "HERO_05") return CardDB.cardIDEnum.HERO_05;
            if (s == "CS2_065") return CardDB.cardIDEnum.CS2_065;
            if (s == "ds1_whelptoken") return CardDB.cardIDEnum.ds1_whelptoken;
            if (s == "EX1_536e") return CardDB.cardIDEnum.EX1_536e;
            if (s == "CS2_032") return CardDB.cardIDEnum.CS2_032;
            if (s == "CS2_120") return CardDB.cardIDEnum.CS2_120;
            if (s == "EX1_155be") return CardDB.cardIDEnum.EX1_155be;
            if (s == "EX1_247") return CardDB.cardIDEnum.EX1_247;
            if (s == "EX1_154a") return CardDB.cardIDEnum.EX1_154a;
            if (s == "EX1_554t") return CardDB.cardIDEnum.EX1_554t;
            if (s == "CS2_103e2") return CardDB.cardIDEnum.CS2_103e2;
            if (s == "TU4d_003") return CardDB.cardIDEnum.TU4d_003;
            if (s == "NEW1_026t") return CardDB.cardIDEnum.NEW1_026t;
            if (s == "EX1_623") return CardDB.cardIDEnum.EX1_623;
            if (s == "EX1_383t") return CardDB.cardIDEnum.EX1_383t;
            if (s == "NAX7_03") return CardDB.cardIDEnum.NAX7_03;
            if (s == "EX1_597") return CardDB.cardIDEnum.EX1_597;
            if (s == "TU4f_006o") return CardDB.cardIDEnum.TU4f_006o;
            if (s == "EX1_130a") return CardDB.cardIDEnum.EX1_130a;
            if (s == "CS2_011") return CardDB.cardIDEnum.CS2_011;
            if (s == "EX1_169") return CardDB.cardIDEnum.EX1_169;
            if (s == "EX1_tk33") return CardDB.cardIDEnum.EX1_tk33;
            if (s == "NAX11_03") return CardDB.cardIDEnum.NAX11_03;
            if (s == "NAX4_01") return CardDB.cardIDEnum.NAX4_01;
            if (s == "NAX10_01") return CardDB.cardIDEnum.NAX10_01;
            if (s == "EX1_250") return CardDB.cardIDEnum.EX1_250;
            if (s == "EX1_564") return CardDB.cardIDEnum.EX1_564;
            if (s == "NAX5_03") return CardDB.cardIDEnum.NAX5_03;
            if (s == "EX1_043e") return CardDB.cardIDEnum.EX1_043e;
            if (s == "EX1_349") return CardDB.cardIDEnum.EX1_349;
            if (s == "XXX_097") return CardDB.cardIDEnum.XXX_097;
            if (s == "EX1_102") return CardDB.cardIDEnum.EX1_102;
            if (s == "EX1_058") return CardDB.cardIDEnum.EX1_058;
            if (s == "EX1_243") return CardDB.cardIDEnum.EX1_243;
            if (s == "PRO_001c") return CardDB.cardIDEnum.PRO_001c;
            if (s == "EX1_116t") return CardDB.cardIDEnum.EX1_116t;
            if (s == "NAX15_01e") return CardDB.cardIDEnum.NAX15_01e;
            if (s == "FP1_029") return CardDB.cardIDEnum.FP1_029;
            if (s == "CS2_089") return CardDB.cardIDEnum.CS2_089;
            if (s == "TU4c_001") return CardDB.cardIDEnum.TU4c_001;
            if (s == "EX1_248") return CardDB.cardIDEnum.EX1_248;
            if (s == "NEW1_037e") return CardDB.cardIDEnum.NEW1_037e;
            if (s == "CS2_122") return CardDB.cardIDEnum.CS2_122;
            if (s == "EX1_393") return CardDB.cardIDEnum.EX1_393;
            if (s == "CS2_232") return CardDB.cardIDEnum.CS2_232;
            if (s == "EX1_165b") return CardDB.cardIDEnum.EX1_165b;
            if (s == "NEW1_030") return CardDB.cardIDEnum.NEW1_030;
            if (s == "EX1_161o") return CardDB.cardIDEnum.EX1_161o;
            if (s == "EX1_093e") return CardDB.cardIDEnum.EX1_093e;
            if (s == "CS2_150") return CardDB.cardIDEnum.CS2_150;
            if (s == "CS2_152") return CardDB.cardIDEnum.CS2_152;
            if (s == "NAX9_03H") return CardDB.cardIDEnum.NAX9_03H;
            if (s == "EX1_160t") return CardDB.cardIDEnum.EX1_160t;
            if (s == "CS2_127") return CardDB.cardIDEnum.CS2_127;
            if (s == "CRED_03") return CardDB.cardIDEnum.CRED_03;
            if (s == "DS1_188") return CardDB.cardIDEnum.DS1_188;
            if (s == "XXX_001") return CardDB.cardIDEnum.XXX_001;
            return CardDB.cardIDEnum.None;
        }

        public enum cardName
        {
            unknown,
            hogger,
            heigantheunclean,
            necroticaura,
            starfall,
            barrel,
            damagereflector,
            edwinvancleef,
            gothiktheharvester,
            perditionsblade,
            bloodsailraider,
            guardianoficecrown,
            bloodmagethalnos,
            rooted,
            wisp,
            rachelledavis,
            senjinshieldmasta,
            totemicmight,
            uproot,
            opponentdisconnect,
            unrelentingrider,
            shandoslesson,
            hemetnesingwary,
            decimate,
            shadowofnothing,
            nerubian,
            dragonlingmechanic,
            mogushanwarden,
            thanekorthazz,
            hungrycrab,
            ancientteachings,
            misdirection,
            patientassassin,
            mutatinginjection,
            violetteacher,
            arathiweaponsmith,
            raisedead,
            acolyteofpain,
            holynova,
            robpardo,
            commandingshout,
            necroticpoison,
            unboundelemental,
            garroshhellscream,
            enchant,
            loatheb,
            blessingofmight,
            nightmare,
            blessingofkings,
            polymorph,
            darkirondwarf,
            destroy,
            roguesdoit,
            freecards,
            iammurloc,
            sporeburst,
            mindcontrolcrystal,
            charge,
            stampedingkodo,
            humility,
            darkcultist,
            gruul,
            markofthewild,
            patchwerk,
            worgeninfiltrator,
            frostbolt,
            runeblade,
            flametonguetotem,
            assassinate,
            madscientist,
            lordofthearena,
            bainebloodhoof,
            injuredblademaster,
            siphonsoul,
            layonhands,
            hook,
            massiveruneblade,
            lorewalkercho,
            destroyallminions,
            silvermoonguardian,
            destroyallmana,
            huffer,
            mindvision,
            malfurionstormrage,
            corehound,
            grimscaleoracle,
            lightningstorm,
            lightwell,
            benthompson,
            coldlightseer,
            deathsbite,
            gorehowl,
            skitter,
            farsight,
            chillwindyeti,
            moonfire,
            bladeflurry,
            massdispel,
            crazedalchemist,
            shadowmadness,
            equality,
            misha,
            treant,
            alarmobot,
            animalcompanion,
            hatefulstrike,
            dream,
            anubrekhan,
            youngpriestess,
            gadgetzanauctioneer,
            coneofcold,
            earthshock,
            tirionfordring,
            wailingsoul,
            skeleton,
            ironfurgrizzly,
            headcrack,
            arcaneshot,
            maexxna,
            imp,
            markofthehorsemen,
            voidterror,
            mortalcoil,
            draw3cards,
            flameofazzinoth,
            jainaproudmoore,
            execute,
            bloodlust,
            bananas,
            kidnapper,
            oldmurkeye,
            homingchicken,
            enableforattack,
            spellbender,
            backstab,
            squirrel,
            stalagg,
            grandwidowfaerlina,
            heavyaxe,
            zwick,
            webwrap,
            flamesofazzinoth,
            murlocwarleader,
            shadowstep,
            ancestralspirit,
            defenderofargus,
            assassinsblade,
            discard,
            biggamehunter,
            aldorpeacekeeper,
            blizzard,
            pandarenscout,
            unleashthehounds,
            yseraawakens,
            sap,
            kelthuzad,
            defiasbandit,
            gnomishinventor,
            mindcontrol,
            ravenholdtassassin,
            icelance,
            dispel,
            acidicswampooze,
            muklasbigbrother,
            blessedchampion,
            savannahhighmane,
            direwolfalpha,
            hoggersmash,
            blessingofwisdom,
            nourish,
            abusivesergeant,
            sylvanaswindrunner,
            spore,
            crueltaskmaster,
            lightningbolt,
            keeperofthegrove,
            steadyshot,
            multishot,
            harvest,
            instructorrazuvious,
            ladyblaumeux,
            jaybaxter,
            molasses,
            pintsizedsummoner,
            spellbreaker,
            anubarambusher,
            deadlypoison,
            stoneskingargoyle,
            bloodfury,
            fanofknives,
            poisoncloud,
            shieldbearer,
            sensedemons,
            shieldblock,
            handswapperminion,
            massivegnoll,
            deathcharger,
            ancientoflore,
            oasissnapjaw,
            illidanstormrage,
            frostwolfgrunt,
            lesserheal,
            infernal,
            wildpyromancer,
            razorfenhunter,
            twistingnether,
            voidcaller,
            leaderofthepack,
            malygos,
            becomehogger,
            baronrivendare,
            millhousemanastorm,
            innerfire,
            valeerasanguinar,
            chicken,
            souloftheforest,
            silencedebug,
            bloodsailcorsair,
            slime,
            tinkmasteroverspark,
            iceblock,
            brawl,
            vanish,
            poisonseeds,
            murloc,
            mindspike,
            kingmukla,
            stevengabriel,
            gluth,
            truesilverchampion,
            harrisonjones,
            destroydeck,
            devilsaur,
            wargolem,
            warsongcommander,
            manawyrm,
            thaddius,
            savagery,
            spitefulsmith,
            shatteredsuncleric,
            eyeforaneye,
            azuredrake,
            mountaingiant,
            korkronelite,
            junglepanther,
            barongeddon,
            spectralspider,
            pitlord,
            markofnature,
            grobbulus,
            leokk,
            fierywaraxe,
            damage5,
            duplicate,
            restore5,
            mindblast,
            timberwolf,
            captaingreenskin,
            elvenarcher,
            michaelschweitzer,
            masterswordsmith,
            grommashhellscream,
            hound,
            seagiant,
            doomguard,
            alakirthewindlord,
            hyena,
            undertaker,
            frothingberserker,
            powerofthewild,
            druidoftheclaw,
            hellfire,
            archmage,
            recklessrocketeer,
            crazymonkey,
            damageallbut1,
            frostblast,
            powerwordshield,
            rainoffire,
            arcaneintellect,
            angrychicken,
            nerubianegg,
            worshipper,
            mindgames,
            leeroyjenkins,
            gurubashiberserker,
            windspeaker,
            enableemotes,
            forceofnature,
            lightspawn,
            destroyamanacrystal,
            warglaiveofazzinoth,
            finkleeinhorn,
            frostelemental,
            thoughtsteal,
            brianschwab,
            scavenginghyena,
            si7agent,
            prophetvelen,
            soulfire,
            ogremagi,
            damagedgolem,
            crash,
            adrenalinerush,
            murloctidecaller,
            kirintormage,
            spectralrider,
            thrallmarfarseer,
            frostwolfwarlord,
            sorcerersapprentice,
            feugen,
            willofmukla,
            holyfire,
            manawraith,
            argentsquire,
            placeholdercard,
            snakeball,
            ancientwatcher,
            noviceengineer,
            stonetuskboar,
            ancestralhealing,
            conceal,
            arcanitereaper,
            guldan,
            ragingworgen,
            earthenringfarseer,
            onyxia,
            manaaddict,
            unholyshadow,
            dualwarglaives,
            sludgebelcher,
            worthlessimp,
            shiv,
            sheep,
            bloodknight,
            holysmite,
            ancientsecrets,
            holywrath,
            ironforgerifleman,
            elitetaurenchieftain,
            spectralwarrior,
            bluegillwarrior,
            shapeshift,
            hamiltonchu,
            battlerage,
            nightblade,
            locustswarm,
            crazedhunter,
            andybrock,
            youthfulbrewmaster,
            theblackknight,
            brewmaster,
            lifetap,
            demonfire,
            redemption,
            lordjaraxxus,
            coldblood,
            lightwarden,
            questingadventurer,
            donothing,
            dereksakamoto,
            poultryizer,
            koboldgeomancer,
            legacyoftheemperor,
            eruption,
            cenarius,
            deathlord,
            searingtotem,
            taurenwarrior,
            explosivetrap,
            frog,
            servercrash,
            wickedknife,
            laughingsister,
            cultmaster,
            wildgrowth,
            sprint,
            masterofdisguise,
            kyleharrison,
            avatarofthecoin,
            excessmana,
            spiritwolf,
            auchenaisoulpriest,
            bestialwrath,
            rockbiterweapon,
            starvingbuzzard,
            mirrorimage,
            frozenchampion,
            silverhandrecruit,
            corruption,
            preparation,
            cairnebloodhoof,
            mortalstrike,
            flare,
            necroknight,
            silverhandknight,
            breakweapon,
            guardianofkings,
            ancientbrewmaster,
            avenge,
            youngdragonhawk,
            frostshock,
            healingtouch,
            venturecomercenary,
            unbalancingstrike,
            sacrificialpact,
            noooooooooooo,
            baneofdoom,
            abomination,
            flesheatingghoul,
            loothoarder,
            mill10,
            sapphiron,
            jasonchayes,
            benbrode,
            betrayal,
            thebeast,
            flameimp,
            freezingtrap,
            southseadeckhand,
            wrath,
            bloodfenraptor,
            cleave,
            fencreeper,
            restore1,
            handtodeck,
            starfire,
            goldshirefootman,
            unrelentingtrainee,
            murlocscout,
            ragnarosthefirelord,
            rampage,
            zombiechow,
            thrall,
            stoneclawtotem,
            captainsparrot,
            windfuryharpy,
            unrelentingwarrior,
            stranglethorntiger,
            summonarandomsecret,
            circleofhealing,
            snaketrap,
            cabalshadowpriest,
            nerubarweblord,
            upgrade,
            shieldslam,
            flameburst,
            windfury,
            enrage,
            natpagle,
            restoreallhealth,
            houndmaster,
            waterelemental,
            eaglehornbow,
            gnoll,
            archmageantonidas,
            destroyallheroes,
            chains,
            wrathofairtotem,
            killcommand,
            manatidetotem,
            daggermastery,
            drainlife,
            doomsayer,
            darkscalehealer,
            shadowform,
            frostnova,
            purecold,
            mirrorentity,
            counterspell,
            mindshatter,
            magmarager,
            wolfrider,
            emboldener3000,
            polarityshift,
            gelbinmekkatorque,
            webspinner,
            utherlightbringer,
            innerrage,
            emeralddrake,
            forceaitouseheropower,
            echoingooze,
            heroicstrike,
            hauntedcreeper,
            barreltoss,
            yongwoo,
            doomhammer,
            stomp,
            spectralknight,
            tracking,
            fireball,
            thecoin,
            bootybaybodyguard,
            scarletcrusader,
            voodoodoctor,
            shadowbolt,
            etherealarcanist,
            succubus,
            emperorcobra,
            deadlyshot,
            reinforce,
            supercharge,
            claw,
            explosiveshot,
            avengingwrath,
            riverpawgnoll,
            sirzeliek,
            argentprotector,
            hiddengnome,
            felguard,
            northshirecleric,
            plague,
            lepergnome,
            fireelemental,
            armorup,
            snipe,
            southseacaptain,
            catform,
            bite,
            defiasringleader,
            harvestgolem,
            kingkrush,
            aibuddydamageownhero5,
            healingtotem,
            ericdodds,
            demigodsfavor,
            huntersmark,
            dalaranmage,
            twilightdrake,
            coldlightoracle,
            shadeofnaxxramas,
            moltengiant,
            deathbloom,
            shadowflame,
            anduinwrynn,
            argentcommander,
            revealhand,
            arcanemissiles,
            repairbot,
            unstableghoul,
            ancientofwar,
            stormwindchampion,
            summonapanther,
            mrbigglesworth,
            swipe,
            aihelperbuddy,
            hex,
            ysera,
            arcanegolem,
            bloodimp,
            pyroblast,
            murlocraider,
            faeriedragon,
            sinisterstrike,
            poweroverwhelming,
            arcaneexplosion,
            shadowwordpain,
            mill30,
            noblesacrifice,
            dreadinfernal,
            naturalize,
            totemiccall,
            secretkeeper,
            dreadcorsair,
            jaws,
            forkedlightning,
            reincarnate,
            handofprotection,
            noththeplaguebringer,
            vaporize,
            frostbreath,
            nozdormu,
            divinespirit,
            transcendence,
            armorsmith,
            murloctidehunter,
            stealcard,
            opponentconcede,
            tundrarhino,
            summoningportal,
            hammerofwrath,
            stormwindknight,
            freeze,
            madbomber,
            consecration,
            spectraltrainee,
            boar,
            knifejuggler,
            icebarrier,
            mechanicaldragonling,
            battleaxe,
            lightsjustice,
            lavaburst,
            mindcontroltech,
            boulderfistogre,
            fireblast,
            priestessofelune,
            ancientmage,
            shadowworddeath,
            ironbeakowl,
            eviscerate,
            repentance,
            understudy,
            sunwalker,
            nagamyrmidon,
            destroyheropower,
            skeletalsmith,
            slam,
            swordofjustice,
            bounce,
            shadopanmonk,
            whirlwind,
            alexstrasza,
            silence,
            rexxar,
            voidwalker,
            whelp,
            flamestrike,
            rivercrocolisk,
            stormforgedaxe,
            snake,
            shotgunblast,
            violetapprentice,
            templeenforcer,
            ashbringer,
            impmaster,
            defender,
            savageroar,
            innervate,
            inferno,
            falloutslime,
            earthelemental,
            facelessmanipulator,
            mindpocalypse,
            divinefavor,
            aibuddydestroyminions,
            demolisher,
            sunfuryprotector,
            dustdevil,
            powerofthehorde,
            dancingswords,
            holylight,
            feralspirit,
            raidleader,
            amaniberserker,
            ironbarkprotector,
            bearform,
            deathwing,
            stormpikecommando,
            squire,
            panther,
            silverbackpatriarch,
            bobfitch,
            gladiatorslongbow,
            damage1,
        }

        public cardName cardNamestringToEnum(string s)
        {
            if (s == "unknown") return CardDB.cardName.unknown;
            if (s == "hogger") return CardDB.cardName.hogger;
            if (s == "heigantheunclean") return CardDB.cardName.heigantheunclean;
            if (s == "necroticaura") return CardDB.cardName.necroticaura;
            if (s == "starfall") return CardDB.cardName.starfall;
            if (s == "barrel") return CardDB.cardName.barrel;
            if (s == "damagereflector") return CardDB.cardName.damagereflector;
            if (s == "edwinvancleef") return CardDB.cardName.edwinvancleef;
            if (s == "gothiktheharvester") return CardDB.cardName.gothiktheharvester;
            if (s == "perditionsblade") return CardDB.cardName.perditionsblade;
            if (s == "bloodsailraider") return CardDB.cardName.bloodsailraider;
            if (s == "guardianoficecrown") return CardDB.cardName.guardianoficecrown;
            if (s == "bloodmagethalnos") return CardDB.cardName.bloodmagethalnos;
            if (s == "rooted") return CardDB.cardName.rooted;
            if (s == "wisp") return CardDB.cardName.wisp;
            if (s == "rachelledavis") return CardDB.cardName.rachelledavis;
            if (s == "senjinshieldmasta") return CardDB.cardName.senjinshieldmasta;
            if (s == "totemicmight") return CardDB.cardName.totemicmight;
            if (s == "uproot") return CardDB.cardName.uproot;
            if (s == "opponentdisconnect") return CardDB.cardName.opponentdisconnect;
            if (s == "unrelentingrider") return CardDB.cardName.unrelentingrider;
            if (s == "shandoslesson") return CardDB.cardName.shandoslesson;
            if (s == "hemetnesingwary") return CardDB.cardName.hemetnesingwary;
            if (s == "decimate") return CardDB.cardName.decimate;
            if (s == "shadowofnothing") return CardDB.cardName.shadowofnothing;
            if (s == "nerubian") return CardDB.cardName.nerubian;
            if (s == "dragonlingmechanic") return CardDB.cardName.dragonlingmechanic;
            if (s == "mogushanwarden") return CardDB.cardName.mogushanwarden;
            if (s == "thanekorthazz") return CardDB.cardName.thanekorthazz;
            if (s == "hungrycrab") return CardDB.cardName.hungrycrab;
            if (s == "ancientteachings") return CardDB.cardName.ancientteachings;
            if (s == "misdirection") return CardDB.cardName.misdirection;
            if (s == "patientassassin") return CardDB.cardName.patientassassin;
            if (s == "mutatinginjection") return CardDB.cardName.mutatinginjection;
            if (s == "violetteacher") return CardDB.cardName.violetteacher;
            if (s == "arathiweaponsmith") return CardDB.cardName.arathiweaponsmith;
            if (s == "raisedead") return CardDB.cardName.raisedead;
            if (s == "acolyteofpain") return CardDB.cardName.acolyteofpain;
            if (s == "holynova") return CardDB.cardName.holynova;
            if (s == "robpardo") return CardDB.cardName.robpardo;
            if (s == "commandingshout") return CardDB.cardName.commandingshout;
            if (s == "necroticpoison") return CardDB.cardName.necroticpoison;
            if (s == "unboundelemental") return CardDB.cardName.unboundelemental;
            if (s == "garroshhellscream") return CardDB.cardName.garroshhellscream;
            if (s == "enchant") return CardDB.cardName.enchant;
            if (s == "loatheb") return CardDB.cardName.loatheb;
            if (s == "blessingofmight") return CardDB.cardName.blessingofmight;
            if (s == "nightmare") return CardDB.cardName.nightmare;
            if (s == "blessingofkings") return CardDB.cardName.blessingofkings;
            if (s == "polymorph") return CardDB.cardName.polymorph;
            if (s == "darkirondwarf") return CardDB.cardName.darkirondwarf;
            if (s == "destroy") return CardDB.cardName.destroy;
            if (s == "roguesdoit") return CardDB.cardName.roguesdoit;
            if (s == "freecards") return CardDB.cardName.freecards;
            if (s == "iammurloc") return CardDB.cardName.iammurloc;
            if (s == "sporeburst") return CardDB.cardName.sporeburst;
            if (s == "mindcontrolcrystal") return CardDB.cardName.mindcontrolcrystal;
            if (s == "charge") return CardDB.cardName.charge;
            if (s == "stampedingkodo") return CardDB.cardName.stampedingkodo;
            if (s == "humility") return CardDB.cardName.humility;
            if (s == "darkcultist") return CardDB.cardName.darkcultist;
            if (s == "gruul") return CardDB.cardName.gruul;
            if (s == "markofthewild") return CardDB.cardName.markofthewild;
            if (s == "patchwerk") return CardDB.cardName.patchwerk;
            if (s == "worgeninfiltrator") return CardDB.cardName.worgeninfiltrator;
            if (s == "frostbolt") return CardDB.cardName.frostbolt;
            if (s == "runeblade") return CardDB.cardName.runeblade;
            if (s == "flametonguetotem") return CardDB.cardName.flametonguetotem;
            if (s == "assassinate") return CardDB.cardName.assassinate;
            if (s == "madscientist") return CardDB.cardName.madscientist;
            if (s == "lordofthearena") return CardDB.cardName.lordofthearena;
            if (s == "bainebloodhoof") return CardDB.cardName.bainebloodhoof;
            if (s == "injuredblademaster") return CardDB.cardName.injuredblademaster;
            if (s == "siphonsoul") return CardDB.cardName.siphonsoul;
            if (s == "layonhands") return CardDB.cardName.layonhands;
            if (s == "hook") return CardDB.cardName.hook;
            if (s == "massiveruneblade") return CardDB.cardName.massiveruneblade;
            if (s == "lorewalkercho") return CardDB.cardName.lorewalkercho;
            if (s == "destroyallminions") return CardDB.cardName.destroyallminions;
            if (s == "silvermoonguardian") return CardDB.cardName.silvermoonguardian;
            if (s == "destroyallmana") return CardDB.cardName.destroyallmana;
            if (s == "huffer") return CardDB.cardName.huffer;
            if (s == "mindvision") return CardDB.cardName.mindvision;
            if (s == "malfurionstormrage") return CardDB.cardName.malfurionstormrage;
            if (s == "corehound") return CardDB.cardName.corehound;
            if (s == "grimscaleoracle") return CardDB.cardName.grimscaleoracle;
            if (s == "lightningstorm") return CardDB.cardName.lightningstorm;
            if (s == "lightwell") return CardDB.cardName.lightwell;
            if (s == "benthompson") return CardDB.cardName.benthompson;
            if (s == "coldlightseer") return CardDB.cardName.coldlightseer;
            if (s == "deathsbite") return CardDB.cardName.deathsbite;
            if (s == "gorehowl") return CardDB.cardName.gorehowl;
            if (s == "skitter") return CardDB.cardName.skitter;
            if (s == "farsight") return CardDB.cardName.farsight;
            if (s == "chillwindyeti") return CardDB.cardName.chillwindyeti;
            if (s == "moonfire") return CardDB.cardName.moonfire;
            if (s == "bladeflurry") return CardDB.cardName.bladeflurry;
            if (s == "massdispel") return CardDB.cardName.massdispel;
            if (s == "crazedalchemist") return CardDB.cardName.crazedalchemist;
            if (s == "shadowmadness") return CardDB.cardName.shadowmadness;
            if (s == "equality") return CardDB.cardName.equality;
            if (s == "misha") return CardDB.cardName.misha;
            if (s == "treant") return CardDB.cardName.treant;
            if (s == "alarmobot") return CardDB.cardName.alarmobot;
            if (s == "animalcompanion") return CardDB.cardName.animalcompanion;
            if (s == "hatefulstrike") return CardDB.cardName.hatefulstrike;
            if (s == "dream") return CardDB.cardName.dream;
            if (s == "anubrekhan") return CardDB.cardName.anubrekhan;
            if (s == "youngpriestess") return CardDB.cardName.youngpriestess;
            if (s == "gadgetzanauctioneer") return CardDB.cardName.gadgetzanauctioneer;
            if (s == "coneofcold") return CardDB.cardName.coneofcold;
            if (s == "earthshock") return CardDB.cardName.earthshock;
            if (s == "tirionfordring") return CardDB.cardName.tirionfordring;
            if (s == "wailingsoul") return CardDB.cardName.wailingsoul;
            if (s == "skeleton") return CardDB.cardName.skeleton;
            if (s == "ironfurgrizzly") return CardDB.cardName.ironfurgrizzly;
            if (s == "headcrack") return CardDB.cardName.headcrack;
            if (s == "arcaneshot") return CardDB.cardName.arcaneshot;
            if (s == "maexxna") return CardDB.cardName.maexxna;
            if (s == "imp") return CardDB.cardName.imp;
            if (s == "markofthehorsemen") return CardDB.cardName.markofthehorsemen;
            if (s == "voidterror") return CardDB.cardName.voidterror;
            if (s == "mortalcoil") return CardDB.cardName.mortalcoil;
            if (s == "draw3cards") return CardDB.cardName.draw3cards;
            if (s == "flameofazzinoth") return CardDB.cardName.flameofazzinoth;
            if (s == "jainaproudmoore") return CardDB.cardName.jainaproudmoore;
            if (s == "execute") return CardDB.cardName.execute;
            if (s == "bloodlust") return CardDB.cardName.bloodlust;
            if (s == "bananas") return CardDB.cardName.bananas;
            if (s == "kidnapper") return CardDB.cardName.kidnapper;
            if (s == "oldmurkeye") return CardDB.cardName.oldmurkeye;
            if (s == "homingchicken") return CardDB.cardName.homingchicken;
            if (s == "enableforattack") return CardDB.cardName.enableforattack;
            if (s == "spellbender") return CardDB.cardName.spellbender;
            if (s == "backstab") return CardDB.cardName.backstab;
            if (s == "squirrel") return CardDB.cardName.squirrel;
            if (s == "stalagg") return CardDB.cardName.stalagg;
            if (s == "grandwidowfaerlina") return CardDB.cardName.grandwidowfaerlina;
            if (s == "heavyaxe") return CardDB.cardName.heavyaxe;
            if (s == "zwick") return CardDB.cardName.zwick;
            if (s == "webwrap") return CardDB.cardName.webwrap;
            if (s == "flamesofazzinoth") return CardDB.cardName.flamesofazzinoth;
            if (s == "murlocwarleader") return CardDB.cardName.murlocwarleader;
            if (s == "shadowstep") return CardDB.cardName.shadowstep;
            if (s == "ancestralspirit") return CardDB.cardName.ancestralspirit;
            if (s == "defenderofargus") return CardDB.cardName.defenderofargus;
            if (s == "assassinsblade") return CardDB.cardName.assassinsblade;
            if (s == "discard") return CardDB.cardName.discard;
            if (s == "biggamehunter") return CardDB.cardName.biggamehunter;
            if (s == "aldorpeacekeeper") return CardDB.cardName.aldorpeacekeeper;
            if (s == "blizzard") return CardDB.cardName.blizzard;
            if (s == "pandarenscout") return CardDB.cardName.pandarenscout;
            if (s == "unleashthehounds") return CardDB.cardName.unleashthehounds;
            if (s == "yseraawakens") return CardDB.cardName.yseraawakens;
            if (s == "sap") return CardDB.cardName.sap;
            if (s == "kelthuzad") return CardDB.cardName.kelthuzad;
            if (s == "defiasbandit") return CardDB.cardName.defiasbandit;
            if (s == "gnomishinventor") return CardDB.cardName.gnomishinventor;
            if (s == "mindcontrol") return CardDB.cardName.mindcontrol;
            if (s == "ravenholdtassassin") return CardDB.cardName.ravenholdtassassin;
            if (s == "icelance") return CardDB.cardName.icelance;
            if (s == "dispel") return CardDB.cardName.dispel;
            if (s == "acidicswampooze") return CardDB.cardName.acidicswampooze;
            if (s == "muklasbigbrother") return CardDB.cardName.muklasbigbrother;
            if (s == "blessedchampion") return CardDB.cardName.blessedchampion;
            if (s == "savannahhighmane") return CardDB.cardName.savannahhighmane;
            if (s == "direwolfalpha") return CardDB.cardName.direwolfalpha;
            if (s == "hoggersmash") return CardDB.cardName.hoggersmash;
            if (s == "blessingofwisdom") return CardDB.cardName.blessingofwisdom;
            if (s == "nourish") return CardDB.cardName.nourish;
            if (s == "abusivesergeant") return CardDB.cardName.abusivesergeant;
            if (s == "sylvanaswindrunner") return CardDB.cardName.sylvanaswindrunner;
            if (s == "spore") return CardDB.cardName.spore;
            if (s == "crueltaskmaster") return CardDB.cardName.crueltaskmaster;
            if (s == "lightningbolt") return CardDB.cardName.lightningbolt;
            if (s == "keeperofthegrove") return CardDB.cardName.keeperofthegrove;
            if (s == "steadyshot") return CardDB.cardName.steadyshot;
            if (s == "multishot") return CardDB.cardName.multishot;
            if (s == "harvest") return CardDB.cardName.harvest;
            if (s == "instructorrazuvious") return CardDB.cardName.instructorrazuvious;
            if (s == "ladyblaumeux") return CardDB.cardName.ladyblaumeux;
            if (s == "jaybaxter") return CardDB.cardName.jaybaxter;
            if (s == "molasses") return CardDB.cardName.molasses;
            if (s == "pintsizedsummoner") return CardDB.cardName.pintsizedsummoner;
            if (s == "spellbreaker") return CardDB.cardName.spellbreaker;
            if (s == "anubarambusher") return CardDB.cardName.anubarambusher;
            if (s == "deadlypoison") return CardDB.cardName.deadlypoison;
            if (s == "stoneskingargoyle") return CardDB.cardName.stoneskingargoyle;
            if (s == "bloodfury") return CardDB.cardName.bloodfury;
            if (s == "fanofknives") return CardDB.cardName.fanofknives;
            if (s == "poisoncloud") return CardDB.cardName.poisoncloud;
            if (s == "shieldbearer") return CardDB.cardName.shieldbearer;
            if (s == "sensedemons") return CardDB.cardName.sensedemons;
            if (s == "shieldblock") return CardDB.cardName.shieldblock;
            if (s == "handswapperminion") return CardDB.cardName.handswapperminion;
            if (s == "massivegnoll") return CardDB.cardName.massivegnoll;
            if (s == "deathcharger") return CardDB.cardName.deathcharger;
            if (s == "ancientoflore") return CardDB.cardName.ancientoflore;
            if (s == "oasissnapjaw") return CardDB.cardName.oasissnapjaw;
            if (s == "illidanstormrage") return CardDB.cardName.illidanstormrage;
            if (s == "frostwolfgrunt") return CardDB.cardName.frostwolfgrunt;
            if (s == "lesserheal") return CardDB.cardName.lesserheal;
            if (s == "infernal") return CardDB.cardName.infernal;
            if (s == "wildpyromancer") return CardDB.cardName.wildpyromancer;
            if (s == "razorfenhunter") return CardDB.cardName.razorfenhunter;
            if (s == "twistingnether") return CardDB.cardName.twistingnether;
            if (s == "voidcaller") return CardDB.cardName.voidcaller;
            if (s == "leaderofthepack") return CardDB.cardName.leaderofthepack;
            if (s == "malygos") return CardDB.cardName.malygos;
            if (s == "becomehogger") return CardDB.cardName.becomehogger;
            if (s == "baronrivendare") return CardDB.cardName.baronrivendare;
            if (s == "millhousemanastorm") return CardDB.cardName.millhousemanastorm;
            if (s == "innerfire") return CardDB.cardName.innerfire;
            if (s == "valeerasanguinar") return CardDB.cardName.valeerasanguinar;
            if (s == "chicken") return CardDB.cardName.chicken;
            if (s == "souloftheforest") return CardDB.cardName.souloftheforest;
            if (s == "silencedebug") return CardDB.cardName.silencedebug;
            if (s == "bloodsailcorsair") return CardDB.cardName.bloodsailcorsair;
            if (s == "slime") return CardDB.cardName.slime;
            if (s == "tinkmasteroverspark") return CardDB.cardName.tinkmasteroverspark;
            if (s == "iceblock") return CardDB.cardName.iceblock;
            if (s == "brawl") return CardDB.cardName.brawl;
            if (s == "vanish") return CardDB.cardName.vanish;
            if (s == "poisonseeds") return CardDB.cardName.poisonseeds;
            if (s == "murloc") return CardDB.cardName.murloc;
            if (s == "mindspike") return CardDB.cardName.mindspike;
            if (s == "kingmukla") return CardDB.cardName.kingmukla;
            if (s == "stevengabriel") return CardDB.cardName.stevengabriel;
            if (s == "gluth") return CardDB.cardName.gluth;
            if (s == "truesilverchampion") return CardDB.cardName.truesilverchampion;
            if (s == "harrisonjones") return CardDB.cardName.harrisonjones;
            if (s == "destroydeck") return CardDB.cardName.destroydeck;
            if (s == "devilsaur") return CardDB.cardName.devilsaur;
            if (s == "wargolem") return CardDB.cardName.wargolem;
            if (s == "warsongcommander") return CardDB.cardName.warsongcommander;
            if (s == "manawyrm") return CardDB.cardName.manawyrm;
            if (s == "thaddius") return CardDB.cardName.thaddius;
            if (s == "savagery") return CardDB.cardName.savagery;
            if (s == "spitefulsmith") return CardDB.cardName.spitefulsmith;
            if (s == "shatteredsuncleric") return CardDB.cardName.shatteredsuncleric;
            if (s == "eyeforaneye") return CardDB.cardName.eyeforaneye;
            if (s == "azuredrake") return CardDB.cardName.azuredrake;
            if (s == "mountaingiant") return CardDB.cardName.mountaingiant;
            if (s == "korkronelite") return CardDB.cardName.korkronelite;
            if (s == "junglepanther") return CardDB.cardName.junglepanther;
            if (s == "barongeddon") return CardDB.cardName.barongeddon;
            if (s == "spectralspider") return CardDB.cardName.spectralspider;
            if (s == "pitlord") return CardDB.cardName.pitlord;
            if (s == "markofnature") return CardDB.cardName.markofnature;
            if (s == "grobbulus") return CardDB.cardName.grobbulus;
            if (s == "leokk") return CardDB.cardName.leokk;
            if (s == "fierywaraxe") return CardDB.cardName.fierywaraxe;
            if (s == "damage5") return CardDB.cardName.damage5;
            if (s == "duplicate") return CardDB.cardName.duplicate;
            if (s == "restore5") return CardDB.cardName.restore5;
            if (s == "mindblast") return CardDB.cardName.mindblast;
            if (s == "timberwolf") return CardDB.cardName.timberwolf;
            if (s == "captaingreenskin") return CardDB.cardName.captaingreenskin;
            if (s == "elvenarcher") return CardDB.cardName.elvenarcher;
            if (s == "michaelschweitzer") return CardDB.cardName.michaelschweitzer;
            if (s == "masterswordsmith") return CardDB.cardName.masterswordsmith;
            if (s == "grommashhellscream") return CardDB.cardName.grommashhellscream;
            if (s == "hound") return CardDB.cardName.hound;
            if (s == "seagiant") return CardDB.cardName.seagiant;
            if (s == "doomguard") return CardDB.cardName.doomguard;
            if (s == "alakirthewindlord") return CardDB.cardName.alakirthewindlord;
            if (s == "hyena") return CardDB.cardName.hyena;
            if (s == "undertaker") return CardDB.cardName.undertaker;
            if (s == "frothingberserker") return CardDB.cardName.frothingberserker;
            if (s == "powerofthewild") return CardDB.cardName.powerofthewild;
            if (s == "druidoftheclaw") return CardDB.cardName.druidoftheclaw;
            if (s == "hellfire") return CardDB.cardName.hellfire;
            if (s == "archmage") return CardDB.cardName.archmage;
            if (s == "recklessrocketeer") return CardDB.cardName.recklessrocketeer;
            if (s == "crazymonkey") return CardDB.cardName.crazymonkey;
            if (s == "damageallbut1") return CardDB.cardName.damageallbut1;
            if (s == "frostblast") return CardDB.cardName.frostblast;
            if (s == "powerwordshield") return CardDB.cardName.powerwordshield;
            if (s == "rainoffire") return CardDB.cardName.rainoffire;
            if (s == "arcaneintellect") return CardDB.cardName.arcaneintellect;
            if (s == "angrychicken") return CardDB.cardName.angrychicken;
            if (s == "nerubianegg") return CardDB.cardName.nerubianegg;
            if (s == "worshipper") return CardDB.cardName.worshipper;
            if (s == "mindgames") return CardDB.cardName.mindgames;
            if (s == "leeroyjenkins") return CardDB.cardName.leeroyjenkins;
            if (s == "gurubashiberserker") return CardDB.cardName.gurubashiberserker;
            if (s == "windspeaker") return CardDB.cardName.windspeaker;
            if (s == "enableemotes") return CardDB.cardName.enableemotes;
            if (s == "forceofnature") return CardDB.cardName.forceofnature;
            if (s == "lightspawn") return CardDB.cardName.lightspawn;
            if (s == "destroyamanacrystal") return CardDB.cardName.destroyamanacrystal;
            if (s == "warglaiveofazzinoth") return CardDB.cardName.warglaiveofazzinoth;
            if (s == "finkleeinhorn") return CardDB.cardName.finkleeinhorn;
            if (s == "frostelemental") return CardDB.cardName.frostelemental;
            if (s == "thoughtsteal") return CardDB.cardName.thoughtsteal;
            if (s == "brianschwab") return CardDB.cardName.brianschwab;
            if (s == "scavenginghyena") return CardDB.cardName.scavenginghyena;
            if (s == "si7agent") return CardDB.cardName.si7agent;
            if (s == "prophetvelen") return CardDB.cardName.prophetvelen;
            if (s == "soulfire") return CardDB.cardName.soulfire;
            if (s == "ogremagi") return CardDB.cardName.ogremagi;
            if (s == "damagedgolem") return CardDB.cardName.damagedgolem;
            if (s == "crash") return CardDB.cardName.crash;
            if (s == "adrenalinerush") return CardDB.cardName.adrenalinerush;
            if (s == "murloctidecaller") return CardDB.cardName.murloctidecaller;
            if (s == "kirintormage") return CardDB.cardName.kirintormage;
            if (s == "spectralrider") return CardDB.cardName.spectralrider;
            if (s == "thrallmarfarseer") return CardDB.cardName.thrallmarfarseer;
            if (s == "frostwolfwarlord") return CardDB.cardName.frostwolfwarlord;
            if (s == "sorcerersapprentice") return CardDB.cardName.sorcerersapprentice;
            if (s == "feugen") return CardDB.cardName.feugen;
            if (s == "willofmukla") return CardDB.cardName.willofmukla;
            if (s == "holyfire") return CardDB.cardName.holyfire;
            if (s == "manawraith") return CardDB.cardName.manawraith;
            if (s == "argentsquire") return CardDB.cardName.argentsquire;
            if (s == "placeholdercard") return CardDB.cardName.placeholdercard;
            if (s == "snakeball") return CardDB.cardName.snakeball;
            if (s == "ancientwatcher") return CardDB.cardName.ancientwatcher;
            if (s == "noviceengineer") return CardDB.cardName.noviceengineer;
            if (s == "stonetuskboar") return CardDB.cardName.stonetuskboar;
            if (s == "ancestralhealing") return CardDB.cardName.ancestralhealing;
            if (s == "conceal") return CardDB.cardName.conceal;
            if (s == "arcanitereaper") return CardDB.cardName.arcanitereaper;
            if (s == "guldan") return CardDB.cardName.guldan;
            if (s == "ragingworgen") return CardDB.cardName.ragingworgen;
            if (s == "earthenringfarseer") return CardDB.cardName.earthenringfarseer;
            if (s == "onyxia") return CardDB.cardName.onyxia;
            if (s == "manaaddict") return CardDB.cardName.manaaddict;
            if (s == "unholyshadow") return CardDB.cardName.unholyshadow;
            if (s == "dualwarglaives") return CardDB.cardName.dualwarglaives;
            if (s == "sludgebelcher") return CardDB.cardName.sludgebelcher;
            if (s == "worthlessimp") return CardDB.cardName.worthlessimp;
            if (s == "shiv") return CardDB.cardName.shiv;
            if (s == "sheep") return CardDB.cardName.sheep;
            if (s == "bloodknight") return CardDB.cardName.bloodknight;
            if (s == "holysmite") return CardDB.cardName.holysmite;
            if (s == "ancientsecrets") return CardDB.cardName.ancientsecrets;
            if (s == "holywrath") return CardDB.cardName.holywrath;
            if (s == "ironforgerifleman") return CardDB.cardName.ironforgerifleman;
            if (s == "elitetaurenchieftain") return CardDB.cardName.elitetaurenchieftain;
            if (s == "spectralwarrior") return CardDB.cardName.spectralwarrior;
            if (s == "bluegillwarrior") return CardDB.cardName.bluegillwarrior;
            if (s == "shapeshift") return CardDB.cardName.shapeshift;
            if (s == "hamiltonchu") return CardDB.cardName.hamiltonchu;
            if (s == "battlerage") return CardDB.cardName.battlerage;
            if (s == "nightblade") return CardDB.cardName.nightblade;
            if (s == "locustswarm") return CardDB.cardName.locustswarm;
            if (s == "crazedhunter") return CardDB.cardName.crazedhunter;
            if (s == "andybrock") return CardDB.cardName.andybrock;
            if (s == "youthfulbrewmaster") return CardDB.cardName.youthfulbrewmaster;
            if (s == "theblackknight") return CardDB.cardName.theblackknight;
            if (s == "brewmaster") return CardDB.cardName.brewmaster;
            if (s == "lifetap") return CardDB.cardName.lifetap;
            if (s == "demonfire") return CardDB.cardName.demonfire;
            if (s == "redemption") return CardDB.cardName.redemption;
            if (s == "lordjaraxxus") return CardDB.cardName.lordjaraxxus;
            if (s == "coldblood") return CardDB.cardName.coldblood;
            if (s == "lightwarden") return CardDB.cardName.lightwarden;
            if (s == "questingadventurer") return CardDB.cardName.questingadventurer;
            if (s == "donothing") return CardDB.cardName.donothing;
            if (s == "dereksakamoto") return CardDB.cardName.dereksakamoto;
            if (s == "poultryizer") return CardDB.cardName.poultryizer;
            if (s == "koboldgeomancer") return CardDB.cardName.koboldgeomancer;
            if (s == "legacyoftheemperor") return CardDB.cardName.legacyoftheemperor;
            if (s == "eruption") return CardDB.cardName.eruption;
            if (s == "cenarius") return CardDB.cardName.cenarius;
            if (s == "deathlord") return CardDB.cardName.deathlord;
            if (s == "searingtotem") return CardDB.cardName.searingtotem;
            if (s == "taurenwarrior") return CardDB.cardName.taurenwarrior;
            if (s == "explosivetrap") return CardDB.cardName.explosivetrap;
            if (s == "frog") return CardDB.cardName.frog;
            if (s == "servercrash") return CardDB.cardName.servercrash;
            if (s == "wickedknife") return CardDB.cardName.wickedknife;
            if (s == "laughingsister") return CardDB.cardName.laughingsister;
            if (s == "cultmaster") return CardDB.cardName.cultmaster;
            if (s == "wildgrowth") return CardDB.cardName.wildgrowth;
            if (s == "sprint") return CardDB.cardName.sprint;
            if (s == "masterofdisguise") return CardDB.cardName.masterofdisguise;
            if (s == "kyleharrison") return CardDB.cardName.kyleharrison;
            if (s == "avatarofthecoin") return CardDB.cardName.avatarofthecoin;
            if (s == "excessmana") return CardDB.cardName.excessmana;
            if (s == "spiritwolf") return CardDB.cardName.spiritwolf;
            if (s == "auchenaisoulpriest") return CardDB.cardName.auchenaisoulpriest;
            if (s == "bestialwrath") return CardDB.cardName.bestialwrath;
            if (s == "rockbiterweapon") return CardDB.cardName.rockbiterweapon;
            if (s == "starvingbuzzard") return CardDB.cardName.starvingbuzzard;
            if (s == "mirrorimage") return CardDB.cardName.mirrorimage;
            if (s == "frozenchampion") return CardDB.cardName.frozenchampion;
            if (s == "silverhandrecruit") return CardDB.cardName.silverhandrecruit;
            if (s == "corruption") return CardDB.cardName.corruption;
            if (s == "preparation") return CardDB.cardName.preparation;
            if (s == "cairnebloodhoof") return CardDB.cardName.cairnebloodhoof;
            if (s == "mortalstrike") return CardDB.cardName.mortalstrike;
            if (s == "flare") return CardDB.cardName.flare;
            if (s == "necroknight") return CardDB.cardName.necroknight;
            if (s == "silverhandknight") return CardDB.cardName.silverhandknight;
            if (s == "breakweapon") return CardDB.cardName.breakweapon;
            if (s == "guardianofkings") return CardDB.cardName.guardianofkings;
            if (s == "ancientbrewmaster") return CardDB.cardName.ancientbrewmaster;
            if (s == "avenge") return CardDB.cardName.avenge;
            if (s == "youngdragonhawk") return CardDB.cardName.youngdragonhawk;
            if (s == "frostshock") return CardDB.cardName.frostshock;
            if (s == "healingtouch") return CardDB.cardName.healingtouch;
            if (s == "venturecomercenary") return CardDB.cardName.venturecomercenary;
            if (s == "unbalancingstrike") return CardDB.cardName.unbalancingstrike;
            if (s == "sacrificialpact") return CardDB.cardName.sacrificialpact;
            if (s == "noooooooooooo") return CardDB.cardName.noooooooooooo;
            if (s == "baneofdoom") return CardDB.cardName.baneofdoom;
            if (s == "abomination") return CardDB.cardName.abomination;
            if (s == "flesheatingghoul") return CardDB.cardName.flesheatingghoul;
            if (s == "loothoarder") return CardDB.cardName.loothoarder;
            if (s == "mill10") return CardDB.cardName.mill10;
            if (s == "sapphiron") return CardDB.cardName.sapphiron;
            if (s == "jasonchayes") return CardDB.cardName.jasonchayes;
            if (s == "benbrode") return CardDB.cardName.benbrode;
            if (s == "betrayal") return CardDB.cardName.betrayal;
            if (s == "thebeast") return CardDB.cardName.thebeast;
            if (s == "flameimp") return CardDB.cardName.flameimp;
            if (s == "freezingtrap") return CardDB.cardName.freezingtrap;
            if (s == "southseadeckhand") return CardDB.cardName.southseadeckhand;
            if (s == "wrath") return CardDB.cardName.wrath;
            if (s == "bloodfenraptor") return CardDB.cardName.bloodfenraptor;
            if (s == "cleave") return CardDB.cardName.cleave;
            if (s == "fencreeper") return CardDB.cardName.fencreeper;
            if (s == "restore1") return CardDB.cardName.restore1;
            if (s == "handtodeck") return CardDB.cardName.handtodeck;
            if (s == "starfire") return CardDB.cardName.starfire;
            if (s == "goldshirefootman") return CardDB.cardName.goldshirefootman;
            if (s == "unrelentingtrainee") return CardDB.cardName.unrelentingtrainee;
            if (s == "murlocscout") return CardDB.cardName.murlocscout;
            if (s == "ragnarosthefirelord") return CardDB.cardName.ragnarosthefirelord;
            if (s == "rampage") return CardDB.cardName.rampage;
            if (s == "zombiechow") return CardDB.cardName.zombiechow;
            if (s == "thrall") return CardDB.cardName.thrall;
            if (s == "stoneclawtotem") return CardDB.cardName.stoneclawtotem;
            if (s == "captainsparrot") return CardDB.cardName.captainsparrot;
            if (s == "windfuryharpy") return CardDB.cardName.windfuryharpy;
            if (s == "unrelentingwarrior") return CardDB.cardName.unrelentingwarrior;
            if (s == "stranglethorntiger") return CardDB.cardName.stranglethorntiger;
            if (s == "summonarandomsecret") return CardDB.cardName.summonarandomsecret;
            if (s == "circleofhealing") return CardDB.cardName.circleofhealing;
            if (s == "snaketrap") return CardDB.cardName.snaketrap;
            if (s == "cabalshadowpriest") return CardDB.cardName.cabalshadowpriest;
            if (s == "nerubarweblord") return CardDB.cardName.nerubarweblord;
            if (s == "upgrade") return CardDB.cardName.upgrade;
            if (s == "shieldslam") return CardDB.cardName.shieldslam;
            if (s == "flameburst") return CardDB.cardName.flameburst;
            if (s == "windfury") return CardDB.cardName.windfury;
            if (s == "enrage") return CardDB.cardName.enrage;
            if (s == "natpagle") return CardDB.cardName.natpagle;
            if (s == "restoreallhealth") return CardDB.cardName.restoreallhealth;
            if (s == "houndmaster") return CardDB.cardName.houndmaster;
            if (s == "waterelemental") return CardDB.cardName.waterelemental;
            if (s == "eaglehornbow") return CardDB.cardName.eaglehornbow;
            if (s == "gnoll") return CardDB.cardName.gnoll;
            if (s == "archmageantonidas") return CardDB.cardName.archmageantonidas;
            if (s == "destroyallheroes") return CardDB.cardName.destroyallheroes;
            if (s == "chains") return CardDB.cardName.chains;
            if (s == "wrathofairtotem") return CardDB.cardName.wrathofairtotem;
            if (s == "killcommand") return CardDB.cardName.killcommand;
            if (s == "manatidetotem") return CardDB.cardName.manatidetotem;
            if (s == "daggermastery") return CardDB.cardName.daggermastery;
            if (s == "drainlife") return CardDB.cardName.drainlife;
            if (s == "doomsayer") return CardDB.cardName.doomsayer;
            if (s == "darkscalehealer") return CardDB.cardName.darkscalehealer;
            if (s == "shadowform") return CardDB.cardName.shadowform;
            if (s == "frostnova") return CardDB.cardName.frostnova;
            if (s == "purecold") return CardDB.cardName.purecold;
            if (s == "mirrorentity") return CardDB.cardName.mirrorentity;
            if (s == "counterspell") return CardDB.cardName.counterspell;
            if (s == "mindshatter") return CardDB.cardName.mindshatter;
            if (s == "magmarager") return CardDB.cardName.magmarager;
            if (s == "wolfrider") return CardDB.cardName.wolfrider;
            if (s == "emboldener3000") return CardDB.cardName.emboldener3000;
            if (s == "polarityshift") return CardDB.cardName.polarityshift;
            if (s == "gelbinmekkatorque") return CardDB.cardName.gelbinmekkatorque;
            if (s == "webspinner") return CardDB.cardName.webspinner;
            if (s == "utherlightbringer") return CardDB.cardName.utherlightbringer;
            if (s == "innerrage") return CardDB.cardName.innerrage;
            if (s == "emeralddrake") return CardDB.cardName.emeralddrake;
            if (s == "forceaitouseheropower") return CardDB.cardName.forceaitouseheropower;
            if (s == "echoingooze") return CardDB.cardName.echoingooze;
            if (s == "heroicstrike") return CardDB.cardName.heroicstrike;
            if (s == "hauntedcreeper") return CardDB.cardName.hauntedcreeper;
            if (s == "barreltoss") return CardDB.cardName.barreltoss;
            if (s == "yongwoo") return CardDB.cardName.yongwoo;
            if (s == "doomhammer") return CardDB.cardName.doomhammer;
            if (s == "stomp") return CardDB.cardName.stomp;
            if (s == "spectralknight") return CardDB.cardName.spectralknight;
            if (s == "tracking") return CardDB.cardName.tracking;
            if (s == "fireball") return CardDB.cardName.fireball;
            if (s == "thecoin") return CardDB.cardName.thecoin;
            if (s == "bootybaybodyguard") return CardDB.cardName.bootybaybodyguard;
            if (s == "scarletcrusader") return CardDB.cardName.scarletcrusader;
            if (s == "voodoodoctor") return CardDB.cardName.voodoodoctor;
            if (s == "shadowbolt") return CardDB.cardName.shadowbolt;
            if (s == "etherealarcanist") return CardDB.cardName.etherealarcanist;
            if (s == "succubus") return CardDB.cardName.succubus;
            if (s == "emperorcobra") return CardDB.cardName.emperorcobra;
            if (s == "deadlyshot") return CardDB.cardName.deadlyshot;
            if (s == "reinforce") return CardDB.cardName.reinforce;
            if (s == "supercharge") return CardDB.cardName.supercharge;
            if (s == "claw") return CardDB.cardName.claw;
            if (s == "explosiveshot") return CardDB.cardName.explosiveshot;
            if (s == "avengingwrath") return CardDB.cardName.avengingwrath;
            if (s == "riverpawgnoll") return CardDB.cardName.riverpawgnoll;
            if (s == "sirzeliek") return CardDB.cardName.sirzeliek;
            if (s == "argentprotector") return CardDB.cardName.argentprotector;
            if (s == "hiddengnome") return CardDB.cardName.hiddengnome;
            if (s == "felguard") return CardDB.cardName.felguard;
            if (s == "northshirecleric") return CardDB.cardName.northshirecleric;
            if (s == "plague") return CardDB.cardName.plague;
            if (s == "lepergnome") return CardDB.cardName.lepergnome;
            if (s == "fireelemental") return CardDB.cardName.fireelemental;
            if (s == "armorup") return CardDB.cardName.armorup;
            if (s == "snipe") return CardDB.cardName.snipe;
            if (s == "southseacaptain") return CardDB.cardName.southseacaptain;
            if (s == "catform") return CardDB.cardName.catform;
            if (s == "bite") return CardDB.cardName.bite;
            if (s == "defiasringleader") return CardDB.cardName.defiasringleader;
            if (s == "harvestgolem") return CardDB.cardName.harvestgolem;
            if (s == "kingkrush") return CardDB.cardName.kingkrush;
            if (s == "aibuddydamageownhero5") return CardDB.cardName.aibuddydamageownhero5;
            if (s == "healingtotem") return CardDB.cardName.healingtotem;
            if (s == "ericdodds") return CardDB.cardName.ericdodds;
            if (s == "demigodsfavor") return CardDB.cardName.demigodsfavor;
            if (s == "huntersmark") return CardDB.cardName.huntersmark;
            if (s == "dalaranmage") return CardDB.cardName.dalaranmage;
            if (s == "twilightdrake") return CardDB.cardName.twilightdrake;
            if (s == "coldlightoracle") return CardDB.cardName.coldlightoracle;
            if (s == "shadeofnaxxramas") return CardDB.cardName.shadeofnaxxramas;
            if (s == "moltengiant") return CardDB.cardName.moltengiant;
            if (s == "deathbloom") return CardDB.cardName.deathbloom;
            if (s == "shadowflame") return CardDB.cardName.shadowflame;
            if (s == "anduinwrynn") return CardDB.cardName.anduinwrynn;
            if (s == "argentcommander") return CardDB.cardName.argentcommander;
            if (s == "revealhand") return CardDB.cardName.revealhand;
            if (s == "arcanemissiles") return CardDB.cardName.arcanemissiles;
            if (s == "repairbot") return CardDB.cardName.repairbot;
            if (s == "unstableghoul") return CardDB.cardName.unstableghoul;
            if (s == "ancientofwar") return CardDB.cardName.ancientofwar;
            if (s == "stormwindchampion") return CardDB.cardName.stormwindchampion;
            if (s == "summonapanther") return CardDB.cardName.summonapanther;
            if (s == "mrbigglesworth") return CardDB.cardName.mrbigglesworth;
            if (s == "swipe") return CardDB.cardName.swipe;
            if (s == "aihelperbuddy") return CardDB.cardName.aihelperbuddy;
            if (s == "hex") return CardDB.cardName.hex;
            if (s == "ysera") return CardDB.cardName.ysera;
            if (s == "arcanegolem") return CardDB.cardName.arcanegolem;
            if (s == "bloodimp") return CardDB.cardName.bloodimp;
            if (s == "pyroblast") return CardDB.cardName.pyroblast;
            if (s == "murlocraider") return CardDB.cardName.murlocraider;
            if (s == "faeriedragon") return CardDB.cardName.faeriedragon;
            if (s == "sinisterstrike") return CardDB.cardName.sinisterstrike;
            if (s == "poweroverwhelming") return CardDB.cardName.poweroverwhelming;
            if (s == "arcaneexplosion") return CardDB.cardName.arcaneexplosion;
            if (s == "shadowwordpain") return CardDB.cardName.shadowwordpain;
            if (s == "mill30") return CardDB.cardName.mill30;
            if (s == "noblesacrifice") return CardDB.cardName.noblesacrifice;
            if (s == "dreadinfernal") return CardDB.cardName.dreadinfernal;
            if (s == "naturalize") return CardDB.cardName.naturalize;
            if (s == "totemiccall") return CardDB.cardName.totemiccall;
            if (s == "secretkeeper") return CardDB.cardName.secretkeeper;
            if (s == "dreadcorsair") return CardDB.cardName.dreadcorsair;
            if (s == "jaws") return CardDB.cardName.jaws;
            if (s == "forkedlightning") return CardDB.cardName.forkedlightning;
            if (s == "reincarnate") return CardDB.cardName.reincarnate;
            if (s == "handofprotection") return CardDB.cardName.handofprotection;
            if (s == "noththeplaguebringer") return CardDB.cardName.noththeplaguebringer;
            if (s == "vaporize") return CardDB.cardName.vaporize;
            if (s == "frostbreath") return CardDB.cardName.frostbreath;
            if (s == "nozdormu") return CardDB.cardName.nozdormu;
            if (s == "divinespirit") return CardDB.cardName.divinespirit;
            if (s == "transcendence") return CardDB.cardName.transcendence;
            if (s == "armorsmith") return CardDB.cardName.armorsmith;
            if (s == "murloctidehunter") return CardDB.cardName.murloctidehunter;
            if (s == "stealcard") return CardDB.cardName.stealcard;
            if (s == "opponentconcede") return CardDB.cardName.opponentconcede;
            if (s == "tundrarhino") return CardDB.cardName.tundrarhino;
            if (s == "summoningportal") return CardDB.cardName.summoningportal;
            if (s == "hammerofwrath") return CardDB.cardName.hammerofwrath;
            if (s == "stormwindknight") return CardDB.cardName.stormwindknight;
            if (s == "freeze") return CardDB.cardName.freeze;
            if (s == "madbomber") return CardDB.cardName.madbomber;
            if (s == "consecration") return CardDB.cardName.consecration;
            if (s == "spectraltrainee") return CardDB.cardName.spectraltrainee;
            if (s == "boar") return CardDB.cardName.boar;
            if (s == "knifejuggler") return CardDB.cardName.knifejuggler;
            if (s == "icebarrier") return CardDB.cardName.icebarrier;
            if (s == "mechanicaldragonling") return CardDB.cardName.mechanicaldragonling;
            if (s == "battleaxe") return CardDB.cardName.battleaxe;
            if (s == "lightsjustice") return CardDB.cardName.lightsjustice;
            if (s == "lavaburst") return CardDB.cardName.lavaburst;
            if (s == "mindcontroltech") return CardDB.cardName.mindcontroltech;
            if (s == "boulderfistogre") return CardDB.cardName.boulderfistogre;
            if (s == "fireblast") return CardDB.cardName.fireblast;
            if (s == "priestessofelune") return CardDB.cardName.priestessofelune;
            if (s == "ancientmage") return CardDB.cardName.ancientmage;
            if (s == "shadowworddeath") return CardDB.cardName.shadowworddeath;
            if (s == "ironbeakowl") return CardDB.cardName.ironbeakowl;
            if (s == "eviscerate") return CardDB.cardName.eviscerate;
            if (s == "repentance") return CardDB.cardName.repentance;
            if (s == "understudy") return CardDB.cardName.understudy;
            if (s == "sunwalker") return CardDB.cardName.sunwalker;
            if (s == "nagamyrmidon") return CardDB.cardName.nagamyrmidon;
            if (s == "destroyheropower") return CardDB.cardName.destroyheropower;
            if (s == "skeletalsmith") return CardDB.cardName.skeletalsmith;
            if (s == "slam") return CardDB.cardName.slam;
            if (s == "swordofjustice") return CardDB.cardName.swordofjustice;
            if (s == "bounce") return CardDB.cardName.bounce;
            if (s == "shadopanmonk") return CardDB.cardName.shadopanmonk;
            if (s == "whirlwind") return CardDB.cardName.whirlwind;
            if (s == "alexstrasza") return CardDB.cardName.alexstrasza;
            if (s == "silence") return CardDB.cardName.silence;
            if (s == "rexxar") return CardDB.cardName.rexxar;
            if (s == "voidwalker") return CardDB.cardName.voidwalker;
            if (s == "whelp") return CardDB.cardName.whelp;
            if (s == "flamestrike") return CardDB.cardName.flamestrike;
            if (s == "rivercrocolisk") return CardDB.cardName.rivercrocolisk;
            if (s == "stormforgedaxe") return CardDB.cardName.stormforgedaxe;
            if (s == "snake") return CardDB.cardName.snake;
            if (s == "shotgunblast") return CardDB.cardName.shotgunblast;
            if (s == "violetapprentice") return CardDB.cardName.violetapprentice;
            if (s == "templeenforcer") return CardDB.cardName.templeenforcer;
            if (s == "ashbringer") return CardDB.cardName.ashbringer;
            if (s == "impmaster") return CardDB.cardName.impmaster;
            if (s == "defender") return CardDB.cardName.defender;
            if (s == "savageroar") return CardDB.cardName.savageroar;
            if (s == "innervate") return CardDB.cardName.innervate;
            if (s == "inferno") return CardDB.cardName.inferno;
            if (s == "falloutslime") return CardDB.cardName.falloutslime;
            if (s == "earthelemental") return CardDB.cardName.earthelemental;
            if (s == "facelessmanipulator") return CardDB.cardName.facelessmanipulator;
            if (s == "mindpocalypse") return CardDB.cardName.mindpocalypse;
            if (s == "divinefavor") return CardDB.cardName.divinefavor;
            if (s == "aibuddydestroyminions") return CardDB.cardName.aibuddydestroyminions;
            if (s == "demolisher") return CardDB.cardName.demolisher;
            if (s == "sunfuryprotector") return CardDB.cardName.sunfuryprotector;
            if (s == "dustdevil") return CardDB.cardName.dustdevil;
            if (s == "powerofthehorde") return CardDB.cardName.powerofthehorde;
            if (s == "dancingswords") return CardDB.cardName.dancingswords;
            if (s == "holylight") return CardDB.cardName.holylight;
            if (s == "feralspirit") return CardDB.cardName.feralspirit;
            if (s == "raidleader") return CardDB.cardName.raidleader;
            if (s == "amaniberserker") return CardDB.cardName.amaniberserker;
            if (s == "ironbarkprotector") return CardDB.cardName.ironbarkprotector;
            if (s == "bearform") return CardDB.cardName.bearform;
            if (s == "deathwing") return CardDB.cardName.deathwing;
            if (s == "stormpikecommando") return CardDB.cardName.stormpikecommando;
            if (s == "squire") return CardDB.cardName.squire;
            if (s == "panther") return CardDB.cardName.panther;
            if (s == "silverbackpatriarch") return CardDB.cardName.silverbackpatriarch;
            if (s == "bobfitch") return CardDB.cardName.bobfitch;
            if (s == "gladiatorslongbow") return CardDB.cardName.gladiatorslongbow;
            if (s == "damage1") return CardDB.cardName.damage1;
            return CardDB.cardName.unknown;
        }

        public enum ErrorType2
        {
            NONE,//=0
            REQ_MINION_TARGET,//=1
            REQ_FRIENDLY_TARGET,//=2
            REQ_ENEMY_TARGET,//=3
            REQ_DAMAGED_TARGET,//=4
            REQ_ENCHANTED_TARGET,
            REQ_FROZEN_TARGET,
            REQ_CHARGE_TARGET,
            REQ_TARGET_MAX_ATTACK,//=8
            REQ_NONSELF_TARGET,//=9
            REQ_TARGET_WITH_RACE,//=10
            REQ_TARGET_TO_PLAY,//=11 
            REQ_NUM_MINION_SLOTS,//=12 
            REQ_WEAPON_EQUIPPED,//=13
            REQ_ENOUGH_MANA,//=14
            REQ_YOUR_TURN,
            REQ_NONSTEALTH_ENEMY_TARGET,
            REQ_HERO_TARGET,//17
            REQ_SECRET_CAP,
            REQ_MINION_CAP_IF_TARGET_AVAILABLE,//19
            REQ_MINION_CAP,
            REQ_TARGET_ATTACKED_THIS_TURN,
            REQ_TARGET_IF_AVAILABLE,//=22
            REQ_MINIMUM_ENEMY_MINIONS,//=23 /like spalen :D
            REQ_TARGET_FOR_COMBO,//=24
            REQ_NOT_EXHAUSTED_ACTIVATE,
            REQ_UNIQUE_SECRET,
            REQ_TARGET_TAUNTER,
            REQ_CAN_BE_ATTACKED,
            REQ_ACTION_PWR_IS_MASTER_PWR,
            REQ_TARGET_MAGNET,
            REQ_ATTACK_GREATER_THAN_0,
            REQ_ATTACKER_NOT_FROZEN,
            REQ_HERO_OR_MINION_TARGET,
            REQ_CAN_BE_TARGETED_BY_SPELLS,
            REQ_SUBCARD_IS_PLAYABLE,
            REQ_TARGET_FOR_NO_COMBO,
            REQ_NOT_MINION_JUST_PLAYED,
            REQ_NOT_EXHAUSTED_HERO_POWER,
            REQ_CAN_BE_TARGETED_BY_OPPONENTS,
            REQ_ATTACKER_CAN_ATTACK,
            REQ_TARGET_MIN_ATTACK,//=41
            REQ_CAN_BE_TARGETED_BY_HERO_POWERS,
            REQ_ENEMY_TARGET_NOT_IMMUNE,
            REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY,//44 (totemic call)
            REQ_MINIMUM_TOTAL_MINIONS,//45 (scharmuetzel)
            REQ_MUST_TARGET_TAUNTER,//=46
            REQ_UNDAMAGED_TARGET//=47
        }

        public class Card
        {
            //public string CardID = "";
            public cardName name = cardName.unknown;
            public int race = 0;
            public int rarity = 0;
            public int cost = 0;
            public int crdtype = 0;
            public cardtype type = CardDB.cardtype.NONE;
            //public string description = "";
            public int carddraw = 0;

            public bool hasEffect = false;// has the minion an effect, but not battlecry

            public int Attack = 0;
            public int Health = 0;
            public int Durability = 0;//for weapons
            public bool target = false;
            //public string targettext = "";
            public bool tank = false;
            public bool Silence = false;
            public bool choice = false;
            public bool windfury = false;
            public bool poisionous = false;
            public bool deathrattle = false;
            public bool battlecry = false;
            public bool oneTurnEffect = false;
            public bool Enrage = false;
            public bool Aura = false;
            public bool Elite = false;
            public bool Combo = false;
            public bool Recall = false;
            public int recallValue = 0;
            public bool immuneWhileAttacking = false;
            public bool immuneToSpellpowerg = false;
            public bool Stealth = false;
            public bool Freeze = false;
            public bool AdjacentBuff = false;
            public bool Shield = false;
            public bool Charge = false;
            public bool Secret = false;
            public bool Morph = false;
            public bool Spellpower = false;
            public bool GrantCharge = false;
            public bool HealTarget = false;
            //playRequirements, reqID= siehe PlayErrors->ErrorType
            public int needEmptyPlacesForPlaying = 0;
            public int needWithMinAttackValueOf = 0;
            public int needWithMaxAttackValueOf = 0;
            public int needRaceForPlaying = 0;
            public int needMinNumberOfEnemy = 0;
            public int needMinTotalMinions = 0;
            public int needMinionsCapIfAvailable = 0;

            public int spellpowervalue = 0;
            public cardIDEnum cardIDenum = cardIDEnum.None;
            public List<ErrorType2> playrequires;


            public Card()
            {
                playrequires = new List<ErrorType2>();
            }

            public Card(Card c)
            {
                //this.entityID = c.entityID;
                this.hasEffect = c.hasEffect;
                this.rarity = c.rarity;
                this.AdjacentBuff = c.AdjacentBuff;
                this.Attack = c.Attack;
                this.Aura = c.Aura;
                this.battlecry = c.battlecry;
                this.carddraw = c.carddraw;
                //this.CardID = c.CardID;
                this.Charge = c.Charge;
                this.choice = c.choice;
                this.Combo = c.Combo;
                this.cost = c.cost;
                this.crdtype = c.crdtype;
                this.deathrattle = c.deathrattle;
                //this.description = c.description;
                this.Durability = c.Durability;
                this.Elite = c.Elite;
                this.Enrage = c.Enrage;
                this.Freeze = c.Freeze;
                this.GrantCharge = c.GrantCharge;
                this.HealTarget = c.HealTarget;
                this.Health = c.Health;
                this.immuneToSpellpowerg = c.immuneToSpellpowerg;
                this.immuneWhileAttacking = c.immuneWhileAttacking;
                this.Morph = c.Morph;
                this.name = c.name;
                this.needEmptyPlacesForPlaying = c.needEmptyPlacesForPlaying;
                this.needMinionsCapIfAvailable = c.needMinionsCapIfAvailable;
                this.needMinNumberOfEnemy = c.needMinNumberOfEnemy;
                this.needMinTotalMinions = c.needMinTotalMinions;
                this.needRaceForPlaying = c.needRaceForPlaying;
                this.needWithMaxAttackValueOf = c.needWithMaxAttackValueOf;
                this.needWithMinAttackValueOf = c.needWithMinAttackValueOf;
                this.oneTurnEffect = c.oneTurnEffect;
                this.playrequires = new List<ErrorType2>(c.playrequires);
                this.poisionous = c.poisionous;
                this.race = c.race;
                this.Recall = c.Recall;
                this.recallValue = c.recallValue;
                this.Secret = c.Secret;
                this.Shield = c.Shield;
                this.Silence = c.Silence;
                this.Spellpower = c.Spellpower;
                this.spellpowervalue = c.spellpowervalue;
                this.Stealth = c.Stealth;
                this.tank = c.tank;
                this.target = c.target;
                //this.targettext = c.targettext;
                this.type = c.type;
                this.windfury = c.windfury;
                this.cardIDenum = c.cardIDenum;
            }

            public bool isRequirementInList(CardDB.ErrorType2 et)
            {
                if (this.playrequires.Contains(et)) return true;
                return false;
            }

            public List<targett> getTargetsForCard(Playfield p)
            {
                List<targett> retval = new List<targett>();

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0) return retval;

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    retval.Add(new targett(100, p.ownHeroEntity));//ownhero
                    retval.Add(new targett(200, p.enemyHeroEntity));//enemyhero
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister)) continue;
                        retval.Add(new targett(m.id, m.entitiyID));
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister)) || m.stealth) continue;
                        retval.Add(new targett(m.id + 10, m.entitiyID));
                    }

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_HERO_TARGET))
                {
                    retval.RemoveAll(x => (x.target <= 30));
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINION_TARGET))
                {
                    retval.RemoveAll(x => (x.target == 100) || (x.target == 200));
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    retval.RemoveAll(x => (x.target >= 10 && x.target <= 20) || (x.target == 200));
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENEMY_TARGET))
                {
                    retval.RemoveAll(x => (x.target <= 9 || (x.target == 100)));
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_DAMAGED_TARGET))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (!m.wounded)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (!m.wounded)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.wounded)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.wounded)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    retval.RemoveAll(x => (x.target == 100) || (x.target == 200));
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (!m.taunt)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (!m.taunt)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }
                return retval;

            }


            public List<targett> getTargetsForCardEnemy(Playfield p)
            {
                List<targett> retval = new List<targett>();

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0) return retval;

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    retval.Add(new targett(100, p.ownHeroEntity));//ownhero
                    retval.Add(new targett(200, p.enemyHeroEntity));//enemyhero
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister)) || m.stealth) continue;
                        retval.Add(new targett(m.id, m.entitiyID));
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister))) continue;
                        retval.Add(new targett(m.id + 10, m.entitiyID));
                    }

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_HERO_TARGET))
                {
                    retval.RemoveAll(x => (x.target <= 30));
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINION_TARGET))
                {
                    retval.RemoveAll(x => (x.target == 100) || (x.target == 200));
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    retval.RemoveAll(x => (x.target <= 9 || (x.target == 100)));
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENEMY_TARGET))
                {
                    retval.RemoveAll(x => (x.target >= 10 && x.target <= 20) || (x.target == 200));
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_DAMAGED_TARGET))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (!m.wounded)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (!m.wounded)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.wounded)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.wounded)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    retval.RemoveAll(x => (x.target == 100) || (x.target == 200));
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.id == -1) continue;
                        if (!m.taunt)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.id == -1) continue;
                        if (!m.taunt)
                        {
                            retval.RemoveAll(x => x.targetEntity == m.entitiyID);
                        }
                    }
                }
                return retval;

            }

            public int calculateManaCost(Playfield p)//calculates the mana from orginal mana, needed for back-to hand effects
            {
                int retval = this.cost;
                int offset = 0;

                if (this.type == cardtype.MOB)
                {
                    offset += (p.soeldnerDerVenture) * 3;

                    offset += (p.managespenst);

                    int temp = -(p.startedWithbeschwoerungsportal) * 2;
                    if (retval + temp <= 0) temp = -retval + 1;
                    offset = offset + temp;

                    if (p.mobsplayedThisTurn == 0)
                    {
                        offset -= p.winzigebeschwoererin;
                    }

                }

                if (this.type == cardtype.SPELL)
                { //if the number of zauberlehrlings change
                    offset -= (p.zauberlehrling);
                    if (p.playedPreparation)
                    { //if the number of zauberlehrlings change
                        offset -= 3;
                    }

                }

                switch (this.name)
                {
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack;
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHeroHp;
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && p.playedmagierinderkirintor)
                {
                    retval = 0;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public int getManaCost(Playfield p, int currentcost)//calculates mana from current mana
            {
                int retval = currentcost;


                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase the manacosts of others ##############################
                //Manacosts changes with soeldner der venture co.
                if (p.soeldnerDerVenture != p.startedWithsoeldnerDerVenture && this.type == cardtype.MOB)
                {
                    offset += (p.soeldnerDerVenture - p.startedWithsoeldnerDerVenture) * 3;
                }

                //Manacosts changes with mana-ghost
                if (p.managespenst != p.startedWithManagespenst && this.type == cardtype.MOB)
                {
                    offset += (p.managespenst - p.startedWithManagespenst);
                }


                // CARDS that decrease the manacosts of others ##############################

                //Manacosts changes with the summoning-portal >_>
                if (p.startedWithbeschwoerungsportal != p.beschwoerungsportal && this.type == cardtype.MOB)
                { //cant lower the mana to 0
                    int temp = (p.startedWithbeschwoerungsportal - p.beschwoerungsportal) * 2;
                    if (retval + temp <= 0) temp = -retval + 1;
                    offset = offset + temp;
                }

                //Manacosts changes with the pint-sized summoner
                if (p.winzigebeschwoererin >= 1 && p.mobsplayedThisTurn >= 1 && p.startedWithMobsPlayedThisTurn == 0 && this.type == cardtype.MOB)
                { // if we start oure calculations with 0 mobs played, then the cardcost are 1 mana to low in the further calculations (with the little summoner on field)
                    offset += p.winzigebeschwoererin;
                }
                if (p.mobsplayedThisTurn == 0 && p.winzigebeschwoererin <= p.startedWithWinzigebeschwoererin && this.type == cardtype.MOB)
                { // one pint-sized summoner got killed, before we played the first mob -> the manacost are higher of all mobs
                    offset += (p.startedWithWinzigebeschwoererin - p.winzigebeschwoererin);
                }

                //Manacosts changes with the zauberlehrling summoner
                if (p.zauberlehrling != p.startedWithZauberlehrling && this.type == cardtype.SPELL)
                { //if the number of zauberlehrlings change
                    offset += (p.startedWithZauberlehrling - p.zauberlehrling);
                }



                //manacosts are lowered, after we played preparation
                if (p.playedPreparation && this.type == cardtype.SPELL)
                { //if the number of zauberlehrlings change
                    offset -= 3;
                }





                switch (this.name)
                {
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack + p.ownWeaponAttackStarted; // if weapon attack change we change manacost
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count + p.ownCardsCountStarted;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHeroHp + p.ownHeroHpStarted;
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && p.playedmagierinderkirintor)
                {
                    retval = 0;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public bool canplayCard(Playfield p, int manacost)
            {
                //is playrequirement?
                bool haveToDoRequires = isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY);
                bool retval = true;
                // cant play if i have to few mana

                if (p.mana < this.getManaCost(p, manacost)) return false;

                // cant play mob, if i have allready 7 mininos
                if (this.type == CardDB.cardtype.MOB && p.ownMinions.Count >= 7) return false;

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINIMUM_ENEMY_MINIONS))
                {
                    if (p.enemyMinions.Count < this.needMinNumberOfEnemy) return false;
                }
                if (isRequirementInList(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS))
                {
                    if (p.ownMinions.Count > 7 - this.needEmptyPlacesForPlaying) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_WEAPON_EQUIPPED))
                {
                    if (p.ownWeaponName == CardDB.cardName.unknown) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINIMUM_TOTAL_MINIONS))
                {
                    if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count) return false;
                }

                if (haveToDoRequires)
                {
                    if (this.getTargetsForCard(p).Count == 0) return false;

                    //it requires a target-> return false if 
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) && isRequirementInList(CardDB.ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE))
                {
                    if (this.getTargetsForCard(p).Count >= 1 && p.ownMinions.Count > 7 - this.needMinionsCapIfAvailable) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY))
                {
                    int difftotem = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.name == CardDB.cardName.healingtotem || m.name == CardDB.cardName.wrathofairtotem || m.name == CardDB.cardName.searingtotem || m.name == CardDB.cardName.stoneclawtotem) difftotem++;
                    }
                    if (difftotem == 4) return false;
                }


                if (this.Secret)
                {
                    if (p.ownSecretsIDList.Contains(this.cardIDenum)) return false;
                    if (p.ownSecretsIDList.Count >= 5) return false;
                }


                return true;
            }



        }

        List<string> namelist = new List<string>();
        List<Card> cardlist = new List<Card>();
        Dictionary<cardIDEnum, Card> cardidToCardList = new Dictionary<cardIDEnum, Card>();
        List<string> allCardIDS = new List<string>();
        public Card unknownCard;

        private static CardDB instance;

        public static CardDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardDB();
                    //instance.enumCreator();// only call this to get latest cardids
                    /*foreach (KeyValuePair<cardIDEnum, Card> kvp in instance.cardidToCardList)
                    {
                        Helpfunctions.Instance.logg(kvp.Value.name + " " + kvp.Value.Attack);
                    }*/
                }
                return instance;
            }
        }

        private CardDB()
        {
            string[] lines = new string[0] { };
            try
            {
                string path = Settings.Instance.path;
                lines = System.IO.File.ReadAllLines(path + "_carddb.txt");
                Helpfunctions.Instance.ErrorLog("read carddb.txt");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find _carddb.txt");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("cant find _carddb.txt");
            }
            cardlist.Clear();
            this.cardidToCardList.Clear();
            Card c = new Card();
            int de = 0;
            //placeholdercard
            Card plchldr = new Card();
            plchldr.name = CardDB.cardName.unknown;
            plchldr.cost = 1000;
            this.namelist.Add("unknown");
            this.cardlist.Add(plchldr);
            this.unknownCard = cardlist[0];
            string name = "";
            foreach (string s in lines)
            {
                if (s.Contains("/Entity"))
                {
                    if (c.type == cardtype.ENCHANTMENT)
                    {
                        //Helpfunctions.Instance.logg(c.CardID);
                        //Helpfunctions.Instance.logg(c.name);
                        //Helpfunctions.Instance.logg(c.description);
                        continue;
                    }
                    if (name != "")
                    {
                        this.namelist.Add(name);
                    }
                    name = "";
                    if (c.name != CardDB.cardName.unknown)
                    {
                        this.cardlist.Add(c);
                        //Helpfunctions.Instance.logg(c.name);

                        if (!this.cardidToCardList.ContainsKey(c.cardIDenum))
                        {
                            this.cardidToCardList.Add(c.cardIDenum, c);
                        }
                    }

                }
                if (s.Contains("<Entity version=\"") && s.Contains(" CardID=\""))
                {
                    c = new Card();
                    de = 0;
                    string temp = s.Split(new string[] { "CardID=\"" }, StringSplitOptions.None)[1];
                    temp = temp.Replace("\">", "");
                    //c.CardID = temp;
                    allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);
                    continue;
                }
                /*
                if (s.Contains("<Entity version=\"1\" CardID=\""))
                {
                    c = new Card();
                    de = 0;
                    string temp = s.Replace("<Entity version=\"1\" CardID=\"", "");
                    temp = temp.Replace("\">", "");
                    //c.CardID = temp;
                    allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);
                    continue;
                }*/

                if (s.Contains("<Tag name=\"Health\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Health = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Atk\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Attack = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Race\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.race = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Rarity\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.rarity = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Cost\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.cost = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"CardType\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    if (c.name != CardDB.cardName.unknown)
                    {
                        //Helpfunctions.Instance.logg(temp);
                    }

                    c.crdtype = Convert.ToInt32(temp);
                    if (c.crdtype == 10)
                    {
                        c.type = CardDB.cardtype.HEROPWR;
                    }
                    if (c.crdtype == 4)
                    {
                        c.type = CardDB.cardtype.MOB;
                    }
                    if (c.crdtype == 5)
                    {
                        c.type = CardDB.cardtype.SPELL;
                    }
                    if (c.crdtype == 6)
                    {
                        c.type = CardDB.cardtype.ENCHANTMENT;
                    }
                    if (c.crdtype == 7)
                    {
                        c.type = CardDB.cardtype.WEAPON;
                    }
                    continue;
                }

                if (s.Contains("<Tag name=\"CardName\" "))
                {
                    de = 0;
                    continue;
                }
                if (s.Contains("<Tag name=\"CardTextInHand\" "))
                {
                    de = 1;
                    continue;
                }
                if (s.Contains("<Tag name=\"TargetingArrowText\" "))
                {
                    c.target = true;
                    de = 2;
                    continue;
                }

                if (s.Contains("<enUS>"))
                {
                    string temp = s.Replace("<enUS>", "");

                    temp = temp.Replace("</enUS>", "");
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower();
                    if (de == 0)
                    {
                        temp = temp.Replace("'", "");
                        temp = temp.Replace(" ", "");
                        temp = temp.Replace(":", "");
                        temp = temp.Replace(".", "");
                        temp = temp.Replace("!", "");
                        temp = temp.Replace("-", "");
                        //temp = temp.Replace("ß", "ss");
                        //temp = temp.Replace("ü", "ue");
                        //temp = temp.Replace("ä", "ae");
                        //temp = temp.Replace("ö", "oe");

                        //Helpfunctions.Instance.logg(temp);
                        c.name = this.cardNamestringToEnum(temp);
                        name = temp;
                        if (PenalityManager.Instance.specialMinions.ContainsKey(this.cardNamestringToEnum(temp))) c.hasEffect = true;

                    }
                    if (de == 1)
                    {
                        //c.description = temp;
                        //if (c.description.Contains("choose one"))
                        if (temp.Contains("choose one"))
                        {
                            c.choice = true;
                            //Helpfunctions.Instance.logg(c.name + " is choice");
                        }
                    }
                    if (de == 2)
                    {
                        //c.targettext = temp;
                    }
                    de = -1;
                    continue;
                }
                if (s.Contains("<Tag name=\"Poisonous\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.poisionous = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Enrage\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Enrage = true;
                    continue;
                }

                if (s.Contains("<Tag name=\"OneTurnEffect\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.oneTurnEffect = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Aura\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Aura = true;
                    continue;
                }


                if (s.Contains("<Tag name=\"Taunt\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.tank = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Battlecry\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.battlecry = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Windfury\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.windfury = true;
                    continue;
                }

                if (s.Contains("<Tag name=\"Deathrattle\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.deathrattle = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Durability\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Durability = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Elite\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Elite = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Combo\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Combo = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Recall\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Recall = true;
                    c.recallValue = 1;
                    if (c.name == CardDB.cardName.forkedlightning) c.recallValue = 2;
                    if (c.name == CardDB.cardName.dustdevil) c.recallValue = 2;
                    if (c.name == CardDB.cardName.lightningstorm) c.recallValue = 2;
                    if (c.name == CardDB.cardName.lavaburst) c.recallValue = 2;
                    if (c.name == CardDB.cardName.feralspirit) c.recallValue = 2;
                    if (c.name == CardDB.cardName.doomhammer) c.recallValue = 2;
                    if (c.name == CardDB.cardName.earthelemental) c.recallValue = 3;
                    continue;
                }

                if (s.Contains("<Tag name=\"ImmuneToSpellpower\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.immuneToSpellpowerg = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Stealth\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Stealth = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Secret\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Secret = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Freeze\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Freeze = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"AdjacentBuff\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.AdjacentBuff = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Divine Shield\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Shield = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Charge\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Charge = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Silence\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Silence = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Morph\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Morph = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Spellpower\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Spellpower = true;
                    c.spellpowervalue = 1;
                    if (c.name == CardDB.cardName.ancientmage) c.spellpowervalue = 0;
                    if (c.name == CardDB.cardName.malygos) c.spellpowervalue = 5;
                    continue;
                }
                if (s.Contains("<Tag name=\"GrantCharge\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.GrantCharge = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"HealTarget\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.HealTarget = true;
                    continue;
                }
                if (s.Contains("<PlayRequirement"))
                {
                    string temp = s.Split(new string[] { "reqID=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    ErrorType2 et2 = (ErrorType2)Convert.ToInt32(temp);
                    c.playrequires.Add(et2);
                }


                if (s.Contains("<PlayRequirement reqID=\"12\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needEmptyPlacesForPlaying = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"41\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMinAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"8\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMaxAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"10\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needRaceForPlaying = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"23\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinNumberOfEnemy = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"45\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinTotalMinions = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"19\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinionsCapIfAvailable = Convert.ToInt32(temp);
                    continue;
                }



                if (s.Contains("<Tag name="))
                {
                    string temp = s.Split(new string[] { "<Tag name=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    /*
                    if (temp != "DevState" && temp != "FlavorText" && temp != "ArtistName" && temp != "Cost" && temp != "EnchantmentIdleVisual" && temp != "EnchantmentBirthVisual" && temp != "Collectible" && temp != "CardSet" && temp != "AttackVisualType" && temp != "CardName" && temp != "Class" && temp != "CardTextInHand" && temp != "Rarity" && temp != "TriggerVisual" && temp != "Faction" && temp != "HowToGetThisGoldCard" && temp != "HowToGetThisCard" && temp != "CardTextInPlay")
                        Helpfunctions.Instance.logg(s);*/
                }


            }


        }

        public Card getCardData(CardDB.cardName cardname)
        {
            Card c = new Card();

            foreach (Card ca in this.cardlist)
            {
                if (ca.name == cardname)
                {
                    return ca;
                }
            }

            return new Card(c);
        }

        public Card getCardDataFromID(cardIDEnum id)
        {
            if (this.cardidToCardList.ContainsKey(id))
            {
                return new Card(cardidToCardList[id]);
            }

            return new Card();
        }

        private void enumCreator()
        {
            //call this, if carddb.txt was changed, to get latest public enum cardIDEnum
            Helpfunctions.Instance.logg("public enum cardIDEnum");
            Helpfunctions.Instance.logg("{");
            Helpfunctions.Instance.logg("None,");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg(cardid + ",");
            }
            Helpfunctions.Instance.logg("}");



            Helpfunctions.Instance.logg("public cardIDEnum cardIdstringToEnum(string s)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg("if(s==\"" + cardid + "\") return CardDB.cardIDEnum." + cardid + ";");
            }
            Helpfunctions.Instance.logg("return CardDB.cardIDEnum.None;");
            Helpfunctions.Instance.logg("}");

            List<string> namelist = new List<string>();

            foreach (string cardid in this.namelist)
            {
                if (namelist.Contains(cardid)) continue;
                namelist.Add(cardid);
            }


            Helpfunctions.Instance.logg("public enum cardName");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in namelist)
            {
                Helpfunctions.Instance.logg(cardid + ",");
            }
            Helpfunctions.Instance.logg("}");

            Helpfunctions.Instance.logg("public cardName cardNamestringToEnum(string s)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in namelist)
            {
                Helpfunctions.Instance.logg("if(s==\"" + cardid + "\") return CardDB.cardName." + cardid + ";");
            }
            Helpfunctions.Instance.logg("return CardDB.cardName.unknown;");
            Helpfunctions.Instance.logg("}");




        }

        public static Enchantment getEnchantmentFromCardID(cardIDEnum cardID)
        {
            Enchantment retval = new Enchantment();
            retval.CARDID = cardID;

            if (cardID == cardIDEnum.CS2_188o)//insiriert  dieser diener hat +2 angriff in diesem zug. (ruchloser unteroffizier)
            {
                retval.angrbuff = 2;
            }

            if (cardID == cardIDEnum.CS2_059o)//blutpakt (blutwichtel)
            {
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_019e)//Segen der Klerikerin (blutelfenklerikerin)
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }

            if (cardID == cardIDEnum.CS2_045e)//waffedesfelsbeissers
            {
                retval.angrbuff = 3;
            }
            if (cardID == cardIDEnum.EX1_587e)//windfury
            {
                retval.windfury = true;
            }
            if (cardID == cardIDEnum.EX1_355e)//urteildestemplers   granted by blessed champion
            {
                retval.angrfaktor = 2;
            }
            if (cardID == cardIDEnum.NEW1_036e)//befehlsruf
            {
                retval.cantLowerHPbelowONE = true;
            }
            if (cardID == cardIDEnum.CS2_046e)// kampfrausch
            {
                retval.angrbuff = 3;
            }

            if (cardID == cardIDEnum.CS2_104e)// toben
            {
                retval.angrbuff = 3;
                retval.hpbuff = 3;
            }
            if (cardID == cardIDEnum.DREAM_05e)// alptraum
            {
                retval.angrbuff = 5;
                retval.hpbuff = 5;
            }
            if (cardID == cardIDEnum.CS2_022e)// verwandlung
            {
                retval.angrbuff = 3;
            }
            if (cardID == cardIDEnum.EX1_611e)// gefangen
            {
                //icetrap?
            }

            if (cardID == cardIDEnum.EX1_014te)// banane
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_178ae)// festgewurzelt
            {
                retval.hpbuff = 5;
                retval.taunt = true;
            }
            if (cardID == cardIDEnum.CS2_011o)// wildesbruellen
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_366e)// rechtschaffen
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.CS2_017o)// klauen (ownhero +1angr)
            {
            }
            if (cardID == cardIDEnum.EX1_604o)// rasend
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_084e)// sturmangriff
            {
                retval.charge = true;
            }
            if (cardID == cardIDEnum.CS1_129e)// inneresfeuer // angr = live
            {
                retval.angrEqualLife = true;
            }
            if (cardID == cardIDEnum.EX1_603e)// aufzackgebracht (fieser zuchtmeister)
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_507e)// mrgglaargl! der murlocanführer verleiht +2/+1.
            {
                retval.angrbuff = 2;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.CS2_038e)// geistderahnen : todesröcheln: dieser diener kehrt aufs schlachtfeld zurück.
            {

            }
            if (cardID == cardIDEnum.NEW1_024o)// gruenhauts befehl +1/+1.
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_590e)// schattenvonmuru : angriff und leben durch aufgezehrte gottesschilde erhöht. (blutritter)
            {
                retval.angrbuff = 3;
                retval.hpbuff = 3;
            }
            if (cardID == cardIDEnum.CS2_074e)// toedlichesgift
            {
            }
            if (cardID == cardIDEnum.EX1_258e)// ueberladen von entfesselnder elementar
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.TU4f_004o)// vermaechtnisdeskaisers von cho
            {
                retval.angrbuff = 2;
                retval.hpbuff = 2;
            }

            if (cardID == cardIDEnum.NEW1_017e)// gefuellterbauch randvoll mit murloc. (hungrigekrabbe)
            {
                retval.angrbuff = 2;
                retval.hpbuff = 2;
            }

            if (cardID == cardIDEnum.EX1_334e)// dunklerbefehl von dunkler Wahnsin
            {
            }

            if (cardID == cardIDEnum.CS2_087e)// segendermacht von segendermacht
            {
                retval.angrbuff = 3;
            }
            if (cardID == cardIDEnum.EX1_613e)// vancleefsrache dieser diener hat erhöhten angriff und erhöhtes leben.
            {
                retval.angrbuff = 2;
                retval.hpbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_623e)// infusion
            {
                retval.hpbuff = 3;
            }
            if (cardID == cardIDEnum.CS2_073e2)// kaltbluetigkeit +4
            {
                retval.angrbuff = 4;
            }
            if (cardID == cardIDEnum.EX1_162o)// staerkedesrudels der terrorwolfalpha verleiht diesem diener +1 angriff.
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_549o)// zorndeswildtiers +2 angriff und immun/ in diesem zug.
            {
                retval.angrbuff = 2;
                retval.imune = true;
            }

            if (cardID == cardIDEnum.EX1_091o)//  kontrollederkabale  dieser diener wurde von einer kabaleschattenpriesterin gestohlen.
            {
            }

            if (cardID == cardIDEnum.CS2_084e)//  maldesjaegers
            {
                retval.setHPtoOne = true;
            }
            if (cardID == cardIDEnum.NEW1_036e2)//  befehlsruf2 ? das leben eurer diener kann in diesem zug nicht unter 1 fallen.
            {
                retval.cantLowerHPbelowONE = true;
            }
            if (cardID == cardIDEnum.CS2_122e)// angespornt der schlachtzugsleiter verleiht diesem diener +1 angriff. (schlachtzugsleiter)
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.CS2_103e)// charge
            {
                retval.charge = true;
            }
            if (cardID == cardIDEnum.EX1_080o)// geheimnissebewahren    erhöhte werte.
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.CS2_005o)// klaue +2 angriff in diesem zug.
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_363e2)// segenderweisheit
            {
                retval.cardDrawOnAngr = true;
            }
            if (cardID == cardIDEnum.EX1_178be)//  entwurzelt +5 angr
            {
                retval.angrbuff = 5;
            }
            if (cardID == cardIDEnum.CS2_222o)//  diemachtsturmwinds +1+1 (von champ of sturmwind)
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_399e)// amoklauf von gurubashi berserker
            {
                retval.angrbuff = 3;
            }
            if (cardID == cardIDEnum.CS2_041e)// machtderahnen
            {
                retval.taunt = true;
            }
            if (cardID == cardIDEnum.EX1_612o)//  machtderkirintor
            {

            }
            if (cardID == cardIDEnum.EX1_004e)// elunesanmut erhöhtes leben. von junger priesterin
            {
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_246e)// verhext dieser diener wurde verwandelt.
            {

            }
            if (cardID == cardIDEnum.EX1_244e)// machtdertotems (card that buffs hp of totems)
            {
                retval.hpbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_607e)// innerewut (innere wut)
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_573ae)// gunstdeshalbgotts (cenarius?)
            {
                retval.angrbuff = 2;
                retval.hpbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_411e2)// schliffbenoetigt angriff verringert.  von waffe blutschrei
            {
                retval.angrbuff = -1;
            }
            if (cardID == cardIDEnum.CS2_063e)// verderbnis  wird zu beginn des zuges des verderbenden spielers vernichtet.
            {

            }
            if (cardID == cardIDEnum.CS2_181e)// vollekraft +2 angr ka von wem
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_508o)// mlarggragllabl! dieser murloc hat +1 angriff. (grimmschuppenorakel)
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.CS2_073e)// kaltbluetigkeit +2 angriff.
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.NEW1_018e)// goldrausch von blutsegelraeuberin
            {

            }
            if (cardID == cardIDEnum.EX1_059e2)// experimente! der verrückte alchemist hat angriff und leben vertauscht.
            {

            }
            if (cardID == cardIDEnum.EX1_570e)// biss (only hero)
            {
                retval.angrbuff = 4;
            }
            if (cardID == cardIDEnum.EX1_360e)//  demut  angriff wurde auf 1 gesetzt.
            {
                retval.setANGRtoOne = true;
            }
            if (cardID == cardIDEnum.DS1_175o)// wutgeheul durch waldwolf
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_596e)// daemonenfeuer
            {
                retval.angrbuff = 2;
                retval.hpbuff = 2;
            }

            if (cardID == cardIDEnum.EX1_158e)// seeledeswaldes todesröcheln: ruft einen treant (2/2) herbei.
            {

            }
            if (cardID == cardIDEnum.EX1_316e)// ueberwaeltigendemacht
            {
                retval.angrbuff = 4;
                retval.hpbuff = 4;
            }
            if (cardID == cardIDEnum.EX1_044e)// stufenaufstieg erhöhter angriff und erhöhtes leben. (rastloser abenteuer)
            {

            }
            if (cardID == cardIDEnum.EX1_304e)// verzehren  erhöhte werte. (hexer)
            {

            }
            if (cardID == cardIDEnum.EX1_363e)// segenderweisheit der segnende spieler zieht eine karte, wenn dieser diener angreift.
            {

            }
            if (cardID == cardIDEnum.CS2_105e)// heldenhafterstoss
            {

            }
            if (cardID == cardIDEnum.EX1_128e)// verhuellt bleibt bis zu eurem nächsten zug verstohlen.
            {

            }
            if (cardID == cardIDEnum.NEW1_033o)// himmelsauge leokk verleiht diesem diener +1 angriff.
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.CS2_004e)// machtwortschild
            {
                retval.hpbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_382e)// waffenniederlegen! angriff auf 1 gesetzt.
            {
                retval.setANGRtoOne = true;
            }
            if (cardID == cardIDEnum.CS2_092e)// segenderkoenige
            {
                retval.angrbuff = 4;
                retval.hpbuff = 4;
            }
            if (cardID == cardIDEnum.NEW1_012o)// manasaettigung  erhöhter angriff.
            {

            }
            if (cardID == cardIDEnum.EX1_619e)//  gleichheit  leben auf 1 gesetzt.
            {
                retval.setHPtoOne = true;
            }
            if (cardID == cardIDEnum.EX1_509e)// blarghghl    erhöhter angriff.
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.CS2_009e)// malderwildnis
            {
                retval.angrbuff = 2;
                retval.hpbuff = 2;
                retval.taunt = true;
            }
            if (cardID == cardIDEnum.EX1_103e)// mrghlglhal +2 leben.
            {
                retval.hpbuff = 2;
            }
            if (cardID == cardIDEnum.NEW1_038o)// wachstum  gruul wächst ...
            {

            }
            if (cardID == cardIDEnum.CS1_113e)//  gedankenkontrolle
            {

            }
            if (cardID == cardIDEnum.CS2_236e)//  goettlicherwille  dieser diener hat doppeltes leben.
            {

            }
            if (cardID == cardIDEnum.CS2_083e)// geschaerft +1 angriff in diesem zug.
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.TU4c_008e)// diemachtmuklas
            {
                retval.angrbuff = 8;
            }
            if (cardID == cardIDEnum.EX1_379e)//  busse 
            {
                retval.setHPtoOne = true;
            }
            if (cardID == cardIDEnum.EX1_274e)// puremacht! (astraler arkanist)
            {
                retval.angrbuff = 2;
                retval.hpbuff = 2;
            }
            if (cardID == cardIDEnum.CS2_221e)// vorsicht!scharf! +2 angriff von hasserfüllte schmiedin. 
            {
                retval.weaponAttack = 2;
            }
            if (cardID == cardIDEnum.EX1_409e)// aufgewertet +1 angriff und +1 haltbarkeit.
            {
                retval.weaponAttack = 1;
                retval.weapondurability = 1;
            }
            if (cardID == cardIDEnum.tt_004o)//kannibalismus (fleischfressender ghul)
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_155ae)// maldernatur
            {
                retval.angrbuff = 4;
            }
            if (cardID == cardIDEnum.NEW1_025e)// verstaerkt (by emboldener 3000)
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_584e)// lehrenderkirintor zauberschaden+1 (by uralter magier)
            {
                retval.zauberschaden = 1;
            }
            if (cardID == cardIDEnum.EX1_160be)// rudelfuehrer +1/+1. (macht der wildnis)
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.TU4c_006e)//  banane
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.NEW1_027e)// yarrr!   der südmeerkapitän verleiht +1/+1.
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.DS1_070o)// praesenzdesmeisters +2/+2 und spott/. (hundemeister)
            {
                retval.angrbuff = 2;
                retval.hpbuff = 2;
                retval.taunt = true;
            }
            if (cardID == cardIDEnum.EX1_046e)// gehaertet +2 angriff in diesem zug. (dunkeleisenzwerg)
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_531e)// satt    erhöhter angriff und erhöhtes leben. (aasfressende Hyaene)
            {
                retval.angrbuff = 2;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.CS2_226e)// bannerderfrostwoelfe    erhöhte werte. (frostwolfkriegsfuerst)
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.DS1_178e)//  sturmangriff tundranashorn verleiht ansturm.
            {
                retval.charge = true;
            }
            if (cardID == cardIDEnum.CS2_226o)//befehlsgewalt der kriegsfürst der frostwölfe hat erhöhten angriff und erhöhtes leben.
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.Mekka4e)// verwandelt wurde in ein huhn verwandelt!
            {

            }
            if (cardID == cardIDEnum.EX1_411e)// blutrausch kein haltbarkeitsverlust. (blutschrei)
            {

            }
            if (cardID == cardIDEnum.EX1_145o)// vorbereitung    der nächste zauber, den ihr in diesem zug wirkt, kostet (3) weniger.
            {

            }
            if (cardID == cardIDEnum.EX1_055o)// gestaerkt    die manasüchtige hat erhöhten angriff.
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.CS2_053e)// fernsicht   eine eurer karten kostet (3) weniger.
            {

            }
            if (cardID == cardIDEnum.CS2_146o)//  geschaerft +1 haltbarkeit.
            {
                retval.weapondurability = 1;
            }
            if (cardID == cardIDEnum.EX1_059e)//  experimente! der verrückte alchemist hat angriff und leben vertauscht.
            {

            }
            if (cardID == cardIDEnum.EX1_565o)// flammenzunge +2 angriff von totem der flammenzunge.
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_001e)// wachsam    erhöhter angriff. (lichtwaechterin)
            {
                retval.angrbuff = 2;
            }
            if (cardID == cardIDEnum.EX1_536e)// aufgewertet   erhöhte haltbarkeit.
            {
                retval.weaponAttack = 1;
                retval.weapondurability = 1;
            }
            if (cardID == cardIDEnum.EX1_155be)// maldernatur   dieser diener hat +4 leben und spott/.
            {
                retval.hpbuff = 4;
                retval.taunt = true;
            }
            if (cardID == cardIDEnum.CS2_103e2)// sturmangriff    +2 angriff und ansturm/.
            {
                retval.angrbuff = 2;
                retval.charge = true;
            }
            if (cardID == cardIDEnum.TU4f_006o)// transzendenz    cho kann nicht angegriffen werden, bevor ihr seine diener erledigt habt.
            {

            }
            if (cardID == cardIDEnum.EX1_043e)// stundedeszwielichts    erhöhtes leben. (zwielichtdrache)
            {
                retval.hpbuff = 1;
            }
            if (cardID == cardIDEnum.NEW1_037e)// bewaffnet   erhöhter angriff. meisterschwertschmied
            {
                retval.angrbuff = 1;
            }
            if (cardID == cardIDEnum.EX1_161o)// demoralisierendesgebruell    dieser diener hat -3 angriff in diesem zug.
            {

            }
            if (cardID == cardIDEnum.EX1_093e)// handvonargus
            {
                retval.angrbuff = 1;
                retval.hpbuff = 1;
                retval.taunt = true;
            }


            return retval;
        }



    }

    public class BoardTester
    {
        int ownPlayer = 1;

        int enemmaxman = 0;

        int mana = 0;
        int maxmana = 0;
        string ownheroname = "";
        int ownherohp = 0;
        int ownherodefence = 0;
        bool ownheroready = false;
        bool ownHeroimmunewhileattacking = false;
        int ownheroattacksThisRound = 0;
        int ownHeroAttack = 0;
        string ownHeroWeapon = "";
        int ownHeroWeaponAttack = 0;
        int ownHeroWeaponDurability = 0;
        int numMinionsPlayedThisTurn = 0;
        int cardsPlayedThisTurn = 0;
        int overdrive = 0;

        int ownDecksize = 30;
        int enemyDecksize = 30;
        int ownFatigue = 0;
        int enemyFatigue = 0;

        bool heroImmune = false;
        bool enemyHeroImmune = false;

        int enemySecrets = 0;

        bool ownHeroFrozen = false;

        List<string> ownsecretlist = new List<string>();
        string enemyheroname = "";
        int enemyherohp = 0;
        int enemyherodefence = 0;
        bool enemyFrozen = false;
        int enemyWeaponAttack = 0;
        int enemyWeaponDur = 0;
        string enemyWeapon = "";

        List<Minion> ownminions = new List<Minion>();
        List<Minion> enemyminions = new List<Minion>();
        List<Handmanager.Handcard> handcards = new List<Handmanager.Handcard>();

        public BoardTester()
        {
            string[] lines = new string[0] { };
            try
            {
                string path = Settings.Instance.path;
                lines = System.IO.File.ReadAllLines(path + "test.txt");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find test.txt");
                Helpfunctions.Instance.ErrorLog("cant find test.txt");
                return;
            }

            CardDB.Card heroability = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_034);
            CardDB.Card enemyability = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_034);
            bool abilityReady = false;

            int readstate = 0;
            int counter = 0;

            Minion tempminion = new Minion();
            int j = 0;
            foreach (string sss in lines)
            {
                string s = sss + " ";
                Helpfunctions.Instance.logg(s);

                if (s.StartsWith("ailoop"))
                {
                    break;
                }
                if (s.StartsWith("####"))
                {
                    continue;
                }
                if (s.StartsWith("start calculations"))
                {
                    continue;
                }

                if (s.StartsWith("enemy secretsCount:"))
                {
                    this.enemySecrets = Convert.ToInt32(s.Split(' ')[2]);
                    continue;
                }

                if (s.StartsWith("mana "))
                {
                    string ss = s.Replace("mana ", "");
                    mana = Convert.ToInt32(ss.Split('/')[0]);
                    maxmana = Convert.ToInt32(ss.Split('/')[1]);
                }

                if (s.StartsWith("emana "))
                {
                    string ss = s.Replace("emana ", "");
                    enemmaxman = Convert.ToInt32(ss);
                }

                if (readstate == 42 && counter == 1) // player
                {
                    this.overdrive = Convert.ToInt32(s.Split(' ')[2]);
                    this.numMinionsPlayedThisTurn = Convert.ToInt32(s.Split(' ')[0]);
                    this.cardsPlayedThisTurn = Convert.ToInt32(s.Split(' ')[1]);
                    this.ownPlayer = Convert.ToInt32(s.Split(' ')[3]);
                }

                if (readstate == 1 && counter == 1) // class + hp + defence + immunewhile attacking + immune
                {
                    ownheroname = s.Split(' ')[0];
                    ownherohp = Convert.ToInt32(s.Split(' ')[1]);
                    ownherodefence = Convert.ToInt32(s.Split(' ')[2]);
                    this.ownHeroimmunewhileattacking = (s.Split(' ')[3] == "True") ? true : false;
                    this.heroImmune = (s.Split(' ')[4] == "True") ? true : false;

                }

                if (readstate == 1 && counter == 2) // ready, num attacks this turn, frozen
                {
                    string readystate = s.Split(' ')[1];
                    this.ownheroready = (readystate == "True") ? true : false;
                    this.ownheroattacksThisRound = Convert.ToInt32(s.Split(' ')[3]);

                    this.ownHeroFrozen = (s.Split(' ')[5] == "True") ? true : false;

                    ownHeroAttack = Convert.ToInt32(s.Split(' ')[7]);
                    ownHeroWeaponAttack = Convert.ToInt32(s.Split(' ')[8]);
                    this.ownHeroWeaponDurability = Convert.ToInt32(s.Split(' ')[9]);
                    if (ownHeroWeaponAttack == 0)
                    {
                        ownHeroWeapon = ""; //:D
                    }
                    else
                    {
                        ownHeroWeapon = s.Split(' ')[10];
                    }
                }

                if (readstate == 1 && counter == 3) // ability + abilityready
                {
                    abilityReady = (s.Split(' ')[1] == "True") ? true : false;
                    heroability = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s.Split(' ')[2]));
                }

                if (readstate == 1 && counter >= 5) // secrets
                {
                    if (!s.StartsWith("enemyhero:"))
                    {
                        ownsecretlist.Add(s.Replace(" ", ""));
                    }
                }

                if (readstate == 2 && counter == 1) // class + hp + defence + frozen + immune
                {
                    enemyheroname = s.Split(' ')[0];
                    enemyherohp = Convert.ToInt32(s.Split(' ')[1]);
                    enemyherodefence = Convert.ToInt32(s.Split(' ')[2]);
                    enemyFrozen = (s.Split(' ')[3] == "True") ? true : false;
                    enemyHeroImmune = (s.Split(' ')[4] == "True") ? true : false;
                }

                if (readstate == 2 && counter == 2) // wepon + stuff
                {
                    this.enemyWeaponAttack = Convert.ToInt32(s.Split(' ')[0]);
                    this.enemyWeaponDur = Convert.ToInt32(s.Split(' ')[1]);
                    if (enemyWeaponDur == 0)
                    {
                        this.enemyWeapon = "";
                    }
                    else
                    {
                        this.enemyWeapon = s.Split(' ')[2];
                    }

                }
                if (readstate == 2 && counter == 3) // ability
                {
                    enemyability = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s.Split(' ')[2]));
                }
                if (readstate == 2 && counter == 4) // fatigue
                {
                    this.ownDecksize = Convert.ToInt32(s.Split(' ')[1]);
                    this.enemyDecksize = Convert.ToInt32(s.Split(' ')[3]);
                    this.ownFatigue = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemyFatigue = Convert.ToInt32(s.Split(' ')[4]);
                }

                if (readstate == 3) // minion or enchantment
                {
                    if (s.Contains(" id:"))
                    {
                        if (counter >= 2) this.ownminions.Add(tempminion);

                        string minionname = s.Split(' ')[0];
                        string minionid = s.Split(' ')[1];
                        int attack = Convert.ToInt32(s.Split(new string[] { " A:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hp = Convert.ToInt32(s.Split(new string[] { " H:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int maxhp = Convert.ToInt32(s.Split(new string[] { " mH:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        bool ready = s.Split(new string[] { " rdy:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool taunt = s.Split(new string[] { " tnt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool frzn = false;
                        if (s.Contains(" frz:")) frzn = s.Split(new string[] { " frz:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool silenced = false;
                        if (s.Contains(" silenced:")) silenced = s.Split(new string[] { " silenced:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool divshield = false;
                        if (s.Contains(" divshield:")) divshield = s.Split(new string[] { " divshield:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool ptt = false;//played this turn
                        if (s.Contains(" ptt:")) ptt = s.Split(new string[] { " ptt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool wndfry = false;//windfurry
                        if (s.Contains(" wndfr:")) wndfry = s.Split(new string[] { " wndfr:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        int natt = 0;
                        if (s.Contains(" natt:")) natt = Convert.ToInt32(s.Split(new string[] { " natt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                        int ent = 1000 + j;
                        if (s.Contains(" e:")) ent = Convert.ToInt32(s.Split(new string[] { " e:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                        bool pois = false;//poision
                        if (s.Contains(" poi:")) pois = s.Split(new string[] { " poi:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool stl = false;//stealth
                        if (s.Contains(" stl:")) stl = s.Split(new string[] { " stl:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool immn = false;//immune
                        if (s.Contains(" imm:")) immn = s.Split(new string[] { " imm:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool chrg = false;//charge
                        if (s.Contains(" chrg:")) chrg = s.Split(new string[] { " chrg:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool ex = false;//exhausted
                        if (s.Contains(" ex:")) ex = s.Split(new string[] { " ex:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;


                        int id = Convert.ToInt32(s.Split(new string[] { " id:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        tempminion = createNewMinion(new Handmanager.Handcard(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid))), id);
                        tempminion.Angr = attack;
                        tempminion.Hp = hp;
                        tempminion.maxHp = maxhp;
                        tempminion.Ready = ready;
                        tempminion.taunt = taunt;
                        tempminion.divineshild = divshield;
                        tempminion.playedThisTurn = ptt;
                        tempminion.windfury = wndfry;
                        tempminion.numAttacksThisTurn = natt;
                        tempminion.entitiyID = ent;
                        tempminion.handcard.entity = ent;
                        tempminion.silenced = silenced;
                        tempminion.exhausted = ex;
                        tempminion.poisonous = pois;
                        tempminion.stealth = stl;
                        tempminion.immune = immn;
                        tempminion.charge = chrg;
                        tempminion.frozen = frzn;
                        if (maxhp > hp) tempminion.wounded = true;





                    }
                    else
                    {
                        try
                        {
                            Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.Instance.cardIdstringToEnum(s.Split(' ')[0]));
                            e.controllerOfCreator = Convert.ToInt32(s.Split(' ')[2]);
                            e.creator = Convert.ToInt32(s.Split(' ')[1]);
                            tempminion.enchantments.Add(e);
                        }
                        catch
                        {
                        }
                    }

                }

                if (readstate == 4) // minion or enchantment
                {
                    if (s.Contains(" id:"))
                    {
                        if (counter >= 2) this.enemyminions.Add(tempminion);

                        string minionname = s.Split(' ')[0];
                        string minionid = s.Split(' ')[1];
                        int attack = Convert.ToInt32(s.Split(new string[] { " A:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hp = Convert.ToInt32(s.Split(new string[] { " H:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int maxhp = Convert.ToInt32(s.Split(new string[] { " mH:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        bool ready = s.Split(new string[] { " rdy:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool taunt = s.Split(new string[] { " tnt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool frzn = false;
                        if (s.Contains(" frz:")) frzn = s.Split(new string[] { " frz:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;

                        bool silenced = false;
                        if (s.Contains(" silenced:")) silenced = s.Split(new string[] { " silenced:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool divshield = false;
                        if (s.Contains(" divshield:")) divshield = s.Split(new string[] { " divshield:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool ptt = false;//played this turn
                        if (s.Contains(" ptt:")) ptt = s.Split(new string[] { " ptt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool wndfry = false;//windfurry
                        if (s.Contains(" wndfr:")) wndfry = s.Split(new string[] { " wndfr:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        int natt = 0;
                        if (s.Contains(" natt:")) natt = Convert.ToInt32(s.Split(new string[] { " natt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                        int ent = 1000 + j;
                        if (s.Contains(" e:")) ent = Convert.ToInt32(s.Split(new string[] { " e:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                        bool pois = false;//poision
                        if (s.Contains(" poi:")) pois = s.Split(new string[] { " poi:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool stl = false;//stealth
                        if (s.Contains(" stl:")) stl = s.Split(new string[] { " stl:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool immn = false;//immune
                        if (s.Contains(" imm:")) immn = s.Split(new string[] { " imm:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool chrg = false;//charge
                        if (s.Contains(" chrg:")) chrg = s.Split(new string[] { " chrg:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        bool ex = false;//exhausted
                        if (s.Contains(" ex:")) ex = s.Split(new string[] { " ex:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;

                        int id = Convert.ToInt32(s.Split(new string[] { " id:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        tempminion = createNewMinion(new Handmanager.Handcard(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid))), id);
                        tempminion.Angr = attack;
                        tempminion.Hp = hp;
                        tempminion.maxHp = maxhp;
                        tempminion.Ready = ready;
                        tempminion.taunt = taunt;
                        tempminion.divineshild = divshield;
                        tempminion.playedThisTurn = ptt;
                        tempminion.windfury = wndfry;
                        tempminion.numAttacksThisTurn = natt;
                        tempminion.entitiyID = ent;
                        tempminion.silenced = silenced;
                        tempminion.exhausted = ex;
                        tempminion.poisonous = pois;
                        tempminion.stealth = stl;
                        tempminion.immune = immn;
                        tempminion.charge = chrg;
                        tempminion.frozen = frzn;
                        if (maxhp > hp) tempminion.wounded = true;


                    }
                    else
                    {
                        try
                        {
                            Enchantment e = CardDB.getEnchantmentFromCardID(CardDB.Instance.cardIdstringToEnum(s.Split(' ')[0]));
                            e.controllerOfCreator = Convert.ToInt32(s.Split(' ')[2]);
                            e.creator = Convert.ToInt32(s.Split(' ')[1]);
                            tempminion.enchantments.Add(e);
                        }
                        catch
                        {
                        }
                    }

                }

                if (readstate == 5) // minion or enchantment
                {

                    Handmanager.Handcard card = new Handmanager.Handcard();

                    string minionname = s.Split(' ')[2];
                    string minionid = s.Split(' ')[6];
                    int pos = Convert.ToInt32(s.Split(' ')[1]);
                    int mana = Convert.ToInt32(s.Split(' ')[3]);
                    card.card = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid));
                    card.entity = Convert.ToInt32(s.Split(' ')[5]);
                    card.manacost = mana;
                    card.position = pos;
                    handcards.Add(card);

                }


                if (s.StartsWith("ownhero:"))
                {
                    readstate = 1;
                    counter = 0;
                }

                if (s.StartsWith("enemyhero:"))
                {
                    readstate = 2;
                    counter = 0;
                }

                if (s.StartsWith("OwnMinions:"))
                {
                    readstate = 3;
                    counter = 0;
                }

                if (s.StartsWith("EnemyMinions:"))
                {
                    if (counter >= 2) this.ownminions.Add(tempminion);

                    readstate = 4;
                    counter = 0;
                }

                if (s.StartsWith("Own Handcards:"))
                {
                    if (counter >= 2) this.enemyminions.Add(tempminion);

                    readstate = 5;
                    counter = 0;
                }

                if (s.StartsWith("player:"))
                {
                    readstate = 42;
                    counter = 0;
                }



                counter++;
                j++;
            }
            Helpfunctions.Instance.logg("rdy");


            Hrtprozis.Instance.setOwnPlayer(ownPlayer);
            Handmanager.Instance.setOwnPlayer(ownPlayer);

            Hrtprozis.Instance.updatePlayer(this.maxmana, this.mana, this.cardsPlayedThisTurn, this.numMinionsPlayedThisTurn, this.overdrive, 100, 200);
            Hrtprozis.Instance.updateSecretStuff(this.ownsecretlist, enemySecrets);

            int numattttHero = 0;
            bool herowindfury = false;
            Hrtprozis.Instance.updateOwnHero(this.ownHeroWeapon, this.ownHeroWeaponAttack, this.ownHeroWeaponDurability, ownHeroimmunewhileattacking, this.ownHeroAttack, this.ownherohp, this.ownherodefence, this.ownheroname, this.ownheroready, this.ownHeroFrozen, heroability, abilityReady, numattttHero, herowindfury, this.heroImmune);
            Hrtprozis.Instance.updateEnemyHero(this.enemyWeapon, this.enemyWeaponAttack, this.enemyWeaponDur, this.enemyWeaponAttack, this.enemyherohp, this.enemyherodefence, this.enemyheroname, this.enemyFrozen, enemyability, enemyHeroImmune, enemmaxman);

            Hrtprozis.Instance.updateMinions(this.ownminions, this.enemyminions);

            Hrtprozis.Instance.updateFatigueStats(this.ownDecksize, this.ownFatigue, this.enemyDecksize, this.enemyFatigue);

            Handmanager.Instance.setHandcards(this.handcards, this.handcards.Count, 5);


        }



        private Minion createNewMinion(Handmanager.Handcard hc, int id)
        {
            Minion m = new Minion();
            m.handcard = new Handmanager.Handcard(hc);
            m.id = id;
            m.zonepos = id + 1;
            m.entitiyID = hc.entity;
            m.Posix = 0;
            m.Posiy = 0;
            m.Angr = hc.card.Attack;
            m.Hp = hc.card.Health;
            m.maxHp = hc.card.Health;
            m.name = hc.card.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;


            if (hc.card.windfury) m.windfury = true;
            if (hc.card.tank) m.taunt = true;
            if (hc.card.Charge)
            {
                m.Ready = true;
                m.charge = true;
            }
            if (hc.card.Shield) m.divineshild = true;
            if (hc.card.poisionous) m.poisonous = true;

            if (hc.card.Stealth) m.stealth = true;

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }


            return m;
        }



    }

    public class Enchantment
    {
        public bool cantBeDispelled = false;
        public CardDB.cardIDEnum CARDID = CardDB.cardIDEnum.None;
        public int creator = 0;
        public int angrbuff = 0;
        public int hpbuff = 0;
        public int weaponAttack = 0;
        public int weapondurability = 0;
        public int angrfaktor = 1;
        public int hpfaktor = 1;
        public bool charge = false;
        public bool divineshild = false;
        public bool taunt = false;

        public bool cantLowerHPbelowONE = false;
        public bool angrEqualLife = false;

        public bool imune = false;
        public bool setHPtoOne = false;
        public bool setANGRtoOne = false;
        public bool cardDrawOnAngr = false;
        public bool windfury = false;
        public int zauberschaden = 0;
        public int controllerOfCreator = 0;
    }

    public class Minion
    {
        public int id = -1;
        public int Posix = 0;
        public int Posiy = 0;
        public int Hp = 0;
        public int maxHp = 0;
        public int Angr = 0;
        public bool Ready = false;
        public bool taunt = false;
        public bool wounded = false;//hp red?
        public CardDB.cardName name = CardDB.cardName.unknown;
        public Handmanager.Handcard handcard;
        public bool divineshild = false;
        public bool windfury = false;
        public bool frozen = false;
        public int zonepos = 0;
        public bool stealth = false;
        public bool immune = false;
        public bool exhausted = false;
        public int numAttacksThisTurn = 0;
        public bool playedThisTurn = false;
        public bool charge = false;
        public bool poisonous = false;
        public bool silenced = false;
        public int entitiyID = -1;
        public bool cantLowerHPbelowONE = false;
        public List<Enchantment> enchantments;

        public Minion()
        {
            enchantments = new List<Enchantment>();
            this.handcard = new Handmanager.Handcard();
        }

        public Minion(Minion m)
        {
            this.id = m.id;
            this.Posix = m.Posix;
            this.Posiy = m.Posiy;
            this.Hp = m.Hp;
            this.maxHp = m.maxHp;
            this.Angr = m.Angr;
            this.Ready = m.Ready;
            this.taunt = m.taunt;
            this.wounded = m.wounded;
            this.name = m.name;
            this.handcard = m.handcard;
            this.divineshild = m.divineshild;
            this.windfury = m.windfury;
            this.frozen = m.frozen;
            this.zonepos = m.zonepos;
            this.stealth = m.stealth;
            this.immune = m.immune;
            this.exhausted = m.exhausted;
            this.numAttacksThisTurn = m.numAttacksThisTurn;
            this.playedThisTurn = m.playedThisTurn;
            this.charge = m.charge;
            this.poisonous = m.poisonous;
            this.silenced = m.silenced;
            this.entitiyID = m.entitiyID;
            this.enchantments = new List<Enchantment>(m.enchantments);
            this.cantLowerHPbelowONE = m.cantLowerHPbelowONE;
        }

        public void setMinionTominion(Minion m)
        {
            this.id = m.id;
            this.Posix = m.Posix;
            this.Posiy = m.Posiy;
            this.Hp = m.Hp;
            this.maxHp = m.maxHp;
            this.Angr = m.Angr;
            this.Ready = m.Ready;
            this.taunt = m.taunt;
            this.wounded = m.wounded;
            this.name = m.name;
            this.handcard = m.handcard;
            this.divineshild = m.divineshild;
            this.windfury = m.windfury;
            this.frozen = m.frozen;
            this.zonepos = m.zonepos;
            this.stealth = m.stealth;
            this.immune = m.immune;
            this.exhausted = m.exhausted;
            this.numAttacksThisTurn = m.numAttacksThisTurn;
            this.playedThisTurn = m.playedThisTurn;
            this.charge = m.charge;
            this.poisonous = m.poisonous;
            this.silenced = m.silenced;
            this.entitiyID = m.entitiyID;
            this.enchantments.Clear();
            this.enchantments.AddRange(m.enchantments);
        }
    }

    public enum Side
    {
        NEUTRAL,
        FRIENDLY,
        OPPOSING
    }

    public enum GAME_TAG
    {
        STATE = 204,
        TURN = 20,
        STEP = 19,
        NEXT_STEP = 198,
        TEAM_ID = 31,
        PLAYER_ID = 30,
        STARTHANDSIZE = 29,
        MAXHANDSIZE = 28,
        MAXRESOURCES = 176,
        TIMEOUT = 7,
        TURN_START,
        TURN_TIMER_SLUSH,
        GOLD_REWARD_STATE = 13,
        FIRST_PLAYER = 24,
        CURRENT_PLAYER = 23,
        HERO_ENTITY = 27,
        RESOURCES = 26,
        RESOURCES_USED = 25,
        FATIGUE = 22,
        PLAYSTATE = 17,
        CURRENT_SPELLPOWER = 291,
        MULLIGAN_STATE = 305,
        HAND_REVEALED = 348,
        CARDNAME = 185,
        CARDTEXT_INHAND = 184,
        CARDRACE = 200,
        CARDTYPE = 202,
        COST = 48,
        HEALTH = 45,
        ATK = 47,
        DURABILITY = 187,
        ARMOR = 292,
        PREDAMAGE = 318,
        TARGETING_ARROW_TEXT = 325,
        LAST_AFFECTED_BY = 18,
        ENCHANTMENT_BIRTH_VISUAL = 330,
        ENCHANTMENT_IDLE_VISUAL,
        PREMIUM = 12,
        IGNORE_DAMAGE = 1,
        IGNORE_DAMAGE_OFF = 354,
        ENTITY_ID = 53,
        DEFINITION = 52,
        OWNER = 51,
        CONTROLLER = 50,
        ZONE = 49,
        EXHAUSTED = 43,
        ATTACHED = 40,
        PROPOSED_ATTACKER = 39,
        ATTACKING = 38,
        PROPOSED_DEFENDER = 37,
        DEFENDING = 36,
        PROTECTED = 35,
        PROTECTING = 34,
        RECENTLY_ARRIVED = 33,
        DAMAGE = 44,
        TRIGGER_VISUAL = 32,
        TAUNT = 190,
        SPELLPOWER = 192,
        DIVINE_SHIELD = 194,
        CHARGE = 197,
        SECRET = 219,
        MORPH = 293,
        DIVINE_SHIELD_READY = 314,
        TAUNT_READY = 306,
        STEALTH_READY,
        CHARGE_READY,
        CREATOR = 313,
        CANT_DRAW = 232,
        CANT_PLAY = 231,
        CANT_DISCARD = 230,
        CANT_DESTROY = 229,
        CANT_TARGET = 228,
        CANT_ATTACK = 227,
        CANT_EXHAUST = 226,
        CANT_READY = 225,
        CANT_REMOVE_FROM_GAME = 224,
        CANT_SET_ASIDE = 223,
        CANT_DAMAGE = 222,
        CANT_HEAL = 221,
        CANT_BE_DESTROYED = 247,
        CANT_BE_TARGETED = 246,
        CANT_BE_ATTACKED = 245,
        CANT_BE_EXHAUSTED = 244,
        CANT_BE_READIED = 243,
        CANT_BE_REMOVED_FROM_GAME = 242,
        CANT_BE_SET_ASIDE = 241,
        CANT_BE_DAMAGED = 240,
        CANT_BE_HEALED = 239,
        CANT_BE_SUMMONING_SICK = 253,
        CANT_BE_DISPELLED = 314,
        INCOMING_DAMAGE_CAP = 238,
        INCOMING_DAMAGE_ADJUSTMENT = 237,
        INCOMING_DAMAGE_MULTIPLIER = 236,
        INCOMING_HEALING_CAP = 235,
        INCOMING_HEALING_ADJUSTMENT = 234,
        INCOMING_HEALING_MULTIPLIER = 233,
        FROZEN = 260,
        JUST_PLAYED,
        LINKEDCARD,
        ZONE_POSITION,
        CANT_BE_FROZEN,
        COMBO_ACTIVE = 266,
        CARD_TARGET,
        NUM_CARDS_PLAYED_THIS_TURN = 269,
        CANT_BE_TARGETED_BY_OPPONENTS,
        NUM_TURNS_IN_PLAY,
        SUMMONED = 205,
        ENRAGED = 212,
        SILENCED = 188,
        WINDFURY,
        LOYALTY = 216,
        DEATHRATTLE,
        ADJACENT_BUFF = 350,
        STEALTH = 191,
        BATTLECRY = 218,
        NUM_TURNS_LEFT = 272,
        OUTGOING_DAMAGE_CAP,
        OUTGOING_DAMAGE_ADJUSTMENT,
        OUTGOING_DAMAGE_MULTIPLIER,
        OUTGOING_HEALING_CAP,
        OUTGOING_HEALING_ADJUSTMENT,
        OUTGOING_HEALING_MULTIPLIER,
        INCOMING_ABILITY_DAMAGE_ADJUSTMENT,
        INCOMING_COMBAT_DAMAGE_ADJUSTMENT,
        OUTGOING_ABILITY_DAMAGE_ADJUSTMENT,
        OUTGOING_COMBAT_DAMAGE_ADJUSTMENT,
        OUTGOING_ABILITY_DAMAGE_MULTIPLIER,
        OUTGOING_ABILITY_DAMAGE_CAP,
        INCOMING_ABILITY_DAMAGE_MULTIPLIER,
        INCOMING_ABILITY_DAMAGE_CAP,
        OUTGOING_COMBAT_DAMAGE_MULTIPLIER,
        OUTGOING_COMBAT_DAMAGE_CAP,
        INCOMING_COMBAT_DAMAGE_MULTIPLIER,
        INCOMING_COMBAT_DAMAGE_CAP,
        IS_MORPHED = 294,
        TEMP_RESOURCES,
        RECALL_OWED,
        NUM_ATTACKS_THIS_TURN,
        NEXT_ALLY_BUFF = 302,
        MAGNET,
        FIRST_CARD_PLAYED_THIS_TURN,
        CARD_ID = 186,
        CANT_BE_TARGETED_BY_ABILITIES = 311,
        SHOULDEXITCOMBAT,
        PARENT_CARD = 316,
        NUM_MINIONS_PLAYED_THIS_TURN,
        CANT_BE_TARGETED_BY_HERO_POWERS = 332,
        COMBO = 220,
        ELITE = 114,
        CARD_SET = 183,
        FACTION = 201,
        RARITY = 203,
        CLASS = 199,
        MISSION_EVENT = 6,
        FREEZE = 208,
        RECALL = 215,
        SILENCE = 339,
        COUNTER,
        ARTISTNAME = 342,
        FLAVORTEXT = 351,
        FORCED_PLAY,
        LOW_HEALTH_THRESHOLD,
        SPELLPOWER_DOUBLE = 356,
        HEALING_DOUBLE,
        NUM_OPTIONS_PLAYED_THIS_TURN,
        NUM_OPTIONS,
        TO_BE_DESTROYED,
        HEALTH_MINIMUM = 337,
        AURA = 362,
        POISONOUS,
        HOW_TO_EARN,
        HOW_TO_EARN_GOLDEN,
        TAG_HERO_POWER_DOUBLE,
        TAG_AI_MUST_PLAY,
        NUM_MINIONS_PLAYER_KILLED_THIS_TURN,
        NUM_MINIONS_KILLED_THIS_TURN,
        AFFECTED_BY_SPELL_POWER,
        EXTRA_DEATHRATTLES,
        START_WITH_1_HEALTH,
        IMMUNE_WHILE_ATTACKING,
        MULTIPLY_HERO_DAMAGE,
        MULTIPLY_BUFF_VALUE,
        CUSTOM_KEYWORD_EFFECT,
        TOPDECK
    }
    public enum TAG_ZONE
    {
        INVALID,
        PLAY,
        DECK,
        HAND,
        GRAVEYARD,
        REMOVEDFROMGAME,
        SETASIDE,
        SECRET
    }

    public enum TAG_MULLIGAN
    {
        INVALID,
        INPUT,
        DEALING,
        WAITING,
        DONE
    }

    public enum TAG_CLASS
    {
        INVALID,
        DEATHKNIGHT,
        DRUID,
        HUNTER,
        MAGE,
        PALADIN,
        PRIEST,
        ROGUE,
        SHAMAN,
        WARLOCK,
        WARRIOR,
        DREAM

    }

    public enum TAG_CARDTYPE
    {
        INVALID,
        GAME,
        PLAYER,
        HERO,
        MINION,
        ABILITY,
        ENCHANTMENT,
        WEAPON,
        ITEM,
        TOKEN,
        HERO_POWER
    }


    public enum AttackType
    {
        INVALID,
        REGULAR,
        PROPOSED,
        CANCELED,
        ONLY_ATTACKER,
        ONLY_DEFENDER,
        ONLY_PROPOSED_ATTACKER,
        ONLY_PROPOSED_DEFENDER,
        WAITING_ON_PROPOSED_ATTACKER,
        WAITING_ON_PROPOSED_DEFENDER,
        WAITING_ON_ATTACKER,
        WAITING_ON_DEFENDER
    }

    public enum TAG_PLAYSTATE
    {
        INVALID,
        PLAYING,
        WINNING,
        LOSING,
        WON,
        LOST,
        TIED,
        DISCONNECTED,
        QUIT
    }


    public enum TAG_RACE
    {
        INVALID,
        BLOODELF,
        DRAENEI,
        DWARF,
        GNOME,
        GOBLIN,
        HUMAN,
        NIGHTELF,
        ORC,
        TAUREN,
        TROLL,
        UNDEAD,
        WORGEN,
        GOBLIN2,
        MURLOC,
        DEMON,
        SCOURGE,
        MECHANICAL,
        ELEMENTAL,
        OGRE,
        PET,
        TOTEM,
        NERUBIAN,
        PIRATE,
        DRAGON
    }

    public enum TAG_STATE
    {
        INVALID,
        LOADING,
        RUNNING,
        COMPLETE
    }

    public enum TAG_STEP
    {
        INVALID,
        BEGIN_FIRST,
        BEGIN_SHUFFLE,
        BEGIN_DRAW,
        BEGIN_MULLIGAN,
        MAIN_BEGIN,
        MAIN_READY,
        MAIN_RESOURCE,
        MAIN_DRAW,
        MAIN_START,
        MAIN_ACTION,
        MAIN_COMBAT,
        MAIN_END,
        MAIN_NEXT,
        FINAL_WRAPUP,
        FINAL_GAMEOVER,
        MAIN_CLEANUP,
        MAIN_START_TRIGGERS
    }

    public enum CHOICE_TYPE
    {
        INVALID,
        MULLIGAN,
        GENERAL
    }

    class Settings
    {

        public string path = "";
        public string logpath = "";
        public string logfile = "Logg.txt";
        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                }
                return instance;
            }
        }


        private Settings()
        {
        }

        public void setFilePath(string path)
        {
            this.path = path;
        }
        public void setLoggPath(string path)
        {
            this.logpath = path;
        }

        public void setLoggFile(string path)
        {
            this.logfile = path;
        }
    }

    public class targett
    {
        public int target = -1;
        public int targetEntity = -1;

        public targett(int targ, int ent)
        {
            this.target = targ;
            this.targetEntity = ent;
        }
    }

}