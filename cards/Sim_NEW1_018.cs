using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_018 : SimTemplate//bloodsail raider
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
             own.Angr += p.ownWeaponAttack;
        }

    }
}
