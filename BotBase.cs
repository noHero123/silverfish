using HREngine.API;
using HREngine.API.Utilities;
using System;
using System.Collections.Generic;

namespace HREngine.Bots
{

   public abstract class Bot : API.IBot
   {
       private int stopAfterWins = 30;
       private int concedeLvl = 5; // the rank, till you want to concede
       private int dirtytarget = -1;
       private int dirtychoice = -1;
       private string choiceCardId = "";
       DateTime starttime = DateTime.Now;
       Silverfish sf;
       bool enemyConcede = false;

       public bool learnmode = true;
       public bool printlearnmode = true;

       Behavior behave = new BehaviorControl();



       //crawlerstuff
       bool isgoingtoconcede = false;
       int wins = 0;
       int loses = 0;

       public Bot()
       {
           behave = this.getBotBehave();
           OnVictory = HandleWining;
            OnLost = HandleLosing;
            OnBattleStateUpdate = HandleOnBattleStateUpdate;
            OnMulliganStateUpdate = HandleBattleMulliganPhase;
            starttime = DateTime.Now;
            bool concede = false;
            bool writeToSingleFile = false;

            try
            {
                this.learnmode = (HRSettings.Get.ReadSetting("silverfish.xml", "uai.wwuaid") == "true") ? true : false;
                if (this.learnmode)
                {
                    Helpfunctions.Instance.ErrorLog("Learn mode is ON");
                }
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("a wild error occurrs! cant read the settings...");
            }
            try
            {
                concede = (HRSettings.Get.ReadSetting("silverfish.xml", "uai.autoconcede") == "true") ? true : false;
                writeToSingleFile = (HRSettings.Get.ReadSetting("silverfish.xml", "uai.singleLog") == "true") ? true : false;
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("a wild error occurrs! cant read the settings...");
            }
            try
            {
                this.concedeLvl = Convert.ToInt32((HRSettings.Get.ReadSetting("silverfish.xml", "uai.concedelvl")));
                if (this.concedeLvl >= 20) this.concedeLvl = 20;
                if (concede)
                {
                    Helpfunctions.Instance.ErrorLog("concede till rank " + concedeLvl);
                }
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("cant read your concede-Lvl");
            }

            try
            {
                this.stopAfterWins = Convert.ToInt32((HRSettings.Get.ReadSetting("silverfish.xml", "uai.stopwin")));
                if (this.stopAfterWins <= 0) this.stopAfterWins = 10000;
                Helpfunctions.Instance.ErrorLog("stop after " + stopAfterWins + " wins");
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("cant read stop after # of wins");
            }

            try
            {
                this.enemyConcede = (HRSettings.Get.ReadSetting("silverfish.xml", "uai.enemyconcede") == "true") ? true : false;
                if (this.enemyConcede) Helpfunctions.Instance.ErrorLog("concede whether enemy has lethal");
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("cant read enemy concede");
            }

            this.sf = new Silverfish(writeToSingleFile);


            CardDB cdb = CardDB.Instance;
            if (cdb.installedWrong) return;


            Mulligan.Instance.setAutoConcede(concede);

            sf.setnewLoggFile();

            try
            {
                int enfacehp = Convert.ToInt32((HRSettings.Get.ReadSetting("silverfish.xml", "uai.enemyfacehp")));
                Helpfunctions.Instance.ErrorLog("set enemy-face-hp to: " + enfacehp);
                ComboBreaker.Instance.attackFaceHP = enfacehp;
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("error in reading enemy-face-hp");
            }

            try
            {
                int mxwde = Convert.ToInt32((HRSettings.Get.ReadSetting("silverfish.xml", "uai.maxwide")));
                if (mxwde != 3000)
                {
                    Ai.Instance.setMaxWide(mxwde);
                    Helpfunctions.Instance.ErrorLog("set maxwide to: " + mxwde);
                }
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("error in reading Maxwide from settings, please recheck the entry");
            }

            try
            {
                //bool twots = (HRSettings.Get.ReadSetting("silverfish.xml", "uai.simulateTwoTurns") == "true") ? true : false;
                int twotsamount = Convert.ToInt32((HRSettings.Get.ReadSetting("silverfish.xml", "uai.simulateTwoTurnCounter")));
                if (twotsamount < 0) twotsamount = 0;
                Ai.Instance.setTwoTurnSimulation(false, twotsamount);
                Helpfunctions.Instance.ErrorLog("calculate the second turn of the " + twotsamount + " best boards");


            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("error in reading two-turn-simulation from settings");
            }

            try
            {
                bool playaround = (HRSettings.Get.ReadSetting("silverfish.xml", "uai.playAround") == "true") ? true : false;
                int playaroundprob = Convert.ToInt32(HRSettings.Get.ReadSetting("silverfish.xml", "uai.playAroundProb"));
                if (playaroundprob > 100) playaroundprob = 100;
                if (playaroundprob < 0) playaroundprob = 0;

                int playaroundprob2 = Convert.ToInt32(HRSettings.Get.ReadSetting("silverfish.xml", "uai.playAroundProb2"));
                if (playaroundprob2 < playaroundprob) playaroundprob2 = playaroundprob;
                if (playaroundprob2 > 100) playaroundprob2 = 100;
                if (playaroundprob2 < 0) playaroundprob2 = 0;
                if (playaround)
                {
                    Ai.Instance.setPlayAround(playaround, playaroundprob, playaroundprob2);
                    Helpfunctions.Instance.ErrorLog("activated playaround");
                }

            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("error in reading play around settings");
            }

            Helpfunctions.Instance.ErrorLog("write to single log file is: " + writeToSingleFile);

            bool teststuff = false;
            bool printstuff = false;
            try
            {

                printstuff = (HRSettings.Get.ReadSetting("silverfish.xml", "uai.longteststuff") == "true") ? true : false;
                teststuff = (HRSettings.Get.ReadSetting("silverfish.xml", "uai.teststuff") == "true") ? true : false;
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("something went wrong with simulating stuff!");
            }
            Helpfunctions.Instance.ErrorLog("----------------------------");
            Helpfunctions.Instance.ErrorLog("you are running uai V" + sf.versionnumber);
            Helpfunctions.Instance.ErrorLog("----------------------------");

            if (teststuff)
            {
                Ai.Instance.autoTester(behave, printstuff);
            }
            writeSettings();
        }

