using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_245 : SimTemplate //earthshock
	{

//    bringt einen diener zum schweigen/ und fügt ihm dann $1 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetSilenced(target);
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}