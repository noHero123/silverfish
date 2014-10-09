// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardDB.cs" company="">
//   
// </copyright>
// <summary>
//   The targett.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    ///     The targett.
    /// </summary>
    public struct targett
    {
        #region Fields

        /// <summary>
        ///     The target.
        /// </summary>
        public int target;

        /// <summary>
        ///     The target entity.
        /// </summary>
        public int targetEntity;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="targett"/> Struktur. 
        /// Initializes a new instance of the <see cref="targett"/> struct.
        /// </summary>
        /// <param name="targ">
        /// The targ.
        /// </param>
        /// <param name="ent">
        /// The ent.
        /// </param>
        public targett(int targ, int ent)
        {
            this.target = targ;
            this.targetEntity = ent;
        }

        #endregion
    }

    /// <summary>
    ///     The card db.
    /// </summary>
    public class CardDB
    {
        // Data is stored in hearthstone-folder -> data->win cardxml0
        // (data-> cardxml0 seems outdated (blutelfkleriker has 3hp there >_>)
        #region Static Fields

        /// <summary>
        ///     The instance.
        /// </summary>
        private static CardDB instance;

        #endregion

        #region Fields

        /// <summary>
        ///     The illidanminion.
        /// </summary>
        public Card illidanminion;

        /// <summary>
        ///     The installed wrong.
        /// </summary>
        public bool installedWrong = false;

        /// <summary>
        ///     The teacherminion.
        /// </summary>
        public Card teacherminion;

        /// <summary>
        ///     The unknown card.
        /// </summary>
        public Card unknownCard;

        /// <summary>
        ///     The all card ids.
        /// </summary>
        private List<string> allCardIDS = new List<string>();

        /// <summary>
        ///     The cardid to card list.
        /// </summary>
        private Dictionary<cardIDEnum, Card> cardidToCardList = new Dictionary<cardIDEnum, Card>();

        /// <summary>
        ///     The cardlist.
        /// </summary>
        private List<Card> cardlist = new List<Card>();

        /// <summary>
        ///     The namelist.
        /// </summary>
        private List<string> namelist = new List<string>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Verhindert, dass eine Standardinstanz der <see cref="CardDB"/> Klasse erstellt wird. 
        ///     Prevents a default instance of the <see cref="CardDB"/> class from being created.
        /// </summary>
        private CardDB()
        {
            string[] lines = { };
            try
            {
                string path = Settings.Instance.path;
                lines = File.ReadAllLines(path + "_carddb.txt");
                Helpfunctions.Instance.ErrorLog("read carddb.txt");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find _carddb.txt");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("cant find _carddb.txt in " + Settings.Instance.path);
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("you installed it wrong");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                this.installedWrong = true;
            }

            this.cardlist.Clear();
            this.cardidToCardList.Clear();
            Card c = new Card();
            int de = 0;

            // placeholdercard
            Card plchldr = new Card();
            plchldr.name = cardName.unknown;
            plchldr.cost = 1000;
            this.namelist.Add("unknown");
            this.cardlist.Add(plchldr);
            this.unknownCard = this.cardlist[0];
            string name = string.Empty;
            foreach (string s in lines)
            {
                if (s.Contains("/Entity"))
                {
                    if (c.type == cardtype.ENCHANTMENT)
                    {
                        // Helpfunctions.Instance.logg(c.CardID);
                        // Helpfunctions.Instance.logg(c.name);
                        // Helpfunctions.Instance.logg(c.description);
                        continue;
                    }

                    if (name != string.Empty)
                    {
                        this.namelist.Add(name);
                    }

                    name = string.Empty;
                    if (c.name != cardName.unknown)
                    {
                        this.cardlist.Add(c);

                        // Helpfunctions.Instance.logg(c.name);
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
                    string temp = s.Split(new[] { "CardID=\"" }, StringSplitOptions.None)[1];
                    temp = temp.Replace("\">", string.Empty);

                    // c.CardID = temp;
                    this.allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);

                    // token:
                    if (temp.EndsWith("t"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("ds1_whelptoken"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_mirror"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_050"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_052"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_051"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("NEW1_009"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_152"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_boar"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_tk11"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_506a"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("skele21"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_tk9"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_finkle"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_598"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_tk34"))
                    {
                        c.isToken = true;
                    }

                    // if (c.isToken) Helpfunctions.Instance.ErrorLog(temp);
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
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Health = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Atk\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Attack = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Race\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.race = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Rarity\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.rarity = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Cost\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.cost = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"CardType\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    if (c.name != cardName.unknown)
                    {
                        // Helpfunctions.Instance.logg(temp);
                    }

                    int crdtype = Convert.ToInt32(temp);
                    if (crdtype == 10)
                    {
                        c.type = cardtype.HEROPWR;
                    }

                    if (crdtype == 4)
                    {
                        c.type = cardtype.MOB;
                    }

                    if (crdtype == 5)
                    {
                        c.type = cardtype.SPELL;
                    }

                    if (crdtype == 6)
                    {
                        c.type = cardtype.ENCHANTMENT;
                    }

                    if (crdtype == 7)
                    {
                        c.type = cardtype.WEAPON;
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
                    string temp = s.Replace("<enUS>", string.Empty);

                    temp = temp.Replace("</enUS>", string.Empty);
                    temp = temp.Replace("&lt;", string.Empty);
                    temp = temp.Replace("b&gt;", string.Empty);
                    temp = temp.Replace("/b&gt;", string.Empty);
                    temp = temp.ToLower();
                    if (de == 0)
                    {
                        temp = temp.Replace("'", string.Empty);
                        temp = temp.Replace(" ", string.Empty);
                        temp = temp.Replace(":", string.Empty);
                        temp = temp.Replace(".", string.Empty);
                        temp = temp.Replace("!", string.Empty);
                        temp = temp.Replace("-", string.Empty);

                        // temp = temp.Replace("ß", "ss");
                        // temp = temp.Replace("ü", "ue");
                        // temp = temp.Replace("ä", "ae");
                        // temp = temp.Replace("ö", "oe");

                        // Helpfunctions.Instance.logg(temp);
                        c.name = this.cardNamestringToEnum(temp);
                        name = temp;
                    }

                    if (de == 1)
                    {
                        // c.description = temp;
                        // if (c.description.Contains("choose one"))
                        if (temp.Contains("choose one"))
                        {
                            c.choice = true;

                            // Helpfunctions.Instance.logg(c.name + " is choice");
                        }
                    }

                    if (de == 2)
                    {
                        // c.targettext = temp;
                    }

                    de = -1;
                    continue;
                }

                if (s.Contains("<Tag name=\"Poisonous\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.poisionous = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Enrage\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Enrage = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"OneTurnEffect\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.oneTurnEffect = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Aura\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Aura = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Taunt\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.tank = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Battlecry\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.battlecry = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Windfury\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.windfury = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Deathrattle\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.deathrattle = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Durability\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Durability = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Elite\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Elite = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Combo\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Combo = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Recall\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Recall = true;
                    }

                    c.recallValue = 1;
                    if (c.name == cardName.forkedlightning)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.dustdevil)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.lightningstorm)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.lavaburst)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.feralspirit)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.doomhammer)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.earthelemental)
                    {
                        c.recallValue = 3;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"ImmuneToSpellpower\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.immuneToSpellpowerg = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Stealth\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Stealth = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Secret\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Secret = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Freeze\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Freeze = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"AdjacentBuff\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.AdjacentBuff = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Divine Shield\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Shield = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Charge\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Charge = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Silence\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Silence = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Morph\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Morph = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Spellpower\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Spellpower = true;
                    }

                    c.spellpowervalue = 1;
                    if (c.name == cardName.ancientmage)
                    {
                        c.spellpowervalue = 0;
                    }

                    if (c.name == cardName.malygos)
                    {
                        c.spellpowervalue = 5;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"GrantCharge\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.GrantCharge = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"HealTarget\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.HealTarget = true;
                    }

                    continue;
                }

                if (s.Contains("<PlayRequirement"))
                {
                    string temp = s.Split(new[] { "reqID=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    ErrorType2 et2 = (ErrorType2)Convert.ToInt32(temp);
                    c.playrequires.Add(et2);
                }

                if (s.Contains("<PlayRequirement reqID=\"12\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needEmptyPlacesForPlaying = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"41\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMinAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"8\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMaxAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"10\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needRaceForPlaying = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"23\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinNumberOfEnemy = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"45\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinTotalMinions = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"19\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinionsCapIfAvailable = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name="))
                {
                    string temp = s.Split(new[] { "<Tag name=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];

                    /*
                    if (temp != "DevState" && temp != "FlavorText" && temp != "ArtistName" && temp != "Cost" && temp != "EnchantmentIdleVisual" && temp != "EnchantmentBirthVisual" && temp != "Collectible" && temp != "CardSet" && temp != "AttackVisualType" && temp != "CardName" && temp != "Class" && temp != "CardTextInHand" && temp != "Rarity" && temp != "TriggerVisual" && temp != "Faction" && temp != "HowToGetThisGoldCard" && temp != "HowToGetThisCard" && temp != "CardTextInPlay")
                        Helpfunctions.Instance.logg(s);*/
                }
            }

            this.teacherminion = this.getCardDataFromID(cardIDEnum.NEW1_026t);
            this.illidanminion = this.getCardDataFromID(cardIDEnum.EX1_614t);
        }

        #endregion

        #region Enums

        /// <summary>
        ///     The error type 2.
        /// </summary>
        public enum ErrorType2
        {
            /// <summary>
            ///     The none.
            /// </summary>
            NONE, // =0

            /// <summary>
            ///     The re q_ minio n_ target.
            /// </summary>
            REQ_MINION_TARGET, // =1

            /// <summary>
            ///     The re q_ friendl y_ target.
            /// </summary>
            REQ_FRIENDLY_TARGET, // =2

            /// <summary>
            ///     The re q_ enem y_ target.
            /// </summary>
            REQ_ENEMY_TARGET, // =3

            /// <summary>
            ///     The re q_ damage d_ target.
            /// </summary>
            REQ_DAMAGED_TARGET, // =4

            /// <summary>
            ///     The re q_ enchante d_ target.
            /// </summary>
            REQ_ENCHANTED_TARGET,

            /// <summary>
            ///     The re q_ froze n_ target.
            /// </summary>
            REQ_FROZEN_TARGET,

            /// <summary>
            ///     The re q_ charg e_ target.
            /// </summary>
            REQ_CHARGE_TARGET,

            /// <summary>
            ///     The re q_ targe t_ ma x_ attack.
            /// </summary>
            REQ_TARGET_MAX_ATTACK, // =8

            /// <summary>
            ///     The re q_ nonsel f_ target.
            /// </summary>
            REQ_NONSELF_TARGET, // =9

            /// <summary>
            ///     The re q_ targe t_ wit h_ race.
            /// </summary>
            REQ_TARGET_WITH_RACE, // =10

            /// <summary>
            ///     The re q_ targe t_ t o_ play.
            /// </summary>
            REQ_TARGET_TO_PLAY, // =11 

            /// <summary>
            ///     The re q_ nu m_ minio n_ slots.
            /// </summary>
            REQ_NUM_MINION_SLOTS, // =12 

            /// <summary>
            ///     The re q_ weapo n_ equipped.
            /// </summary>
            REQ_WEAPON_EQUIPPED, // =13

            /// <summary>
            ///     The re q_ enoug h_ mana.
            /// </summary>
            REQ_ENOUGH_MANA, // =14

            /// <summary>
            ///     The re q_ you r_ turn.
            /// </summary>
            REQ_YOUR_TURN,

            /// <summary>
            ///     The re q_ nonstealt h_ enem y_ target.
            /// </summary>
            REQ_NONSTEALTH_ENEMY_TARGET,

            /// <summary>
            ///     The re q_ her o_ target.
            /// </summary>
            REQ_HERO_TARGET, // 17

            /// <summary>
            ///     The re q_ secre t_ cap.
            /// </summary>
            REQ_SECRET_CAP,

            /// <summary>
            ///     The re q_ minio n_ ca p_ i f_ targe t_ available.
            /// </summary>
            REQ_MINION_CAP_IF_TARGET_AVAILABLE, // 19

            /// <summary>
            ///     The re q_ minio n_ cap.
            /// </summary>
            REQ_MINION_CAP,

            /// <summary>
            ///     The re q_ targe t_ attacke d_ thi s_ turn.
            /// </summary>
            REQ_TARGET_ATTACKED_THIS_TURN,

            /// <summary>
            ///     The re q_ targe t_ i f_ available.
            /// </summary>
            REQ_TARGET_IF_AVAILABLE, // =22

            /// <summary>
            ///     The re q_ minimu m_ enem y_ minions.
            /// </summary>
            REQ_MINIMUM_ENEMY_MINIONS, // =23 /like spalen :D

            /// <summary>
            ///     The re q_ targe t_ fo r_ combo.
            /// </summary>
            REQ_TARGET_FOR_COMBO, // =24

            /// <summary>
            ///     The re q_ no t_ exhauste d_ activate.
            /// </summary>
            REQ_NOT_EXHAUSTED_ACTIVATE,

            /// <summary>
            ///     The re q_ uniqu e_ secret.
            /// </summary>
            REQ_UNIQUE_SECRET,

            /// <summary>
            ///     The re q_ targe t_ taunter.
            /// </summary>
            REQ_TARGET_TAUNTER,

            /// <summary>
            ///     The re q_ ca n_ b e_ attacked.
            /// </summary>
            REQ_CAN_BE_ATTACKED,

            /// <summary>
            ///     The re q_ actio n_ pw r_ i s_ maste r_ pwr.
            /// </summary>
            REQ_ACTION_PWR_IS_MASTER_PWR,

            /// <summary>
            ///     The re q_ targe t_ magnet.
            /// </summary>
            REQ_TARGET_MAGNET,

            /// <summary>
            ///     The re q_ attac k_ greate r_ tha n_0.
            /// </summary>
            REQ_ATTACK_GREATER_THAN_0,

            /// <summary>
            ///     The re q_ attacke r_ no t_ frozen.
            /// </summary>
            REQ_ATTACKER_NOT_FROZEN,

            /// <summary>
            ///     The re q_ her o_ o r_ minio n_ target.
            /// </summary>
            REQ_HERO_OR_MINION_TARGET,

            /// <summary>
            ///     The re q_ ca n_ b e_ targete d_ b y_ spells.
            /// </summary>
            REQ_CAN_BE_TARGETED_BY_SPELLS,

            /// <summary>
            ///     The re q_ subcar d_ i s_ playable.
            /// </summary>
            REQ_SUBCARD_IS_PLAYABLE,

            /// <summary>
            ///     The re q_ targe t_ fo r_ n o_ combo.
            /// </summary>
            REQ_TARGET_FOR_NO_COMBO,

            /// <summary>
            ///     The re q_ no t_ minio n_ jus t_ played.
            /// </summary>
            REQ_NOT_MINION_JUST_PLAYED,

            /// <summary>
            ///     The re q_ no t_ exhauste d_ her o_ power.
            /// </summary>
            REQ_NOT_EXHAUSTED_HERO_POWER,

            /// <summary>
            ///     The re q_ ca n_ b e_ targete d_ b y_ opponents.
            /// </summary>
            REQ_CAN_BE_TARGETED_BY_OPPONENTS,

            /// <summary>
            ///     The re q_ attacke r_ ca n_ attack.
            /// </summary>
            REQ_ATTACKER_CAN_ATTACK,

            /// <summary>
            ///     The re q_ targe t_ mi n_ attack.
            /// </summary>
            REQ_TARGET_MIN_ATTACK, // =41

            /// <summary>
            ///     The re q_ ca n_ b e_ targete d_ b y_ her o_ powers.
            /// </summary>
            REQ_CAN_BE_TARGETED_BY_HERO_POWERS,

            /// <summary>
            ///     The re q_ enem y_ targe t_ no t_ immune.
            /// </summary>
            REQ_ENEMY_TARGET_NOT_IMMUNE,

            /// <summary>
            ///     The re q_ entir e_ entourag e_ no t_ i n_ play.
            /// </summary>
            REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY, // 44 (totemic call)

            /// <summary>
            ///     The re q_ minimu m_ tota l_ minions.
            /// </summary>
            REQ_MINIMUM_TOTAL_MINIONS, // 45 (scharmuetzel)

            /// <summary>
            ///     The re q_ mus t_ targe t_ taunter.
            /// </summary>
            REQ_MUST_TARGET_TAUNTER, // =46

            /// <summary>
            ///     The re q_ undamage d_ target.
            /// </summary>
            REQ_UNDAMAGED_TARGET // =47
        }

        /// <summary>
        ///     The card id enum.
        /// </summary>
        public enum cardIDEnum
        {
            /// <summary>
            ///     The none.
            /// </summary>
            None,

            /// <summary>
            ///     The xx x_040.
            /// </summary>
            XXX_040,

            /// <summary>
            ///     The na x 5_01 h.
            /// </summary>
            NAX5_01H,

            /// <summary>
            ///     The c s 2_188 o.
            /// </summary>
            CS2_188o,

            /// <summary>
            ///     The na x 6_02 h.
            /// </summary>
            NAX6_02H,

            /// <summary>
            ///     The ne w 1_007 b.
            /// </summary>
            NEW1_007b,

            /// <summary>
            ///     The na x 6_02 e.
            /// </summary>
            NAX6_02e,

            /// <summary>
            ///     The t u 4 c_003.
            /// </summary>
            TU4c_003,

            /// <summary>
            ///     The xx x_024.
            /// </summary>
            XXX_024,

            /// <summary>
            ///     The e x 1_613.
            /// </summary>
            EX1_613,

            /// <summary>
            ///     The na x 8_01.
            /// </summary>
            NAX8_01,

            /// <summary>
            ///     The e x 1_295 o.
            /// </summary>
            EX1_295o,

            /// <summary>
            ///     The c s 2_059 o.
            /// </summary>
            CS2_059o,

            /// <summary>
            ///     The e x 1_133.
            /// </summary>
            EX1_133,

            /// <summary>
            ///     The ne w 1_018.
            /// </summary>
            NEW1_018,

            /// <summary>
            ///     The na x 15_03 t.
            /// </summary>
            NAX15_03t,

            /// <summary>
            ///     The e x 1_012.
            /// </summary>
            EX1_012,

            /// <summary>
            ///     The e x 1_178 a.
            /// </summary>
            EX1_178a,

            /// <summary>
            ///     The c s 2_231.
            /// </summary>
            CS2_231,

            /// <summary>
            ///     The e x 1_019 e.
            /// </summary>
            EX1_019e,

            /// <summary>
            ///     The cre d_12.
            /// </summary>
            CRED_12,

            /// <summary>
            ///     The c s 2_179.
            /// </summary>
            CS2_179,

            /// <summary>
            ///     The c s 2_045 e.
            /// </summary>
            CS2_045e,

            /// <summary>
            ///     The e x 1_244.
            /// </summary>
            EX1_244,

            /// <summary>
            ///     The e x 1_178 b.
            /// </summary>
            EX1_178b,

            /// <summary>
            ///     The xx x_030.
            /// </summary>
            XXX_030,

            /// <summary>
            ///     The na x 8_05.
            /// </summary>
            NAX8_05,

            /// <summary>
            ///     The e x 1_573 b.
            /// </summary>
            EX1_573b,

            /// <summary>
            ///     The t u 4 d_001.
            /// </summary>
            TU4d_001,

            /// <summary>
            ///     The ne w 1_007 a.
            /// </summary>
            NEW1_007a,

            /// <summary>
            ///     The na x 12_02 h.
            /// </summary>
            NAX12_02H,

            /// <summary>
            ///     The e x 1_345 t.
            /// </summary>
            EX1_345t,

            /// <summary>
            ///     The f p 1_007 t.
            /// </summary>
            FP1_007t,

            /// <summary>
            ///     The e x 1_025.
            /// </summary>
            EX1_025,

            /// <summary>
            ///     The e x 1_396.
            /// </summary>
            EX1_396,

            /// <summary>
            ///     The na x 9_03.
            /// </summary>
            NAX9_03,

            /// <summary>
            ///     The ne w 1_017.
            /// </summary>
            NEW1_017,

            /// <summary>
            ///     The ne w 1_008 a.
            /// </summary>
            NEW1_008a,

            /// <summary>
            ///     The e x 1_587 e.
            /// </summary>
            EX1_587e,

            /// <summary>
            ///     The e x 1_533.
            /// </summary>
            EX1_533,

            /// <summary>
            ///     The e x 1_522.
            /// </summary>
            EX1_522,

            /// <summary>
            ///     The na x 11_04.
            /// </summary>
            NAX11_04,

            /// <summary>
            ///     The ne w 1_026.
            /// </summary>
            NEW1_026,

            /// <summary>
            ///     The e x 1_398.
            /// </summary>
            EX1_398,

            /// <summary>
            ///     The na x 4_04.
            /// </summary>
            NAX4_04,

            /// <summary>
            ///     The e x 1_007.
            /// </summary>
            EX1_007,

            /// <summary>
            ///     The c s 1_112.
            /// </summary>
            CS1_112,

            /// <summary>
            ///     The cre d_17.
            /// </summary>
            CRED_17,

            /// <summary>
            ///     The ne w 1_036.
            /// </summary>
            NEW1_036,

            /// <summary>
            ///     The na x 3_03.
            /// </summary>
            NAX3_03,

            /// <summary>
            ///     The e x 1_355 e.
            /// </summary>
            EX1_355e,

            /// <summary>
            ///     The e x 1_258.
            /// </summary>
            EX1_258,

            /// <summary>
            ///     The her o_01.
            /// </summary>
            HERO_01,

            /// <summary>
            ///     The xx x_009.
            /// </summary>
            XXX_009,

            /// <summary>
            ///     The na x 6_01 h.
            /// </summary>
            NAX6_01H,

            /// <summary>
            ///     The na x 12_04 e.
            /// </summary>
            NAX12_04e,

            /// <summary>
            ///     The c s 2_087.
            /// </summary>
            CS2_087,

            /// <summary>
            ///     The drea m_05.
            /// </summary>
            DREAM_05,

            /// <summary>
            ///     The ne w 1_036 e.
            /// </summary>
            NEW1_036e,

            /// <summary>
            ///     The c s 2_092.
            /// </summary>
            CS2_092,

            /// <summary>
            ///     The c s 2_022.
            /// </summary>
            CS2_022,

            /// <summary>
            ///     The e x 1_046.
            /// </summary>
            EX1_046,

            /// <summary>
            ///     The xx x_005.
            /// </summary>
            XXX_005,

            /// <summary>
            ///     The pr o_001 b.
            /// </summary>
            PRO_001b,

            /// <summary>
            ///     The xx x_022.
            /// </summary>
            XXX_022,

            /// <summary>
            ///     The pr o_001 a.
            /// </summary>
            PRO_001a,

            /// <summary>
            ///     The na x 6_04.
            /// </summary>
            NAX6_04,

            /// <summary>
            ///     The na x 7_05.
            /// </summary>
            NAX7_05,

            /// <summary>
            ///     The c s 2_103.
            /// </summary>
            CS2_103,

            /// <summary>
            ///     The ne w 1_041.
            /// </summary>
            NEW1_041,

            /// <summary>
            ///     The e x 1_360.
            /// </summary>
            EX1_360,

            /// <summary>
            ///     The f p 1_023.
            /// </summary>
            FP1_023,

            /// <summary>
            ///     The ne w 1_038.
            /// </summary>
            NEW1_038,

            /// <summary>
            ///     The c s 2_009.
            /// </summary>
            CS2_009,

            /// <summary>
            ///     The na x 10_01 h.
            /// </summary>
            NAX10_01H,

            /// <summary>
            ///     The e x 1_010.
            /// </summary>
            EX1_010,

            /// <summary>
            ///     The c s 2_024.
            /// </summary>
            CS2_024,

            /// <summary>
            ///     The na x 9_05.
            /// </summary>
            NAX9_05,

            /// <summary>
            ///     The e x 1_565.
            /// </summary>
            EX1_565,

            /// <summary>
            ///     The c s 2_076.
            /// </summary>
            CS2_076,

            /// <summary>
            ///     The f p 1_004.
            /// </summary>
            FP1_004,

            /// <summary>
            ///     The c s 2_046 e.
            /// </summary>
            CS2_046e,

            /// <summary>
            ///     The c s 2_162.
            /// </summary>
            CS2_162,

            /// <summary>
            ///     The e x 1_110 t.
            /// </summary>
            EX1_110t,

            /// <summary>
            ///     The c s 2_104 e.
            /// </summary>
            CS2_104e,

            /// <summary>
            ///     The c s 2_181.
            /// </summary>
            CS2_181,

            /// <summary>
            ///     The e x 1_309.
            /// </summary>
            EX1_309,

            /// <summary>
            ///     The e x 1_354.
            /// </summary>
            EX1_354,

            /// <summary>
            ///     The na x 10_02 h.
            /// </summary>
            NAX10_02H,

            /// <summary>
            ///     The na x 7_04 h.
            /// </summary>
            NAX7_04H,

            /// <summary>
            ///     The t u 4 f_001.
            /// </summary>
            TU4f_001,

            /// <summary>
            ///     The xx x_018.
            /// </summary>
            XXX_018,

            /// <summary>
            ///     The e x 1_023.
            /// </summary>
            EX1_023,

            /// <summary>
            ///     The xx x_048.
            /// </summary>
            XXX_048,

            /// <summary>
            ///     The xx x_049.
            /// </summary>
            XXX_049,

            /// <summary>
            ///     The ne w 1_034.
            /// </summary>
            NEW1_034,

            /// <summary>
            ///     The c s 2_003.
            /// </summary>
            CS2_003,

            /// <summary>
            ///     The her o_06.
            /// </summary>
            HERO_06,

            /// <summary>
            ///     The c s 2_201.
            /// </summary>
            CS2_201,

            /// <summary>
            ///     The e x 1_508.
            /// </summary>
            EX1_508,

            /// <summary>
            ///     The e x 1_259.
            /// </summary>
            EX1_259,

            /// <summary>
            ///     The e x 1_341.
            /// </summary>
            EX1_341,

            /// <summary>
            ///     The drea m_05 e.
            /// </summary>
            DREAM_05e,

            /// <summary>
            ///     The cre d_09.
            /// </summary>
            CRED_09,

            /// <summary>
            ///     The e x 1_103.
            /// </summary>
            EX1_103,

            /// <summary>
            ///     The f p 1_021.
            /// </summary>
            FP1_021,

            /// <summary>
            ///     The e x 1_411.
            /// </summary>
            EX1_411,

            /// <summary>
            ///     The na x 1_04.
            /// </summary>
            NAX1_04,

            /// <summary>
            ///     The c s 2_053.
            /// </summary>
            CS2_053,

            /// <summary>
            ///     The c s 2_182.
            /// </summary>
            CS2_182,

            /// <summary>
            ///     The c s 2_008.
            /// </summary>
            CS2_008,

            /// <summary>
            ///     The c s 2_233.
            /// </summary>
            CS2_233,

            /// <summary>
            ///     The e x 1_626.
            /// </summary>
            EX1_626,

            /// <summary>
            ///     The e x 1_059.
            /// </summary>
            EX1_059,

            /// <summary>
            ///     The e x 1_334.
            /// </summary>
            EX1_334,

            /// <summary>
            ///     The e x 1_619.
            /// </summary>
            EX1_619,

            /// <summary>
            ///     The ne w 1_032.
            /// </summary>
            NEW1_032,

            /// <summary>
            ///     The e x 1_158 t.
            /// </summary>
            EX1_158t,

            /// <summary>
            ///     The e x 1_006.
            /// </summary>
            EX1_006,

            /// <summary>
            ///     The ne w 1_031.
            /// </summary>
            NEW1_031,

            /// <summary>
            ///     The na x 10_03.
            /// </summary>
            NAX10_03,

            /// <summary>
            ///     The drea m_04.
            /// </summary>
            DREAM_04,

            /// <summary>
            ///     The na x 1 h_01.
            /// </summary>
            NAX1h_01,

            /// <summary>
            ///     The c s 2_022 e.
            /// </summary>
            CS2_022e,

            /// <summary>
            ///     The e x 1_611 e.
            /// </summary>
            EX1_611e,

            /// <summary>
            ///     The e x 1_004.
            /// </summary>
            EX1_004,

            /// <summary>
            ///     The e x 1_014 te.
            /// </summary>
            EX1_014te,

            /// <summary>
            ///     The f p 1_005 e.
            /// </summary>
            FP1_005e,

            /// <summary>
            ///     The na x 12_03 e.
            /// </summary>
            NAX12_03e,

            /// <summary>
            ///     The e x 1_095.
            /// </summary>
            EX1_095,

            /// <summary>
            ///     The ne w 1_007.
            /// </summary>
            NEW1_007,

            /// <summary>
            ///     The e x 1_275.
            /// </summary>
            EX1_275,

            /// <summary>
            ///     The e x 1_245.
            /// </summary>
            EX1_245,

            /// <summary>
            ///     The e x 1_383.
            /// </summary>
            EX1_383,

            /// <summary>
            ///     The f p 1_016.
            /// </summary>
            FP1_016,

            /// <summary>
            ///     The e x 1_016 t.
            /// </summary>
            EX1_016t,

            /// <summary>
            ///     The c s 2_125.
            /// </summary>
            CS2_125,

            /// <summary>
            ///     The e x 1_137.
            /// </summary>
            EX1_137,

            /// <summary>
            ///     The e x 1_178 ae.
            /// </summary>
            EX1_178ae,

            /// <summary>
            ///     The d s 1_185.
            /// </summary>
            DS1_185,

            /// <summary>
            ///     The f p 1_010.
            /// </summary>
            FP1_010,

            /// <summary>
            ///     The e x 1_598.
            /// </summary>
            EX1_598,

            /// <summary>
            ///     The na x 9_07.
            /// </summary>
            NAX9_07,

            /// <summary>
            ///     The e x 1_304.
            /// </summary>
            EX1_304,

            /// <summary>
            ///     The e x 1_302.
            /// </summary>
            EX1_302,

            /// <summary>
            ///     The xx x_017.
            /// </summary>
            XXX_017,

            /// <summary>
            ///     The c s 2_011 o.
            /// </summary>
            CS2_011o,

            /// <summary>
            ///     The e x 1_614 t.
            /// </summary>
            EX1_614t,

            /// <summary>
            ///     The t u 4 a_006.
            /// </summary>
            TU4a_006,

            /// <summary>
            ///     The mekka 3 e.
            /// </summary>
            Mekka3e,

            /// <summary>
            ///     The c s 2_108.
            /// </summary>
            CS2_108,

            /// <summary>
            ///     The c s 2_046.
            /// </summary>
            CS2_046,

            /// <summary>
            ///     The e x 1_014 t.
            /// </summary>
            EX1_014t,

            /// <summary>
            ///     The ne w 1_005.
            /// </summary>
            NEW1_005,

            /// <summary>
            ///     The e x 1_062.
            /// </summary>
            EX1_062,

            /// <summary>
            ///     The e x 1_366 e.
            /// </summary>
            EX1_366e,

            /// <summary>
            ///     The mekka 1.
            /// </summary>
            Mekka1,

            /// <summary>
            ///     The xx x_007.
            /// </summary>
            XXX_007,

            /// <summary>
            ///     The tt_010 a.
            /// </summary>
            tt_010a,

            /// <summary>
            ///     The c s 2_017 o.
            /// </summary>
            CS2_017o,

            /// <summary>
            ///     The c s 2_072.
            /// </summary>
            CS2_072,

            /// <summary>
            ///     The e x 1_tk 28.
            /// </summary>
            EX1_tk28,

            /// <summary>
            ///     The e x 1_604 o.
            /// </summary>
            EX1_604o,

            /// <summary>
            ///     The f p 1_014.
            /// </summary>
            FP1_014,

            /// <summary>
            ///     The e x 1_084 e.
            /// </summary>
            EX1_084e,

            /// <summary>
            ///     The na x 3_01 h.
            /// </summary>
            NAX3_01H,

            /// <summary>
            ///     The na x 2_01.
            /// </summary>
            NAX2_01,

            /// <summary>
            ///     The e x 1_409 t.
            /// </summary>
            EX1_409t,

            /// <summary>
            ///     The cre d_07.
            /// </summary>
            CRED_07,

            /// <summary>
            ///     The na x 3_02 h.
            /// </summary>
            NAX3_02H,

            /// <summary>
            ///     The t u 4 e_002.
            /// </summary>
            TU4e_002,

            /// <summary>
            ///     The e x 1_507.
            /// </summary>
            EX1_507,

            /// <summary>
            ///     The e x 1_144.
            /// </summary>
            EX1_144,

            /// <summary>
            ///     The c s 2_038.
            /// </summary>
            CS2_038,

            /// <summary>
            ///     The e x 1_093.
            /// </summary>
            EX1_093,

            /// <summary>
            ///     The c s 2_080.
            /// </summary>
            CS2_080,

            /// <summary>
            ///     The c s 1_129 e.
            /// </summary>
            CS1_129e,

            /// <summary>
            ///     The xx x_013.
            /// </summary>
            XXX_013,

            /// <summary>
            ///     The e x 1_005.
            /// </summary>
            EX1_005,

            /// <summary>
            ///     The e x 1_382.
            /// </summary>
            EX1_382,

            /// <summary>
            ///     The na x 13_02 e.
            /// </summary>
            NAX13_02e,

            /// <summary>
            ///     The f p 1_020 e.
            /// </summary>
            FP1_020e,

            /// <summary>
            ///     The e x 1_603 e.
            /// </summary>
            EX1_603e,

            /// <summary>
            ///     The c s 2_028.
            /// </summary>
            CS2_028,

            /// <summary>
            ///     The t u 4 f_002.
            /// </summary>
            TU4f_002,

            /// <summary>
            ///     The e x 1_538.
            /// </summary>
            EX1_538,

            /// <summary>
            ///     The gam e_003 e.
            /// </summary>
            GAME_003e,

            /// <summary>
            ///     The drea m_02.
            /// </summary>
            DREAM_02,

            /// <summary>
            ///     The e x 1_581.
            /// </summary>
            EX1_581,

            /// <summary>
            ///     The na x 15_01 h.
            /// </summary>
            NAX15_01H,

            /// <summary>
            ///     The e x 1_131 t.
            /// </summary>
            EX1_131t,

            /// <summary>
            ///     The c s 2_147.
            /// </summary>
            CS2_147,

            /// <summary>
            ///     The c s 1_113.
            /// </summary>
            CS1_113,

            /// <summary>
            ///     The c s 2_161.
            /// </summary>
            CS2_161,

            /// <summary>
            ///     The c s 2_031.
            /// </summary>
            CS2_031,

            /// <summary>
            ///     The e x 1_166 b.
            /// </summary>
            EX1_166b,

            /// <summary>
            ///     The e x 1_066.
            /// </summary>
            EX1_066,

            /// <summary>
            ///     The t u 4 c_007.
            /// </summary>
            TU4c_007,

            /// <summary>
            ///     The e x 1_355.
            /// </summary>
            EX1_355,

            /// <summary>
            ///     The e x 1_507 e.
            /// </summary>
            EX1_507e,

            /// <summary>
            ///     The e x 1_534.
            /// </summary>
            EX1_534,

            /// <summary>
            ///     The e x 1_162.
            /// </summary>
            EX1_162,

            /// <summary>
            ///     The t u 4 a_004.
            /// </summary>
            TU4a_004,

            /// <summary>
            ///     The e x 1_363.
            /// </summary>
            EX1_363,

            /// <summary>
            ///     The e x 1_164 a.
            /// </summary>
            EX1_164a,

            /// <summary>
            ///     The c s 2_188.
            /// </summary>
            CS2_188,

            /// <summary>
            ///     The e x 1_016.
            /// </summary>
            EX1_016,

            /// <summary>
            ///     The na x 6_03 t.
            /// </summary>
            NAX6_03t,

            /// <summary>
            ///     The e x 1_tk 31.
            /// </summary>
            EX1_tk31,

            /// <summary>
            ///     The e x 1_603.
            /// </summary>
            EX1_603,

            /// <summary>
            ///     The e x 1_238.
            /// </summary>
            EX1_238,

            /// <summary>
            ///     The e x 1_166.
            /// </summary>
            EX1_166,

            /// <summary>
            ///     The d s 1 h_292.
            /// </summary>
            DS1h_292,

            /// <summary>
            ///     The d s 1_183.
            /// </summary>
            DS1_183,

            /// <summary>
            ///     The na x 15_03 n.
            /// </summary>
            NAX15_03n,

            /// <summary>
            ///     The na x 8_02 h.
            /// </summary>
            NAX8_02H,

            /// <summary>
            ///     The na x 7_01 h.
            /// </summary>
            NAX7_01H,

            /// <summary>
            ///     The na x 9_02 h.
            /// </summary>
            NAX9_02H,

            /// <summary>
            ///     The cre d_11.
            /// </summary>
            CRED_11,

            /// <summary>
            ///     The xx x_019.
            /// </summary>
            XXX_019,

            /// <summary>
            ///     The e x 1_076.
            /// </summary>
            EX1_076,

            /// <summary>
            ///     The e x 1_048.
            /// </summary>
            EX1_048,

            /// <summary>
            ///     The c s 2_038 e.
            /// </summary>
            CS2_038e,

            /// <summary>
            ///     The f p 1_026.
            /// </summary>
            FP1_026,

            /// <summary>
            ///     The c s 2_074.
            /// </summary>
            CS2_074,

            /// <summary>
            ///     The f p 1_027.
            /// </summary>
            FP1_027,

            /// <summary>
            ///     The e x 1_323 w.
            /// </summary>
            EX1_323w,

            /// <summary>
            ///     The e x 1_129.
            /// </summary>
            EX1_129,

            /// <summary>
            ///     The ne w 1_024 o.
            /// </summary>
            NEW1_024o,

            /// <summary>
            ///     The na x 11_02.
            /// </summary>
            NAX11_02,

            /// <summary>
            ///     The e x 1_405.
            /// </summary>
            EX1_405,

            /// <summary>
            ///     The e x 1_317.
            /// </summary>
            EX1_317,

            /// <summary>
            ///     The e x 1_606.
            /// </summary>
            EX1_606,

            /// <summary>
            ///     The e x 1_590 e.
            /// </summary>
            EX1_590e,

            /// <summary>
            ///     The xx x_044.
            /// </summary>
            XXX_044,

            /// <summary>
            ///     The c s 2_074 e.
            /// </summary>
            CS2_074e,

            /// <summary>
            ///     The t u 4 a_005.
            /// </summary>
            TU4a_005,

            /// <summary>
            ///     The f p 1_006.
            /// </summary>
            FP1_006,

            /// <summary>
            ///     The e x 1_258 e.
            /// </summary>
            EX1_258e,

            /// <summary>
            ///     The t u 4 f_004 o.
            /// </summary>
            TU4f_004o,

            /// <summary>
            ///     The ne w 1_008.
            /// </summary>
            NEW1_008,

            /// <summary>
            ///     The c s 2_119.
            /// </summary>
            CS2_119,

            /// <summary>
            ///     The ne w 1_017 e.
            /// </summary>
            NEW1_017e,

            /// <summary>
            ///     The e x 1_334 e.
            /// </summary>
            EX1_334e,

            /// <summary>
            ///     The t u 4 e_001.
            /// </summary>
            TU4e_001,

            /// <summary>
            ///     The c s 2_121.
            /// </summary>
            CS2_121,

            /// <summary>
            ///     The c s 1 h_001.
            /// </summary>
            CS1h_001,

            /// <summary>
            ///     The e x 1_tk 34.
            /// </summary>
            EX1_tk34,

            /// <summary>
            ///     The ne w 1_020.
            /// </summary>
            NEW1_020,

            /// <summary>
            ///     The c s 2_196.
            /// </summary>
            CS2_196,

            /// <summary>
            ///     The e x 1_312.
            /// </summary>
            EX1_312,

            /// <summary>
            ///     The na x 1_01.
            /// </summary>
            NAX1_01,

            /// <summary>
            ///     The f p 1_022.
            /// </summary>
            FP1_022,

            /// <summary>
            ///     The e x 1_160 b.
            /// </summary>
            EX1_160b,

            /// <summary>
            ///     The e x 1_563.
            /// </summary>
            EX1_563,

            /// <summary>
            ///     The xx x_039.
            /// </summary>
            XXX_039,

            /// <summary>
            ///     The f p 1_031.
            /// </summary>
            FP1_031,

            /// <summary>
            ///     The c s 2_087 e.
            /// </summary>
            CS2_087e,

            /// <summary>
            ///     The e x 1_613 e.
            /// </summary>
            EX1_613e,

            /// <summary>
            ///     The na x 9_02.
            /// </summary>
            NAX9_02,

            /// <summary>
            ///     The ne w 1_029.
            /// </summary>
            NEW1_029,

            /// <summary>
            ///     The c s 1_129.
            /// </summary>
            CS1_129,

            /// <summary>
            ///     The her o_03.
            /// </summary>
            HERO_03,

            /// <summary>
            ///     The mekka 4 t.
            /// </summary>
            Mekka4t,

            /// <summary>
            ///     The e x 1_158.
            /// </summary>
            EX1_158,

            /// <summary>
            ///     The xx x_010.
            /// </summary>
            XXX_010,

            /// <summary>
            ///     The ne w 1_025.
            /// </summary>
            NEW1_025,

            /// <summary>
            ///     The f p 1_012 t.
            /// </summary>
            FP1_012t,

            /// <summary>
            ///     The e x 1_083.
            /// </summary>
            EX1_083,

            /// <summary>
            ///     The e x 1_295.
            /// </summary>
            EX1_295,

            /// <summary>
            ///     The e x 1_407.
            /// </summary>
            EX1_407,

            /// <summary>
            ///     The ne w 1_004.
            /// </summary>
            NEW1_004,

            /// <summary>
            ///     The f p 1_019.
            /// </summary>
            FP1_019,

            /// <summary>
            ///     The pr o_001 at.
            /// </summary>
            PRO_001at,

            /// <summary>
            ///     The na x 13_03 e.
            /// </summary>
            NAX13_03e,

            /// <summary>
            ///     The e x 1_625 t.
            /// </summary>
            EX1_625t,

            /// <summary>
            ///     The e x 1_014.
            /// </summary>
            EX1_014,

            /// <summary>
            ///     The cre d_04.
            /// </summary>
            CRED_04,

            /// <summary>
            ///     The na x 12_01 h.
            /// </summary>
            NAX12_01H,

            /// <summary>
            ///     The c s 2_097.
            /// </summary>
            CS2_097,

            /// <summary>
            ///     The e x 1_558.
            /// </summary>
            EX1_558,

            /// <summary>
            ///     The xx x_047.
            /// </summary>
            XXX_047,

            /// <summary>
            ///     The e x 1_tk 29.
            /// </summary>
            EX1_tk29,

            /// <summary>
            ///     The c s 2_186.
            /// </summary>
            CS2_186,

            /// <summary>
            ///     The e x 1_084.
            /// </summary>
            EX1_084,

            /// <summary>
            ///     The ne w 1_012.
            /// </summary>
            NEW1_012,

            /// <summary>
            ///     The f p 1_014 t.
            /// </summary>
            FP1_014t,

            /// <summary>
            ///     The na x 1_03.
            /// </summary>
            NAX1_03,

            /// <summary>
            ///     The e x 1_623 e.
            /// </summary>
            EX1_623e,

            /// <summary>
            ///     The e x 1_578.
            /// </summary>
            EX1_578,

            /// <summary>
            ///     The c s 2_073 e 2.
            /// </summary>
            CS2_073e2,

            /// <summary>
            ///     The c s 2_221.
            /// </summary>
            CS2_221,

            /// <summary>
            ///     The e x 1_019.
            /// </summary>
            EX1_019,

            /// <summary>
            ///     The na x 15_04 a.
            /// </summary>
            NAX15_04a,

            /// <summary>
            ///     The f p 1_019 t.
            /// </summary>
            FP1_019t,

            /// <summary>
            ///     The e x 1_132.
            /// </summary>
            EX1_132,

            /// <summary>
            ///     The e x 1_284.
            /// </summary>
            EX1_284,

            /// <summary>
            ///     The e x 1_105.
            /// </summary>
            EX1_105,

            /// <summary>
            ///     The ne w 1_011.
            /// </summary>
            NEW1_011,

            /// <summary>
            ///     The na x 9_07 e.
            /// </summary>
            NAX9_07e,

            /// <summary>
            ///     The e x 1_017.
            /// </summary>
            EX1_017,

            /// <summary>
            ///     The e x 1_249.
            /// </summary>
            EX1_249,

            /// <summary>
            ///     The e x 1_162 o.
            /// </summary>
            EX1_162o,

            /// <summary>
            ///     The f p 1_002 t.
            /// </summary>
            FP1_002t,

            /// <summary>
            ///     The na x 3_02.
            /// </summary>
            NAX3_02,

            /// <summary>
            ///     The e x 1_313.
            /// </summary>
            EX1_313,

            /// <summary>
            ///     The e x 1_549 o.
            /// </summary>
            EX1_549o,

            /// <summary>
            ///     The e x 1_091 o.
            /// </summary>
            EX1_091o,

            /// <summary>
            ///     The c s 2_084 e.
            /// </summary>
            CS2_084e,

            /// <summary>
            ///     The e x 1_155 b.
            /// </summary>
            EX1_155b,

            /// <summary>
            ///     The na x 11_01.
            /// </summary>
            NAX11_01,

            /// <summary>
            ///     The ne w 1_033.
            /// </summary>
            NEW1_033,

            /// <summary>
            ///     The c s 2_106.
            /// </summary>
            CS2_106,

            /// <summary>
            ///     The xx x_002.
            /// </summary>
            XXX_002,

            /// <summary>
            ///     The f p 1_018.
            /// </summary>
            FP1_018,

            /// <summary>
            ///     The ne w 1_036 e 2.
            /// </summary>
            NEW1_036e2,

            /// <summary>
            ///     The xx x_004.
            /// </summary>
            XXX_004,

            /// <summary>
            ///     The na x 11_02 h.
            /// </summary>
            NAX11_02H,

            /// <summary>
            ///     The c s 2_122 e.
            /// </summary>
            CS2_122e,

            /// <summary>
            ///     The d s 1_233.
            /// </summary>
            DS1_233,

            /// <summary>
            ///     The d s 1_175.
            /// </summary>
            DS1_175,

            /// <summary>
            ///     The ne w 1_024.
            /// </summary>
            NEW1_024,

            /// <summary>
            ///     The c s 2_189.
            /// </summary>
            CS2_189,

            /// <summary>
            ///     The cre d_10.
            /// </summary>
            CRED_10,

            /// <summary>
            ///     The ne w 1_037.
            /// </summary>
            NEW1_037,

            /// <summary>
            ///     The e x 1_414.
            /// </summary>
            EX1_414,

            /// <summary>
            ///     The e x 1_538 t.
            /// </summary>
            EX1_538t,

            /// <summary>
            ///     The f p 1_030 e.
            /// </summary>
            FP1_030e,

            /// <summary>
            ///     The e x 1_586.
            /// </summary>
            EX1_586,

            /// <summary>
            ///     The e x 1_310.
            /// </summary>
            EX1_310,

            /// <summary>
            ///     The ne w 1_010.
            /// </summary>
            NEW1_010,

            /// <summary>
            ///     The c s 2_103 e.
            /// </summary>
            CS2_103e,

            /// <summary>
            ///     The e x 1_080 o.
            /// </summary>
            EX1_080o,

            /// <summary>
            ///     The c s 2_005 o.
            /// </summary>
            CS2_005o,

            /// <summary>
            ///     The e x 1_363 e 2.
            /// </summary>
            EX1_363e2,

            /// <summary>
            ///     The e x 1_534 t.
            /// </summary>
            EX1_534t,

            /// <summary>
            ///     The f p 1_028.
            /// </summary>
            FP1_028,

            /// <summary>
            ///     The e x 1_604.
            /// </summary>
            EX1_604,

            /// <summary>
            ///     The e x 1_160.
            /// </summary>
            EX1_160,

            /// <summary>
            ///     The e x 1_165 t 1.
            /// </summary>
            EX1_165t1,

            /// <summary>
            ///     The c s 2_062.
            /// </summary>
            CS2_062,

            /// <summary>
            ///     The c s 2_155.
            /// </summary>
            CS2_155,

            /// <summary>
            ///     The c s 2_213.
            /// </summary>
            CS2_213,

            /// <summary>
            ///     The t u 4 f_007.
            /// </summary>
            TU4f_007,

            /// <summary>
            ///     The gam e_004.
            /// </summary>
            GAME_004,

            /// <summary>
            ///     The na x 5_01.
            /// </summary>
            NAX5_01,

            /// <summary>
            ///     The xx x_020.
            /// </summary>
            XXX_020,

            /// <summary>
            ///     The na x 15_02 h.
            /// </summary>
            NAX15_02H,

            /// <summary>
            ///     The c s 2_004.
            /// </summary>
            CS2_004,

            /// <summary>
            ///     The na x 2_03 h.
            /// </summary>
            NAX2_03H,

            /// <summary>
            ///     The e x 1_561 e.
            /// </summary>
            EX1_561e,

            /// <summary>
            ///     The c s 2_023.
            /// </summary>
            CS2_023,

            /// <summary>
            ///     The e x 1_164.
            /// </summary>
            EX1_164,

            /// <summary>
            ///     The e x 1_009.
            /// </summary>
            EX1_009,

            /// <summary>
            ///     The na x 6_01.
            /// </summary>
            NAX6_01,

            /// <summary>
            ///     The f p 1_007.
            /// </summary>
            FP1_007,

            /// <summary>
            ///     The na x 1 h_04.
            /// </summary>
            NAX1h_04,

            /// <summary>
            ///     The na x 2_05 h.
            /// </summary>
            NAX2_05H,

            /// <summary>
            ///     The na x 10_02.
            /// </summary>
            NAX10_02,

            /// <summary>
            ///     The e x 1_345.
            /// </summary>
            EX1_345,

            /// <summary>
            ///     The e x 1_116.
            /// </summary>
            EX1_116,

            /// <summary>
            ///     The e x 1_399.
            /// </summary>
            EX1_399,

            /// <summary>
            ///     The e x 1_587.
            /// </summary>
            EX1_587,

            /// <summary>
            ///     The xx x_026.
            /// </summary>
            XXX_026,

            /// <summary>
            ///     The e x 1_571.
            /// </summary>
            EX1_571,

            /// <summary>
            ///     The e x 1_335.
            /// </summary>
            EX1_335,

            /// <summary>
            ///     The xx x_050.
            /// </summary>
            XXX_050,

            /// <summary>
            ///     The t u 4 e_004.
            /// </summary>
            TU4e_004,

            /// <summary>
            ///     The her o_08.
            /// </summary>
            HERO_08,

            /// <summary>
            ///     The e x 1_166 a.
            /// </summary>
            EX1_166a,

            /// <summary>
            ///     The na x 2_03.
            /// </summary>
            NAX2_03,

            /// <summary>
            ///     The e x 1_finkle.
            /// </summary>
            EX1_finkle,

            /// <summary>
            ///     The na x 4_03 h.
            /// </summary>
            NAX4_03H,

            /// <summary>
            ///     The e x 1_164 b.
            /// </summary>
            EX1_164b,

            /// <summary>
            ///     The e x 1_283.
            /// </summary>
            EX1_283,

            /// <summary>
            ///     The e x 1_339.
            /// </summary>
            EX1_339,

            /// <summary>
            ///     The cre d_13.
            /// </summary>
            CRED_13,

            /// <summary>
            ///     The e x 1_178 be.
            /// </summary>
            EX1_178be,

            /// <summary>
            ///     The e x 1_531.
            /// </summary>
            EX1_531,

            /// <summary>
            ///     The e x 1_134.
            /// </summary>
            EX1_134,

            /// <summary>
            ///     The e x 1_350.
            /// </summary>
            EX1_350,

            /// <summary>
            ///     The e x 1_308.
            /// </summary>
            EX1_308,

            /// <summary>
            ///     The c s 2_197.
            /// </summary>
            CS2_197,

            /// <summary>
            ///     The skele 21.
            /// </summary>
            skele21,

            /// <summary>
            ///     The c s 2_222 o.
            /// </summary>
            CS2_222o,

            /// <summary>
            ///     The xx x_015.
            /// </summary>
            XXX_015,

            /// <summary>
            ///     The f p 1_013.
            /// </summary>
            FP1_013,

            /// <summary>
            ///     The ne w 1_006.
            /// </summary>
            NEW1_006,

            /// <summary>
            ///     The e x 1_399 e.
            /// </summary>
            EX1_399e,

            /// <summary>
            ///     The e x 1_509.
            /// </summary>
            EX1_509,

            /// <summary>
            ///     The e x 1_612.
            /// </summary>
            EX1_612,

            /// <summary>
            ///     The na x 8_05 t.
            /// </summary>
            NAX8_05t,

            /// <summary>
            ///     The na x 9_05 h.
            /// </summary>
            NAX9_05H,

            /// <summary>
            ///     The e x 1_021.
            /// </summary>
            EX1_021,

            /// <summary>
            ///     The c s 2_041 e.
            /// </summary>
            CS2_041e,

            /// <summary>
            ///     The c s 2_226.
            /// </summary>
            CS2_226,

            /// <summary>
            ///     The e x 1_608.
            /// </summary>
            EX1_608,

            /// <summary>
            ///     The na x 13_05 h.
            /// </summary>
            NAX13_05H,

            /// <summary>
            ///     The na x 13_04 h.
            /// </summary>
            NAX13_04H,

            /// <summary>
            ///     The t u 4 c_008.
            /// </summary>
            TU4c_008,

            /// <summary>
            ///     The e x 1_624.
            /// </summary>
            EX1_624,

            /// <summary>
            ///     The e x 1_616.
            /// </summary>
            EX1_616,

            /// <summary>
            ///     The e x 1_008.
            /// </summary>
            EX1_008,

            /// <summary>
            ///     The placeholder card.
            /// </summary>
            PlaceholderCard,

            /// <summary>
            ///     The xx x_016.
            /// </summary>
            XXX_016,

            /// <summary>
            ///     The e x 1_045.
            /// </summary>
            EX1_045,

            /// <summary>
            ///     The e x 1_015.
            /// </summary>
            EX1_015,

            /// <summary>
            ///     The gam e_003.
            /// </summary>
            GAME_003,

            /// <summary>
            ///     The c s 2_171.
            /// </summary>
            CS2_171,

            /// <summary>
            ///     The c s 2_041.
            /// </summary>
            CS2_041,

            /// <summary>
            ///     The e x 1_128.
            /// </summary>
            EX1_128,

            /// <summary>
            ///     The c s 2_112.
            /// </summary>
            CS2_112,

            /// <summary>
            ///     The her o_07.
            /// </summary>
            HERO_07,

            /// <summary>
            ///     The e x 1_412.
            /// </summary>
            EX1_412,

            /// <summary>
            ///     The e x 1_612 o.
            /// </summary>
            EX1_612o,

            /// <summary>
            ///     The c s 2_117.
            /// </summary>
            CS2_117,

            /// <summary>
            ///     The xx x_009 e.
            /// </summary>
            XXX_009e,

            /// <summary>
            ///     The e x 1_562.
            /// </summary>
            EX1_562,

            /// <summary>
            ///     The e x 1_055.
            /// </summary>
            EX1_055,

            /// <summary>
            ///     The na x 9_06.
            /// </summary>
            NAX9_06,

            /// <summary>
            ///     The t u 4 e_007.
            /// </summary>
            TU4e_007,

            /// <summary>
            ///     The f p 1_012.
            /// </summary>
            FP1_012,

            /// <summary>
            ///     The e x 1_317 t.
            /// </summary>
            EX1_317t,

            /// <summary>
            ///     The e x 1_004 e.
            /// </summary>
            EX1_004e,

            /// <summary>
            ///     The e x 1_278.
            /// </summary>
            EX1_278,

            /// <summary>
            ///     The c s 2_tk 1.
            /// </summary>
            CS2_tk1,

            /// <summary>
            ///     The e x 1_590.
            /// </summary>
            EX1_590,

            /// <summary>
            ///     The c s 1_130.
            /// </summary>
            CS1_130,

            /// <summary>
            ///     The ne w 1_008 b.
            /// </summary>
            NEW1_008b,

            /// <summary>
            ///     The e x 1_365.
            /// </summary>
            EX1_365,

            /// <summary>
            ///     The c s 2_141.
            /// </summary>
            CS2_141,

            /// <summary>
            ///     The pr o_001.
            /// </summary>
            PRO_001,

            /// <summary>
            ///     The na x 8_04 t.
            /// </summary>
            NAX8_04t,

            /// <summary>
            ///     The c s 2_173.
            /// </summary>
            CS2_173,

            /// <summary>
            ///     The c s 2_017.
            /// </summary>
            CS2_017,

            /// <summary>
            ///     The cre d_16.
            /// </summary>
            CRED_16,

            /// <summary>
            ///     The e x 1_392.
            /// </summary>
            EX1_392,

            /// <summary>
            ///     The e x 1_593.
            /// </summary>
            EX1_593,

            /// <summary>
            ///     The f p 1_023 e.
            /// </summary>
            FP1_023e,

            /// <summary>
            ///     The na x 1_05.
            /// </summary>
            NAX1_05,

            /// <summary>
            ///     The t u 4 d_002.
            /// </summary>
            TU4d_002,

            /// <summary>
            ///     The cre d_15.
            /// </summary>
            CRED_15,

            /// <summary>
            ///     The e x 1_049.
            /// </summary>
            EX1_049,

            /// <summary>
            ///     The e x 1_002.
            /// </summary>
            EX1_002,

            /// <summary>
            ///     The t u 4 f_005.
            /// </summary>
            TU4f_005,

            /// <summary>
            ///     The ne w 1_029 t.
            /// </summary>
            NEW1_029t,

            /// <summary>
            ///     The t u 4 a_001.
            /// </summary>
            TU4a_001,

            /// <summary>
            ///     The c s 2_056.
            /// </summary>
            CS2_056,

            /// <summary>
            ///     The e x 1_596.
            /// </summary>
            EX1_596,

            /// <summary>
            ///     The e x 1_136.
            /// </summary>
            EX1_136,

            /// <summary>
            ///     The e x 1_323.
            /// </summary>
            EX1_323,

            /// <summary>
            ///     The c s 2_073.
            /// </summary>
            CS2_073,

            /// <summary>
            ///     The e x 1_246 e.
            /// </summary>
            EX1_246e,

            /// <summary>
            ///     The na x 12_01.
            /// </summary>
            NAX12_01,

            /// <summary>
            ///     The e x 1_244 e.
            /// </summary>
            EX1_244e,

            /// <summary>
            ///     The e x 1_001.
            /// </summary>
            EX1_001,

            /// <summary>
            ///     The e x 1_607 e.
            /// </summary>
            EX1_607e,

            /// <summary>
            ///     The e x 1_044.
            /// </summary>
            EX1_044,

            /// <summary>
            ///     The e x 1_573 ae.
            /// </summary>
            EX1_573ae,

            /// <summary>
            ///     The xx x_025.
            /// </summary>
            XXX_025,

            /// <summary>
            ///     The cre d_06.
            /// </summary>
            CRED_06,

            /// <summary>
            ///     The mekka 4.
            /// </summary>
            Mekka4,

            /// <summary>
            ///     The c s 2_142.
            /// </summary>
            CS2_142,

            /// <summary>
            ///     The t u 4 f_004.
            /// </summary>
            TU4f_004,

            /// <summary>
            ///     The na x 5_02 h.
            /// </summary>
            NAX5_02H,

            /// <summary>
            ///     The e x 1_411 e 2.
            /// </summary>
            EX1_411e2,

            /// <summary>
            ///     The e x 1_573.
            /// </summary>
            EX1_573,

            /// <summary>
            ///     The f p 1_009.
            /// </summary>
            FP1_009,

            /// <summary>
            ///     The c s 2_050.
            /// </summary>
            CS2_050,

            /// <summary>
            ///     The na x 4_03.
            /// </summary>
            NAX4_03,

            /// <summary>
            ///     The c s 2_063 e.
            /// </summary>
            CS2_063e,

            /// <summary>
            ///     The na x 2_05.
            /// </summary>
            NAX2_05,

            /// <summary>
            ///     The e x 1_390.
            /// </summary>
            EX1_390,

            /// <summary>
            ///     The e x 1_610.
            /// </summary>
            EX1_610,

            /// <summary>
            ///     The hexfrog.
            /// </summary>
            hexfrog,

            /// <summary>
            ///     The c s 2_181 e.
            /// </summary>
            CS2_181e,

            /// <summary>
            ///     The na x 6_02.
            /// </summary>
            NAX6_02,

            /// <summary>
            ///     The xx x_027.
            /// </summary>
            XXX_027,

            /// <summary>
            ///     The c s 2_082.
            /// </summary>
            CS2_082,

            /// <summary>
            ///     The ne w 1_040.
            /// </summary>
            NEW1_040,

            /// <summary>
            ///     The drea m_01.
            /// </summary>
            DREAM_01,

            /// <summary>
            ///     The e x 1_595.
            /// </summary>
            EX1_595,

            /// <summary>
            ///     The c s 2_013.
            /// </summary>
            CS2_013,

            /// <summary>
            ///     The c s 2_077.
            /// </summary>
            CS2_077,

            /// <summary>
            ///     The ne w 1_014.
            /// </summary>
            NEW1_014,

            /// <summary>
            ///     The cre d_05.
            /// </summary>
            CRED_05,

            /// <summary>
            ///     The gam e_002.
            /// </summary>
            GAME_002,

            /// <summary>
            ///     The e x 1_165.
            /// </summary>
            EX1_165,

            /// <summary>
            ///     The c s 2_013 t.
            /// </summary>
            CS2_013t,

            /// <summary>
            ///     The na x 4_04 h.
            /// </summary>
            NAX4_04H,

            /// <summary>
            ///     The e x 1_tk 11.
            /// </summary>
            EX1_tk11,

            /// <summary>
            ///     The e x 1_591.
            /// </summary>
            EX1_591,

            /// <summary>
            ///     The e x 1_549.
            /// </summary>
            EX1_549,

            /// <summary>
            ///     The c s 2_045.
            /// </summary>
            CS2_045,

            /// <summary>
            ///     The c s 2_237.
            /// </summary>
            CS2_237,

            /// <summary>
            ///     The c s 2_027.
            /// </summary>
            CS2_027,

            /// <summary>
            ///     The e x 1_508 o.
            /// </summary>
            EX1_508o,

            /// <summary>
            ///     The na x 14_03.
            /// </summary>
            NAX14_03,

            /// <summary>
            ///     The c s 2_101 t.
            /// </summary>
            CS2_101t,

            /// <summary>
            ///     The c s 2_063.
            /// </summary>
            CS2_063,

            /// <summary>
            ///     The e x 1_145.
            /// </summary>
            EX1_145,

            /// <summary>
            ///     The na x 1 h_03.
            /// </summary>
            NAX1h_03,

            /// <summary>
            ///     The e x 1_110.
            /// </summary>
            EX1_110,

            /// <summary>
            ///     The e x 1_408.
            /// </summary>
            EX1_408,

            /// <summary>
            ///     The e x 1_544.
            /// </summary>
            EX1_544,

            /// <summary>
            ///     The t u 4 c_006.
            /// </summary>
            TU4c_006,

            /// <summary>
            ///     The nax m_001.
            /// </summary>
            NAXM_001,

            /// <summary>
            ///     The c s 2_151.
            /// </summary>
            CS2_151,

            /// <summary>
            ///     The c s 2_073 e.
            /// </summary>
            CS2_073e,

            /// <summary>
            ///     The xx x_006.
            /// </summary>
            XXX_006,

            /// <summary>
            ///     The c s 2_088.
            /// </summary>
            CS2_088,

            /// <summary>
            ///     The e x 1_057.
            /// </summary>
            EX1_057,

            /// <summary>
            ///     The f p 1_020.
            /// </summary>
            FP1_020,

            /// <summary>
            ///     The c s 2_169.
            /// </summary>
            CS2_169,

            /// <summary>
            ///     The e x 1_573 t.
            /// </summary>
            EX1_573t,

            /// <summary>
            ///     The e x 1_323 h.
            /// </summary>
            EX1_323h,

            /// <summary>
            ///     The e x 1_tk 9.
            /// </summary>
            EX1_tk9,

            /// <summary>
            ///     The ne w 1_018 e.
            /// </summary>
            NEW1_018e,

            /// <summary>
            ///     The c s 2_037.
            /// </summary>
            CS2_037,

            /// <summary>
            ///     The c s 2_007.
            /// </summary>
            CS2_007,

            /// <summary>
            ///     The e x 1_059 e 2.
            /// </summary>
            EX1_059e2,

            /// <summary>
            ///     The c s 2_227.
            /// </summary>
            CS2_227,

            /// <summary>
            ///     The na x 7_03 h.
            /// </summary>
            NAX7_03H,

            /// <summary>
            ///     The na x 9_01 h.
            /// </summary>
            NAX9_01H,

            /// <summary>
            ///     The e x 1_570 e.
            /// </summary>
            EX1_570e,

            /// <summary>
            ///     The ne w 1_003.
            /// </summary>
            NEW1_003,

            /// <summary>
            ///     The gam e_006.
            /// </summary>
            GAME_006,

            /// <summary>
            ///     The e x 1_320.
            /// </summary>
            EX1_320,

            /// <summary>
            ///     The e x 1_097.
            /// </summary>
            EX1_097,

            /// <summary>
            ///     The tt_004.
            /// </summary>
            tt_004,

            /// <summary>
            ///     The e x 1_360 e.
            /// </summary>
            EX1_360e,

            /// <summary>
            ///     The e x 1_096.
            /// </summary>
            EX1_096,

            /// <summary>
            ///     The d s 1_175 o.
            /// </summary>
            DS1_175o,

            /// <summary>
            ///     The e x 1_596 e.
            /// </summary>
            EX1_596e,

            /// <summary>
            ///     The xx x_014.
            /// </summary>
            XXX_014,

            /// <summary>
            ///     The e x 1_158 e.
            /// </summary>
            EX1_158e,

            /// <summary>
            ///     The na x 14_01.
            /// </summary>
            NAX14_01,

            /// <summary>
            ///     The cre d_01.
            /// </summary>
            CRED_01,

            /// <summary>
            ///     The cre d_08.
            /// </summary>
            CRED_08,

            /// <summary>
            ///     The e x 1_126.
            /// </summary>
            EX1_126,

            /// <summary>
            ///     The e x 1_577.
            /// </summary>
            EX1_577,

            /// <summary>
            ///     The e x 1_319.
            /// </summary>
            EX1_319,

            /// <summary>
            ///     The e x 1_611.
            /// </summary>
            EX1_611,

            /// <summary>
            ///     The c s 2_146.
            /// </summary>
            CS2_146,

            /// <summary>
            ///     The e x 1_154 b.
            /// </summary>
            EX1_154b,

            /// <summary>
            ///     The skele 11.
            /// </summary>
            skele11,

            /// <summary>
            ///     The e x 1_165 t 2.
            /// </summary>
            EX1_165t2,

            /// <summary>
            ///     The c s 2_172.
            /// </summary>
            CS2_172,

            /// <summary>
            ///     The c s 2_114.
            /// </summary>
            CS2_114,

            /// <summary>
            ///     The c s 1_069.
            /// </summary>
            CS1_069,

            /// <summary>
            ///     The xx x_003.
            /// </summary>
            XXX_003,

            /// <summary>
            ///     The xx x_042.
            /// </summary>
            XXX_042,

            /// <summary>
            ///     The na x 8_02.
            /// </summary>
            NAX8_02,

            /// <summary>
            ///     The e x 1_173.
            /// </summary>
            EX1_173,

            /// <summary>
            ///     The c s 1_042.
            /// </summary>
            CS1_042,

            /// <summary>
            ///     The na x 8_03.
            /// </summary>
            NAX8_03,

            /// <summary>
            ///     The e x 1_506 a.
            /// </summary>
            EX1_506a,

            /// <summary>
            ///     The e x 1_298.
            /// </summary>
            EX1_298,

            /// <summary>
            ///     The c s 2_104.
            /// </summary>
            CS2_104,

            /// <summary>
            ///     The f p 1_001.
            /// </summary>
            FP1_001,

            /// <summary>
            ///     The her o_02.
            /// </summary>
            HERO_02,

            /// <summary>
            ///     The e x 1_316 e.
            /// </summary>
            EX1_316e,

            /// <summary>
            ///     The na x 7_01.
            /// </summary>
            NAX7_01,

            /// <summary>
            ///     The e x 1_044 e.
            /// </summary>
            EX1_044e,

            /// <summary>
            ///     The c s 2_051.
            /// </summary>
            CS2_051,

            /// <summary>
            ///     The ne w 1_016.
            /// </summary>
            NEW1_016,

            /// <summary>
            ///     The e x 1_304 e.
            /// </summary>
            EX1_304e,

            /// <summary>
            ///     The e x 1_033.
            /// </summary>
            EX1_033,

            /// <summary>
            ///     The na x 8_04.
            /// </summary>
            NAX8_04,

            /// <summary>
            ///     The e x 1_028.
            /// </summary>
            EX1_028,

            /// <summary>
            ///     The xx x_011.
            /// </summary>
            XXX_011,

            /// <summary>
            ///     The e x 1_621.
            /// </summary>
            EX1_621,

            /// <summary>
            ///     The e x 1_554.
            /// </summary>
            EX1_554,

            /// <summary>
            ///     The e x 1_091.
            /// </summary>
            EX1_091,

            /// <summary>
            ///     The f p 1_017.
            /// </summary>
            FP1_017,

            /// <summary>
            ///     The e x 1_409.
            /// </summary>
            EX1_409,

            /// <summary>
            ///     The e x 1_363 e.
            /// </summary>
            EX1_363e,

            /// <summary>
            ///     The e x 1_410.
            /// </summary>
            EX1_410,

            /// <summary>
            ///     The t u 4 e_005.
            /// </summary>
            TU4e_005,

            /// <summary>
            ///     The c s 2_039.
            /// </summary>
            CS2_039,

            /// <summary>
            ///     The na x 12_04.
            /// </summary>
            NAX12_04,

            /// <summary>
            ///     The e x 1_557.
            /// </summary>
            EX1_557,

            /// <summary>
            ///     The c s 2_105 e.
            /// </summary>
            CS2_105e,

            /// <summary>
            ///     The e x 1_128 e.
            /// </summary>
            EX1_128e,

            /// <summary>
            ///     The xx x_021.
            /// </summary>
            XXX_021,

            /// <summary>
            ///     The d s 1_070.
            /// </summary>
            DS1_070,

            /// <summary>
            ///     The c s 2_033.
            /// </summary>
            CS2_033,

            /// <summary>
            ///     The e x 1_536.
            /// </summary>
            EX1_536,

            /// <summary>
            ///     The t u 4 a_003.
            /// </summary>
            TU4a_003,

            /// <summary>
            ///     The e x 1_559.
            /// </summary>
            EX1_559,

            /// <summary>
            ///     The xx x_023.
            /// </summary>
            XXX_023,

            /// <summary>
            ///     The ne w 1_033 o.
            /// </summary>
            NEW1_033o,

            /// <summary>
            ///     The na x 15_04 h.
            /// </summary>
            NAX15_04H,

            /// <summary>
            ///     The c s 2_004 e.
            /// </summary>
            CS2_004e,

            /// <summary>
            ///     The c s 2_052.
            /// </summary>
            CS2_052,

            /// <summary>
            ///     The e x 1_539.
            /// </summary>
            EX1_539,

            /// <summary>
            ///     The e x 1_575.
            /// </summary>
            EX1_575,

            /// <summary>
            ///     The c s 2_083 b.
            /// </summary>
            CS2_083b,

            /// <summary>
            ///     The c s 2_061.
            /// </summary>
            CS2_061,

            /// <summary>
            ///     The ne w 1_021.
            /// </summary>
            NEW1_021,

            /// <summary>
            ///     The d s 1_055.
            /// </summary>
            DS1_055,

            /// <summary>
            ///     The e x 1_625.
            /// </summary>
            EX1_625,

            /// <summary>
            ///     The e x 1_382 e.
            /// </summary>
            EX1_382e,

            /// <summary>
            ///     The c s 2_092 e.
            /// </summary>
            CS2_092e,

            /// <summary>
            ///     The c s 2_026.
            /// </summary>
            CS2_026,

            /// <summary>
            ///     The na x 14_04.
            /// </summary>
            NAX14_04,

            /// <summary>
            ///     The ne w 1_012 o.
            /// </summary>
            NEW1_012o,

            /// <summary>
            ///     The e x 1_619 e.
            /// </summary>
            EX1_619e,

            /// <summary>
            ///     The e x 1_294.
            /// </summary>
            EX1_294,

            /// <summary>
            ///     The e x 1_287.
            /// </summary>
            EX1_287,

            /// <summary>
            ///     The e x 1_509 e.
            /// </summary>
            EX1_509e,

            /// <summary>
            ///     The e x 1_625 t 2.
            /// </summary>
            EX1_625t2,

            /// <summary>
            ///     The c s 2_118.
            /// </summary>
            CS2_118,

            /// <summary>
            ///     The c s 2_124.
            /// </summary>
            CS2_124,

            /// <summary>
            ///     The mekka 3.
            /// </summary>
            Mekka3,

            /// <summary>
            ///     The na x 13_02.
            /// </summary>
            NAX13_02,

            /// <summary>
            ///     The e x 1_112.
            /// </summary>
            EX1_112,

            /// <summary>
            ///     The f p 1_011.
            /// </summary>
            FP1_011,

            /// <summary>
            ///     The c s 2_009 e.
            /// </summary>
            CS2_009e,

            /// <summary>
            ///     The her o_04.
            /// </summary>
            HERO_04,

            /// <summary>
            ///     The e x 1_607.
            /// </summary>
            EX1_607,

            /// <summary>
            ///     The drea m_03.
            /// </summary>
            DREAM_03,

            /// <summary>
            ///     The na x 11_04 e.
            /// </summary>
            NAX11_04e,

            /// <summary>
            ///     The e x 1_103 e.
            /// </summary>
            EX1_103e,

            /// <summary>
            ///     The xx x_046.
            /// </summary>
            XXX_046,

            /// <summary>
            ///     The f p 1_003.
            /// </summary>
            FP1_003,

            /// <summary>
            ///     The c s 2_105.
            /// </summary>
            CS2_105,

            /// <summary>
            ///     The f p 1_002.
            /// </summary>
            FP1_002,

            /// <summary>
            ///     The t u 4 c_002.
            /// </summary>
            TU4c_002,

            /// <summary>
            ///     The cre d_14.
            /// </summary>
            CRED_14,

            /// <summary>
            ///     The e x 1_567.
            /// </summary>
            EX1_567,

            /// <summary>
            ///     The t u 4 c_004.
            /// </summary>
            TU4c_004,

            /// <summary>
            ///     The na x 10_03 h.
            /// </summary>
            NAX10_03H,

            /// <summary>
            ///     The f p 1_008.
            /// </summary>
            FP1_008,

            /// <summary>
            ///     The d s 1_184.
            /// </summary>
            DS1_184,

            /// <summary>
            ///     The c s 2_029.
            /// </summary>
            CS2_029,

            /// <summary>
            ///     The gam e_005.
            /// </summary>
            GAME_005,

            /// <summary>
            ///     The c s 2_187.
            /// </summary>
            CS2_187,

            /// <summary>
            ///     The e x 1_020.
            /// </summary>
            EX1_020,

            /// <summary>
            ///     The na x 15_01 he.
            /// </summary>
            NAX15_01He,

            /// <summary>
            ///     The e x 1_011.
            /// </summary>
            EX1_011,

            /// <summary>
            ///     The c s 2_057.
            /// </summary>
            CS2_057,

            /// <summary>
            ///     The e x 1_274.
            /// </summary>
            EX1_274,

            /// <summary>
            ///     The e x 1_306.
            /// </summary>
            EX1_306,

            /// <summary>
            ///     The ne w 1_038 o.
            /// </summary>
            NEW1_038o,

            /// <summary>
            ///     The e x 1_170.
            /// </summary>
            EX1_170,

            /// <summary>
            ///     The e x 1_617.
            /// </summary>
            EX1_617,

            /// <summary>
            ///     The c s 1_113 e.
            /// </summary>
            CS1_113e,

            /// <summary>
            ///     The c s 2_101.
            /// </summary>
            CS2_101,

            /// <summary>
            ///     The f p 1_015.
            /// </summary>
            FP1_015,

            /// <summary>
            ///     The na x 13_03.
            /// </summary>
            NAX13_03,

            /// <summary>
            ///     The c s 2_005.
            /// </summary>
            CS2_005,

            /// <summary>
            ///     The e x 1_537.
            /// </summary>
            EX1_537,

            /// <summary>
            ///     The e x 1_384.
            /// </summary>
            EX1_384,

            /// <summary>
            ///     The t u 4 a_002.
            /// </summary>
            TU4a_002,

            /// <summary>
            ///     The na x 9_04.
            /// </summary>
            NAX9_04,

            /// <summary>
            ///     The e x 1_362.
            /// </summary>
            EX1_362,

            /// <summary>
            ///     The na x 12_02.
            /// </summary>
            NAX12_02,

            /// <summary>
            ///     The f p 1_028 e.
            /// </summary>
            FP1_028e,

            /// <summary>
            ///     The t u 4 c_005.
            /// </summary>
            TU4c_005,

            /// <summary>
            ///     The e x 1_301.
            /// </summary>
            EX1_301,

            /// <summary>
            ///     The c s 2_235.
            /// </summary>
            CS2_235,

            /// <summary>
            ///     The na x 4_05.
            /// </summary>
            NAX4_05,

            /// <summary>
            ///     The e x 1_029.
            /// </summary>
            EX1_029,

            /// <summary>
            ///     The c s 2_042.
            /// </summary>
            CS2_042,

            /// <summary>
            ///     The e x 1_155 a.
            /// </summary>
            EX1_155a,

            /// <summary>
            ///     The c s 2_102.
            /// </summary>
            CS2_102,

            /// <summary>
            ///     The e x 1_609.
            /// </summary>
            EX1_609,

            /// <summary>
            ///     The ne w 1_027.
            /// </summary>
            NEW1_027,

            /// <summary>
            ///     The c s 2_236 e.
            /// </summary>
            CS2_236e,

            /// <summary>
            ///     The c s 2_083 e.
            /// </summary>
            CS2_083e,

            /// <summary>
            ///     The na x 6_03 te.
            /// </summary>
            NAX6_03te,

            /// <summary>
            ///     The e x 1_165 a.
            /// </summary>
            EX1_165a,

            /// <summary>
            ///     The e x 1_570.
            /// </summary>
            EX1_570,

            /// <summary>
            ///     The e x 1_131.
            /// </summary>
            EX1_131,

            /// <summary>
            ///     The e x 1_556.
            /// </summary>
            EX1_556,

            /// <summary>
            ///     The e x 1_543.
            /// </summary>
            EX1_543,

            /// <summary>
            ///     The xx x_096.
            /// </summary>
            XXX_096,

            /// <summary>
            ///     The t u 4 c_008 e.
            /// </summary>
            TU4c_008e,

            /// <summary>
            ///     The e x 1_379 e.
            /// </summary>
            EX1_379e,

            /// <summary>
            ///     The ne w 1_009.
            /// </summary>
            NEW1_009,

            /// <summary>
            ///     The e x 1_100.
            /// </summary>
            EX1_100,

            /// <summary>
            ///     The e x 1_274 e.
            /// </summary>
            EX1_274e,

            /// <summary>
            ///     The cre d_02.
            /// </summary>
            CRED_02,

            /// <summary>
            ///     The e x 1_573 a.
            /// </summary>
            EX1_573a,

            /// <summary>
            ///     The c s 2_084.
            /// </summary>
            CS2_084,

            /// <summary>
            ///     The e x 1_582.
            /// </summary>
            EX1_582,

            /// <summary>
            ///     The e x 1_043.
            /// </summary>
            EX1_043,

            /// <summary>
            ///     The e x 1_050.
            /// </summary>
            EX1_050,

            /// <summary>
            ///     The t u 4 b_001.
            /// </summary>
            TU4b_001,

            /// <summary>
            ///     The f p 1_005.
            /// </summary>
            FP1_005,

            /// <summary>
            ///     The e x 1_620.
            /// </summary>
            EX1_620,

            /// <summary>
            ///     The na x 15_01.
            /// </summary>
            NAX15_01,

            /// <summary>
            ///     The na x 6_03.
            /// </summary>
            NAX6_03,

            /// <summary>
            ///     The e x 1_303.
            /// </summary>
            EX1_303,

            /// <summary>
            ///     The her o_09.
            /// </summary>
            HERO_09,

            /// <summary>
            ///     The e x 1_067.
            /// </summary>
            EX1_067,

            /// <summary>
            ///     The xx x_028.
            /// </summary>
            XXX_028,

            /// <summary>
            ///     The e x 1_277.
            /// </summary>
            EX1_277,

            /// <summary>
            ///     The mekka 2.
            /// </summary>
            Mekka2,

            /// <summary>
            ///     The na x 14_01 h.
            /// </summary>
            NAX14_01H,

            /// <summary>
            ///     The na x 15_04.
            /// </summary>
            NAX15_04,

            /// <summary>
            ///     The f p 1_024.
            /// </summary>
            FP1_024,

            /// <summary>
            ///     The f p 1_030.
            /// </summary>
            FP1_030,

            /// <summary>
            ///     The c s 2_221 e.
            /// </summary>
            CS2_221e,

            /// <summary>
            ///     The e x 1_178.
            /// </summary>
            EX1_178,

            /// <summary>
            ///     The c s 2_222.
            /// </summary>
            CS2_222,

            /// <summary>
            ///     The e x 1_409 e.
            /// </summary>
            EX1_409e,

            /// <summary>
            ///     The tt_004 o.
            /// </summary>
            tt_004o,

            /// <summary>
            ///     The e x 1_155 ae.
            /// </summary>
            EX1_155ae,

            /// <summary>
            ///     The na x 11_01 h.
            /// </summary>
            NAX11_01H,

            /// <summary>
            ///     The e x 1_160 a.
            /// </summary>
            EX1_160a,

            /// <summary>
            ///     The na x 15_02.
            /// </summary>
            NAX15_02,

            /// <summary>
            ///     The na x 15_05.
            /// </summary>
            NAX15_05,

            /// <summary>
            ///     The ne w 1_025 e.
            /// </summary>
            NEW1_025e,

            /// <summary>
            ///     The c s 2_012.
            /// </summary>
            CS2_012,

            /// <summary>
            ///     The xx x_099.
            /// </summary>
            XXX_099,

            /// <summary>
            ///     The e x 1_246.
            /// </summary>
            EX1_246,

            /// <summary>
            ///     The e x 1_572.
            /// </summary>
            EX1_572,

            /// <summary>
            ///     The e x 1_089.
            /// </summary>
            EX1_089,

            /// <summary>
            ///     The c s 2_059.
            /// </summary>
            CS2_059,

            /// <summary>
            ///     The e x 1_279.
            /// </summary>
            EX1_279,

            /// <summary>
            ///     The na x 12_02 e.
            /// </summary>
            NAX12_02e,

            /// <summary>
            ///     The c s 2_168.
            /// </summary>
            CS2_168,

            /// <summary>
            ///     The tt_010.
            /// </summary>
            tt_010,

            /// <summary>
            ///     The ne w 1_023.
            /// </summary>
            NEW1_023,

            /// <summary>
            ///     The c s 2_075.
            /// </summary>
            CS2_075,

            /// <summary>
            ///     The e x 1_316.
            /// </summary>
            EX1_316,

            /// <summary>
            ///     The c s 2_025.
            /// </summary>
            CS2_025,

            /// <summary>
            ///     The c s 2_234.
            /// </summary>
            CS2_234,

            /// <summary>
            ///     The xx x_043.
            /// </summary>
            XXX_043,

            /// <summary>
            ///     The gam e_001.
            /// </summary>
            GAME_001,

            /// <summary>
            ///     The na x 5_02.
            /// </summary>
            NAX5_02,

            /// <summary>
            ///     The e x 1_130.
            /// </summary>
            EX1_130,

            /// <summary>
            ///     The e x 1_584 e.
            /// </summary>
            EX1_584e,

            /// <summary>
            ///     The c s 2_064.
            /// </summary>
            CS2_064,

            /// <summary>
            ///     The e x 1_161.
            /// </summary>
            EX1_161,

            /// <summary>
            ///     The c s 2_049.
            /// </summary>
            CS2_049,

            /// <summary>
            ///     The na x 13_01.
            /// </summary>
            NAX13_01,

            /// <summary>
            ///     The e x 1_154.
            /// </summary>
            EX1_154,

            /// <summary>
            ///     The e x 1_080.
            /// </summary>
            EX1_080,

            /// <summary>
            ///     The ne w 1_022.
            /// </summary>
            NEW1_022,

            /// <summary>
            ///     The na x 2_01 h.
            /// </summary>
            NAX2_01H,

            /// <summary>
            ///     The e x 1_160 be.
            /// </summary>
            EX1_160be,

            /// <summary>
            ///     The na x 12_03.
            /// </summary>
            NAX12_03,

            /// <summary>
            ///     The e x 1_251.
            /// </summary>
            EX1_251,

            /// <summary>
            ///     The f p 1_025.
            /// </summary>
            FP1_025,

            /// <summary>
            ///     The e x 1_371.
            /// </summary>
            EX1_371,

            /// <summary>
            ///     The c s 2_mirror.
            /// </summary>
            CS2_mirror,

            /// <summary>
            ///     The na x 4_01 h.
            /// </summary>
            NAX4_01H,

            /// <summary>
            ///     The e x 1_594.
            /// </summary>
            EX1_594,

            /// <summary>
            ///     The na x 14_02.
            /// </summary>
            NAX14_02,

            /// <summary>
            ///     The t u 4 c_006 e.
            /// </summary>
            TU4c_006e,

            /// <summary>
            ///     The e x 1_560.
            /// </summary>
            EX1_560,

            /// <summary>
            ///     The c s 2_236.
            /// </summary>
            CS2_236,

            /// <summary>
            ///     The t u 4 f_006.
            /// </summary>
            TU4f_006,

            /// <summary>
            ///     The e x 1_402.
            /// </summary>
            EX1_402,

            /// <summary>
            ///     The na x 3_01.
            /// </summary>
            NAX3_01,

            /// <summary>
            ///     The e x 1_506.
            /// </summary>
            EX1_506,

            /// <summary>
            ///     The ne w 1_027 e.
            /// </summary>
            NEW1_027e,

            /// <summary>
            ///     The d s 1_070 o.
            /// </summary>
            DS1_070o,

            /// <summary>
            ///     The xx x_045.
            /// </summary>
            XXX_045,

            /// <summary>
            ///     The xx x_029.
            /// </summary>
            XXX_029,

            /// <summary>
            ///     The d s 1_178.
            /// </summary>
            DS1_178,

            /// <summary>
            ///     The xx x_098.
            /// </summary>
            XXX_098,

            /// <summary>
            ///     The e x 1_315.
            /// </summary>
            EX1_315,

            /// <summary>
            ///     The c s 2_094.
            /// </summary>
            CS2_094,

            /// <summary>
            ///     The na x 13_01 h.
            /// </summary>
            NAX13_01H,

            /// <summary>
            ///     The t u 4 e_002 t.
            /// </summary>
            TU4e_002t,

            /// <summary>
            ///     The e x 1_046 e.
            /// </summary>
            EX1_046e,

            /// <summary>
            ///     The ne w 1_040 t.
            /// </summary>
            NEW1_040t,

            /// <summary>
            ///     The gam e_005 e.
            /// </summary>
            GAME_005e,

            /// <summary>
            ///     The c s 2_131.
            /// </summary>
            CS2_131,

            /// <summary>
            ///     The xx x_008.
            /// </summary>
            XXX_008,

            /// <summary>
            ///     The e x 1_531 e.
            /// </summary>
            EX1_531e,

            /// <summary>
            ///     The c s 2_226 e.
            /// </summary>
            CS2_226e,

            /// <summary>
            ///     The xx x_022 e.
            /// </summary>
            XXX_022e,

            /// <summary>
            ///     The d s 1_178 e.
            /// </summary>
            DS1_178e,

            /// <summary>
            ///     The c s 2_226 o.
            /// </summary>
            CS2_226o,

            /// <summary>
            ///     The na x 9_04 h.
            /// </summary>
            NAX9_04H,

            /// <summary>
            ///     The mekka 4 e.
            /// </summary>
            Mekka4e,

            /// <summary>
            ///     The e x 1_082.
            /// </summary>
            EX1_082,

            /// <summary>
            ///     The c s 2_093.
            /// </summary>
            CS2_093,

            /// <summary>
            ///     The e x 1_411 e.
            /// </summary>
            EX1_411e,

            /// <summary>
            ///     The na x 8_03 t.
            /// </summary>
            NAX8_03t,

            /// <summary>
            ///     The e x 1_145 o.
            /// </summary>
            EX1_145o,

            /// <summary>
            ///     The na x 7_04.
            /// </summary>
            NAX7_04,

            /// <summary>
            ///     The c s 2_boar.
            /// </summary>
            CS2_boar,

            /// <summary>
            ///     The ne w 1_019.
            /// </summary>
            NEW1_019,

            /// <summary>
            ///     The e x 1_289.
            /// </summary>
            EX1_289,

            /// <summary>
            ///     The e x 1_025 t.
            /// </summary>
            EX1_025t,

            /// <summary>
            ///     The e x 1_398 t.
            /// </summary>
            EX1_398t,

            /// <summary>
            ///     The na x 12_03 h.
            /// </summary>
            NAX12_03H,

            /// <summary>
            ///     The e x 1_055 o.
            /// </summary>
            EX1_055o,

            /// <summary>
            ///     The c s 2_091.
            /// </summary>
            CS2_091,

            /// <summary>
            ///     The e x 1_241.
            /// </summary>
            EX1_241,

            /// <summary>
            ///     The e x 1_085.
            /// </summary>
            EX1_085,

            /// <summary>
            ///     The c s 2_200.
            /// </summary>
            CS2_200,

            /// <summary>
            ///     The c s 2_034.
            /// </summary>
            CS2_034,

            /// <summary>
            ///     The e x 1_583.
            /// </summary>
            EX1_583,

            /// <summary>
            ///     The e x 1_584.
            /// </summary>
            EX1_584,

            /// <summary>
            ///     The e x 1_155.
            /// </summary>
            EX1_155,

            /// <summary>
            ///     The e x 1_622.
            /// </summary>
            EX1_622,

            /// <summary>
            ///     The c s 2_203.
            /// </summary>
            CS2_203,

            /// <summary>
            ///     The e x 1_124.
            /// </summary>
            EX1_124,

            /// <summary>
            ///     The e x 1_379.
            /// </summary>
            EX1_379,

            /// <summary>
            ///     The na x 7_02.
            /// </summary>
            NAX7_02,

            /// <summary>
            ///     The c s 2_053 e.
            /// </summary>
            CS2_053e,

            /// <summary>
            ///     The e x 1_032.
            /// </summary>
            EX1_032,

            /// <summary>
            ///     The na x 9_01.
            /// </summary>
            NAX9_01,

            /// <summary>
            ///     The t u 4 e_003.
            /// </summary>
            TU4e_003,

            /// <summary>
            ///     The c s 2_146 o.
            /// </summary>
            CS2_146o,

            /// <summary>
            ///     The na x 8_01 h.
            /// </summary>
            NAX8_01H,

            /// <summary>
            ///     The xx x_041.
            /// </summary>
            XXX_041,

            /// <summary>
            ///     The nax m_002.
            /// </summary>
            NAXM_002,

            /// <summary>
            ///     The e x 1_391.
            /// </summary>
            EX1_391,

            /// <summary>
            ///     The e x 1_366.
            /// </summary>
            EX1_366,

            /// <summary>
            ///     The e x 1_059 e.
            /// </summary>
            EX1_059e,

            /// <summary>
            ///     The xx x_012.
            /// </summary>
            XXX_012,

            /// <summary>
            ///     The e x 1_565 o.
            /// </summary>
            EX1_565o,

            /// <summary>
            ///     The e x 1_001 e.
            /// </summary>
            EX1_001e,

            /// <summary>
            ///     The t u 4 f_003.
            /// </summary>
            TU4f_003,

            /// <summary>
            ///     The e x 1_400.
            /// </summary>
            EX1_400,

            /// <summary>
            ///     The e x 1_614.
            /// </summary>
            EX1_614,

            /// <summary>
            ///     The e x 1_561.
            /// </summary>
            EX1_561,

            /// <summary>
            ///     The e x 1_332.
            /// </summary>
            EX1_332,

            /// <summary>
            ///     The her o_05.
            /// </summary>
            HERO_05,

            /// <summary>
            ///     The c s 2_065.
            /// </summary>
            CS2_065,

            /// <summary>
            ///     The ds 1_whelptoken.
            /// </summary>
            ds1_whelptoken,

            /// <summary>
            ///     The e x 1_536 e.
            /// </summary>
            EX1_536e,

            /// <summary>
            ///     The c s 2_032.
            /// </summary>
            CS2_032,

            /// <summary>
            ///     The c s 2_120.
            /// </summary>
            CS2_120,

            /// <summary>
            ///     The e x 1_155 be.
            /// </summary>
            EX1_155be,

            /// <summary>
            ///     The e x 1_247.
            /// </summary>
            EX1_247,

            /// <summary>
            ///     The e x 1_154 a.
            /// </summary>
            EX1_154a,

            /// <summary>
            ///     The e x 1_554 t.
            /// </summary>
            EX1_554t,

            /// <summary>
            ///     The c s 2_103 e 2.
            /// </summary>
            CS2_103e2,

            /// <summary>
            ///     The t u 4 d_003.
            /// </summary>
            TU4d_003,

            /// <summary>
            ///     The ne w 1_026 t.
            /// </summary>
            NEW1_026t,

            /// <summary>
            ///     The e x 1_623.
            /// </summary>
            EX1_623,

            /// <summary>
            ///     The e x 1_383 t.
            /// </summary>
            EX1_383t,

            /// <summary>
            ///     The na x 7_03.
            /// </summary>
            NAX7_03,

            /// <summary>
            ///     The e x 1_597.
            /// </summary>
            EX1_597,

            /// <summary>
            ///     The t u 4 f_006 o.
            /// </summary>
            TU4f_006o,

            /// <summary>
            ///     The e x 1_130 a.
            /// </summary>
            EX1_130a,

            /// <summary>
            ///     The c s 2_011.
            /// </summary>
            CS2_011,

            /// <summary>
            ///     The e x 1_169.
            /// </summary>
            EX1_169,

            /// <summary>
            ///     The e x 1_tk 33.
            /// </summary>
            EX1_tk33,

            /// <summary>
            ///     The na x 11_03.
            /// </summary>
            NAX11_03,

            /// <summary>
            ///     The na x 4_01.
            /// </summary>
            NAX4_01,

            /// <summary>
            ///     The na x 10_01.
            /// </summary>
            NAX10_01,

            /// <summary>
            ///     The e x 1_250.
            /// </summary>
            EX1_250,

            /// <summary>
            ///     The e x 1_564.
            /// </summary>
            EX1_564,

            /// <summary>
            ///     The na x 5_03.
            /// </summary>
            NAX5_03,

            /// <summary>
            ///     The e x 1_043 e.
            /// </summary>
            EX1_043e,

            /// <summary>
            ///     The e x 1_349.
            /// </summary>
            EX1_349,

            /// <summary>
            ///     The xx x_097.
            /// </summary>
            XXX_097,

            /// <summary>
            ///     The e x 1_102.
            /// </summary>
            EX1_102,

            /// <summary>
            ///     The e x 1_058.
            /// </summary>
            EX1_058,

            /// <summary>
            ///     The e x 1_243.
            /// </summary>
            EX1_243,

            /// <summary>
            ///     The pr o_001 c.
            /// </summary>
            PRO_001c,

            /// <summary>
            ///     The e x 1_116 t.
            /// </summary>
            EX1_116t,

            /// <summary>
            ///     The na x 15_01 e.
            /// </summary>
            NAX15_01e,

            /// <summary>
            ///     The f p 1_029.
            /// </summary>
            FP1_029,

            /// <summary>
            ///     The c s 2_089.
            /// </summary>
            CS2_089,

            /// <summary>
            ///     The t u 4 c_001.
            /// </summary>
            TU4c_001,

            /// <summary>
            ///     The e x 1_248.
            /// </summary>
            EX1_248,

            /// <summary>
            ///     The ne w 1_037 e.
            /// </summary>
            NEW1_037e,

            /// <summary>
            ///     The c s 2_122.
            /// </summary>
            CS2_122,

            /// <summary>
            ///     The e x 1_393.
            /// </summary>
            EX1_393,

            /// <summary>
            ///     The c s 2_232.
            /// </summary>
            CS2_232,

            /// <summary>
            ///     The e x 1_165 b.
            /// </summary>
            EX1_165b,

            /// <summary>
            ///     The ne w 1_030.
            /// </summary>
            NEW1_030,

            /// <summary>
            ///     The e x 1_161 o.
            /// </summary>
            EX1_161o,

            /// <summary>
            ///     The e x 1_093 e.
            /// </summary>
            EX1_093e,

            /// <summary>
            ///     The c s 2_150.
            /// </summary>
            CS2_150,

            /// <summary>
            ///     The c s 2_152.
            /// </summary>
            CS2_152,

            /// <summary>
            ///     The na x 9_03 h.
            /// </summary>
            NAX9_03H,

            /// <summary>
            ///     The e x 1_160 t.
            /// </summary>
            EX1_160t,

            /// <summary>
            ///     The c s 2_127.
            /// </summary>
            CS2_127,

            /// <summary>
            ///     The cre d_03.
            /// </summary>
            CRED_03,

            /// <summary>
            ///     The d s 1_188.
            /// </summary>
            DS1_188,

            /// <summary>
            ///     The xx x_001.
            /// </summary>
            XXX_001,
        }

        /// <summary>
        ///     The card name.
        /// </summary>
        public enum cardName
        {
            /// <summary>
            ///     The unknown.
            /// </summary>
            unknown,

            /// <summary>
            ///     The hogger.
            /// </summary>
            hogger,

            /// <summary>
            ///     The heigantheunclean.
            /// </summary>
            heigantheunclean,

            /// <summary>
            ///     The necroticaura.
            /// </summary>
            necroticaura,

            /// <summary>
            ///     The starfall.
            /// </summary>
            starfall,

            /// <summary>
            ///     The barrel.
            /// </summary>
            barrel,

            /// <summary>
            ///     The damagereflector.
            /// </summary>
            damagereflector,

            /// <summary>
            ///     The edwinvancleef.
            /// </summary>
            edwinvancleef,

            /// <summary>
            ///     The gothiktheharvester.
            /// </summary>
            gothiktheharvester,

            /// <summary>
            ///     The perditionsblade.
            /// </summary>
            perditionsblade,

            /// <summary>
            ///     The bloodsailraider.
            /// </summary>
            bloodsailraider,

            /// <summary>
            ///     The guardianoficecrown.
            /// </summary>
            guardianoficecrown,

            /// <summary>
            ///     The bloodmagethalnos.
            /// </summary>
            bloodmagethalnos,

            /// <summary>
            ///     The rooted.
            /// </summary>
            rooted,

            /// <summary>
            ///     The wisp.
            /// </summary>
            wisp,

            /// <summary>
            ///     The rachelledavis.
            /// </summary>
            rachelledavis,

            /// <summary>
            ///     The senjinshieldmasta.
            /// </summary>
            senjinshieldmasta,

            /// <summary>
            ///     The totemicmight.
            /// </summary>
            totemicmight,

            /// <summary>
            ///     The uproot.
            /// </summary>
            uproot,

            /// <summary>
            ///     The opponentdisconnect.
            /// </summary>
            opponentdisconnect,

            /// <summary>
            ///     The unrelentingrider.
            /// </summary>
            unrelentingrider,

            /// <summary>
            ///     The shandoslesson.
            /// </summary>
            shandoslesson,

            /// <summary>
            ///     The hemetnesingwary.
            /// </summary>
            hemetnesingwary,

            /// <summary>
            ///     The decimate.
            /// </summary>
            decimate,

            /// <summary>
            ///     The shadowofnothing.
            /// </summary>
            shadowofnothing,

            /// <summary>
            ///     The nerubian.
            /// </summary>
            nerubian,

            /// <summary>
            ///     The dragonlingmechanic.
            /// </summary>
            dragonlingmechanic,

            /// <summary>
            ///     The mogushanwarden.
            /// </summary>
            mogushanwarden,

            /// <summary>
            ///     The thanekorthazz.
            /// </summary>
            thanekorthazz,

            /// <summary>
            ///     The hungrycrab.
            /// </summary>
            hungrycrab,

            /// <summary>
            ///     The ancientteachings.
            /// </summary>
            ancientteachings,

            /// <summary>
            ///     The misdirection.
            /// </summary>
            misdirection,

            /// <summary>
            ///     The patientassassin.
            /// </summary>
            patientassassin,

            /// <summary>
            ///     The mutatinginjection.
            /// </summary>
            mutatinginjection,

            /// <summary>
            ///     The violetteacher.
            /// </summary>
            violetteacher,

            /// <summary>
            ///     The arathiweaponsmith.
            /// </summary>
            arathiweaponsmith,

            /// <summary>
            ///     The raisedead.
            /// </summary>
            raisedead,

            /// <summary>
            ///     The acolyteofpain.
            /// </summary>
            acolyteofpain,

            /// <summary>
            ///     The holynova.
            /// </summary>
            holynova,

            /// <summary>
            ///     The robpardo.
            /// </summary>
            robpardo,

            /// <summary>
            ///     The commandingshout.
            /// </summary>
            commandingshout,

            /// <summary>
            ///     The necroticpoison.
            /// </summary>
            necroticpoison,

            /// <summary>
            ///     The unboundelemental.
            /// </summary>
            unboundelemental,

            /// <summary>
            ///     The garroshhellscream.
            /// </summary>
            garroshhellscream,

            /// <summary>
            ///     The enchant.
            /// </summary>
            enchant,

            /// <summary>
            ///     The loatheb.
            /// </summary>
            loatheb,

            /// <summary>
            ///     The blessingofmight.
            /// </summary>
            blessingofmight,

            /// <summary>
            ///     The nightmare.
            /// </summary>
            nightmare,

            /// <summary>
            ///     The blessingofkings.
            /// </summary>
            blessingofkings,

            /// <summary>
            ///     The polymorph.
            /// </summary>
            polymorph,

            /// <summary>
            ///     The darkirondwarf.
            /// </summary>
            darkirondwarf,

            /// <summary>
            ///     The destroy.
            /// </summary>
            destroy,

            /// <summary>
            ///     The roguesdoit.
            /// </summary>
            roguesdoit,

            /// <summary>
            ///     The freecards.
            /// </summary>
            freecards,

            /// <summary>
            ///     The iammurloc.
            /// </summary>
            iammurloc,

            /// <summary>
            ///     The sporeburst.
            /// </summary>
            sporeburst,

            /// <summary>
            ///     The mindcontrolcrystal.
            /// </summary>
            mindcontrolcrystal,

            /// <summary>
            ///     The charge.
            /// </summary>
            charge,

            /// <summary>
            ///     The stampedingkodo.
            /// </summary>
            stampedingkodo,

            /// <summary>
            ///     The humility.
            /// </summary>
            humility,

            /// <summary>
            ///     The darkcultist.
            /// </summary>
            darkcultist,

            /// <summary>
            ///     The gruul.
            /// </summary>
            gruul,

            /// <summary>
            ///     The markofthewild.
            /// </summary>
            markofthewild,

            /// <summary>
            ///     The patchwerk.
            /// </summary>
            patchwerk,

            /// <summary>
            ///     The worgeninfiltrator.
            /// </summary>
            worgeninfiltrator,

            /// <summary>
            ///     The frostbolt.
            /// </summary>
            frostbolt,

            /// <summary>
            ///     The runeblade.
            /// </summary>
            runeblade,

            /// <summary>
            ///     The flametonguetotem.
            /// </summary>
            flametonguetotem,

            /// <summary>
            ///     The assassinate.
            /// </summary>
            assassinate,

            /// <summary>
            ///     The madscientist.
            /// </summary>
            madscientist,

            /// <summary>
            ///     The lordofthearena.
            /// </summary>
            lordofthearena,

            /// <summary>
            ///     The bainebloodhoof.
            /// </summary>
            bainebloodhoof,

            /// <summary>
            ///     The injuredblademaster.
            /// </summary>
            injuredblademaster,

            /// <summary>
            ///     The siphonsoul.
            /// </summary>
            siphonsoul,

            /// <summary>
            ///     The layonhands.
            /// </summary>
            layonhands,

            /// <summary>
            ///     The hook.
            /// </summary>
            hook,

            /// <summary>
            ///     The massiveruneblade.
            /// </summary>
            massiveruneblade,

            /// <summary>
            ///     The lorewalkercho.
            /// </summary>
            lorewalkercho,

            /// <summary>
            ///     The destroyallminions.
            /// </summary>
            destroyallminions,

            /// <summary>
            ///     The silvermoonguardian.
            /// </summary>
            silvermoonguardian,

            /// <summary>
            ///     The destroyallmana.
            /// </summary>
            destroyallmana,

            /// <summary>
            ///     The huffer.
            /// </summary>
            huffer,

            /// <summary>
            ///     The mindvision.
            /// </summary>
            mindvision,

            /// <summary>
            ///     The malfurionstormrage.
            /// </summary>
            malfurionstormrage,

            /// <summary>
            ///     The corehound.
            /// </summary>
            corehound,

            /// <summary>
            ///     The grimscaleoracle.
            /// </summary>
            grimscaleoracle,

            /// <summary>
            ///     The lightningstorm.
            /// </summary>
            lightningstorm,

            /// <summary>
            ///     The lightwell.
            /// </summary>
            lightwell,

            /// <summary>
            ///     The benthompson.
            /// </summary>
            benthompson,

            /// <summary>
            ///     The coldlightseer.
            /// </summary>
            coldlightseer,

            /// <summary>
            ///     The deathsbite.
            /// </summary>
            deathsbite,

            /// <summary>
            ///     The gorehowl.
            /// </summary>
            gorehowl,

            /// <summary>
            ///     The skitter.
            /// </summary>
            skitter,

            /// <summary>
            ///     The farsight.
            /// </summary>
            farsight,

            /// <summary>
            ///     The chillwindyeti.
            /// </summary>
            chillwindyeti,

            /// <summary>
            ///     The moonfire.
            /// </summary>
            moonfire,

            /// <summary>
            ///     The bladeflurry.
            /// </summary>
            bladeflurry,

            /// <summary>
            ///     The massdispel.
            /// </summary>
            massdispel,

            /// <summary>
            ///     The crazedalchemist.
            /// </summary>
            crazedalchemist,

            /// <summary>
            ///     The shadowmadness.
            /// </summary>
            shadowmadness,

            /// <summary>
            ///     The equality.
            /// </summary>
            equality,

            /// <summary>
            ///     The misha.
            /// </summary>
            misha,

            /// <summary>
            ///     The treant.
            /// </summary>
            treant,

            /// <summary>
            ///     The alarmobot.
            /// </summary>
            alarmobot,

            /// <summary>
            ///     The animalcompanion.
            /// </summary>
            animalcompanion,

            /// <summary>
            ///     The hatefulstrike.
            /// </summary>
            hatefulstrike,

            /// <summary>
            ///     The dream.
            /// </summary>
            dream,

            /// <summary>
            ///     The anubrekhan.
            /// </summary>
            anubrekhan,

            /// <summary>
            ///     The youngpriestess.
            /// </summary>
            youngpriestess,

            /// <summary>
            ///     The gadgetzanauctioneer.
            /// </summary>
            gadgetzanauctioneer,

            /// <summary>
            ///     The coneofcold.
            /// </summary>
            coneofcold,

            /// <summary>
            ///     The earthshock.
            /// </summary>
            earthshock,

            /// <summary>
            ///     The tirionfordring.
            /// </summary>
            tirionfordring,

            /// <summary>
            ///     The wailingsoul.
            /// </summary>
            wailingsoul,

            /// <summary>
            ///     The skeleton.
            /// </summary>
            skeleton,

            /// <summary>
            ///     The ironfurgrizzly.
            /// </summary>
            ironfurgrizzly,

            /// <summary>
            ///     The headcrack.
            /// </summary>
            headcrack,

            /// <summary>
            ///     The arcaneshot.
            /// </summary>
            arcaneshot,

            /// <summary>
            ///     The maexxna.
            /// </summary>
            maexxna,

            /// <summary>
            ///     The imp.
            /// </summary>
            imp,

            /// <summary>
            ///     The markofthehorsemen.
            /// </summary>
            markofthehorsemen,

            /// <summary>
            ///     The voidterror.
            /// </summary>
            voidterror,

            /// <summary>
            ///     The mortalcoil.
            /// </summary>
            mortalcoil,

            /// <summary>
            ///     The draw 3 cards.
            /// </summary>
            draw3cards,

            /// <summary>
            ///     The flameofazzinoth.
            /// </summary>
            flameofazzinoth,

            /// <summary>
            ///     The jainaproudmoore.
            /// </summary>
            jainaproudmoore,

            /// <summary>
            ///     The execute.
            /// </summary>
            execute,

            /// <summary>
            ///     The bloodlust.
            /// </summary>
            bloodlust,

            /// <summary>
            ///     The bananas.
            /// </summary>
            bananas,

            /// <summary>
            ///     The kidnapper.
            /// </summary>
            kidnapper,

            /// <summary>
            ///     The oldmurkeye.
            /// </summary>
            oldmurkeye,

            /// <summary>
            ///     The homingchicken.
            /// </summary>
            homingchicken,

            /// <summary>
            ///     The enableforattack.
            /// </summary>
            enableforattack,

            /// <summary>
            ///     The spellbender.
            /// </summary>
            spellbender,

            /// <summary>
            ///     The backstab.
            /// </summary>
            backstab,

            /// <summary>
            ///     The squirrel.
            /// </summary>
            squirrel,

            /// <summary>
            ///     The stalagg.
            /// </summary>
            stalagg,

            /// <summary>
            ///     The grandwidowfaerlina.
            /// </summary>
            grandwidowfaerlina,

            /// <summary>
            ///     The heavyaxe.
            /// </summary>
            heavyaxe,

            /// <summary>
            ///     The zwick.
            /// </summary>
            zwick,

            /// <summary>
            ///     The webwrap.
            /// </summary>
            webwrap,

            /// <summary>
            ///     The flamesofazzinoth.
            /// </summary>
            flamesofazzinoth,

            /// <summary>
            ///     The murlocwarleader.
            /// </summary>
            murlocwarleader,

            /// <summary>
            ///     The shadowstep.
            /// </summary>
            shadowstep,

            /// <summary>
            ///     The ancestralspirit.
            /// </summary>
            ancestralspirit,

            /// <summary>
            ///     The defenderofargus.
            /// </summary>
            defenderofargus,

            /// <summary>
            ///     The assassinsblade.
            /// </summary>
            assassinsblade,

            /// <summary>
            ///     The discard.
            /// </summary>
            discard,

            /// <summary>
            ///     The biggamehunter.
            /// </summary>
            biggamehunter,

            /// <summary>
            ///     The aldorpeacekeeper.
            /// </summary>
            aldorpeacekeeper,

            /// <summary>
            ///     The blizzard.
            /// </summary>
            blizzard,

            /// <summary>
            ///     The pandarenscout.
            /// </summary>
            pandarenscout,

            /// <summary>
            ///     The unleashthehounds.
            /// </summary>
            unleashthehounds,

            /// <summary>
            ///     The yseraawakens.
            /// </summary>
            yseraawakens,

            /// <summary>
            ///     The sap.
            /// </summary>
            sap,

            /// <summary>
            ///     The kelthuzad.
            /// </summary>
            kelthuzad,

            /// <summary>
            ///     The defiasbandit.
            /// </summary>
            defiasbandit,

            /// <summary>
            ///     The gnomishinventor.
            /// </summary>
            gnomishinventor,

            /// <summary>
            ///     The mindcontrol.
            /// </summary>
            mindcontrol,

            /// <summary>
            ///     The ravenholdtassassin.
            /// </summary>
            ravenholdtassassin,

            /// <summary>
            ///     The icelance.
            /// </summary>
            icelance,

            /// <summary>
            ///     The dispel.
            /// </summary>
            dispel,

            /// <summary>
            ///     The acidicswampooze.
            /// </summary>
            acidicswampooze,

            /// <summary>
            ///     The muklasbigbrother.
            /// </summary>
            muklasbigbrother,

            /// <summary>
            ///     The blessedchampion.
            /// </summary>
            blessedchampion,

            /// <summary>
            ///     The savannahhighmane.
            /// </summary>
            savannahhighmane,

            /// <summary>
            ///     The direwolfalpha.
            /// </summary>
            direwolfalpha,

            /// <summary>
            ///     The hoggersmash.
            /// </summary>
            hoggersmash,

            /// <summary>
            ///     The blessingofwisdom.
            /// </summary>
            blessingofwisdom,

            /// <summary>
            ///     The nourish.
            /// </summary>
            nourish,

            /// <summary>
            ///     The abusivesergeant.
            /// </summary>
            abusivesergeant,

            /// <summary>
            ///     The sylvanaswindrunner.
            /// </summary>
            sylvanaswindrunner,

            /// <summary>
            ///     The spore.
            /// </summary>
            spore,

            /// <summary>
            ///     The crueltaskmaster.
            /// </summary>
            crueltaskmaster,

            /// <summary>
            ///     The lightningbolt.
            /// </summary>
            lightningbolt,

            /// <summary>
            ///     The keeperofthegrove.
            /// </summary>
            keeperofthegrove,

            /// <summary>
            ///     The steadyshot.
            /// </summary>
            steadyshot,

            /// <summary>
            ///     The multishot.
            /// </summary>
            multishot,

            /// <summary>
            ///     The harvest.
            /// </summary>
            harvest,

            /// <summary>
            ///     The instructorrazuvious.
            /// </summary>
            instructorrazuvious,

            /// <summary>
            ///     The ladyblaumeux.
            /// </summary>
            ladyblaumeux,

            /// <summary>
            ///     The jaybaxter.
            /// </summary>
            jaybaxter,

            /// <summary>
            ///     The molasses.
            /// </summary>
            molasses,

            /// <summary>
            ///     The pintsizedsummoner.
            /// </summary>
            pintsizedsummoner,

            /// <summary>
            ///     The spellbreaker.
            /// </summary>
            spellbreaker,

            /// <summary>
            ///     The anubarambusher.
            /// </summary>
            anubarambusher,

            /// <summary>
            ///     The deadlypoison.
            /// </summary>
            deadlypoison,

            /// <summary>
            ///     The stoneskingargoyle.
            /// </summary>
            stoneskingargoyle,

            /// <summary>
            ///     The bloodfury.
            /// </summary>
            bloodfury,

            /// <summary>
            ///     The fanofknives.
            /// </summary>
            fanofknives,

            /// <summary>
            ///     The poisoncloud.
            /// </summary>
            poisoncloud,

            /// <summary>
            ///     The shieldbearer.
            /// </summary>
            shieldbearer,

            /// <summary>
            ///     The sensedemons.
            /// </summary>
            sensedemons,

            /// <summary>
            ///     The shieldblock.
            /// </summary>
            shieldblock,

            /// <summary>
            ///     The handswapperminion.
            /// </summary>
            handswapperminion,

            /// <summary>
            ///     The massivegnoll.
            /// </summary>
            massivegnoll,

            /// <summary>
            ///     The deathcharger.
            /// </summary>
            deathcharger,

            /// <summary>
            ///     The ancientoflore.
            /// </summary>
            ancientoflore,

            /// <summary>
            ///     The oasissnapjaw.
            /// </summary>
            oasissnapjaw,

            /// <summary>
            ///     The illidanstormrage.
            /// </summary>
            illidanstormrage,

            /// <summary>
            ///     The frostwolfgrunt.
            /// </summary>
            frostwolfgrunt,

            /// <summary>
            ///     The lesserheal.
            /// </summary>
            lesserheal,

            /// <summary>
            ///     The infernal.
            /// </summary>
            infernal,

            /// <summary>
            ///     The wildpyromancer.
            /// </summary>
            wildpyromancer,

            /// <summary>
            ///     The razorfenhunter.
            /// </summary>
            razorfenhunter,

            /// <summary>
            ///     The twistingnether.
            /// </summary>
            twistingnether,

            /// <summary>
            ///     The voidcaller.
            /// </summary>
            voidcaller,

            /// <summary>
            ///     The leaderofthepack.
            /// </summary>
            leaderofthepack,

            /// <summary>
            ///     The malygos.
            /// </summary>
            malygos,

            /// <summary>
            ///     The becomehogger.
            /// </summary>
            becomehogger,

            /// <summary>
            ///     The baronrivendare.
            /// </summary>
            baronrivendare,

            /// <summary>
            ///     The millhousemanastorm.
            /// </summary>
            millhousemanastorm,

            /// <summary>
            ///     The innerfire.
            /// </summary>
            innerfire,

            /// <summary>
            ///     The valeerasanguinar.
            /// </summary>
            valeerasanguinar,

            /// <summary>
            ///     The chicken.
            /// </summary>
            chicken,

            /// <summary>
            ///     The souloftheforest.
            /// </summary>
            souloftheforest,

            /// <summary>
            ///     The silencedebug.
            /// </summary>
            silencedebug,

            /// <summary>
            ///     The bloodsailcorsair.
            /// </summary>
            bloodsailcorsair,

            /// <summary>
            ///     The slime.
            /// </summary>
            slime,

            /// <summary>
            ///     The tinkmasteroverspark.
            /// </summary>
            tinkmasteroverspark,

            /// <summary>
            ///     The iceblock.
            /// </summary>
            iceblock,

            /// <summary>
            ///     The brawl.
            /// </summary>
            brawl,

            /// <summary>
            ///     The vanish.
            /// </summary>
            vanish,

            /// <summary>
            ///     The poisonseeds.
            /// </summary>
            poisonseeds,

            /// <summary>
            ///     The murloc.
            /// </summary>
            murloc,

            /// <summary>
            ///     The mindspike.
            /// </summary>
            mindspike,

            /// <summary>
            ///     The kingmukla.
            /// </summary>
            kingmukla,

            /// <summary>
            ///     The stevengabriel.
            /// </summary>
            stevengabriel,

            /// <summary>
            ///     The gluth.
            /// </summary>
            gluth,

            /// <summary>
            ///     The truesilverchampion.
            /// </summary>
            truesilverchampion,

            /// <summary>
            ///     The harrisonjones.
            /// </summary>
            harrisonjones,

            /// <summary>
            ///     The destroydeck.
            /// </summary>
            destroydeck,

            /// <summary>
            ///     The devilsaur.
            /// </summary>
            devilsaur,

            /// <summary>
            ///     The wargolem.
            /// </summary>
            wargolem,

            /// <summary>
            ///     The warsongcommander.
            /// </summary>
            warsongcommander,

            /// <summary>
            ///     The manawyrm.
            /// </summary>
            manawyrm,

            /// <summary>
            ///     The thaddius.
            /// </summary>
            thaddius,

            /// <summary>
            ///     The savagery.
            /// </summary>
            savagery,

            /// <summary>
            ///     The spitefulsmith.
            /// </summary>
            spitefulsmith,

            /// <summary>
            ///     The shatteredsuncleric.
            /// </summary>
            shatteredsuncleric,

            /// <summary>
            ///     The eyeforaneye.
            /// </summary>
            eyeforaneye,

            /// <summary>
            ///     The azuredrake.
            /// </summary>
            azuredrake,

            /// <summary>
            ///     The mountaingiant.
            /// </summary>
            mountaingiant,

            /// <summary>
            ///     The korkronelite.
            /// </summary>
            korkronelite,

            /// <summary>
            ///     The junglepanther.
            /// </summary>
            junglepanther,

            /// <summary>
            ///     The barongeddon.
            /// </summary>
            barongeddon,

            /// <summary>
            ///     The spectralspider.
            /// </summary>
            spectralspider,

            /// <summary>
            ///     The pitlord.
            /// </summary>
            pitlord,

            /// <summary>
            ///     The markofnature.
            /// </summary>
            markofnature,

            /// <summary>
            ///     The grobbulus.
            /// </summary>
            grobbulus,

            /// <summary>
            ///     The leokk.
            /// </summary>
            leokk,

            /// <summary>
            ///     The fierywaraxe.
            /// </summary>
            fierywaraxe,

            /// <summary>
            ///     The damage 5.
            /// </summary>
            damage5,

            /// <summary>
            ///     The duplicate.
            /// </summary>
            duplicate,

            /// <summary>
            ///     The restore 5.
            /// </summary>
            restore5,

            /// <summary>
            ///     The mindblast.
            /// </summary>
            mindblast,

            /// <summary>
            ///     The timberwolf.
            /// </summary>
            timberwolf,

            /// <summary>
            ///     The captaingreenskin.
            /// </summary>
            captaingreenskin,

            /// <summary>
            ///     The elvenarcher.
            /// </summary>
            elvenarcher,

            /// <summary>
            ///     The michaelschweitzer.
            /// </summary>
            michaelschweitzer,

            /// <summary>
            ///     The masterswordsmith.
            /// </summary>
            masterswordsmith,

            /// <summary>
            ///     The grommashhellscream.
            /// </summary>
            grommashhellscream,

            /// <summary>
            ///     The hound.
            /// </summary>
            hound,

            /// <summary>
            ///     The seagiant.
            /// </summary>
            seagiant,

            /// <summary>
            ///     The doomguard.
            /// </summary>
            doomguard,

            /// <summary>
            ///     The alakirthewindlord.
            /// </summary>
            alakirthewindlord,

            /// <summary>
            ///     The hyena.
            /// </summary>
            hyena,

            /// <summary>
            ///     The undertaker.
            /// </summary>
            undertaker,

            /// <summary>
            ///     The frothingberserker.
            /// </summary>
            frothingberserker,

            /// <summary>
            ///     The powerofthewild.
            /// </summary>
            powerofthewild,

            /// <summary>
            ///     The druidoftheclaw.
            /// </summary>
            druidoftheclaw,

            /// <summary>
            ///     The hellfire.
            /// </summary>
            hellfire,

            /// <summary>
            ///     The archmage.
            /// </summary>
            archmage,

            /// <summary>
            ///     The recklessrocketeer.
            /// </summary>
            recklessrocketeer,

            /// <summary>
            ///     The crazymonkey.
            /// </summary>
            crazymonkey,

            /// <summary>
            ///     The damageallbut 1.
            /// </summary>
            damageallbut1,

            /// <summary>
            ///     The frostblast.
            /// </summary>
            frostblast,

            /// <summary>
            ///     The powerwordshield.
            /// </summary>
            powerwordshield,

            /// <summary>
            ///     The rainoffire.
            /// </summary>
            rainoffire,

            /// <summary>
            ///     The arcaneintellect.
            /// </summary>
            arcaneintellect,

            /// <summary>
            ///     The angrychicken.
            /// </summary>
            angrychicken,

            /// <summary>
            ///     The nerubianegg.
            /// </summary>
            nerubianegg,

            /// <summary>
            ///     The worshipper.
            /// </summary>
            worshipper,

            /// <summary>
            ///     The mindgames.
            /// </summary>
            mindgames,

            /// <summary>
            ///     The leeroyjenkins.
            /// </summary>
            leeroyjenkins,

            /// <summary>
            ///     The gurubashiberserker.
            /// </summary>
            gurubashiberserker,

            /// <summary>
            ///     The windspeaker.
            /// </summary>
            windspeaker,

            /// <summary>
            ///     The enableemotes.
            /// </summary>
            enableemotes,

            /// <summary>
            ///     The forceofnature.
            /// </summary>
            forceofnature,

            /// <summary>
            ///     The lightspawn.
            /// </summary>
            lightspawn,

            /// <summary>
            ///     The destroyamanacrystal.
            /// </summary>
            destroyamanacrystal,

            /// <summary>
            ///     The warglaiveofazzinoth.
            /// </summary>
            warglaiveofazzinoth,

            /// <summary>
            ///     The finkleeinhorn.
            /// </summary>
            finkleeinhorn,

            /// <summary>
            ///     The frostelemental.
            /// </summary>
            frostelemental,

            /// <summary>
            ///     The thoughtsteal.
            /// </summary>
            thoughtsteal,

            /// <summary>
            ///     The brianschwab.
            /// </summary>
            brianschwab,

            /// <summary>
            ///     The scavenginghyena.
            /// </summary>
            scavenginghyena,

            /// <summary>
            ///     The si 7 agent.
            /// </summary>
            si7agent,

            /// <summary>
            ///     The prophetvelen.
            /// </summary>
            prophetvelen,

            /// <summary>
            ///     The soulfire.
            /// </summary>
            soulfire,

            /// <summary>
            ///     The ogremagi.
            /// </summary>
            ogremagi,

            /// <summary>
            ///     The damagedgolem.
            /// </summary>
            damagedgolem,

            /// <summary>
            ///     The crash.
            /// </summary>
            crash,

            /// <summary>
            ///     The adrenalinerush.
            /// </summary>
            adrenalinerush,

            /// <summary>
            ///     The murloctidecaller.
            /// </summary>
            murloctidecaller,

            /// <summary>
            ///     The kirintormage.
            /// </summary>
            kirintormage,

            /// <summary>
            ///     The spectralrider.
            /// </summary>
            spectralrider,

            /// <summary>
            ///     The thrallmarfarseer.
            /// </summary>
            thrallmarfarseer,

            /// <summary>
            ///     The frostwolfwarlord.
            /// </summary>
            frostwolfwarlord,

            /// <summary>
            ///     The sorcerersapprentice.
            /// </summary>
            sorcerersapprentice,

            /// <summary>
            ///     The feugen.
            /// </summary>
            feugen,

            /// <summary>
            ///     The willofmukla.
            /// </summary>
            willofmukla,

            /// <summary>
            ///     The holyfire.
            /// </summary>
            holyfire,

            /// <summary>
            ///     The manawraith.
            /// </summary>
            manawraith,

            /// <summary>
            ///     The argentsquire.
            /// </summary>
            argentsquire,

            /// <summary>
            ///     The placeholdercard.
            /// </summary>
            placeholdercard,

            /// <summary>
            ///     The snakeball.
            /// </summary>
            snakeball,

            /// <summary>
            ///     The ancientwatcher.
            /// </summary>
            ancientwatcher,

            /// <summary>
            ///     The noviceengineer.
            /// </summary>
            noviceengineer,

            /// <summary>
            ///     The stonetuskboar.
            /// </summary>
            stonetuskboar,

            /// <summary>
            ///     The ancestralhealing.
            /// </summary>
            ancestralhealing,

            /// <summary>
            ///     The conceal.
            /// </summary>
            conceal,

            /// <summary>
            ///     The arcanitereaper.
            /// </summary>
            arcanitereaper,

            /// <summary>
            ///     The guldan.
            /// </summary>
            guldan,

            /// <summary>
            ///     The ragingworgen.
            /// </summary>
            ragingworgen,

            /// <summary>
            ///     The earthenringfarseer.
            /// </summary>
            earthenringfarseer,

            /// <summary>
            ///     The onyxia.
            /// </summary>
            onyxia,

            /// <summary>
            ///     The manaaddict.
            /// </summary>
            manaaddict,

            /// <summary>
            ///     The unholyshadow.
            /// </summary>
            unholyshadow,

            /// <summary>
            ///     The dualwarglaives.
            /// </summary>
            dualwarglaives,

            /// <summary>
            ///     The sludgebelcher.
            /// </summary>
            sludgebelcher,

            /// <summary>
            ///     The worthlessimp.
            /// </summary>
            worthlessimp,

            /// <summary>
            ///     The shiv.
            /// </summary>
            shiv,

            /// <summary>
            ///     The sheep.
            /// </summary>
            sheep,

            /// <summary>
            ///     The bloodknight.
            /// </summary>
            bloodknight,

            /// <summary>
            ///     The holysmite.
            /// </summary>
            holysmite,

            /// <summary>
            ///     The ancientsecrets.
            /// </summary>
            ancientsecrets,

            /// <summary>
            ///     The holywrath.
            /// </summary>
            holywrath,

            /// <summary>
            ///     The ironforgerifleman.
            /// </summary>
            ironforgerifleman,

            /// <summary>
            ///     The elitetaurenchieftain.
            /// </summary>
            elitetaurenchieftain,

            /// <summary>
            ///     The spectralwarrior.
            /// </summary>
            spectralwarrior,

            /// <summary>
            ///     The bluegillwarrior.
            /// </summary>
            bluegillwarrior,

            /// <summary>
            ///     The shapeshift.
            /// </summary>
            shapeshift,

            /// <summary>
            ///     The hamiltonchu.
            /// </summary>
            hamiltonchu,

            /// <summary>
            ///     The battlerage.
            /// </summary>
            battlerage,

            /// <summary>
            ///     The nightblade.
            /// </summary>
            nightblade,

            /// <summary>
            ///     The locustswarm.
            /// </summary>
            locustswarm,

            /// <summary>
            ///     The crazedhunter.
            /// </summary>
            crazedhunter,

            /// <summary>
            ///     The andybrock.
            /// </summary>
            andybrock,

            /// <summary>
            ///     The youthfulbrewmaster.
            /// </summary>
            youthfulbrewmaster,

            /// <summary>
            ///     The theblackknight.
            /// </summary>
            theblackknight,

            /// <summary>
            ///     The brewmaster.
            /// </summary>
            brewmaster,

            /// <summary>
            ///     The lifetap.
            /// </summary>
            lifetap,

            /// <summary>
            ///     The demonfire.
            /// </summary>
            demonfire,

            /// <summary>
            ///     The redemption.
            /// </summary>
            redemption,

            /// <summary>
            ///     The lordjaraxxus.
            /// </summary>
            lordjaraxxus,

            /// <summary>
            ///     The coldblood.
            /// </summary>
            coldblood,

            /// <summary>
            ///     The lightwarden.
            /// </summary>
            lightwarden,

            /// <summary>
            ///     The questingadventurer.
            /// </summary>
            questingadventurer,

            /// <summary>
            ///     The donothing.
            /// </summary>
            donothing,

            /// <summary>
            ///     The dereksakamoto.
            /// </summary>
            dereksakamoto,

            /// <summary>
            ///     The poultryizer.
            /// </summary>
            poultryizer,

            /// <summary>
            ///     The koboldgeomancer.
            /// </summary>
            koboldgeomancer,

            /// <summary>
            ///     The legacyoftheemperor.
            /// </summary>
            legacyoftheemperor,

            /// <summary>
            ///     The eruption.
            /// </summary>
            eruption,

            /// <summary>
            ///     The cenarius.
            /// </summary>
            cenarius,

            /// <summary>
            ///     The deathlord.
            /// </summary>
            deathlord,

            /// <summary>
            ///     The searingtotem.
            /// </summary>
            searingtotem,

            /// <summary>
            ///     The taurenwarrior.
            /// </summary>
            taurenwarrior,

            /// <summary>
            ///     The explosivetrap.
            /// </summary>
            explosivetrap,

            /// <summary>
            ///     The frog.
            /// </summary>
            frog,

            /// <summary>
            ///     The servercrash.
            /// </summary>
            servercrash,

            /// <summary>
            ///     The wickedknife.
            /// </summary>
            wickedknife,

            /// <summary>
            ///     The laughingsister.
            /// </summary>
            laughingsister,

            /// <summary>
            ///     The cultmaster.
            /// </summary>
            cultmaster,

            /// <summary>
            ///     The wildgrowth.
            /// </summary>
            wildgrowth,

            /// <summary>
            ///     The sprint.
            /// </summary>
            sprint,

            /// <summary>
            ///     The masterofdisguise.
            /// </summary>
            masterofdisguise,

            /// <summary>
            ///     The kyleharrison.
            /// </summary>
            kyleharrison,

            /// <summary>
            ///     The avatarofthecoin.
            /// </summary>
            avatarofthecoin,

            /// <summary>
            ///     The excessmana.
            /// </summary>
            excessmana,

            /// <summary>
            ///     The spiritwolf.
            /// </summary>
            spiritwolf,

            /// <summary>
            ///     The auchenaisoulpriest.
            /// </summary>
            auchenaisoulpriest,

            /// <summary>
            ///     The bestialwrath.
            /// </summary>
            bestialwrath,

            /// <summary>
            ///     The rockbiterweapon.
            /// </summary>
            rockbiterweapon,

            /// <summary>
            ///     The starvingbuzzard.
            /// </summary>
            starvingbuzzard,

            /// <summary>
            ///     The mirrorimage.
            /// </summary>
            mirrorimage,

            /// <summary>
            ///     The frozenchampion.
            /// </summary>
            frozenchampion,

            /// <summary>
            ///     The silverhandrecruit.
            /// </summary>
            silverhandrecruit,

            /// <summary>
            ///     The corruption.
            /// </summary>
            corruption,

            /// <summary>
            ///     The preparation.
            /// </summary>
            preparation,

            /// <summary>
            ///     The cairnebloodhoof.
            /// </summary>
            cairnebloodhoof,

            /// <summary>
            ///     The mortalstrike.
            /// </summary>
            mortalstrike,

            /// <summary>
            ///     The flare.
            /// </summary>
            flare,

            /// <summary>
            ///     The necroknight.
            /// </summary>
            necroknight,

            /// <summary>
            ///     The silverhandknight.
            /// </summary>
            silverhandknight,

            /// <summary>
            ///     The breakweapon.
            /// </summary>
            breakweapon,

            /// <summary>
            ///     The guardianofkings.
            /// </summary>
            guardianofkings,

            /// <summary>
            ///     The ancientbrewmaster.
            /// </summary>
            ancientbrewmaster,

            /// <summary>
            ///     The avenge.
            /// </summary>
            avenge,

            /// <summary>
            ///     The youngdragonhawk.
            /// </summary>
            youngdragonhawk,

            /// <summary>
            ///     The frostshock.
            /// </summary>
            frostshock,

            /// <summary>
            ///     The healingtouch.
            /// </summary>
            healingtouch,

            /// <summary>
            ///     The venturecomercenary.
            /// </summary>
            venturecomercenary,

            /// <summary>
            ///     The unbalancingstrike.
            /// </summary>
            unbalancingstrike,

            /// <summary>
            ///     The sacrificialpact.
            /// </summary>
            sacrificialpact,

            /// <summary>
            ///     The noooooooooooo.
            /// </summary>
            noooooooooooo,

            /// <summary>
            ///     The baneofdoom.
            /// </summary>
            baneofdoom,

            /// <summary>
            ///     The abomination.
            /// </summary>
            abomination,

            /// <summary>
            ///     The flesheatingghoul.
            /// </summary>
            flesheatingghoul,

            /// <summary>
            ///     The loothoarder.
            /// </summary>
            loothoarder,

            /// <summary>
            ///     The mill 10.
            /// </summary>
            mill10,

            /// <summary>
            ///     The sapphiron.
            /// </summary>
            sapphiron,

            /// <summary>
            ///     The jasonchayes.
            /// </summary>
            jasonchayes,

            /// <summary>
            ///     The benbrode.
            /// </summary>
            benbrode,

            /// <summary>
            ///     The betrayal.
            /// </summary>
            betrayal,

            /// <summary>
            ///     The thebeast.
            /// </summary>
            thebeast,

            /// <summary>
            ///     The flameimp.
            /// </summary>
            flameimp,

            /// <summary>
            ///     The freezingtrap.
            /// </summary>
            freezingtrap,

            /// <summary>
            ///     The southseadeckhand.
            /// </summary>
            southseadeckhand,

            /// <summary>
            ///     The wrath.
            /// </summary>
            wrath,

            /// <summary>
            ///     The bloodfenraptor.
            /// </summary>
            bloodfenraptor,

            /// <summary>
            ///     The cleave.
            /// </summary>
            cleave,

            /// <summary>
            ///     The fencreeper.
            /// </summary>
            fencreeper,

            /// <summary>
            ///     The restore 1.
            /// </summary>
            restore1,

            /// <summary>
            ///     The handtodeck.
            /// </summary>
            handtodeck,

            /// <summary>
            ///     The starfire.
            /// </summary>
            starfire,

            /// <summary>
            ///     The goldshirefootman.
            /// </summary>
            goldshirefootman,

            /// <summary>
            ///     The unrelentingtrainee.
            /// </summary>
            unrelentingtrainee,

            /// <summary>
            ///     The murlocscout.
            /// </summary>
            murlocscout,

            /// <summary>
            ///     The ragnarosthefirelord.
            /// </summary>
            ragnarosthefirelord,

            /// <summary>
            ///     The rampage.
            /// </summary>
            rampage,

            /// <summary>
            ///     The zombiechow.
            /// </summary>
            zombiechow,

            /// <summary>
            ///     The thrall.
            /// </summary>
            thrall,

            /// <summary>
            ///     The stoneclawtotem.
            /// </summary>
            stoneclawtotem,

            /// <summary>
            ///     The captainsparrot.
            /// </summary>
            captainsparrot,

            /// <summary>
            ///     The windfuryharpy.
            /// </summary>
            windfuryharpy,

            /// <summary>
            ///     The unrelentingwarrior.
            /// </summary>
            unrelentingwarrior,

            /// <summary>
            ///     The stranglethorntiger.
            /// </summary>
            stranglethorntiger,

            /// <summary>
            ///     The summonarandomsecret.
            /// </summary>
            summonarandomsecret,

            /// <summary>
            ///     The circleofhealing.
            /// </summary>
            circleofhealing,

            /// <summary>
            ///     The snaketrap.
            /// </summary>
            snaketrap,

            /// <summary>
            ///     The cabalshadowpriest.
            /// </summary>
            cabalshadowpriest,

            /// <summary>
            ///     The nerubarweblord.
            /// </summary>
            nerubarweblord,

            /// <summary>
            ///     The upgrade.
            /// </summary>
            upgrade,

            /// <summary>
            ///     The shieldslam.
            /// </summary>
            shieldslam,

            /// <summary>
            ///     The flameburst.
            /// </summary>
            flameburst,

            /// <summary>
            ///     The windfury.
            /// </summary>
            windfury,

            /// <summary>
            ///     The enrage.
            /// </summary>
            enrage,

            /// <summary>
            ///     The natpagle.
            /// </summary>
            natpagle,

            /// <summary>
            ///     The restoreallhealth.
            /// </summary>
            restoreallhealth,

            /// <summary>
            ///     The houndmaster.
            /// </summary>
            houndmaster,

            /// <summary>
            ///     The waterelemental.
            /// </summary>
            waterelemental,

            /// <summary>
            ///     The eaglehornbow.
            /// </summary>
            eaglehornbow,

            /// <summary>
            ///     The gnoll.
            /// </summary>
            gnoll,

            /// <summary>
            ///     The archmageantonidas.
            /// </summary>
            archmageantonidas,

            /// <summary>
            ///     The destroyallheroes.
            /// </summary>
            destroyallheroes,

            /// <summary>
            ///     The chains.
            /// </summary>
            chains,

            /// <summary>
            ///     The wrathofairtotem.
            /// </summary>
            wrathofairtotem,

            /// <summary>
            ///     The killcommand.
            /// </summary>
            killcommand,

            /// <summary>
            ///     The manatidetotem.
            /// </summary>
            manatidetotem,

            /// <summary>
            ///     The daggermastery.
            /// </summary>
            daggermastery,

            /// <summary>
            ///     The drainlife.
            /// </summary>
            drainlife,

            /// <summary>
            ///     The doomsayer.
            /// </summary>
            doomsayer,

            /// <summary>
            ///     The darkscalehealer.
            /// </summary>
            darkscalehealer,

            /// <summary>
            ///     The shadowform.
            /// </summary>
            shadowform,

            /// <summary>
            ///     The frostnova.
            /// </summary>
            frostnova,

            /// <summary>
            ///     The purecold.
            /// </summary>
            purecold,

            /// <summary>
            ///     The mirrorentity.
            /// </summary>
            mirrorentity,

            /// <summary>
            ///     The counterspell.
            /// </summary>
            counterspell,

            /// <summary>
            ///     The mindshatter.
            /// </summary>
            mindshatter,

            /// <summary>
            ///     The magmarager.
            /// </summary>
            magmarager,

            /// <summary>
            ///     The wolfrider.
            /// </summary>
            wolfrider,

            /// <summary>
            ///     The emboldener 3000.
            /// </summary>
            emboldener3000,

            /// <summary>
            ///     The polarityshift.
            /// </summary>
            polarityshift,

            /// <summary>
            ///     The gelbinmekkatorque.
            /// </summary>
            gelbinmekkatorque,

            /// <summary>
            ///     The webspinner.
            /// </summary>
            webspinner,

            /// <summary>
            ///     The utherlightbringer.
            /// </summary>
            utherlightbringer,

            /// <summary>
            ///     The innerrage.
            /// </summary>
            innerrage,

            /// <summary>
            ///     The emeralddrake.
            /// </summary>
            emeralddrake,

            /// <summary>
            ///     The forceaitouseheropower.
            /// </summary>
            forceaitouseheropower,

            /// <summary>
            ///     The echoingooze.
            /// </summary>
            echoingooze,

            /// <summary>
            ///     The heroicstrike.
            /// </summary>
            heroicstrike,

            /// <summary>
            ///     The hauntedcreeper.
            /// </summary>
            hauntedcreeper,

            /// <summary>
            ///     The barreltoss.
            /// </summary>
            barreltoss,

            /// <summary>
            ///     The yongwoo.
            /// </summary>
            yongwoo,

            /// <summary>
            ///     The doomhammer.
            /// </summary>
            doomhammer,

            /// <summary>
            ///     The stomp.
            /// </summary>
            stomp,

            /// <summary>
            ///     The spectralknight.
            /// </summary>
            spectralknight,

            /// <summary>
            ///     The tracking.
            /// </summary>
            tracking,

            /// <summary>
            ///     The fireball.
            /// </summary>
            fireball,

            /// <summary>
            ///     The thecoin.
            /// </summary>
            thecoin,

            /// <summary>
            ///     The bootybaybodyguard.
            /// </summary>
            bootybaybodyguard,

            /// <summary>
            ///     The scarletcrusader.
            /// </summary>
            scarletcrusader,

            /// <summary>
            ///     The voodoodoctor.
            /// </summary>
            voodoodoctor,

            /// <summary>
            ///     The shadowbolt.
            /// </summary>
            shadowbolt,

            /// <summary>
            ///     The etherealarcanist.
            /// </summary>
            etherealarcanist,

            /// <summary>
            ///     The succubus.
            /// </summary>
            succubus,

            /// <summary>
            ///     The emperorcobra.
            /// </summary>
            emperorcobra,

            /// <summary>
            ///     The deadlyshot.
            /// </summary>
            deadlyshot,

            /// <summary>
            ///     The reinforce.
            /// </summary>
            reinforce,

            /// <summary>
            ///     The supercharge.
            /// </summary>
            supercharge,

            /// <summary>
            ///     The claw.
            /// </summary>
            claw,

            /// <summary>
            ///     The explosiveshot.
            /// </summary>
            explosiveshot,

            /// <summary>
            ///     The avengingwrath.
            /// </summary>
            avengingwrath,

            /// <summary>
            ///     The riverpawgnoll.
            /// </summary>
            riverpawgnoll,

            /// <summary>
            ///     The sirzeliek.
            /// </summary>
            sirzeliek,

            /// <summary>
            ///     The argentprotector.
            /// </summary>
            argentprotector,

            /// <summary>
            ///     The hiddengnome.
            /// </summary>
            hiddengnome,

            /// <summary>
            ///     The felguard.
            /// </summary>
            felguard,

            /// <summary>
            ///     The northshirecleric.
            /// </summary>
            northshirecleric,

            /// <summary>
            ///     The plague.
            /// </summary>
            plague,

            /// <summary>
            ///     The lepergnome.
            /// </summary>
            lepergnome,

            /// <summary>
            ///     The fireelemental.
            /// </summary>
            fireelemental,

            /// <summary>
            ///     The armorup.
            /// </summary>
            armorup,

            /// <summary>
            ///     The snipe.
            /// </summary>
            snipe,

            /// <summary>
            ///     The southseacaptain.
            /// </summary>
            southseacaptain,

            /// <summary>
            ///     The catform.
            /// </summary>
            catform,

            /// <summary>
            ///     The bite.
            /// </summary>
            bite,

            /// <summary>
            ///     The defiasringleader.
            /// </summary>
            defiasringleader,

            /// <summary>
            ///     The harvestgolem.
            /// </summary>
            harvestgolem,

            /// <summary>
            ///     The kingkrush.
            /// </summary>
            kingkrush,

            /// <summary>
            ///     The aibuddydamageownhero 5.
            /// </summary>
            aibuddydamageownhero5,

            /// <summary>
            ///     The healingtotem.
            /// </summary>
            healingtotem,

            /// <summary>
            ///     The ericdodds.
            /// </summary>
            ericdodds,

            /// <summary>
            ///     The demigodsfavor.
            /// </summary>
            demigodsfavor,

            /// <summary>
            ///     The huntersmark.
            /// </summary>
            huntersmark,

            /// <summary>
            ///     The dalaranmage.
            /// </summary>
            dalaranmage,

            /// <summary>
            ///     The twilightdrake.
            /// </summary>
            twilightdrake,

            /// <summary>
            ///     The coldlightoracle.
            /// </summary>
            coldlightoracle,

            /// <summary>
            ///     The shadeofnaxxramas.
            /// </summary>
            shadeofnaxxramas,

            /// <summary>
            ///     The moltengiant.
            /// </summary>
            moltengiant,

            /// <summary>
            ///     The deathbloom.
            /// </summary>
            deathbloom,

            /// <summary>
            ///     The shadowflame.
            /// </summary>
            shadowflame,

            /// <summary>
            ///     The anduinwrynn.
            /// </summary>
            anduinwrynn,

            /// <summary>
            ///     The argentcommander.
            /// </summary>
            argentcommander,

            /// <summary>
            ///     The revealhand.
            /// </summary>
            revealhand,

            /// <summary>
            ///     The arcanemissiles.
            /// </summary>
            arcanemissiles,

            /// <summary>
            ///     The repairbot.
            /// </summary>
            repairbot,

            /// <summary>
            ///     The unstableghoul.
            /// </summary>
            unstableghoul,

            /// <summary>
            ///     The ancientofwar.
            /// </summary>
            ancientofwar,

            /// <summary>
            ///     The stormwindchampion.
            /// </summary>
            stormwindchampion,

            /// <summary>
            ///     The summonapanther.
            /// </summary>
            summonapanther,

            /// <summary>
            ///     The mrbigglesworth.
            /// </summary>
            mrbigglesworth,

            /// <summary>
            ///     The swipe.
            /// </summary>
            swipe,

            /// <summary>
            ///     The aihelperbuddy.
            /// </summary>
            aihelperbuddy,

            /// <summary>
            ///     The hex.
            /// </summary>
            hex,

            /// <summary>
            ///     The ysera.
            /// </summary>
            ysera,

            /// <summary>
            ///     The arcanegolem.
            /// </summary>
            arcanegolem,

            /// <summary>
            ///     The bloodimp.
            /// </summary>
            bloodimp,

            /// <summary>
            ///     The pyroblast.
            /// </summary>
            pyroblast,

            /// <summary>
            ///     The murlocraider.
            /// </summary>
            murlocraider,

            /// <summary>
            ///     The faeriedragon.
            /// </summary>
            faeriedragon,

            /// <summary>
            ///     The sinisterstrike.
            /// </summary>
            sinisterstrike,

            /// <summary>
            ///     The poweroverwhelming.
            /// </summary>
            poweroverwhelming,

            /// <summary>
            ///     The arcaneexplosion.
            /// </summary>
            arcaneexplosion,

            /// <summary>
            ///     The shadowwordpain.
            /// </summary>
            shadowwordpain,

            /// <summary>
            ///     The mill 30.
            /// </summary>
            mill30,

            /// <summary>
            ///     The noblesacrifice.
            /// </summary>
            noblesacrifice,

            /// <summary>
            ///     The dreadinfernal.
            /// </summary>
            dreadinfernal,

            /// <summary>
            ///     The naturalize.
            /// </summary>
            naturalize,

            /// <summary>
            ///     The totemiccall.
            /// </summary>
            totemiccall,

            /// <summary>
            ///     The secretkeeper.
            /// </summary>
            secretkeeper,

            /// <summary>
            ///     The dreadcorsair.
            /// </summary>
            dreadcorsair,

            /// <summary>
            ///     The jaws.
            /// </summary>
            jaws,

            /// <summary>
            ///     The forkedlightning.
            /// </summary>
            forkedlightning,

            /// <summary>
            ///     The reincarnate.
            /// </summary>
            reincarnate,

            /// <summary>
            ///     The handofprotection.
            /// </summary>
            handofprotection,

            /// <summary>
            ///     The noththeplaguebringer.
            /// </summary>
            noththeplaguebringer,

            /// <summary>
            ///     The vaporize.
            /// </summary>
            vaporize,

            /// <summary>
            ///     The frostbreath.
            /// </summary>
            frostbreath,

            /// <summary>
            ///     The nozdormu.
            /// </summary>
            nozdormu,

            /// <summary>
            ///     The divinespirit.
            /// </summary>
            divinespirit,

            /// <summary>
            ///     The transcendence.
            /// </summary>
            transcendence,

            /// <summary>
            ///     The armorsmith.
            /// </summary>
            armorsmith,

            /// <summary>
            ///     The murloctidehunter.
            /// </summary>
            murloctidehunter,

            /// <summary>
            ///     The stealcard.
            /// </summary>
            stealcard,

            /// <summary>
            ///     The opponentconcede.
            /// </summary>
            opponentconcede,

            /// <summary>
            ///     The tundrarhino.
            /// </summary>
            tundrarhino,

            /// <summary>
            ///     The summoningportal.
            /// </summary>
            summoningportal,

            /// <summary>
            ///     The hammerofwrath.
            /// </summary>
            hammerofwrath,

            /// <summary>
            ///     The stormwindknight.
            /// </summary>
            stormwindknight,

            /// <summary>
            ///     The freeze.
            /// </summary>
            freeze,

            /// <summary>
            ///     The madbomber.
            /// </summary>
            madbomber,

            /// <summary>
            ///     The consecration.
            /// </summary>
            consecration,

            /// <summary>
            ///     The spectraltrainee.
            /// </summary>
            spectraltrainee,

            /// <summary>
            ///     The boar.
            /// </summary>
            boar,

            /// <summary>
            ///     The knifejuggler.
            /// </summary>
            knifejuggler,

            /// <summary>
            ///     The icebarrier.
            /// </summary>
            icebarrier,

            /// <summary>
            ///     The mechanicaldragonling.
            /// </summary>
            mechanicaldragonling,

            /// <summary>
            ///     The battleaxe.
            /// </summary>
            battleaxe,

            /// <summary>
            ///     The lightsjustice.
            /// </summary>
            lightsjustice,

            /// <summary>
            ///     The lavaburst.
            /// </summary>
            lavaburst,

            /// <summary>
            ///     The mindcontroltech.
            /// </summary>
            mindcontroltech,

            /// <summary>
            ///     The boulderfistogre.
            /// </summary>
            boulderfistogre,

            /// <summary>
            ///     The fireblast.
            /// </summary>
            fireblast,

            /// <summary>
            ///     The priestessofelune.
            /// </summary>
            priestessofelune,

            /// <summary>
            ///     The ancientmage.
            /// </summary>
            ancientmage,

            /// <summary>
            ///     The shadowworddeath.
            /// </summary>
            shadowworddeath,

            /// <summary>
            ///     The ironbeakowl.
            /// </summary>
            ironbeakowl,

            /// <summary>
            ///     The eviscerate.
            /// </summary>
            eviscerate,

            /// <summary>
            ///     The repentance.
            /// </summary>
            repentance,

            /// <summary>
            ///     The understudy.
            /// </summary>
            understudy,

            /// <summary>
            ///     The sunwalker.
            /// </summary>
            sunwalker,

            /// <summary>
            ///     The nagamyrmidon.
            /// </summary>
            nagamyrmidon,

            /// <summary>
            ///     The destroyheropower.
            /// </summary>
            destroyheropower,

            /// <summary>
            ///     The skeletalsmith.
            /// </summary>
            skeletalsmith,

            /// <summary>
            ///     The slam.
            /// </summary>
            slam,

            /// <summary>
            ///     The swordofjustice.
            /// </summary>
            swordofjustice,

            /// <summary>
            ///     The bounce.
            /// </summary>
            bounce,

            /// <summary>
            ///     The shadopanmonk.
            /// </summary>
            shadopanmonk,

            /// <summary>
            ///     The whirlwind.
            /// </summary>
            whirlwind,

            /// <summary>
            ///     The alexstrasza.
            /// </summary>
            alexstrasza,

            /// <summary>
            ///     The silence.
            /// </summary>
            silence,

            /// <summary>
            ///     The rexxar.
            /// </summary>
            rexxar,

            /// <summary>
            ///     The voidwalker.
            /// </summary>
            voidwalker,

            /// <summary>
            ///     The whelp.
            /// </summary>
            whelp,

            /// <summary>
            ///     The flamestrike.
            /// </summary>
            flamestrike,

            /// <summary>
            ///     The rivercrocolisk.
            /// </summary>
            rivercrocolisk,

            /// <summary>
            ///     The stormforgedaxe.
            /// </summary>
            stormforgedaxe,

            /// <summary>
            ///     The snake.
            /// </summary>
            snake,

            /// <summary>
            ///     The shotgunblast.
            /// </summary>
            shotgunblast,

            /// <summary>
            ///     The violetapprentice.
            /// </summary>
            violetapprentice,

            /// <summary>
            ///     The templeenforcer.
            /// </summary>
            templeenforcer,

            /// <summary>
            ///     The ashbringer.
            /// </summary>
            ashbringer,

            /// <summary>
            ///     The impmaster.
            /// </summary>
            impmaster,

            /// <summary>
            ///     The defender.
            /// </summary>
            defender,

            /// <summary>
            ///     The savageroar.
            /// </summary>
            savageroar,

            /// <summary>
            ///     The innervate.
            /// </summary>
            innervate,

            /// <summary>
            ///     The inferno.
            /// </summary>
            inferno,

            /// <summary>
            ///     The falloutslime.
            /// </summary>
            falloutslime,

            /// <summary>
            ///     The earthelemental.
            /// </summary>
            earthelemental,

            /// <summary>
            ///     The facelessmanipulator.
            /// </summary>
            facelessmanipulator,

            /// <summary>
            ///     The mindpocalypse.
            /// </summary>
            mindpocalypse,

            /// <summary>
            ///     The divinefavor.
            /// </summary>
            divinefavor,

            /// <summary>
            ///     The aibuddydestroyminions.
            /// </summary>
            aibuddydestroyminions,

            /// <summary>
            ///     The demolisher.
            /// </summary>
            demolisher,

            /// <summary>
            ///     The sunfuryprotector.
            /// </summary>
            sunfuryprotector,

            /// <summary>
            ///     The dustdevil.
            /// </summary>
            dustdevil,

            /// <summary>
            ///     The powerofthehorde.
            /// </summary>
            powerofthehorde,

            /// <summary>
            ///     The dancingswords.
            /// </summary>
            dancingswords,

            /// <summary>
            ///     The holylight.
            /// </summary>
            holylight,

            /// <summary>
            ///     The feralspirit.
            /// </summary>
            feralspirit,

            /// <summary>
            ///     The raidleader.
            /// </summary>
            raidleader,

            /// <summary>
            ///     The amaniberserker.
            /// </summary>
            amaniberserker,

            /// <summary>
            ///     The ironbarkprotector.
            /// </summary>
            ironbarkprotector,

            /// <summary>
            ///     The bearform.
            /// </summary>
            bearform,

            /// <summary>
            ///     The deathwing.
            /// </summary>
            deathwing,

            /// <summary>
            ///     The stormpikecommando.
            /// </summary>
            stormpikecommando,

            /// <summary>
            ///     The squire.
            /// </summary>
            squire,

            /// <summary>
            ///     The panther.
            /// </summary>
            panther,

            /// <summary>
            ///     The silverbackpatriarch.
            /// </summary>
            silverbackpatriarch,

            /// <summary>
            ///     The bobfitch.
            /// </summary>
            bobfitch,

            /// <summary>
            ///     The gladiatorslongbow.
            /// </summary>
            gladiatorslongbow,

            /// <summary>
            ///     The damage 1.
            /// </summary>
            damage1,
        }

        /// <summary>
        ///     The cardrace.
        /// </summary>
        public enum cardrace
        {
            /// <summary>
            ///     The invalid.
            /// </summary>
            INVALID,

            /// <summary>
            ///     The bloodelf.
            /// </summary>
            BLOODELF,

            /// <summary>
            ///     The draenei.
            /// </summary>
            DRAENEI,

            /// <summary>
            ///     The dwarf.
            /// </summary>
            DWARF,

            /// <summary>
            ///     The gnome.
            /// </summary>
            GNOME,

            /// <summary>
            ///     The goblin.
            /// </summary>
            GOBLIN,

            /// <summary>
            ///     The human.
            /// </summary>
            HUMAN,

            /// <summary>
            ///     The nightelf.
            /// </summary>
            NIGHTELF,

            /// <summary>
            ///     The orc.
            /// </summary>
            ORC,

            /// <summary>
            ///     The tauren.
            /// </summary>
            TAUREN,

            /// <summary>
            ///     The troll.
            /// </summary>
            TROLL,

            /// <summary>
            ///     The undead.
            /// </summary>
            UNDEAD,

            /// <summary>
            ///     The worgen.
            /// </summary>
            WORGEN,

            /// <summary>
            ///     The gobli n 2.
            /// </summary>
            GOBLIN2,

            /// <summary>
            ///     The murloc.
            /// </summary>
            MURLOC,

            /// <summary>
            ///     The demon.
            /// </summary>
            DEMON,

            /// <summary>
            ///     The scourge.
            /// </summary>
            SCOURGE,

            /// <summary>
            ///     The mechanical.
            /// </summary>
            MECHANICAL,

            /// <summary>
            ///     The elemental.
            /// </summary>
            ELEMENTAL,

            /// <summary>
            ///     The ogre.
            /// </summary>
            OGRE,

            /// <summary>
            ///     The pet.
            /// </summary>
            PET,

            /// <summary>
            ///     The totem.
            /// </summary>
            TOTEM,

            /// <summary>
            ///     The nerubian.
            /// </summary>
            NERUBIAN,

            /// <summary>
            ///     The pirate.
            /// </summary>
            PIRATE,

            /// <summary>
            ///     The dragon.
            /// </summary>
            DRAGON
        }

        /// <summary>
        ///     The cardtype.
        /// </summary>
        public enum cardtype
        {
            /// <summary>
            ///     The none.
            /// </summary>
            NONE,

            /// <summary>
            ///     The mob.
            /// </summary>
            MOB,

            /// <summary>
            ///     The spell.
            /// </summary>
            SPELL,

            /// <summary>
            ///     The weapon.
            /// </summary>
            WEAPON,

            /// <summary>
            ///     The heropwr.
            /// </summary>
            HEROPWR,

            /// <summary>
            ///     The enchantment.
            /// </summary>
            ENCHANTMENT,
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        public static CardDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardDB();

                    // instance.enumCreator();// only call this to get latest cardids
                    /*foreach (KeyValuePair<cardIDEnum, Card> kvp in instance.cardidToCardList)
                    {
                        Helpfunctions.Instance.logg(kvp.Value.name + " " + kvp.Value.Attack);
                    }*/
                    // have to do it 2 times (or the kids inside the simcards will not have a simcard :D
                    foreach (Card c in instance.cardlist)
                    {
                        c.sim_card = instance.getSimCard(c.cardIDenum);
                    }

                    instance.setAdditionalData();
                }

                return instance;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The card idstring to enum.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="cardIDEnum"/>.
        /// </returns>
        public cardIDEnum cardIdstringToEnum(string s)
        {
            switch (s)
            {
                case "XXX_040":
                    return cardIDEnum.XXX_040;
                case "NAX5_01H":
                    return cardIDEnum.NAX5_01H;
                case "CS2_188o":
                    return cardIDEnum.CS2_188o;
                case "NAX6_02H":
                    return cardIDEnum.NAX6_02H;
                case "NEW1_007b":
                    return cardIDEnum.NEW1_007b;
                case "NAX6_02e":
                    return cardIDEnum.NAX6_02e;
                case "TU4c_003":
                    return cardIDEnum.TU4c_003;
                case "XXX_024":
                    return cardIDEnum.XXX_024;
                case "EX1_613":
                    return cardIDEnum.EX1_613;
                case "NAX8_01":
                    return cardIDEnum.NAX8_01;
                case "EX1_295o":
                    return cardIDEnum.EX1_295o;
                case "CS2_059o":
                    return cardIDEnum.CS2_059o;
                case "EX1_133":
                    return cardIDEnum.EX1_133;
                case "NEW1_018":
                    return cardIDEnum.NEW1_018;
                case "NAX15_03t":
                    return cardIDEnum.NAX15_03t;
                case "EX1_012":
                    return cardIDEnum.EX1_012;
                case "EX1_178a":
                    return cardIDEnum.EX1_178a;
                case "CS2_231":
                    return cardIDEnum.CS2_231;
                case "EX1_019e":
                    return cardIDEnum.EX1_019e;
                case "CRED_12":
                    return cardIDEnum.CRED_12;
                case "CS2_179":
                    return cardIDEnum.CS2_179;
                case "CS2_045e":
                    return cardIDEnum.CS2_045e;
                case "EX1_244":
                    return cardIDEnum.EX1_244;
                case "EX1_178b":
                    return cardIDEnum.EX1_178b;
                case "XXX_030":
                    return cardIDEnum.XXX_030;
                case "NAX8_05":
                    return cardIDEnum.NAX8_05;
                case "EX1_573b":
                    return cardIDEnum.EX1_573b;
                case "TU4d_001":
                    return cardIDEnum.TU4d_001;
                case "NEW1_007a":
                    return cardIDEnum.NEW1_007a;
                case "NAX12_02H":
                    return cardIDEnum.NAX12_02H;
                case "EX1_345t":
                    return cardIDEnum.EX1_345t;
                case "FP1_007t":
                    return cardIDEnum.FP1_007t;
                case "EX1_025":
                    return cardIDEnum.EX1_025;
                case "EX1_396":
                    return cardIDEnum.EX1_396;
                case "NAX9_03":
                    return cardIDEnum.NAX9_03;
                case "NEW1_017":
                    return cardIDEnum.NEW1_017;
                case "NEW1_008a":
                    return cardIDEnum.NEW1_008a;
                case "EX1_587e":
                    return cardIDEnum.EX1_587e;
                case "EX1_533":
                    return cardIDEnum.EX1_533;
                case "EX1_522":
                    return cardIDEnum.EX1_522;
                case "NAX11_04":
                    return cardIDEnum.NAX11_04;
                case "NEW1_026":
                    return cardIDEnum.NEW1_026;
                case "EX1_398":
                    return cardIDEnum.EX1_398;
                case "NAX4_04":
                    return cardIDEnum.NAX4_04;
                case "EX1_007":
                    return cardIDEnum.EX1_007;
                case "CS1_112":
                    return cardIDEnum.CS1_112;
                case "CRED_17":
                    return cardIDEnum.CRED_17;
                case "NEW1_036":
                    return cardIDEnum.NEW1_036;
                case "NAX3_03":
                    return cardIDEnum.NAX3_03;
                case "EX1_355e":
                    return cardIDEnum.EX1_355e;
                case "EX1_258":
                    return cardIDEnum.EX1_258;
                case "HERO_01":
                    return cardIDEnum.HERO_01;
                case "XXX_009":
                    return cardIDEnum.XXX_009;
                case "NAX6_01H":
                    return cardIDEnum.NAX6_01H;
                case "NAX12_04e":
                    return cardIDEnum.NAX12_04e;
                case "CS2_087":
                    return cardIDEnum.CS2_087;
                case "DREAM_05":
                    return cardIDEnum.DREAM_05;
                case "NEW1_036e":
                    return cardIDEnum.NEW1_036e;
                case "CS2_092":
                    return cardIDEnum.CS2_092;
                case "CS2_022":
                    return cardIDEnum.CS2_022;
                case "EX1_046":
                    return cardIDEnum.EX1_046;
                case "XXX_005":
                    return cardIDEnum.XXX_005;
                case "PRO_001b":
                    return cardIDEnum.PRO_001b;
                case "XXX_022":
                    return cardIDEnum.XXX_022;
                case "PRO_001a":
                    return cardIDEnum.PRO_001a;
                case "NAX6_04":
                    return cardIDEnum.NAX6_04;
                case "NAX7_05":
                    return cardIDEnum.NAX7_05;
                case "CS2_103":
                    return cardIDEnum.CS2_103;
                case "NEW1_041":
                    return cardIDEnum.NEW1_041;
                case "EX1_360":
                    return cardIDEnum.EX1_360;
                case "FP1_023":
                    return cardIDEnum.FP1_023;
                case "NEW1_038":
                    return cardIDEnum.NEW1_038;
                case "CS2_009":
                    return cardIDEnum.CS2_009;
                case "NAX10_01H":
                    return cardIDEnum.NAX10_01H;
                case "EX1_010":
                    return cardIDEnum.EX1_010;
                case "CS2_024":
                    return cardIDEnum.CS2_024;
                case "NAX9_05":
                    return cardIDEnum.NAX9_05;
                case "EX1_565":
                    return cardIDEnum.EX1_565;
                case "CS2_076":
                    return cardIDEnum.CS2_076;
                case "FP1_004":
                    return cardIDEnum.FP1_004;
                case "CS2_046e":
                    return cardIDEnum.CS2_046e;
                case "CS2_162":
                    return cardIDEnum.CS2_162;
                case "EX1_110t":
                    return cardIDEnum.EX1_110t;
                case "CS2_104e":
                    return cardIDEnum.CS2_104e;
                case "CS2_181":
                    return cardIDEnum.CS2_181;
                case "EX1_309":
                    return cardIDEnum.EX1_309;
                case "EX1_354":
                    return cardIDEnum.EX1_354;
                case "NAX10_02H":
                    return cardIDEnum.NAX10_02H;
                case "NAX7_04H":
                    return cardIDEnum.NAX7_04H;
                case "TU4f_001":
                    return cardIDEnum.TU4f_001;
                case "XXX_018":
                    return cardIDEnum.XXX_018;
                case "EX1_023":
                    return cardIDEnum.EX1_023;
                case "XXX_048":
                    return cardIDEnum.XXX_048;
                case "XXX_049":
                    return cardIDEnum.XXX_049;
                case "NEW1_034":
                    return cardIDEnum.NEW1_034;
                case "CS2_003":
                    return cardIDEnum.CS2_003;
                case "HERO_06":
                    return cardIDEnum.HERO_06;
                case "CS2_201":
                    return cardIDEnum.CS2_201;
                case "EX1_508":
                    return cardIDEnum.EX1_508;
                case "EX1_259":
                    return cardIDEnum.EX1_259;
                case "EX1_341":
                    return cardIDEnum.EX1_341;
                case "DREAM_05e":
                    return cardIDEnum.DREAM_05e;
                case "CRED_09":
                    return cardIDEnum.CRED_09;
                case "EX1_103":
                    return cardIDEnum.EX1_103;
                case "FP1_021":
                    return cardIDEnum.FP1_021;
                case "EX1_411":
                    return cardIDEnum.EX1_411;
                case "NAX1_04":
                    return cardIDEnum.NAX1_04;
                case "CS2_053":
                    return cardIDEnum.CS2_053;
                case "CS2_182":
                    return cardIDEnum.CS2_182;
                case "CS2_008":
                    return cardIDEnum.CS2_008;
                case "CS2_233":
                    return cardIDEnum.CS2_233;
                case "EX1_626":
                    return cardIDEnum.EX1_626;
                case "EX1_059":
                    return cardIDEnum.EX1_059;
                case "EX1_334":
                    return cardIDEnum.EX1_334;
                case "EX1_619":
                    return cardIDEnum.EX1_619;
                case "NEW1_032":
                    return cardIDEnum.NEW1_032;
                case "EX1_158t":
                    return cardIDEnum.EX1_158t;
                case "EX1_006":
                    return cardIDEnum.EX1_006;
                case "NEW1_031":
                    return cardIDEnum.NEW1_031;
                case "NAX10_03":
                    return cardIDEnum.NAX10_03;
                case "DREAM_04":
                    return cardIDEnum.DREAM_04;
                case "NAX1h_01":
                    return cardIDEnum.NAX1h_01;
                case "CS2_022e":
                    return cardIDEnum.CS2_022e;
                case "EX1_611e":
                    return cardIDEnum.EX1_611e;
                case "EX1_004":
                    return cardIDEnum.EX1_004;
                case "EX1_014te":
                    return cardIDEnum.EX1_014te;
                case "FP1_005e":
                    return cardIDEnum.FP1_005e;
                case "NAX12_03e":
                    return cardIDEnum.NAX12_03e;
                case "EX1_095":
                    return cardIDEnum.EX1_095;
                case "NEW1_007":
                    return cardIDEnum.NEW1_007;
                case "EX1_275":
                    return cardIDEnum.EX1_275;
                case "EX1_245":
                    return cardIDEnum.EX1_245;
                case "EX1_383":
                    return cardIDEnum.EX1_383;
                case "FP1_016":
                    return cardIDEnum.FP1_016;
                case "EX1_016t":
                    return cardIDEnum.EX1_016t;
                case "CS2_125":
                    return cardIDEnum.CS2_125;
                case "EX1_137":
                    return cardIDEnum.EX1_137;
                case "EX1_178ae":
                    return cardIDEnum.EX1_178ae;
                case "DS1_185":
                    return cardIDEnum.DS1_185;
                case "FP1_010":
                    return cardIDEnum.FP1_010;
                case "EX1_598":
                    return cardIDEnum.EX1_598;
                case "NAX9_07":
                    return cardIDEnum.NAX9_07;
                case "EX1_304":
                    return cardIDEnum.EX1_304;
                case "EX1_302":
                    return cardIDEnum.EX1_302;
                case "XXX_017":
                    return cardIDEnum.XXX_017;
                case "CS2_011o":
                    return cardIDEnum.CS2_011o;
                case "EX1_614t":
                    return cardIDEnum.EX1_614t;
                case "TU4a_006":
                    return cardIDEnum.TU4a_006;
                case "Mekka3e":
                    return cardIDEnum.Mekka3e;
                case "CS2_108":
                    return cardIDEnum.CS2_108;
                case "CS2_046":
                    return cardIDEnum.CS2_046;
                case "EX1_014t":
                    return cardIDEnum.EX1_014t;
                case "NEW1_005":
                    return cardIDEnum.NEW1_005;
                case "EX1_062":
                    return cardIDEnum.EX1_062;
                case "EX1_366e":
                    return cardIDEnum.EX1_366e;
                case "Mekka1":
                    return cardIDEnum.Mekka1;
                case "XXX_007":
                    return cardIDEnum.XXX_007;
                case "tt_010a":
                    return cardIDEnum.tt_010a;
                case "CS2_017o":
                    return cardIDEnum.CS2_017o;
                case "CS2_072":
                    return cardIDEnum.CS2_072;
                case "EX1_tk28":
                    return cardIDEnum.EX1_tk28;
                case "EX1_604o":
                    return cardIDEnum.EX1_604o;
                case "FP1_014":
                    return cardIDEnum.FP1_014;
                case "EX1_084e":
                    return cardIDEnum.EX1_084e;
                case "NAX3_01H":
                    return cardIDEnum.NAX3_01H;
                case "NAX2_01":
                    return cardIDEnum.NAX2_01;
                case "EX1_409t":
                    return cardIDEnum.EX1_409t;
                case "CRED_07":
                    return cardIDEnum.CRED_07;
                case "NAX3_02H":
                    return cardIDEnum.NAX3_02H;
                case "TU4e_002":
                    return cardIDEnum.TU4e_002;
                case "EX1_507":
                    return cardIDEnum.EX1_507;
                case "EX1_144":
                    return cardIDEnum.EX1_144;
                case "CS2_038":
                    return cardIDEnum.CS2_038;
                case "EX1_093":
                    return cardIDEnum.EX1_093;
                case "CS2_080":
                    return cardIDEnum.CS2_080;
                case "CS1_129e":
                    return cardIDEnum.CS1_129e;
                case "XXX_013":
                    return cardIDEnum.XXX_013;
                case "EX1_005":
                    return cardIDEnum.EX1_005;
                case "EX1_382":
                    return cardIDEnum.EX1_382;
                case "NAX13_02e":
                    return cardIDEnum.NAX13_02e;
                case "FP1_020e":
                    return cardIDEnum.FP1_020e;
                case "EX1_603e":
                    return cardIDEnum.EX1_603e;
                case "CS2_028":
                    return cardIDEnum.CS2_028;
                case "TU4f_002":
                    return cardIDEnum.TU4f_002;
                case "EX1_538":
                    return cardIDEnum.EX1_538;
                case "GAME_003e":
                    return cardIDEnum.GAME_003e;
                case "DREAM_02":
                    return cardIDEnum.DREAM_02;
                case "EX1_581":
                    return cardIDEnum.EX1_581;
                case "NAX15_01H":
                    return cardIDEnum.NAX15_01H;
                case "EX1_131t":
                    return cardIDEnum.EX1_131t;
                case "CS2_147":
                    return cardIDEnum.CS2_147;
                case "CS1_113":
                    return cardIDEnum.CS1_113;
                case "CS2_161":
                    return cardIDEnum.CS2_161;
                case "CS2_031":
                    return cardIDEnum.CS2_031;
                case "EX1_166b":
                    return cardIDEnum.EX1_166b;
                case "EX1_066":
                    return cardIDEnum.EX1_066;
                case "TU4c_007":
                    return cardIDEnum.TU4c_007;
                case "EX1_355":
                    return cardIDEnum.EX1_355;
                case "EX1_507e":
                    return cardIDEnum.EX1_507e;
                case "EX1_534":
                    return cardIDEnum.EX1_534;
                case "EX1_162":
                    return cardIDEnum.EX1_162;
                case "TU4a_004":
                    return cardIDEnum.TU4a_004;
                case "EX1_363":
                    return cardIDEnum.EX1_363;
                case "EX1_164a":
                    return cardIDEnum.EX1_164a;
                case "CS2_188":
                    return cardIDEnum.CS2_188;
                case "EX1_016":
                    return cardIDEnum.EX1_016;
                case "NAX6_03t":
                    return cardIDEnum.NAX6_03t;
                case "EX1_tk31":
                    return cardIDEnum.EX1_tk31;
                case "EX1_603":
                    return cardIDEnum.EX1_603;
                case "EX1_238":
                    return cardIDEnum.EX1_238;
                case "EX1_166":
                    return cardIDEnum.EX1_166;
                case "DS1h_292":
                    return cardIDEnum.DS1h_292;
                case "DS1_183":
                    return cardIDEnum.DS1_183;
                case "NAX15_03n":
                    return cardIDEnum.NAX15_03n;
                case "NAX8_02H":
                    return cardIDEnum.NAX8_02H;
                case "NAX7_01H":
                    return cardIDEnum.NAX7_01H;
                case "NAX9_02H":
                    return cardIDEnum.NAX9_02H;
                case "CRED_11":
                    return cardIDEnum.CRED_11;
                case "XXX_019":
                    return cardIDEnum.XXX_019;
                case "EX1_076":
                    return cardIDEnum.EX1_076;
                case "EX1_048":
                    return cardIDEnum.EX1_048;
                case "CS2_038e":
                    return cardIDEnum.CS2_038e;
                case "FP1_026":
                    return cardIDEnum.FP1_026;
                case "CS2_074":
                    return cardIDEnum.CS2_074;
                case "FP1_027":
                    return cardIDEnum.FP1_027;
                case "EX1_323w":
                    return cardIDEnum.EX1_323w;
                case "EX1_129":
                    return cardIDEnum.EX1_129;
                case "NEW1_024o":
                    return cardIDEnum.NEW1_024o;
                case "NAX11_02":
                    return cardIDEnum.NAX11_02;
                case "EX1_405":
                    return cardIDEnum.EX1_405;
                case "EX1_317":
                    return cardIDEnum.EX1_317;
                case "EX1_606":
                    return cardIDEnum.EX1_606;
                case "EX1_590e":
                    return cardIDEnum.EX1_590e;
                case "XXX_044":
                    return cardIDEnum.XXX_044;
                case "CS2_074e":
                    return cardIDEnum.CS2_074e;
                case "TU4a_005":
                    return cardIDEnum.TU4a_005;
                case "FP1_006":
                    return cardIDEnum.FP1_006;
                case "EX1_258e":
                    return cardIDEnum.EX1_258e;
                case "TU4f_004o":
                    return cardIDEnum.TU4f_004o;
                case "NEW1_008":
                    return cardIDEnum.NEW1_008;
                case "CS2_119":
                    return cardIDEnum.CS2_119;
                case "NEW1_017e":
                    return cardIDEnum.NEW1_017e;
                case "EX1_334e":
                    return cardIDEnum.EX1_334e;
                case "TU4e_001":
                    return cardIDEnum.TU4e_001;
                case "CS2_121":
                    return cardIDEnum.CS2_121;
                case "CS1h_001":
                    return cardIDEnum.CS1h_001;
                case "EX1_tk34":
                    return cardIDEnum.EX1_tk34;
                case "NEW1_020":
                    return cardIDEnum.NEW1_020;
                case "CS2_196":
                    return cardIDEnum.CS2_196;
                case "EX1_312":
                    return cardIDEnum.EX1_312;
                case "NAX1_01":
                    return cardIDEnum.NAX1_01;
                case "FP1_022":
                    return cardIDEnum.FP1_022;
                case "EX1_160b":
                    return cardIDEnum.EX1_160b;
                case "EX1_563":
                    return cardIDEnum.EX1_563;
                case "XXX_039":
                    return cardIDEnum.XXX_039;
                case "FP1_031":
                    return cardIDEnum.FP1_031;
                case "CS2_087e":
                    return cardIDEnum.CS2_087e;
                case "EX1_613e":
                    return cardIDEnum.EX1_613e;
                case "NAX9_02":
                    return cardIDEnum.NAX9_02;
                case "NEW1_029":
                    return cardIDEnum.NEW1_029;
                case "CS1_129":
                    return cardIDEnum.CS1_129;
                case "HERO_03":
                    return cardIDEnum.HERO_03;
                case "Mekka4t":
                    return cardIDEnum.Mekka4t;
                case "EX1_158":
                    return cardIDEnum.EX1_158;
                case "XXX_010":
                    return cardIDEnum.XXX_010;
                case "NEW1_025":
                    return cardIDEnum.NEW1_025;
                case "FP1_012t":
                    return cardIDEnum.FP1_012t;
                case "EX1_083":
                    return cardIDEnum.EX1_083;
                case "EX1_295":
                    return cardIDEnum.EX1_295;
                case "EX1_407":
                    return cardIDEnum.EX1_407;
                case "NEW1_004":
                    return cardIDEnum.NEW1_004;
                case "FP1_019":
                    return cardIDEnum.FP1_019;
                case "PRO_001at":
                    return cardIDEnum.PRO_001at;
                case "NAX13_03e":
                    return cardIDEnum.NAX13_03e;
                case "EX1_625t":
                    return cardIDEnum.EX1_625t;
                case "EX1_014":
                    return cardIDEnum.EX1_014;
                case "CRED_04":
                    return cardIDEnum.CRED_04;
                case "NAX12_01H":
                    return cardIDEnum.NAX12_01H;
                case "CS2_097":
                    return cardIDEnum.CS2_097;
                case "EX1_558":
                    return cardIDEnum.EX1_558;
                case "XXX_047":
                    return cardIDEnum.XXX_047;
                case "EX1_tk29":
                    return cardIDEnum.EX1_tk29;
                case "CS2_186":
                    return cardIDEnum.CS2_186;
                case "EX1_084":
                    return cardIDEnum.EX1_084;
                case "NEW1_012":
                    return cardIDEnum.NEW1_012;
                case "FP1_014t":
                    return cardIDEnum.FP1_014t;
                case "NAX1_03":
                    return cardIDEnum.NAX1_03;
                case "EX1_623e":
                    return cardIDEnum.EX1_623e;
                case "EX1_578":
                    return cardIDEnum.EX1_578;
                case "CS2_073e2":
                    return cardIDEnum.CS2_073e2;
                case "CS2_221":
                    return cardIDEnum.CS2_221;
                case "EX1_019":
                    return cardIDEnum.EX1_019;
                case "NAX15_04a":
                    return cardIDEnum.NAX15_04a;
                case "FP1_019t":
                    return cardIDEnum.FP1_019t;
                case "EX1_132":
                    return cardIDEnum.EX1_132;
                case "EX1_284":
                    return cardIDEnum.EX1_284;
                case "EX1_105":
                    return cardIDEnum.EX1_105;
                case "NEW1_011":
                    return cardIDEnum.NEW1_011;
                case "NAX9_07e":
                    return cardIDEnum.NAX9_07e;
                case "EX1_017":
                    return cardIDEnum.EX1_017;
                case "EX1_249":
                    return cardIDEnum.EX1_249;
                case "EX1_162o":
                    return cardIDEnum.EX1_162o;
                case "FP1_002t":
                    return cardIDEnum.FP1_002t;
                case "NAX3_02":
                    return cardIDEnum.NAX3_02;
                case "EX1_313":
                    return cardIDEnum.EX1_313;
                case "EX1_549o":
                    return cardIDEnum.EX1_549o;
                case "EX1_091o":
                    return cardIDEnum.EX1_091o;
                case "CS2_084e":
                    return cardIDEnum.CS2_084e;
                case "EX1_155b":
                    return cardIDEnum.EX1_155b;
                case "NAX11_01":
                    return cardIDEnum.NAX11_01;
                case "NEW1_033":
                    return cardIDEnum.NEW1_033;
                case "CS2_106":
                    return cardIDEnum.CS2_106;
                case "XXX_002":
                    return cardIDEnum.XXX_002;
                case "FP1_018":
                    return cardIDEnum.FP1_018;
                case "NEW1_036e2":
                    return cardIDEnum.NEW1_036e2;
                case "XXX_004":
                    return cardIDEnum.XXX_004;
                case "NAX11_02H":
                    return cardIDEnum.NAX11_02H;
                case "CS2_122e":
                    return cardIDEnum.CS2_122e;
                case "DS1_233":
                    return cardIDEnum.DS1_233;
                case "DS1_175":
                    return cardIDEnum.DS1_175;
                case "NEW1_024":
                    return cardIDEnum.NEW1_024;
                case "CS2_189":
                    return cardIDEnum.CS2_189;
                case "CRED_10":
                    return cardIDEnum.CRED_10;
                case "NEW1_037":
                    return cardIDEnum.NEW1_037;
                case "EX1_414":
                    return cardIDEnum.EX1_414;
                case "EX1_538t":
                    return cardIDEnum.EX1_538t;
                case "FP1_030e":
                    return cardIDEnum.FP1_030e;
                case "EX1_586":
                    return cardIDEnum.EX1_586;
                case "EX1_310":
                    return cardIDEnum.EX1_310;
                case "NEW1_010":
                    return cardIDEnum.NEW1_010;
                case "CS2_103e":
                    return cardIDEnum.CS2_103e;
                case "EX1_080o":
                    return cardIDEnum.EX1_080o;
                case "CS2_005o":
                    return cardIDEnum.CS2_005o;
                case "EX1_363e2":
                    return cardIDEnum.EX1_363e2;
                case "EX1_534t":
                    return cardIDEnum.EX1_534t;
                case "FP1_028":
                    return cardIDEnum.FP1_028;
                case "EX1_604":
                    return cardIDEnum.EX1_604;
                case "EX1_160":
                    return cardIDEnum.EX1_160;
                case "EX1_165t1":
                    return cardIDEnum.EX1_165t1;
                case "CS2_062":
                    return cardIDEnum.CS2_062;
                case "CS2_155":
                    return cardIDEnum.CS2_155;
                case "CS2_213":
                    return cardIDEnum.CS2_213;
                case "TU4f_007":
                    return cardIDEnum.TU4f_007;
                case "GAME_004":
                    return cardIDEnum.GAME_004;
                case "NAX5_01":
                    return cardIDEnum.NAX5_01;
                case "XXX_020":
                    return cardIDEnum.XXX_020;
                case "NAX15_02H":
                    return cardIDEnum.NAX15_02H;
                case "CS2_004":
                    return cardIDEnum.CS2_004;
                case "NAX2_03H":
                    return cardIDEnum.NAX2_03H;
                case "EX1_561e":
                    return cardIDEnum.EX1_561e;
                case "CS2_023":
                    return cardIDEnum.CS2_023;
                case "EX1_164":
                    return cardIDEnum.EX1_164;
                case "EX1_009":
                    return cardIDEnum.EX1_009;
                case "NAX6_01":
                    return cardIDEnum.NAX6_01;
                case "FP1_007":
                    return cardIDEnum.FP1_007;
                case "NAX1h_04":
                    return cardIDEnum.NAX1h_04;
                case "NAX2_05H":
                    return cardIDEnum.NAX2_05H;
                case "NAX10_02":
                    return cardIDEnum.NAX10_02;
                case "EX1_345":
                    return cardIDEnum.EX1_345;
                case "EX1_116":
                    return cardIDEnum.EX1_116;
                case "EX1_399":
                    return cardIDEnum.EX1_399;
                case "EX1_587":
                    return cardIDEnum.EX1_587;
                case "XXX_026":
                    return cardIDEnum.XXX_026;
                case "EX1_571":
                    return cardIDEnum.EX1_571;
                case "EX1_335":
                    return cardIDEnum.EX1_335;
                case "XXX_050":
                    return cardIDEnum.XXX_050;
                case "TU4e_004":
                    return cardIDEnum.TU4e_004;
                case "HERO_08":
                    return cardIDEnum.HERO_08;
                case "EX1_166a":
                    return cardIDEnum.EX1_166a;
                case "NAX2_03":
                    return cardIDEnum.NAX2_03;
                case "EX1_finkle":
                    return cardIDEnum.EX1_finkle;
                case "NAX4_03H":
                    return cardIDEnum.NAX4_03H;
                case "EX1_164b":
                    return cardIDEnum.EX1_164b;
                case "EX1_283":
                    return cardIDEnum.EX1_283;
                case "EX1_339":
                    return cardIDEnum.EX1_339;
                case "CRED_13":
                    return cardIDEnum.CRED_13;
                case "EX1_178be":
                    return cardIDEnum.EX1_178be;
                case "EX1_531":
                    return cardIDEnum.EX1_531;
                case "EX1_134":
                    return cardIDEnum.EX1_134;
                case "EX1_350":
                    return cardIDEnum.EX1_350;
                case "EX1_308":
                    return cardIDEnum.EX1_308;
                case "CS2_197":
                    return cardIDEnum.CS2_197;
                case "skele21":
                    return cardIDEnum.skele21;
                case "CS2_222o":
                    return cardIDEnum.CS2_222o;
                case "XXX_015":
                    return cardIDEnum.XXX_015;
                case "FP1_013":
                    return cardIDEnum.FP1_013;
                case "NEW1_006":
                    return cardIDEnum.NEW1_006;
                case "EX1_399e":
                    return cardIDEnum.EX1_399e;
                case "EX1_509":
                    return cardIDEnum.EX1_509;
                case "EX1_612":
                    return cardIDEnum.EX1_612;
                case "NAX8_05t":
                    return cardIDEnum.NAX8_05t;
                case "NAX9_05H":
                    return cardIDEnum.NAX9_05H;
                case "EX1_021":
                    return cardIDEnum.EX1_021;
                case "CS2_041e":
                    return cardIDEnum.CS2_041e;
                case "CS2_226":
                    return cardIDEnum.CS2_226;
                case "EX1_608":
                    return cardIDEnum.EX1_608;
                case "NAX13_05H":
                    return cardIDEnum.NAX13_05H;
                case "NAX13_04H":
                    return cardIDEnum.NAX13_04H;
                case "TU4c_008":
                    return cardIDEnum.TU4c_008;
                case "EX1_624":
                    return cardIDEnum.EX1_624;
                case "EX1_616":
                    return cardIDEnum.EX1_616;
                case "EX1_008":
                    return cardIDEnum.EX1_008;
                case "PlaceholderCard":
                    return cardIDEnum.PlaceholderCard;
                case "XXX_016":
                    return cardIDEnum.XXX_016;
                case "EX1_045":
                    return cardIDEnum.EX1_045;
                case "EX1_015":
                    return cardIDEnum.EX1_015;
                case "GAME_003":
                    return cardIDEnum.GAME_003;
                case "CS2_171":
                    return cardIDEnum.CS2_171;
                case "CS2_041":
                    return cardIDEnum.CS2_041;
                case "EX1_128":
                    return cardIDEnum.EX1_128;
                case "CS2_112":
                    return cardIDEnum.CS2_112;
                case "HERO_07":
                    return cardIDEnum.HERO_07;
                case "EX1_412":
                    return cardIDEnum.EX1_412;
                case "EX1_612o":
                    return cardIDEnum.EX1_612o;
                case "CS2_117":
                    return cardIDEnum.CS2_117;
                case "XXX_009e":
                    return cardIDEnum.XXX_009e;
                case "EX1_562":
                    return cardIDEnum.EX1_562;
                case "EX1_055":
                    return cardIDEnum.EX1_055;
                case "NAX9_06":
                    return cardIDEnum.NAX9_06;
                case "TU4e_007":
                    return cardIDEnum.TU4e_007;
                case "FP1_012":
                    return cardIDEnum.FP1_012;
                case "EX1_317t":
                    return cardIDEnum.EX1_317t;
                case "EX1_004e":
                    return cardIDEnum.EX1_004e;
                case "EX1_278":
                    return cardIDEnum.EX1_278;
                case "CS2_tk1":
                    return cardIDEnum.CS2_tk1;
                case "EX1_590":
                    return cardIDEnum.EX1_590;
                case "CS1_130":
                    return cardIDEnum.CS1_130;
                case "NEW1_008b":
                    return cardIDEnum.NEW1_008b;
                case "EX1_365":
                    return cardIDEnum.EX1_365;
                case "CS2_141":
                    return cardIDEnum.CS2_141;
                case "PRO_001":
                    return cardIDEnum.PRO_001;
                case "NAX8_04t":
                    return cardIDEnum.NAX8_04t;
                case "CS2_173":
                    return cardIDEnum.CS2_173;
                case "CS2_017":
                    return cardIDEnum.CS2_017;
                case "CRED_16":
                    return cardIDEnum.CRED_16;
                case "EX1_392":
                    return cardIDEnum.EX1_392;
                case "EX1_593":
                    return cardIDEnum.EX1_593;
                case "FP1_023e":
                    return cardIDEnum.FP1_023e;
                case "NAX1_05":
                    return cardIDEnum.NAX1_05;
                case "TU4d_002":
                    return cardIDEnum.TU4d_002;
                case "CRED_15":
                    return cardIDEnum.CRED_15;
                case "EX1_049":
                    return cardIDEnum.EX1_049;
                case "EX1_002":
                    return cardIDEnum.EX1_002;
                case "TU4f_005":
                    return cardIDEnum.TU4f_005;
                case "NEW1_029t":
                    return cardIDEnum.NEW1_029t;
                case "TU4a_001":
                    return cardIDEnum.TU4a_001;
                case "CS2_056":
                    return cardIDEnum.CS2_056;
                case "EX1_596":
                    return cardIDEnum.EX1_596;
                case "EX1_136":
                    return cardIDEnum.EX1_136;
                case "EX1_323":
                    return cardIDEnum.EX1_323;
                case "CS2_073":
                    return cardIDEnum.CS2_073;
                case "EX1_246e":
                    return cardIDEnum.EX1_246e;
                case "NAX12_01":
                    return cardIDEnum.NAX12_01;
                case "EX1_244e":
                    return cardIDEnum.EX1_244e;
                case "EX1_001":
                    return cardIDEnum.EX1_001;
                case "EX1_607e":
                    return cardIDEnum.EX1_607e;
                case "EX1_044":
                    return cardIDEnum.EX1_044;
                case "EX1_573ae":
                    return cardIDEnum.EX1_573ae;
                case "XXX_025":
                    return cardIDEnum.XXX_025;
                case "CRED_06":
                    return cardIDEnum.CRED_06;
                case "Mekka4":
                    return cardIDEnum.Mekka4;
                case "CS2_142":
                    return cardIDEnum.CS2_142;
                case "TU4f_004":
                    return cardIDEnum.TU4f_004;
                case "NAX5_02H":
                    return cardIDEnum.NAX5_02H;
                case "EX1_411e2":
                    return cardIDEnum.EX1_411e2;
                case "EX1_573":
                    return cardIDEnum.EX1_573;
                case "FP1_009":
                    return cardIDEnum.FP1_009;
                case "CS2_050":
                    return cardIDEnum.CS2_050;
                case "NAX4_03":
                    return cardIDEnum.NAX4_03;
                case "CS2_063e":
                    return cardIDEnum.CS2_063e;
                case "NAX2_05":
                    return cardIDEnum.NAX2_05;
                case "EX1_390":
                    return cardIDEnum.EX1_390;
                case "EX1_610":
                    return cardIDEnum.EX1_610;
                case "hexfrog":
                    return cardIDEnum.hexfrog;
                case "CS2_181e":
                    return cardIDEnum.CS2_181e;
                case "NAX6_02":
                    return cardIDEnum.NAX6_02;
                case "XXX_027":
                    return cardIDEnum.XXX_027;
                case "CS2_082":
                    return cardIDEnum.CS2_082;
                case "NEW1_040":
                    return cardIDEnum.NEW1_040;
                case "DREAM_01":
                    return cardIDEnum.DREAM_01;
                case "EX1_595":
                    return cardIDEnum.EX1_595;
                case "CS2_013":
                    return cardIDEnum.CS2_013;
                case "CS2_077":
                    return cardIDEnum.CS2_077;
                case "NEW1_014":
                    return cardIDEnum.NEW1_014;
                case "CRED_05":
                    return cardIDEnum.CRED_05;
                case "GAME_002":
                    return cardIDEnum.GAME_002;
                case "EX1_165":
                    return cardIDEnum.EX1_165;
                case "CS2_013t":
                    return cardIDEnum.CS2_013t;
                case "NAX4_04H":
                    return cardIDEnum.NAX4_04H;
                case "EX1_tk11":
                    return cardIDEnum.EX1_tk11;
                case "EX1_591":
                    return cardIDEnum.EX1_591;
                case "EX1_549":
                    return cardIDEnum.EX1_549;
                case "CS2_045":
                    return cardIDEnum.CS2_045;
                case "CS2_237":
                    return cardIDEnum.CS2_237;
                case "CS2_027":
                    return cardIDEnum.CS2_027;
                case "EX1_508o":
                    return cardIDEnum.EX1_508o;
                case "NAX14_03":
                    return cardIDEnum.NAX14_03;
                case "CS2_101t":
                    return cardIDEnum.CS2_101t;
                case "CS2_063":
                    return cardIDEnum.CS2_063;
                case "EX1_145":
                    return cardIDEnum.EX1_145;
                case "NAX1h_03":
                    return cardIDEnum.NAX1h_03;
                case "EX1_110":
                    return cardIDEnum.EX1_110;
                case "EX1_408":
                    return cardIDEnum.EX1_408;
                case "EX1_544":
                    return cardIDEnum.EX1_544;
                case "TU4c_006":
                    return cardIDEnum.TU4c_006;
                case "NAXM_001":
                    return cardIDEnum.NAXM_001;
                case "CS2_151":
                    return cardIDEnum.CS2_151;
                case "CS2_073e":
                    return cardIDEnum.CS2_073e;
                case "XXX_006":
                    return cardIDEnum.XXX_006;
                case "CS2_088":
                    return cardIDEnum.CS2_088;
                case "EX1_057":
                    return cardIDEnum.EX1_057;
                case "FP1_020":
                    return cardIDEnum.FP1_020;
                case "CS2_169":
                    return cardIDEnum.CS2_169;
                case "EX1_573t":
                    return cardIDEnum.EX1_573t;
                case "EX1_323h":
                    return cardIDEnum.EX1_323h;
                case "EX1_tk9":
                    return cardIDEnum.EX1_tk9;
                case "NEW1_018e":
                    return cardIDEnum.NEW1_018e;
                case "CS2_037":
                    return cardIDEnum.CS2_037;
                case "CS2_007":
                    return cardIDEnum.CS2_007;
                case "EX1_059e2":
                    return cardIDEnum.EX1_059e2;
                case "CS2_227":
                    return cardIDEnum.CS2_227;
                case "NAX7_03H":
                    return cardIDEnum.NAX7_03H;
                case "NAX9_01H":
                    return cardIDEnum.NAX9_01H;
                case "EX1_570e":
                    return cardIDEnum.EX1_570e;
                case "NEW1_003":
                    return cardIDEnum.NEW1_003;
                case "GAME_006":
                    return cardIDEnum.GAME_006;
                case "EX1_320":
                    return cardIDEnum.EX1_320;
                case "EX1_097":
                    return cardIDEnum.EX1_097;
                case "tt_004":
                    return cardIDEnum.tt_004;
                case "EX1_360e":
                    return cardIDEnum.EX1_360e;
                case "EX1_096":
                    return cardIDEnum.EX1_096;
                case "DS1_175o":
                    return cardIDEnum.DS1_175o;
                case "EX1_596e":
                    return cardIDEnum.EX1_596e;
                case "XXX_014":
                    return cardIDEnum.XXX_014;
                case "EX1_158e":
                    return cardIDEnum.EX1_158e;
                case "NAX14_01":
                    return cardIDEnum.NAX14_01;
                case "CRED_01":
                    return cardIDEnum.CRED_01;
                case "CRED_08":
                    return cardIDEnum.CRED_08;
                case "EX1_126":
                    return cardIDEnum.EX1_126;
                case "EX1_577":
                    return cardIDEnum.EX1_577;
                case "EX1_319":
                    return cardIDEnum.EX1_319;
                case "EX1_611":
                    return cardIDEnum.EX1_611;
                case "CS2_146":
                    return cardIDEnum.CS2_146;
                case "EX1_154b":
                    return cardIDEnum.EX1_154b;
                case "skele11":
                    return cardIDEnum.skele11;
                case "EX1_165t2":
                    return cardIDEnum.EX1_165t2;
                case "CS2_172":
                    return cardIDEnum.CS2_172;
                case "CS2_114":
                    return cardIDEnum.CS2_114;
                case "CS1_069":
                    return cardIDEnum.CS1_069;
                case "XXX_003":
                    return cardIDEnum.XXX_003;
                case "XXX_042":
                    return cardIDEnum.XXX_042;
                case "NAX8_02":
                    return cardIDEnum.NAX8_02;
                case "EX1_173":
                    return cardIDEnum.EX1_173;
                case "CS1_042":
                    return cardIDEnum.CS1_042;
                case "NAX8_03":
                    return cardIDEnum.NAX8_03;
                case "EX1_506a":
                    return cardIDEnum.EX1_506a;
                case "EX1_298":
                    return cardIDEnum.EX1_298;
                case "CS2_104":
                    return cardIDEnum.CS2_104;
                case "FP1_001":
                    return cardIDEnum.FP1_001;
                case "HERO_02":
                    return cardIDEnum.HERO_02;
                case "EX1_316e":
                    return cardIDEnum.EX1_316e;
                case "NAX7_01":
                    return cardIDEnum.NAX7_01;
                case "EX1_044e":
                    return cardIDEnum.EX1_044e;
                case "CS2_051":
                    return cardIDEnum.CS2_051;
                case "NEW1_016":
                    return cardIDEnum.NEW1_016;
                case "EX1_304e":
                    return cardIDEnum.EX1_304e;
                case "EX1_033":
                    return cardIDEnum.EX1_033;
                case "NAX8_04":
                    return cardIDEnum.NAX8_04;
                case "EX1_028":
                    return cardIDEnum.EX1_028;
                case "XXX_011":
                    return cardIDEnum.XXX_011;
                case "EX1_621":
                    return cardIDEnum.EX1_621;
                case "EX1_554":
                    return cardIDEnum.EX1_554;
                case "EX1_091":
                    return cardIDEnum.EX1_091;
                case "FP1_017":
                    return cardIDEnum.FP1_017;
                case "EX1_409":
                    return cardIDEnum.EX1_409;
                case "EX1_363e":
                    return cardIDEnum.EX1_363e;
                case "EX1_410":
                    return cardIDEnum.EX1_410;
                case "TU4e_005":
                    return cardIDEnum.TU4e_005;
                case "CS2_039":
                    return cardIDEnum.CS2_039;
                case "NAX12_04":
                    return cardIDEnum.NAX12_04;
                case "EX1_557":
                    return cardIDEnum.EX1_557;
                case "CS2_105e":
                    return cardIDEnum.CS2_105e;
                case "EX1_128e":
                    return cardIDEnum.EX1_128e;
                case "XXX_021":
                    return cardIDEnum.XXX_021;
                case "DS1_070":
                    return cardIDEnum.DS1_070;
                case "CS2_033":
                    return cardIDEnum.CS2_033;
                case "EX1_536":
                    return cardIDEnum.EX1_536;
                case "TU4a_003":
                    return cardIDEnum.TU4a_003;
                case "EX1_559":
                    return cardIDEnum.EX1_559;
                case "XXX_023":
                    return cardIDEnum.XXX_023;
                case "NEW1_033o":
                    return cardIDEnum.NEW1_033o;
                case "NAX15_04H":
                    return cardIDEnum.NAX15_04H;
                case "CS2_004e":
                    return cardIDEnum.CS2_004e;
                case "CS2_052":
                    return cardIDEnum.CS2_052;
                case "EX1_539":
                    return cardIDEnum.EX1_539;
                case "EX1_575":
                    return cardIDEnum.EX1_575;
                case "CS2_083b":
                    return cardIDEnum.CS2_083b;
                case "CS2_061":
                    return cardIDEnum.CS2_061;
                case "NEW1_021":
                    return cardIDEnum.NEW1_021;
                case "DS1_055":
                    return cardIDEnum.DS1_055;
                case "EX1_625":
                    return cardIDEnum.EX1_625;
                case "EX1_382e":
                    return cardIDEnum.EX1_382e;
                case "CS2_092e":
                    return cardIDEnum.CS2_092e;
                case "CS2_026":
                    return cardIDEnum.CS2_026;
                case "NAX14_04":
                    return cardIDEnum.NAX14_04;
                case "NEW1_012o":
                    return cardIDEnum.NEW1_012o;
                case "EX1_619e":
                    return cardIDEnum.EX1_619e;
                case "EX1_294":
                    return cardIDEnum.EX1_294;
                case "EX1_287":
                    return cardIDEnum.EX1_287;
                case "EX1_509e":
                    return cardIDEnum.EX1_509e;
                case "EX1_625t2":
                    return cardIDEnum.EX1_625t2;
                case "CS2_118":
                    return cardIDEnum.CS2_118;
                case "CS2_124":
                    return cardIDEnum.CS2_124;
                case "Mekka3":
                    return cardIDEnum.Mekka3;
                case "NAX13_02":
                    return cardIDEnum.NAX13_02;
                case "EX1_112":
                    return cardIDEnum.EX1_112;
                case "FP1_011":
                    return cardIDEnum.FP1_011;
                case "CS2_009e":
                    return cardIDEnum.CS2_009e;
                case "HERO_04":
                    return cardIDEnum.HERO_04;
                case "EX1_607":
                    return cardIDEnum.EX1_607;
                case "DREAM_03":
                    return cardIDEnum.DREAM_03;
                case "NAX11_04e":
                    return cardIDEnum.NAX11_04e;
                case "EX1_103e":
                    return cardIDEnum.EX1_103e;
                case "XXX_046":
                    return cardIDEnum.XXX_046;
                case "FP1_003":
                    return cardIDEnum.FP1_003;
                case "CS2_105":
                    return cardIDEnum.CS2_105;
                case "FP1_002":
                    return cardIDEnum.FP1_002;
                case "TU4c_002":
                    return cardIDEnum.TU4c_002;
                case "CRED_14":
                    return cardIDEnum.CRED_14;
                case "EX1_567":
                    return cardIDEnum.EX1_567;
                case "TU4c_004":
                    return cardIDEnum.TU4c_004;
                case "NAX10_03H":
                    return cardIDEnum.NAX10_03H;
                case "FP1_008":
                    return cardIDEnum.FP1_008;
                case "DS1_184":
                    return cardIDEnum.DS1_184;
                case "CS2_029":
                    return cardIDEnum.CS2_029;
                case "GAME_005":
                    return cardIDEnum.GAME_005;
                case "CS2_187":
                    return cardIDEnum.CS2_187;
                case "EX1_020":
                    return cardIDEnum.EX1_020;
                case "NAX15_01He":
                    return cardIDEnum.NAX15_01He;
                case "EX1_011":
                    return cardIDEnum.EX1_011;
                case "CS2_057":
                    return cardIDEnum.CS2_057;
                case "EX1_274":
                    return cardIDEnum.EX1_274;
                case "EX1_306":
                    return cardIDEnum.EX1_306;
                case "NEW1_038o":
                    return cardIDEnum.NEW1_038o;
                case "EX1_170":
                    return cardIDEnum.EX1_170;
                case "EX1_617":
                    return cardIDEnum.EX1_617;
                case "CS1_113e":
                    return cardIDEnum.CS1_113e;
                case "CS2_101":
                    return cardIDEnum.CS2_101;
                case "FP1_015":
                    return cardIDEnum.FP1_015;
                case "NAX13_03":
                    return cardIDEnum.NAX13_03;
                case "CS2_005":
                    return cardIDEnum.CS2_005;
                case "EX1_537":
                    return cardIDEnum.EX1_537;
                case "EX1_384":
                    return cardIDEnum.EX1_384;
                case "TU4a_002":
                    return cardIDEnum.TU4a_002;
                case "NAX9_04":
                    return cardIDEnum.NAX9_04;
                case "EX1_362":
                    return cardIDEnum.EX1_362;
                case "NAX12_02":
                    return cardIDEnum.NAX12_02;
                case "FP1_028e":
                    return cardIDEnum.FP1_028e;
                case "TU4c_005":
                    return cardIDEnum.TU4c_005;
                case "EX1_301":
                    return cardIDEnum.EX1_301;
                case "CS2_235":
                    return cardIDEnum.CS2_235;
                case "NAX4_05":
                    return cardIDEnum.NAX4_05;
                case "EX1_029":
                    return cardIDEnum.EX1_029;
                case "CS2_042":
                    return cardIDEnum.CS2_042;
                case "EX1_155a":
                    return cardIDEnum.EX1_155a;
                case "CS2_102":
                    return cardIDEnum.CS2_102;
                case "EX1_609":
                    return cardIDEnum.EX1_609;
                case "NEW1_027":
                    return cardIDEnum.NEW1_027;
                case "CS2_236e":
                    return cardIDEnum.CS2_236e;
                case "CS2_083e":
                    return cardIDEnum.CS2_083e;
                case "NAX6_03te":
                    return cardIDEnum.NAX6_03te;
                case "EX1_165a":
                    return cardIDEnum.EX1_165a;
                case "EX1_570":
                    return cardIDEnum.EX1_570;
                case "EX1_131":
                    return cardIDEnum.EX1_131;
                case "EX1_556":
                    return cardIDEnum.EX1_556;
                case "EX1_543":
                    return cardIDEnum.EX1_543;
                case "XXX_096":
                    return cardIDEnum.XXX_096;
                case "TU4c_008e":
                    return cardIDEnum.TU4c_008e;
                case "EX1_379e":
                    return cardIDEnum.EX1_379e;
                case "NEW1_009":
                    return cardIDEnum.NEW1_009;
                case "EX1_100":
                    return cardIDEnum.EX1_100;
                case "EX1_274e":
                    return cardIDEnum.EX1_274e;
                case "CRED_02":
                    return cardIDEnum.CRED_02;
                case "EX1_573a":
                    return cardIDEnum.EX1_573a;
                case "CS2_084":
                    return cardIDEnum.CS2_084;
                case "EX1_582":
                    return cardIDEnum.EX1_582;
                case "EX1_043":
                    return cardIDEnum.EX1_043;
                case "EX1_050":
                    return cardIDEnum.EX1_050;
                case "TU4b_001":
                    return cardIDEnum.TU4b_001;
                case "FP1_005":
                    return cardIDEnum.FP1_005;
                case "EX1_620":
                    return cardIDEnum.EX1_620;
                case "NAX15_01":
                    return cardIDEnum.NAX15_01;
                case "NAX6_03":
                    return cardIDEnum.NAX6_03;
                case "EX1_303":
                    return cardIDEnum.EX1_303;
                case "HERO_09":
                    return cardIDEnum.HERO_09;
                case "EX1_067":
                    return cardIDEnum.EX1_067;
                case "XXX_028":
                    return cardIDEnum.XXX_028;
                case "EX1_277":
                    return cardIDEnum.EX1_277;
                case "Mekka2":
                    return cardIDEnum.Mekka2;
                case "NAX14_01H":
                    return cardIDEnum.NAX14_01H;
                case "NAX15_04":
                    return cardIDEnum.NAX15_04;
                case "FP1_024":
                    return cardIDEnum.FP1_024;
                case "FP1_030":
                    return cardIDEnum.FP1_030;
                case "CS2_221e":
                    return cardIDEnum.CS2_221e;
                case "EX1_178":
                    return cardIDEnum.EX1_178;
                case "CS2_222":
                    return cardIDEnum.CS2_222;
                case "EX1_409e":
                    return cardIDEnum.EX1_409e;
                case "tt_004o":
                    return cardIDEnum.tt_004o;
                case "EX1_155ae":
                    return cardIDEnum.EX1_155ae;
                case "NAX11_01H":
                    return cardIDEnum.NAX11_01H;
                case "EX1_160a":
                    return cardIDEnum.EX1_160a;
                case "NAX15_02":
                    return cardIDEnum.NAX15_02;
                case "NAX15_05":
                    return cardIDEnum.NAX15_05;
                case "NEW1_025e":
                    return cardIDEnum.NEW1_025e;
                case "CS2_012":
                    return cardIDEnum.CS2_012;
                case "XXX_099":
                    return cardIDEnum.XXX_099;
                case "EX1_246":
                    return cardIDEnum.EX1_246;
                case "EX1_572":
                    return cardIDEnum.EX1_572;
                case "EX1_089":
                    return cardIDEnum.EX1_089;
                case "CS2_059":
                    return cardIDEnum.CS2_059;
                case "EX1_279":
                    return cardIDEnum.EX1_279;
                case "NAX12_02e":
                    return cardIDEnum.NAX12_02e;
                case "CS2_168":
                    return cardIDEnum.CS2_168;
                case "tt_010":
                    return cardIDEnum.tt_010;
                case "NEW1_023":
                    return cardIDEnum.NEW1_023;
                case "CS2_075":
                    return cardIDEnum.CS2_075;
                case "EX1_316":
                    return cardIDEnum.EX1_316;
                case "CS2_025":
                    return cardIDEnum.CS2_025;
                case "CS2_234":
                    return cardIDEnum.CS2_234;
                case "XXX_043":
                    return cardIDEnum.XXX_043;
                case "GAME_001":
                    return cardIDEnum.GAME_001;
                case "NAX5_02":
                    return cardIDEnum.NAX5_02;
                case "EX1_130":
                    return cardIDEnum.EX1_130;
                case "EX1_584e":
                    return cardIDEnum.EX1_584e;
                case "CS2_064":
                    return cardIDEnum.CS2_064;
                case "EX1_161":
                    return cardIDEnum.EX1_161;
                case "CS2_049":
                    return cardIDEnum.CS2_049;
                case "NAX13_01":
                    return cardIDEnum.NAX13_01;
                case "EX1_154":
                    return cardIDEnum.EX1_154;
                case "EX1_080":
                    return cardIDEnum.EX1_080;
                case "NEW1_022":
                    return cardIDEnum.NEW1_022;
                case "NAX2_01H":
                    return cardIDEnum.NAX2_01H;
                case "EX1_160be":
                    return cardIDEnum.EX1_160be;
                case "NAX12_03":
                    return cardIDEnum.NAX12_03;
                case "EX1_251":
                    return cardIDEnum.EX1_251;
                case "FP1_025":
                    return cardIDEnum.FP1_025;
                case "EX1_371":
                    return cardIDEnum.EX1_371;
                case "CS2_mirror":
                    return cardIDEnum.CS2_mirror;
                case "NAX4_01H":
                    return cardIDEnum.NAX4_01H;
                case "EX1_594":
                    return cardIDEnum.EX1_594;
                case "NAX14_02":
                    return cardIDEnum.NAX14_02;
                case "TU4c_006e":
                    return cardIDEnum.TU4c_006e;
                case "EX1_560":
                    return cardIDEnum.EX1_560;
                case "CS2_236":
                    return cardIDEnum.CS2_236;
                case "TU4f_006":
                    return cardIDEnum.TU4f_006;
                case "EX1_402":
                    return cardIDEnum.EX1_402;
                case "NAX3_01":
                    return cardIDEnum.NAX3_01;
                case "EX1_506":
                    return cardIDEnum.EX1_506;
                case "NEW1_027e":
                    return cardIDEnum.NEW1_027e;
                case "DS1_070o":
                    return cardIDEnum.DS1_070o;
                case "XXX_045":
                    return cardIDEnum.XXX_045;
                case "XXX_029":
                    return cardIDEnum.XXX_029;
                case "DS1_178":
                    return cardIDEnum.DS1_178;
                case "XXX_098":
                    return cardIDEnum.XXX_098;
                case "EX1_315":
                    return cardIDEnum.EX1_315;
                case "CS2_094":
                    return cardIDEnum.CS2_094;
                case "NAX13_01H":
                    return cardIDEnum.NAX13_01H;
                case "TU4e_002t":
                    return cardIDEnum.TU4e_002t;
                case "EX1_046e":
                    return cardIDEnum.EX1_046e;
                case "NEW1_040t":
                    return cardIDEnum.NEW1_040t;
                case "GAME_005e":
                    return cardIDEnum.GAME_005e;
                case "CS2_131":
                    return cardIDEnum.CS2_131;
                case "XXX_008":
                    return cardIDEnum.XXX_008;
                case "EX1_531e":
                    return cardIDEnum.EX1_531e;
                case "CS2_226e":
                    return cardIDEnum.CS2_226e;
                case "XXX_022e":
                    return cardIDEnum.XXX_022e;
                case "DS1_178e":
                    return cardIDEnum.DS1_178e;
                case "CS2_226o":
                    return cardIDEnum.CS2_226o;
                case "NAX9_04H":
                    return cardIDEnum.NAX9_04H;
                case "Mekka4e":
                    return cardIDEnum.Mekka4e;
                case "EX1_082":
                    return cardIDEnum.EX1_082;
                case "CS2_093":
                    return cardIDEnum.CS2_093;
                case "EX1_411e":
                    return cardIDEnum.EX1_411e;
                case "NAX8_03t":
                    return cardIDEnum.NAX8_03t;
                case "EX1_145o":
                    return cardIDEnum.EX1_145o;
                case "NAX7_04":
                    return cardIDEnum.NAX7_04;
                case "CS2_boar":
                    return cardIDEnum.CS2_boar;
                case "NEW1_019":
                    return cardIDEnum.NEW1_019;
                case "EX1_289":
                    return cardIDEnum.EX1_289;
                case "EX1_025t":
                    return cardIDEnum.EX1_025t;
                case "EX1_398t":
                    return cardIDEnum.EX1_398t;
                case "NAX12_03H":
                    return cardIDEnum.NAX12_03H;
                case "EX1_055o":
                    return cardIDEnum.EX1_055o;
                case "CS2_091":
                    return cardIDEnum.CS2_091;
                case "EX1_241":
                    return cardIDEnum.EX1_241;
                case "EX1_085":
                    return cardIDEnum.EX1_085;
                case "CS2_200":
                    return cardIDEnum.CS2_200;
                case "CS2_034":
                    return cardIDEnum.CS2_034;
                case "EX1_583":
                    return cardIDEnum.EX1_583;
                case "EX1_584":
                    return cardIDEnum.EX1_584;
                case "EX1_155":
                    return cardIDEnum.EX1_155;
                case "EX1_622":
                    return cardIDEnum.EX1_622;
                case "CS2_203":
                    return cardIDEnum.CS2_203;
                case "EX1_124":
                    return cardIDEnum.EX1_124;
                case "EX1_379":
                    return cardIDEnum.EX1_379;
                case "NAX7_02":
                    return cardIDEnum.NAX7_02;
                case "CS2_053e":
                    return cardIDEnum.CS2_053e;
                case "EX1_032":
                    return cardIDEnum.EX1_032;
                case "NAX9_01":
                    return cardIDEnum.NAX9_01;
                case "TU4e_003":
                    return cardIDEnum.TU4e_003;
                case "CS2_146o":
                    return cardIDEnum.CS2_146o;
                case "NAX8_01H":
                    return cardIDEnum.NAX8_01H;
                case "XXX_041":
                    return cardIDEnum.XXX_041;
                case "NAXM_002":
                    return cardIDEnum.NAXM_002;
                case "EX1_391":
                    return cardIDEnum.EX1_391;
                case "EX1_366":
                    return cardIDEnum.EX1_366;
                case "EX1_059e":
                    return cardIDEnum.EX1_059e;
                case "XXX_012":
                    return cardIDEnum.XXX_012;
                case "EX1_565o":
                    return cardIDEnum.EX1_565o;
                case "EX1_001e":
                    return cardIDEnum.EX1_001e;
                case "TU4f_003":
                    return cardIDEnum.TU4f_003;
                case "EX1_400":
                    return cardIDEnum.EX1_400;
                case "EX1_614":
                    return cardIDEnum.EX1_614;
                case "EX1_561":
                    return cardIDEnum.EX1_561;
                case "EX1_332":
                    return cardIDEnum.EX1_332;
                case "HERO_05":
                    return cardIDEnum.HERO_05;
                case "CS2_065":
                    return cardIDEnum.CS2_065;
                case "ds1_whelptoken":
                    return cardIDEnum.ds1_whelptoken;
                case "EX1_536e":
                    return cardIDEnum.EX1_536e;
                case "CS2_032":
                    return cardIDEnum.CS2_032;
                case "CS2_120":
                    return cardIDEnum.CS2_120;
                case "EX1_155be":
                    return cardIDEnum.EX1_155be;
                case "EX1_247":
                    return cardIDEnum.EX1_247;
                case "EX1_154a":
                    return cardIDEnum.EX1_154a;
                case "EX1_554t":
                    return cardIDEnum.EX1_554t;
                case "CS2_103e2":
                    return cardIDEnum.CS2_103e2;
                case "TU4d_003":
                    return cardIDEnum.TU4d_003;
                case "NEW1_026t":
                    return cardIDEnum.NEW1_026t;
                case "EX1_623":
                    return cardIDEnum.EX1_623;
                case "EX1_383t":
                    return cardIDEnum.EX1_383t;
                case "NAX7_03":
                    return cardIDEnum.NAX7_03;
                case "EX1_597":
                    return cardIDEnum.EX1_597;
                case "TU4f_006o":
                    return cardIDEnum.TU4f_006o;
                case "EX1_130a":
                    return cardIDEnum.EX1_130a;
                case "CS2_011":
                    return cardIDEnum.CS2_011;
                case "EX1_169":
                    return cardIDEnum.EX1_169;
                case "EX1_tk33":
                    return cardIDEnum.EX1_tk33;
                case "NAX11_03":
                    return cardIDEnum.NAX11_03;
                case "NAX4_01":
                    return cardIDEnum.NAX4_01;
                case "NAX10_01":
                    return cardIDEnum.NAX10_01;
                case "EX1_250":
                    return cardIDEnum.EX1_250;
                case "EX1_564":
                    return cardIDEnum.EX1_564;
                case "NAX5_03":
                    return cardIDEnum.NAX5_03;
                case "EX1_043e":
                    return cardIDEnum.EX1_043e;
                case "EX1_349":
                    return cardIDEnum.EX1_349;
                case "XXX_097":
                    return cardIDEnum.XXX_097;
                case "EX1_102":
                    return cardIDEnum.EX1_102;
                case "EX1_058":
                    return cardIDEnum.EX1_058;
                case "EX1_243":
                    return cardIDEnum.EX1_243;
                case "PRO_001c":
                    return cardIDEnum.PRO_001c;
                case "EX1_116t":
                    return cardIDEnum.EX1_116t;
                case "NAX15_01e":
                    return cardIDEnum.NAX15_01e;
                case "FP1_029":
                    return cardIDEnum.FP1_029;
                case "CS2_089":
                    return cardIDEnum.CS2_089;
                case "TU4c_001":
                    return cardIDEnum.TU4c_001;
                case "EX1_248":
                    return cardIDEnum.EX1_248;
                case "NEW1_037e":
                    return cardIDEnum.NEW1_037e;
                case "CS2_122":
                    return cardIDEnum.CS2_122;
                case "EX1_393":
                    return cardIDEnum.EX1_393;
                case "CS2_232":
                    return cardIDEnum.CS2_232;
                case "EX1_165b":
                    return cardIDEnum.EX1_165b;
                case "NEW1_030":
                    return cardIDEnum.NEW1_030;
                case "EX1_161o":
                    return cardIDEnum.EX1_161o;
                case "EX1_093e":
                    return cardIDEnum.EX1_093e;
                case "CS2_150":
                    return cardIDEnum.CS2_150;
                case "CS2_152":
                    return cardIDEnum.CS2_152;
                case "NAX9_03H":
                    return cardIDEnum.NAX9_03H;
                case "EX1_160t":
                    return cardIDEnum.EX1_160t;
                case "CS2_127":
                    return cardIDEnum.CS2_127;
                case "CRED_03":
                    return cardIDEnum.CRED_03;
                case "DS1_188":
                    return cardIDEnum.DS1_188;
                case "XXX_001":
                    return cardIDEnum.XXX_001;
            }




            return cardIDEnum.None;
        }

        /// <summary>
        /// The card namestring to enum.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="cardName"/>.
        /// </returns>
        public cardName cardNamestringToEnum(string s)
        {
            switch (s)
            {
                case "unknown":
                    return cardName.unknown;

                case "hogger":
                    return cardName.hogger;

                case "heigantheunclean":
                    return cardName.heigantheunclean;

                case "necroticaura":
                    return cardName.necroticaura;

                case "starfall":
                    return cardName.starfall;

                case "barrel":
                    return cardName.barrel;

                case "damagereflector":
                    return cardName.damagereflector;

                case "edwinvancleef":
                    return cardName.edwinvancleef;

                case "gothiktheharvester":
                    return cardName.gothiktheharvester;

                case "perditionsblade":
                    return cardName.perditionsblade;

                case "bloodsailraider":
                    return cardName.bloodsailraider;

                case "guardianoficecrown":
                    return cardName.guardianoficecrown;

                case "bloodmagethalnos":
                    return cardName.bloodmagethalnos;

                case "rooted":
                    return cardName.rooted;

                case "wisp":
                    return cardName.wisp;

                case "rachelledavis":
                    return cardName.rachelledavis;

                case "senjinshieldmasta":
                    return cardName.senjinshieldmasta;

                case "totemicmight":
                    return cardName.totemicmight;

                case "uproot":
                    return cardName.uproot;

                case "opponentdisconnect":
                    return cardName.opponentdisconnect;

                case "unrelentingrider":
                    return cardName.unrelentingrider;

                case "shandoslesson":
                    return cardName.shandoslesson;

                case "hemetnesingwary":
                    return cardName.hemetnesingwary;

                case "decimate":
                    return cardName.decimate;

                case "shadowofnothing":
                    return cardName.shadowofnothing;

                case "nerubian":
                    return cardName.nerubian;

                case "dragonlingmechanic":
                    return cardName.dragonlingmechanic;

                case "mogushanwarden":
                    return cardName.mogushanwarden;

                case "thanekorthazz":
                    return cardName.thanekorthazz;

                case "hungrycrab":
                    return cardName.hungrycrab;

                case "ancientteachings":
                    return cardName.ancientteachings;

                case "misdirection":
                    return cardName.misdirection;

                case "patientassassin":
                    return cardName.patientassassin;

                case "mutatinginjection":
                    return cardName.mutatinginjection;

                case "violetteacher":
                    return cardName.violetteacher;

                case "arathiweaponsmith":
                    return cardName.arathiweaponsmith;

                case "raisedead":
                    return cardName.raisedead;

                case "acolyteofpain":
                    return cardName.acolyteofpain;

                case "holynova":
                    return cardName.holynova;

                case "robpardo":
                    return cardName.robpardo;

                case "commandingshout":
                    return cardName.commandingshout;

                case "necroticpoison":
                    return cardName.necroticpoison;

                case "unboundelemental":
                    return cardName.unboundelemental;

                case "garroshhellscream":
                    return cardName.garroshhellscream;

                case "enchant":
                    return cardName.enchant;

                case "loatheb":
                    return cardName.loatheb;

                case "blessingofmight":
                    return cardName.blessingofmight;

                case "nightmare":
                    return cardName.nightmare;

                case "blessingofkings":
                    return cardName.blessingofkings;

                case "polymorph":
                    return cardName.polymorph;

                case "darkirondwarf":
                    return cardName.darkirondwarf;

                case "destroy":
                    return cardName.destroy;

                case "roguesdoit":
                    return cardName.roguesdoit;

                case "freecards":
                    return cardName.freecards;

                case "iammurloc":
                    return cardName.iammurloc;

                case "sporeburst":
                    return cardName.sporeburst;

                case "mindcontrolcrystal":
                    return cardName.mindcontrolcrystal;

                case "charge":
                    return cardName.charge;

                case "stampedingkodo":
                    return cardName.stampedingkodo;

                case "humility":
                    return cardName.humility;

                case "darkcultist":
                    return cardName.darkcultist;

                case "gruul":
                    return cardName.gruul;

                case "markofthewild":
                    return cardName.markofthewild;

                case "patchwerk":
                    return cardName.patchwerk;

                case "worgeninfiltrator":
                    return cardName.worgeninfiltrator;

                case "frostbolt":
                    return cardName.frostbolt;

                case "runeblade":
                    return cardName.runeblade;

                case "flametonguetotem":
                    return cardName.flametonguetotem;

                case "assassinate":
                    return cardName.assassinate;

                case "madscientist":
                    return cardName.madscientist;

                case "lordofthearena":
                    return cardName.lordofthearena;

                case "bainebloodhoof":
                    return cardName.bainebloodhoof;

                case "injuredblademaster":
                    return cardName.injuredblademaster;

                case "siphonsoul":
                    return cardName.siphonsoul;

                case "layonhands":
                    return cardName.layonhands;

                case "hook":
                    return cardName.hook;

                case "massiveruneblade":
                    return cardName.massiveruneblade;

                case "lorewalkercho":
                    return cardName.lorewalkercho;

                case "destroyallminions":
                    return cardName.destroyallminions;

                case "silvermoonguardian":
                    return cardName.silvermoonguardian;

                case "destroyallmana":
                    return cardName.destroyallmana;

                case "huffer":
                    return cardName.huffer;

                case "mindvision":
                    return cardName.mindvision;

                case "malfurionstormrage":
                    return cardName.malfurionstormrage;

                case "corehound":
                    return cardName.corehound;

                case "grimscaleoracle":
                    return cardName.grimscaleoracle;

                case "lightningstorm":
                    return cardName.lightningstorm;

                case "lightwell":
                    return cardName.lightwell;

                case "benthompson":
                    return cardName.benthompson;

                case "coldlightseer":
                    return cardName.coldlightseer;

                case "deathsbite":
                    return cardName.deathsbite;

                case "gorehowl":
                    return cardName.gorehowl;

                case "skitter":
                    return cardName.skitter;

                case "farsight":
                    return cardName.farsight;

                case "chillwindyeti":
                    return cardName.chillwindyeti;

                case "moonfire":
                    return cardName.moonfire;

                case "bladeflurry":
                    return cardName.bladeflurry;

                case "massdispel":
                    return cardName.massdispel;

                case "crazedalchemist":
                    return cardName.crazedalchemist;

                case "shadowmadness":
                    return cardName.shadowmadness;

                case "equality":
                    return cardName.equality;

                case "misha":
                    return cardName.misha;

                case "treant":
                    return cardName.treant;

                case "alarmobot":
                    return cardName.alarmobot;

                case "animalcompanion":
                    return cardName.animalcompanion;

                case "hatefulstrike":
                    return cardName.hatefulstrike;

                case "dream":
                    return cardName.dream;

                case "anubrekhan":
                    return cardName.anubrekhan;

                case "youngpriestess":
                    return cardName.youngpriestess;

                case "gadgetzanauctioneer":
                    return cardName.gadgetzanauctioneer;

                case "coneofcold":
                    return cardName.coneofcold;

                case "earthshock":
                    return cardName.earthshock;

                case "tirionfordring":
                    return cardName.tirionfordring;

                case "wailingsoul":
                    return cardName.wailingsoul;

                case "skeleton":
                    return cardName.skeleton;

                case "ironfurgrizzly":
                    return cardName.ironfurgrizzly;

                case "headcrack":
                    return cardName.headcrack;

                case "arcaneshot":
                    return cardName.arcaneshot;

                case "maexxna":
                    return cardName.maexxna;

                case "imp":
                    return cardName.imp;

                case "markofthehorsemen":
                    return cardName.markofthehorsemen;

                case "voidterror":
                    return cardName.voidterror;

                case "mortalcoil":
                    return cardName.mortalcoil;

                case "draw3cards":
                    return cardName.draw3cards;

                case "flameofazzinoth":
                    return cardName.flameofazzinoth;

                case "jainaproudmoore":
                    return cardName.jainaproudmoore;

                case "execute":
                    return cardName.execute;

                case "bloodlust":
                    return cardName.bloodlust;

                case "bananas":
                    return cardName.bananas;

                case "kidnapper":
                    return cardName.kidnapper;

                case "oldmurkeye":
                    return cardName.oldmurkeye;

                case "homingchicken":
                    return cardName.homingchicken;

                case "enableforattack":
                    return cardName.enableforattack;

                case "spellbender":
                    return cardName.spellbender;

                case "backstab":
                    return cardName.backstab;

                case "squirrel":
                    return cardName.squirrel;

                case "stalagg":
                    return cardName.stalagg;

                case "grandwidowfaerlina":
                    return cardName.grandwidowfaerlina;

                case "heavyaxe":
                    return cardName.heavyaxe;

                case "zwick":
                    return cardName.zwick;

                case "webwrap":
                    return cardName.webwrap;

                case "flamesofazzinoth":
                    return cardName.flamesofazzinoth;

                case "murlocwarleader":
                    return cardName.murlocwarleader;

                case "shadowstep":
                    return cardName.shadowstep;

                case "ancestralspirit":
                    return cardName.ancestralspirit;

                case "defenderofargus":
                    return cardName.defenderofargus;

                case "assassinsblade":
                    return cardName.assassinsblade;

                case "discard":
                    return cardName.discard;

                case "biggamehunter":
                    return cardName.biggamehunter;

                case "aldorpeacekeeper":
                    return cardName.aldorpeacekeeper;

                case "blizzard":
                    return cardName.blizzard;

                case "pandarenscout":
                    return cardName.pandarenscout;

                case "unleashthehounds":
                    return cardName.unleashthehounds;

                case "yseraawakens":
                    return cardName.yseraawakens;

                case "sap":
                    return cardName.sap;

                case "kelthuzad":
                    return cardName.kelthuzad;

                case "defiasbandit":
                    return cardName.defiasbandit;

                case "gnomishinventor":
                    return cardName.gnomishinventor;

                case "mindcontrol":
                    return cardName.mindcontrol;

                case "ravenholdtassassin":
                    return cardName.ravenholdtassassin;

                case "icelance":
                    return cardName.icelance;

                case "dispel":
                    return cardName.dispel;

                case "acidicswampooze":
                    return cardName.acidicswampooze;

                case "muklasbigbrother":
                    return cardName.muklasbigbrother;

                case "blessedchampion":
                    return cardName.blessedchampion;

                case "savannahhighmane":
                    return cardName.savannahhighmane;

                case "direwolfalpha":
                    return cardName.direwolfalpha;

                case "hoggersmash":
                    return cardName.hoggersmash;

                case "blessingofwisdom":
                    return cardName.blessingofwisdom;

                case "nourish":
                    return cardName.nourish;

                case "abusivesergeant":
                    return cardName.abusivesergeant;

                case "sylvanaswindrunner":
                    return cardName.sylvanaswindrunner;

                case "spore":
                    return cardName.spore;

                case "crueltaskmaster":
                    return cardName.crueltaskmaster;

                case "lightningbolt":
                    return cardName.lightningbolt;

                case "keeperofthegrove":
                    return cardName.keeperofthegrove;

                case "steadyshot":
                    return cardName.steadyshot;

                case "multishot":
                    return cardName.multishot;

                case "harvest":
                    return cardName.harvest;

                case "instructorrazuvious":
                    return cardName.instructorrazuvious;

                case "ladyblaumeux":
                    return cardName.ladyblaumeux;

                case "jaybaxter":
                    return cardName.jaybaxter;

                case "molasses":
                    return cardName.molasses;

                case "pintsizedsummoner":
                    return cardName.pintsizedsummoner;

                case "spellbreaker":
                    return cardName.spellbreaker;

                case "anubarambusher":
                    return cardName.anubarambusher;

                case "deadlypoison":
                    return cardName.deadlypoison;

                case "stoneskingargoyle":
                    return cardName.stoneskingargoyle;

                case "bloodfury":
                    return cardName.bloodfury;

                case "fanofknives":
                    return cardName.fanofknives;

                case "poisoncloud":
                    return cardName.poisoncloud;

                case "shieldbearer":
                    return cardName.shieldbearer;

                case "sensedemons":
                    return cardName.sensedemons;

                case "shieldblock":
                    return cardName.shieldblock;

                case "handswapperminion":
                    return cardName.handswapperminion;

                case "massivegnoll":
                    return cardName.massivegnoll;

                case "deathcharger":
                    return cardName.deathcharger;

                case "ancientoflore":
                    return cardName.ancientoflore;

                case "oasissnapjaw":
                    return cardName.oasissnapjaw;

                case "illidanstormrage":
                    return cardName.illidanstormrage;

                case "frostwolfgrunt":
                    return cardName.frostwolfgrunt;

                case "lesserheal":
                    return cardName.lesserheal;

                case "infernal":
                    return cardName.infernal;

                case "wildpyromancer":
                    return cardName.wildpyromancer;

                case "razorfenhunter":
                    return cardName.razorfenhunter;

                case "twistingnether":
                    return cardName.twistingnether;

                case "voidcaller":
                    return cardName.voidcaller;

                case "leaderofthepack":
                    return cardName.leaderofthepack;

                case "malygos":
                    return cardName.malygos;

                case "becomehogger":
                    return cardName.becomehogger;

                case "baronrivendare":
                    return cardName.baronrivendare;

                case "millhousemanastorm":
                    return cardName.millhousemanastorm;

                case "innerfire":
                    return cardName.innerfire;

                case "valeerasanguinar":
                    return cardName.valeerasanguinar;

                case "chicken":
                    return cardName.chicken;

                case "souloftheforest":
                    return cardName.souloftheforest;

                case "silencedebug":
                    return cardName.silencedebug;

                case "bloodsailcorsair":
                    return cardName.bloodsailcorsair;

                case "slime":
                    return cardName.slime;

                case "tinkmasteroverspark":
                    return cardName.tinkmasteroverspark;

                case "iceblock":
                    return cardName.iceblock;

                case "brawl":
                    return cardName.brawl;

                case "vanish":
                    return cardName.vanish;

                case "poisonseeds":
                    return cardName.poisonseeds;

                case "murloc":
                    return cardName.murloc;

                case "mindspike":
                    return cardName.mindspike;

                case "kingmukla":
                    return cardName.kingmukla;

                case "stevengabriel":
                    return cardName.stevengabriel;

                case "gluth":
                    return cardName.gluth;

                case "truesilverchampion":
                    return cardName.truesilverchampion;

                case "harrisonjones":
                    return cardName.harrisonjones;

                case "destroydeck":
                    return cardName.destroydeck;

                case "devilsaur":
                    return cardName.devilsaur;

                case "wargolem":
                    return cardName.wargolem;

                case "warsongcommander":
                    return cardName.warsongcommander;

                case "manawyrm":
                    return cardName.manawyrm;

                case "thaddius":
                    return cardName.thaddius;

                case "savagery":
                    return cardName.savagery;

                case "spitefulsmith":
                    return cardName.spitefulsmith;

                case "shatteredsuncleric":
                    return cardName.shatteredsuncleric;

                case "eyeforaneye":
                    return cardName.eyeforaneye;

                case "azuredrake":
                    return cardName.azuredrake;

                case "mountaingiant":
                    return cardName.mountaingiant;

                case "korkronelite":
                    return cardName.korkronelite;

                case "junglepanther":
                    return cardName.junglepanther;

                case "barongeddon":
                    return cardName.barongeddon;

                case "spectralspider":
                    return cardName.spectralspider;

                case "pitlord":
                    return cardName.pitlord;

                case "markofnature":
                    return cardName.markofnature;

                case "grobbulus":
                    return cardName.grobbulus;

                case "leokk":
                    return cardName.leokk;

                case "fierywaraxe":
                    return cardName.fierywaraxe;

                case "damage5":
                    return cardName.damage5;

                case "duplicate":
                    return cardName.duplicate;

                case "restore5":
                    return cardName.restore5;

                case "mindblast":
                    return cardName.mindblast;

                case "timberwolf":
                    return cardName.timberwolf;

                case "captaingreenskin":
                    return cardName.captaingreenskin;

                case "elvenarcher":
                    return cardName.elvenarcher;

                case "michaelschweitzer":
                    return cardName.michaelschweitzer;

                case "masterswordsmith":
                    return cardName.masterswordsmith;

                case "grommashhellscream":
                    return cardName.grommashhellscream;

                case "hound":
                    return cardName.hound;

                case "seagiant":
                    return cardName.seagiant;

                case "doomguard":
                    return cardName.doomguard;

                case "alakirthewindlord":
                    return cardName.alakirthewindlord;

                case "hyena":
                    return cardName.hyena;

                case "undertaker":
                    return cardName.undertaker;

                case "frothingberserker":
                    return cardName.frothingberserker;

                case "powerofthewild":
                    return cardName.powerofthewild;

                case "druidoftheclaw":
                    return cardName.druidoftheclaw;

                case "hellfire":
                    return cardName.hellfire;

                case "archmage":
                    return cardName.archmage;

                case "recklessrocketeer":
                    return cardName.recklessrocketeer;

                case "crazymonkey":
                    return cardName.crazymonkey;

                case "damageallbut1":
                    return cardName.damageallbut1;

                case "frostblast":
                    return cardName.frostblast;

                case "powerwordshield":
                    return cardName.powerwordshield;

                case "rainoffire":
                    return cardName.rainoffire;

                case "arcaneintellect":
                    return cardName.arcaneintellect;

                case "angrychicken":
                    return cardName.angrychicken;

                case "nerubianegg":
                    return cardName.nerubianegg;

                case "worshipper":
                    return cardName.worshipper;

                case "mindgames":
                    return cardName.mindgames;

                case "leeroyjenkins":
                    return cardName.leeroyjenkins;

                case "gurubashiberserker":
                    return cardName.gurubashiberserker;

                case "windspeaker":
                    return cardName.windspeaker;

                case "enableemotes":
                    return cardName.enableemotes;

                case "forceofnature":
                    return cardName.forceofnature;

                case "lightspawn":
                    return cardName.lightspawn;

                case "destroyamanacrystal":
                    return cardName.destroyamanacrystal;

                case "warglaiveofazzinoth":
                    return cardName.warglaiveofazzinoth;

                case "finkleeinhorn":
                    return cardName.finkleeinhorn;

                case "frostelemental":
                    return cardName.frostelemental;

                case "thoughtsteal":
                    return cardName.thoughtsteal;

                case "brianschwab":
                    return cardName.brianschwab;

                case "scavenginghyena":
                    return cardName.scavenginghyena;

                case "si7agent":
                    return cardName.si7agent;

                case "prophetvelen":
                    return cardName.prophetvelen;

                case "soulfire":
                    return cardName.soulfire;

                case "ogremagi":
                    return cardName.ogremagi;

                case "damagedgolem":
                    return cardName.damagedgolem;

                case "crash":
                    return cardName.crash;

                case "adrenalinerush":
                    return cardName.adrenalinerush;

                case "murloctidecaller":
                    return cardName.murloctidecaller;

                case "kirintormage":
                    return cardName.kirintormage;

                case "spectralrider":
                    return cardName.spectralrider;

                case "thrallmarfarseer":
                    return cardName.thrallmarfarseer;

                case "frostwolfwarlord":
                    return cardName.frostwolfwarlord;

                case "sorcerersapprentice":
                    return cardName.sorcerersapprentice;

                case "feugen":
                    return cardName.feugen;

                case "willofmukla":
                    return cardName.willofmukla;

                case "holyfire":
                    return cardName.holyfire;

                case "manawraith":
                    return cardName.manawraith;

                case "argentsquire":
                    return cardName.argentsquire;

                case "placeholdercard":
                    return cardName.placeholdercard;

                case "snakeball":
                    return cardName.snakeball;

                case "ancientwatcher":
                    return cardName.ancientwatcher;

                case "noviceengineer":
                    return cardName.noviceengineer;

                case "stonetuskboar":
                    return cardName.stonetuskboar;

                case "ancestralhealing":
                    return cardName.ancestralhealing;

                case "conceal":
                    return cardName.conceal;

                case "arcanitereaper":
                    return cardName.arcanitereaper;

                case "guldan":
                    return cardName.guldan;

                case "ragingworgen":
                    return cardName.ragingworgen;

                case "earthenringfarseer":
                    return cardName.earthenringfarseer;

                case "onyxia":
                    return cardName.onyxia;

                case "manaaddict":
                    return cardName.manaaddict;

                case "unholyshadow":
                    return cardName.unholyshadow;

                case "dualwarglaives":
                    return cardName.dualwarglaives;

                case "sludgebelcher":
                    return cardName.sludgebelcher;

                case "worthlessimp":
                    return cardName.worthlessimp;

                case "shiv":
                    return cardName.shiv;

                case "sheep":
                    return cardName.sheep;

                case "bloodknight":
                    return cardName.bloodknight;

                case "holysmite":
                    return cardName.holysmite;

                case "ancientsecrets":
                    return cardName.ancientsecrets;

                case "holywrath":
                    return cardName.holywrath;

                case "ironforgerifleman":
                    return cardName.ironforgerifleman;

                case "elitetaurenchieftain":
                    return cardName.elitetaurenchieftain;

                case "spectralwarrior":
                    return cardName.spectralwarrior;

                case "bluegillwarrior":
                    return cardName.bluegillwarrior;

                case "shapeshift":
                    return cardName.shapeshift;

                case "hamiltonchu":
                    return cardName.hamiltonchu;

                case "battlerage":
                    return cardName.battlerage;

                case "nightblade":
                    return cardName.nightblade;

                case "locustswarm":
                    return cardName.locustswarm;

                case "crazedhunter":
                    return cardName.crazedhunter;

                case "andybrock":
                    return cardName.andybrock;

                case "youthfulbrewmaster":
                    return cardName.youthfulbrewmaster;

                case "theblackknight":
                    return cardName.theblackknight;

                case "brewmaster":
                    return cardName.brewmaster;

                case "lifetap":
                    return cardName.lifetap;

                case "demonfire":
                    return cardName.demonfire;

                case "redemption":
                    return cardName.redemption;

                case "lordjaraxxus":
                    return cardName.lordjaraxxus;

                case "coldblood":
                    return cardName.coldblood;

                case "lightwarden":
                    return cardName.lightwarden;

                case "questingadventurer":
                    return cardName.questingadventurer;

                case "donothing":
                    return cardName.donothing;

                case "dereksakamoto":
                    return cardName.dereksakamoto;

                case "poultryizer":
                    return cardName.poultryizer;

                case "koboldgeomancer":
                    return cardName.koboldgeomancer;

                case "legacyoftheemperor":
                    return cardName.legacyoftheemperor;

                case "eruption":
                    return cardName.eruption;

                case "cenarius":
                    return cardName.cenarius;

                case "deathlord":
                    return cardName.deathlord;

                case "searingtotem":
                    return cardName.searingtotem;

                case "taurenwarrior":
                    return cardName.taurenwarrior;

                case "explosivetrap":
                    return cardName.explosivetrap;

                case "frog":
                    return cardName.frog;

                case "servercrash":
                    return cardName.servercrash;

                case "wickedknife":
                    return cardName.wickedknife;

                case "laughingsister":
                    return cardName.laughingsister;

                case "cultmaster":
                    return cardName.cultmaster;

                case "wildgrowth":
                    return cardName.wildgrowth;

                case "sprint":
                    return cardName.sprint;

                case "masterofdisguise":
                    return cardName.masterofdisguise;

                case "kyleharrison":
                    return cardName.kyleharrison;

                case "avatarofthecoin":
                    return cardName.avatarofthecoin;

                case "excessmana":
                    return cardName.excessmana;

                case "spiritwolf":
                    return cardName.spiritwolf;

                case "auchenaisoulpriest":
                    return cardName.auchenaisoulpriest;

                case "bestialwrath":
                    return cardName.bestialwrath;

                case "rockbiterweapon":
                    return cardName.rockbiterweapon;

                case "starvingbuzzard":
                    return cardName.starvingbuzzard;

                case "mirrorimage":
                    return cardName.mirrorimage;

                case "frozenchampion":
                    return cardName.frozenchampion;

                case "silverhandrecruit":
                    return cardName.silverhandrecruit;

                case "corruption":
                    return cardName.corruption;

                case "preparation":
                    return cardName.preparation;

                case "cairnebloodhoof":
                    return cardName.cairnebloodhoof;

                case "mortalstrike":
                    return cardName.mortalstrike;

                case "flare":
                    return cardName.flare;

                case "necroknight":
                    return cardName.necroknight;

                case "silverhandknight":
                    return cardName.silverhandknight;

                case "breakweapon":
                    return cardName.breakweapon;

                case "guardianofkings":
                    return cardName.guardianofkings;

                case "ancientbrewmaster":
                    return cardName.ancientbrewmaster;

                case "avenge":
                    return cardName.avenge;

                case "youngdragonhawk":
                    return cardName.youngdragonhawk;

                case "frostshock":
                    return cardName.frostshock;

                case "healingtouch":
                    return cardName.healingtouch;

                case "venturecomercenary":
                    return cardName.venturecomercenary;

                case "unbalancingstrike":
                    return cardName.unbalancingstrike;

                case "sacrificialpact":
                    return cardName.sacrificialpact;

                case "noooooooooooo":
                    return cardName.noooooooooooo;

                case "baneofdoom":
                    return cardName.baneofdoom;

                case "abomination":
                    return cardName.abomination;

                case "flesheatingghoul":
                    return cardName.flesheatingghoul;

                case "loothoarder":
                    return cardName.loothoarder;

                case "mill10":
                    return cardName.mill10;

                case "sapphiron":
                    return cardName.sapphiron;

                case "jasonchayes":
                    return cardName.jasonchayes;

                case "benbrode":
                    return cardName.benbrode;

                case "betrayal":
                    return cardName.betrayal;

                case "thebeast":
                    return cardName.thebeast;

                case "flameimp":
                    return cardName.flameimp;

                case "freezingtrap":
                    return cardName.freezingtrap;

                case "southseadeckhand":
                    return cardName.southseadeckhand;

                case "wrath":
                    return cardName.wrath;

                case "bloodfenraptor":
                    return cardName.bloodfenraptor;

                case "cleave":
                    return cardName.cleave;

                case "fencreeper":
                    return cardName.fencreeper;

                case "restore1":
                    return cardName.restore1;

                case "handtodeck":
                    return cardName.handtodeck;

                case "starfire":
                    return cardName.starfire;

                case "goldshirefootman":
                    return cardName.goldshirefootman;

                case "unrelentingtrainee":
                    return cardName.unrelentingtrainee;

                case "murlocscout":
                    return cardName.murlocscout;

                case "ragnarosthefirelord":
                    return cardName.ragnarosthefirelord;

                case "rampage":
                    return cardName.rampage;

                case "zombiechow":
                    return cardName.zombiechow;

                case "thrall":
                    return cardName.thrall;

                case "stoneclawtotem":
                    return cardName.stoneclawtotem;

                case "captainsparrot":
                    return cardName.captainsparrot;

                case "windfuryharpy":
                    return cardName.windfuryharpy;

                case "unrelentingwarrior":
                    return cardName.unrelentingwarrior;

                case "stranglethorntiger":
                    return cardName.stranglethorntiger;

                case "summonarandomsecret":
                    return cardName.summonarandomsecret;

                case "circleofhealing":
                    return cardName.circleofhealing;

                case "snaketrap":
                    return cardName.snaketrap;

                case "cabalshadowpriest":
                    return cardName.cabalshadowpriest;

                case "nerubarweblord":
                    return cardName.nerubarweblord;

                case "upgrade":
                    return cardName.upgrade;

                case "shieldslam":
                    return cardName.shieldslam;

                case "flameburst":
                    return cardName.flameburst;

                case "windfury":
                    return cardName.windfury;

                case "enrage":
                    return cardName.enrage;

                case "natpagle":
                    return cardName.natpagle;

                case "restoreallhealth":
                    return cardName.restoreallhealth;

                case "houndmaster":
                    return cardName.houndmaster;

                case "waterelemental":
                    return cardName.waterelemental;

                case "eaglehornbow":
                    return cardName.eaglehornbow;

                case "gnoll":
                    return cardName.gnoll;

                case "archmageantonidas":
                    return cardName.archmageantonidas;

                case "destroyallheroes":
                    return cardName.destroyallheroes;

                case "chains":
                    return cardName.chains;

                case "wrathofairtotem":
                    return cardName.wrathofairtotem;

                case "killcommand":
                    return cardName.killcommand;

                case "manatidetotem":
                    return cardName.manatidetotem;

                case "daggermastery":
                    return cardName.daggermastery;

                case "drainlife":
                    return cardName.drainlife;

                case "doomsayer":
                    return cardName.doomsayer;

                case "darkscalehealer":
                    return cardName.darkscalehealer;

                case "shadowform":
                    return cardName.shadowform;

                case "frostnova":
                    return cardName.frostnova;

                case "purecold":
                    return cardName.purecold;

                case "mirrorentity":
                    return cardName.mirrorentity;

                case "counterspell":
                    return cardName.counterspell;

                case "mindshatter":
                    return cardName.mindshatter;

                case "magmarager":
                    return cardName.magmarager;

                case "wolfrider":
                    return cardName.wolfrider;

                case "emboldener3000":
                    return cardName.emboldener3000;

                case "polarityshift":
                    return cardName.polarityshift;

                case "gelbinmekkatorque":
                    return cardName.gelbinmekkatorque;

                case "webspinner":
                    return cardName.webspinner;

                case "utherlightbringer":
                    return cardName.utherlightbringer;

                case "innerrage":
                    return cardName.innerrage;

                case "emeralddrake":
                    return cardName.emeralddrake;

                case "forceaitouseheropower":
                    return cardName.forceaitouseheropower;

                case "echoingooze":
                    return cardName.echoingooze;

                case "heroicstrike":
                    return cardName.heroicstrike;

                case "hauntedcreeper":
                    return cardName.hauntedcreeper;

                case "barreltoss":
                    return cardName.barreltoss;

                case "yongwoo":
                    return cardName.yongwoo;

                case "doomhammer":
                    return cardName.doomhammer;

                case "stomp":
                    return cardName.stomp;

                case "spectralknight":
                    return cardName.spectralknight;

                case "tracking":
                    return cardName.tracking;

                case "fireball":
                    return cardName.fireball;

                case "thecoin":
                    return cardName.thecoin;

                case "bootybaybodyguard":
                    return cardName.bootybaybodyguard;

                case "scarletcrusader":
                    return cardName.scarletcrusader;

                case "voodoodoctor":
                    return cardName.voodoodoctor;

                case "shadowbolt":
                    return cardName.shadowbolt;

                case "etherealarcanist":
                    return cardName.etherealarcanist;

                case "succubus":
                    return cardName.succubus;

                case "emperorcobra":
                    return cardName.emperorcobra;

                case "deadlyshot":
                    return cardName.deadlyshot;

                case "reinforce":
                    return cardName.reinforce;

                case "supercharge":
                    return cardName.supercharge;

                case "claw":
                    return cardName.claw;

                case "explosiveshot":
                    return cardName.explosiveshot;

                case "avengingwrath":
                    return cardName.avengingwrath;

                case "riverpawgnoll":
                    return cardName.riverpawgnoll;

                case "sirzeliek":
                    return cardName.sirzeliek;

                case "argentprotector":
                    return cardName.argentprotector;

                case "hiddengnome":
                    return cardName.hiddengnome;

                case "felguard":
                    return cardName.felguard;

                case "northshirecleric":
                    return cardName.northshirecleric;

                case "plague":
                    return cardName.plague;

                case "lepergnome":
                    return cardName.lepergnome;

                case "fireelemental":
                    return cardName.fireelemental;

                case "armorup":
                    return cardName.armorup;

                case "snipe":
                    return cardName.snipe;

                case "southseacaptain":
                    return cardName.southseacaptain;

                case "catform":
                    return cardName.catform;

                case "bite":
                    return cardName.bite;

                case "defiasringleader":
                    return cardName.defiasringleader;

                case "harvestgolem":
                    return cardName.harvestgolem;

                case "kingkrush":
                    return cardName.kingkrush;

                case "aibuddydamageownhero5":
                    return cardName.aibuddydamageownhero5;

                case "healingtotem":
                    return cardName.healingtotem;

                case "ericdodds":
                    return cardName.ericdodds;

                case "demigodsfavor":
                    return cardName.demigodsfavor;

                case "huntersmark":
                    return cardName.huntersmark;

                case "dalaranmage":
                    return cardName.dalaranmage;

                case "twilightdrake":
                    return cardName.twilightdrake;

                case "coldlightoracle":
                    return cardName.coldlightoracle;

                case "shadeofnaxxramas":
                    return cardName.shadeofnaxxramas;

                case "moltengiant":
                    return cardName.moltengiant;

                case "deathbloom":
                    return cardName.deathbloom;

                case "shadowflame":
                    return cardName.shadowflame;

                case "anduinwrynn":
                    return cardName.anduinwrynn;

                case "argentcommander":
                    return cardName.argentcommander;

                case "revealhand":
                    return cardName.revealhand;

                case "arcanemissiles":
                    return cardName.arcanemissiles;

                case "repairbot":
                    return cardName.repairbot;

                case "unstableghoul":
                    return cardName.unstableghoul;

                case "ancientofwar":
                    return cardName.ancientofwar;

                case "stormwindchampion":
                    return cardName.stormwindchampion;

                case "summonapanther":
                    return cardName.summonapanther;

                case "mrbigglesworth":
                    return cardName.mrbigglesworth;

                case "swipe":
                    return cardName.swipe;

                case "aihelperbuddy":
                    return cardName.aihelperbuddy;

                case "hex":
                    return cardName.hex;

                case "ysera":
                    return cardName.ysera;

                case "arcanegolem":
                    return cardName.arcanegolem;

                case "bloodimp":
                    return cardName.bloodimp;

                case "pyroblast":
                    return cardName.pyroblast;

                case "murlocraider":
                    return cardName.murlocraider;

                case "faeriedragon":
                    return cardName.faeriedragon;

                case "sinisterstrike":
                    return cardName.sinisterstrike;

                case "poweroverwhelming":
                    return cardName.poweroverwhelming;

                case "arcaneexplosion":
                    return cardName.arcaneexplosion;

                case "shadowwordpain":
                    return cardName.shadowwordpain;

                case "mill30":
                    return cardName.mill30;

                case "noblesacrifice":
                    return cardName.noblesacrifice;

                case "dreadinfernal":
                    return cardName.dreadinfernal;

                case "naturalize":
                    return cardName.naturalize;

                case "totemiccall":
                    return cardName.totemiccall;

                case "secretkeeper":
                    return cardName.secretkeeper;

                case "dreadcorsair":
                    return cardName.dreadcorsair;

                case "jaws":
                    return cardName.jaws;

                case "forkedlightning":
                    return cardName.forkedlightning;

                case "reincarnate":
                    return cardName.reincarnate;

                case "handofprotection":
                    return cardName.handofprotection;

                case "noththeplaguebringer":
                    return cardName.noththeplaguebringer;

                case "vaporize":
                    return cardName.vaporize;

                case "frostbreath":
                    return cardName.frostbreath;

                case "nozdormu":
                    return cardName.nozdormu;

                case "divinespirit":
                    return cardName.divinespirit;

                case "transcendence":
                    return cardName.transcendence;

                case "armorsmith":
                    return cardName.armorsmith;

                case "murloctidehunter":
                    return cardName.murloctidehunter;

                case "stealcard":
                    return cardName.stealcard;

                case "opponentconcede":
                    return cardName.opponentconcede;

                case "tundrarhino":
                    return cardName.tundrarhino;

                case "summoningportal":
                    return cardName.summoningportal;

                case "hammerofwrath":
                    return cardName.hammerofwrath;

                case "stormwindknight":
                    return cardName.stormwindknight;

                case "freeze":
                    return cardName.freeze;

                case "madbomber":
                    return cardName.madbomber;

                case "consecration":
                    return cardName.consecration;

                case "spectraltrainee":
                    return cardName.spectraltrainee;

                case "boar":
                    return cardName.boar;

                case "knifejuggler":
                    return cardName.knifejuggler;

                case "icebarrier":
                    return cardName.icebarrier;

                case "mechanicaldragonling":
                    return cardName.mechanicaldragonling;

                case "battleaxe":
                    return cardName.battleaxe;

                case "lightsjustice":
                    return cardName.lightsjustice;

                case "lavaburst":
                    return cardName.lavaburst;

                case "mindcontroltech":
                    return cardName.mindcontroltech;

                case "boulderfistogre":
                    return cardName.boulderfistogre;

                case "fireblast":
                    return cardName.fireblast;

                case "priestessofelune":
                    return cardName.priestessofelune;

                case "ancientmage":
                    return cardName.ancientmage;

                case "shadowworddeath":
                    return cardName.shadowworddeath;

                case "ironbeakowl":
                    return cardName.ironbeakowl;

                case "eviscerate":
                    return cardName.eviscerate;

                case "repentance":
                    return cardName.repentance;

                case "understudy":
                    return cardName.understudy;

                case "sunwalker":
                    return cardName.sunwalker;

                case "nagamyrmidon":
                    return cardName.nagamyrmidon;

                case "destroyheropower":
                    return cardName.destroyheropower;

                case "skeletalsmith":
                    return cardName.skeletalsmith;

                case "slam":
                    return cardName.slam;

                case "swordofjustice":
                    return cardName.swordofjustice;

                case "bounce":
                    return cardName.bounce;

                case "shadopanmonk":
                    return cardName.shadopanmonk;

                case "whirlwind":
                    return cardName.whirlwind;

                case "alexstrasza":
                    return cardName.alexstrasza;

                case "silence":
                    return cardName.silence;

                case "rexxar":
                    return cardName.rexxar;

                case "voidwalker":
                    return cardName.voidwalker;

                case "whelp":
                    return cardName.whelp;

                case "flamestrike":
                    return cardName.flamestrike;

                case "rivercrocolisk":
                    return cardName.rivercrocolisk;

                case "stormforgedaxe":
                    return cardName.stormforgedaxe;

                case "snake":
                    return cardName.snake;

                case "shotgunblast":
                    return cardName.shotgunblast;

                case "violetapprentice":
                    return cardName.violetapprentice;

                case "templeenforcer":
                    return cardName.templeenforcer;

                case "ashbringer":
                    return cardName.ashbringer;

                case "impmaster":
                    return cardName.impmaster;

                case "defender":
                    return cardName.defender;

                case "savageroar":
                    return cardName.savageroar;

                case "innervate":
                    return cardName.innervate;

                case "inferno":
                    return cardName.inferno;

                case "falloutslime":
                    return cardName.falloutslime;

                case "earthelemental":
                    return cardName.earthelemental;

                case "facelessmanipulator":
                    return cardName.facelessmanipulator;

                case "mindpocalypse":
                    return cardName.mindpocalypse;

                case "divinefavor":
                    return cardName.divinefavor;

                case "aibuddydestroyminions":
                    return cardName.aibuddydestroyminions;

                case "demolisher":
                    return cardName.demolisher;

                case "sunfuryprotector":
                    return cardName.sunfuryprotector;

                case "dustdevil":
                    return cardName.dustdevil;

                case "powerofthehorde":
                    return cardName.powerofthehorde;

                case "dancingswords":
                    return cardName.dancingswords;

                case "holylight":
                    return cardName.holylight;

                case "feralspirit":
                    return cardName.feralspirit;

                case "raidleader":
                    return cardName.raidleader;

                case "amaniberserker":
                    return cardName.amaniberserker;

                case "ironbarkprotector":
                    return cardName.ironbarkprotector;

                case "bearform":
                    return cardName.bearform;

                case "deathwing":
                    return cardName.deathwing;

                case "stormpikecommando":
                    return cardName.stormpikecommando;

                case "squire":
                    return cardName.squire;

                case "panther":
                    return cardName.panther;

                case "silverbackpatriarch":
                    return cardName.silverbackpatriarch;

                case "bobfitch":
                    return cardName.bobfitch;

                case "gladiatorslongbow":
                    return cardName.gladiatorslongbow;

                case "damage1":
                    return cardName.damage1;
            }

            return cardName.unknown;
        }

        /// <summary>
        /// The get card data.
        /// </summary>
        /// <param name="cardname">
        /// The cardname.
        /// </param>
        /// <returns>
        /// The <see cref="Card"/>.
        /// </returns>
        public Card getCardData(cardName cardname)
        {
            foreach (Card ca in this.cardlist)
            {
                if (ca.name == cardname)
                {
                    return ca;
                }
            }

            return this.unknownCard;
        }

        /// <summary>
        /// The get card data from id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Card"/>.
        /// </returns>
        public Card getCardDataFromID(cardIDEnum id)
        {
            if (this.cardidToCardList.ContainsKey(id))
            {
                return this.cardidToCardList[id];

                // return new Card(cardidToCardList[id]);
            }

            return this.unknownCard;
        }

        /// <summary>
        /// The get sim card.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SimTemplate"/>.
        /// </returns>
        public SimTemplate getSimCard(cardIDEnum id)
        {
            switch (id)
            {
                case cardIDEnum.NEW1_007b:
                    return new Sim_NEW1_007b();


                case cardIDEnum.EX1_613:
                    return new Sim_EX1_613();


                case cardIDEnum.EX1_133:
                    return new Sim_EX1_133();


                case cardIDEnum.NEW1_018:
                    return new Sim_NEW1_018();


                case cardIDEnum.EX1_012:
                    return new Sim_EX1_012();


                case cardIDEnum.EX1_178a:
                    return new Sim_EX1_178a();


                case cardIDEnum.CS2_231:
                    return new Sim_CS2_231();


                case cardIDEnum.CS2_179:
                    return new Sim_CS2_179();


                case cardIDEnum.EX1_244:
                    return new Sim_EX1_244();


                case cardIDEnum.EX1_178b:
                    return new Sim_EX1_178b();


                case cardIDEnum.EX1_573b:
                    return new Sim_EX1_573b();


                case cardIDEnum.NEW1_007a:
                    return new Sim_NEW1_007a();


                case cardIDEnum.EX1_345t:
                    return new Sim_EX1_345t();


                case cardIDEnum.FP1_007t:
                    return new Sim_FP1_007t();


                case cardIDEnum.EX1_025:
                    return new Sim_EX1_025();


                case cardIDEnum.EX1_396:
                    return new Sim_EX1_396();


                case cardIDEnum.NEW1_017:
                    return new Sim_NEW1_017();


                case cardIDEnum.NEW1_008a:
                    return new Sim_NEW1_008a();


                case cardIDEnum.EX1_533:
                    return new Sim_EX1_533();


                case cardIDEnum.EX1_522:
                    return new Sim_EX1_522();


                // case CardDB.cardIDEnum.NAX11_04: return new Sim_NAX11_04();
                case cardIDEnum.NEW1_026:
                    return new Sim_NEW1_026();


                case cardIDEnum.EX1_398:
                    return new Sim_EX1_398();


                // case CardDB.cardIDEnum.NAX4_04: return new Sim_NAX4_04();
                case cardIDEnum.EX1_007:
                    return new Sim_EX1_007();


                case cardIDEnum.CS1_112:
                    return new Sim_CS1_112();

                case cardIDEnum.NEW1_036:
                    return new Sim_NEW1_036();
                case cardIDEnum.EX1_258:
                    return new Sim_EX1_258();
                case cardIDEnum.HERO_01:
                    return new Sim_HERO_01();

                case cardIDEnum.CS2_087:
                    return new Sim_CS2_087();
                case cardIDEnum.DREAM_05:
                    return new Sim_DREAM_05();

                case cardIDEnum.CS2_092:
                    return new Sim_CS2_092();
                case cardIDEnum.CS2_022:
                    return new Sim_CS2_022();
                case cardIDEnum.EX1_046:
                    return new Sim_EX1_046();

                case cardIDEnum.PRO_001b:
                    return new Sim_PRO_001b();

                case cardIDEnum.PRO_001a:
                    return new Sim_PRO_001a();
                case cardIDEnum.CS2_103:
                    return new Sim_CS2_103();
                case cardIDEnum.NEW1_041:
                    return new Sim_NEW1_041();
                case cardIDEnum.EX1_360:
                    return new Sim_EX1_360();
                case cardIDEnum.FP1_023:
                    return new Sim_FP1_023();
                case cardIDEnum.NEW1_038:
                    return new Sim_NEW1_038();
                case cardIDEnum.CS2_009:
                    return new Sim_CS2_009();

                case cardIDEnum.EX1_010:
                    return new Sim_EX1_010();
                case cardIDEnum.CS2_024:
                    return new Sim_CS2_024();

                case cardIDEnum.EX1_565:
                    return new Sim_EX1_565();
                case cardIDEnum.CS2_076:
                    return new Sim_CS2_076();
                case cardIDEnum.FP1_004:
                    return new Sim_FP1_004();

                case cardIDEnum.CS2_162:
                    return new Sim_CS2_162();
                case cardIDEnum.EX1_110t:
                    return new Sim_EX1_110t();

                case cardIDEnum.CS2_181:
                    return new Sim_CS2_181();
                case cardIDEnum.EX1_309:
                    return new Sim_EX1_309();
                case cardIDEnum.EX1_354:
                    return new Sim_EX1_354();
                case cardIDEnum.EX1_023:
                    return new Sim_EX1_023();
                case cardIDEnum.NEW1_034:
                    return new Sim_NEW1_034();
                case cardIDEnum.CS2_003:
                    return new Sim_CS2_003();
                case cardIDEnum.HERO_06:
                    return new Sim_HERO_06();
                case cardIDEnum.CS2_201:
                    return new Sim_CS2_201();
                case cardIDEnum.EX1_508:
                    return new Sim_EX1_508();
                case cardIDEnum.EX1_259:
                    return new Sim_EX1_259();
                case cardIDEnum.EX1_341:
                    return new Sim_EX1_341();
                case cardIDEnum.EX1_103:
                    return new Sim_EX1_103();
                case cardIDEnum.FP1_021:
                    return new Sim_FP1_021();
                case cardIDEnum.EX1_411:
                    return new Sim_EX1_411();

                case cardIDEnum.CS2_053:
                    return new Sim_CS2_053();
                case cardIDEnum.CS2_182:
                    return new Sim_CS2_182();
                case cardIDEnum.CS2_008:
                    return new Sim_CS2_008();
                case cardIDEnum.CS2_233:
                    return new Sim_CS2_233();
                case cardIDEnum.EX1_626:
                    return new Sim_EX1_626();
                case cardIDEnum.EX1_059:
                    return new Sim_EX1_059();
                case cardIDEnum.EX1_334:
                    return new Sim_EX1_334();
                case cardIDEnum.EX1_619:
                    return new Sim_EX1_619();
                case cardIDEnum.NEW1_032:
                    return new Sim_NEW1_032();
                case cardIDEnum.EX1_158t:
                    return new Sim_EX1_158t();
                case cardIDEnum.EX1_006:
                    return new Sim_EX1_006();
                case cardIDEnum.NEW1_031:
                    return new Sim_NEW1_031();

                case cardIDEnum.DREAM_04:
                    return new Sim_DREAM_04();

                case cardIDEnum.EX1_004:
                    return new Sim_EX1_004();

                case cardIDEnum.EX1_095:
                    return new Sim_EX1_095();
                case cardIDEnum.NEW1_007:
                    return new Sim_NEW1_007();
                case cardIDEnum.EX1_275:
                    return new Sim_EX1_275();
                case cardIDEnum.EX1_245:
                    return new Sim_EX1_245();
                case cardIDEnum.EX1_383:
                    return new Sim_EX1_383();
                case cardIDEnum.FP1_016:
                    return new Sim_FP1_016();
                case cardIDEnum.EX1_016t:
                    return new Sim_EX1_016t();
                case cardIDEnum.CS2_125:
                    return new Sim_CS2_125();
                case cardIDEnum.EX1_137:
                    return new Sim_EX1_137();

                case cardIDEnum.DS1_185:
                    return new Sim_DS1_185();
                case cardIDEnum.FP1_010:
                    return new Sim_FP1_010();
                case cardIDEnum.EX1_598:
                    return new Sim_EX1_598();

                case cardIDEnum.EX1_304:
                    return new Sim_EX1_304();
                case cardIDEnum.EX1_302:
                    return new Sim_EX1_302();
                case cardIDEnum.EX1_614t:
                    return new Sim_EX1_614t();
                case cardIDEnum.CS2_108:
                    return new Sim_CS2_108();
                case cardIDEnum.CS2_046:
                    return new Sim_CS2_046();
                case cardIDEnum.EX1_014t:
                    return new Sim_EX1_014t();
                case cardIDEnum.NEW1_005:
                    return new Sim_NEW1_005();
                case cardIDEnum.EX1_062:
                    return new Sim_EX1_062();

                case cardIDEnum.Mekka1:
                    return new Sim_Mekka1();

                case cardIDEnum.tt_010a:
                    return new Sim_tt_010a();

                case cardIDEnum.CS2_072:
                    return new Sim_CS2_072();
                case cardIDEnum.EX1_tk28:
                    return new Sim_EX1_tk28();

                case cardIDEnum.FP1_014:
                    return new Sim_FP1_014();

                case cardIDEnum.EX1_409t:
                    return new Sim_EX1_409t();

                case cardIDEnum.EX1_507:
                    return new Sim_EX1_507();
                case cardIDEnum.EX1_144:
                    return new Sim_EX1_144();
                case cardIDEnum.CS2_038:
                    return new Sim_CS2_038();
                case cardIDEnum.EX1_093:
                    return new Sim_EX1_093();
                case cardIDEnum.CS2_080:
                    return new Sim_CS2_080();
                case cardIDEnum.EX1_005:
                    return new Sim_EX1_005();
                case cardIDEnum.EX1_382:
                    return new Sim_EX1_382();

                case cardIDEnum.CS2_028:
                    return new Sim_CS2_028();

                case cardIDEnum.EX1_538:
                    return new Sim_EX1_538();

                case cardIDEnum.DREAM_02:
                    return new Sim_DREAM_02();
                case cardIDEnum.EX1_581:
                    return new Sim_EX1_581();

                case cardIDEnum.EX1_131t:
                    return new Sim_EX1_131t();
                case cardIDEnum.CS2_147:
                    return new Sim_CS2_147();
                case cardIDEnum.CS1_113:
                    return new Sim_CS1_113();
                case cardIDEnum.CS2_161:
                    return new Sim_CS2_161();
                case cardIDEnum.CS2_031:
                    return new Sim_CS2_031();
                case cardIDEnum.EX1_166b:
                    return new Sim_EX1_166b();
                case cardIDEnum.EX1_066:
                    return new Sim_EX1_066();

                case cardIDEnum.EX1_355:
                    return new Sim_EX1_355();

                case cardIDEnum.EX1_534:
                    return new Sim_EX1_534();
                case cardIDEnum.EX1_162:
                    return new Sim_EX1_162();

                case cardIDEnum.EX1_363:
                    return new Sim_EX1_363();
                case cardIDEnum.EX1_164a:
                    return new Sim_EX1_164a();
                case cardIDEnum.CS2_188:
                    return new Sim_CS2_188();
                case cardIDEnum.EX1_016:
                    return new Sim_EX1_016();
                case cardIDEnum.EX1_603:
                    return new Sim_EX1_603();
                case cardIDEnum.EX1_238:
                    return new Sim_EX1_238();
                case cardIDEnum.EX1_166:
                    return new Sim_EX1_166();
                case cardIDEnum.DS1h_292:
                    return new Sim_DS1h_292();
                case cardIDEnum.DS1_183:
                    return new Sim_DS1_183();
                case cardIDEnum.EX1_076:
                    return new Sim_EX1_076();
                case cardIDEnum.EX1_048:
                    return new Sim_EX1_048();

                case cardIDEnum.FP1_026:
                    return new Sim_FP1_026();
                case cardIDEnum.CS2_074:
                    return new Sim_CS2_074();
                case cardIDEnum.FP1_027:
                    return new Sim_FP1_027();
                case cardIDEnum.EX1_323w:
                    return new Sim_EX1_323w();
                case cardIDEnum.EX1_129:
                    return new Sim_EX1_129();
                case cardIDEnum.EX1_405:
                    return new Sim_EX1_405();
                case cardIDEnum.EX1_317:
                    return new Sim_EX1_317();
                case cardIDEnum.EX1_606:
                    return new Sim_EX1_606();
                case cardIDEnum.FP1_006:
                    return new Sim_FP1_006();
                case cardIDEnum.NEW1_008:
                    return new Sim_NEW1_008();
                case cardIDEnum.CS2_119:
                    return new Sim_CS2_119();

                case cardIDEnum.CS2_121:
                    return new Sim_CS2_121();
                case cardIDEnum.CS1h_001:
                    return new Sim_CS1h_001();
                case cardIDEnum.EX1_tk34:
                    return new Sim_EX1_tk34();
                case cardIDEnum.NEW1_020:
                    return new Sim_NEW1_020();
                case cardIDEnum.CS2_196:
                    return new Sim_CS2_196();
                case cardIDEnum.EX1_312:
                    return new Sim_EX1_312();

                case cardIDEnum.FP1_022:
                    return new Sim_FP1_022();
                case cardIDEnum.EX1_160b:
                    return new Sim_EX1_160b();
                case cardIDEnum.EX1_563:
                    return new Sim_EX1_563();

                case cardIDEnum.FP1_031:
                    return new Sim_FP1_031();

                case cardIDEnum.NEW1_029:
                    return new Sim_NEW1_029();
                case cardIDEnum.CS1_129:
                    return new Sim_CS1_129();
                case cardIDEnum.HERO_03:
                    return new Sim_HERO_03();
                case cardIDEnum.Mekka4t:
                    return new Sim_Mekka4t();
                case cardIDEnum.EX1_158:
                    return new Sim_EX1_158();

                case cardIDEnum.NEW1_025:
                    return new Sim_NEW1_025();
                case cardIDEnum.FP1_012t:
                    return new Sim_FP1_012t();
                case cardIDEnum.EX1_083:
                    return new Sim_EX1_083();
                case cardIDEnum.EX1_295:
                    return new Sim_EX1_295();
                case cardIDEnum.EX1_407:
                    return new Sim_EX1_407();
                case cardIDEnum.NEW1_004:
                    return new Sim_NEW1_004();
                case cardIDEnum.FP1_019:
                    return new Sim_FP1_019();
                case cardIDEnum.PRO_001at:
                    return new Sim_PRO_001at();

                case cardIDEnum.EX1_625t:
                    return new Sim_EX1_625t();
                case cardIDEnum.EX1_014:
                    return new Sim_EX1_014();
                case cardIDEnum.CS2_097:
                    return new Sim_CS2_097();
                case cardIDEnum.EX1_558:
                    return new Sim_EX1_558();

                case cardIDEnum.EX1_tk29:
                    return new Sim_EX1_tk29();
                case cardIDEnum.CS2_186:
                    return new Sim_CS2_186();
                case cardIDEnum.EX1_084:
                    return new Sim_EX1_084();
                case cardIDEnum.NEW1_012:
                    return new Sim_NEW1_012();
                case cardIDEnum.FP1_014t:
                    return new Sim_FP1_014t();
                case cardIDEnum.EX1_578:
                    return new Sim_EX1_578();

                case cardIDEnum.CS2_221:
                    return new Sim_CS2_221();
                case cardIDEnum.EX1_019:
                    return new Sim_EX1_019();

                case cardIDEnum.FP1_019t:
                    return new Sim_FP1_019t();
                case cardIDEnum.EX1_132:
                    return new Sim_EX1_132();
                case cardIDEnum.EX1_284:
                    return new Sim_EX1_284();
                case cardIDEnum.EX1_105:
                    return new Sim_EX1_105();
                case cardIDEnum.NEW1_011:
                    return new Sim_NEW1_011();

                case cardIDEnum.EX1_017:
                    return new Sim_EX1_017();
                case cardIDEnum.EX1_249:
                    return new Sim_EX1_249();

                case cardIDEnum.FP1_002t:
                    return new Sim_FP1_002t();

                case cardIDEnum.EX1_313:
                    return new Sim_EX1_313();

                case cardIDEnum.EX1_155b:
                    return new Sim_EX1_155b();

                case cardIDEnum.NEW1_033:
                    return new Sim_NEW1_033();
                case cardIDEnum.CS2_106:
                    return new Sim_CS2_106();

                case cardIDEnum.FP1_018:
                    return new Sim_FP1_018();
                case cardIDEnum.DS1_233:
                    return new Sim_DS1_233();
                case cardIDEnum.DS1_175:
                    return new Sim_DS1_175();
                case cardIDEnum.NEW1_024:
                    return new Sim_NEW1_024();
                case cardIDEnum.CS2_189:
                    return new Sim_CS2_189();

                case cardIDEnum.NEW1_037:
                    return new Sim_NEW1_037();
                case cardIDEnum.EX1_414:
                    return new Sim_EX1_414();
                case cardIDEnum.EX1_538t:
                    return new Sim_EX1_538t();

                case cardIDEnum.EX1_586:
                    return new Sim_EX1_586();
                case cardIDEnum.EX1_310:
                    return new Sim_EX1_310();
                case cardIDEnum.NEW1_010:
                    return new Sim_NEW1_010();
                case cardIDEnum.EX1_534t:
                    return new Sim_EX1_534t();
                case cardIDEnum.FP1_028:
                    return new Sim_FP1_028();
                case cardIDEnum.EX1_604:
                    return new Sim_EX1_604();
                case cardIDEnum.EX1_160:
                    return new Sim_EX1_160();
                case cardIDEnum.EX1_165t1:
                    return new Sim_EX1_165t1();
                case cardIDEnum.CS2_062:
                    return new Sim_CS2_062();
                case cardIDEnum.CS2_155:
                    return new Sim_CS2_155();
                case cardIDEnum.CS2_213:
                    return new Sim_CS2_213();

                case cardIDEnum.CS2_004:
                    return new Sim_CS2_004();
                case cardIDEnum.CS2_023:
                    return new Sim_CS2_023();
                case cardIDEnum.EX1_164:
                    return new Sim_EX1_164();
                case cardIDEnum.EX1_009:
                    return new Sim_EX1_009();

                case cardIDEnum.FP1_007:
                    return new Sim_FP1_007();

                case cardIDEnum.EX1_345:
                    return new Sim_EX1_345();
                case cardIDEnum.EX1_116:
                    return new Sim_EX1_116();
                case cardIDEnum.EX1_399:
                    return new Sim_EX1_399();
                case cardIDEnum.EX1_587:
                    return new Sim_EX1_587();

                case cardIDEnum.EX1_571:
                    return new Sim_EX1_571();
                case cardIDEnum.EX1_335:
                    return new Sim_EX1_335();
                case cardIDEnum.HERO_08:
                    return new Sim_HERO_08();
                case cardIDEnum.EX1_166a:
                    return new Sim_EX1_166a();

                case cardIDEnum.EX1_finkle:
                    return new Sim_EX1_finkle();

                case cardIDEnum.EX1_164b:
                    return new Sim_EX1_164b();
                case cardIDEnum.EX1_283:
                    return new Sim_EX1_283();
                case cardIDEnum.EX1_339:
                    return new Sim_EX1_339();
                case cardIDEnum.EX1_531:
                    return new Sim_EX1_531();
                case cardIDEnum.EX1_134:
                    return new Sim_EX1_134();
                case cardIDEnum.EX1_350:
                    return new Sim_EX1_350();
                case cardIDEnum.EX1_308:
                    return new Sim_EX1_308();
                case cardIDEnum.CS2_197:
                    return new Sim_CS2_197();
                case cardIDEnum.skele21:
                    return new Sim_skele21();
                case cardIDEnum.FP1_013:
                    return new Sim_FP1_013();
                case cardIDEnum.NEW1_006:
                    return new Sim_NEW1_006();

                case cardIDEnum.EX1_509:
                    return new Sim_EX1_509();
                case cardIDEnum.EX1_612:
                    return new Sim_EX1_612();
                case cardIDEnum.EX1_021:
                    return new Sim_EX1_021();

                case cardIDEnum.CS2_226:
                    return new Sim_CS2_226();
                case cardIDEnum.EX1_608:
                    return new Sim_EX1_608();

                case cardIDEnum.EX1_624:
                    return new Sim_EX1_624();
                case cardIDEnum.EX1_616:
                    return new Sim_EX1_616();
                case cardIDEnum.EX1_008:
                    return new Sim_EX1_008();
                case cardIDEnum.PlaceholderCard:
                    return new Sim_PlaceholderCard();

                case cardIDEnum.EX1_045:
                    return new Sim_EX1_045();
                case cardIDEnum.EX1_015:
                    return new Sim_EX1_015();

                case cardIDEnum.CS2_171:
                    return new Sim_CS2_171();
                case cardIDEnum.CS2_041:
                    return new Sim_CS2_041();
                case cardIDEnum.EX1_128:
                    return new Sim_EX1_128();
                case cardIDEnum.CS2_112:
                    return new Sim_CS2_112();
                case cardIDEnum.HERO_07:
                    return new Sim_HERO_07();
                case cardIDEnum.EX1_412:
                    return new Sim_EX1_412();

                case cardIDEnum.CS2_117:
                    return new Sim_CS2_117();

                case cardIDEnum.EX1_562:
                    return new Sim_EX1_562();
                case cardIDEnum.EX1_055:
                    return new Sim_EX1_055();
                case cardIDEnum.FP1_012:
                    return new Sim_FP1_012();
                case cardIDEnum.EX1_317t:
                    return new Sim_EX1_317t();

                case cardIDEnum.EX1_278:
                    return new Sim_EX1_278();
                case cardIDEnum.CS2_tk1:
                    return new Sim_CS2_tk1();
                case cardIDEnum.EX1_590:
                    return new Sim_EX1_590();
                case cardIDEnum.CS1_130:
                    return new Sim_CS1_130();
                case cardIDEnum.NEW1_008b:
                    return new Sim_NEW1_008b();
                case cardIDEnum.EX1_365:
                    return new Sim_EX1_365();
                case cardIDEnum.CS2_141:
                    return new Sim_CS2_141();
                case cardIDEnum.PRO_001:
                    return new Sim_PRO_001();

                case cardIDEnum.CS2_173:
                    return new Sim_CS2_173();
                case cardIDEnum.CS2_017:
                    return new Sim_CS2_017();

                case cardIDEnum.EX1_392:
                    return new Sim_EX1_392();
                case cardIDEnum.EX1_593:
                    return new Sim_EX1_593();
                case cardIDEnum.EX1_049:
                    return new Sim_EX1_049();
                case cardIDEnum.EX1_002:
                    return new Sim_EX1_002();

                case cardIDEnum.CS2_056:
                    return new Sim_CS2_056();
                case cardIDEnum.EX1_596:
                    return new Sim_EX1_596();
                case cardIDEnum.EX1_136:
                    return new Sim_EX1_136();
                case cardIDEnum.EX1_323:
                    return new Sim_EX1_323();
                case cardIDEnum.CS2_073:
                    return new Sim_CS2_073();

                case cardIDEnum.EX1_001:
                    return new Sim_EX1_001();

                case cardIDEnum.EX1_044:
                    return new Sim_EX1_044();

                case cardIDEnum.Mekka4:
                    return new Sim_Mekka4();
                case cardIDEnum.CS2_142:
                    return new Sim_CS2_142();

                case cardIDEnum.EX1_573:
                    return new Sim_EX1_573();
                case cardIDEnum.FP1_009:
                    return new Sim_FP1_009();
                case cardIDEnum.CS2_050:
                    return new Sim_CS2_050();

                case cardIDEnum.EX1_390:
                    return new Sim_EX1_390();
                case cardIDEnum.EX1_610:
                    return new Sim_EX1_610();
                case cardIDEnum.hexfrog:
                    return new Sim_hexfrog();

                case cardIDEnum.CS2_082:
                    return new Sim_CS2_082();
                case cardIDEnum.NEW1_040:
                    return new Sim_NEW1_040();
                case cardIDEnum.DREAM_01:
                    return new Sim_DREAM_01();
                case cardIDEnum.EX1_595:
                    return new Sim_EX1_595();
                case cardIDEnum.CS2_013:
                    return new Sim_CS2_013();
                case cardIDEnum.CS2_077:
                    return new Sim_CS2_077();
                case cardIDEnum.NEW1_014:
                    return new Sim_NEW1_014();

                case cardIDEnum.GAME_002:
                    return new Sim_GAME_002();
                case cardIDEnum.EX1_165:
                    return new Sim_EX1_165();
                case cardIDEnum.CS2_013t:
                    return new Sim_CS2_013t();

                case cardIDEnum.EX1_tk11:
                    return new Sim_EX1_tk11();
                case cardIDEnum.EX1_591:
                    return new Sim_EX1_591();
                case cardIDEnum.EX1_549:
                    return new Sim_EX1_549();
                case cardIDEnum.CS2_045:
                    return new Sim_CS2_045();
                case cardIDEnum.CS2_237:
                    return new Sim_CS2_237();
                case cardIDEnum.CS2_027:
                    return new Sim_CS2_027();
                case cardIDEnum.CS2_101t:
                    return new Sim_CS2_101t();
                case cardIDEnum.CS2_063:
                    return new Sim_CS2_063();
                case cardIDEnum.EX1_145:
                    return new Sim_EX1_145();

                case cardIDEnum.EX1_110:
                    return new Sim_EX1_110();
                case cardIDEnum.EX1_408:
                    return new Sim_EX1_408();
                case cardIDEnum.EX1_544:
                    return new Sim_EX1_544();
                case cardIDEnum.CS2_151:
                    return new Sim_CS2_151();
                case cardIDEnum.CS2_088:
                    return new Sim_CS2_088();
                case cardIDEnum.EX1_057:
                    return new Sim_EX1_057();
                case cardIDEnum.FP1_020:
                    return new Sim_FP1_020();
                case cardIDEnum.CS2_169:
                    return new Sim_CS2_169();
                case cardIDEnum.EX1_573t:
                    return new Sim_EX1_573t();
                case cardIDEnum.EX1_323h:
                    return new Sim_EX1_323h();
                case cardIDEnum.EX1_tk9:
                    return new Sim_EX1_tk9();

                case cardIDEnum.CS2_037:
                    return new Sim_CS2_037();
                case cardIDEnum.CS2_007:
                    return new Sim_CS2_007();

                case cardIDEnum.CS2_227:
                    return new Sim_CS2_227();

                case cardIDEnum.NEW1_003:
                    return new Sim_NEW1_003();
                case cardIDEnum.GAME_006:
                    return new Sim_GAME_006();
                case cardIDEnum.EX1_320:
                    return new Sim_EX1_320();
                case cardIDEnum.EX1_097:
                    return new Sim_EX1_097();
                case cardIDEnum.tt_004:
                    return new Sim_tt_004();

                case cardIDEnum.EX1_096:
                    return new Sim_EX1_096();

                case cardIDEnum.EX1_126:
                    return new Sim_EX1_126();
                case cardIDEnum.EX1_577:
                    return new Sim_EX1_577();
                case cardIDEnum.EX1_319:
                    return new Sim_EX1_319();
                case cardIDEnum.EX1_611:
                    return new Sim_EX1_611();
                case cardIDEnum.CS2_146:
                    return new Sim_CS2_146();
                case cardIDEnum.EX1_154b:
                    return new Sim_EX1_154b();
                case cardIDEnum.skele11:
                    return new Sim_skele11();
                case cardIDEnum.EX1_165t2:
                    return new Sim_EX1_165t2();
                case cardIDEnum.CS2_172:
                    return new Sim_CS2_172();
                case cardIDEnum.CS2_114:
                    return new Sim_CS2_114();
                case cardIDEnum.CS1_069:
                    return new Sim_CS1_069();

                case cardIDEnum.EX1_173:
                    return new Sim_EX1_173();
                case cardIDEnum.CS1_042:
                    return new Sim_CS1_042();

                case cardIDEnum.EX1_506a:
                    return new Sim_EX1_506a();
                case cardIDEnum.EX1_298:
                    return new Sim_EX1_298();
                case cardIDEnum.CS2_104:
                    return new Sim_CS2_104();
                case cardIDEnum.FP1_001:
                    return new Sim_FP1_001();
                case cardIDEnum.HERO_02:
                    return new Sim_HERO_02();

                case cardIDEnum.CS2_051:
                    return new Sim_CS2_051();
                case cardIDEnum.NEW1_016:
                    return new Sim_NEW1_016();

                case cardIDEnum.EX1_033:
                    return new Sim_EX1_033();

                case cardIDEnum.EX1_028:
                    return new Sim_EX1_028();

                case cardIDEnum.EX1_621:
                    return new Sim_EX1_621();
                case cardIDEnum.EX1_554:
                    return new Sim_EX1_554();
                case cardIDEnum.EX1_091:
                    return new Sim_EX1_091();
                case cardIDEnum.FP1_017:
                    return new Sim_FP1_017();
                case cardIDEnum.EX1_409:
                    return new Sim_EX1_409();

                case cardIDEnum.EX1_410:
                    return new Sim_EX1_410();

                case cardIDEnum.CS2_039:
                    return new Sim_CS2_039();

                case cardIDEnum.EX1_557:
                    return new Sim_EX1_557();

                case cardIDEnum.DS1_070:
                    return new Sim_DS1_070();
                case cardIDEnum.CS2_033:
                    return new Sim_CS2_033();
                case cardIDEnum.EX1_536:
                    return new Sim_EX1_536();

                case cardIDEnum.EX1_559:
                    return new Sim_EX1_559();
                case cardIDEnum.CS2_052:
                    return new Sim_CS2_052();
                case cardIDEnum.EX1_539:
                    return new Sim_EX1_539();
                case cardIDEnum.EX1_575:
                    return new Sim_EX1_575();
                case cardIDEnum.CS2_083b:
                    return new Sim_CS2_083b();
                case cardIDEnum.CS2_061:
                    return new Sim_CS2_061();
                case cardIDEnum.NEW1_021:
                    return new Sim_NEW1_021();
                case cardIDEnum.DS1_055:
                    return new Sim_DS1_055();
                case cardIDEnum.EX1_625:
                    return new Sim_EX1_625();
                case cardIDEnum.CS2_026:
                    return new Sim_CS2_026();

                case cardIDEnum.EX1_294:
                    return new Sim_EX1_294();
                case cardIDEnum.EX1_287:
                    return new Sim_EX1_287();

                case cardIDEnum.EX1_625t2:
                    return new Sim_EX1_625t2();
                case cardIDEnum.CS2_118:
                    return new Sim_CS2_118();
                case cardIDEnum.CS2_124:
                    return new Sim_CS2_124();
                case cardIDEnum.Mekka3:
                    return new Sim_Mekka3();

                case cardIDEnum.EX1_112:
                    return new Sim_EX1_112();
                case cardIDEnum.FP1_011:
                    return new Sim_FP1_011();

                case cardIDEnum.HERO_04:
                    return new Sim_HERO_04();
                case cardIDEnum.EX1_607:
                    return new Sim_EX1_607();
                case cardIDEnum.DREAM_03:
                    return new Sim_DREAM_03();

                case cardIDEnum.FP1_003:
                    return new Sim_FP1_003();
                case cardIDEnum.CS2_105:
                    return new Sim_CS2_105();
                case cardIDEnum.FP1_002:
                    return new Sim_FP1_002();
                case cardIDEnum.EX1_567:
                    return new Sim_EX1_567();
                case cardIDEnum.FP1_008:
                    return new Sim_FP1_008();
                case cardIDEnum.DS1_184:
                    return new Sim_DS1_184();
                case cardIDEnum.CS2_029:
                    return new Sim_CS2_029();
                case cardIDEnum.GAME_005:
                    return new Sim_GAME_005();
                case cardIDEnum.CS2_187:
                    return new Sim_CS2_187();
                case cardIDEnum.EX1_020:
                    return new Sim_EX1_020();

                case cardIDEnum.EX1_011:
                    return new Sim_EX1_011();
                case cardIDEnum.CS2_057:
                    return new Sim_CS2_057();
                case cardIDEnum.EX1_274:
                    return new Sim_EX1_274();
                case cardIDEnum.EX1_306:
                    return new Sim_EX1_306();

                case cardIDEnum.EX1_170:
                    return new Sim_EX1_170();
                case cardIDEnum.EX1_617:
                    return new Sim_EX1_617();

                case cardIDEnum.CS2_101:
                    return new Sim_CS2_101();
                case cardIDEnum.FP1_015:
                    return new Sim_FP1_015();

                case cardIDEnum.CS2_005:
                    return new Sim_CS2_005();
                case cardIDEnum.EX1_537:
                    return new Sim_EX1_537();
                case cardIDEnum.EX1_384:
                    return new Sim_EX1_384();
                case cardIDEnum.EX1_362:
                    return new Sim_EX1_362();

                case cardIDEnum.EX1_301:
                    return new Sim_EX1_301();
                case cardIDEnum.CS2_235:
                    return new Sim_CS2_235();

                case cardIDEnum.EX1_029:
                    return new Sim_EX1_029();
                case cardIDEnum.CS2_042:
                    return new Sim_CS2_042();
                case cardIDEnum.EX1_155a:
                    return new Sim_EX1_155a();
                case cardIDEnum.CS2_102:
                    return new Sim_CS2_102();
                case cardIDEnum.EX1_609:
                    return new Sim_EX1_609();
                case cardIDEnum.NEW1_027:
                    return new Sim_NEW1_027();

                case cardIDEnum.EX1_165a:
                    return new Sim_EX1_165a();
                case cardIDEnum.EX1_570:
                    return new Sim_EX1_570();
                case cardIDEnum.EX1_131:
                    return new Sim_EX1_131();
                case cardIDEnum.EX1_556:
                    return new Sim_EX1_556();
                case cardIDEnum.EX1_543:
                    return new Sim_EX1_543();

                case cardIDEnum.NEW1_009:
                    return new Sim_NEW1_009();
                case cardIDEnum.EX1_100:
                    return new Sim_EX1_100();
                case cardIDEnum.EX1_573a:
                    return new Sim_EX1_573a();
                case cardIDEnum.CS2_084:
                    return new Sim_CS2_084();
                case cardIDEnum.EX1_582:
                    return new Sim_EX1_582();
                case cardIDEnum.EX1_043:
                    return new Sim_EX1_043();
                case cardIDEnum.EX1_050:
                    return new Sim_EX1_050();

                case cardIDEnum.FP1_005:
                    return new Sim_FP1_005();
                case cardIDEnum.EX1_620:
                    return new Sim_EX1_620();
                case cardIDEnum.EX1_303:
                    return new Sim_EX1_303();
                case cardIDEnum.HERO_09:
                    return new Sim_HERO_09();
                case cardIDEnum.EX1_067:
                    return new Sim_EX1_067();

                case cardIDEnum.EX1_277:
                    return new Sim_EX1_277();
                case cardIDEnum.Mekka2:
                    return new Sim_Mekka2();
                case cardIDEnum.FP1_024:
                    return new Sim_FP1_024();
                case cardIDEnum.FP1_030:
                    return new Sim_FP1_030();

                case cardIDEnum.EX1_178:
                    return new Sim_EX1_178();
                case cardIDEnum.CS2_222:
                    return new Sim_CS2_222();
                case cardIDEnum.EX1_160a:
                    return new Sim_EX1_160a();
                case cardIDEnum.CS2_012:
                    return new Sim_CS2_012();
                case cardIDEnum.EX1_246:
                    return new Sim_EX1_246();
                case cardIDEnum.EX1_572:
                    return new Sim_EX1_572();
                case cardIDEnum.EX1_089:
                    return new Sim_EX1_089();
                case cardIDEnum.CS2_059:
                    return new Sim_CS2_059();
                case cardIDEnum.EX1_279:
                    return new Sim_EX1_279();
                case cardIDEnum.CS2_168:
                    return new Sim_CS2_168();
                case cardIDEnum.tt_010:
                    return new Sim_tt_010();
                case cardIDEnum.NEW1_023:
                    return new Sim_NEW1_023();
                case cardIDEnum.CS2_075:
                    return new Sim_CS2_075();
                case cardIDEnum.EX1_316:
                    return new Sim_EX1_316();
                case cardIDEnum.CS2_025:
                    return new Sim_CS2_025();
                case cardIDEnum.CS2_234:
                    return new Sim_CS2_234();
                case cardIDEnum.EX1_130:
                    return new Sim_EX1_130();
                case cardIDEnum.CS2_064:
                    return new Sim_CS2_064();
                case cardIDEnum.EX1_161:
                    return new Sim_EX1_161();
                case cardIDEnum.CS2_049:
                    return new Sim_CS2_049();
                case cardIDEnum.EX1_154:
                    return new Sim_EX1_154();
                case cardIDEnum.EX1_080:
                    return new Sim_EX1_080();
                case cardIDEnum.NEW1_022:
                    return new Sim_NEW1_022();
                case cardIDEnum.EX1_251:
                    return new Sim_EX1_251();
                case cardIDEnum.FP1_025:
                    return new Sim_FP1_025();
                case cardIDEnum.EX1_371:
                    return new Sim_EX1_371();
                case cardIDEnum.CS2_mirror:
                    return new Sim_CS2_mirror();
                case cardIDEnum.EX1_594:
                    return new Sim_EX1_594();
                case cardIDEnum.EX1_560:
                    return new Sim_EX1_560();
                case cardIDEnum.CS2_236:
                    return new Sim_CS2_236();
                case cardIDEnum.EX1_402:
                    return new Sim_EX1_402();
                case cardIDEnum.EX1_506:
                    return new Sim_EX1_506();
                case cardIDEnum.DS1_178:
                    return new Sim_DS1_178();
                case cardIDEnum.EX1_315:
                    return new Sim_EX1_315();
                case cardIDEnum.CS2_094:
                    return new Sim_CS2_094();
                case cardIDEnum.NEW1_040t:
                    return new Sim_NEW1_040t();
                case cardIDEnum.CS2_131:
                    return new Sim_CS2_131();
                case cardIDEnum.EX1_082:
                    return new Sim_EX1_082();
                case cardIDEnum.CS2_093:
                    return new Sim_CS2_093();
                case cardIDEnum.CS2_boar:
                    return new Sim_CS2_boar();
                case cardIDEnum.NEW1_019:
                    return new Sim_NEW1_019();
                case cardIDEnum.EX1_289:
                    return new Sim_EX1_289();
                case cardIDEnum.EX1_025t:
                    return new Sim_EX1_025t();
                case cardIDEnum.EX1_398t:
                    return new Sim_EX1_398t();
                case cardIDEnum.CS2_091:
                    return new Sim_CS2_091();
                case cardIDEnum.EX1_241:
                    return new Sim_EX1_241();
                case cardIDEnum.EX1_085:
                    return new Sim_EX1_085();
                case cardIDEnum.CS2_200:
                    return new Sim_CS2_200();
                case cardIDEnum.CS2_034:
                    return new Sim_CS2_034();
                case cardIDEnum.EX1_583:
                    return new Sim_EX1_583();
                case cardIDEnum.EX1_584:
                    return new Sim_EX1_584();
                case cardIDEnum.EX1_155:
                    return new Sim_EX1_155();
                case cardIDEnum.EX1_622:
                    return new Sim_EX1_622();
                case cardIDEnum.CS2_203:
                    return new Sim_CS2_203();
                case cardIDEnum.EX1_124:
                    return new Sim_EX1_124();
                case cardIDEnum.EX1_379:
                    return new Sim_EX1_379();
                case cardIDEnum.EX1_032:
                    return new Sim_EX1_032();
                case cardIDEnum.EX1_391:
                    return new Sim_EX1_391();
                case cardIDEnum.EX1_366:
                    return new Sim_EX1_366();
                case cardIDEnum.EX1_400:
                    return new Sim_EX1_400();
                case cardIDEnum.EX1_614:
                    return new Sim_EX1_614();
                case cardIDEnum.EX1_561:
                    return new Sim_EX1_561();
                case cardIDEnum.EX1_332:
                    return new Sim_EX1_332();
                case cardIDEnum.HERO_05:
                    return new Sim_HERO_05();
                case cardIDEnum.CS2_065:
                    return new Sim_CS2_065();
                case cardIDEnum.ds1_whelptoken:
                    return new Sim_ds1_whelptoken();
                case cardIDEnum.CS2_032:
                    return new Sim_CS2_032();
                case cardIDEnum.CS2_120:
                    return new Sim_CS2_120();
                case cardIDEnum.EX1_247:
                    return new Sim_EX1_247();
                case cardIDEnum.EX1_154a:
                    return new Sim_EX1_154a();
                case cardIDEnum.EX1_554t:
                    return new Sim_EX1_554t();
                case cardIDEnum.NEW1_026t:
                    return new Sim_NEW1_026t();
                case cardIDEnum.EX1_623:
                    return new Sim_EX1_623();
                case cardIDEnum.EX1_383t:
                    return new Sim_EX1_383t();
                case cardIDEnum.EX1_597:
                    return new Sim_EX1_597();
                case cardIDEnum.EX1_130a:
                    return new Sim_EX1_130a();
                case cardIDEnum.CS2_011:
                    return new Sim_CS2_011();
                case cardIDEnum.EX1_169:
                    return new Sim_EX1_169();
                case cardIDEnum.EX1_tk33:
                    return new Sim_EX1_tk33();
                case cardIDEnum.EX1_250:
                    return new Sim_EX1_250();
                case cardIDEnum.EX1_564:
                    return new Sim_EX1_564();
                case cardIDEnum.EX1_349:
                    return new Sim_EX1_349();
                case cardIDEnum.EX1_102:
                    return new Sim_EX1_102();
                case cardIDEnum.EX1_058:
                    return new Sim_EX1_058();
                case cardIDEnum.EX1_243:
                    return new Sim_EX1_243();
                case cardIDEnum.PRO_001c:
                    return new Sim_PRO_001c();
                case cardIDEnum.EX1_116t:
                    return new Sim_EX1_116t();
                case cardIDEnum.FP1_029:
                    return new Sim_FP1_029();
                case cardIDEnum.CS2_089:
                    return new Sim_CS2_089();
                case cardIDEnum.EX1_248:
                    return new Sim_EX1_248();
                case cardIDEnum.CS2_122:
                    return new Sim_CS2_122();
                case cardIDEnum.EX1_393:
                    return new Sim_EX1_393();
                case cardIDEnum.CS2_232:
                    return new Sim_CS2_232();
                case cardIDEnum.EX1_165b:
                    return new Sim_EX1_165b();
                case cardIDEnum.NEW1_030:
                    return new Sim_NEW1_030();
                case cardIDEnum.CS2_150:
                    return new Sim_CS2_150();
                case cardIDEnum.CS2_152:
                    return new Sim_CS2_152();
                case cardIDEnum.EX1_160t:
                    return new Sim_EX1_160t();
                case cardIDEnum.CS2_127:
                    return new Sim_CS2_127();
                case cardIDEnum.DS1_188:
                    return new Sim_DS1_188();
            }

            return new SimTemplate();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The enum creator.
        /// </summary>
        private void enumCreator()
        {
            // call this, if carddb.txt was changed, to get latest public enum cardIDEnum
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
                if (namelist.Contains(cardid))
                {
                    continue;
                }

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

            // simcard creator:
            Helpfunctions.Instance.logg("public SimTemplate getSimCard(cardIDEnum id)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg(
                    "if(id == CardDB.cardIDEnum." + cardid + ") return new Sim_" + cardid + "();");
            }

            Helpfunctions.Instance.logg("return new SimTemplate();");
            Helpfunctions.Instance.logg("}");
        }

        /// <summary>
        ///     The set additional data.
        /// </summary>
        private void setAdditionalData()
        {
            PenalityManager pen = PenalityManager.Instance;

            foreach (Card c in this.cardlist)
            {
                if (pen.cardDrawBattleCryDatabase.ContainsKey(c.name))
                {
                    c.isCarddraw = pen.cardDrawBattleCryDatabase[c.name];
                }

                if (pen.DamageTargetSpecialDatabase.ContainsKey(c.name))
                {
                    c.damagesTargetWithSpecial = true;
                }

                if (pen.DamageTargetDatabase.ContainsKey(c.name))
                {
                    c.damagesTarget = true;
                }

                if (pen.priorityTargets.ContainsKey(c.name))
                {
                    c.targetPriority = pen.priorityTargets[c.name];
                }

                if (pen.specialMinions.ContainsKey(c.name))
                {
                    c.isSpecialMinion = true;
                }
            }
        }

        #endregion

        /// <summary>
        ///     The card.
        /// </summary>
        public class Card
        {
            // public string CardID = "";

            // public string description = "";
            #region Fields

            /// <summary>
            ///     The adjacent buff.
            /// </summary>
            public bool AdjacentBuff = false;

            /// <summary>
            ///     The attack.
            /// </summary>
            public int Attack = 0;

            /// <summary>
            ///     The aura.
            /// </summary>
            public bool Aura = false;

            /// <summary>
            ///     The charge.
            /// </summary>
            public bool Charge = false;

            /// <summary>
            ///     The combo.
            /// </summary>
            public bool Combo = false;

            /// <summary>
            ///     The durability.
            /// </summary>
            public int Durability = 0; // for weapons

            /// <summary>
            ///     The elite.
            /// </summary>
            public bool Elite = false;

            /// <summary>
            ///     The enrage.
            /// </summary>
            public bool Enrage = false;

            /// <summary>
            ///     The freeze.
            /// </summary>
            public bool Freeze = false;

            /// <summary>
            ///     The grant charge.
            /// </summary>
            public bool GrantCharge = false;

            /// <summary>
            ///     The heal target.
            /// </summary>
            public bool HealTarget = false;

            /// <summary>
            ///     The health.
            /// </summary>
            public int Health = 0;

            /// <summary>
            ///     The morph.
            /// </summary>
            public bool Morph = false;

            /// <summary>
            ///     The recall.
            /// </summary>
            public bool Recall = false;

            /// <summary>
            ///     The secret.
            /// </summary>
            public bool Secret = false;

            /// <summary>
            ///     The shield.
            /// </summary>
            public bool Shield = false;

            /// <summary>
            ///     The silence.
            /// </summary>
            public bool Silence = false;

            /// <summary>
            ///     The spellpower.
            /// </summary>
            public bool Spellpower = false;

            /// <summary>
            ///     The stealth.
            /// </summary>
            public bool Stealth = false;

            /// <summary>
            ///     The battlecry.
            /// </summary>
            public bool battlecry = false;

            /// <summary>
            ///     The card i denum.
            /// </summary>
            public cardIDEnum cardIDenum = cardIDEnum.None;

            /// <summary>
            ///     The choice.
            /// </summary>
            public bool choice = false;

            /// <summary>
            ///     The cost.
            /// </summary>
            public int cost = 0;

            /// <summary>
            ///     The damages target.
            /// </summary>
            public bool damagesTarget = false;

            /// <summary>
            ///     The damages target with special.
            /// </summary>
            public bool damagesTargetWithSpecial = false;

            /// <summary>
            ///     The deathrattle.
            /// </summary>
            public bool deathrattle = false;

            /// <summary>
            ///     The immune to spellpowerg.
            /// </summary>
            public bool immuneToSpellpowerg = false;

            /// <summary>
            ///     The immune while attacking.
            /// </summary>
            public bool immuneWhileAttacking = false;

            /// <summary>
            ///     The is carddraw.
            /// </summary>
            public int isCarddraw = 0;

            /// <summary>
            ///     The is special minion.
            /// </summary>
            public bool isSpecialMinion = false;

            /// <summary>
            ///     The is token.
            /// </summary>
            public bool isToken = false;

            /// <summary>
            ///     The name.
            /// </summary>
            public cardName name = cardName.unknown;

            // playRequirements, reqID= siehe PlayErrors->ErrorType
            /// <summary>
            ///     The need empty places for playing.
            /// </summary>
            public int needEmptyPlacesForPlaying = 0;

            /// <summary>
            ///     The need min number of enemy.
            /// </summary>
            public int needMinNumberOfEnemy = 0;

            /// <summary>
            ///     The need min total minions.
            /// </summary>
            public int needMinTotalMinions = 0;

            /// <summary>
            ///     The need minions cap if available.
            /// </summary>
            public int needMinionsCapIfAvailable = 0;

            /// <summary>
            ///     The need race for playing.
            /// </summary>
            public int needRaceForPlaying = 0;

            /// <summary>
            ///     The need with max attack value of.
            /// </summary>
            public int needWithMaxAttackValueOf = 0;

            /// <summary>
            ///     The need with min attack value of.
            /// </summary>
            public int needWithMinAttackValueOf = 0;

            /// <summary>
            ///     The one turn effect.
            /// </summary>
            public bool oneTurnEffect = false;

            // additional data

            /// <summary>
            ///     The playrequires.
            /// </summary>
            public List<ErrorType2> playrequires;

            /// <summary>
            ///     The poisionous.
            /// </summary>
            public bool poisionous = false;

            /// <summary>
            ///     The race.
            /// </summary>
            public int race = 0;

            /// <summary>
            ///     The rarity.
            /// </summary>
            public int rarity = 0;

            /// <summary>
            ///     The recall value.
            /// </summary>
            public int recallValue = 0;

            /// <summary>
            ///     The sim_card.
            /// </summary>
            public SimTemplate sim_card;

            /// <summary>
            ///     The spellpowervalue.
            /// </summary>
            public int spellpowervalue = 0;

            /// <summary>
            ///     The tank.
            /// </summary>
            public bool tank = false;

            /// <summary>
            ///     The target.
            /// </summary>
            public bool target = false;

            /// <summary>
            ///     The target priority.
            /// </summary>
            public int targetPriority = 0;

            /// <summary>
            ///     The type.
            /// </summary>
            public cardtype type = cardtype.NONE;

            /// <summary>
            ///     The windfury.
            /// </summary>
            public bool windfury = false;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initialisiert eine neue Instanz der <see cref="Card"/> Klasse. 
            ///     Initializes a new instance of the <see cref="Card"/> class.
            /// </summary>
            public Card()
            {
                this.playrequires = new List<ErrorType2>();
            }

            /// <summary>
            /// Initialisiert eine neue Instanz der <see cref="Card"/> Klasse. 
            /// Initializes a new instance of the <see cref="Card"/> class.
            /// </summary>
            /// <param name="c">
            /// The c.
            /// </param>
            public Card(Card c)
            {
                // this.entityID = c.entityID;
                this.rarity = c.rarity;
                this.AdjacentBuff = c.AdjacentBuff;
                this.Attack = c.Attack;
                this.Aura = c.Aura;
                this.battlecry = c.battlecry;

                // this.CardID = c.CardID;
                this.Charge = c.Charge;
                this.choice = c.choice;
                this.Combo = c.Combo;
                this.cost = c.cost;
                this.deathrattle = c.deathrattle;

                // this.description = c.description;
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

                // this.targettext = c.targettext;
                this.type = c.type;
                this.windfury = c.windfury;
                this.cardIDenum = c.cardIDenum;
                this.sim_card = c.sim_card;
                this.isToken = c.isToken;
            }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// The calculate mana cost.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <returns>
            /// The <see cref="int"/>.
            /// </returns>
            public int calculateManaCost(Playfield p)
            {
                // calculates the mana from orginal mana, needed for back-to hand effects
                int retval = this.cost;
                int offset = 0;

                if (this.type == cardtype.MOB)
                {
                    offset += p.soeldnerDerVenture * 3;

                    offset += p.managespenst;

                    int temp = -p.startedWithbeschwoerungsportal * 2;
                    if (retval + temp <= 0)
                    {
                        temp = -retval + 1;
                    }

                    offset = offset + temp;

                    if (p.mobsplayedThisTurn == 0)
                    {
                        offset -= p.winzigebeschwoererin;
                    }

                    if (this.battlecry)
                    {
                        offset += p.nerubarweblord * 2;
                    }
                }

                if (this.type == cardtype.SPELL)
                {
                    // if the number of zauberlehrlings change
                    offset -= p.anzOwnsorcerersapprentice;
                    if (p.playedPreparation)
                    {
                        // if the number of zauberlehrlings change
                        offset -= 3;
                    }
                }

                switch (this.name)
                {
                    case cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack;
                        break;
                    case cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                        break;
                    case cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count;
                        break;
                    case cardName.moltengiant:
                        retval = retval + offset - p.ownHero.Hp;
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

            /// <summary>
            /// The canplay card.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <param name="manacost">
            /// The manacost.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool canplayCard(Playfield p, int manacost)
            {
                // is playrequirement?
                bool haveToDoRequires = this.isRequirementInList(ErrorType2.REQ_TARGET_TO_PLAY);
                bool retval = true;

                // cant play if i have to few mana
                if (p.mana < this.getManaCost(p, manacost))
                {
                    return false;
                }

                // cant play mob, if i have allready 7 mininos
                if (this.type == cardtype.MOB && p.ownMinions.Count >= 7)
                {
                    return false;
                }

                if (this.isRequirementInList(ErrorType2.REQ_MINIMUM_ENEMY_MINIONS))
                {
                    if (p.enemyMinions.Count < this.needMinNumberOfEnemy)
                    {
                        return false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_NUM_MINION_SLOTS))
                {
                    if (p.ownMinions.Count > 7 - this.needEmptyPlacesForPlaying)
                    {
                        return false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_WEAPON_EQUIPPED))
                {
                    if (p.ownWeaponName == cardName.unknown)
                    {
                        return false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_MINIMUM_TOTAL_MINIONS))
                {
                    if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count)
                    {
                        return false;
                    }
                }

                if (haveToDoRequires)
                {
                    if (this.getTargetsForCard(p).Count == 0)
                    {
                        return false;
                    }

                    // it requires a target-> return false if 
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_IF_AVAILABLE)
                    && this.isRequirementInList(ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE))
                {
                    if (this.getTargetsForCard(p).Count >= 1 && p.ownMinions.Count > 7 - this.needMinionsCapIfAvailable)
                    {
                        return false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY))
                {
                    int difftotem = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.name == cardName.healingtotem || m.name == cardName.wrathofairtotem
                            || m.name == cardName.searingtotem || m.name == cardName.stoneclawtotem)
                        {
                            difftotem++;
                        }
                    }

                    if (difftotem == 4)
                    {
                        return false;
                    }
                }

                if (this.Secret)
                {
                    if (p.ownSecretsIDList.Contains(this.cardIDenum))
                    {
                        return false;
                    }

                    if (p.ownSecretsIDList.Count >= 5)
                    {
                        return false;
                    }
                }

                return true;
            }

            /// <summary>
            /// The get mana cost.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <param name="currentcost">
            /// The currentcost.
            /// </param>
            /// <returns>
            /// The <see cref="int"/>.
            /// </returns>
            public int getManaCost(Playfield p, int currentcost)
            {
                // calculates mana from current mana
                int retval = currentcost;

                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase the manacosts of others ##############################
                // Manacosts changes with soeldner der venture co.
                if (p.soeldnerDerVenture != p.startedWithsoeldnerDerVenture && this.type == cardtype.MOB)
                {
                    offset += (p.soeldnerDerVenture - p.startedWithsoeldnerDerVenture) * 3;
                }

                // Manacosts changes with mana-ghost
                if (p.managespenst != p.startedWithManagespenst && this.type == cardtype.MOB)
                {
                    offset += p.managespenst - p.startedWithManagespenst;
                }

                if (this.battlecry && p.nerubarweblord != p.startedWithnerubarweblord && this.type == cardtype.MOB)
                {
                    offset += (p.nerubarweblord - p.startedWithnerubarweblord) * 2;
                }

                // CARDS that decrease the manacosts of others ##############################

                // Manacosts changes with the summoning-portal >_>
                if (p.startedWithbeschwoerungsportal != p.beschwoerungsportal && this.type == cardtype.MOB)
                {
                    // cant lower the mana to 0
                    int temp = (p.startedWithbeschwoerungsportal - p.beschwoerungsportal) * 2;
                    if (retval + temp <= 0)
                    {
                        temp = -retval + 1;
                    }

                    offset = offset + temp;
                }

                // Manacosts changes with the pint-sized summoner
                if (p.winzigebeschwoererin >= 1 && p.mobsplayedThisTurn >= 1 && p.startedWithMobsPlayedThisTurn == 0
                    && this.type == cardtype.MOB)
                {
                    // if we start oure calculations with 0 mobs played, then the cardcost are 1 mana to low in the further calculations (with the little summoner on field)
                    offset += p.winzigebeschwoererin;
                }

                if (p.mobsplayedThisTurn == 0 && p.winzigebeschwoererin <= p.startedWithWinzigebeschwoererin
                    && this.type == cardtype.MOB)
                {
                    // one pint-sized summoner got killed, before we played the first mob -> the manacost are higher of all mobs
                    offset += p.startedWithWinzigebeschwoererin - p.winzigebeschwoererin;
                }

                // Manacosts changes with the zauberlehrling summoner
                if (p.anzOwnsorcerersapprentice != p.anzOwnsorcerersapprenticeStarted && this.type == cardtype.SPELL)
                {
                    // if the number of zauberlehrlings change
                    offset += p.anzOwnsorcerersapprenticeStarted - p.anzOwnsorcerersapprentice;
                }

                // manacosts are lowered, after we played preparation
                if (p.playedPreparation && this.type == cardtype.SPELL)
                {
                    // if the number of zauberlehrlings change
                    offset -= 3;
                }

                switch (this.name)
                {
                    case cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack + p.ownWeaponAttackStarted;

                        // if weapon attack change we change manacost
                        break;
                    case cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted;
                        break;
                    case cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count + p.ownCardsCountStarted;
                        break;
                    case cardName.moltengiant:
                        retval = retval + offset - p.ownHero.Hp + p.ownHeroHpStarted;
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

            /// <summary>
            /// The get targets for card.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <returns>
            /// The <see cref="List"/>.
            /// </returns>
            public List<Minion> getTargetsForCard(Playfield p)
            {
                // todo make it faster!! 
                // todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++)
                {
                    ownMins[i] = false;
                }

                for (int i = 0; i < enemyMins.Length; i++)
                {
                    enemyMins[i] = false;
                }

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0)
                {
                    return retval;
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_TO_PLAY)
                    || this.isRequirementInList(ErrorType2.REQ_NONSELF_TARGET)
                    || this.isRequirementInList(ErrorType2.REQ_TARGET_IF_AVAILABLE)
                    || this.isRequirementInList(ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)
                            && (m.name == cardName.faeriedragon || m.name == cardName.laughingsister
                                || m.name == cardName.spectralknight))
                        {
                            continue;
                        }

                        ownMins[k] = true;
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)
                             && (m.name == cardName.faeriedragon || m.name == cardName.laughingsister
                                 || m.name == cardName.spectralknight)) || m.stealth)
                        {
                            continue;
                        }

                        enemyMins[k] = true;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++)
                    {
                        ownMins[i] = false;
                    }

                    for (int i = 0; i < enemyMins.Length; i++)
                    {
                        enemyMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (this.isRequirementInList(ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++)
                    {
                        enemyMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_ENEMY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++)
                    {
                        ownMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_DAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    if (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON)
                    {
                        addOwnHero = true;
                    }

                    if (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON)
                    {
                        addEnemyHero = true;
                    }

                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (addEnemyHero)
                {
                    retval.Add(p.enemyHero);
                }

                if (addOwnHero)
                {
                    retval.Add(p.ownHero);
                }

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k])
                    {
                        retval.Add(m);
                    }
                }

                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k])
                    {
                        retval.Add(m);
                    }
                }

                return retval;
            }

            /// <summary>
            /// The get targets for card enemy.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <returns>
            /// The <see cref="List"/>.
            /// </returns>
            public List<Minion> getTargetsForCardEnemy(Playfield p)
            {
                // todo make it faster!! 
                // todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++)
                {
                    ownMins[i] = false;
                }

                for (int i = 0; i < enemyMins.Length; i++)
                {
                    enemyMins[i] = false;
                }

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0)
                {
                    return retval;
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_TO_PLAY)
                    || this.isRequirementInList(ErrorType2.REQ_NONSELF_TARGET)
                    || this.isRequirementInList(ErrorType2.REQ_TARGET_IF_AVAILABLE)
                    || this.isRequirementInList(ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)
                             && (m.name == cardName.faeriedragon || m.name == cardName.laughingsister
                                 || m.name == cardName.spectralknight)) || m.stealth)
                        {
                            continue;
                        }

                        ownMins[k] = true;
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)
                            && (m.name == cardName.faeriedragon || m.name == cardName.laughingsister)
                            || m.name == cardName.spectralknight)
                        {
                            continue;
                        }

                        enemyMins[k] = true;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++)
                    {
                        ownMins[i] = false;
                    }

                    for (int i = 0; i < enemyMins.Length; i++)
                    {
                        enemyMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (this.isRequirementInList(ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++)
                    {
                        ownMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_ENEMY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++)
                    {
                        enemyMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_DAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    if (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON)
                    {
                        addOwnHero = true;
                    }

                    if (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON)
                    {
                        addEnemyHero = true;
                    }

                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            ownMins[k] = false;
                        }
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (addEnemyHero)
                {
                    retval.Add(p.enemyHero);
                }

                if (addOwnHero)
                {
                    retval.Add(p.ownHero);
                }

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k])
                    {
                        retval.Add(m);
                    }
                }

                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k])
                    {
                        retval.Add(m);
                    }
                }

                return retval;
            }

            /// <summary>
            /// The is requirement in list.
            /// </summary>
            /// <param name="et">
            /// The et.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool isRequirementInList(ErrorType2 et)
            {
                if (this.playrequires.Contains(et))
                {
                    return true;
                }

                return false;
            }

            #endregion
        }
    }
}