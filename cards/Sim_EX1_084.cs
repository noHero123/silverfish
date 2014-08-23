using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_084 : SimTemplate //warsongcommander
	{

//    jedes mal, wenn ihr einen diener mit max. 3 angriff herbeiruft, erhält dieser ansturm/.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own && summonedMinion.handcard.card.Attack <= 3 )
            {
                p.minionGetCharge(summonedMinion);
            }
        }

	}
}