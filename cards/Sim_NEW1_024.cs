using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_024 : SimTemplate //captaingreenskin
	{
        //todo enemy
//    kampfschrei:/ verleiht eurer waffe +1/+1.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.ownWeaponDurability++;
                    p.ownWeaponAttack++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
            }
		}

	}
}