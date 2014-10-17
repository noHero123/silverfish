using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_003 : SimTemplate //sacrificialpact
    {

        //    vernichtet einen dämon. stellt bei eurem helden #5 leben wieder her.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            int heal = (ownplay) ? p.getSpellHeal(5) : p.getEnemySpellHeal(5);
            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }

    }
}