        int lossedtodo = 0;
        int KeepConcede = 0;
        int oldwin = 0;
        private bool autoconcede()
        {
            int totalwin = this.wins;
            int totallose = this.loses;
            /*if ((totalwin + totallose - KeepConcede) != 0)
            {
                Helpfunctions.Instance.ErrorLog("#info: win:" + totalwin + " concede:" + KeepConcede + " lose:" + (totallose - KeepConcede) + " real winrate:" + (totalwin * 100 / (totalwin + totallose - KeepConcede)));
            }*/


            if (HREngine.API.Utilities.HRSettings.Get.SelectedGameMode != HRGameMode.RANKED_PLAY) return false;
            int curlvl = HRPlayer.GetLocalPlayer().GetRank();

            if (this.oldwin != totalwin)
            {
                this.oldwin = totalwin;
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
                Helpfunctions.Instance.ErrorLog("not today!!!");
                this.isgoingtoconcede = true;
                return true;
            }
            return false;
        }

        private bool concedeVSenemy(string ownh, string enemyh)
        {
            if (!(HREngine.API.Utilities.HRSettings.Get.SelectedGameMode == HRGameMode.RANKED_PLAY || HREngine.API.Utilities.HRSettings.Get.SelectedGameMode == HRGameMode.UNRANKED_PLAY)) return false;
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
                string path = (HRSettings.Get.CustomRuleFilePath).Remove(HRSettings.Get.CustomRuleFilePath.Length - 13) + "Common" + System.IO.Path.DirectorySeparatorChar;
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
                string path = (HRSettings.Get.CustomRuleFilePath).Remove(HRSettings.Get.CustomRuleFilePath.Length - 13) + "Common" + System.IO.Path.DirectorySeparatorChar;
                System.IO.File.WriteAllLines(path + "Settings.ini", newlines.ToArray());
            }
            catch
            {
                Helpfunctions.Instance.logg("cant write Settings.ini");
            }
        }

