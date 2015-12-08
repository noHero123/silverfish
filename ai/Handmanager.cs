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
            public bool isChoiceTemp = false;
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
                this.isChoiceTemp = hc.isChoiceTemp;
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

        List<Handcard> handcardchoices = new List<Handcard>();

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
            this.handcardchoices.Clear();
        }

        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }

        public string getCardChoiceString()
        {
            string retval ="";

            if (handcardchoices.Count >= 1)
            {
                retval = "activeChoice:";

                foreach (Handcard c in handcardchoices)
                {
                    retval += " " + c.card.cardIDenum;
                }
            }

            return retval;
        }

        private void setCardChoices(List<CardDB.cardIDEnum> crdchcs)
        {
            this.handcardchoices.Clear();
            foreach (CardDB.cardIDEnum cid in crdchcs)
            {
                CardDB.Card cardc = CardDB.Instance.getCardDataFromID(cid);
                Handcard nehc = new Handcard(cardc);
                nehc.entity = 54321;
                nehc.manacost = cardc.cost;
                this.handcardchoices.Add(nehc);
                Helpfunctions.Instance.ErrorLog("choices " + cardc.name);
            }
            CardDB.Card tempcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_029);//=fireball, just to make sure its not a mob (movegen will ignore mobs if own minions >= 7)
            tempcard.name = CardDB.cardName.placeholdercard;
            Handcard newhc = new Handcard(tempcard);
            newhc.entity = 54321;
            newhc.isChoiceTemp=true;
            newhc.manacost = 0;
            this.handCards.Add(newhc);
        }

        public Handcard getCardChoice(int i)
        {
            return handcardchoices[i];
        }

        public int getNumberChoices()
        {
            return handcardchoices.Count;
        }


        public void setHandcards(List<Handcard> hc, int anzowncards, int anzenemycards, List<CardDB.cardIDEnum> crdchcs)
        {
            this.handcardchoices.Clear();
            this.handCards.Clear();
            foreach (Handcard h in hc)
            {
                this.handCards.Add(new Handcard(h));
            }
            //this.handCards.AddRange(hc);
            this.handCards.Sort((a, b) => a.position.CompareTo(b.position));
            this.anzcards = anzowncards;
            this.enemyAnzCards = anzenemycards;

            if (crdchcs.Count >= 1)
            {
                setCardChoices(crdchcs);
                this.anzcards++;
            }
        }

        //not updated anymore!
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