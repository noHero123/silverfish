using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_154a : SimTemplate //wrath
	{

//    fügt einem diener $3 schaden zu.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = 0;
            damage = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            p.minionGetDamageOrHeal(target, damage);
        }

	}
}