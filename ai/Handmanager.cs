using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HREngine.Bots
{

    public class Handmanager
    {
        public class Cardsposi
        {
            public int Amount = 0;
            public int DetectPosix = 0;
            public int DetectPosiy = 0;
            public int cardsHooverPosx = 0;
            public int cardsHooverdiff = 0;
            public int cardsBigPosx = 0;
            public int cardsBigdiff = 0;
            public int hoovery = 750;
            public int bigreadydetecty = 510;

        }

        public class Handcard
        {
            public int position = 0;
            public int entity = -1;
            public int manacost = 1000;
            public CardDB.Card card ;

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
            }
            public Handcard(CardDB.Card c )
            {
                this.position = 0;
                this.entity = -1;
                this.card = c;
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

        public List<Cardsposi> cardsdata = new List<Cardsposi>();

        public List<Handcard> handCards = new List<Handcard>();

        public int anzcards = 0;

        public int enemyAnzCards = 0;

        private int ownPlayerController = 0;

        Helpfunctions help;
        Cardsposi currentCarddata = new Cardsposi();
        CardDB cdb = CardDB.Instance;

        private static Handmanager instance;

        public static Handmanager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Handmanager();
                }
                return instance;
            }
        }


        private Handmanager()
        {
            this.help = Helpfunctions.Instance;

            int i = 0;
            Cardsposi c = new Cardsposi();
            c.Amount = 1;
            c.DetectPosix = 450;
            c.DetectPosiy = 675;
            c.cardsHooverPosx = 490;
            c.cardsHooverdiff = 1;
            c.cardsBigPosx = 366;
            c.cardsBigdiff = 1;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 2;
            c.DetectPosix = 403;
            c.DetectPosiy = 674;
            c.cardsHooverPosx = 438;
            c.cardsHooverdiff = 100;
            c.cardsBigPosx = 317;
            c.cardsBigdiff = 99;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 3;
            c.DetectPosix = 356;
            c.DetectPosiy = 675;
            c.cardsHooverPosx = 390;
            c.cardsHooverdiff = 100;
            c.cardsBigPosx = 267;
            c.cardsBigdiff = 99;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 4;
            c.DetectPosix = 291;
            c.DetectPosiy = 715;
            c.cardsHooverPosx = 350;
            c.cardsHooverdiff = 90;
            c.cardsBigPosx = 220;
            c.cardsBigdiff = 97;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 5;
            c.DetectPosix = 280;
            c.DetectPosiy = 712;
            c.cardsHooverPosx = 340;
            c.cardsHooverdiff = 75;
            c.cardsBigPosx = 210;
            c.cardsBigdiff = 78;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 6;
            c.DetectPosix = 273;
            c.DetectPosiy = 726;
            c.cardsHooverPosx = 323;
            c.cardsHooverdiff = 65;
            c.cardsBigPosx = 204;
            c.cardsBigdiff = 65;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 7;
            c.DetectPosix = 267;
            c.DetectPosiy = 724;
            c.cardsHooverPosx = 314;
            c.cardsHooverdiff = 56;
            c.cardsBigPosx = 199;
            c.cardsBigdiff = 56;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 8;
            c.DetectPosix = 262;
            c.DetectPosiy = 740;
            c.cardsHooverPosx = 300;
            c.cardsHooverdiff = 47;
            c.cardsBigPosx = 196;
            c.cardsBigdiff = 49;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 9;
            c.DetectPosix = 260;
            c.DetectPosiy = 738;
            c.cardsHooverPosx = 295;
            c.cardsHooverdiff = 42;
            c.cardsBigPosx = 193;
            c.cardsBigdiff = 43;
            this.cardsdata.Add(c);

            i = i + 1;
            c = new Cardsposi();
            c.Amount = 10;
            c.DetectPosix = 257;
            c.DetectPosiy = 752;
            c.cardsHooverPosx = 286;
            c.cardsHooverdiff = 38;
            c.cardsBigPosx = 191;
            c.cardsBigdiff = 39;
            this.cardsdata.Add(c);

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



        public Cardsposi getCardposi(int anzcard)
        {
            if (anzcard == 0) return new Cardsposi();
            int k = anzcard - 1;
            Cardsposi returnval = new Cardsposi();
            returnval.Amount = this.cardsdata[k].Amount;
            returnval.cardsBigdiff = this.cardsdata[k].cardsBigdiff;
            returnval.cardsBigPosx = this.cardsdata[k].cardsBigPosx;
            returnval.cardsHooverdiff = this.cardsdata[k].cardsHooverdiff;
            returnval.cardsHooverPosx = this.cardsdata[k].cardsHooverPosx;
            returnval.DetectPosix = this.cardsdata[k].DetectPosix;
            returnval.DetectPosiy = this.cardsdata[k].DetectPosiy;
            return returnval;
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
            this.currentCarddata = this.getCardposi(this.anzcards);
        }


        public void printcards()
        {
            help.logg("Own Handcards: ");
            foreach (Handmanager.Handcard c in this.handCards)
            {
                help.logg("pos " + c.position + " " + c.card.name + " " + c.manacost + " entity " + c.entity + " " + c.card.cardIDenum);
            }
            help.logg("Enemy cards: " + this.enemyAnzCards);
            
            //todo print died minions this turn!
            
            if(Ai.Instance.playaround)
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
            }
        }


    }


}
