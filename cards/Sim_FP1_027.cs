using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_027 : SimTemplate //stoneskingargoyle
	{

//    stellt zu beginn eures zuges das volle leben dieses dieners wieder her.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                int heal = (triggerEffectMinion.own) ? p.getMinionHeal(triggerEffectMinion.maxHp - triggerEffectMinion.Hp) : p.getEnemyMinionHeal(triggerEffectMinion.maxHp - triggerEffectMinion.Hp);
                p.minionGetDamageOrHeal(triggerEffectMinion, -heal);
            }
        }

	}
}