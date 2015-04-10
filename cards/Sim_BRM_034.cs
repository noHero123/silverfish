using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_034 : SimTemplate //Blackwing Corruptor
    {

        //    If you're holding a Dragon, deal 3 damage.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) //requires target
            {
                int dmg = 3;
                p.minionGetDamageOrHeal(target, dmg);
            }
        }

    }
}