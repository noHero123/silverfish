using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_033 : SimTemplate //Tree of Life
    {

        //    Restore all characters to full Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                int heal = (ownplay) ? p.getSpellHeal(m.maxHp) : p.getEnemySpellHeal(m.maxHp);
                p.minionGetDamageOrHeal(m, -heal);
            }
            foreach (Minion m in p.enemyMinions)
            {
                int heal = (ownplay) ? p.getSpellHeal(m.maxHp) : p.getEnemySpellHeal(m.maxHp);
                p.minionGetDamageOrHeal(m, -heal);
            }

            int heal2 = (ownplay) ? p.getSpellHeal(p.enemyHero.maxHp) : p.getEnemySpellHeal(p.enemyHero.maxHp);
            p.minionGetDamageOrHeal(p.enemyHero, -heal2);

            heal2 = (ownplay) ? p.getSpellHeal(p.ownHero.maxHp) : p.getEnemySpellHeal(p.ownHero.maxHp);
            p.minionGetDamageOrHeal(p.ownHero, -heal2);
        }


    }

}