namespace HREngine.Bots
{
    using System.Collections.Generic;

    public class Handmanager
    {

        public class Handcard
        {
            public int position = 0;
            public int entity = -1;
            public int manacost = 1000;
            public int addattack = 0;
            public int addHp = 0;
            public CardDB.Card card;

            public Handcard()
            {
                card = CardDB.Instance.unknownCard;
            }
            public Handcard(Handcard hc)
            {
                this.position = hc.position;
                this.entity = hc.entity;
                this.manacost = hc.manacost;
                this.card = hc.card;
                this.addattack = hc.addattack;
                this.addHp = hc.addHp;
            }
            public Handcard(CardDB.Card c)
            {
                this.position = 0;
                this.entity = -1;
                this.card = c;
                this.addattack = 0;
                this.addHp = 0;
            }
            public int getManaCost(Playfield p)
            {
                return this.card.getManaCost(p, this.manacost);
            }
            public bool canplayCard(Playfield p)
            {
                return this.card.canplayCard(p, this.manacost);
            }
        }

        public List<Handcard> handCards = new List<Handcard>();

        public int anzcards = 0;

        public int enemyAnzCards = 0;

        private int ownPlayerController = 0;

        Helpfunctions help;
        CardDB cdb = CardDB.Instance;

        private static Handmanager instance;

        public static Handmanager Instance
        {
            get
            {
                return instance ?? (instance = new Handmanager());
            }
        }


        private Handmanager()
        {
            this.help = Helpfunctions.Instance;

        }

        public void clearAll()
        {
            this.handCards.Clear();
            this.anzcards = 0;
            this.enemyAnzCards = 0;
            this.ownPlayerController = 0;
        }

        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }




        public void setHandcards(List<Handcard> hc, int anzown, int anzenemy)
        {
            this.handCards.Clear();
            foreach (Handcard h in hc)
            {
                this.handCards.Add(new Handcard(h));
            }
            //this.handCards.AddRange(hc);
            this.handCards.Sort((a, b) => a.position.CompareTo(b.position));
            this.anzcards = anzown;
            this.enemyAnzCards = anzenemy;
        }


        public void printcards(bool writeTobuffer = false)
        {
            help.logg("Own Handcards: ");
            foreach (Handmanager.Handcard c in this.handCards)
            {
                help.logg("pos " + c.position + " " + c.card.name + " " + c.manacost + " entity " + c.entity + " " + c.card.cardIDenum + " " + c.addattack);
            }
            help.logg("Enemy cards: " + this.enemyAnzCards);

            //todo print died minions this turn!

            /*if(Ai.Instance.playaround)
            {
                if(Hrtprozis.Instance.enemyHeroname == HeroEnum.mage)
                {
                    help.logg("probs: "  + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS2_032) + " " + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS2_028));
                }

                if (Hrtprozis.Instance.enemyHeroname == HeroEnum.warrior)
                {
                    help.logg("probs: "  + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.EX1_400));
                }

                if (Hrtprozis.Instance.enemyHeroname == HeroEnum.hunter)
                {
                    help.logg("probs: "  + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.EX1_538));
                }

                if (Hrtprozis.Instance.enemyHeroname == HeroEnum.priest)
                {
                    help.logg("probs: "  + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS1_112));
                }

                if (Hrtprozis.Instance.enemyHeroname == HeroEnum.shaman)
                {
                    help.logg("probs: "  + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.EX1_259));
                }

                if (Hrtprozis.Instance.enemyHeroname == HeroEnum.pala)
                {
                    help.logg("probs: "  + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS2_093));
                }

                if (Hrtprozis.Instance.enemyHeroname == HeroEnum.druid)
                {
                    help.logg("probs: "  + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS2_012));
                }
            }*/

            if (writeTobuffer)
            {
                help.writeToBuffer("Own Handcards: ");
                foreach (Handmanager.Handcard c in this.handCards)
                {
                    help.writeToBuffer("pos " + c.position + " " + c.card.name + " " + c.manacost + " entity " + c.entity + " " + c.card.cardIDenum + " " + c.addattack);
                }
                help.writeToBuffer("Enemy cards: " + this.enemyAnzCards);

                //todo print died minions this turn!

            }
        }


    }

}