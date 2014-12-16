using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_052 : SimTemplate //Crush
    {

        //   Destroy a minion. If you have a damaged minion, this costs (4) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }


    }

}