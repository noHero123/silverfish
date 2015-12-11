namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BoardTester
    {
        public int boardToSimulate = -1;
        public string evalFunction = "control";
        int maxwide = 3000;
        int twoturnsim = 256;
        bool simEnemy2Turn = false;
        int pprob1 = 50;
        int pprob2 = 80;
        bool playarround = false;

        int ownPlayer = 1;
        int enemmaxman = 0;

        Minion ownHero;
        Minion enemyHero;

        int ownHEntity = 0;
        int enemyHEntity = 1;

        int mana = 0;
        int maxmana = 0;
        string ownheroname = "";
        int ownherohp = 0;
        int ownheromaxhp = 30;
        int enemyheromaxhp = 30;
        int ownherodefence = 0;
        bool ownheroready = false;
        bool ownHeroimmunewhileattacking = false;
        int ownheroattacksThisRound = 0;
        int ownHeroAttack = 0;
        int ownHeroTempAttack = 0;
        string ownHeroWeapon = "";
        int ownHeroWeaponAttack = 0;
        int ownHeroWeaponDurability = 0;
        int numOptionPlayedThisTurn = 0;
        int numMinionsPlayedThisTurn = 0;
        int cardsPlayedThisTurn = 0;
        int overdrive = 0;
        int numberMinionsDiedThisturn = 0;
        int owncurrentRecall = 0;
        int enemyRecall = 0;

        int ownDragonConsort = 0;
        int enemyDragonConsort = 0;
        int ownLoathebs = 0;
        int enemyLoathebs = 0;
        int ownMillhouse = 0;
        int enemyMillhouse = 0;
        int ownKirintor = 0;
        int ownPrep = 0;

        int ownSab = 0;
        int enemySab = 0;


        int ownDecksize = 30;
        int enemyDecksize = 30;
        int ownFatigue = 0;
        int enemyFatigue = 0;

        bool heroImmune = false;
        bool enemyHeroImmune = false;

        int enemySecretAmount = 0;
        List<SecretItem> enemySecrets = new List<SecretItem>();

        List<CardDB.cardIDEnum> choiceCards = new List<CardDB.cardIDEnum>();

        bool ownHeroFrozen = false;

        List<string> ownsecretlist = new List<string>();
        string enemyheroname = "";
        int enemyherohp = 0;
        int enemyherodefence = 0;
        bool enemyFrozen = false;
        int enemyWeaponAttack = 0;
        int enemyWeaponDur = 0;
        string enemyWeapon = "";
        int enemyNumberHand = 5;

        int enemyCursedCards = 0;

        List<Minion> ownminions = new List<Minion>();
        List<Minion> enemyminions = new List<Minion>();
        List<Handmanager.Handcard> handcards = new List<Handmanager.Handcard>();
        List<CardDB.cardIDEnum> enemycards = new List<CardDB.cardIDEnum>();
        List<GraveYardItem> turnGraveYard = new List<GraveYardItem>();

        int ownFenci = 0;

        int ownHeropowerUsesThisGame = 0;
        int enemyHeropowerUsesThisGame = 0;
        int heropowerUsesThisTurn = 0;
        int locknload = 0;

        bool feugendead = false;
        bool stalaggdead = false;
        public bool datareaded = false;

        public BoardTester(string data = "")
        {
            this.boardToSimulate = -1;
            string og = "";
            string eg = "";

            string omd = "";
            string emd = "";

            int ets = 20;
            int ents = 20;

            int ntssw = 10;
            int ntssd = 6;
            int ntssm = 50;

            int alpha = 50;

            bool dosecrets = false;

            Settings.Instance.simulatePlacement = false;

            Hrtprozis.Instance.clearAll();
            Handmanager.Instance.clearAll();
            string[] lines = new string[0] { };
            if (data == "")
            {
                this.datareaded = false;
                try
                {
                    string path = Settings.Instance.path;
                    lines = System.IO.File.ReadAllLines(path + "test.txt");
                    this.datareaded = true;
                }
                catch
                {
                    this.datareaded = false;
                    Helpfunctions.Instance.logg("cant find test.txt");
                    Helpfunctions.Instance.ErrorLog("cant find test.txt");
                    return;
                }
            }
            else
            {
                this.datareaded = true;
                lines = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
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
                    if (s.EndsWith("test "))
                    {
                        this.boardToSimulate = 1;
                    }
                    continue;
                }

                if (s.StartsWith("activeChoice: "))
                {
                    string choices = s.Replace("activeChoice: ", "");
                    foreach (string choi in choices.Split(' '))
                    {
                        if (choi == "" || choi == " ") continue;
                        //Console.WriteLine("choice "+choi);
                        choiceCards.Add(CardDB.Instance.cardIdstringToEnum(choi));
                    }
                    continue;
                }

                if (s.StartsWith("ownhero:"))
                {
                    readstate = 1;
                    counter = 1;
                    continue;
                }

                if (s.StartsWith("enemyhero:"))
                {
                    readstate = 2;
                    counter = 1;
                    continue;
                }

                if (s.StartsWith("OwnMinions:"))
                {
                    readstate = 3;
                    counter = 1;
                    continue;
                }

                if (s.StartsWith("EnemyMinions:"))
                {
                    readstate = 4;
                    counter = 1;
                    continue;
                }

                if (s.StartsWith("Own Handcards:"))
                {
                    readstate = 5;
                    counter = 1;
                    continue;
                }

                if (s.StartsWith("player:"))
                {
                    readstate = 42;
                    counter = 1;
                    continue;
                }

                if (s.StartsWith("start calculations, current time: "))
                {
                    Ai.Instance.currentCalculatedBoard = s.Split(' ')[4].Split(' ')[0];

                    this.evalFunction = s.Split(' ')[6].Split(' ')[0];

                    this.maxwide = Convert.ToInt32(s.Split(' ')[7].Split(' ')[0]);

                    //following params are optional
                    this.twoturnsim = 256;
                    if (s.Contains("twoturnsim ")) this.twoturnsim = Convert.ToInt32(s.Split(new string[] { "twoturnsim " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                    if (s.Contains(" face "))
                    {
                        string facehp = s.Split(new string[] { "face " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        ComboBreaker.Instance.attackFaceHP = Convert.ToInt32(facehp);
                        Settings.Instance.enfacehp = ComboBreaker.Instance.attackFaceHP;
                    }

                    this.playarround = false;
                    if (s.Contains("playaround "))
                    {
                        string probs = s.Split(new string[] { "playaround " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        this.playarround = true;
                        this.pprob1 = Convert.ToInt32(probs.Split(' ')[0]);
                        this.pprob2 = Convert.ToInt32(probs.Split(' ')[1]);
                    }

                    if (s.Contains(" ets "))
                    {
                        string eturnsim = s.Split(new string[] { " ets " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        ets = Convert.ToInt32(eturnsim.Split(' ')[0]);
                    }

                    if (s.Contains(" ets2 "))
                    {
                        string eturnsim2 = s.Split(new string[] { " ets2 " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        int ets2 = Convert.ToInt32(eturnsim2.Split(' ')[0]);
                        Settings.Instance.enemyTurnMaxWideSecondTime = ets2;
                    }


                    if (s.Contains(" ents "))
                    {
                        this.simEnemy2Turn = true;
                        string eturnsim = s.Split(new string[] { " ents " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        ents = Convert.ToInt32(eturnsim.Split(' ')[0]);
                    }

                    if (s.Contains(" ntss "))
                    {
                        string probs = s.Split(new string[] { " ntss " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        ntssd = Convert.ToInt32(probs.Split(' ')[0]);
                        ntssw = Convert.ToInt32(probs.Split(' ')[1]);
                        ntssm = Convert.ToInt32(probs.Split(' ')[2]);
                    }

                    if (s.Contains(" secret")) dosecrets = true;

                    if (s.Contains(" weight "))
                    {
                        string alphaval = s.Split(new string[] { " weight " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        alpha = Convert.ToInt32(alphaval.Split(' ')[0]);
                    }


                    if (s.Contains(" plcmnt"))
                    {
                        Settings.Instance.simulatePlacement = true;
                    }

                    continue;
                }

                if (s.StartsWith("enemy secretsCount:"))
                {
                    this.enemySecretAmount = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemySecrets.Clear();
                    if (this.enemySecretAmount >= 1 && s.Contains(";"))
                    {
                        string secretstuff = s.Split(';')[1];
                        foreach (string sec in secretstuff.Split(','))
                        {
                            if (sec == "" || sec == String.Empty || sec == " ") continue;
                            this.enemySecrets.Add(new SecretItem(sec));
                        }

                    }
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

                if (s.StartsWith("Enemy cards: "))
                {
                    enemyNumberHand = Convert.ToInt32(s.Split(' ')[2]);
                    continue;
                }

                if (s.StartsWith("GraveYard:"))
                {
                    if (s.Contains("fgn")) this.feugendead = true;
                    if (s.Contains("stlgg")) this.stalaggdead = true;
                    continue;
                }

                if (s.StartsWith("osecrets: "))
                {
                    string secs = s.Replace("osecrets: ", "");
                    foreach (string sec in secs.Split(' '))
                    {
                        if (sec == "" || sec == string.Empty) continue;
                        this.ownsecretlist.Add(sec);
                    }
                    continue;
                }

                if (s.StartsWith("ownDiedMinions: "))
                {
                    omd = s;
                    continue;
                }

                if (s.StartsWith("enemyDiedMinions: "))
                {
                    emd = s;
                    continue;
                }



                if (s.StartsWith("probs: "))
                {
                    int i = 0;
                    foreach (string p in s.Split(' '))
                    {
                        if (p.StartsWith("probs:") || p == "" || p == null) continue;
                        int num = Convert.ToInt32(p);
                        CardDB.cardIDEnum c = CardDB.cardIDEnum.None;
                        if (i == 0)
                        {
                            if (this.enemyheroname == "mage")
                            {
                                c = CardDB.cardIDEnum.CS2_032;
                            }
                            if (this.enemyheroname == "warrior")
                            {
                                c = CardDB.cardIDEnum.EX1_400;
                            }

                            if (this.enemyheroname == "hunter")
                            {
                                c = CardDB.cardIDEnum.EX1_538;
                            }

                            if (this.enemyheroname == "priest")
                            {
                                c = CardDB.cardIDEnum.CS1_112;
                            }

                            if (this.enemyheroname == "shaman")
                            {
                                c = CardDB.cardIDEnum.EX1_259;
                            }

                            if (this.enemyheroname == "pala")
                            {
                                c = CardDB.cardIDEnum.CS2_093;
                            }

                            if (this.enemyheroname == "druid")
                            {
                                c = CardDB.cardIDEnum.CS2_012;
                            }
                        }

                        if (i == 1)
                        {
                            if (this.enemyheroname == "mage")
                            {
                                c = CardDB.cardIDEnum.CS2_028;
                            }
                        }

                        if (num == 1)
                        {
                            enemycards.Add(c);
                        }
                        if (num == 0)
                        {
                            enemycards.Add(c);
                            enemycards.Add(c);
                        }
                        i++;
                    }

                    Probabilitymaker.Instance.setEnemyCards(enemycards);
                    continue;
                }

                if (s.StartsWith("og:"))
                {
                    og = s;
                    continue;
                }
                if (s.StartsWith("eg:"))
                {
                    eg = s;
                    continue;
                }

                if (readstate == 42 && counter == 1) // player
                {
                    this.overdrive = Convert.ToInt32(s.Split(' ')[2]);
                    this.numMinionsPlayedThisTurn = Convert.ToInt32(s.Split(' ')[0]);
                    this.cardsPlayedThisTurn = Convert.ToInt32(s.Split(' ')[1]);
                    this.ownPlayer = Convert.ToInt32(s.Split(' ')[3]);
                    this.numberMinionsDiedThisturn = 0;
                    this.owncurrentRecall = 0;
                    this.enemyRecall = 0;
                    try
                    {
                        //for old log files a try and catch :D
                        this.numberMinionsDiedThisturn = Convert.ToInt32(s.Split(' ')[4]);
                        this.owncurrentRecall = Convert.ToInt32(s.Split(' ')[5]);
                        this.enemyRecall = Convert.ToInt32(s.Split(' ')[6]);
                       
                    }
                    catch
                    {

                    }
                    try
                    {
                        //for old log files a try and catch :D
                        this.heropowerUsesThisTurn = Convert.ToInt32(s.Split(' ')[7]);
                        this.locknload = Convert.ToInt32(s.Split(' ')[8]); 

                    }
                    catch
                    {

                    }
                }

                if (readstate == 42 && counter == 2) // player enchantmens
                {
                    this.ownDragonConsort = Convert.ToInt32(s.Split(' ')[0]);
                    this.enemyDragonConsort = Convert.ToInt32(s.Split(' ')[1]);
                    this.ownLoathebs = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemyLoathebs = Convert.ToInt32(s.Split(' ')[3]);
                    this.ownMillhouse = Convert.ToInt32(s.Split(' ')[4]);
                    this.enemyMillhouse = Convert.ToInt32(s.Split(' ')[5]);
                    this.ownKirintor = Convert.ToInt32(s.Split(' ')[6]);
                    this.ownPrep = Convert.ToInt32(s.Split(' ')[7]);

                    try
                    {
                        this.ownSab = Convert.ToInt32(s.Split(' ')[8]);
                        this.enemySab = Convert.ToInt32(s.Split(' ')[9]);
                        this.ownFenci = Convert.ToInt32(s.Split(' ')[10]); 

                    }
                    catch
                    {

                    }

                    try
                    {
                        this.enemyCursedCards = Convert.ToInt32(s.Split(' ')[11]);

                    }
                    catch
                    {

                    }



                }

                if (readstate == 1 && counter == 1) // class + hp + defence + immunewhile attacking + immune
                {
                    ownheroname = s.Split(' ')[0];
                    ownherohp = Convert.ToInt32(s.Split(' ')[1]);
                    ownheromaxhp = Convert.ToInt32(s.Split(' ')[2]);
                    ownherodefence = Convert.ToInt32(s.Split(' ')[3]);
                    this.ownHeroimmunewhileattacking = (s.Split(' ')[4] == "True") ? true : false;
                    this.heroImmune = (s.Split(' ')[5] == "True") ? true : false;
                    ownHEntity = Convert.ToInt32(s.Split(' ')[6]);
                    ownheroready = (s.Split(' ')[7] == "True") ? true : false;
                    ownheroattacksThisRound = Convert.ToInt32(s.Split(' ')[8]);
                    ownHeroFrozen = (s.Split(' ')[9] == "True") ? true : false;
                    ownHeroAttack = Convert.ToInt32(s.Split(' ')[10]);
                    ownHeroTempAttack = Convert.ToInt32(s.Split(' ')[11]);

                }

                if (readstate == 1 && counter == 2) // own hero weapon
                {
                    ownHeroWeaponAttack = Convert.ToInt32(s.Split(' ')[1]);
                    this.ownHeroWeaponDurability = Convert.ToInt32(s.Split(' ')[2]);
                    if (ownHeroWeaponAttack == 0)
                    {
                        ownHeroWeapon = ""; //:D
                    }
                    else
                    {
                        ownHeroWeapon = s.Split(' ')[3];
                    }
                }

                if (readstate == 1 && counter == 3) // ability + abilityready
                {
                    abilityReady = (s.Split(' ')[1] == "True");
                    heroability = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s.Split(' ')[2]));
                    try
                    {
                        //for old log files a try and catch :D
                        this.ownHeropowerUsesThisGame = Convert.ToInt32(s.Split(' ')[3]);

                    }
                    catch
                    {

                    }
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
                    enemyheromaxhp = Convert.ToInt32(s.Split(' ')[2]);
                    enemyherodefence = Convert.ToInt32(s.Split(' ')[3]);
                    enemyFrozen = (s.Split(' ')[4] == "True") ? true : false;
                    enemyHeroImmune = (s.Split(' ')[5] == "True") ? true : false;
                    enemyHEntity = Convert.ToInt32(s.Split(' ')[6]);
                }

                if (readstate == 2 && counter == 2) // wepon + stuff
                {
                    this.enemyWeaponAttack = Convert.ToInt32(s.Split(' ')[1]);
                    this.enemyWeaponDur = Convert.ToInt32(s.Split(' ')[2]);
                    if (enemyWeaponDur == 0)
                    {
                        this.enemyWeapon = "";
                    }
                    else
                    {
                        this.enemyWeapon = s.Split(' ')[3];
                    }

                }
                if (readstate == 2 && counter == 3) // ability
                {
                    enemyability = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s.Split(' ')[2]));
                    try
                    {
                        //for old log files a try and catch :D
                        this.enemyHeropowerUsesThisGame = Convert.ToInt32(s.Split(' ')[3]);

                    }
                    catch
                    {

                    }
                }
                if (readstate == 2 && counter == 4) // fatigue
                {
                    this.ownDecksize = Convert.ToInt32(s.Split(' ')[1]);
                    this.enemyDecksize = Convert.ToInt32(s.Split(' ')[3]);
                    this.ownFatigue = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemyFatigue = Convert.ToInt32(s.Split(' ')[4]);
                }

                if (readstate == 3) // minion + enchantment
                {
                    if (s.Contains(" zp:"))
                    {

                        string minionname = s.Split(' ')[0];
                        string minionid = s.Split(' ')[1];
                        int zp = Convert.ToInt32(s.Split(new string[] { " zp:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int ent = 1000 + j;
                        if (s.Contains(" e:")) ent = Convert.ToInt32(s.Split(new string[] { " e:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int attack = Convert.ToInt32(s.Split(new string[] { " A:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hp = Convert.ToInt32(s.Split(new string[] { " H:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int maxhp = Convert.ToInt32(s.Split(new string[] { " mH:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        bool ready = s.Split(new string[] { " rdy:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True";
                        int natt = 0;
                        if (s.Contains(" natt:")) natt = Convert.ToInt32(s.Split(new string[] { " natt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                        // optional params (bools)
                        bool ex = s.Contains(" ex");
                        bool taunt = s.Contains(" tnt");
                        bool frzn = s.Contains(" frz");
                        bool silenced = s.Contains(" silenced");
                        bool divshield = s.Contains(" divshield");
                        bool ptt = s.Contains(" ptt");
                        bool wndfry = s.Contains(" wndfr");
                        bool stl = s.Contains(" stlth");
                        bool pois = s.Contains(" poi");
                        bool immn = s.Contains(" imm");
                        bool cncdl = s.Contains(" cncdl");
                        bool destroyOnOwnTurnStart = s.Contains(" dstrOwnTrnStrt");
                        bool destroyOnOwnTurnEnd = s.Contains(" dstrOwnTrnnd");
                        bool destroyOnEnemyTurnStart = s.Contains(" dstrEnmTrnStrt");
                        bool destroyOnEnemyTurnEnd = s.Contains(" dstrEnmTrnnd");
                        bool shadowmadnessed = s.Contains(" shdwmdnssd");
                        bool cntlower = s.Contains(" cantLowerHpBelowOne");
                        bool cnttrgt = s.Contains(" canttarget");
                        //optional params (ints)


                        int chrg = 0;//charge
                        if (s.Contains(" chrg(")) chrg = Convert.ToInt32(s.Split(new string[] { " chrg(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int adjadmg = 0;//adjadmg
                        if (s.Contains(" adjaattk(")) adjadmg = Convert.ToInt32(s.Split(new string[] { " adjaattk(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int tmpdmg = 0;//adjadmg
                        if (s.Contains(" tmpattck(")) tmpdmg = Convert.ToInt32(s.Split(new string[] { " tmpattck(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int spllpwr = 0;//adjadmg
                        if (s.Contains(" spllpwr(")) spllpwr = Convert.ToInt32(s.Split(new string[] { " spllpwr(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ancestralspirit = 0;//adjadmg
                        if (s.Contains(" ancstrl(")) ancestralspirit = Convert.ToInt32(s.Split(new string[] { " ancstrl(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ownBlessingOfWisdom = 0;//adjadmg
                        if (s.Contains(" ownBlssng(")) ownBlessingOfWisdom = Convert.ToInt32(s.Split(new string[] { " ownBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int enemyBlessingOfWisdom = 0;//adjadmg
                        if (s.Contains(" enemyBlssng(")) enemyBlessingOfWisdom = Convert.ToInt32(s.Split(new string[] { " enemyBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int souloftheforest = 0;//adjadmg
                        if (s.Contains(" souloffrst(")) souloftheforest = Convert.ToInt32(s.Split(new string[] { " souloffrst(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ownPwordGlory = 0;//adjadmg
                        if (s.Contains(" ownPWG(")) ownPwordGlory = Convert.ToInt32(s.Split(new string[] { " ownPWG(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int enemyPwordGlory = 0;//adjadmg
                        if (s.Contains(" enemyPWG(")) enemyPwordGlory = Convert.ToInt32(s.Split(new string[] { " enemyPWG(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int explorersHat = 0;
                        if (s.Contains(" explht(")) explorersHat = Convert.ToInt32(s.Split(new string[] { " explht(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);



                        tempminion = createNewMinion(new Handmanager.Handcard(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid))), zp, true);
                        tempminion.own = true;
                        tempminion.entitiyID = ent;
                        tempminion.handcard.entity = ent;
                        tempminion.Angr = attack;
                        tempminion.Hp = hp;
                        tempminion.maxHp = maxhp;
                        tempminion.Ready = ready;
                        tempminion.numAttacksThisTurn = natt;
                        tempminion.exhausted = ex;
                        tempminion.taunt = taunt;
                        tempminion.frozen = frzn;
                        tempminion.silenced = silenced;
                        tempminion.divineshild = divshield;
                        tempminion.playedThisTurn = ptt;
                        tempminion.windfury = wndfry;
                        tempminion.stealth = stl;
                        tempminion.poisonous = pois;
                        tempminion.immune = immn;

                        tempminion.concedal = cncdl;
                        tempminion.destroyOnOwnTurnStart = destroyOnOwnTurnStart;
                        tempminion.destroyOnOwnTurnEnd = destroyOnOwnTurnEnd;
                        tempminion.destroyOnEnemyTurnStart = destroyOnEnemyTurnStart;
                        tempminion.destroyOnEnemyTurnEnd = destroyOnEnemyTurnEnd;
                        tempminion.shadowmadnessed = shadowmadnessed;
                        tempminion.cantLowerHPbelowONE = cntlower;
                        tempminion.cantBeTargetedBySpellsOrHeroPowers = cnttrgt;

                        tempminion.charge = chrg;
                        tempminion.AdjacentAngr = adjadmg;
                        tempminion.tempAttack = tmpdmg;
                        tempminion.spellpower = spllpwr;

                        tempminion.ancestralspirit = ancestralspirit;
                        tempminion.ownBlessingOfWisdom = ownBlessingOfWisdom;
                        tempminion.enemyBlessingOfWisdom = enemyBlessingOfWisdom;
                        tempminion.ownPowerWordGlory = ownPwordGlory;
                        tempminion.enemyPowerWordGlory = enemyPwordGlory;
                        tempminion.souloftheforest = souloftheforest;

                        tempminion.explorersHat = explorersHat;

                        tempminion.canAttackNormal = false;
                        if (ready == true) tempminion.canAttackNormal = true;

                        if (maxhp > hp) tempminion.wounded = true;
                        tempminion.updateReadyness();
                        this.ownminions.Add(tempminion);



                    }

                }

                if (readstate == 4) // minion or enchantment
                {
                    if (s.Contains(" zp:"))
                    {

                        string minionname = s.Split(' ')[0];
                        string minionid = s.Split(' ')[1];
                        int zp = Convert.ToInt32(s.Split(new string[] { " zp:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int ent = 1000 + j;
                        if (s.Contains(" e:")) ent = Convert.ToInt32(s.Split(new string[] { " e:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int attack = Convert.ToInt32(s.Split(new string[] { " A:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hp = Convert.ToInt32(s.Split(new string[] { " H:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int maxhp = Convert.ToInt32(s.Split(new string[] { " mH:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        bool ready = s.Split(new string[] { " rdy:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        int natt = 0;
                        //if (s.Contains(" natt:")) natt = Convert.ToInt32(s.Split(new string[] { " natt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                        // optional params (bools)
                        bool ex = s.Contains(" ex");
                        bool taunt = s.Contains(" tnt");
                        bool frzn = s.Contains(" frz");
                        bool silenced = s.Contains(" silenced");
                        bool divshield = s.Contains(" divshield");
                        bool ptt = s.Contains(" ptt");
                        bool wndfry = s.Contains(" wndfr");
                        bool stl = s.Contains(" stlth");
                        bool pois = s.Contains(" poi");
                        bool immn = s.Contains(" imm");
                        bool cncdl = s.Contains(" cncdl");
                        bool destroyOnOwnTurnStart = s.Contains(" dstrOwnTrnStrt");
                        bool destroyOnOwnTurnEnd = s.Contains(" dstrOwnTrnnd");
                        bool destroyOnEnemyTurnStart = s.Contains(" dstrEnmTrnStrt");
                        bool destroyOnEnemyTurnEnd = s.Contains(" dstrEnmTrnnd");
                        bool shadowmadnessed = s.Contains(" shdwmdnssd");
                        bool cntlower = s.Contains(" cantLowerHpBelowOne");
                        bool cnttrgt = s.Contains(" canttarget");

                        //optional params (ints)


                        int chrg = 0;//charge
                        if (s.Contains(" chrg(")) chrg = Convert.ToInt32(s.Split(new string[] { " chrg(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int adjadmg = 0;//adjadmg
                        if (s.Contains(" adjaattk(")) adjadmg = Convert.ToInt32(s.Split(new string[] { " adjaattk(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int tmpdmg = 0;//adjadmg
                        if (s.Contains(" tmpattck(")) tmpdmg = Convert.ToInt32(s.Split(new string[] { " tmpattck(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int spllpwr = 0;//adjadmg
                        if (s.Contains(" spllpwr(")) spllpwr = Convert.ToInt32(s.Split(new string[] { " spllpwr(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ancestralspirit = 0;//adjadmg
                        if (s.Contains(" ancstrl(")) ancestralspirit = Convert.ToInt32(s.Split(new string[] { " ancstrl(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ownBlessingOfWisdom = 0;//adjadmg
                        if (s.Contains(" ownBlssng(")) ownBlessingOfWisdom = Convert.ToInt32(s.Split(new string[] { " ownBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int enemyBlessingOfWisdom = 0;//adjadmg
                        if (s.Contains(" enemyBlssng(")) enemyBlessingOfWisdom = Convert.ToInt32(s.Split(new string[] { " enemyBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int souloftheforest = 0;//adjadmg
                        if (s.Contains(" souloffrst(")) souloftheforest = Convert.ToInt32(s.Split(new string[] { " souloffrst(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ownPwordGlory = 0;//adjadmg
                        if (s.Contains(" ownPWG(")) ownPwordGlory = Convert.ToInt32(s.Split(new string[] { " ownPWG(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int enemyPwordGlory = 0;//adjadmg
                        if (s.Contains(" enemyPWG(")) enemyPwordGlory = Convert.ToInt32(s.Split(new string[] { " enemyPWG(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int explorersHat = 0;
                        if (s.Contains(" explht(")) explorersHat = Convert.ToInt32(s.Split(new string[] { " explht(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        tempminion = createNewMinion(new Handmanager.Handcard(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid))), zp, false);
                        tempminion.own = false;
                        tempminion.entitiyID = ent;
                        tempminion.handcard.entity = ent;
                        tempminion.Angr = attack;
                        tempminion.Hp = hp;
                        tempminion.maxHp = maxhp;
                        tempminion.Ready = ready;
                        tempminion.numAttacksThisTurn = natt;
                        tempminion.exhausted = ex;
                        tempminion.taunt = taunt;
                        tempminion.frozen = frzn;
                        tempminion.silenced = silenced;
                        tempminion.divineshild = divshield;
                        tempminion.playedThisTurn = ptt;
                        tempminion.windfury = wndfry;
                        tempminion.stealth = stl;
                        tempminion.poisonous = pois;
                        tempminion.immune = immn;

                        tempminion.concedal = cncdl;
                        tempminion.destroyOnOwnTurnStart = destroyOnOwnTurnStart;
                        tempminion.destroyOnOwnTurnEnd = destroyOnOwnTurnEnd;
                        tempminion.destroyOnEnemyTurnStart = destroyOnEnemyTurnStart;
                        tempminion.destroyOnEnemyTurnEnd = destroyOnEnemyTurnEnd;
                        tempminion.shadowmadnessed = shadowmadnessed;
                        tempminion.cantLowerHPbelowONE = cntlower;
                        tempminion.cantBeTargetedBySpellsOrHeroPowers = cnttrgt;

                        tempminion.charge = chrg;
                        tempminion.AdjacentAngr = adjadmg;
                        tempminion.tempAttack = tmpdmg;
                        tempminion.spellpower = spllpwr;

                        tempminion.ancestralspirit = ancestralspirit;
                        tempminion.ownBlessingOfWisdom = ownBlessingOfWisdom;
                        tempminion.enemyBlessingOfWisdom = enemyBlessingOfWisdom;
                        tempminion.ownPowerWordGlory = ownPwordGlory;
                        tempminion.enemyPowerWordGlory = enemyPwordGlory;
                        tempminion.souloftheforest = souloftheforest;

                        tempminion.explorersHat = explorersHat;

                        if (maxhp > hp) tempminion.wounded = true;
                        tempminion.updateReadyness();
                        this.enemyminions.Add(tempminion);


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
                    card.addattack = 0;
                    if (s.Split(' ').Length >= 8 && s.Split(' ')[7] != "")
                    {
                        card.addattack = Convert.ToInt32(s.Split(' ')[7]);
                    }
                    card.addHp = 0;
                    try
                    {
                        card.addHp = Convert.ToInt32(s.Split(' ')[8]);
                    }
                    catch
                    {
 
                    }
                    card.manacost = mana;
                    card.position = pos;
                    handcards.Add(card);

                }






                counter++;
                j++;
            }
            Helpfunctions.Instance.logg("rdy");


            Hrtprozis.Instance.setOwnPlayer(ownPlayer);
            Handmanager.Instance.setOwnPlayer(ownPlayer);

            this.numOptionPlayedThisTurn = 0;
            this.numOptionPlayedThisTurn += this.cardsPlayedThisTurn + ownheroattacksThisRound;
            foreach (Minion m in this.ownminions)
            {
                this.numOptionPlayedThisTurn += m.numAttacksThisTurn;
            }


            Hrtprozis.Instance.updatePlayer(this.maxmana, this.mana, this.cardsPlayedThisTurn, this.numMinionsPlayedThisTurn, this.numOptionPlayedThisTurn, this.overdrive, ownHEntity, enemyHEntity, this.numberMinionsDiedThisturn, this.owncurrentRecall, this.enemyRecall, this.heropowerUsesThisTurn, this.locknload);
            Hrtprozis.Instance.setPlayereffects(this.ownDragonConsort, this.enemyDragonConsort, this.ownLoathebs, this.enemyLoathebs, this.ownMillhouse, this.enemyMillhouse, this.ownKirintor, this.ownPrep, this.ownSab, this.enemySab, this.ownFenci, this.enemyCursedCards);


            Hrtprozis.Instance.updateSecretStuff(this.ownsecretlist, enemySecretAmount);

            bool herowindfury = false;
            if (this.ownHeroWeapon == "doomhammer") herowindfury = true;

            //create heros:

            this.ownHero = new Minion();
            this.enemyHero = new Minion();
            this.ownHero.isHero = true;
            this.enemyHero.isHero = true;
            this.ownHero.own = true;
            this.enemyHero.own = false;
            this.ownHero.maxHp = this.ownheromaxhp;
            this.enemyHero.maxHp = this.enemyheromaxhp;
            this.ownHero.entitiyID = ownHEntity;
            this.enemyHero.entitiyID = enemyHEntity;

            this.ownHero.Angr = ownHeroAttack;
            this.ownHero.tempAttack = ownHeroTempAttack;//fix
            this.ownHero.Hp = ownherohp;
            this.ownHero.armor = ownherodefence;
            this.ownHero.frozen = ownHeroFrozen;
            this.ownHero.immuneWhileAttacking = ownHeroimmunewhileattacking;
            this.ownHero.immune = heroImmune;
            this.ownHero.numAttacksThisTurn = ownheroattacksThisRound;
            this.ownHero.windfury = herowindfury;

            this.enemyHero.Angr = enemyWeaponAttack;
            this.enemyHero.Hp = enemyherohp;
            this.enemyHero.frozen = enemyFrozen;
            this.enemyHero.armor = enemyherodefence;
            this.enemyHero.immune = enemyHeroImmune;
            this.enemyHero.Ready = false;

            this.ownHero.updateReadyness();


            //set Simulation stuff

            Ai.Instance.botBase = new BehaviorControl();



            if (this.evalFunction == "rush") Ai.Instance.botBase = new BehaviorRush();
            if (this.evalFunction == "face") Ai.Instance.botBase = new BehaviorFace();
            if (this.evalFunction == "mana") Ai.Instance.botBase = new BehaviorMana();

            Ai.Instance.setMaxWide(this.maxwide);
            Ai.Instance.setTwoTurnSimulation(false, this.twoturnsim);
            Settings.Instance.simEnemySecondTurn = this.simEnemy2Turn;
            //Ai.Instance.nextTurnSimulator.updateParams();
            Settings.Instance.playarround = this.playarround;
            Settings.Instance.playaroundprob = this.pprob1;
            Settings.Instance.playaroundprob2 = this.pprob2;
            Ai.Instance.setPlayAround();

            //save data
            Hrtprozis.Instance.updateOwnHero(this.ownHeroWeapon, this.ownHeroWeaponAttack, this.ownHeroWeaponDurability, this.ownheroname, heroability, abilityReady, this.ownHero, this.ownHeropowerUsesThisGame);
            Hrtprozis.Instance.updateEnemyHero(this.enemyWeapon, this.enemyWeaponAttack, this.enemyWeaponDur, this.enemyheroname, enemmaxman, enemyability, this.enemyHero, this.enemyHeropowerUsesThisGame);

            Hrtprozis.Instance.updateMinions(this.ownminions, this.enemyminions);

            Hrtprozis.Instance.updateFatigueStats(this.ownDecksize, this.ownFatigue, this.enemyDecksize, this.enemyFatigue);

            Handmanager.Instance.setHandcards(this.handcards, this.handcards.Count, enemyNumberHand, this.choiceCards);

            Probabilitymaker.Instance.setEnemySecretData(enemySecrets);

            Probabilitymaker.Instance.setTurnGraveYard(this.turnGraveYard);
            Probabilitymaker.Instance.stalaggDead = this.stalaggdead;
            Probabilitymaker.Instance.feugenDead = this.feugendead;

            if (og != "") Probabilitymaker.Instance.readGraveyards(og, eg);
            if (omd != "") Probabilitymaker.Instance.readTurnGraveYard(omd, emd);
            //Ai.Instance.enemyTurnSim.maxwide = ets;
            //Ai.Instance.enemySecondTurnSim.maxwide = ents;
            Settings.Instance.enemyTurnMaxWide = ets;
            Settings.Instance.enemySecondTurnMaxWide = ents;

            Settings.Instance.nextTurnDeep = ntssd;
            Settings.Instance.nextTurnMaxWide = ntssw;
            Settings.Instance.nextTurnTotalBoards = ntssm;
            //Ai.Instance.nextTurnSimulator.updateParams(ntssd, ntssw, ntssm);

            Settings.Instance.useSecretsPlayArround = dosecrets;

            Settings.Instance.setWeights(alpha);

        }



        public Minion createNewMinion(Handmanager.Handcard hc, int zonepos, bool own)
        {
            Minion m = new Minion
            {
                handcard = new Handmanager.Handcard(hc),
                zonepos = zonepos,
                entitiyID = hc.entity,
                Angr = hc.card.Attack,
                Hp = hc.card.Health,
                maxHp = hc.card.Health,
                name = hc.card.name,
                playedThisTurn = true,
                numAttacksThisTurn = 0
            };

            m.own = own;
            m.isHero = false;
            m.entitiyID = hc.entity;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.windfury = hc.card.windfury;
            m.taunt = hc.card.tank;
            m.charge = (hc.card.Charge) ? 1 : 0;
            m.divineshild = hc.card.Shield;
            m.poisonous = hc.card.poisionous;
            m.stealth = hc.card.Stealth;

            m.updateReadyness();

            if (m.name == CardDB.cardName.lightspawn)
            {
                m.Angr = m.Hp;
            }
            return m;
        }




    }

}