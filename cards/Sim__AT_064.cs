using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_064 : SimTemplate //Bash
    {

        //   Deal $3 damage. Gain 3 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target != null)
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
                p.minionGetDamageOrHeal(target, dmg);
            }
            p.minionGetArmor((ownplay) ? p.ownHero : p.enemyHero, 3);
        }


    }

}