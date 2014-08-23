using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

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
                                    this.holdlist.Add(new mulliitem(crd.Split(':')[0],ownclass, enemyclass, Convert.ToInt32(crd.Split(':')[1]), crd.Split(':')[2].Split('/')));
                                }
                                else
                                {
                                    this.holdlist.Add(new mulliitem(crd.Split(':')[0],ownclass, enemyclass, Convert.ToInt32(crd.Split(':')[1])));
                                }

                            }
                            else
                            {
                                this.holdlist.Add(new mulliitem(crd,ownclass, enemyclass, 2));
                            }
                        }

                        if (line.Split(';').Length == 5)
                        {
                            int manarule = Convert.ToInt32(line.Split(';')[4]);
                            this.holdlist.Add(new mulliitem("#MANARULE",ownclass, enemyclass, 2, null, manarule));
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

}
