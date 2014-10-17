using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_124 : SimTemplate //eviscerate
	{

//    verursacht $2 schaden. combo:/ verursacht stattdessen $4 schaden.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            if (p.cardsPlayedThisTurn == 0) dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}