using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_026 : SimTemplate //frostnova
    {

        //    friert/ alle feindlichen diener ein.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            foreach (Minion t in temp)
            {
                t.frozen = true;
            }
        }
    }
}