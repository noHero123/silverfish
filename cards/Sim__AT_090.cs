using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_090 : SimTemplate //Mukla's Champion
    {

        //Inspire: Give your other minions +1/+1.

        public override void onInspire(Playfield p, Minion m)
        {
            foreach (Minion mini in (m.own) ? p.ownMinions : p.enemyMinions)
            {
                if (m.entitiyID != mini.entitiyID) p.minionGetBuffed(mini, 1, 1);
            }
        }


    }
}