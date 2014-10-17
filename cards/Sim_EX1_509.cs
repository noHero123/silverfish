using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_509 : SimTemplate //murloctidecaller
	{

//    erhält jedes mal +1 angriff, wenn ein murloc herbeigerufen wird.
        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if ((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.MURLOC) p.minionGetBuffed(triggerEffectMinion, 1, 0);
        }

	}
}