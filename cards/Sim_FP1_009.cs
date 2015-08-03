using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_009 : SimTemplate //deathlord
	{
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_017);//nerubian
//    spott. todesröcheln:/ euer gegner legt einen diener aus seinem deck auf das schlachtfeld.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.isServer)
            {
                int places = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
                List<Handmanager.Handcard> deck = (m.own) ? p.enemyDeck : p.myDeck;
                if (deck.Count == 0) return;
                int i = 0;
                for (i = 0; i < deck.Count; i++)
                {
                    if (deck[i].card.type == CardDB.cardtype.MOB) break;
                }

                p.callKid(deck[i].card, places, !m.own);
                deck.Remove(deck[i]);
                return;
            }

            int place = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(c, place, !m.own);
        }

	}
}