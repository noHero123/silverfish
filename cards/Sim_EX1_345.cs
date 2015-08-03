using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_345 : SimTemplate //mindgames
	{

//    legt eine kopie eines zufälligen dieners aus dem deck eures gegners auf das schlachtfeld.

        CardDB.Card shadow = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_345t); // server :D
        CardDB.Card copymin = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_182); // we take a icewindjety :D

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{

            if (p.isServer)
            {
                List<Handmanager.Handcard> temp = new List<Handmanager.Handcard>();
                List<Handmanager.Handcard> cards = (ownplay)? p.enemyDeck : p.myDeck;

                foreach (Handmanager.Handcard hc in cards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB)
                    {
                        temp.Add(hc);
                    }
                }

                if (temp.Count >= 1)
                {

                    int rand = p.getRandomNumber_SERVER(0, temp.Count - 1);
                    int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                    p.callKid(cards[rand].card, posi, true);
                }
                else
                {
                    int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                    p.callKid(shadow, posi, true);
                }
                return;
            }
            p.callKid(copymin, p.ownMinions.Count, true);
		}

	}
}