using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_308 : SimTemplate //soulfire
	{

//    verursacht $4 schaden. werft eine zufällige karte ab.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);

            if (p.isServer)
            {
                p.discardRandomCard_SERVER(ownplay);
                return;
            }

            p.disCardACard(ownplay);
		}

	}
}