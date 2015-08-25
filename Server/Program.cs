using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace HREngine.Bots
{
    class Program
    {
        //todo (later)
        // ogre brut, dunemaul shaman, ogre ninja, mogor the ogre, == game-tag forgetfull

        //TODO secrets
        // resurrect,
        // blingtron 3000

        // minions to do: 
        //http://hearthstone.gamepedia.com/Random_effect

        static void Main(string[] args)
        { 
            //Bot b = new Bot();

            CardDB carddb = CardDB.Instance;
            HSServer hsc = new HSServer();

            hsc.start(100);

            /*
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
            }*/

            Console.ReadLine();
        }
    }


    public class HSServer
    {
        public int waitForClients = 0;

        public int serverListenPort = 11111;

        public IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

        public static void sendToClient(Socket client, String s)
        {
            byte[] msg = Encoding.ASCII.GetBytes(s);

            // Send the data through the socket.
            int bytesSent = client.Send(msg);
            //client.Send(msg, bytesSent, SocketFlags.None);
        }

        player p1;
        player p2;

         int ready = 0;

        HSBoard board;

        public void start(int maxgames)
        {
            //read ip + port
            String ip_port = "127.0.0.1:11111";
            try
            {
                ip_port = System.IO.File.ReadAllText("ip.txt").Replace("\r\n", "").Replace(" ", "") ;
            }
            catch
            {
            }
            
            try
            {
                string ipa = ip_port.Split(':')[0];
                serverListenPort = Convert.ToInt32(ip_port.Split(':')[1]);
                ipAddress = IPAddress.Parse(ipa);
            }
            catch
            {
                Console.WriteLine("Error: cant read ip + port, legal tupel is 127.0.0.1:11111");
            }
            //ip + port readed..................................

            DateTime start = DateTime.Now;
            int games = 0;
            ArrayList sockList = new ArrayList(2);
            ArrayList copyList = new ArrayList(2);
            Socket main = new Socket(AddressFamily.InterNetwork,
                               SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint iep = new IPEndPoint(ipAddress, serverListenPort);
            byte[] data = new byte[1024];
            string stringData;
            int recv;


            main.Bind(iep);
            main.Listen(2);
            
            Console.WriteLine("Waiting for 2 clients...");
            Socket client1 = main.Accept();
            IPEndPoint iep1 = (IPEndPoint)client1.RemoteEndPoint;
            client1.Send(Encoding.ASCII.GetBytes("connected with HSServer"));
            Console.WriteLine("Connected to {0}", iep1.ToString());
            sockList.Add(client1);

            //TODO remove comment!
            Console.WriteLine("Waiting for 1 more client...");
            Socket client2 = main.Accept();
            IPEndPoint iep2 = (IPEndPoint)client2.RemoteEndPoint;
            Console.WriteLine("Connected to {0}", iep2.ToString());
            client2.Send(Encoding.ASCII.GetBytes("connected with HSServer"));
            sockList.Add(client2);

            main.Close();
            Boolean running = true;
            string oldinstructions = "";
            int instructionCounter = 0;
            int roundcounter = 0;
            while (running)
            {

                copyList = new ArrayList(sockList);
                string win = "";
                if (this.board != null) win = this.board.getWinstring();
                Console.WriteLine("Monitoring {0} sockets..." + win, copyList.Count);
                Socket.Select(copyList, null, null, 100000000);//10000000
                
                foreach (Socket client in copyList)
                {
                    try
                    {
                        data = new byte[1024];
                        recv = client.Receive(data);
                        stringData = Encoding.ASCII.GetString(data, 0, recv);
                        Console.WriteLine("##############################Received: {0}", stringData);
                        if (recv == 0)
                        {
                            iep = (IPEndPoint)client.RemoteEndPoint;
                            Console.WriteLine("Client {0} disconnected.", iep.ToString());
                            client.Close();
                            sockList.Remove(client);
                            if (sockList.Count == 0)
                            {
                                Console.WriteLine("Last client disconnected, bye");
                                return;
                            }
                        }
                        else
                        {
                            if (stringData.StartsWith("hello:"))
                            {
                                int port = (client.RemoteEndPoint as IPEndPoint).Port;
                                //load player
                                if (this.p1 == null)
                                {
                                    
                                    p1 = new player(port, Directory.GetCurrentDirectory(),stringData.Split(':')[1]);
                                    p1.client = client;
                                    //TODO delte this: only for testing
                                    //p2 = new player(port, Directory.GetCurrentDirectory(), stringData.Split(':')[1]);
                                    //p2.client = client;
                                    //ready++;

                                    ready++;
                                }
                                else
                                {
                                    p2 = new player(port, Directory.GetCurrentDirectory(), stringData.Split(':')[1]);
                                    p2.client = client;
                                    ready++;
                                }

                                HSServer.sendToClient(client, "ok " + port);
                                Console.WriteLine("ok :" + ready);
                                if (ready == 2)
                                {
                                    //create board 
                                    board = new HSBoard(p1, p2);
                                }
                            }

                            if (stringData.EndsWith("<EoF>"))
                            {
                                //read instructions
                                List<string> instructions = new List<string>((stringData.Replace("<EoF>", "")).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
                                //we only need the first one!
                                string boardl = instructions[0];
                                string boardnumm = "0";
                                float value = 0f;
                                //foreach (string s in instructions)
                                {
                                    if (boardl.StartsWith("board "))
                                    {
                                        boardnumm = (boardl.Split(' ')[1].Split(' ')[0]);
                                        instructions.RemoveAt(0);
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
                                    string first = instructions[0];
                                    if (first.StartsWith("value "))
                                    {
                                        value = float.Parse((first.Split(' ')[1].Split(' ')[0]));
                                        instructions.RemoveAt(0);
                                    }
                                }
                                Playfield p = new Playfield(this.board.board);
                                List<Action> aclist = new List<Action>();
                                string instr="";;
                                foreach (string a in instructions)
                                {
                                    aclist.Add(new Action(a, p));
                                    instr += a;
                                   
                                }
                                if (instr == oldinstructions) 
                                {
                                    instructionCounter++;
                                }
                                else
                                {
                                    instructionCounter=0;
                                }
                                oldinstructions = instr;
                                if (instructionCounter >= 2)
                                {
                                    Console.WriteLine("ERROR#####################");
                                    running = false;
                                }

                                if (aclist.Count == 0)
                                {
                                    //end phase
                                    Console.WriteLine("END TURN#####################");
                                    this.board.endturn();
                                    instructionCounter = 0;
                                    oldinstructions = "1";
                                }
                                else
                                {


                                    roundcounter++;
                                    if (roundcounter >= 20) running = false;


                                    Helpfunctions.Instance.ErrorLog("DO ACTION:");
                                    aclist[0].print();
                                    //perform first action!
                                    
                                    if (aclist[0].card !=null)
                                    {
                                        int id = aclist[0].card.entity;
                                        Handmanager.Handcard hc = this.board.getcardFromcurrentPlayer(id);
                                        if (hc.card.Secret)
                                        {
                                            this.board.playedSecret(hc.card.cardIDenum, hc.entity);
                                        }
                                    }

                                    this.board.doAction(aclist[0]);



                                }

                                if (this.board.winner != "")
                                {
                                    String winsss = this.board.getWinstring();
                                    Console.WriteLine(winsss);
                                    games++;
                                    if (games < maxgames)
                                    {
                                        this.board.replay();
                                    }
                                    else
                                    {
                                        running = false;
                                    }
                                }
                                
                            }

                            
                        }

                    }
                    catch (ArgumentNullException ane)
                    {
                        Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    }
                    catch (SocketException se)
                    {
                        Console.WriteLine("SocketException : {0}", se.ToString());
                        sockList.Remove(client);
                        copyList = new ArrayList(sockList);
                        if (copyList.Count == 0)
                        {
                            running = false;
                        }
                    }
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    //}
                    


                }


            }

            Console.WriteLine("server closed");
            Console.WriteLine("time: " + (DateTime.Now - start).TotalSeconds + " seconds OR " + (DateTime.Now - start).TotalMinutes + " minutes");

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
            if (Ai.Instance.bestmove != null)
            {
                Ai.Instance.bestmove.print(true);
                foreach (Action a in Ai.Instance.bestActions)
                {
                    a.print(true);
                }
            }
            //Helpfunctions.Instance.writeBufferToActionFile();
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
        public string versionnumber = "115.12";
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
                        //Helpfunctions.Instance.writeBufferToActionFile();
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

            Ai.Instance.setBestMoves(aclist, value);

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


            if (!writelogg) return;
            /*try
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

        public void writeBufferToFile(Socket client)
        {
            bool writed = true;
            this.sendbuffer += "<EoF>";
            while (writed)
            {
                try
                {
                    HSServer.sendToClient(client, this.sendbuffer);
                    //System.IO.File.WriteAllText(Settings.Instance.path + "crrntbrd.txt", this.sendbuffer);
                    writed = false;
                }
                catch
                {
                    writed = true;
                }
            }
            this.sendbuffer = "";
        }

        public void writeBufferToActionFile(Socket client)
        {
            bool writed = true;
            this.sendbuffer += "<EoF>";
            this.ErrorLog("write to action file: "+ sendbuffer);
            while (writed)
            {
                try
                {
                    HSServer.sendToClient(client, this.sendbuffer);
                    //System.IO.File.WriteAllText(Settings.Instance.path + "actionstodo.txt", this.sendbuffer);
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

    public class CardDrawReturn
    {
        public List<Handmanager.Handcard> drawnCards;
        public List<Handmanager.Handcard> gravedCards;
        public int overdrawn = 0;

        public CardDrawReturn(List<Handmanager.Handcard> drawedCards, List<Handmanager.Handcard> cardsToGrave, int over)
        {
            this.drawnCards = drawedCards;
            this.gravedCards = cardsToGrave;
            this.overdrawn = over;
        }
    }

    public class player
    {

        public List<SecretItem> enemySecrets = new List<SecretItem>();
        public int wins = 0;
        public Socket client;
        public string settings = "control 5000 face 15 twoturnsim 1000 ntss 6 20 200 ets 40 ets2 200 ents 40 plcmnt";
        public int curMana = 0;
        public int maxMana = 0;
        public int socket = 0;
        public string folder = "a";
        public int nextEntity = 70;
        public List<Minion> ownminions = new List<Minion>();
        public List<CardDB.cardIDEnum> secrets = new List<CardDB.cardIDEnum>();
        public List<Handmanager.Handcard> deck = new List<Handmanager.Handcard>();
        public List<Handmanager.Handcard> grave = new List<Handmanager.Handcard>();
        public List<Handmanager.Handcard> hand = new List<Handmanager.Handcard>();
        public List<CardDB.cardIDEnum> usedCards = new List<CardDB.cardIDEnum>();
        public HeroEnum hero = HeroEnum.druid;
        public string heroname = "druid";
        public CardDB.Card heroAbility;
        public bool heroAbilityReady = true;
        CardDB cdb;

        //HERO:
        public int HEntity = 0;//TODO HERO ENTITY?
        public int ownheromaxhp = 30;
        public int ownHeroAttack = 0;
        public int ownherohp = 30;
        public int ownherodefence = 0;
        public bool ownHeroFrozen = false;
        public bool ownHeroimmunewhileattacking = false;
        public bool heroImmune = false;
        public bool herowindfury = false;
        public int ownheroattacksThisRound = 0;


        public int cardsPlayedThisTurn = 0;
        public int numMinionsPlayedThisTurn = 0;
        public int numOptionPlayedThisTurn = 0;
        public int overdrive = 0;
        
        public int numberMinionsDiedThisturn = 0;
        public int owncurrentRecall = 0;
        public int ownDragonConsort = 0;
        public int ownLoathebs = 0;
        public int ownMillhouse = 0;
        public int ownKirintor = 0;
        public int ownPrep = 0;

        public int ownFatigue = 0;

        public string ownHeroWeapon = "";
        public int ownHeroWeaponAttack = 0;
        public int ownHeroWeaponDurability = 0;
        
        //public int cardsPlayedThisTurn = 0;

        public player(int sock, string path, string fold)
        {
            cdb = CardDB.Instance;
            this.socket = sock;
            this.folder = fold;
            string deckToLoad = path + Path.DirectorySeparatorChar + fold + Path.DirectorySeparatorChar ;
            Console.WriteLine("path: " + deckToLoad);

            usedCards.Clear();
            loadCards(deckToLoad);

        }

        public void loadCards(string path)
        {
            try
            {
                this.settings = System.IO.File.ReadAllText(path + "simsettings.txt");
            }
            catch
            {
                this.settings = "control 5000 face 15 twoturnsim 1000 ntss 6 20 200 ets 40 ets2 200 ents 40 plcmnt";
            }

            string data = System.IO.File.ReadAllText(path+ "deck.txt");
            int i = 0;
            foreach (String ss in data.Split(new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                String s = ss;
                if (s.Contains(" ")) s = s.Split(' ')[0];
                if (s.Contains("/")) s = s.Split('/')[0];
                if (s.Contains(";")) s = s.Split(';')[0];
                //Console.WriteLine("read: " + s);
                if (i == 0)
                {
                    //hero:
                    
                    this.hero = Hrtprozis.Instance.heroNametoEnum(s);
                    this.heroname = s;
                    Console.WriteLine("heroname: "+s);
                    CardDB.cardIDEnum arbilityenum = CardDB.cardIDEnum.CS2_102;
                    if (this.hero == HeroEnum.druid) arbilityenum = CardDB.cardIDEnum.CS2_017;
                    if (this.hero == HeroEnum.hunter) arbilityenum = CardDB.cardIDEnum.DS1h_292;
                    if (this.hero == HeroEnum.lordjaraxxus) arbilityenum = CardDB.cardIDEnum.EX1_tk33;
                    if (this.hero == HeroEnum.mage) arbilityenum = CardDB.cardIDEnum.CS2_034;
                    if (this.hero == HeroEnum.pala) arbilityenum = CardDB.cardIDEnum.CS2_101;
                    if (this.hero == HeroEnum.priest) arbilityenum = CardDB.cardIDEnum.CS1h_001;
                    if (this.hero == HeroEnum.ragnarosthefirelord) arbilityenum = CardDB.cardIDEnum.BRM_027p;
                    if (this.hero == HeroEnum.shaman) arbilityenum = CardDB.cardIDEnum.CS2_049;
                    if (this.hero == HeroEnum.thief) arbilityenum = CardDB.cardIDEnum.CS2_083b;
                    if (this.hero == HeroEnum.warlock) arbilityenum = CardDB.cardIDEnum.CS2_056;
                    if (this.hero == HeroEnum.warrior) arbilityenum = CardDB.cardIDEnum.CS2_102;


                    this.heroAbility = CardDB.Instance.getCardDataFromID(arbilityenum);
                }
                else
                {

                    usedCards.Add(cdb.cardIdstringToEnum(s));
                }
                i++;
            }

            if (this.usedCards.Count != 30) Console.WriteLine("ERROR, deck contains not 30 cards");
            foreach (CardDB.cardIDEnum cie in usedCards)
            {
                //Console.WriteLine(cie.ToString() + "");
            }


        }


        public int initDeck( int entitiy)
        {
            grave.Clear();
            deck.Clear();
            hand.Clear();
            int e = entitiy;
            foreach (CardDB.cardIDEnum cie in usedCards)
            {
                Handmanager.Handcard card = new Handmanager.Handcard();
                card.card = cdb.getCardDataFromID(cie);
                card.manacost = card.card.cost;
                card.entity = e;
                e++;
                deck.Add(card);
            }

            return e;

        }


        public void printDeck()
        {
            Console.WriteLine("print deck for " + this.socket);
            foreach (Handmanager.Handcard cie in this.deck)
            {
                Console.WriteLine(cie.entity + " " + cie.card.cardIDenum.ToString());
            }
        }

        public void printHand()
        {
            Console.WriteLine("print Hand for " + this.socket);
            foreach (Handmanager.Handcard cie in this.hand)
            {
                Console.WriteLine("pos:"+cie.position + " mana:" + cie.manacost + " entity:" + cie.entity + " cardid:" + cie.card.cardIDenum.ToString() + " name:" + cie.card.name.ToString() );
            }
        }


        public CardDrawReturn drawCards(int howmany)
        {
            List<Handmanager.Handcard> drawedCards = new List<Handmanager.Handcard>();
            List<Handmanager.Handcard> diggedCards = new List<Handmanager.Handcard>();
            int overdraw = 0;
            for (int i = 0; i < howmany; i++)
            {
                if (this.deck.Count >= 1)
                {
                    Handmanager.Handcard hc = this.deck[0];
                    this.deck.RemoveAt(0);

                    if (this.hand.Count >= 10)
                    {
                        //add to grave
                        diggedCards.Add(hc);
                        this.grave.Add(hc);
                    }
                    else
                    {
                        //add to hand
                        hc.position = this.hand.Count+1;
                        this.hand.Add(hc);
                    }
                }
                else
                {
                    overdraw +=1;
                }
            }

            CardDrawReturn cdr = new CardDrawReturn(drawedCards, diggedCards, overdraw);
            return cdr;
        }

        public void addCardToHand(Handmanager.Handcard card)
        {
            if (this.hand.Count >= 10)
            {
                //add to grave
                this.grave.Add(card);
            }
            else
            {
                //add to hand
                card.position = this.hand.Count + 1;
                this.hand.Add(card);
            }
        }
    }


    public class HSBoard
    {
        player p1; //->current player = true!
        player p2;
        int nextentity = 10;
        Random rand = new Random();
        CardDB cdb = CardDB.Instance;
        Boolean currentplayer = true; //true-> p1 turn, false -> p2 turn
        public Playfield board;
        public string winner = "";
        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public int getrandom(int min, int max)
        {
            return rand.Next(min, max + 1);
        }


        public HSBoard(player pl1, player pl2)
        {
            //set player random
            p1 = pl1; 
            p2 = pl2;

            if (getrandom(0, 1) == 1)//other player begins
            {
                player p = p1;
                p1 = p2;
                p2 = p;
            }

            p1.HEntity = 3;
            p2.HEntity = 4;

            nextentity = 10;
            this.nextentity = p1.initDeck(this.nextentity);
            this.nextentity = p2.initDeck(this.nextentity);

            replay();
        }

        public void replay()
        {
            this.winner = "";
            //switch players
            player p = p1;
            p1 = p2;
            p2 = p;

            this.currentplayer = true;
            //init player decks...
            
            //shuffle
            this.Shuffle(p1.deck);
            this.Shuffle(p2.deck);

            p1.maxMana = 1;
            p1.curMana = 1;
            p2.maxMana = 0;
            p2.curMana = 0;
            this.updateHrtprozisAtStart();
            this.updateHandManagerAtStart();

            this.board = new Playfield();
            this.board.isServer = true;
            this.board.nextEntity = 2000;
            this.board.setDecksAndHands(new List<Handmanager.Handcard>(p1.deck), new List<Handmanager.Handcard>(p2.deck), new List<Handmanager.Handcard>(p2.hand));

            //start game... p1 draws 3 cards ( + one at start turn (not handled here)) 

            this.board.drawACard(CardDB.cardIDEnum.None, true);
            this.board.drawACard(CardDB.cardIDEnum.None, true);
            this.board.drawACard(CardDB.cardIDEnum.None, true);

            //p2 draws 4 cards + the coin (+ the one at start turn (not handled here))
            this.board.drawACard(CardDB.cardIDEnum.None, false);
            this.board.drawACard(CardDB.cardIDEnum.None, false);
            this.board.drawACard(CardDB.cardIDEnum.None, false);
            this.board.drawACard(CardDB.cardIDEnum.None, false);
            this.board.drawACard(CardDB.cardIDEnum.GAME_005, false);



            //TURN 1 STARTS!
            this.board.drawACard(CardDB.cardIDEnum.None, true);
            Console.WriteLine(this.board.getCompleteBoardForSimulating("startBoard:", "112", "now"));

            //this.board.swapAll();
            //Console.WriteLine(this.board.getCompleteBoardForSimulating("swapped", "112", "swapped"));
            //this.board.swapAll();

            sendCurrentBoardToClient();
        }


        public void playedSecret(CardDB.cardIDEnum secretid, int entity)
        {
            Console.WriteLine("1111111111111111111111111111111111111111111111111111111111111");
            Console.WriteLine("current player " + this.currentplayer + " played secret " + secretid);
            Console.WriteLine("1111111111111111111111111111111111111111111111111111111111111");
            player currentp = this.p2;
            player currentenemyp = this.p1;
            if (this.currentplayer)
            {
                currentp = this.p1;
                currentenemyp = this.p2;
            }
            SecretItem si = Probabilitymaker.Instance.getNewSecretGuessedItem(entity, currentp.hero);
            currentenemyp.enemySecrets.Add(si);
            
        }

        public void updateSecrets(Playfield old, Playfield newone)
        {

        }

        public Handmanager.Handcard getcardFromcurrentPlayer(int entityid)
        {
            Console.WriteLine("search for " + entityid);
            foreach (Handmanager.Handcard hc in board.owncards)
            {
                if (hc.entity == entityid)
                {
                    return hc;
                }
            }

            return new Handmanager.Handcard();
        }

        public void endturn()
        {
            this.board.endTurn(false, false);

            //allways false! because we switch the players after that!
            this.board.prepareNextTurn(false);
            //change active player!
            this.currentplayer = !this.currentplayer;
            this.board.swapAll();

           updateStuffAndSend();
        }

        public void doAction(Action a)
        {
            this.board.doAction(a);
            updateStuffAndSend();
        }

        public void updateStuffAndSend()
        {
            this.board.printBoard();

            if (this.board.ownHero.Hp <= 0 || this.board.enemyHero.Hp <= 0)
            {
                Console.WriteLine("SOME ONE WINS in " + this.board.turnCounter + " turns");
                player p1w = p2;
                player p2w = p1;
                if (this.currentplayer)
                {
                    p1w = p1;
                    p2w = p2;
                }
                if (this.board.ownHero.Hp <= 0)
                {
                    this.winner = p2w.folder + p2w.socket;
                    p2w.wins++;
                    Console.WriteLine(p1w.socket + "looses");

                    if (this.board.enemyHero.Hp <= 0)
                    {
                        p1w.wins++;// split :D
                    }
                }
                else
                {
                    this.winner = p1w.folder + p1w.socket;
                    p1w.wins++;
                    Console.WriteLine(p2w.socket + "looses");
                }
                
                return;
            }

            sendCurrentBoardToClient();
        }

        public string getWinstring()
        {
            return p1.folder + p1.socket + " VS " + p2.folder + p2.socket + " = " + p1.wins + ":" +p2.wins; 
        }

        public void updateHrtprozisAtStart()
        {
            int controler = 2;
            player p = p2;
            player opponent = p1;
            if (this.currentplayer)
            {
                controler = 1;
                p = p1;
                opponent = p2;
            }

            Hrtprozis.Instance.setOwnPlayer(controler);
            Hrtprozis.Instance.updatePlayer(p.maxMana, p.curMana, p.cardsPlayedThisTurn, p.numMinionsPlayedThisTurn, p.numOptionPlayedThisTurn, p.overdrive, p.HEntity, opponent.HEntity, p.numberMinionsDiedThisturn, p.owncurrentRecall, opponent.owncurrentRecall, 0, 0);//new values a zero at start
            Hrtprozis.Instance.setPlayereffects(p.ownDragonConsort, opponent.ownDragonConsort, p.ownLoathebs, opponent.ownLoathebs, p.ownMillhouse, opponent.ownMillhouse, p.ownKirintor, p.ownPrep, 0, 0, 0);//new values a zero at start

            //TODO
            //Hrtprozis.Instance.updateSecretStuff(this.ownsecretlist, enemySecretAmount);

            bool herowindfury = false;
            if (p.ownHeroWeapon == "doomhammer") herowindfury = true;
            Minion ownHero = new Minion();
            Minion enemyHero = new Minion();
            ownHero.isHero = true;
            enemyHero.isHero = true;
            ownHero.own = true;
            enemyHero.own = false;
            ownHero.maxHp = p.ownheromaxhp;
            enemyHero.maxHp = opponent.ownheromaxhp;
            ownHero.entitiyID = p.HEntity;
            enemyHero.entitiyID = opponent.HEntity;

            ownHero.Angr = p.ownHeroAttack;
            ownHero.Hp = p.ownherohp;
            ownHero.armor = p.ownherodefence;
            ownHero.frozen = p.ownHeroFrozen;
            ownHero.immuneWhileAttacking = p.ownHeroimmunewhileattacking;
            ownHero.immune = p.heroImmune;
            ownHero.numAttacksThisTurn = p.ownheroattacksThisRound;
            ownHero.windfury = herowindfury;

            enemyHero.Angr = opponent.ownHeroWeaponAttack;
            enemyHero.Hp = opponent.ownherohp;
            enemyHero.frozen = opponent.ownHeroFrozen;
            enemyHero.armor = opponent.ownherodefence;
            enemyHero.immune = opponent.heroImmune;
            enemyHero.Ready = false;

            ownHero.updateReadyness();

            Console.WriteLine("herodata:" + p.heroname + " " + ownHero.Hp + " " + ownHero.maxHp);
            Hrtprozis.Instance.updateOwnHero(p.ownHeroWeapon, p.ownHeroWeaponAttack, p.ownHeroWeaponDurability, p.heroname, p.heroAbility, p.heroAbilityReady, ownHero, 0); //at start heropower uses this game = 0
            Hrtprozis.Instance.updateEnemyHero(opponent.ownHeroWeapon, opponent.ownHeroWeaponAttack, opponent.ownHeroWeaponDurability, opponent.heroname, opponent.maxMana, opponent.heroAbility, enemyHero, 0);//at start heropower uses this game = 0

            Hrtprozis.Instance.updateMinions(p.ownminions, opponent.ownminions);

            Hrtprozis.Instance.updateFatigueStats(p.deck.Count, p.ownFatigue, opponent.deck.Count, opponent.ownFatigue);

            //TODO
            /*
            Probabilitymaker.Instance.setEnemySecretData(enemySecrets);

            Probabilitymaker.Instance.setTurnGraveYard(this.turnGraveYard);
            Probabilitymaker.Instance.stalaggDead = this.stalaggdead;
            Probabilitymaker.Instance.feugenDead = this.feugendead;

            if (og != "") Probabilitymaker.Instance.readGraveyards(og, eg);
            if (omd != "") Probabilitymaker.Instance.readTurnGraveYard(omd, emd);*/

        }

        public void updateHandManagerAtStart()
        {
            int controler = 2;
            player p = p2;
            player opponent = p1;
            if (this.currentplayer)
            {
                controler = 1;
                p = p1;
                opponent = p2;
            }
            Handmanager.Instance.setOwnPlayer(controler);
            Handmanager.Instance.setHandcards(p.hand, p.hand.Count, opponent.hand.Count);


        }

        public void sendCurrentBoardToClient()
        {
            //bool runEx = true;
            Helpfunctions hpf = Helpfunctions.Instance;
            player p = p2;
            player opponent = p1;
            if (this.currentplayer)
            {
                p = p1;
                opponent = p2;
            }

            //DO we need this?
            //hpf.resetBuffer();
            //hpf.writeBufferToActionFile(p.client);
            hpf.resetBuffer();

            string dtimes = DateTime.Now.ToString("HH:mm:ss:ffff");
            /*int ownsecretcount = p.secrets.Count;
            int enemySecretCount = opponent.secrets.Count;

            string enemysecretIds = "";
            enemysecretIds = Probabilitymaker.Instance.getEnemySecretData();

            
            hpf.writeToBuffer("#######################################################################");
            hpf.writeToBuffer("#######################################################################");
            hpf.writeToBuffer("start calculations, current time: " + dtimes + " V" + "115.55" + " " + p.settings);
            hpf.writeToBuffer("#######################################################################");
            hpf.writeToBuffer("mana " + p.curMana + "/" + p.maxMana);
            hpf.writeToBuffer("emana " + opponent.maxMana);
            hpf.writeToBuffer("own secretsCount: " + ownsecretcount);
            hpf.writeToBuffer("enemy secretsCount: " + enemySecretCount + " ;" + enemysecretIds);

            Hrtprozis.Instance.printHero(runEx);
            Hrtprozis.Instance.printOwnMinions(runEx);
            Hrtprozis.Instance.printEnemyMinions(runEx);
            Handmanager.Instance.printcards(runEx);
            Probabilitymaker.Instance.printTurnGraveYard(runEx);
            Probabilitymaker.Instance.printGraveyards(runEx);*/

            hpf.writeToBuffer(this.board.getCompleteBoardForSimulating(p.settings, "116.00", dtimes));
            hpf.writeBufferToFile(p.client);
            hpf.ErrorLog("sended");
        }
    }

}
