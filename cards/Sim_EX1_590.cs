using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_590 : SimTemplate //bloodknight
	{

//    kampfschrei:/ alle diener verlieren gottesschild/. erhält +3/+3 für jeden verlorenen schild.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int shilds = 0;
            foreach (Minion m in p.ownMinions)
            {
                if (m.divineshild)
                {
                    m.divineshild = false;
                    shilds++;
                }
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.divineshild)
                {
                    m.divineshild = false;
                    shilds++;
                }
            }
            p.minionGetBuffed(own, 3 * shilds, 3 * shilds);
		}


	}
}