﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using HSRangerLib;

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

        public static string SettingsPath
        {
            get
            {
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

    public class Bot : BotBase
    {
        public override string Description
        {
            get
            {
                return "Author of HR-Silver-translator: Rush4xDev " + "\r\n" +
                       "This is silver fish A.I. module.";
            }
        }

        //private int stopAfterWins = 30;
        private int concedeLvl = 5; // the rank, till you want to concede
        private int dirtytarget = -1;
        private int dirtychoice = -1;
        private string choiceCardId = "";
        DateTime starttime = DateTime.Now;
        Silverfish sf;


        Behavior behave = new BehaviorControl();


        //
        bool isgoingtoconcede = false;
        int wins = 0;
        int loses = 0;

        public Bot()
        {

            //it's very important to set HasBestMoveAI property to true
            //or Hearthranger will never call OnQueryBestMove !
            base.HasBestMoveAI = true;

            starttime = DateTime.Now;

            Settings set = Settings.Instance;
            this.sf = Silverfish.Instance;
            behave = set.setSettings();
            sf.setnewLoggFile();
            CardDB cdb = CardDB.Instance;
            if (cdb.installedWrong)
            {
                Helpfunctions.Instance.ErrorLog("cant find CardDB");
                return;
            }

            bool teststuff = false; // set to true, to run a testfile (requires test.txt file in folder where _cardDB.txt file is located)
            bool printstuff = false; // if true, the best board of the tested file is printet stepp by stepp

            Helpfunctions.Instance.ErrorLog("----------------------------");
            Helpfunctions.Instance.ErrorLog("you are now running uai V" + sf.versionnumber);
            Helpfunctions.Instance.ErrorLog("----------------------------");
            //Helpfunctions.Instance.ErrorLog("test... " + Settings.Instance.logpath + Settings.Instance.logfile);
            if (Settings.Instance.useExternalProcess) Helpfunctions.Instance.ErrorLog("YOU USE SILVER.EXE FOR CALCULATION, MAKE SURE YOU STARTED IT!");
            if (Settings.Instance.useExternalProcess) Helpfunctions.Instance.ErrorLog("SILVER.EXE IS LOCATED IN: " + Settings.Instance.path);



            if (teststuff)//run autotester for developpers
            {
                Ai.Instance.autoTester(printstuff);
            }
            writeSettings();
        }

        /// <summary>
        /// HRanger Code
        /// invoke when game enter mulligan
        /// </summary>
        /// <param name="e">
        ///     e.card_list -- mulligan card list
        ///     e.replace_list -- toggle card list (output)
        /// </param>
        public override void OnGameMulligan(GameMulliganEventArgs e)
        {
            if (e.handled)
            {
                return;
            }

            //set e.handled to true, 
            //then bot will toggle cards by e.replace_list 
            //and will not use internal mulligan logic anymore.
            e.handled = true;

            if (Settings.Instance.learnmode)
            {

                e.handled = false;
                return;
            }



            var list = e.card_list;

            Entity enemyPlayer = base.EnemyHero;
            Entity ownPlayer = base.FriendHero;

            string enemName = Hrtprozis.Instance.heroIDtoName(enemyPlayer.CardId);
            string ownName = Hrtprozis.Instance.heroIDtoName(ownPlayer.CardId);

            if (Mulligan.Instance.hasmulliganrules(ownName, enemName))
            {

                List<Mulligan.CardIDEntity> celist = new List<Mulligan.CardIDEntity>();
                foreach (var item in list)
                {
                    if (item.CardId != "GAME_005")// dont mulligan coin
                    {
                        celist.Add(new Mulligan.CardIDEntity(item.CardId, item.EntityId));
                    }
                }
                List<int> mullientitys = Mulligan.Instance.whatShouldIMulligan(celist, ownName, enemName);
                foreach (var item in list)
                {
                    if (mullientitys.Contains(item.EntityId))
                    {
                        Helpfunctions.Instance.ErrorLog("Rejecting Mulligan Card " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(item.CardId) + " because of your rules");
                        //toggle this card
                        e.replace_list.Add(item);
                    }
                }

            }
            else
            {
                foreach (var item in list)
                {
                    if (item.Cost >= 4)
                    {
                        Helpfunctions.Instance.ErrorLog("Rejecting Mulligan Card " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(item.CardId) + " because it cost is >= 4.");

                        e.replace_list.Add(item);

                    }
                    if (item.CardId == "EX1_308" || item.CardId == "EX1_622" || item.CardId == "EX1_005")
                    {
                        Helpfunctions.Instance.ErrorLog("Rejecting Mulligan Card " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(item.CardId) + " because it is soulfire or shadow word: death");
                        e.replace_list.Add(item);
                    }
                }
            }


            sf.setnewLoggFile();

            if (Mulligan.Instance.loserLoserLoser)
            {
                if (!autoconcede())
                {
                    concedeVSenemy(ownName, enemName);
                }

                //set concede flag
                e.concede = this.isgoingtoconcede;
            }
        }

        /// <summary>
        /// invoke when drafting arena cards (including hero draft)
        /// </summary>
        /// <param name="e"></param>
        public override void OnGameArenaDraft(GameArenaDraftEventArgs e)
        {
            //must set e.handled to true if you handle draft in this function.
            e.handled = false;
        }

        /// <summary>
        /// invoke when game starts.
        /// </summary>
        /// <param name="e">e.deck_list -- all cards id in the deck.</param>
        public override void OnGameStart(GameStartEventArgs e)
        {
            //do nothing here
        }

        /// <summary>
        /// invoke when game ends.
        /// </summary>
        /// <param name="e"></param>
        public override void OnGameOver(GameOverEventArgs e)
        {
            if (e.win)
            {
                HandleWining();
            }
            else if (e.loss || e.concede)
            {
                HandleLosing(e.concede);
            }
        }

        private HSRangerLib.BotAction CreateRangerConcedeAction()
        {
            HSRangerLib.BotAction ranger_action = new HSRangerLib.BotAction();
            ranger_action.Actor = base.FriendHero;
            ranger_action.Type = BotActionType.CONCEDE;

            return ranger_action;
        }

        private HSRangerLib.BotActionType GetRangerActionType(Entity actor, Entity target, actionEnum sf_action_type)
        {

            if (sf_action_type == actionEnum.endturn)
            {
                return BotActionType.END_TURN;
            }

            if (sf_action_type == actionEnum.useHeroPower)
            {
                return BotActionType.CAST_ABILITY;
            }

            if (sf_action_type == actionEnum.attackWithHero)
            {
                return BotActionType.HERO_ATTACK;
            }

            if (sf_action_type == actionEnum.attackWithMinion)
            {
                if (actor.Zone == HSRangerLib.TAG_ZONE.HAND && actor.IsMinion)
                {
                    return BotActionType.CAST_MINION;// that should not occour >_>
                }
                else if (actor.Zone == HSRangerLib.TAG_ZONE.PLAY && actor.IsMinion)
                {
                    return BotActionType.MINION_ATTACK;
                }
            }

            if (sf_action_type == actionEnum.playcard)
            {
                if (actor.Zone == HSRangerLib.TAG_ZONE.HAND)
                {
                    if (actor.IsMinion)
                    {
                        return BotActionType.CAST_MINION;
                    }
                    else if (actor.IsWeapon)
                    {
                        return BotActionType.CAST_WEAPON;
                    }
                    else
                    {
                        return BotActionType.CAST_SPELL;
                    }
                }
                else if (actor.Zone == HSRangerLib.TAG_ZONE.PLAY)
                {
                    if (actor.IsMinion)
                    {
                        return BotActionType.MINION_ATTACK;
                    }
                    else if (actor.IsWeapon)
                    {
                        return BotActionType.HERO_ATTACK;
                    }
                }
            }

            if (target != null)
            {
                Helpfunctions.Instance.ErrorLog("GetActionType: wrong action type! " +
                                            sf_action_type.ToString() + ": " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(actor.CardId)
                                                         + " target: " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(target.CardId));
            }
            else
            {
                Helpfunctions.Instance.ErrorLog("GetActionType: wrong action type! " +
                                            sf_action_type.ToString() + ": " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(actor.CardId)
                                                         + " target none.");
            }


            return BotActionType.END_TURN;
        }

        private HSRangerLib.BotAction ConvertToRangerAction(Action moveTodo)
        {
            HSRangerLib.BotAction ranger_action = new HSRangerLib.BotAction();

            switch (moveTodo.actionType)
            {
                case actionEnum.endturn:
                    break;
                case actionEnum.playcard:
                    ranger_action.Actor = getCardWithNumber(moveTodo.card.entity);
                    break;
                case actionEnum.attackWithHero:
                    ranger_action.Actor = base.FriendHero;
                    break;
                case actionEnum.useHeroPower:
                    ranger_action.Actor = base.FriendHeroPower;
                    break;
                case actionEnum.attackWithMinion:
                    ranger_action.Actor = getEntityWithNumber(moveTodo.own.entitiyID);
                    break;
                default:
                    break;
            }

            if (moveTodo.target != null)
            {
                ranger_action.Target = getEntityWithNumber(moveTodo.target.entitiyID);
            }

            ranger_action.Type = GetRangerActionType(ranger_action.Actor, ranger_action.Target, moveTodo.actionType);

            if (moveTodo.druidchoice >= 1)
            {
                ranger_action.Choice = moveTodo.druidchoice;//1=leftcard, 2= rightcard
            }

            ranger_action.Index = moveTodo.place;


            if (moveTodo.target != null)
            {
                Helpfunctions.Instance.ErrorLog(moveTodo.actionType.ToString() + ": " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(ranger_action.Actor.CardId)
                                                 + " target: " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(ranger_action.Target.CardId));
                Helpfunctions.Instance.logg(moveTodo.actionType.ToString() + ": " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(ranger_action.Actor.CardId)
                                                 + " target: " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(ranger_action.Target.CardId)
                                                 + " choice: " + moveTodo.druidchoice + " place" + moveTodo.place);


            }
            else
            {
                Helpfunctions.Instance.ErrorLog(moveTodo.actionType.ToString() + ": " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(ranger_action.Actor.CardId)
                                                 + " target nothing");
                Helpfunctions.Instance.logg(moveTodo.actionType.ToString() + ": " + HSRangerLib.CardDefDB.Instance.GetCardEnglishName(ranger_action.Actor.CardId)
                                                 + " choice: " + moveTodo.druidchoice + " place" + moveTodo.place);
            }


            return ranger_action;
        }

        /// <summary>
        /// if uses extern a.i.,
        /// invoke when hearthranger did all the actions.
        /// </summary>
        /// <param name="e"></param>
        public override void OnQueryBestMove(QueryBestMoveEventArgs e)
        {

            //don't forget to set HasBestMoveAI property to true in class constructor.
            //or Hearthranger will never query best move !
            //base.HasBestMoveAI = true;
            e.handled = true;
            HSRangerLib.BotAction ranger_action;

            try
            {
                if (this.isgoingtoconcede)
                {
                    if (HSRangerLib.RangerBotSettings.CurrentSettingsGameType == HSRangerLib.enGameType.The_Arena)
                    {
                        this.isgoingtoconcede = false;
                    }
                    else
                    {
                        ranger_action = CreateRangerConcedeAction();
                        e.action_list.Add(ranger_action);
                        return;
                    }
                }
                if (Settings.Instance.learnmode)
                {
                    e.handled = false;
                    return;
                }

                bool templearn = sf.updateEverything(this, behave, Settings.Instance.useExternalProcess, false); // cant use passive waiting (in this mode i return nothing)
                if (templearn == true) Settings.Instance.printlearnmode = true;



                if (Settings.Instance.learnmode)
                {
                    if (Settings.Instance.printlearnmode)
                    {
                        Ai.Instance.simmulateWholeTurnandPrint();
                    }
                    Settings.Instance.printlearnmode = false;

                    e.handled = false;
                    return;
                }



                if (Ai.Instance.bestmoveValue <= -900 && Settings.Instance.enemyConcede)
                {
                    e.action_list.Add(CreateRangerConcedeAction());
                    return;
                }

                Action moveTodo = Ai.Instance.bestmove;

                if (moveTodo == null || moveTodo.actionType == actionEnum.endturn)
                {
                    //simply clear action list, hearthranger bot will endturn if no action can do.
                    e.action_list.Clear();
                    return;
                }

                Helpfunctions.Instance.ErrorLog("play action");
                moveTodo.print();

                e.action_list.Add(ConvertToRangerAction(moveTodo));
            }
            catch (Exception Exception)
            {
                Helpfunctions.Instance.ErrorLog(Exception.Message);
                Helpfunctions.Instance.ErrorLog(Environment.StackTrace);
                if (Settings.Instance.learnmode)
                {
                    e.action_list.Clear();
                    return;
                }
            }
            return;
        }

        public override void OnActionDone(ActionDoneEventArgs e)
        {
            //do nothing here            
        }



        int lossedtodo = 0;
        int KeepConcede = 0;
        int oldwin = 0;
        private bool autoconcede()
        {
            if (HSRangerLib.RangerBotSettings.CurrentSettingsGameType == HSRangerLib.enGameType.The_Arena) return false;
            if (HSRangerLib.RangerBotSettings.CurrentSettingsGameType == HSRangerLib.enGameType.Play_Ranked) return false;
            int totalwin = this.wins;
            int totallose = this.loses;
            /*if ((totalwin + totallose - KeepConcede) != 0)
            {
                Helpfunctions.Instance.ErrorLog("#info: win:" + totalwin + " concede:" + KeepConcede + " lose:" + (totallose - KeepConcede) + " real winrate:" + (totalwin * 100 / (totalwin + totallose - KeepConcede)));
            }*/



            int curlvl = gameState.CurrentRank;

            if (curlvl > this.concedeLvl)
            {
                this.lossedtodo = 0;
                return false;
            }

            if (this.oldwin != totalwin)
            {
                this.oldwin = totalwin;
                if (this.lossedtodo > 0)
                {
                    this.lossedtodo--;
                }
                Helpfunctions.Instance.ErrorLog("not today!! (you won a game)");
                this.isgoingtoconcede = true;
                return true;
            }

            if (this.lossedtodo > 0)
            {
                this.lossedtodo--;
                Helpfunctions.Instance.ErrorLog("not today!");
                this.isgoingtoconcede = true;
                return true;
            }

            if (curlvl < this.concedeLvl)
            {
                this.lossedtodo = 3;
                Helpfunctions.Instance.ErrorLog("your rank is " + curlvl + " targeted rank is " + this.concedeLvl + " -> concede!");
                Helpfunctions.Instance.ErrorLog("not today!!!");
                this.isgoingtoconcede = true;
                return true;
            }
            return false;
        }

        private bool concedeVSenemy(string ownh, string enemyh)
        {
            if (HSRangerLib.RangerBotSettings.CurrentSettingsGameType == HSRangerLib.enGameType.The_Arena) return false;
            if (HSRangerLib.RangerBotSettings.CurrentSettingsGameType == HSRangerLib.enGameType.Play_Ranked) return false;

            if (Mulligan.Instance.shouldConcede(Hrtprozis.Instance.heroNametoEnum(ownh), Hrtprozis.Instance.heroNametoEnum(enemyh)))
            {
                Helpfunctions.Instance.ErrorLog("not today!!!!");
                writeSettings();
                this.isgoingtoconcede = true;
                return true;
            }
            return false;
        }

        private void disableRelogger()
        {
            string version = sf.versionnumber;
            int totalwin = 0;
            int totallose = 0;
            string[] lines = new string[0] { };
            try
            {
                string path = SiverFishBotPath.SettingsPath;
                //string path = (HRSettings.Get.CustomRuleFilePath).Remove(HRSettings.Get.CustomRuleFilePath.Length - 13) + "Common" + System.IO.Path.DirectorySeparatorChar;
                lines = System.IO.File.ReadAllLines(path + "Settings.ini");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find Settings.ini");
            }
            List<string> newlines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                string s = lines[i];

                if (s.Contains("client.relogger"))
                {
                    s = "client.relogger=false";
                }
                //Helpfunctions.Instance.ErrorLog("add " + s);
                newlines.Add(s);

            }


            try
            {
                string path = SiverFishBotPath.SettingsPath;
                System.IO.File.WriteAllLines(path + "Settings.ini", newlines.ToArray());
            }
            catch
            {
                Helpfunctions.Instance.logg("cant write Settings.ini");
            }
        }

        private void writeSettings()
        {
            return;
            string version = sf.versionnumber;
            string[] lines = new string[0] { };
            try
            {
                string path = SiverFishBotPath.SettingsPath;
                lines = System.IO.File.ReadAllLines(path + "Settings.ini");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find Settings.ini");
            }
            List<string> newlines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                string s = lines[i];

                if (s.Contains("uai.version"))
                {
                    s = "uai.version=V" + version;
                }

                if (s.Contains("uai.concedes"))
                {
                    s = "uai.concedes=" + KeepConcede;
                }

                if (s.Contains("uai.wins"))
                {
                    s = "uai.wins=" + this.wins;
                }
                if (s.Contains("uai.loses"))
                {
                    s = "uai.loses=" + this.loses;
                }
                if (s.Contains("uai.winrate"))
                {
                    s = "uai.winrate=" + 0;
                    double winr = 0;
                    if ((this.wins + this.loses - KeepConcede) != 0)
                    {
                        winr = ((double)(this.wins * 100) / (double)(this.wins + this.loses - KeepConcede));
                        s = "uai.winrate=" + Math.Round(winr, 2);
                    }

                }
                if (s.Contains("uai.winph"))
                {
                    s = "uai.winph=" + 0;
                    double winh = 0;
                    if ((DateTime.Now - starttime).TotalHours >= 0.001)
                    {

                        winh = (double)this.wins / (DateTime.Now - starttime).TotalHours;
                        s = "uai.winph=" + Math.Round(winh, 2);
                    }

                }
                //Helpfunctions.Instance.ErrorLog("add " + s);
                newlines.Add(s);

            }


            try
            {
                string path = SiverFishBotPath.SettingsPath;
                System.IO.File.WriteAllLines(path + "Settings.ini", newlines.ToArray());
            }
            catch
            {
                Helpfunctions.Instance.logg("cant write Settings.ini");
            }
        }

        private void resetSettings()
        {
            string[] lines = new string[0] { };
            try
            {
                string path = SiverFishBotPath.SettingsPath;
                lines = System.IO.File.ReadAllLines(path + "Settings.ini");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find Settings.ini");
            }
            List<string> newlines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                string s = lines[i];

                if (s.Contains("uai.reset"))
                {
                    s = "uai.reset=false";
                }

                if (s.Contains("uai.extern"))
                {
                    s = "uai.extern=true";
                }
                if (s.Contains("uai.passivewait"))
                {
                    s = "uai.passivewait=true";
                }
                if (s.Contains("uai.wwuaid"))
                {
                    s = "uai.wwuaid=false";
                }
                if (s.Contains("uai.enemyfacehp"))
                {
                    s = "uai.enemyfacehp=15";
                }
                if (s.Contains("uai.singleLog"))
                {
                    s = "uai.singleLog=false";
                }


                // advanced settings
                if (s.Contains("uai.maxwide"))
                {
                    s = "uai.maxwide=4000";
                }

                if (s.Contains("uai.maxBoardsEnemysTurn"))
                {
                    s = "uai.maxBoardsEnemysTurn=40";
                }

                if (s.Contains("uai.simulateTwoTurnCounter"))
                {
                    s = "uai.simulateTwoTurnCounter=1500";
                }

                if (s.Contains("uai.maxBoardsEnemysTurnSecondStepp"))
                {
                    s = "uai.maxBoardsEnemysTurnSecondStepp=200";
                }

                if (s.Contains("uai.nextTurnSimDeep"))
                {
                    s = "uai.nextTurnSimDeep=6";
                }
                if (s.Contains("uai.nextTurnSimWide"))
                {
                    s = "uai.nextTurnSimWide=20";
                }
                if (s.Contains("uai.nextTurnSimBoards"))
                {
                    s = "uai.nextTurnSimBoards=200";
                }

                if (s.Contains("uai.simulateEnemyOnSecondTurn"))
                {
                    s = "uai.simulateEnemyOnSecondTurn=true";
                }
                if (s.Contains("uai.maxBoardsEnemysSecondTurn"))
                {
                    s = "uai.maxBoardsEnemysSecondTurn=20";
                }

                if (s.Contains("uai.placement"))
                {
                    s = "uai.placement=true";
                }

                if (s.Contains("uai.secrets"))
                {
                    s = "uai.secrets=false";
                }

                if (s.Contains("uai.playAround"))
                {
                    s = "uai.playAround=false";
                }
                if (s.Contains("uai.playAroundProb"))
                {
                    s = "uai.playAroundProb=40";
                }
                if (s.Contains("uai.playAroundProb2"))
                {
                    s = "uai.playAroundProb2=80";
                }

                if (s.Contains("uai.secondweight"))
                {
                    s = "uai.secondweight=50";
                }
                newlines.Add(s);
                Helpfunctions.Instance.logg("add " + s);

            }


            try
            {
                string path = SiverFishBotPath.SettingsPath;
                System.IO.File.WriteAllLines(path + "Settings.ini", newlines.ToArray());
            }
            catch
            {
                Helpfunctions.Instance.logg("cant write Settings.ini");
            }
        }

        private void HandleWining()
        {
            this.wins++;
            if (this.isgoingtoconcede)
            {
                this.isgoingtoconcede = false;
            }
            writeSettings();
            writeTrigger(1);
            int totalwin = this.wins;
            int totallose = this.loses;
            if ((totalwin + totallose - KeepConcede) != 0)
            {
                Helpfunctions.Instance.ErrorLog("#info: win:" + totalwin + " concede:" + KeepConcede + " lose:" + (totallose - KeepConcede) + " real winrate:" + (totalwin * 100 / (totalwin + totallose - KeepConcede)));
            }
            else
            {
                Helpfunctions.Instance.ErrorLog("#info: win:" + totalwin + " concede:" + KeepConcede + " lose:" + (totallose - KeepConcede) + " real winrate: infinity!!!! (division by zero :D)");
            }
        }

        private void HandleLosing(bool is_concede)
        {
            this.loses++;
            if (is_concede)
            {
                this.isgoingtoconcede = false;
                writeTrigger(0);
                this.KeepConcede++;
            }
            else
            {
                writeTrigger(2);
            }
            writeSettings();
            int totalwin = this.wins;
            int totallose = this.loses;
            if ((totalwin + totallose - KeepConcede) != 0)
            {
                Helpfunctions.Instance.ErrorLog("#info: win:" + totalwin + " concede:" + KeepConcede + " lose:" + (totallose - KeepConcede) + " real winrate:" + (totalwin * 100 / (totalwin + totallose - KeepConcede)));
            }
            else
            {
                Helpfunctions.Instance.ErrorLog("#info: win:" + totalwin + " concede:" + KeepConcede + " lose:" + (totallose - KeepConcede) + " real winrate: infinity!!!! (division by zero :D)");
            }

        }

        private void writeTrigger(int what)
        {
            try
            {
                string path = SiverFishBotPath.SettingsPath + System.IO.Path.DirectorySeparatorChar + "uaibattletrigger.txt";
                string w = "concede";
                if (what == 1) w = "win";
                if (what == 2) w = "loss";
                System.IO.File.WriteAllText(path, w);
            }
            catch
            {
                Helpfunctions.Instance.logg("cant write trigger");
            }
        }

        private Entity getEntityWithNumber(int number)
        {
            foreach (Entity e in gameState.GameEntityList)
            {
                if (number == e.EntityId) return e;
            }
            return null;
        }

        private Entity getCardWithNumber(int number)
        {
            foreach (Entity e in base.FriendHand)
            {
                if (number == e.EntityId) return e;
            }
            return null;
        }

        private List<Entity> getallEntitys()
        {

            List<Entity> result = gameState.GameEntityList;

            return result;
        }

        private List<Entity> getallHandCards()
        {
            return base.FriendHand;
        }


    }

    public class Silverfish
    {
        public string versionnumber = "116.00";
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
        int ownsabo = 0;//number of saboteurplays  of our player (so enemy has the buff)
        int enemysabo = 0;//number of saboteurplays  of enemy player (so we have the buff)
        int ownFenciCoaches = 0; // number of Fencing Coach-debuffs on our player 


        private static HSRangerLib.GameState latestGameState;

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
            string path = SiverFishBotPath.AssemblyDirectory + System.IO.Path.DirectorySeparatorChar + "UltimateLogs" + System.IO.Path.DirectorySeparatorChar;
            System.IO.Directory.CreateDirectory(path);
            Helpfunctions.Instance.ErrorLog("setlogpath to:" + path);
            sttngs.setFilePath(SiverFishBotPath.AssemblyDirectory);

            Helpfunctions.Instance.ErrorLog(path);

            if (!singleLog)
            {

                sttngs.setLoggPath(path);
            }
            else
            {
                sttngs.setLoggPath(SiverFishBotPath.LogPath + System.IO.Path.DirectorySeparatorChar);
                sttngs.setLoggFile("UILogg.txt");
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

        public bool updateEverything(HSRangerLib.BotBase rangerbot, Behavior botbase, bool runExtern = false, bool passiveWait = false)
        {

            Helpfunctions.Instance.ErrorLog("updateEverything");
            latestGameState = rangerbot.gameState;

            this.updateBehaveString(botbase);

            Entity ownPlayer = rangerbot.FriendHero;
            Entity enemyPlayer = rangerbot.EnemyHero;
            ownPlayerController = ownPlayer.ControllerId;//ownPlayer.GetHero().GetControllerId()


            // create hero + minion data
            getHerostuff(rangerbot);
            getMinions(rangerbot);
            getHandcards(rangerbot);
            getDecks(rangerbot);

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

            Hrtprozis.Instance.updatePlayer(this.ownMaxMana, this.currentMana, this.cardsPlayedThisTurn, this.numMinionsPlayedThisTurn, this.numOptionPlayedThisTurn, this.ueberladung, ownHero.entitiyID, enemyHero.entitiyID, this.numberMinionsDiedThisTurn, this.ownCurrentOverload, this.enemyOverload, this.heroPowerUsesThisTurn, this.lockandload);
            Hrtprozis.Instance.setPlayereffects(this.ownDragonConsort, this.enemyDragonConsort, this.ownLoathebs, this.enemyLoathebs, this.ownMillhouse, this.enemyMillhouse, this.ownKirintor, this.ownPrepa, this.ownsabo, this.enemysabo, this.ownFenciCoaches);
            Hrtprozis.Instance.updateSecretStuff(this.ownSecretList, this.enemySecretCount);


            Hrtprozis.Instance.updateOwnHero(this.ownHeroWeapon, this.heroWeaponAttack, this.heroWeaponDurability, this.heroname, this.heroAbility, this.ownAbilityisReady, this.ownHero, this.ownHeroPowerUsesThisGame);
            Hrtprozis.Instance.updateEnemyHero(this.enemyHeroWeapon, this.enemyWeaponAttack, this.enemyWeaponDurability, this.enemyHeroname, this.enemyMaxMana, this.enemyAbility, this.enemyHero, this.enemyHeroPowerUsesThisGame);

            Hrtprozis.Instance.updateMinions(this.ownMinions, this.enemyMinions);
            Handmanager.Instance.setHandcards(this.handCards, this.anzcards, this.enemyAnzCards);

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
                lastpf = p;
            }
            else
            {
                lastpf = p;
            }

            p = new Playfield();//secrets have updated :D
            // calculate stuff
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
                printstuff(p, false);
                Ai.Instance.dosomethingclever(botbase);
            }

            Helpfunctions.Instance.ErrorLog("calculating ended! " + DateTime.Now.ToString("HH:mm:ss.ffff"));

            return true;
        }

        private void getHerostuff(HSRangerLib.BotBase rangerbot)
        {




            Dictionary<int, Entity> allEntitys = new Dictionary<int, Entity>();

            foreach (var item in rangerbot.gameState.GameEntityList)
            {
                allEntitys.Add(item.EntityId, item);
            }

            Entity ownPlayer = rangerbot.FriendHero;
            Entity enemyPlayer = rangerbot.EnemyHero;

            Entity ownhero = rangerbot.FriendHero;
            Entity enemyhero = rangerbot.EnemyHero;
            Entity ownHeroAbility = rangerbot.FriendHeroPower;

            //TODO GET HERO POWER USES!!!!!!
            heroPowerUsesThisTurn = ownHeroAbility.NumAttacksThisTurn; //Should work, as ownHeroAbility is an entity;
            ownHeroPowerUsesThisGame += heroPowerUsesThisTurn;
            enemyHeroPowerUsesThisGame += rangerbot.EnemyHeroPower.NumAttacksThisTurn;


            //TEST
            List<Entity> heroplayers = new List<Entity>();
            //heroplayers.Add(ownPlayer);
            //heroplayers.Add(enemyPlayer);
            heroplayers.Add(ownhero);
            heroplayers.Add(enemyhero);
            /*
            Helpfunctions.Instance.ErrorLog("# players/heros");
            foreach (var item in heroplayers)
            {
                Helpfunctions.Instance.ErrorLog(item.CardId + " e " + item.EntityId + " a " + item.Attached + " controler " + item.ControllerId + " creator " + item.CreatorId + " zone " + item.Zone + " zp " + item.ZonePosition);
                List<Entity> ents = item.Attachments;
                foreach (var item1 in ents)
                {
                    Helpfunctions.Instance.ErrorLog("#" + item1.CardId + " e " + item1.EntityId + " a " + item1.Attached + " controler " + item1.ControllerId + " creator " + item1.CreatorId + " zone " + item1.Zone);
                }
            }*/
            //TEST end

            //player stuff#########################
            //this.currentMana =ownPlayer.GetTag(HRGameTag.RESOURCES) - ownPlayer.GetTag(HRGameTag.RESOURCES_USED) + ownPlayer.GetTag(HRGameTag.TEMP_RESOURCES);
            this.currentMana = rangerbot.gameState.CurrentMana;
            this.ownMaxMana = rangerbot.gameState.LocalMaxMana;
            this.enemyMaxMana = rangerbot.gameState.RemoteMaxMana;
            //enemySecretCount = rangerbot.EnemySecrets.Count;
            //enemySecretCount = 0;
            //count enemy secrets
            enemySecretList.Clear();

            foreach (var item in rangerbot.EnemySecrets)
            {
                enemySecretList.Add(item.EntityId);
            }
            enemySecretCount = enemySecretList.Count;

            this.ownSecretList.Clear();

            foreach (var item in rangerbot.FriendSecrets)
            {
                this.ownSecretList.Add(item.CardId);
            }


            this.numMinionsPlayedThisTurn = rangerbot.gameState.NumMinionsPlayedThisTurn;
            this.cardsPlayedThisTurn = rangerbot.gameState.NumCardsPlayedThisTurn;


            //get weapon stuff
            this.ownHeroWeapon = "";
            this.heroWeaponAttack = 0;
            this.heroWeaponDurability = 0;

            this.ownHeroFatigue = ownhero.Fatigue;
            this.enemyHeroFatigue = enemyhero.Fatigue;

            this.ownDecksize = rangerbot.gameState.LocalDeckRemain;
            this.enemyDecksize = rangerbot.gameState.RemoteDeckRemain;


            //own hero stuff###########################
            int heroAtk = ownhero.ATK;
            int heroHp = ownhero.Health - ownhero.Damage;
            int heroDefence = ownhero.Armor;
            this.heroname = Hrtprozis.Instance.heroIDtoName(ownhero.CardId);

            bool heroImmuneToDamageWhileAttacking = false;
            bool herofrozen = ownhero.IsFrozen;
            int heroNumAttacksThisTurn = ownhero.NumAttacksThisTurn;
            bool heroHasWindfury = ownhero.HasWindfury;
            bool heroImmune = (ownhero.IsImmune);

            //Helpfunctions.Instance.ErrorLog(ownhero.GetName() + " ready params ex: " + exausted + " " + heroAtk + " " + numberofattacks + " " + herofrozen);


            if (rangerbot.FriendWeapon != null)
            {
                Entity weapon = rangerbot.FriendWeapon;
                this.ownHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(rangerbot.FriendWeapon.CardId)).name.ToString();
                this.heroWeaponAttack = weapon.ATK;
                this.heroWeaponDurability = weapon.Durability - weapon.Damage;//weapon.GetDurability();
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
            this.enemyHeroname = Hrtprozis.Instance.heroIDtoName(enemyhero.CardId);

            int enemyAtk = enemyhero.ATK;
            int enemyHp = enemyhero.Health - enemyhero.Damage;
            int enemyDefence = enemyhero.Armor;
            bool enemyfrozen = enemyhero.IsFrozen;
            bool enemyHeroImmune = (enemyhero.IsImmune);

            this.enemyHeroWeapon = "";
            this.enemyWeaponAttack = 0;
            this.enemyWeaponDurability = 0;
            if (rangerbot.EnemyWeapon != null)
            {
                Entity weapon = rangerbot.EnemyWeapon;
                this.enemyHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(weapon.CardId)).name.ToString();
                this.enemyWeaponAttack = weapon.ATK;
                this.enemyWeaponDurability = weapon.Durability;
            }


            //own hero power stuff###########################################################

            this.heroAbility = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(ownHeroAbility.CardId));
            this.ownAbilityisReady = (ownHeroAbility.IsExhausted) ? false : true; // if exhausted, ability is NOT ready

            //only because hearthranger desnt give me the data ;_; use the tag HEROPOWER_ACTIVATIONS_THIS_TURN instead! (of own player)
            //this.heroPowerUsesThisTurn = 10000;
            //if (this.ownAbilityisReady) this.heroPowerUsesThisTurn = 0;
            this.heroPowerUsesThisTurn = rangerbot.gameState.HeroPowerActivationsThisTurn;
            this.ownHeroPowerUsesThisGame = rangerbot.gameState.NumTimesHeroPowerUsedThisGame;

            this.enemyAbility = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(rangerbot.EnemyHeroPower.CardId));

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
            foreach (Entity ent in allEntitys.Values)
            {
                if (ent.Attached == this.ownHero.entitiyID && ent.Zone == HSRangerLib.TAG_ZONE.PLAY)
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.CardId);
                    int controler = ent.ControllerId;
                    int creator = ent.CreatorId;
                    miniEnchlist.Add(new miniEnch(id, creator, controler));
                }

            }

            this.ownHero.loadEnchantments(miniEnchlist, ownhero.ControllerId);

            miniEnchlist.Clear();

            foreach (Entity ent in allEntitys.Values)
            {
                if (ent.Attached == this.enemyHero.entitiyID && ent.Zone == HSRangerLib.TAG_ZONE.PLAY)
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.CardId);
                    int controler = ent.ControllerId;
                    int creator = ent.CreatorId;
                    miniEnchlist.Add(new miniEnch(id, creator, controler));
                }

            }

            this.enemyHero.loadEnchantments(miniEnchlist, enemyhero.ControllerId);
            //fastmode weapon correction:
            if (ownHero.Angr < this.heroWeaponAttack) ownHero.Angr = this.heroWeaponAttack;
            if (enemyHero.Angr < this.enemyWeaponAttack) enemyHero.Angr = this.enemyWeaponAttack;

            this.ueberladung = rangerbot.gameState.RecallOwnedNum;//was at the start, but copied it over here :D , its german for overload :D
            //Reading new values:###################################################################################################
            //ToDo:

            this.numberMinionsDiedThisTurn = rangerbot.gameState.NumMinionsKilledThisTurn;

            //this should work (hope i didnt oversee a value :D)

            this.ownCurrentOverload = rangerbot.gameState.RecalledCrystalsOwedNextTurn;// ownhero.GetTag(HRGameTag.RECALL);
            this.enemyOverload = 0;// enemyhero.GetTag(HRGameTag.RECALL_OWED);

            //count buffs off !!players!! (players and not heros) (like preparation, kirintor-buff and stuff)
            // hope this works, dont own these cards to test where its attached

            int owncontrollerblubb = ownhero.ControllerId + 1; // controller = 1 or 2, but entity with 1 is the board -> +1
            int enemycontrollerblubb = enemyhero.ControllerId + 1;// controller = 1 or 2, but entity with 1 is the board -> +1

            //will not work in Hearthranger!


            foreach (Entity ent in allEntitys.Values)
            {
                if (ent.Attached == owncontrollerblubb && ent.Zone == HSRangerLib.TAG_ZONE.PLAY) //1==play
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.CardId);
                    if (id == CardDB.cardIDEnum.NEW1_029t) this.enemyMillhouse++;//CHANGED!!!!
                    if (id == CardDB.cardIDEnum.FP1_030e) this.enemyLoathebs++; //CHANGED!!!!
                    if (id == CardDB.cardIDEnum.BRM_018e) this.ownDragonConsort++;
                    if (id == CardDB.cardIDEnum.EX1_612o) this.ownKirintor++;
                    if (id == CardDB.cardIDEnum.EX1_145o) this.ownPrepa++;
                    if (id == CardDB.cardIDEnum.AT_061e) this.lockandload++;
                    if (id == CardDB.cardIDEnum.AT_086e) this.enemysabo++;
                    if (id == CardDB.cardIDEnum.AT_115e) this.ownFenciCoaches++;

                }

                if (ent.Attached == enemycontrollerblubb && ent.Zone == HSRangerLib.TAG_ZONE.PLAY) //1==play
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.CardId);
                    if (id == CardDB.cardIDEnum.NEW1_029t) this.ownMillhouse++; //CHANGED!!!! (enemy has the buff-> we played millhouse)
                    if (id == CardDB.cardIDEnum.FP1_030e) this.ownLoathebs++; //CHANGED!!!!
                    if (id == CardDB.cardIDEnum.BRM_018e) this.enemyDragonConsort++;
                    // not needef for enemy, because its lasting only for his turn
                    //if (id == CardDB.cardIDEnum.EX1_612o) this.enemyKirintor++;
                    //if (id == CardDB.cardIDEnum.EX1_145o) this.enemyPrepa++;
                    if (id == CardDB.cardIDEnum.AT_086e) this.ownsabo++;
                }

            }
            this.lockandload = (rangerbot.gameState.LocalPlayerLockAndLoad)? 1 : 0;

            //TODO test Bolvar Fordragon but it will be on his card :D
            //Reading new values end################################

        }

        private void getMinions(HSRangerLib.BotBase rangerbot)
        {
            Dictionary<int, Entity> allEntitys = new Dictionary<int, Entity>();
            
            //TEST....................
            /*Helpfunctions.Instance.ErrorLog("# all");
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
            Entity ownPlayer = rangerbot.FriendHero;
            Entity enemyPlayer = rangerbot.EnemyHero;

            // ALL minions on Playfield:
            List<Entity> list = new List<Entity>();

            foreach (var item in rangerbot.FriendMinion)
            {
                list.Add(item);
            }

            foreach (var item in rangerbot.EnemyMinion)
            {
                list.Add(item);
            }


            List<Entity> enchantments = new List<Entity>();


            foreach (Entity item in list)
            {
                Entity entitiy = item;
                int zp = entitiy.ZonePosition;

                if (entitiy.CardType == TAG_CARDTYPE.MINION && zp >= 1)
                {
                    //Helpfunctions.Instance.ErrorLog("zonepos " + zp);
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.CardId));
                    Minion m = new Minion();
                    m.name = c.name;
                    m.handcard.card = c;
                    m.Angr = entitiy.ATK;
                    m.maxHp = entitiy.Health;
                    m.Hp = m.maxHp - entitiy.Damage;
                    if (m.Hp <= 0) continue;
                    m.wounded = false;
                    if (m.maxHp > m.Hp) m.wounded = true;


                    m.exhausted = entitiy.IsExhausted;

                    m.taunt = (entitiy.HasTaunt);

                    m.numAttacksThisTurn = entitiy.NumAttacksThisTurn;

                    int temp = entitiy.NumTurnsInPlay;
                    m.playedThisTurn = (temp == 0) ? true : false;

                    m.windfury = (entitiy.HasWindfury);

                    m.frozen = (entitiy.IsFrozen);

                    m.divineshild = (entitiy.HasDivineShield);

                    m.stealth = (entitiy.IsStealthed);

                    m.poisonous = (entitiy.IsPoisonous);

                    m.immune = (entitiy.IsImmune);

                    m.silenced = entitiy.IsSilenced;

                    m.spellpower = entitiy.SpellPower;

                    m.charge = 0;

                    if (!m.silenced && m.name == CardDB.cardName.southseadeckhand && entitiy.HasCharge) m.charge = 1;
                    if (!m.silenced && m.handcard.card.Charge) m.charge = 1;

                    m.zonepos = zp;

                    m.entitiyID = entitiy.EntityId;


                    Helpfunctions.Instance.ErrorLog( m.entitiyID +" " +  m.name + " ready params ex: " + m.exhausted + " charge: " +m.charge + " attcksthisturn: " + m.numAttacksThisTurn + " playedthisturn " + m.playedThisTurn );
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

                    foreach (Entity ent in item.Attachments)
                    {
                        CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.CardId);
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

                /*
                if (entitiy.GetCardType() == HRCardType.WEAPON)
                {
                    //Helpfunctions.Instance.ErrorLog("found weapon!");
                    if (entitiy.GetControllerId() == this.ownPlayerController) // OWN weapon
                    {
                        this.ownHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.GetCardId())).name.ToString();
                        this.heroWeaponAttack = entitiy.GetATK();
                        this.heroWeaponDurability = entitiy.GetDurability();
                        //this.heroImmuneToDamageWhileAttacking = false;


                    }
                    else
                    {
                        this.enemyHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.GetCardId())).name.ToString();
                        this.enemyWeaponAttack = entitiy.GetATK();
                        this.enemyWeaponDurability = entitiy.GetDurability();
                    }
                }

                if (entitiy.GetCardType() == HRCardType.ENCHANTMENT)
                {

                    enchantments.Add(entitiy);
                }
                 */


            }

            /*foreach (HRCard item in list)
            {
                foreach (HREntity e in item.GetEntity().GetEnchantments())
                {
                    enchantments.Add(e);
                }
            }


            // add enchantments to minions
            setEnchantments(enchantments);*/
        }

        private void setEnchantments(List<Entity> enchantments)
        {
            /*
            foreach (HREntity bhu in enchantments)
            {
                //create enchantment
                Enchantment ench = CardDB.getEnchantmentFromCardID(CardDB.Instance.cardIdstringToEnum(bhu.GetCardId()));
                ench.creator = bhu.GetCreatorId();
                ench.controllerOfCreator = bhu.GetControllerId();
                ench.cantBeDispelled = false;
                //if (bhu.c) ench.cantBeDispelled = true;

                foreach (Minion m in this.ownMinions)
                {
                    if (m.entitiyID == bhu.GetAttached())
                    {
                        m.enchantments.Add(ench);
                        //Helpfunctions.Instance.ErrorLog("add enchantment " +bhu.GetCardId()+" to: " + m.entitiyID);
                    }

                }

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entitiyID == bhu.GetAttached())
                    {
                        m.enchantments.Add(ench);
                    }

                }

            }
            */
        }

        private void getHandcards(HSRangerLib.BotBase rangerbot)
        {
            handCards.Clear();
            this.anzcards = 0;
            this.enemyAnzCards = 0;
            List<Entity> list = rangerbot.FriendHand;

            foreach (Entity item in list)
            {

                Entity entitiy = item;

                if (entitiy.ControllerId == this.ownPlayerController && entitiy.ZonePosition >= 1) // own handcard
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.CardId));

                    //c.cost = entitiy.GetCost();
                    //c.entityID = entitiy.GetEntityId();

                    Handmanager.Handcard hc = new Handmanager.Handcard();
                    hc.card = c;
                    hc.position = entitiy.ZonePosition;
                    hc.entity = entitiy.EntityId;
                    hc.manacost = entitiy.Cost;
                    hc.addattack = 0;

                    int attackchange = entitiy.ATK - c.Attack;
                    int hpchange = entitiy.Health - c.Health;
                    hc.addattack = attackchange;
                    hc.addHp = hpchange;

                    handCards.Add(hc);
                    this.anzcards++;
                }


            }

            Dictionary<int, Entity> allEntitys = new Dictionary<int, Entity>();

            foreach (var item in rangerbot.gameState.GameEntityList)
            {
                allEntitys.Add(item.EntityId, item);
            }


            foreach (Entity ent in allEntitys.Values)
            {
                if (ent.ControllerId != this.ownPlayerController && ent.ZonePosition >= 1 && ent.Zone == HSRangerLib.TAG_ZONE.HAND) // enemy handcard
                {
                    this.enemyAnzCards++;
                }
            }

        }

        private void getDecks(HSRangerLib.BotBase rangerbot)
        {
            Dictionary<int, Entity> allEntitys = new Dictionary<int, Entity>();

            foreach (var item in rangerbot.gameState.GameEntityList)
            {
                allEntitys.Add(item.EntityId, item);
            }

            int owncontroler = rangerbot.gameState.LocalControllerId;
            int enemycontroler = rangerbot.gameState.RemoteControllerId;
            List<CardDB.cardIDEnum> ownCards = new List<CardDB.cardIDEnum>();
            List<CardDB.cardIDEnum> enemyCards = new List<CardDB.cardIDEnum>();
            List<GraveYardItem> graveYard = new List<GraveYardItem>();

            foreach (Entity ent in allEntitys.Values)
            {
                if (ent.Zone == HSRangerLib.TAG_ZONE.SECRET && ent.ControllerId == enemycontroler) continue; // cant know enemy secrets :D
                if (ent.Zone == HSRangerLib.TAG_ZONE.DECK) continue;
                if (ent.CardType == HSRangerLib.TAG_CARDTYPE.MINION || ent.CardType == HSRangerLib.TAG_CARDTYPE.WEAPON || ent.CardType == HSRangerLib.TAG_CARDTYPE.ABILITY)
                {

                    CardDB.cardIDEnum cardid = CardDB.Instance.cardIdstringToEnum(ent.CardId);
                    //string owner = "own";
                    //if (ent.GetControllerId() == enemycontroler) owner = "enemy";
                    //if (ent.GetControllerId() == enemycontroler && ent.GetZone() == HRCardZone.HAND) Helpfunctions.Instance.logg("enemy card in hand: " + "cardindeck: " + cardid + " " + ent.GetName());
                    //if (cardid != CardDB.cardIDEnum.None) Helpfunctions.Instance.logg("cardindeck: " + cardid + " " + ent.GetName() + " " + ent.GetZone() + " " + owner + " " + ent.GetCardType());
                    if (cardid != CardDB.cardIDEnum.None)
                    {
                        if (ent.Zone == HSRangerLib.TAG_ZONE.GRAVEYARD)
                        {
                            GraveYardItem gyi = new GraveYardItem(cardid, ent.EntityId, ent.ControllerId == owncontroler);
                            graveYard.Add(gyi);
                        }

                        int creator = ent.CreatorId;
                        if (creator != 0 && creator != owncontroler && creator != enemycontroler) continue; //if creator is someone else, it was not played

                        if (ent.ControllerId == owncontroler) //or controler?
                        {
                            if (ent.Zone == HSRangerLib.TAG_ZONE.GRAVEYARD)
                            {
                                ownCards.Add(cardid);
                            }
                        }
                        else
                        {
                            if (ent.Zone == HSRangerLib.TAG_ZONE.GRAVEYARD)
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

            if (latestGameState != null)
            {
                foreach (var item in latestGameState.GameEntityList)
                {
                    if (item.LastAffectedById == entityid)
                    {
                        return item.EntityId;
                    }
                }
            }

            return 0;
        }

        public static int getCardTarget(int entityid)
        {

            if (latestGameState != null)
            {
                foreach (var item in latestGameState.GameEntityList)
                {
                    if (item.EntityId == entityid)
                    {
                        return item.CardTargetId;
                    }
                }
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

            Ai.Instance.setBestMoves(aclist, value);

            return true;
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
                return instance ?? (instance = new Helpfunctions());
            }
        }

        private Helpfunctions()
        {

            //System.IO.File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, "");
        }

        private bool writelogg = true;
        public void loggonoff(bool onoff)
        {
            //writelogg = onoff;
        }

        private bool filecreated = false;
        public void createNewLoggfile()
        {
            filecreated = false;

        }

        public void logg(string s)
        {

            if (!filecreated)
            {
                System.IO.File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, "");
                filecreated = true;
            }
            //if (!writelogg) return;
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

        private bool createdLogging = true;

        public void ErrorLog(string s)
        {
            if (!writelogg) return;
            if (createdLogging)
            {
                createdLogging = false;
                System.IO.File.WriteAllText(Settings.Instance.logpath + "Logging.txt", "");
            }

            try
            {
                using (StreamWriter sw = File.AppendText(Settings.Instance.logpath + "Logging.txt"))
                {
                    sw.WriteLine("#ConsoleLog: " + s);
                }
            }
            catch { }
        }

        string sendbuffer = "";
        public void resetBuffer()
        {
            this.sendbuffer = "";
        }

        public void writeToBuffer(string data)
        {
            this.sendbuffer += "\r\n" + data;
        }

        public void writeBufferToFile()
        {
            bool writed = true;
            this.sendbuffer += "<EoF>";
            //this.ErrorLog("write to crrntbrd file: " + sendbuffer);
            while (writed)
            {
                try
                {
                    System.IO.File.WriteAllText(Settings.Instance.path + "crrntbrd.txt", this.sendbuffer);
                    writed = false;
                }
                catch
                {
                    writed = true;
                }
            }
            this.sendbuffer = "";
        }

        public void writeBufferToActionFile()
        {
            bool writed = true;
            this.sendbuffer += "<EoF>";
            //this.ErrorLog("write to action file: "+ sendbuffer);
            while (writed)
            {
                try
                {
                    System.IO.File.WriteAllText(Settings.Instance.path + "actionstodo.txt", this.sendbuffer);
                    writed = false;
                }
                catch
                {
                    writed = true;
                }
            }
            this.sendbuffer = "";

        }

    }


    // the ai :D
    //please ask/write me if you use this in your project

}
