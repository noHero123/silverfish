using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_102 : SimTemplate //demolisher
	{

//    fügt zu beginn eures zuges einem zufälligen feind 2 schaden zu.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                List<Minion> temp2 = (turnStartOfOwner)? p.enemyMinions : p.ownMinions;
                bool dmgdone = false;
                foreach (Minion mins in temp2.ToArray())
                {
                    p.minionGetDamageOrHeal(mins, 2);
                    dmgdone = true;
                    break;
                }
                if (!dmgdone)
                {
                    if (turnStartOfOwner) { p.minionGetDamageOrHeal(p.enemyHero, 2); } else { p.minionGetDamageOrHeal(p.ownHero, 2); }
                };
            }
        }

	}
}