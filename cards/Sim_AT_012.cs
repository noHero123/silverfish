using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_012 : SimTemplate //Spawn of Shadows
    {

        //Inspire: Deal 4 damage to each hero.

        public override void onInspire(Playfield p, Minion m)
        {
            p.minionGetDamageOrHeal(p.ownHero, 4);
            p.minionGetDamageOrHeal(p.enemyHero, 4);
        }


    }
}