using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_009 : SimTemplate //healingtotem
	{

//    stellt am ende eures zuges bei allen befreundeten dienern 1 leben wieder her.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int heal = (triggerEffectMinion.own) ? p.getMinionHeal(1) : p.getEnemyMinionHeal(1);
                p.allMinionOfASideGetDamage(turnEndOfOwner, -heal);
            }
        }

	}
}