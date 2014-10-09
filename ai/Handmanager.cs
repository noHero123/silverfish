// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Handmanager.cs" company="">
//   
// </copyright>
// <summary>
//   The handmanager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The handmanager.
    /// </summary>
    public class Handmanager
    {
        /// <summary>
        /// The handcard.
        /// </summary>
        public class Handcard
        {
            /// <summary>
            /// The position.
            /// </summary>
            public int position = 0;

            /// <summary>
            /// The entity.
            /// </summary>
            public int entity = -1;

            /// <summary>
            /// The manacost.
            /// </summary>
            public int manacost = 1000;

            /// <summary>
            /// The card.
            /// </summary>
            public CardDB.Card card ;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handcard"/> class.
            /// </summary>
            public Handcard()
            {
                this.card = CardDB.Instance.unknownCard;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Handcard"/> class.
            /// </summary>
            /// <param name="hc">
            /// The hc.
            /// </param>
            public Handcard(Handcard hc)
            {
                this.position = hc.position;
                this.entity = hc.entity;
                this.manacost = hc.manacost;
                this.card = hc.card;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Handcard"/> class.
            /// </summary>
            /// <param name="c">
            /// The c.
            /// </param>
            public Handcard(CardDB.Card c )
            {
                this.position = 0;
                this.entity = -1;
                this.card = c;
            }

            /// <summary>
            /// The get mana cost.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <returns>
            /// The <see cref="int"/>.
            /// </returns>
            public int getManaCost(Playfield p)
            {
                return this.card.getManaCost(p, this.manacost);
            }

            /// <summary>
            /// The canplay card.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool canplayCard(Playfield p)
            {
                return this.card.canplayCard(p, this.manacost);
            }
        }

        /// <summary>
        /// The hand cards.
        /// </summary>
        public List<Handcard> handCards = new List<Handcard>();

        /// <summary>
        /// The anzcards.
        /// </summary>
        public int anzcards = 0;

        /// <summary>
        /// The enemy anz cards.
        /// </summary>
        public int enemyAnzCards = 0;

        /// <summary>
        /// The own player controller.
        /// </summary>
        private int ownPlayerController = 0;

        /// <summary>
        /// The help.
        /// </summary>
        Helpfunctions help;

        /// <summary>
        /// The cdb.
        /// </summary>
        CardDB cdb = CardDB.Instance;

        /// <summary>
        /// The instance.
        /// </summary>
        private static Handmanager instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
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

        /// <summary>
        /// Prevents a default instance of the <see cref="Handmanager"/> class from being created.
        /// </summary>
        private Handmanager()
        {
            this.help = Helpfunctions.Instance;

        }

        /// <summary>
        /// The clear all.
        /// </summary>
        public void clearAll()
        {
            this.handCards.Clear();
            this.anzcards = 0;
            this.enemyAnzCards = 0;
            this.ownPlayerController = 0;
        }

        /// <summary>
        /// The set own player.
        /// </summary>
        /// <param name="player">
        /// The player.
        /// </param>
        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }

        /// <summary>
        /// The set handcards.
        /// </summary>
        /// <param name="hc">
        /// The hc.
        /// </param>
        /// <param name="anzown">
        /// The anzown.
        /// </param>
        /// <param name="anzenemy">
        /// The anzenemy.
        /// </param>
        public void setHandcards(List<Handcard> hc, int anzown, int anzenemy)
        {
            this.handCards.Clear();
            foreach (Handcard h in hc)
            {
                this.handCards.Add(new Handcard(h));
            }

            // this.handCards.AddRange(hc);
            this.handCards.Sort((a, b) => a.position.CompareTo(b.position));
            this.anzcards = anzown;
            this.enemyAnzCards = anzenemy;
        }

        /// <summary>
        /// The printcards.
        /// </summary>
        /// <param name="writeTobuffer">
        /// The write tobuffer.
        /// </param>
        public void printcards(bool writeTobuffer = false)
        {
            this.help.logg("Own Handcards: ");
            foreach (Handcard c in this.handCards)
            {
                this.help.logg("pos " + c.position + " " + c.card.name + " " + c.manacost + " entity " + c.entity + " " + c.card.cardIDenum);
            }

            this.help.logg("Enemy cards: " + this.enemyAnzCards);
            
            // todo print died minions this turn!
            
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
                this.help.writeToBuffer("Own Handcards: ");
                foreach (Handcard c in this.handCards)
                {
                    this.help.writeToBuffer("pos " + c.position + " " + c.card.name + " " + c.manacost + " entity " + c.entity + " " + c.card.cardIDenum);
                }

                this.help.writeToBuffer("Enemy cards: " + this.enemyAnzCards);

                // todo print died minions this turn!

                /*if (Ai.Instance.playaround)
                {
                    if (Hrtprozis.Instance.enemyHeroname == HeroEnum.mage)
                    {
                        help.writeToBuffer("probs: " + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS2_032) + " " + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS2_028));
                    }

                    if (Hrtprozis.Instance.enemyHeroname == HeroEnum.warrior)
                    {
                        help.writeToBuffer("probs: " + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.EX1_400));
                    }

                    if (Hrtprozis.Instance.enemyHeroname == HeroEnum.hunter)
                    {
                        help.writeToBuffer("probs: " + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.EX1_538));
                    }

                    if (Hrtprozis.Instance.enemyHeroname == HeroEnum.priest)
                    {
                        help.writeToBuffer("probs: " + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS1_112));
                    }

                    if (Hrtprozis.Instance.enemyHeroname == HeroEnum.shaman)
                    {
                        help.writeToBuffer("probs: " + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.EX1_259));
                    }

                    if (Hrtprozis.Instance.enemyHeroname == HeroEnum.pala)
                    {
                        help.writeToBuffer("probs: " + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS2_093));
                    }

                    if (Hrtprozis.Instance.enemyHeroname == HeroEnum.druid)
                    {
                        help.writeToBuffer("probs: " + Probabilitymaker.Instance.anzCardsInDeck(CardDB.cardIDEnum.CS2_012));
                    }
                }*/
            }
        }


    }


}
