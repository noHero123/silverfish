using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_016 : SimTemplate //Confuse
	{

        //    Swap the Attack and Health of all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            foreach (Minion m in p.ownMinions)
            {
                p.minionSwapAngrAndHP(m);
            }

            foreach (Minion m in p.enemyMinions)
            {
                p.minionSwapAngrAndHP(m);
            }
        }

	}
}