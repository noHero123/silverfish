using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_037a : SimTemplate //Living Roots
    {

        //   Choose One - Deal $2 damage; or Summon two 1/1 Saplings..
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            if (target != null) p.minionGetDamageOrHeal(target, dmg);
            
        }

    }


}