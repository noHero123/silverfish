using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DS1_178 : SimTemplate //tundrarhino
	{

//    eure wildtiere haben ansturm/.
        //todo charge?
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnTundrarhino++;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) p.minionGetCharge(m);
                }
            }
            else
            {
                p.anzEnemyTundrarhino++;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) p.minionGetCharge(m);
                }
            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnTundrarhino--;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) p.minionLostCharge(m);
                }
            }
            else
            {
                p.anzEnemyTundrarhino--;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) p.minionLostCharge(m);
                }
            }
        }

	}
}