using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_317 : SimTemplate //sensedemons
	{

//    fügt eurer hand zwei zufällige dämonen aus eurem deck hinzu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (p.isServer)
            {
                List<Handmanager.Handcard> tempdeck = new List<Handmanager.Handcard>( (ownplay) ? p.myDeck : p.enemyDeck );
                List<Handmanager.Handcard> deck = (ownplay) ? p.myDeck : p.enemyDeck;
                int count = 0;
                foreach (Handmanager.Handcard hc in tempdeck)
                {
                    if (hc.card.race == TAG_RACE.DEMON)
                    {

                        p.drawACard(hc.card.cardIDenum, ownplay);
                        deck.Remove(hc);
                        count++;
                        if (count == 2) break;
                    }
                }
                //TODO shuffle?
            }

            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}

	}
}