using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_062 : SimTemplate //oldmurkeye
	{

//    ansturm/. hat +1 angriff für jeden anderen murloc auf dem schlachtfeld.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            foreach (Minion m in p.ownMinions)
            {
                if (m.handcard.card.race == TAG_RACE.MURLOC)
                {
                    p.minionGetBuffed(own, 1, 0);
                }
            }

            foreach (Minion m in p.enemyMinions)
            {
                if (m.handcard.card.race == TAG_RACE.MURLOC)
                {
                    p.minionGetBuffed(own, 1, 0);
                }
            }
		}

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (summonedMinion.handcard.card.race == TAG_RACE.MURLOC)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }

        public override void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            if (diedMinion.handcard.card.race == TAG_RACE.MURLOC)
            {
                p.minionGetBuffed(triggerEffectMinion, -1, 0);
            }
        }

	}
}