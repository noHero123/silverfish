using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_407 : SimTemplate //brawl
	{

//    vernichtet alle diener bis auf einen. (zufällige auswahl)

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{

            if (p.isServer)
            {
                Minion choosen = p.getRandomCharExcept_SERVER(null, false);

                foreach (Minion m in p.ownMinions)
                {
                    if (m == choosen) continue;
                    p.minionGetDestroyed(m);
                }
                foreach (Minion m in p.enemyMinions)
                {
                    if (m == choosen) continue;
                    p.minionGetDestroyed(m);
                }
            }

            p.allMinionsGetDestroyed();
		}

	}
}