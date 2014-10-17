using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_037 : SimTemplate //frostshock
	{

//    fügt einem feindlichen charakter $1 schaden zu und friert/ ihn ein.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            target.frozen = true;
            p.minionGetDamageOrHeal(target, dmg);
            
		}

	}
}