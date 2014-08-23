using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_074 : SimTemplate //deadlypoison
	{

//    eure waffe erhält +2 angriff.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.ownWeaponAttack += 2;
                    p.ownHero.Angr += 2;
                }
            }
            else
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    p.enemyWeaponAttack += 2;
                    p.enemyHero.Angr += 2;
                }
            }
		}

	}
}