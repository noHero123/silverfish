using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_617 : SimTemplate //deadlyshot
	{
//    vernichtet einen zufälligen feindlichen diener.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (p.isServer)
            {
                Minion tempS = p.getRandomMinionFromSide_SERVER(!ownplay, false);
                if (tempS != null) p.minionGetDestroyed(tempS);
                return;
            }

            List<Minion> temp2 = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
            foreach (Minion enemy in temp2)
            {
                p.minionGetDestroyed(enemy);
                break;
            }
		}

	}
}