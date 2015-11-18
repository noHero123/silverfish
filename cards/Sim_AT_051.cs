using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_051 : SimTemplate //Elemental Destruction
    {

        //    Deal $4-$5 damage to all minions. Overload: (5)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            p.changeRecall(ownplay, 5);
            if (p.isServer)
            {

                foreach (Minion m in p.ownMinions)
                {
                    int dmgr = p.getRandomNumber_SERVER(4, 5);
                    dmgr = (ownplay) ? p.getSpellDamageDamage(dmgr) : p.getEnemySpellDamageDamage(dmgr);
                    p.minionGetDamageOrHeal(m, dmgr);
                }

                foreach (Minion m in p.enemyMinions)
                {
                    int dmgr = p.getRandomNumber_SERVER(4, 5);
                    dmgr = (ownplay) ? p.getSpellDamageDamage(dmgr) : p.getEnemySpellDamageDamage(dmgr);
                    p.minionGetDamageOrHeal(m, dmgr);
                }

                return;
            }

            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.allMinionsGetDamage(dmg);
            
        }

    }
}