        private void writeSettings()
        {
            string version = sf.versionnumber;
            string[] lines = new string[0] { };
            try
            {
                string path = (HRSettings.Get.CustomRuleFilePath).Remove(HRSettings.Get.CustomRuleFilePath.Length - 13) + "Common" + System.IO.Path.DirectorySeparatorChar;
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
                string path = (HRSettings.Get.CustomRuleFilePath).Remove(HRSettings.Get.CustomRuleFilePath.Length - 13) + "Common" + System.IO.Path.DirectorySeparatorChar;
                System.IO.File.WriteAllLines(path + "Settings.ini", newlines.ToArray());
            }
            catch
            {
                Helpfunctions.Instance.logg("cant write Settings.ini");
            }
        }

        private HREngine.API.Actions.ActionBase HandleBattleMulliganPhase()
        {
            if (this.learnmode)
            {
                return new HREngine.API.Actions.MakeNothingAction();
            }
            //Helpfunctions.Instance.ErrorLog("handle mulligan");

            if ((TAG_MULLIGAN)HRPlayer.GetLocalPlayer().GetTag(HRGameTag.MULLIGAN_STATE) != TAG_MULLIGAN.INPUT)
            {
                //Helpfunctions.Instance.ErrorLog("but we have to wait :D");
                return null;
            }

            if (HRMulligan.IsMulliganActive())
            {
                var list = HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.HAND);
                if (Mulligan.Instance.hasmulliganrules())
                {
                    HRPlayer enemyPlayer = HRPlayer.GetEnemyPlayer();
                    HRPlayer ownPlayer = HRPlayer.GetLocalPlayer();
                    string enemName = Hrtprozis.Instance.heroIDtoName(enemyPlayer.GetHeroCard().GetEntity().GetCardId());
                    string ownName = Hrtprozis.Instance.heroIDtoName(ownPlayer.GetHeroCard().GetEntity().GetCardId());
                    List<Mulligan.CardIDEntity> celist = new List<Mulligan.CardIDEntity>();
                    foreach (var item in list)
                    {
                        if (item.GetEntity().GetCardId() != "GAME_005")// dont mulligan coin
                        {
                            celist.Add(new Mulligan.CardIDEntity(item.GetEntity().GetCardId(), item.GetEntity().GetEntityId()));
                        }
                    }
                    List<int> mullientitys = Mulligan.Instance.whatShouldIMulligan(celist, ownName, enemName);
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

                //writeSettings();

                if (Mulligan.Instance.loserLoserLoser)
                {
                    HRPlayer enemyPlayer = HRPlayer.GetEnemyPlayer();
                    HRPlayer ownPlayer = HRPlayer.GetLocalPlayer();
                    string enemName = Hrtprozis.Instance.heroIDtoName(enemyPlayer.GetHeroCard().GetEntity().GetCardId());
                    string ownName = Hrtprozis.Instance.heroIDtoName(ownPlayer.GetHeroCard().GetEntity().GetCardId());
                    if (!autoconcede())
                    {
                        concedeVSenemy(ownName, enemName);
                    }
                    
                }

                return null;
                //HRMulligan.EndMulligan();
            }
            return null;
        }

