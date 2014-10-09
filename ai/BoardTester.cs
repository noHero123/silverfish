// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoardTester.cs" company="">
//   
// </copyright>
// <summary>
//   The board tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace HREngine.Bots
{
    using System.IO;

    // reads the board and simulates it
    /// <summary>
    /// The board tester.
    /// </summary>
    public class BoardTester
    {
        /// <summary>
        /// The eval function.
        /// </summary>
        public string evalFunction = "control";

        /// <summary>
        /// The maxwide.
        /// </summary>
        int maxwide = 3000;

        /// <summary>
        /// The twoturnsim.
        /// </summary>
        int twoturnsim = 256;

        /// <summary>
        /// The sim enemy 2 turn.
        /// </summary>
        bool simEnemy2Turn = false;

        /// <summary>
        /// The pprob 1.
        /// </summary>
        int pprob1 = 50;

        /// <summary>
        /// The pprob 2.
        /// </summary>
        int pprob2 = 80;

        /// <summary>
        /// The playarround.
        /// </summary>
        bool playarround = false;

        /// <summary>
        /// The own player.
        /// </summary>
        int ownPlayer = 1;

        /// <summary>
        /// The enemmaxman.
        /// </summary>
        int enemmaxman = 0;

        /// <summary>
        /// The own hero.
        /// </summary>
        Minion ownHero;

        /// <summary>
        /// The enemy hero.
        /// </summary>
        Minion enemyHero;

        /// <summary>
        /// The own h entity.
        /// </summary>
        int ownHEntity = 0;

        /// <summary>
        /// The enemy h entity.
        /// </summary>
        int enemyHEntity = 1;

        /// <summary>
        /// The mana.
        /// </summary>
        int mana = 0;

        /// <summary>
        /// The maxmana.
        /// </summary>
        int maxmana = 0;

        /// <summary>
        /// The ownheroname.
        /// </summary>
        string ownheroname = string.Empty;

        /// <summary>
        /// The ownherohp.
        /// </summary>
        int ownherohp = 0;

        /// <summary>
        /// The ownheromaxhp.
        /// </summary>
        int ownheromaxhp = 30;

        /// <summary>
        /// The enemyheromaxhp.
        /// </summary>
        int enemyheromaxhp = 30;

        /// <summary>
        /// The ownherodefence.
        /// </summary>
        int ownherodefence = 0;

        /// <summary>
        /// The ownheroready.
        /// </summary>
        bool ownheroready = false;

        /// <summary>
        /// The own heroimmunewhileattacking.
        /// </summary>
        bool ownHeroimmunewhileattacking = false;

        /// <summary>
        /// The ownheroattacks this round.
        /// </summary>
        int ownheroattacksThisRound = 0;

        /// <summary>
        /// The own hero attack.
        /// </summary>
        int ownHeroAttack = 0;

        /// <summary>
        /// The own hero temp attack.
        /// </summary>
        int ownHeroTempAttack = 0;

        /// <summary>
        /// The own hero weapon.
        /// </summary>
        string ownHeroWeapon = string.Empty;

        /// <summary>
        /// The own hero weapon attack.
        /// </summary>
        int ownHeroWeaponAttack = 0;

        /// <summary>
        /// The own hero weapon durability.
        /// </summary>
        int ownHeroWeaponDurability = 0;

        /// <summary>
        /// The num option played this turn.
        /// </summary>
        int numOptionPlayedThisTurn = 0;

        /// <summary>
        /// The num minions played this turn.
        /// </summary>
        int numMinionsPlayedThisTurn = 0;

        /// <summary>
        /// The cards played this turn.
        /// </summary>
        int cardsPlayedThisTurn = 0;

        /// <summary>
        /// The overdrive.
        /// </summary>
        int overdrive = 0;

        /// <summary>
        /// The own decksize.
        /// </summary>
        int ownDecksize = 30;

        /// <summary>
        /// The enemy decksize.
        /// </summary>
        int enemyDecksize = 30;

        /// <summary>
        /// The own fatigue.
        /// </summary>
        int ownFatigue = 0;

        /// <summary>
        /// The enemy fatigue.
        /// </summary>
        int enemyFatigue = 0;

        /// <summary>
        /// The hero immune.
        /// </summary>
        bool heroImmune = false;

        /// <summary>
        /// The enemy hero immune.
        /// </summary>
        bool enemyHeroImmune = false;

        /// <summary>
        /// The enemy secret amount.
        /// </summary>
        int enemySecretAmount = 0;

        /// <summary>
        /// The enemy secrets.
        /// </summary>
        List<SecretItem> enemySecrets = new List<SecretItem>();

        /// <summary>
        /// The own hero frozen.
        /// </summary>
        bool ownHeroFrozen = false;

        /// <summary>
        /// The ownsecretlist.
        /// </summary>
        List<string> ownsecretlist = new List<string>();

        /// <summary>
        /// The enemyheroname.
        /// </summary>
        string enemyheroname = string.Empty;

        /// <summary>
        /// The enemyherohp.
        /// </summary>
        int enemyherohp = 0;

        /// <summary>
        /// The enemyherodefence.
        /// </summary>
        int enemyherodefence = 0;

        /// <summary>
        /// The enemy frozen.
        /// </summary>
        bool enemyFrozen = false;

        /// <summary>
        /// The enemy weapon attack.
        /// </summary>
        int enemyWeaponAttack = 0;

        /// <summary>
        /// The enemy weapon dur.
        /// </summary>
        int enemyWeaponDur = 0;

        /// <summary>
        /// The enemy weapon.
        /// </summary>
        string enemyWeapon = string.Empty;

        /// <summary>
        /// The enemy number hand.
        /// </summary>
        int enemyNumberHand = 5;

        /// <summary>
        /// The ownminions.
        /// </summary>
        List<Minion> ownminions = new List<Minion>();

        /// <summary>
        /// The enemyminions.
        /// </summary>
        List<Minion> enemyminions = new List<Minion>();

        /// <summary>
        /// The handcards.
        /// </summary>
        List<Handmanager.Handcard> handcards = new List<Handmanager.Handcard>();

        /// <summary>
        /// The enemycards.
        /// </summary>
        List<CardDB.cardIDEnum> enemycards = new List<CardDB.cardIDEnum>();

        /// <summary>
        /// The turn grave yard.
        /// </summary>
        List<GraveYardItem> turnGraveYard = new List<GraveYardItem>();

        /// <summary>
        /// The feugendead.
        /// </summary>
        bool feugendead = false;

        /// <summary>
        /// The stalaggdead.
        /// </summary>
        bool stalaggdead = false;

        /// <summary>
        /// The datareaded.
        /// </summary>
        public bool datareaded = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardTester"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public BoardTester(string data = "")
        {
            string og = string.Empty;
            string eg = string.Empty;

            string omd = string.Empty;
            string emd = string.Empty;

            int ets = 20;
            int ents = 20;

            int ntssw = 10;
            int ntssd = 6;
            int ntssm = 50;

            bool dosecrets = false;

            Hrtprozis.Instance.clearAll();
            Handmanager.Instance.clearAll();
            string[] lines = { };
            if (data == string.Empty)
            {
                this.datareaded = false;
                try
                {
                    string path = Settings.Instance.path;
                    lines = File.ReadAllLines(path + "test.txt");
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
                lines = data.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
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

                if (s.StartsWith("start calculations, current time: "))
                {
                    Ai.Instance.currentCalculatedBoard = s.Split(' ')[4].Split(' ')[0];

                    this.evalFunction = s.Split(' ')[6].Split(' ')[0];

                    this.maxwide = Convert.ToInt32(s.Split(' ')[7].Split(' ')[0]);

                    // following params are optional
                    this.twoturnsim = 256;
                    if (s.Contains("twoturnsim "))
                    {
                        this.twoturnsim =
                            Convert.ToInt32(
                                s.Split(new[] { "twoturnsim " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                    }

                    if (s.Contains(" face "))
                    {
                        string facehp =
                            s.Split(new[] { "face " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        ComboBreaker.Instance.attackFaceHP = Convert.ToInt32(facehp);
                    }

                    this.playarround = false;
                    if (s.Contains("playaround "))
                    {
                        string probs = s.Split(new[] { "playaround " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        this.playarround = true;
                        this.pprob1 = Convert.ToInt32(probs.Split(' ')[0]);
                        this.pprob2 = Convert.ToInt32(probs.Split(' ')[1]);
                    }

                    if (s.Contains(" ets "))
                    {
                        string eturnsim = s.Split(new[] { " ets " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        ets = Convert.ToInt32(eturnsim.Split(' ')[0]);
                    }

                    if (s.Contains(" ents "))
                    {
                        string eturnsim = s.Split(new[] { " ents " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        ents = Convert.ToInt32(eturnsim.Split(' ')[0]);
                    }

                    if (s.Contains(" ntss "))
                    {
                        string probs = s.Split(new[] { " ntss " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        this.playarround = true;
                        ntssd = Convert.ToInt32(probs.Split(' ')[0]);
                        ntssw = Convert.ToInt32(probs.Split(' ')[1]);
                        ntssm = Convert.ToInt32(probs.Split(' ')[2]);
                    }

                    if (s.Contains("simEnemy2Turn"))
                    {
                        this.simEnemy2Turn = true;
                    }

                    if (s.Contains(" secret"))
                    {
                        dosecrets = true;
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
                            if (sec == string.Empty || sec == string.Empty || sec == " ")
                            {
                                continue;
                            }

                            this.enemySecrets.Add(new SecretItem(sec));
                        }
                    }

                    continue;
                }

                if (s.StartsWith("mana "))
                {
                    string ss = s.Replace("mana ", string.Empty);
                    this.mana = Convert.ToInt32(ss.Split('/')[0]);
                    this.maxmana = Convert.ToInt32(ss.Split('/')[1]);
                }

                if (s.StartsWith("emana "))
                {
                    string ss = s.Replace("emana ", string.Empty);
                    this.enemmaxman = Convert.ToInt32(ss);
                }

                if (s.StartsWith("Enemy cards: "))
                {
                    this.enemyNumberHand = Convert.ToInt32(s.Split(' ')[2]);
                    continue;
                }

                if (s.StartsWith("GraveYard:"))
                {
                    if (s.Contains("fgn"))
                    {
                        this.feugendead = true;
                    }

                    if (s.Contains("stlgg"))
                    {
                        this.stalaggdead = true;
                    }

                    continue;
                }

                if (s.StartsWith("osecrets: "))
                {
                    string secs = s.Replace("osecrets: ", string.Empty);
                    foreach (string sec in secs.Split(' '))
                    {
                        if (sec == string.Empty || sec == string.Empty)
                        {
                            continue;
                        }

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
                        if (p.StartsWith("probs:") || p == string.Empty || p == null)
                        {
                            continue;
                        }

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
                            this.enemycards.Add(c);
                        }

                        if (num == 0)
                        {
                            this.enemycards.Add(c);
                            this.enemycards.Add(c);
                        }

                        i++;
                    }

                    Probabilitymaker.Instance.setEnemyCards(this.enemycards);
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

                if (readstate == 42 && counter == 1)
                {
                    // player
                    this.overdrive = Convert.ToInt32(s.Split(' ')[2]);
                    this.numMinionsPlayedThisTurn = Convert.ToInt32(s.Split(' ')[0]);
                    this.cardsPlayedThisTurn = Convert.ToInt32(s.Split(' ')[1]);
                    this.ownPlayer = Convert.ToInt32(s.Split(' ')[3]);
                }

                if (readstate == 1 && counter == 1)
                {
                    // class + hp + defence + immunewhile attacking + immune
                    this.ownheroname = s.Split(' ')[0];
                    this.ownherohp = Convert.ToInt32(s.Split(' ')[1]);
                    this.ownheromaxhp = Convert.ToInt32(s.Split(' ')[2]);
                    this.ownherodefence = Convert.ToInt32(s.Split(' ')[3]);
                    this.ownHeroimmunewhileattacking = s.Split(' ')[4] == "True";
                    this.heroImmune = s.Split(' ')[5] == "True";
                    this.ownHEntity = Convert.ToInt32(s.Split(' ')[6]);
                    this.ownheroready = s.Split(' ')[7] == "True";
                    this.ownheroattacksThisRound = Convert.ToInt32(s.Split(' ')[8]);
                    this.ownHeroFrozen = s.Split(' ')[9] == "True";
                    this.ownHeroAttack = Convert.ToInt32(s.Split(' ')[10]);
                    this.ownHeroTempAttack = Convert.ToInt32(s.Split(' ')[11]);
                }

                if (readstate == 1 && counter == 2)
                {
                    // own hero weapon
                    this.ownHeroWeaponAttack = Convert.ToInt32(s.Split(' ')[1]);
                    this.ownHeroWeaponDurability = Convert.ToInt32(s.Split(' ')[2]);
                    if (this.ownHeroWeaponAttack == 0)
                    {
                        this.ownHeroWeapon = string.Empty; // :D
                    }
                    else
                    {
                        this.ownHeroWeapon = s.Split(' ')[3];
                    }
                }

                if (readstate == 1 && counter == 3)
                {
                    // ability + abilityready
                    abilityReady = (s.Split(' ')[1] == "True") ? true : false;
                    heroability = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s.Split(' ')[2]));
                }

                if (readstate == 1 && counter >= 5)
                {
                    // secrets
                    if (!s.StartsWith("enemyhero:"))
                    {
                        this.ownsecretlist.Add(s.Replace(" ", string.Empty));
                    }
                }

                if (readstate == 2 && counter == 1)
                {
                    // class + hp + defence + frozen + immune
                    this.enemyheroname = s.Split(' ')[0];
                    this.enemyherohp = Convert.ToInt32(s.Split(' ')[1]);
                    this.enemyheromaxhp = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemyherodefence = Convert.ToInt32(s.Split(' ')[3]);
                    this.enemyFrozen = s.Split(' ')[4] == "True";
                    this.enemyHeroImmune = s.Split(' ')[5] == "True";
                    this.enemyHEntity = Convert.ToInt32(s.Split(' ')[6]);
                }

                if (readstate == 2 && counter == 2)
                {
                    // wepon + stuff
                    this.enemyWeaponAttack = Convert.ToInt32(s.Split(' ')[1]);
                    this.enemyWeaponDur = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemyWeapon = this.enemyWeaponDur == 0 ? string.Empty : s.Split(' ')[3];
                }

                if (readstate == 2 && counter == 3)
                {
                    // ability
                    enemyability = CardDB.Instance.getCardDataFromID(
                        CardDB.Instance.cardIdstringToEnum(s.Split(' ')[2]));
                }

                if (readstate == 2 && counter == 4)
                {
                    // fatigue
                    this.ownDecksize = Convert.ToInt32(s.Split(' ')[1]);
                    this.enemyDecksize = Convert.ToInt32(s.Split(' ')[3]);
                    this.ownFatigue = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemyFatigue = Convert.ToInt32(s.Split(' ')[4]);
                }

                if (readstate == 3)
                {
                    // minion + enchantment
                    if (s.Contains(" zp:"))
                    {
                        string minionname = s.Split(' ')[0];
                        string minionid = s.Split(' ')[1];
                        int zp =
                            Convert.ToInt32(
                                s.Split(new[] { " zp:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int ent = 1000 + j;
                        if (s.Contains(" e:"))
                        {
                            ent =
                                Convert.ToInt32(
                                    s.Split(new[] { " e:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        }

                        int attack =
                            Convert.ToInt32(
                                s.Split(new[] { " A:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hp =
                            Convert.ToInt32(
                                s.Split(new[] { " H:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int maxhp =
                            Convert.ToInt32(
                                s.Split(new[] { " mH:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        bool ready = s.Split(new[] { " rdy:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]
                                     == "True"
                                         ? true
                                         : false;
                        int natt = 0;
                        if (s.Contains(" natt:"))
                        {
                            natt =
                                Convert.ToInt32(
                                    s.Split(new[] { " natt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        }

                        // optional params (bools)
                        bool ex = false; // exhausted
                        if (s.Contains(" ex"))
                        {
                            ex = true;
                        }

                        bool taunt = false;
                        if (s.Contains(" tnt"))
                        {
                            taunt = true;
                        }

                        bool frzn = false;
                        if (s.Contains(" frz"))
                        {
                            frzn = true;
                        }

                        bool silenced = false;
                        if (s.Contains(" silenced"))
                        {
                            silenced = true;
                        }

                        bool divshield = false;
                        if (s.Contains(" divshield"))
                        {
                            divshield = true;
                        }

                        bool ptt = false; // played this turn
                        if (s.Contains(" ptt"))
                        {
                            ptt = true;
                        }

                        bool wndfry = false; // windfurry
                        if (s.Contains(" wndfr"))
                        {
                            wndfry = true;
                        }

                        bool stl = false; // stealth
                        if (s.Contains(" stlth"))
                        {
                            stl = true;
                        }

                        bool pois = false; // poision
                        if (s.Contains(" poi"))
                        {
                            pois = true;
                        }

                        bool immn = false; // immune
                        if (s.Contains(" imm"))
                        {
                            immn = true;
                        }

                        bool cncdl = false; // concedal buffed
                        if (s.Contains(" cncdl"))
                        {
                            cncdl = true;
                        }

                        bool destroyOnOwnTurnStart = false; // destroyOnOwnTurnStart
                        if (s.Contains(" dstrOwnTrnStrt"))
                        {
                            destroyOnOwnTurnStart = true;
                        }

                        bool destroyOnOwnTurnEnd = false; // destroyOnOwnTurnEnd
                        if (s.Contains(" dstrOwnTrnnd"))
                        {
                            destroyOnOwnTurnEnd = true;
                        }

                        bool destroyOnEnemyTurnStart = false; // destroyOnEnemyTurnStart
                        if (s.Contains(" dstrEnmTrnStrt"))
                        {
                            destroyOnEnemyTurnStart = true;
                        }

                        bool destroyOnEnemyTurnEnd = false; // destroyOnEnemyTurnEnd
                        if (s.Contains(" dstrEnmTrnnd"))
                        {
                            destroyOnEnemyTurnEnd = true;
                        }

                        bool shadowmadnessed = false; // shadowmadnessed
                        if (s.Contains(" shdwmdnssd"))
                        {
                            shadowmadnessed = true;
                        }

                        bool cntlower = false; // shadowmadnessed
                        if (s.Contains(" cantLowerHpBelowOne"))
                        {
                            cntlower = true;
                        }

                        // optional params (ints)
                        int chrg = 0; // charge
                        if (s.Contains(" chrg("))
                        {
                            chrg =
                                Convert.ToInt32(
                                    s.Split(new[] { " chrg(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        int adjadmg = 0; // adjadmg
                        if (s.Contains(" adjaattk("))
                        {
                            adjadmg =
                                Convert.ToInt32(
                                    s.Split(new[] { " adjaattk(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')
                                        [0]);
                        }

                        int tmpdmg = 0; // adjadmg
                        if (s.Contains(" tmpattck("))
                        {
                            tmpdmg =
                                Convert.ToInt32(
                                    s.Split(new[] { " tmpattck(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')
                                        [0]);
                        }

                        int spllpwr = 0; // adjadmg
                        if (s.Contains(" spllpwr("))
                        {
                            spllpwr =
                                Convert.ToInt32(
                                    s.Split(new[] { " spllpwr(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[
                                        0]);
                        }

                        int ancestralspirit = 0; // adjadmg
                        if (s.Contains(" ancstrl("))
                        {
                            ancestralspirit =
                                Convert.ToInt32(
                                    s.Split(new[] { " ancstrl(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[
                                        0]);
                        }

                        int ownBlessingOfWisdom = 0; // adjadmg
                        if (s.Contains(" ownBlssng("))
                        {
                            ownBlessingOfWisdom =
                                Convert.ToInt32(
                                    s.Split(new[] { " ownBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(
                                        ')')[0]);
                        }

                        int enemyBlessingOfWisdom = 0; // adjadmg
                        if (s.Contains(" enemyBlssng("))
                        {
                            enemyBlessingOfWisdom =
                                Convert.ToInt32(
                                    s.Split(new[] { " enemyBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(
                                        ')')[0]);
                        }

                        int souloftheforest = 0; // adjadmg
                        if (s.Contains(" souloffrst("))
                        {
                            souloftheforest =
                                Convert.ToInt32(
                                    s.Split(new[] { " souloffrst(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(
                                        ')')[0]);
                        }

                        tempminion =
                            this.createNewMinion(
                                new Handmanager.Handcard(
                                    CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid))), 
                                zp, 
                                true);
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

                        tempminion.charge = chrg;
                        tempminion.AdjacentAngr = adjadmg;
                        tempminion.tempAttack = tmpdmg;
                        tempminion.spellpower = spllpwr;

                        tempminion.ancestralspirit = ancestralspirit;
                        tempminion.ownBlessingOfWisdom = ownBlessingOfWisdom;
                        tempminion.enemyBlessingOfWisdom = enemyBlessingOfWisdom;
                        tempminion.souloftheforest = souloftheforest;

                        if (maxhp > hp)
                        {
                            tempminion.wounded = true;
                        }

                        tempminion.updateReadyness();
                        this.ownminions.Add(tempminion);
                    }
                }

                if (readstate == 4)
                {
                    // minion or enchantment
                    if (s.Contains(" zp:"))
                    {
                        string minionname = s.Split(' ')[0];
                        string minionid = s.Split(' ')[1];
                        int zp =
                            Convert.ToInt32(
                                s.Split(new[] { " zp:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int ent = 1000 + j;
                        if (s.Contains(" e:"))
                        {
                            ent =
                                Convert.ToInt32(
                                    s.Split(new[] { " e:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        }

                        int attack =
                            Convert.ToInt32(
                                s.Split(new[] { " A:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hp =
                            Convert.ToInt32(
                                s.Split(new[] { " H:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int maxhp =
                            Convert.ToInt32(
                                s.Split(new[] { " mH:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        bool ready = s.Split(new[] { " rdy:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]
                                     == "True";
                        int natt = 0;

                        // if (s.Contains(" natt:")) natt = Convert.ToInt32(s.Split(new string[] { " natt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                        // optional params (bools)
                        bool ex = s.Contains(" ex"); // exhausted

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

                        // optional params (ints)
                        int chrg = 0; // charge
                        if (s.Contains(" chrg("))
                        {
                            chrg =
                                Convert.ToInt32(
                                    s.Split(new[] { " chrg(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        int adjadmg = 0; // adjadmg
                        if (s.Contains(" adjaattk("))
                        {
                            adjadmg =
                                Convert.ToInt32(
                                    s.Split(new[] { " adjaattk(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')
                                        [0]);
                        }

                        int tmpdmg = 0; // adjadmg
                        if (s.Contains(" tmpattck("))
                        {
                            tmpdmg =
                                Convert.ToInt32(
                                    s.Split(new[] { " tmpattck(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')
                                        [0]);
                        }

                        int spllpwr = 0; // adjadmg
                        if (s.Contains(" spllpwr("))
                        {
                            spllpwr =
                                Convert.ToInt32(
                                    s.Split(new[] { " spllpwr(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[
                                        0]);
                        }

                        int ancestralspirit = 0; // adjadmg
                        if (s.Contains(" ancstrl("))
                        {
                            ancestralspirit =
                                Convert.ToInt32(
                                    s.Split(new[] { " ancstrl(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[
                                        0]);
                        }

                        int ownBlessingOfWisdom = 0; // adjadmg
                        if (s.Contains(" ownBlssng("))
                        {
                            ownBlessingOfWisdom =
                                Convert.ToInt32(
                                    s.Split(new[] { " ownBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(
                                        ')')[0]);
                        }

                        int enemyBlessingOfWisdom = 0; // adjadmg
                        if (s.Contains(" enemyBlssng("))
                        {
                            enemyBlessingOfWisdom =
                                Convert.ToInt32(
                                    s.Split(new[] { " enemyBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(
                                        ')')[0]);
                        }

                        int souloftheforest = 0; // adjadmg
                        if (s.Contains(" souloffrst("))
                        {
                            souloftheforest =
                                Convert.ToInt32(
                                    s.Split(new[] { " souloffrst(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(
                                        ')')[0]);
                        }

                        tempminion =
                            this.createNewMinion(
                                new Handmanager.Handcard(
                                    CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid))), 
                                zp, 
                                false);
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

                        tempminion.charge = chrg;
                        tempminion.AdjacentAngr = adjadmg;
                        tempminion.tempAttack = tmpdmg;
                        tempminion.spellpower = spllpwr;

                        tempminion.ancestralspirit = ancestralspirit;
                        tempminion.ownBlessingOfWisdom = ownBlessingOfWisdom;
                        tempminion.enemyBlessingOfWisdom = enemyBlessingOfWisdom;
                        tempminion.souloftheforest = souloftheforest;

                        if (maxhp > hp)
                        {
                            tempminion.wounded = true;
                        }

                        tempminion.updateReadyness();
                        this.enemyminions.Add(tempminion);
                    }
                }

                if (readstate == 5)
                {
                    // minion or enchantment
                    Handmanager.Handcard card = new Handmanager.Handcard();

                    string minionname = s.Split(' ')[2];
                    string minionid = s.Split(' ')[6];
                    int pos = Convert.ToInt32(s.Split(' ')[1]);
                    int mana = Convert.ToInt32(s.Split(' ')[3]);
                    card.card = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid));
                    card.entity = Convert.ToInt32(s.Split(' ')[5]);
                    card.manacost = mana;
                    card.position = pos;
                    this.handcards.Add(card);
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
                    readstate = 4;
                    counter = 0;
                }

                if (s.StartsWith("Own Handcards:"))
                {
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

            Hrtprozis.Instance.setOwnPlayer(this.ownPlayer);
            Handmanager.Instance.setOwnPlayer(this.ownPlayer);

            this.numOptionPlayedThisTurn = 0;
            this.numOptionPlayedThisTurn += this.cardsPlayedThisTurn + this.ownheroattacksThisRound;
            foreach (Minion m in this.ownminions)
            {
                this.numOptionPlayedThisTurn += m.numAttacksThisTurn;
            }

            Hrtprozis.Instance.updatePlayer(
                this.maxmana, 
                this.mana, 
                this.cardsPlayedThisTurn, 
                this.numMinionsPlayedThisTurn, 
                this.numOptionPlayedThisTurn, 
                this.overdrive, 
                this.ownHEntity, 
                this.enemyHEntity);
            Hrtprozis.Instance.updateSecretStuff(this.ownsecretlist, this.enemySecretAmount);

            bool herowindfury = false;
            if (this.ownHeroWeapon == "doomhammer")
            {
                herowindfury = true;
            }

            // create heros:
            this.ownHero = new Minion();
            this.enemyHero = new Minion();
            this.ownHero.isHero = true;
            this.enemyHero.isHero = true;
            this.ownHero.own = true;
            this.enemyHero.own = false;
            this.ownHero.maxHp = this.ownheromaxhp;
            this.enemyHero.maxHp = this.enemyheromaxhp;
            this.ownHero.entitiyID = this.ownHEntity;
            this.enemyHero.entitiyID = this.enemyHEntity;

            this.ownHero.Angr = this.ownHeroAttack;
            this.ownHero.Hp = this.ownherohp;
            this.ownHero.armor = this.ownherodefence;
            this.ownHero.frozen = this.ownHeroFrozen;
            this.ownHero.immuneWhileAttacking = this.ownHeroimmunewhileattacking;
            this.ownHero.immune = this.heroImmune;
            this.ownHero.numAttacksThisTurn = this.ownheroattacksThisRound;
            this.ownHero.windfury = herowindfury;

            this.enemyHero.Angr = this.enemyWeaponAttack;
            this.enemyHero.Hp = this.enemyherohp;
            this.enemyHero.frozen = this.enemyFrozen;
            this.enemyHero.armor = this.enemyherodefence;
            this.enemyHero.immune = this.enemyHeroImmune;
            this.enemyHero.Ready = false;

            this.ownHero.updateReadyness();

            // set Simulation stuff
            Ai.Instance.botBase = new BehaviorControl();

            if (this.evalFunction == "rush")
            {
                Ai.Instance.botBase = new BehaviorRush();
            }

            if (this.evalFunction == "mana")
            {
                Ai.Instance.botBase = new BehaviorMana();
            }

            Ai.Instance.setMaxWide(this.maxwide);
            Ai.Instance.setTwoTurnSimulation(false, this.twoturnsim);
            Settings.Instance.simEnemySecondTurn = this.simEnemy2Turn;

            // Ai.Instance.nextTurnSimulator.updateParams();
            Settings.Instance.playarround = this.playarround;
            Settings.Instance.playaroundprob = this.pprob1;
            Settings.Instance.playaroundprob2 = this.pprob2;
            Ai.Instance.setPlayAround();

            // save data
            Hrtprozis.Instance.updateOwnHero(
                this.ownHeroWeapon, 
                this.ownHeroWeaponAttack, 
                this.ownHeroWeaponDurability, 
                this.ownheroname, 
                heroability, 
                abilityReady, 
                this.ownHero);
            Hrtprozis.Instance.updateEnemyHero(
                this.enemyWeapon, 
                this.enemyWeaponAttack, 
                this.enemyWeaponDur, 
                this.enemyheroname, 
                this.enemmaxman, 
                enemyability, 
                this.enemyHero);

            Hrtprozis.Instance.updateMinions(this.ownminions, this.enemyminions);

            Hrtprozis.Instance.updateFatigueStats(
                this.ownDecksize, 
                this.ownFatigue, 
                this.enemyDecksize, 
                this.enemyFatigue);

            Handmanager.Instance.setHandcards(this.handcards, this.handcards.Count, this.enemyNumberHand);

            Probabilitymaker.Instance.setEnemySecretData(this.enemySecrets);

            Probabilitymaker.Instance.setTurnGraveYard(this.turnGraveYard);
            Probabilitymaker.Instance.stalaggDead = this.stalaggdead;
            Probabilitymaker.Instance.feugenDead = this.feugendead;

            if (og != string.Empty)
            {
                Probabilitymaker.Instance.readGraveyards(og, eg);
            }

            if (omd != string.Empty)
            {
                Probabilitymaker.Instance.readTurnGraveYard(omd, emd);
            }

            // Ai.Instance.enemyTurnSim.maxwide = ets;
            // Ai.Instance.enemySecondTurnSim.maxwide = ents;
            Settings.Instance.enemyTurnMaxWide = ets;
            Settings.Instance.enemySecondTurnMaxWide = ents;

            Settings.Instance.nextTurnDeep = ntssd;
            Settings.Instance.nextTurnMaxWide = ntssw;
            Settings.Instance.nextTurnTotalBoards = ntssm;

            // Ai.Instance.nextTurnSimulator.updateParams(ntssd, ntssw, ntssm);
            Settings.Instance.useSecretsPlayArround = dosecrets;
        }

        /// <summary>
        /// The create new minion.
        /// </summary>
        /// <param name="hc">
        /// The hc.
        /// </param>
        /// <param name="zonepos">
        /// The zonepos.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <returns>
        /// The <see cref="Minion"/>.
        /// </returns>
        public Minion createNewMinion(Handmanager.Handcard hc, int zonepos, bool own)
        {
            Minion m = new Minion();
            Handmanager.Handcard handc = new Handmanager.Handcard(hc);
            m.handcard = handc;
            m.own = own;
            m.isHero = false;
            m.entitiyID = hc.entity;
            m.Angr = hc.card.Attack;
            m.Hp = hc.card.Health;
            m.maxHp = hc.card.Health;
            m.name = hc.card.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.zonepos = zonepos;
            m.windfury = hc.card.windfury;
            m.taunt = hc.card.tank;
            m.charge = hc.card.Charge ? 1 : 0;
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
