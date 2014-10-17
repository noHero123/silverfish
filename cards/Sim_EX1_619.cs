using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_619 : SimTemplate //equality
	{

//    setzt das leben aller diener auf 1.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            foreach (Minion m in p.ownMinions)
            {
                p.minionSetLifetoOne(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
                p.minionSetLifetoOne(m);
            }
		}

	}
}