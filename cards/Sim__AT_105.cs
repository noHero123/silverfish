using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_105 : SimTemplate//Injured Kvaldir
    {
        //Battlecry: Deal 3 damage to this minion.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            p.minionGetDamageOrHeal(own, 3);
        }

    }
}
