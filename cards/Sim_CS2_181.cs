using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_181 : SimTemplate//Injured Blademaster
    {

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            p.minionGetDamageOrHeal(own, 4);
        }

    }
}
