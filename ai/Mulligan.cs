// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mulligan.cs" company="">
//   
// </copyright>
// <summary>
//   The mulligan.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    ///     The mulligan.
    /// </summary>
    public class Mulligan
    {
        #region Static Fields

        /// <summary>
        ///     The instance.
        /// </summary>
        private static Mulligan instance;

        #endregion

        #region Fields

        /// <summary>
        ///     The loser loser loser.
        /// </summary>
        public bool loserLoserLoser = false;

        /// <summary>
        ///     The concedelist.
        /// </summary>
        private List<concedeItem> concedelist = new List<concedeItem>();

        /// <summary>
        ///     The deletelist.
        /// </summary>
        private List<mulliitem> deletelist = new List<mulliitem>();

        /// <summary>
        ///     The holdlist.
        /// </summary>
        private List<mulliitem> holdlist = new List<mulliitem>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Verhindert, dass eine Standardinstanz der <see cref="Mulligan"/> Klasse erstellt wird. 
        ///     Prevents a default instance of the <see cref="Mulligan"/> class from being created.
        /// </summary>
        private Mulligan()
        {
            this.readCombos();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        public static Mulligan Instance
        {
            get
            {
                return instance ?? (instance = new Mulligan());
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The hasmulliganrules.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool hasmulliganrules()
        {
            if (this.holdlist.Count == 0 && this.deletelist.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The set auto concede.
        /// </summary>
        /// <param name="mode">
        /// The mode.
        /// </param>
        public void setAutoConcede(bool mode)
        {
            this.loserLoserLoser = mode;
        }

        /// <summary>
        /// The should concede.
        /// </summary>
        /// <param name="ownhero">
        /// The ownhero.
        /// </param>
        /// <param name="enemHero">
        /// The enem hero.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool shouldConcede(HeroEnum ownhero, HeroEnum enemHero)
        {
            foreach (concedeItem ci in this.concedelist)
            {
                if (ci.urhero == ownhero && ci.enemhero.Contains(enemHero))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The what should i mulligan.
        /// </summary>
        /// <param name="cards">
        /// The cards.
        /// </param>
        /// <param name="ownclass">
        /// The ownclass.
        /// </param>
        /// <param name="enemclass">
        /// The enemclass.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<int> whatShouldIMulligan(List<CardIDEntity> cards, string ownclass, string enemclass)
        {
            List<int> discarditems = new List<int>();

            foreach (mulliitem mi in this.deletelist)
            {
                foreach (CardIDEntity c in cards)
                {
                    if (mi.cardid == "#MANARULE" && (mi.enemyclass == "all" || mi.enemyclass == enemclass)
                        && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {
                        if (CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(c.id)).cost
                            >= mi.manarule)
                        {
                            if (discarditems.Contains(c.entitiy))
                            {
                                continue;
                            }

                            discarditems.Add(c.entitiy);
                        }

                        continue;
                    }

                    if (c.id == mi.cardid && (mi.enemyclass == "all" || mi.enemyclass == enemclass)
                        && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {
                        if (discarditems.Contains(c.entitiy))
                        {
                            continue;
                        }

                        discarditems.Add(c.entitiy);
                    }
                }
            }

            if (this.holdlist.Count == 0)
            {
                return discarditems;
            }

            Dictionary<string, int> holddic = new Dictionary<string, int>();
            foreach (CardIDEntity c in cards)
            {
                bool delete = true;
                foreach (mulliitem mi in this.holdlist)
                {
                    if (mi.cardid == "#MANARULE" && (mi.enemyclass == "all" || mi.enemyclass == enemclass)
                        && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {
                        if (CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(c.id)).cost
                            <= mi.manarule)
                        {
                            delete = false;
                        }

                        continue;
                    }

                    if (c.id == mi.cardid && (mi.enemyclass == "all" || mi.enemyclass == enemclass)
                        && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {
                        if (mi.requiresCard == null)
                        {
                            if (holddic.ContainsKey(c.id))
                            {
                                // we are holding one of the cards
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
                                if (holddic.ContainsKey(c.id))
                                {
                                    // we are holding one of the cards
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
                    if (discarditems.Contains(c.entitiy))
                    {
                        continue;
                    }

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

        #endregion

        #region Methods

        /// <summary>
        ///     The read combos.
        /// </summary>
        private void readCombos()
        {
            string[] lines = { };
            this.holdlist.Clear();
            this.deletelist.Clear();
            try
            {
                string path = Settings.Instance.path;
                lines = File.ReadAllLines(path + "_mulligan.txt");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find _mulligan.txt");
                Helpfunctions.Instance.ErrorLog(
                    "cant find _mulligan.txt (if you dont created your own mulliganfile, ignore this message)");
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
                        concedeItem ci = new concedeItem { urhero = Hrtprozis.Instance.heroNametoEnum(ownh) };
                        string enemlist = line.Split(':')[2];
                        foreach (string s in enemlist.Split(','))
                        {
                            ci.enemhero.Add(Hrtprozis.Instance.heroNametoEnum(s));
                        }

                        this.concedelist.Add(ci);
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
                                if (crd.Split(':').Length == 3)
                                {
                                    this.holdlist.Add(
                                        new mulliitem(
                                            crd.Split(':')[0], 
                                            ownclass, 
                                            enemyclass, 
                                            Convert.ToInt32(crd.Split(':')[1]), 
                                            crd.Split(':')[2].Split('/')));
                                }
                                else
                                {
                                    this.holdlist.Add(
                                        new mulliitem(
                                            crd.Split(':')[0], 
                                            ownclass, 
                                            enemyclass, 
                                            Convert.ToInt32(crd.Split(':')[1])));
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
                                if (crd == null || crd == string.Empty)
                                {
                                    continue;
                                }

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
                }
            }
        }

        #endregion

        /// <summary>
        ///     The card id entity.
        /// </summary>
        public class CardIDEntity
        {
            #region Fields

            /// <summary>
            ///     The entitiy.
            /// </summary>
            public int entitiy = 0;

            /// <summary>
            ///     The id.
            /// </summary>
            public string id = string.Empty;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initialisiert eine neue Instanz der <see cref="CardIDEntity"/> Klasse. 
            /// Initializes a new instance of the <see cref="CardIDEntity"/> class.
            /// </summary>
            /// <param name="id">
            /// The id.
            /// </param>
            /// <param name="entt">
            /// The entt.
            /// </param>
            public CardIDEntity(string id, int entt)
            {
                this.id = id;
                this.entitiy = entt;
            }

            #endregion
        }

        /// <summary>
        ///     The concede item.
        /// </summary>
        private class concedeItem
        {
            #region Fields

            /// <summary>
            ///     The enemhero.
            /// </summary>
            public List<HeroEnum> enemhero = new List<HeroEnum>();

            /// <summary>
            ///     The urhero.
            /// </summary>
            public HeroEnum urhero = HeroEnum.None;

            #endregion
        }

        /// <summary>
        ///     The mulliitem.
        /// </summary>
        private class mulliitem
        {
            #region Fields

            /// <summary>
            ///     The cardid.
            /// </summary>
            public string cardid = string.Empty;

            /// <summary>
            ///     The enemyclass.
            /// </summary>
            public string enemyclass = string.Empty;

            /// <summary>
            ///     The howmuch.
            /// </summary>
            public int howmuch = 2;

            /// <summary>
            ///     The manarule.
            /// </summary>
            public int manarule = -1;

            /// <summary>
            ///     The ownclass.
            /// </summary>
            public string ownclass = string.Empty;

            /// <summary>
            ///     The requires card.
            /// </summary>
            public string[] requiresCard;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initialisiert eine neue Instanz der <see cref="mulliitem"/> Klasse. 
            /// Initializes a new instance of the <see cref="mulliitem"/> class.
            /// </summary>
            /// <param name="id">
            /// The id.
            /// </param>
            /// <param name="own">
            /// The own.
            /// </param>
            /// <param name="enemy">
            /// The enemy.
            /// </param>
            /// <param name="number">
            /// The number.
            /// </param>
            /// <param name="req">
            /// The req.
            /// </param>
            /// <param name="mrule">
            /// The mrule.
            /// </param>
            public mulliitem(string id, string own, string enemy, int number, string[] req = null, int mrule = -1)
            {
                this.cardid = id;
                this.ownclass = own;
                this.enemyclass = enemy;
                this.howmuch = number;
                this.requiresCard = req;
                this.manarule = mrule;
            }

            #endregion
        }
    }
}