using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_061 : SimTemplate //drainlife
    {

        //    verursacht $2 schaden. stellt bei eurem helden #2 leben wieder her.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            int heal = (ownplay) ? p.getSpellHeal(2) : p.getEnemySpellHeal(2);
            p.minionGetDamageOrHeal(target, dmg);

            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }

    }
}