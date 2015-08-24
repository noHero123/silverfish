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
            bool reduceToZero = false;
            if(ownplay && p.anzOwnFizzlebang >=1)
            {
                reduceToZero=true;
            }
            if(!ownplay && p.anzEnemyFizzlebang>=1)
            {
                reduceToZero=true;
            }
            p.drawACard(CardDB.cardIDEnum.None, ownplay, false, reduceToZero);

            int dmg = 2;
            if (ownplay)
            {
                dmg += p.anzOwnFallenHeros;
                if (p.doublepriest >= 1) dmg *= (2 * p.doublepriest);
                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }
            else
            {
                dmg += p.anzEnemyFallenHeros;
                if (p.enemydoublepriest >= 1) dmg *= (2 * p.enemydoublepriest);
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
        }


	}
}