using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_056 : SimTemplate //lifetap
	{

//    heldenfähigkeit/\nzieht eine karte und erleidet 2 schaden.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);
            if (ownplay)
            {
                p.minionGetDamageOrHeal(p.ownHero, 2);
            }
            else
            {
                p.minionGetDamageOrHeal(p.enemyHero, 2);
            }
        }


	}
}