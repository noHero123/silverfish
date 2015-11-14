using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_001 : SimTemplate //Flame Lance
    {

        //   Deal $8 damage to a minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            int dmg = (ownplay) ? p.getSpellDamageDamage(8) : p.getEnemySpellDamageDamage(8);
            p.minionGetDamageOrHeal(target, dmg);
        }


    }

}