using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HREngine.Bots
{

    public struct GraveYardItem
    {
        public bool own;
        public int entity;
        public CardDB.cardIDEnum cardid;

        public GraveYardItem(CardDB.cardIDEnum id, int entity, bool own)
        {
            this.own = own;
            this.cardid = id;
            this.entity = entity;
        }
    }

    public class Probabilitymaker
    {
        Dictionary<CardDB.cardIDEnum, int> ownCardsPlayed = new Dictionary<CardDB.cardIDEnum, int>();
        Dictionary<CardDB.cardIDEnum, int> enemyCardsPlayed = new Dictionary<CardDB.cardIDEnum, int>();
        List<CardDB.Card> ownDeckGuessed = new List<CardDB.Card>();
        List<CardDB.Card> enemyDeckGuessed = new List<CardDB.Card>();
        List<GraveYardItem> graveyard = new List<GraveYardItem>();
        public List<GraveYardItem> turngraveyard = new List<GraveYardItem>();//MOBS only
        List<GraveYardItem> graveyartTillTurnStart = new List<GraveYardItem>();

        public bool feugenDead = false;
        public bool stalaggDead = false;

        private static Probabilitymaker instance;
        public static Probabilitymaker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Probabilitymaker();
                }
                return instance;
            }
        }

        private Probabilitymaker()
        {
 
        }

        public void setOwnCards(List<CardDB.cardIDEnum> list)
        {
            setupDeck(list, ownDeckGuessed, ownCardsPlayed);
        }

        public void setEnemyCards(List<CardDB.cardIDEnum> list)
        {
            setupDeck(list, enemyDeckGuessed, enemyCardsPlayed);
        }

        public void printTurnGraveYard()
        {
            string g = "";
            if (Probabilitymaker.Instance.feugenDead) g += " fgn";
            if (Probabilitymaker.Instance.stalaggDead) g += " stlgg";
            Helpfunctions.Instance.logg("GraveYard:" + g);

            string s = "ownDiedMinions: ";
            foreach (GraveYardItem gyi in this.turngraveyard)
            {
                if (gyi.own) s += gyi.cardid + "," + gyi.entity + ";";
            }
            Helpfunctions.Instance.logg(s);

            s = "enemyDiedMinions: ";
            foreach (GraveYardItem gyi in this.turngraveyard)
            {
                if (!gyi.own) s += gyi.cardid + "," + gyi.entity + ";";
            }
            Helpfunctions.Instance.logg(s);
        }

        public void setGraveYard(List<GraveYardItem> list, bool turnStart)
        {
            graveyard.Clear();
            graveyard.AddRange(list);
            if (turnStart)
            {
                this.graveyartTillTurnStart.Clear();
                this.graveyartTillTurnStart.AddRange(list);
            }

            this.stalaggDead = false;
            this.feugenDead = false;
            this.turngraveyard.Clear();

            foreach (GraveYardItem en in list)
            {
                if (en.cardid == CardDB.cardIDEnum.FP1_015) this.feugenDead = true;
                if (en.cardid == CardDB.cardIDEnum.FP1_014) this.stalaggDead = true;

                bool found = false;

                foreach (GraveYardItem gyi in this.graveyartTillTurnStart)
                {
                    if (en.entity == gyi.entity)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (CardDB.Instance.getCardDataFromID(en.cardid).type == CardDB.cardtype.MOB)
                    {
                        this.turngraveyard.Add(en);
                    }
                }
            }

          
        }

        public void setTurnGraveYard(List<GraveYardItem> list)
        {
            this.turngraveyard.Clear();
            this.turngraveyard.AddRange(list);
        }

        private void setupDeck(List<CardDB.cardIDEnum> cardsPlayed, List<CardDB.Card> deckGuessed, Dictionary<CardDB.cardIDEnum, int> knownCards)
        {
            deckGuessed.Clear();
            knownCards.Clear();
            foreach (CardDB.cardIDEnum crdidnm in cardsPlayed)
            {
                if (crdidnm == CardDB.cardIDEnum.GAME_005) continue; //(im sure, he has no coins in his deck :D)
                if (knownCards.ContainsKey(crdidnm))
                {
                    knownCards[crdidnm]++;
                }
                else 
                {
                    if (CardDB.Instance.getCardDataFromID(crdidnm).rarity == 5)
                    {
                        //you cant own rare ones more than once!
                        knownCards.Add(crdidnm, 2);
                        continue;
                    }
                    knownCards.Add(crdidnm, 1);
                }
            }

            foreach (KeyValuePair<CardDB.cardIDEnum, int> kvp in knownCards)
            {
                if (kvp.Value == 1) deckGuessed.Add(CardDB.Instance.getCardDataFromID(kvp.Key));
            }
        }

        public bool hasEnemyThisCardInDeck(CardDB.cardIDEnum cardid)
        {
            if (this.enemyCardsPlayed.ContainsKey(cardid))
            {
                if (this.enemyCardsPlayed[cardid] == 1)
                {

                    return true;
                }
                return false;
            }
            return true;
        }

        public int anzCardsInDeck(CardDB.cardIDEnum cardid)
        {
            int ret = 2;
            CardDB.Card c = CardDB.Instance.getCardDataFromID(cardid);
            if (c.rarity == 5) ret = 1;//you can have only one rare;

            if (this.enemyCardsPlayed.ContainsKey(cardid))
            {
                if (this.enemyCardsPlayed[cardid] == 1)
                {

                    return 1;
                }
                return 0;
            }
            return ret;

        }


        public int getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum cardid, int handsize, int decksize)
        {
            //calculates probability \in [0,...,100]

            
            int cardsremaining = this.anzCardsInDeck(cardid);
            if (cardsremaining == 0) return 0;
            double retval = 0.0;
            //http://de.wikipedia.org/wiki/Hypergeometrische_Verteilung (we calculte 1-p(x=0))

            if (cardsremaining == 1)
            {
                retval = 1.0 - ((double)(decksize)) / ((double)(decksize + handsize));
            }
            else
            {
                retval = 1.0 - ((double)(decksize * (decksize - 1))) / ((double)((decksize + handsize) * (decksize + handsize - 1)));
            }

            retval = Math.Min(retval, 1.0);

            return (int) (100.0 * retval);
        }

        public bool hasCardinGraveyard(CardDB.cardIDEnum cardid)
        {
            foreach (GraveYardItem gyi in this.graveyard)
            {
                if (gyi.cardid == cardid) return true;
            }
            return false;
        }

    }

}
