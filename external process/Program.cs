using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HREngine.Bots
{
    class Program
    {
        static void Main(string[] args)
        { 
            Bot b = new Bot();
            bool readed =false;
            while(!readed)
            {
                try
                {
                    string data = System.IO.File.ReadAllText("crrntbrd.txt");
                    if (data != "" && data != "<EoF>")
                    {
                        data = data.Replace("<EoF>", "");
                        Helpfunctions.Instance.resetBuffer();
                        Helpfunctions.Instance.writeBufferToFile();
                        //readed = true;
                        b.doData(data);
                    }
                }
                catch
                {
                    
                }
                System.Threading.Thread.Sleep(10);
            }

            Console.ReadLine();
        }
    }

    public class Bot
    {
        private int concedeLvl = 5; // the rank, till you want to concede
        PenalityManager penman = PenalityManager.Instance;
        DateTime starttime = DateTime.Now;
        Silverfish sf;
        Behavior behave = new BehaviorControl();

        public Bot()
        {
            starttime = DateTime.Now;
            Settings set = Settings.Instance;
            this.sf = Silverfish.Instance;
            set.setSettings();
            sf.setnewLoggFile();

            bool teststuff = true;
            bool printstuff = true;

            if (teststuff)
            {
                Helpfunctions.Instance.logg("teststuff");
                Playfield p = new Playfield();
                Ai.Instance.autoTester( printstuff);
            }
            Helpfunctions.Instance.ErrorLog("wait for board...");
        }

        public void doData(string data)
        {
            Ai.Instance.updateTwoTurnSim();
            Ai.Instance.autoTester(false, data);
            Helpfunctions.Instance.resetBuffer();
            Helpfunctions.Instance.writeToBuffer("board " + Ai.Instance.currentCalculatedBoard);
            Helpfunctions.Instance.writeToBuffer("value " + Ai.Instance.bestmoveValue);
            Helpfunctions.Instance.writeToBuffer("discover " + Ai.Instance.bestTracking + "," + Ai.Instance.bestTrackingStatus);
            
            if (Ai.Instance.bestmove != null)
            {
                Ai.Instance.bestmove.print(true);
                foreach (Action a in Ai.Instance.bestActions)
                {
                    a.print(true);
                }
            }
            Helpfunctions.Instance.writeBufferToActionFile();
            Ai.Instance.currentCalculatedBoard = "1";
            Helpfunctions.Instance.ErrorLog("wait for next board...");

            //sf.readActionFile();
        }

        public void testing(int start)
        {
            for (int i = start; i < 900; i++)
            {
                Handmanager.Instance.anzcards = 1;
                Handmanager.Instance.handCards.Clear();
                Handmanager.Handcard hc = new Handmanager.Handcard();
                hc.manacost = 1;
                hc.position = 1;
                hc.entity = 122;
                hc.card = CardDB.Instance.getCardDataFromID((CardDB.cardIDEnum)i);
                Handmanager.Instance.handCards.Add(hc);
                Helpfunctions.Instance.ErrorLog("test " + i + " " + hc.card.name + " " + hc.card.cardIDenum);
                if (hc.card.sim_card == null)
                {
                    Helpfunctions.Instance.logg("cant test " + i + " " + hc.card.name);
                }
                else
                {
                    Ai.Instance.dosomethingclever(this.behave);
                }
            }
        }

    }

    public class Silverfish
    {
        public string versionnumber = "116.01";
        private bool singleLog = false;
        private string botbehave = "rush";

        Settings sttngs = Settings.Instance;

        List<Minion> ownMinions = new List<Minion>();
        List<Minion> enemyMinions = new List<Minion>();
        List<Handmanager.Handcard> handCards = new List<Handmanager.Handcard>();
        int ownPlayerController = 0;
        List<string> ownSecretList = new List<string>();
        int enemySecretCount = 0;

        int currentMana = 0;
        int ownMaxMana = 0;
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
            Helpfunctions.Instance.ErrorLog("init Silverfish");
            string path = "";
            //System.IO.Directory.CreateDirectory(path);
            sttngs.setFilePath("");

            if (!singleLog)
            {
                sttngs.setLoggPath(path);
            }
            else
            {
                sttngs.setLoggPath("");
                sttngs.setLoggFile("UILogg.txt");
                try
                {
                    Helpfunctions.Instance.createNewLoggfile();
                }
                    catch
                {
                    }
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

        public void readActionFile(bool passiveWaiting = false)
        {
            Ai.Instance.nextMoveGuess = new Playfield();
            bool readed = true;
            List<string> alist = new List<string>();
            float value = 0f;
            string boardnumm = "-1";
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
                            /*if (boardnumm != Ai.Instance.currentCalculatedBoard)
                            {
                                if (passiveWaiting)
                                {
                                    System.Threading.Thread.Sleep(10);
                                    return;
                                }
                                continue;
                            }*/
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
                            trackingchoice = Convert.ToInt32(first.Split(',')[0]);
                            trackingstate = Convert.ToInt32(first.Split(',')[1]);
                            alist.RemoveAt(0);
                        }

                        readed = false;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(10);
                        if (passiveWaiting)
                        {
                            return;
                        }
                    }

                }
                catch
                {
                    System.Threading.Thread.Sleep(10);
                }

            }
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

        }

        public static int getLastAffected(int entityid)
        {
            return 0;
        }

        public static int getCardTarget(int entityid)
        {
            return 0;
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

        public void createNewLoggfile()
        {
            //System.IO.File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, "");
        }

        public void logg(string s)
        {


            /*if (!writelogg) return;
            try
            {
                using (StreamWriter sw = File.AppendText(Settings.Instance.logpath + Settings.Instance.logfile))
                {
                    sw.WriteLine(s);
                }
            }
            catch { }*/
            Console.WriteLine(s);
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
            //HREngine.API.Utilities.HRLog.Write(s);
            Console.WriteLine(s);
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
            this.ErrorLog("write to action file: "+ sendbuffer);
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
