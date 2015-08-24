using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_004 : SimTemplate //vanish
	{

//    lasst alle diener auf die hand ihrer besitzer zurückkehren.
        //todo clear playfield
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = new List<Minion>( p.ownMinions);
            foreach (Minion m in temp)
            {
                p.minionReturnToHand(m, true, 0);
            }
            temp.Clear();
            temp.AddRange(p.enemyMinions);
            foreach (Minion m in temp)
            {
                p.minionReturnToHand(m, false, 0);
            }
            p.ownMinions.Clear();
            p.enemyMinions.Clear();

        }

	}
}