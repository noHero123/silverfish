using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_008 : SimTemplate //Dark Iron Skulker
    {

        //   Battlecry: Deal 2 damage to all undamaged enemy minions.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int dmg = 2;
            List<Minion> temp = (own.own) ? p.enemyMinions : p.ownMinions;

            foreach (Minion m in temp)
            {
                if (m.maxHp == m.Hp)
                {
                    bool dmgloss = true;
                    if (m.allreadyAttacked) dmgloss = false;
                    p.minionGetDamageOrHeal(m, dmg, dmgloss);
                }
            }
        }


    }

}