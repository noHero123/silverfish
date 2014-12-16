using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_120 : SimTemplate //Hemet Nesingwary
    {

        //   Battlecry: Destroy a Beast.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null) return;

            p.minionGetDestroyed(target);
        }



    }

}