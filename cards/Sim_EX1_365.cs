using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_365 : SimTemplate //holywrath
	{
        // todo ask the posibility manager!
//    zieht eine karte und verursacht schaden, der ihren kosten entspricht.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, ownplay);

            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}