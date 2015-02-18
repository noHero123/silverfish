using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_028 : SimTemplate //undertaker
	{

//    erhält jedes mal +1 attack, wenn ihr einen diener mit todesröcheln/ herbeiruft.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own)
            {
                if (summonedMinion.handcard.card.deathrattle) p.minionGetBuffed(triggerEffectMinion,1,0);
            }
        }

	}
}