        /// <summary>
        /// [EN]
        /// This handler is executed when the local player turn is active.
        ///
        /// [DE]
        /// Dieses Event wird ausgelöst wenn der Spieler am Zug ist.
        /// </summary>
        private HREngine.API.Actions.ActionBase HandleOnBattleStateUpdate()
        {

            try
            {

                if (this.isgoingtoconcede)
                {
                    return new HREngine.API.Actions.ConcedeAction();
                }

                if (this.learnmode && (HRBattle.IsInTargetMode() || HRChoice.IsChoiceActive()))
                {
                    return new HREngine.API.Actions.MakeNothingAction();
                }

                if (HRBattle.IsInTargetMode() && dirtytarget >= 0)
                {
                    Helpfunctions.Instance.ErrorLog("dirty targeting...");
                    HREntity target = getEntityWithNumber(dirtytarget);

                    dirtytarget = -1;

                    return new HREngine.API.Actions.TargetAction(target);
                }
                if (HRChoice.IsChoiceActive())
                {
                    if (this.dirtychoice >= 1)
                    {
                        List<HREntity> choices = HRChoice.GetChoiceCards();
                        int choice = this.dirtychoice;
                        this.dirtychoice = -1;
                        string ccId = this.choiceCardId;
                        this.choiceCardId = "";
                        HREntity target = choices[choice - 1];
                        if (ccId == "EX1_160")
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "EX1_160b") target = hre;
                                if (choice == 2 && hre.GetCardId() == "EX1_160a") target = hre;
                            }
                        }
                        if (ccId == "NEW1_008")
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "NEW1_008a") target = hre;
                                if (choice == 2 && hre.GetCardId() == "NEW1_008b") target = hre;
                            }
                        }
                        if (ccId == "EX1_178")
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "EX1_178a") target = hre;
                                if (choice == 2 && hre.GetCardId() == "EX1_178b") target = hre;
                            }
                        }
                        if (ccId == "EX1_573")
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "EX1_573a") target = hre;
                                if (choice == 2 && hre.GetCardId() == "EX1_573b") target = hre;
                            }
                        }
                        if (ccId == "EX1_165")//druid of the claw
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "EX1_165t1") target = hre;
                                if (choice == 2 && hre.GetCardId() == "EX1_165t2") target = hre;
                            }
                        }
                        if (ccId == "EX1_166")//keeper of the grove
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "EX1_166a") target = hre;
                                if (choice == 2 && hre.GetCardId() == "EX1_166b") target = hre;
                            }
                        }
                        if (ccId == "EX1_155")
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "EX1_155a") target = hre;
                                if (choice == 2 && hre.GetCardId() == "EX1_155b") target = hre;
                            }
                        }
                        if (ccId == "EX1_164")
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "EX1_164a") target = hre;
                                if (choice == 2 && hre.GetCardId() == "EX1_164b") target = hre;
                            }
                        }
                        if (ccId == "New1_007")//starfall
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "New1_007b") target = hre;
                                if (choice == 2 && hre.GetCardId() == "New1_007a") target = hre;
                            }
                        }
                        if (ccId == "EX1_154")//warth
                        {
                            foreach (HREntity hre in choices)
                            {
                                if (choice == 1 && hre.GetCardId() == "EX1_154a") target = hre;
                                if (choice == 2 && hre.GetCardId() == "EX1_154b") target = hre;
                            }
                        }
                        Helpfunctions.Instance.logg("chooses the card: " + target.GetCardId());
                        return new HREngine.API.Actions.ChoiceAction(target);
                    }
                    else
                    {
                        //Todo: ultimate tracking-simulation!
                        List<HREntity> choices = HRChoice.GetChoiceCards();
                        Random r = new Random();
                        int choice = r.Next(0, choices.Count);
                        Helpfunctions.Instance.logg("chooses a random card");
                        return new HREngine.API.Actions.ChoiceAction(choices[choice]);
                    }
                }

                this.printlearnmode = sf.updateEverything(behave);

                if (this.learnmode)
                {
                    if (this.printlearnmode)
                    {
                        Ai.Instance.simmulateWholeTurnandPrint();
                    }
                    this.printlearnmode = false;
                    return new HREngine.API.Actions.MakeNothingAction();
                }

                if (Ai.Instance.bestmoveValue <= -900) { return new HREngine.API.Actions.ConcedeAction(); }

                Action moveTodo = Ai.Instance.bestmove;

                if (moveTodo == null)
                {
                    Helpfunctions.Instance.ErrorLog("end turn");
                    return null;
                }
                Helpfunctions.Instance.ErrorLog("play action");
                moveTodo.print();
                if (moveTodo.actionType == actionEnum.playcard)
                {
                    HRCard cardtoplay = getCardWithNumber(moveTodo.card.entity);
                    if (moveTodo.target != null)
                    {
                        HREntity target = getEntityWithNumber(moveTodo.target.entitiyID);
                        Helpfunctions.Instance.ErrorLog("play: " + cardtoplay.GetEntity().GetName() + " target: " + target.GetName());
                        Helpfunctions.Instance.logg("play: " + cardtoplay.GetEntity().GetName() + " target: " + target.GetName() + " choice: " + moveTodo.druidchoice);
                        if (moveTodo.druidchoice >= 1)
                        {
                            this.dirtytarget = moveTodo.target.entitiyID;
                            this.dirtychoice = moveTodo.druidchoice; //1=leftcard, 2= rightcard
                            this.choiceCardId = moveTodo.card.card.cardIDenum.ToString();

                        }
                        if (moveTodo.card.card.type == CardDB.cardtype.MOB)
                        {
                            return new HREngine.API.Actions.PlayCardAction(cardtoplay, target, moveTodo.place);
                        }

                        return new HREngine.API.Actions.PlayCardAction(cardtoplay, target);

                    }
                    else
                    {
                        Helpfunctions.Instance.ErrorLog("play: " + cardtoplay.GetEntity().GetName() + " target nothing");
                        Helpfunctions.Instance.logg("play: " + cardtoplay.GetEntity().GetName() + " choice: " + moveTodo.druidchoice);
                        if (moveTodo.druidchoice >= 1)
                        {
                            this.dirtychoice = moveTodo.druidchoice; //1=leftcard, 2= rightcard
                            this.choiceCardId = moveTodo.card.card.cardIDenum.ToString();

                        }
                        if (moveTodo.card.card.type == CardDB.cardtype.MOB)
                        {
                            return new HREngine.API.Actions.PlayCardAction(cardtoplay, null, moveTodo.place);
                        }
                        return new HREngine.API.Actions.PlayCardAction(cardtoplay);
                    }

                }

                if (moveTodo.actionType == actionEnum.attackWithMinion)
                {
                    HREntity attacker = getEntityWithNumber(moveTodo.own.entitiyID);
                    HREntity target = getEntityWithNumber(moveTodo.target.entitiyID);
                    Helpfunctions.Instance.ErrorLog("minion attack: " + attacker.GetName() + " target: " + target.GetName());
                    Helpfunctions.Instance.logg("minion attack: " + attacker.GetName() + " target: " + target.GetName());
                    return new HREngine.API.Actions.AttackAction(attacker, target);

                }

                if (moveTodo.actionType == actionEnum.attackWithHero)
                {
                    HREntity attacker = getEntityWithNumber(moveTodo.own.entitiyID );
                    HREntity target = getEntityWithNumber(moveTodo.target.entitiyID);
                    this.dirtytarget = moveTodo.target.entitiyID;
                    Helpfunctions.Instance.ErrorLog("heroattack: " + attacker.GetName() + " target: " + target.GetName());
                    Helpfunctions.Instance.logg("heroattack: " + attacker.GetName() + " target: " + target.GetName());
                    if (HRPlayer.GetLocalPlayer().HasWeapon())
                    {
                        Helpfunctions.Instance.ErrorLog("hero attack with weapon");
                        return new HREngine.API.Actions.AttackAction(HRPlayer.GetLocalPlayer().GetWeaponCard().GetEntity(), target);
                    }
                    Helpfunctions.Instance.ErrorLog("hero attack without weapon");
                    //Helpfunctions.Instance.ErrorLog("attacker entity: " + HRPlayer.GetLocalPlayer().GetHero().GetEntityId());
                    //return new HREngine.API.Actions.AttackAction(HRPlayer.GetLocalPlayer().GetHero(), target);
                    return new HREngine.API.Actions.PlayCardAction(HRPlayer.GetLocalPlayer().GetHeroCard(), target);
                }

                if (moveTodo.actionType == actionEnum.useHeroPower)
                {
                    HRCard cardtoplay = HRPlayer.GetLocalPlayer().GetHeroPower().GetCard();

                    if (moveTodo.target != null)
                    {
                        HREntity target = getEntityWithNumber(moveTodo.target.entitiyID);
                        Helpfunctions.Instance.ErrorLog("use ablitiy: " + cardtoplay.GetEntity().GetName() + " target " + target.GetName());
                        Helpfunctions.Instance.logg("use ablitiy: " + cardtoplay.GetEntity().GetName() + " target " + target.GetName());
                        return new HREngine.API.Actions.PlayCardAction(cardtoplay, target);

                    }
                    else
                    {
                        Helpfunctions.Instance.ErrorLog("use ablitiy: " + cardtoplay.GetEntity().GetName() + " target nothing");
                        Helpfunctions.Instance.logg("use ablitiy: " + cardtoplay.GetEntity().GetName() + " target nothing");
                        return new HREngine.API.Actions.PlayCardAction(cardtoplay);
                    }
                }

            }
            catch (Exception Exception)
            {
                Helpfunctions.Instance.ErrorLog(Exception.Message);
                Helpfunctions.Instance.ErrorLog(Environment.StackTrace);
                if (this.learnmode)
                {
                    return new HREngine.API.Actions.MakeNothingAction();
                }
            }
            return null;
            //HRBattle.FinishRound();
        }

        private HREngine.API.Actions.ActionBase HandleWining()
        {
            this.wins++;
            if (this.isgoingtoconcede)
            {
                this.isgoingtoconcede = false;
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
            if (totalwin >= this.stopAfterWins)
            {
                if (HREngine.API.Utilities.HRSettings.Get.SelectedGameMode == HRGameMode.ARENA) return null;
                Helpfunctions.Instance.ErrorLog("we have done our " + totalwin + " wins! lets finish this!");
                disableRelogger();
                Helpfunctions.Instance.ErrorLog("relogger is disabled");
                HREngine.API.HRGame.OpenScene(HRGameMode.ARENA);
                return null;
            }
            return null;
        }

        private HREngine.API.Actions.ActionBase HandleLosing()
        {
            this.loses++;
            if (this.isgoingtoconcede)
            {
                this.isgoingtoconcede = false;
                this.KeepConcede++;
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
            return null;
        }

        private HREntity getEntityWithNumber(int number)
        {
            foreach (HREntity e in this.getallEntitys())
            {
                if (number == e.GetEntityId()) return e;
            }
            return null;
        }

        private HRCard getCardWithNumber(int number)
        {
            foreach (HRCard e in this.getallHandCards())
            {
                if (number == e.GetEntity().GetEntityId()) return e;
            }
            return null;
        }

        private List<HREntity> getallEntitys()
        {
            List<HREntity> result = new List<HREntity>();
            HREntity ownhero = HRPlayer.GetLocalPlayer().GetHero();
            HREntity enemyhero = HRPlayer.GetEnemyPlayer().GetHero();
            HREntity ownHeroAbility = HRPlayer.GetLocalPlayer().GetHeroPower();
            List<HRCard> list2 = HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.PLAY);
            List<HRCard> list3 = HRCard.GetCards(HRPlayer.GetEnemyPlayer(), HRCardZone.PLAY);

            result.Add(ownhero);
            result.Add(enemyhero);
            result.Add(ownHeroAbility);

            foreach (HRCard item in list2)
            {
                result.Add(item.GetEntity());
            }
            foreach (HRCard item in list3)
            {
                result.Add(item.GetEntity());
            }




            return result;
        }

        private List<HRCard> getallHandCards()
        {
            List<HRCard> list = HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.HAND);
            return list;
        }


        protected virtual HRCard GetMinionByPriority(HRCard lastMinion = null)
        {
            return null;
        }

        protected virtual Behavior getBotBehave()
        {
            return null;
        }

    }


    
}