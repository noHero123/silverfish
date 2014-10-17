using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_094 : SimTemplate //hammerofwrath
	{

//    verursacht $3 schaden. zieht eine karte.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(CardDB.cardName.unknown, ownplay);
		}

	}
}