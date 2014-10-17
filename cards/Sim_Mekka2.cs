using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_Mekka2 : SimTemplate //repairbot
    {

        //    stellt am ende eures zuges bei einem verletzten charakter 6 leben wieder her.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {

                Minion tm = null;
                int hl = (triggerEffectMinion.own) ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);
                int heal = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.maxHp - m.Hp > heal)
                    {
                        tm = m;
                        heal = m.maxHp - m.Hp;
                    }
                }
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.maxHp - m.Hp > heal)
                    {
                        tm = m;
                        heal = m.maxHp - m.Hp;
                    }
                }
                if (heal >= 1)
                {
                    p.minionGetDamageOrHeal(tm, -hl);
                }
                else
                {
                    p.minionGetDamageOrHeal(p.ownHero.Hp < 30 ? p.ownHero : p.enemyHero, -hl);
                }

            }
        }

    }
}