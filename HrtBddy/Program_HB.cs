using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Triton.Bot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Mapping;


using System.Linq;

namespace HREngine.Bots
{

    public static class SiverFishBotPath
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path) + System.IO.Path.DirectorySeparatorChar;
            }
        }

        public static  string SettingsPath
        {
            get{
                string temp = AssemblyDirectory + System.IO.Path.DirectorySeparatorChar + "Common" + System.IO.Path.DirectorySeparatorChar;
                if (System.IO.Directory.Exists(temp) == false)
                {
                    System.IO.Directory.CreateDirectory(temp);
                }

                return temp;
            }
        }

        public static string LogPath
        {
            get
            {
                string temp = AssemblyDirectory + System.IO.Path.DirectorySeparatorChar + "Logs" + System.IO.Path.DirectorySeparatorChar;
                if (System.IO.Directory.Exists(temp) == false)
                {
                    System.IO.Directory.CreateDirectory(temp);
                }

                return temp;
            }
        }
    }

    public class Silverfish
    {
        public string versionnumber = "117.3";
        private bool singleLog = false;
        private string botbehave = "rush";
        public bool waitingForSilver = false;


        Playfield lastpf;
        Settings sttngs = Settings.Instance;

        List<Minion> ownMinions = new List<Minion>();
        List<Minion> enemyMinions = new List<Minion>();
        List<Handmanager.Handcard> handCards = new List<Handmanager.Handcard>();
        int ownPlayerController = 0;
        List<string> ownSecretList = new List<string>();
        int enemySecretCount = 0;
        List<int> enemySecretList = new List<int>();

        int currentMana = 0;
        int ownMaxMana = 0;
        int numOptionPlayedThisTurn = 0;
        int numMinionsPlayedThisTurn = 0;
        int cardsPlayedThisTurn = 0;
        int ueberladung = 0;

        int enemyMaxMana = 0;

        string ownHeroWeapon = "";
        int heroWeaponAttack = 0;
        int heroWeaponDurability = 0;

        string enemyHeroWeapon = "";
        int enemyWeaponAttack = 0;
        int enemyWeaponDurability = 0;

        string heroname = "";
        string enemyHeroname = "";

        CardDB.Card heroAbility = new CardDB.Card();
        bool ownAbilityisReady = false;
        CardDB.Card enemyAbility = new CardDB.Card();

        int anzcards = 0;
        int enemyAnzCards = 0;

        int ownHeroFatigue = 0;
        int enemyHeroFatigue = 0;
        int ownDecksize = 0;
        int enemyDecksize = 0;

        Minion ownHero;
        Minion enemyHero;

        // NEW VALUES--

        int numberMinionsDiedThisTurn = 0;//todo need that value
        int ownCurrentOverload = 0;//todo get them! = number of overloaded Manacrystals for CURRENT turn (NOT RECALL_OWED !)
        int enemyOverload = 0;//todo need that value maybe
        int ownDragonConsort = 0;
        int enemyDragonConsort = 0;
        int ownLoathebs = 0;// number of loathebs WE PLAYED (so enemy has the buff)
        int enemyLoathebs = 0;
        int ownMillhouse = 0; // number of millhouse-manastorm WE PLAYED (so enemy has the buff)
        int enemyMillhouse = 0;
        int ownKirintor = 0;
        int enemyKirintor = 0;
        int ownPrepa = 0;
        int enemyPrepa = 0;

        // NEW VALUES#TGT#############################################################################################################
        // NEW VALUES#################################################################################################################
        int heroPowerUsesThisTurn = 0;
        int ownHeroPowerUsesThisGame = 0;
        int enemyHeroPowerUsesThisGame = 0;
        int lockandload = 0;
        int ownsabo=0;//number of saboteurplays  of our player (so enemy has the buff)
        int enemysabo = 0;//number of saboteurplays  of enemy player (so we have the buff)
        int ownFenciCoaches = 0; // number of Fencing Coach-debuffs on our player 

        int enemyCursedCardsInHand = 0;
        //LOE stuff###############################################################################################################
        List<CardDB.cardIDEnum> choiceCards = new List<CardDB.cardIDEnum>(); // here we save all available tracking/discover cards ordered from left to right
        public List<int> choiceCardsEntitys = new List<int>(); //list of entitys same order as choiceCards
        

        private static Silverfish instance;

        public static Silverfish Instance
        {
            get
            {
                return instance ?? (instance = new Silverfish());
            }
        }

        private Silverfish()
        {
            this.singleLog = Settings.Instance.writeToSingleFile;
            Helpfunctions.Instance.logg("init Silverfish");
            Helpfunctions.Instance.ErrorLog("init Silverfish");
            string p = "." + System.IO.Path.DirectorySeparatorChar + "Routines" + System.IO.Path.DirectorySeparatorChar + "DefaultRoutine" +
                       System.IO.Path.DirectorySeparatorChar + "Silverfish" + System.IO.Path.DirectorySeparatorChar;
            string path = p + "SilverLogs" + Path.DirectorySeparatorChar;
            System.IO.Directory.CreateDirectory(path);
            Helpfunctions.Instance.ErrorLog("setlogpath to:" + path);
            sttngs.setFilePath(p + "Data" + Path.DirectorySeparatorChar);

            Helpfunctions.Instance.ErrorLog(path);
            
            if (!singleLog)
            {
                
                sttngs.setLoggPath(path);
            }
            else
            {
                sttngs.setLoggPath(SiverFishBotPath.LogPath + System.IO.Path.DirectorySeparatorChar);
                sttngs.setLoggFile("SilverLog.txt");
                Helpfunctions.Instance.createNewLoggfile();
            }
            Helpfunctions.Instance.ErrorLog("setlogpath to:" + path);
            PenalityManager.Instance.setCombos();
            Mulligan m = Mulligan.Instance; // read the mulligan list
        }

        public void setnewLoggFile()
        {
            if (!singleLog)
            {
                sttngs.setLoggFile("SilverLog" + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss") + ".txt");
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

        public bool updateEverything(Behavior botbase, bool quequeActions, bool runExtern = false, bool passiveWait = false, bool nodruidchoice=true)
        {
            quequeActions = false;
            Helpfunctions.Instance.ErrorLog("updateEverything");

            this.updateBehaveString(botbase);

            ownPlayerController = TritonHs.OurHero.ControllerId;


            // create hero + minion data
            getHerostuff();

            //small fix for not knowing when to mulligan:
            if (ownMaxMana == 1 && currentMana == 1 && numMinionsPlayedThisTurn == 0 && cardsPlayedThisTurn == 0)
            {
                setnewLoggFile();
                getHerostuff();
            }

            getMinions();
            getHandcards(nodruidchoice);
            getDecks();
            correctSpellpower();
            // send ai the data:
            Hrtprozis.Instance.clearAll();
            Handmanager.Instance.clearAll();

            Hrtprozis.Instance.setOwnPlayer(ownPlayerController);
            Handmanager.Instance.setOwnPlayer(ownPlayerController);

            this.numOptionPlayedThisTurn = 0;
            this.numOptionPlayedThisTurn += this.cardsPlayedThisTurn + this.ownHero.numAttacksThisTurn;
            foreach (Minion m in this.ownMinions)
            {
                if (m.Hp >= 1) this.numOptionPlayedThisTurn += m.numAttacksThisTurn;
            }

            Hrtprozis.Instance.updatePlayer(this.ownMaxMana, this.currentMana, this.cardsPlayedThisTurn, this.numMinionsPlayedThisTurn, this.numOptionPlayedThisTurn, this.ueberladung, ownHero.entitiyID, enemyHero.entitiyID, this.numberMinionsDiedThisTurn, this.ownCurrentOverload, this.enemyOverload, this.heroPowerUsesThisTurn,this.lockandload);
            Hrtprozis.Instance.setPlayereffects(this.ownDragonConsort, this.enemyDragonConsort, this.ownLoathebs, this.enemyLoathebs, this.ownMillhouse, this.enemyMillhouse, this.ownKirintor, this.ownPrepa, this.ownsabo, this.enemysabo, this.ownFenciCoaches, this.enemyCursedCardsInHand);
            Hrtprozis.Instance.updateSecretStuff(this.ownSecretList, this.enemySecretCount);


            Hrtprozis.Instance.updateOwnHero(this.ownHeroWeapon, this.heroWeaponAttack, this.heroWeaponDurability, this.heroname, this.heroAbility, this.ownAbilityisReady, this.ownHero, this.ownHeroPowerUsesThisGame);
            Hrtprozis.Instance.updateEnemyHero(this.enemyHeroWeapon, this.enemyWeaponAttack, this.enemyWeaponDurability, this.enemyHeroname, this.enemyMaxMana, this.enemyAbility, this.enemyHero, this.enemyHeroPowerUsesThisGame);

            Hrtprozis.Instance.updateMinions(this.ownMinions, this.enemyMinions);
            Handmanager.Instance.setHandcards(this.handCards, this.anzcards, this.enemyAnzCards, this.choiceCards);

            Hrtprozis.Instance.updateFatigueStats(this.ownDecksize, this.ownHeroFatigue, this.enemyDecksize, this.enemyHeroFatigue);

            Probabilitymaker.Instance.getEnemySecretGuesses(this.enemySecretList, Hrtprozis.Instance.heroNametoEnum(this.enemyHeroname));

            //learnmode :D

            Playfield p = new Playfield();


            if (lastpf != null)
            {
                if (lastpf.isEqualf(p))
                {
                    return false;
                }

                //board changed we update secrets!
                //if(Ai.Instance.nextMoveGuess!=null) Probabilitymaker.Instance.updateSecretList(Ai.Instance.nextMoveGuess.enemySecretList);
                Probabilitymaker.Instance.updateSecretList(p, lastpf);
            }


            lastpf = p;
            p = new Playfield();//secrets have updated :D
            // calculate stuff

            /*foreach (Handmanager.Handcard hc in p.owncards)
            {
                Helpfunctions.Instance.ErrorLog("hc playfield" + hc.manacost + " " + hc.getManaCost(p));
            }*/

            /*if (quequeActions)
            {
                // Detect errors in HearthRanger execution of our last set of actions and try to fix it so we don't
                // have to re-calculate the entire turn.
                Bot currentBot = (Bot)rangerbot;
                if (currentBot.numActionsSent > currentBot.numExecsReceived && !p.isEqualf(Ai.Instance.nextMoveGuess))
                {
                    Helpfunctions.Instance.ErrorLog("HR action queue did not complete!");
                    Helpfunctions.Instance.logg("board state out-of-sync due to action queue!");

                    if (Ai.Instance.restoreBestMoves(p, currentBot.queuedMoveGuesses))
                    {
                        Helpfunctions.Instance.logg("rolled back state to replay queued actions.");
                        Helpfunctions.Instance.ErrorLog("#queue-rollback#");
                    }
                }
            }*/


            Helpfunctions.Instance.ErrorLog("calculating stuff... " + DateTime.Now.ToString("HH:mm:ss.ffff"));
            
            if (runExtern)
            {
                Helpfunctions.Instance.logg("recalc-check###########");
                //p.printBoard();
                //Ai.Instance.nextMoveGuess.printBoard();
                if (p.isEqual(Ai.Instance.nextMoveGuess, true))
                {

                    printstuff(p, false);
                    Ai.Instance.doNextCalcedMove();

                }
                else
                {
                    printstuff(p, true);
                    readActionFile(passiveWait);
                }
            }
            else
            {
                using (TritonHs.Memory.ReleaseFrame(true))
                {
                    printstuff(p, false);
                    Ai.Instance.dosomethingclever(botbase);
                }
            }

            Helpfunctions.Instance.ErrorLog("calculating ended! " + DateTime.Now.ToString("HH:mm:ss.ffff"));

            return true;
        }

        private void getHerostuff()
        {

            //TODO GET HERO POWER USES!!!!!!
            //heroPowerUsesThisTurn = 0;
            //ownHeroPowerUsesThisGame = 0;
            //enemyHeroPowerUsesThisGame = 0;

            //reset playerbuffs (thx to xytri)
            this.enemyMillhouse = 0;
            this.enemyLoathebs = 0;
            this.ownDragonConsort = 0;
            this.ownKirintor = 0;
            this.ownPrepa = 0;
            this.lockandload = 0;
            this.enemysabo = 0;
            this.ownFenciCoaches = 0;
            this.ownMillhouse = 0;
            this.ownLoathebs = 0;
            this.enemyDragonConsort = 0;
            this.enemyKirintor = 0;
            this.enemyPrepa = 0;
            this.ownsabo = 0;


            List<HSCard> allEntitys = TritonHs.GetAllCards();
            allEntitys.Add(TritonHs.CurrentPlayer);
            allEntitys.Add(TritonHs.RemotePlayer);

            HSCard ownPlayer = TritonHs.CurrentPlayer;
            HSCard enemyPlayer = TritonHs.RemotePlayer;

            HSCard ownhero = TritonHs.OurHero;
            HSCard enemyhero = TritonHs.EnemyHero;
            HSCard ownHeroAbility = TritonHs.OurHeroPowerCard;

            /*
            //TEST
            List<HSCard> heroplayers = new List<HSCard>();
            heroplayers.Add(ownPlayer);
            heroplayers.Add(enemyPlayer);
            heroplayers.Add(ownhero);
            heroplayers.Add(enemyhero);
            
            Helpfunctions.Instance.ErrorLog("# players/heros");
            foreach (var item in heroplayers)
            {
                Helpfunctions.Instance.ErrorLog(item.Id + " e " + item.EntityId + " a " + item.GetTag(GAME_TAG.ATTACHED) + " controler " + item.ControllerId + " creator " + item.CreatorId + " zone " + item.GetZone() + " zp " + item.ZonePosition);
                List<HSCard> ents = item.AttachedCards;
                foreach (var item1 in ents)
                {
                    Helpfunctions.Instance.ErrorLog("#" + item1.Id + " e " + item1.EntityId + " a " + item1.GetTag(GAME_TAG.ATTACHED) + " controler " + item1.ControllerId + " creator " + item1.CreatorId + " zone " + item1.GetZone());
                }
            }
            //TEST end
            */

            //player stuff#########################
            //this.currentMana =ownPlayer.GetTag(HRGameTag.RESOURCES) - ownPlayer.GetTag(HRGameTag.RESOURCES_USED) + ownPlayer.GetTag(HRGameTag.TEMP_RESOURCES);
            this.currentMana = TritonHs.CurrentMana;
            this.ownMaxMana = TritonHs.Resources;
            this.enemyMaxMana = TritonHs.Resources;
            //enemySecretCount = rangerbot.EnemySecrets.Count;
            //enemySecretCount = 0;
            //count enemy secrets
            enemySecretList.Clear();

            foreach (HSCard item in allEntitys)
            {
                if (item.IsSecret && item.ControllerId == enemyPlayer.ControllerId && item.GetZone() == Triton.Game.Mapping.TAG_ZONE.SECRET)
                {
                    enemySecretList.Add(item.EntityId);
                }
            }
            enemySecretCount = enemySecretList.Count;

            this.ownSecretList.Clear();

            foreach (HSCard item in allEntitys)
            {
                if (item.IsSecret && item.ControllerId == ownPlayer.ControllerId && item.GetZone() == Triton.Game.Mapping.TAG_ZONE.SECRET)
                {
                    this.ownSecretList.Add(item.Id);
                }
            }


            this.numMinionsPlayedThisTurn = TritonHs.NumMinionsPlayedThisTurn;
            this.cardsPlayedThisTurn = TritonHs.NumCardsPlayedThisTurn;
            

            //get weapon stuff
            this.ownHeroWeapon = "";
            this.heroWeaponAttack = 0;
            this.heroWeaponDurability = 0;

            this.ownHeroFatigue = ownhero.GetTag(GAME_TAG.FATIGUE);
            this.enemyHeroFatigue = enemyhero.GetTag(GAME_TAG.FATIGUE);


            //TODO
            this.ownDecksize = 0;
            this.enemyDecksize = 0;
            //count decksize
            foreach (HSCard ent in allEntitys)
            {
                if (ent.ControllerId == ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 2) ownDecksize++;
                if (ent.ControllerId != ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 2) enemyDecksize++;
            }

            //own hero stuff###########################
            int heroAtk = ownhero.GetTag(GAME_TAG.ATK);
            int heroHp = ownhero.GetTag(GAME_TAG.HEALTH) - ownhero.GetTag(GAME_TAG.DAMAGE);
            int heroDefence = ownhero.GetTag(GAME_TAG.ARMOR);
            this.heroname = Hrtprozis.Instance.heroIDtoName(TritonHs.OurHero.Id);

            bool heroImmuneToDamageWhileAttacking = false;
            bool herofrozen = (ownhero.GetTag(GAME_TAG.FROZEN) == 0) ? false : true;
            int heroNumAttacksThisTurn = ownhero.GetTag(GAME_TAG.NUM_ATTACKS_THIS_TURN);
            bool heroHasWindfury = (ownhero.GetTag(GAME_TAG.WINDFURY) == 0) ? false : true;
            bool heroImmune = (ownhero.GetTag(GAME_TAG.CANT_BE_DAMAGED) == 0) ? false : true;

            //Helpfunctions.Instance.ErrorLog(ownhero.GetName() + " ready params ex: " + exausted + " " + heroAtk + " " + numberofattacks + " " + herofrozen);


            if (TritonHs.DoWeHaveWeapon)
            {
                HSCard weapon = TritonHs.OurWeaponCard;
                this.ownHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(weapon.Id)).name.ToString();
                this.heroWeaponAttack = weapon.GetTag(GAME_TAG.ATK);
                this.heroWeaponDurability = weapon.GetTag(GAME_TAG.DURABILITY) - weapon.GetTag(GAME_TAG.DAMAGE);
                heroImmuneToDamageWhileAttacking = false;
                if (this.ownHeroWeapon == "gladiatorslongbow")
                {
                    heroImmuneToDamageWhileAttacking = true;
                }
                if (this.ownHeroWeapon == "doomhammer")
                {
                    heroHasWindfury = true;
                }

                //Helpfunctions.Instance.ErrorLog("weapon: " + ownHeroWeapon + " " + heroWeaponAttack + " " + heroWeaponDurability);

            }



            //enemy hero stuff###############################################################
            this.enemyHeroname = Hrtprozis.Instance.heroIDtoName(TritonHs.EnemyHero.Id);

            int enemyAtk = enemyhero.GetTag(GAME_TAG.ATK);
            int enemyHp = enemyhero.GetTag(GAME_TAG.HEALTH) - enemyhero.GetTag(GAME_TAG.DAMAGE);
            int enemyDefence = enemyhero.GetTag(GAME_TAG.ARMOR);
            bool enemyfrozen = (enemyhero.GetTag(GAME_TAG.FROZEN) == 0) ? false : true;
            bool enemyHeroImmune = (enemyhero.GetTag(GAME_TAG.CANT_BE_DAMAGED) == 0) ? false : true;

            this.enemyHeroWeapon = "";
            this.enemyWeaponAttack = 0;
            this.enemyWeaponDurability = 0;
            if (TritonHs.DoesEnemyHasWeapon)
            {
                HSCard weapon = TritonHs.EnemyWeaponCard;
                this.enemyHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(weapon.Id)).name.ToString();
                this.enemyWeaponAttack = weapon.GetTag(GAME_TAG.ATK);
                this.enemyWeaponDurability = weapon.GetTag(GAME_TAG.DURABILITY) - weapon.GetTag(GAME_TAG.DAMAGE);
            }


            //own hero power stuff###########################################################

            this.heroAbility = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(TritonHs.OurHeroPowerCard.Id));
            this.ownAbilityisReady = (TritonHs.OurHeroPowerCard.GetTag(GAME_TAG.EXHAUSTED) == 0) ? true : false; // if exhausted, ability is NOT ready

            //only because hearthranger desnt give me the data ;_; use the tag HEROPOWER_ACTIVATIONS_THIS_TURN instead! (of own player)
            //this.heroPowerUsesThisTurn = 10000;
            //if (this.ownAbilityisReady) this.heroPowerUsesThisTurn = 0;
            this.heroPowerUsesThisTurn = ownPlayer.GetTag(GAME_TAG.HEROPOWER_ACTIVATIONS_THIS_TURN);
            this.ownHeroPowerUsesThisGame = ownPlayer.GetTag(GAME_TAG.NUM_TIMES_HERO_POWER_USED_THIS_GAME);

            this.enemyAbility = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(TritonHs.EnemyHeroPowerCard.Id));

            //generate Heros
            this.ownHero = new Minion();
            this.enemyHero = new Minion();
            this.ownHero.isHero = true;
            this.enemyHero.isHero = true;
            this.ownHero.own = true;
            this.enemyHero.own = false;
            this.ownHero.maxHp = ownhero.Health;
            this.enemyHero.maxHp = enemyhero.Health;
            this.ownHero.entitiyID = ownhero.EntityId;
            this.enemyHero.entitiyID = enemyhero.EntityId;

            this.ownHero.Angr = heroAtk;
            this.ownHero.Hp = heroHp;
            this.ownHero.armor = heroDefence;
            this.ownHero.frozen = herofrozen;
            this.ownHero.immuneWhileAttacking = heroImmuneToDamageWhileAttacking;
            this.ownHero.immune = heroImmune;
            this.ownHero.numAttacksThisTurn = heroNumAttacksThisTurn;
            this.ownHero.windfury = heroHasWindfury;

            this.enemyHero.Angr = enemyAtk;
            this.enemyHero.Hp = enemyHp;
            this.enemyHero.frozen = enemyfrozen;
            this.enemyHero.armor = enemyDefence;
            this.enemyHero.immune = enemyHeroImmune;
            this.enemyHero.Ready = false;

            this.ownHero.updateReadyness();


            //load enchantments of the heros
            List<miniEnch> miniEnchlist = new List<miniEnch>();
            foreach (HSCard ent in allEntitys)
            {
                if (ent.GetTag(GAME_TAG.ATTACHED) == this.ownHero.entitiyID && ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.PLAY)
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.Id);
                    int controler = ent.ControllerId;
                    int creator = ent.CreatorId;
                    miniEnchlist.Add(new miniEnch(id, creator, controler));
                }

            }

            this.ownHero.loadEnchantments(miniEnchlist, ownhero.ControllerId);

            miniEnchlist.Clear();

            foreach (HSCard ent in allEntitys)
            {
                if (ent.GetTag(GAME_TAG.ATTACHED) == this.enemyHero.entitiyID && ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.PLAY)
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.Id);
                    int controler = ent.ControllerId;
                    int creator = ent.CreatorId;
                    miniEnchlist.Add(new miniEnch(id, creator, controler));
                }

            }

            this.enemyHero.loadEnchantments(miniEnchlist, enemyhero.ControllerId);
            //fastmode weapon correction:
            if (ownHero.Angr < this.heroWeaponAttack) ownHero.Angr = this.heroWeaponAttack;
            if (enemyHero.Angr < this.enemyWeaponAttack) enemyHero.Angr = this.enemyWeaponAttack;

            this.ueberladung = ownPlayer.GetTag(GAME_TAG.OVERLOAD_OWED);// rangerbot.gameState.RecallOwnedNum;//was at the start, but copied it over here :D , its german for overload :D
            //Reading new values:###################################################################################################
            //ToDo:

            this.numberMinionsDiedThisTurn = ownPlayer.GetTag(GAME_TAG.NUM_MINIONS_PLAYER_KILLED_THIS_TURN);// rangerbot.gameState.NumMinionsKilledThisTurn;
            
            //this should work (hope i didnt oversee a value :D)

            this.ownCurrentOverload = ownPlayer.GetTag(GAME_TAG.OVERLOAD);// rangerbot.gameState.RecalledCrystalsOwedNextTurn;// ownhero.GetTag(HRGameTag.RECALL);
            this.enemyOverload = 0;// enemyhero.GetTag(HRGameTag.RECALL_OWED);

            //count buffs off !!players!! (players and not heros) (like preparation, kirintor-buff and stuff)
            // hope this works, dont own these cards to test where its attached

            int owncontrollerblubb = ownhero.ControllerId + 1; // controller = 1 or 2, but entity with 1 is the board -> +1
            int enemycontrollerblubb = enemyhero.ControllerId + 1;// controller = 1 or 2, but entity with 1 is the board -> +1

            //will not work in Hearthranger!


            foreach (HSCard ent in allEntitys)
            {
                if (ent.GetTag(GAME_TAG.ATTACHED) == owncontrollerblubb && ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.PLAY ) //1==play
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.Id);
                    if (id == CardDB.cardIDEnum.NEW1_029t) this.enemyMillhouse++;//CHANGED!!!!
                    if (id == CardDB.cardIDEnum.FP1_030e) this.enemyLoathebs++; //CHANGED!!!!
                    if (id == CardDB.cardIDEnum.BRM_018e) this.ownDragonConsort++;
                    if (id == CardDB.cardIDEnum.EX1_612o) this.ownKirintor++;
                    if (id == CardDB.cardIDEnum.EX1_145o) this.ownPrepa++;
                    if (id == CardDB.cardIDEnum.AT_061e) this.lockandload++;
                    if (id == CardDB.cardIDEnum.AT_086e) this.enemysabo++;
                    if (id == CardDB.cardIDEnum.AT_115e) this.ownFenciCoaches++;

                }

                if (ent.GetTag(GAME_TAG.ATTACHED) == enemycontrollerblubb && ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.PLAY) //1==play
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.Id);
                    if (id == CardDB.cardIDEnum.NEW1_029t) this.ownMillhouse++; //CHANGED!!!! (enemy has the buff-> we played millhouse)
                    if (id == CardDB.cardIDEnum.FP1_030e) this.ownLoathebs++; //CHANGED!!!!
                    if (id == CardDB.cardIDEnum.BRM_018e) this.enemyDragonConsort++;
                    // not needef for enemy, because its lasting only for his turn
                    //if (id == CardDB.cardIDEnum.EX1_612o) this.enemyKirintor++;
                    //if (id == CardDB.cardIDEnum.EX1_145o) this.enemyPrepa++;
                    if (id == CardDB.cardIDEnum.AT_086e) this.ownsabo++;
                }

            }
            //this.lockandload = (rangerbot.gameState.LocalPlayerLockAndLoad)? 1 : 0;

            //saboteur test:
            if (ownHeroAbility.Cost >= 3) Helpfunctions.Instance.ErrorLog("heroabilitymana " + ownHeroAbility.Cost);
            if (this.enemysabo == 0 && ownHeroAbility.Cost >= 3) this.enemysabo++;
            if (this.enemysabo == 1 && ownHeroAbility.Cost >= 8) this.enemysabo++;

            //TODO test Bolvar Fordragon but it will be on his card :D
            //Reading new values end################################

        }

        private void getMinions()
        {
            List<HSCard> allEntitys = TritonHs.GetAllCards();
            HSCard ownPlayer = TritonHs.CurrentPlayer;
            HSCard enemyPlayer = TritonHs.RemotePlayer;
            allEntitys.Add(ownPlayer);
            allEntitys.Add(enemyPlayer);
            
            //TEST....................
            /*
            Helpfunctions.Instance.ErrorLog("# all");
            foreach (var item in rangerbot.gameState.GameEntityList)
            {
                allEntitys.Add(item.EntityId, item);
                Helpfunctions.Instance.ErrorLog(item.CardId + " e " + item.EntityId + " a " + item.Attached + " controler " + item.ControllerId + " creator " + item.CreatorId + " zone " + item.Zone + " zp " + item.ZonePosition);
                List<Entity> ents = item.Attachments;
                foreach (var item1 in ents)
                {
                    Helpfunctions.Instance.ErrorLog("#" + item1.CardId + " e " + item1.EntityId + " a " + item1.Attached + " controler " + item1.ControllerId + " creator " + item1.CreatorId + " zone " + item1.Zone);
                }
            }*/

            

            ownMinions.Clear();
            enemyMinions.Clear();
            

            // ALL minions on Playfield:
            List<HSCard> list = new List<HSCard>();

            foreach (var item in allEntitys)
            {
                if (item.GetZone() == Triton.Game.Mapping.TAG_ZONE.PLAY && item.IsMinion && item.ZonePosition >= 1)
                {
                    list.Add(item);
                }
            }



            List<HSCard> enchantments = new List<HSCard>();


            foreach (HSCard item in list)
            {
                HSCard entitiy = item;
                int zp = entitiy.ZonePosition;

                if (entitiy.IsMinion && zp >= 1)
                {
                    //Helpfunctions.Instance.ErrorLog("zonepos " + zp);
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.Id));
                    Minion m = new Minion();
                    m.name = c.name;
                    m.handcard.card = c;
                    m.Angr = entitiy.GetTag(GAME_TAG.ATK);
                    m.maxHp = entitiy.GetTag(GAME_TAG.HEALTH);
                    m.Hp = m.maxHp - entitiy.GetTag(GAME_TAG.DAMAGE);
                    if (m.Hp <= 0) continue;
                    m.wounded = false;
                    if (m.maxHp > m.Hp) m.wounded = true;


                    m.exhausted = entitiy.IsExhausted;

                    m.taunt = (entitiy.HasTaunt);

                    m.numAttacksThisTurn = entitiy.GetTag(GAME_TAG.NUM_ATTACKS_THIS_TURN);

                    int temp = entitiy.GetTag(GAME_TAG.NUM_TURNS_IN_PLAY);
                    m.playedThisTurn = (temp == 0) ? true : false;

                    m.windfury = (entitiy.HasWindfury);

                    m.frozen = (entitiy.IsFrozen);

                    m.divineshild = (entitiy.HasDivineShield);

                    m.stealth = (entitiy.IsStealthed);

                    m.poisonous = (entitiy.IsPoisonous);

                    m.immune = (entitiy.IsImmune);

                    m.silenced = entitiy.IsSilenced;

                    m.spellpower = entitiy.GetTag(GAME_TAG.SPELLPOWER);

                    m.charge = 0;

                    if (!m.silenced && m.name == CardDB.cardName.southseadeckhand && entitiy.HasCharge) m.charge = 1;
                    if (!m.silenced && m.handcard.card.Charge) m.charge = 1;
                    if (m.charge == 0 && entitiy.HasCharge) m.charge = 1;
                    m.zonepos = zp;

                    m.entitiyID = entitiy.EntityId;

                    if(m.name == CardDB.cardName.unknown) Helpfunctions.Instance.ErrorLog("unknown card error");

                    Helpfunctions.Instance.ErrorLog(m.entitiyID + " ." + entitiy.Id + ". " + m.name + " ready params ex: " + m.exhausted + " charge: " + m.charge + " attcksthisturn: " + m.numAttacksThisTurn + " playedthisturn " + m.playedThisTurn);
                    //Helpfunctions.Instance.ErrorLog("spellpower check " + entitiy.SpellPowerAttack + " " + entitiy.SpellPowerHealing + " " + entitiy.SpellPower);


                    List<miniEnch> enchs = new List<miniEnch>();
                    /*foreach (Entity ent in allEntitys.Values)
                    {
                        if (ent.Attached == m.entitiyID && ent.Zone == HSRangerLib.TAG_ZONE.PLAY)
                        {
                            CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.CardId);
                            int creator = ent.CreatorId;
                            int controler = ent.ControllerId;
                            enchs.Add(new miniEnch(id, creator, controler));
                        }

                    }*/

                    foreach (HSCard ent in item.AttachedCards)
                    {
                        CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.Id);
                        int creator = ent.CreatorId;
                        int controler = ent.ControllerId;
                        enchs.Add(new miniEnch(id, creator, controler));

                    }

                    m.loadEnchantments(enchs, entitiy.ControllerId);




                    m.Ready = false; // if exhausted, he is NOT ready

                    m.updateReadyness();


                    if (entitiy.ControllerId == this.ownPlayerController) // OWN minion
                    {
                        m.own = true;
                        this.ownMinions.Add(m);
                    }
                    else
                    {
                        m.own = false;
                        this.enemyMinions.Add(m);
                    }

                }
                // minions added


            }


        }

        private void correctSpellpower()
        {
            int ownspellpower = TritonHs.CurrentPlayer.GetTag(GAME_TAG.SPELLPOWER);
            int spellpowerfield = 0;
            int numberDalaranAspirant=0;
            foreach (Minion mnn in this.ownMinions)
            {
                if(mnn.name == CardDB.cardName.dalaranaspirant) numberDalaranAspirant++;
                spellpowerfield += mnn.spellpower;
            }
            int missingSpellpower = ownspellpower - spellpowerfield;
            if (missingSpellpower != 0 )
            {
                Helpfunctions.Instance.ErrorLog("spellpower correction: " + ownspellpower + " " + spellpowerfield + " " + numberDalaranAspirant);
            }
            if (missingSpellpower >= 1 && numberDalaranAspirant >= 1)
            {
                //give all dalaran aspirants the "same amount" of spellpower
                for (int i = 0; i < missingSpellpower; i++)
                {
                    Minion dalaranAspriant = null;
                    int spellpower = ownspellpower;

                    foreach (Minion mnn in this.ownMinions)
                    {
                        if (mnn.name == CardDB.cardName.dalaranaspirant)
                        {
                            if (spellpower >= mnn.spellpower)
                            {
                                spellpower = mnn.spellpower;
                                dalaranAspriant = mnn;
                            }
                        }
                    }
                    dalaranAspriant.spellpower++;
                }

            }
        }

        private void getHandcards(bool nodruidchoice)
        {
            handCards.Clear();
            this.anzcards = 0;
            this.enemyAnzCards = 0;
            List<HSCard> allEntitys = TritonHs.GetAllCards();

            foreach (HSCard item in allEntitys)
            {

                HSCard entitiy = item;

                if (entitiy.ControllerId == this.ownPlayerController && entitiy.ZonePosition >= 1 && entitiy.GetZone() == Triton.Game.Mapping.TAG_ZONE.HAND) // own handcard
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.Id));

                    //c.cost = entitiy.GetCost();
                    //c.entityID = entitiy.GetEntityId();

                    Handmanager.Handcard hc = new Handmanager.Handcard();
                    hc.card = c;
                    hc.position = entitiy.ZonePosition;
                    hc.entity = entitiy.EntityId;
                    hc.manacost = entitiy.Cost;
                    hc.addattack = 0;
                    //Helpfunctions.Instance.ErrorLog("hc "+ entitiy.ZonePosition + " ." + entitiy.CardId + ". " + entitiy.Cost + "  " + c.name);
                    int attackchange = entitiy.GetTag(GAME_TAG.ATK) - c.Attack;
                    int hpchange = entitiy.GetTag(GAME_TAG.HEALTH) - c.Health;
                    hc.addattack = attackchange;
                    hc.addHp = hpchange;

                    handCards.Add(hc);
                    this.anzcards++;
                }


            }



            foreach (HSCard ent in allEntitys)
            {
                if (ent.ControllerId != this.ownPlayerController && ent.ZonePosition >= 1 && ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.HAND) // enemy handcard
                {
                    this.enemyAnzCards++;
                    if (CardDB.Instance.cardIdstringToEnum(ent.Id) == CardDB.cardIDEnum.LOE_007t) this.enemyCursedCardsInHand++;
                }
            }

            //search for choice-cards in HR:
            this.choiceCards.Clear();
            this.choiceCardsEntitys.Clear();

            if (TritonHs.IsInChoiceMode() && nodruidchoice)
            {
                var choiceCardMgr = ChoiceCardMgr.Get();
                List<Card> cards = choiceCardMgr.GetFriendlyCards();

                for (int i = 0; i < cards.Count; i++)
                {
                    Card ent = cards[i];
                    this.choiceCards.Add(CardDB.Instance.cardIdstringToEnum(ent.GetCardId()));
                    this.choiceCardsEntitys.Add(ent.GetEntityId());
                    Helpfunctions.Instance.ErrorLog("choice card: " + ent.GetCardId() + " " + ent.GetEntityId());

                }
            }

        }

        private void getDecks()
        {
            List<HSCard> allEntitys = TritonHs.GetAllCards();

            int owncontroler = TritonHs.OurHero.ControllerId;
            int enemycontroler = TritonHs.EnemyHero.ControllerId;
            List<CardDB.cardIDEnum> ownCards = new List<CardDB.cardIDEnum>();
            List<CardDB.cardIDEnum> enemyCards = new List<CardDB.cardIDEnum>();
            List<GraveYardItem> graveYard = new List<GraveYardItem>();

            foreach (HSCard ent in allEntitys)
            {
                if (ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.SECRET && ent.ControllerId == enemycontroler) continue; // cant know enemy secrets :D
                if (ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.DECK) continue;

                if(ent.IsMinion || ent.IsWeapon || ent.IsSpell)
                {

                    CardDB.cardIDEnum cardid = CardDB.Instance.cardIdstringToEnum(ent.Id);
                    //string owner = "own";
                    //if (ent.GetControllerId() == enemycontroler) owner = "enemy";
                    //if (ent.GetControllerId() == enemycontroler && ent.GetZone() == HRCardZone.HAND) Helpfunctions.Instance.logg("enemy card in hand: " + "cardindeck: " + cardid + " " + ent.GetName());
                    //if (cardid != CardDB.cardIDEnum.None) Helpfunctions.Instance.logg("cardindeck: " + cardid + " " + ent.GetName() + " " + ent.GetZone() + " " + owner + " " + ent.GetCardType());
                    if (cardid != CardDB.cardIDEnum.None)
                    {
                        if (ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.GRAVEYARD)
                        {
                            GraveYardItem gyi = new GraveYardItem(cardid, ent.EntityId, ent.ControllerId == owncontroler);
                            graveYard.Add(gyi);
                        }

                        int creator = ent.CreatorId;
                        if (creator != 0 && creator != owncontroler && creator != enemycontroler) continue; //if creator is someone else, it was not played

                        if (ent.ControllerId == owncontroler) //or controler?
                        {
                            if (ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.GRAVEYARD)
                            {
                                ownCards.Add(cardid);
                            }
                        }
                        else
                        {
                            if (ent.GetZone() == Triton.Game.Mapping.TAG_ZONE.GRAVEYARD)
                            {
                                enemyCards.Add(cardid);
                            }
                        }
                    }
                }

            }

            Probabilitymaker.Instance.setOwnCards(ownCards);
            Probabilitymaker.Instance.setEnemyCards(enemyCards);
            bool isTurnStart = false;
            if (Ai.Instance.nextMoveGuess.mana == -100)
            {
                isTurnStart = true;
                Ai.Instance.updateTwoTurnSim();
            }
            Probabilitymaker.Instance.setGraveYard(graveYard, isTurnStart);

        }

        private void updateBehaveString(Behavior botbase)
        {
            this.botbehave = "rush";
            if (botbase is BehaviorFace) this.botbehave = "face";
            if (botbase is BehaviorControl) this.botbehave = "control";
            if (botbase is BehaviorMana) this.botbehave = "mana";
            this.botbehave += " " + Ai.Instance.maxwide;
            this.botbehave += " face " + ComboBreaker.Instance.attackFaceHP;
            if (Settings.Instance.secondTurnAmount > 0)
            {
                if (Ai.Instance.nextMoveGuess.mana == -100)
                {
                    Ai.Instance.updateTwoTurnSim();
                }
                this.botbehave += " twoturnsim " + Settings.Instance.secondTurnAmount + " ntss " + Settings.Instance.nextTurnDeep + " " + Settings.Instance.nextTurnMaxWide + " " + Settings.Instance.nextTurnTotalBoards;
            }

            if (Settings.Instance.playarround)
            {
                this.botbehave += " playaround";
                this.botbehave += " " + Settings.Instance.playaroundprob + " " + Settings.Instance.playaroundprob2;
            }

            this.botbehave += " ets " + Settings.Instance.enemyTurnMaxWide;

            if (Settings.Instance.simEnemySecondTurn)
            {
                this.botbehave += " ets2 " + Settings.Instance.enemyTurnMaxWideSecondTime;
                this.botbehave += " ents " + Settings.Instance.enemySecondTurnMaxWide;
            }

            if (Settings.Instance.useSecretsPlayArround)
            {
                this.botbehave += " secret";
            }

            if (Settings.Instance.secondweight != 0.5f)
            {
                this.botbehave += " weight " + (int)(Settings.Instance.secondweight * 100f);
            }

            if (Settings.Instance.simulatePlacement)
            {
                this.botbehave += " plcmnt";
            }


        }


        public static int getLastAffected(int entityid)
        {

            List<HSCard> allEntitys = TritonHs.GetAllCards();

            foreach (HSCard ent in allEntitys)
            {
                if (ent.GetTag(GAME_TAG.LAST_AFFECTED_BY) == entityid) return ent.GetTag(GAME_TAG.ENTITY_ID);
            }

            return 0;
        }

        public static int getCardTarget(int entityid)
        {

            List<HSCard> allEntitys = TritonHs.GetAllCards();

            foreach (HSCard ent in allEntitys)
            {
                if (ent.GetTag(GAME_TAG.ENTITY_ID) == entityid) return ent.GetTag(GAME_TAG.CARD_TARGET);
            }

            return 0;

        }


        //public void testExternal()
        //{
        //    BoardTester bt = new BoardTester("");
        //    this.currentMana = Hrtprozis.Instance.currentMana;
        //    this.ownMaxMana = Hrtprozis.Instance.ownMaxMana;
        //    this.enemyMaxMana = Hrtprozis.Instance.enemyMaxMana;
        //    printstuff(true);
        //    readActionFile();
        //}

        private void printstuff(Playfield p, bool runEx)
        {
            string dtimes = DateTime.Now.ToString("HH:mm:ss:ffff");
            String completeBoardString = p.getCompleteBoardForSimulating(this.botbehave, this.versionnumber, dtimes);
            
            Helpfunctions.Instance.logg(completeBoardString);

            if (runEx)
            {
                Ai.Instance.currentCalculatedBoard = dtimes;
                Helpfunctions.Instance.resetBuffer();
                Helpfunctions.Instance.writeBufferToActionFile();
                Helpfunctions.Instance.resetBuffer();

                Helpfunctions.Instance.writeToBuffer(completeBoardString);
                Helpfunctions.Instance.writeBufferToFile();
            }

        }

        public bool readActionFile(bool passiveWaiting = false)
        {
            bool readed = true;
            List<string> alist = new List<string>();
            float value = 0f;
            string boardnumm = "-1";
            this.waitingForSilver = true;
            int trackingchoice = 0;
            int trackingstate = 0;
            while (readed)
            {
                try
                {
                    string data = System.IO.File.ReadAllText(Settings.Instance.path + "actionstodo.txt");
                    if (data != "" && data != "<EoF>" && data.EndsWith("<EoF>"))
                    {
                        data = data.Replace("<EoF>", "");
                        //Helpfunctions.Instance.ErrorLog(data);
                        Helpfunctions.Instance.resetBuffer();
                        Helpfunctions.Instance.writeBufferToActionFile();
                        alist.AddRange(data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
                        string board = alist[0];
                        if (board.StartsWith("board "))
                        {
                            boardnumm = (board.Split(' ')[1].Split(' ')[0]);
                            alist.RemoveAt(0);
                            if (boardnumm != Ai.Instance.currentCalculatedBoard)
                            {
                                if (passiveWaiting)
                                {
                                    System.Threading.Thread.Sleep(10);
                                    return false;
                                }
                                continue;
                            }
                        }
                        string first = alist[0];
                        if (first.StartsWith("value "))
                        {
                            value = float.Parse((first.Split(' ')[1].Split(' ')[0]));
                            alist.RemoveAt(0);
                        }

                        first = alist[0];

                        if (first.StartsWith("discover "))
                        {
                            string trackingstuff = first.Replace("discover ", "");
                            trackingchoice = Convert.ToInt32(trackingstuff.Split(',')[0]);
                            trackingstate = Convert.ToInt32(trackingstuff.Split(',')[1]);
                            alist.RemoveAt(0);
                        }
                        readed = false;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(10);
                        if (passiveWaiting)
                        {
                            return false;
                        }
                    }

                }
                catch
                {
                    System.Threading.Thread.Sleep(10);
                }

            }
            this.waitingForSilver = false;
            Helpfunctions.Instance.logg("received " + boardnumm + " actions to do:");
            Ai.Instance.currentCalculatedBoard = "0";
            Playfield p = new Playfield();
            List<Action> aclist = new List<Action>();

            foreach (string a in alist)
            {
                aclist.Add(new Action(a, p));
                Helpfunctions.Instance.logg(a);
            }

            Ai.Instance.setBestMoves(aclist, value, trackingchoice, trackingstate);

            return true;
        }


    }


    // the ai :D
    //please ask/write me if you use this in your project

}
