using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_578 : SimTemplate //savagery
	{

//    fügt einem diener schaden zu, der dem angriff eures helden entspricht.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(p.ownHero.Angr) : p.getEnemySpellDamageDamage(p.enemyHero.Angr);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}