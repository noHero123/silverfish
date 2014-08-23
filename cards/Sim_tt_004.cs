using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_tt_004 : SimTemplate //flesheatingghoul
	{

//    erhält jedes mal +1 angriff, wenn ein diener stirbt.
        public override void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            p.minionGetBuffed(triggerEffectMinion, 1, 0);
        }

	}
}