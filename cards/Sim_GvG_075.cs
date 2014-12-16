using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_075 : SimTemplate //Ship's Cannon
    {

        //   Whenever you summon a Pirate, deal 2 damage to a random enemy.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own)
            {
                List<Minion> temp = (triggerEffectMinion.own) ? p.enemyMinions : p.ownMinions;
                Minion m = p.searchRandomMinion(temp, Playfield.searchmode.searchHighestHP);
                if (m == null) return;
                p.minionGetDamageOrHeal(m, 2, true);
            }
        }


    }

}