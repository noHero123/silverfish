using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_221 : SimTemplate //spitefulsmith
	{

//    wutanfall:/ eure waffe hat +2 angriff.
        public override void onEnrageStart(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.ownHero.Angr += 2;
                    p.ownWeaponAttack += 2;
                }
            }
            else 
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    p.enemyWeaponAttack += 2;
                }
            }
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.ownHero.Angr -= 2;
                    p.ownWeaponAttack -= 2;
                }
            }
            else
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    p.enemyWeaponAttack -= 2;
                }
            }
        }

	}
}