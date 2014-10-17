using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_027 : SimTemplate //southseacaptain
	{

//    eure anderen piraten haben +1/+1.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnSouthseacaptain++;
                foreach (Minion m in p.ownMinions)
                {
                    if((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 1, 1);
                }
            }
            else
            {
                p.anzEnemySouthseacaptain++;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 1, 1);
                }
            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnSouthseacaptain--;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, -1, -1);
                }
            }
            else
            {
                p.anzEnemySouthseacaptain--;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, -1, -1);
                }
            }
        }


	}
}