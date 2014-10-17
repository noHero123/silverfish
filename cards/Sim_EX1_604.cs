using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_604 : SimTemplate //frothingberserker
	{

//    erhält jedes mal +1 angriff, wenn ein diener schaden erleidet.

        public override void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, bool ownDmgdmin)
        {
            p.minionGetBuffed(triggerEffectMinion, 1, 0);
        }

	}
}