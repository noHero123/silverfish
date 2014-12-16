using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_008 : SimTemplate //Lightbomb
    {

        //    Deal damage to each minion equal to its Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                p.minionGetDamageOrHeal(m, m.Angr, true);
            }

            foreach (Minion m in p.enemyMinions)
            {
                p.minionGetDamageOrHeal(m, m.Angr, true);
            }
        }


    }

}