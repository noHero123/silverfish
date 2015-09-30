using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_507 : SimTemplate //murlocwarleader
	{

//    alle anderen murlocs haben +2/+1.
        public override void onAuraStarts(Playfield p, Minion own)
		{
            p.anzMurlocWarleader++;
                foreach (Minion m in p.ownMinions)
                {
                    if((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 2, 1);
                }
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 2, 1);
                }
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.anzMurlocWarleader--;
                foreach (Minion mn in p.ownMinions)
                {
                    if((TAG_RACE)mn.handcard.card.race == TAG_RACE.MURLOC && mn.entitiyID != m.entitiyID) p.minionGetBuffed(mn, -2, -1);
                }
                foreach (Minion mn in p.enemyMinions)
                {
                    if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.MURLOC && mn.entitiyID != m.entitiyID) p.minionGetBuffed(mn, -2, -1);
                }
		}
        


	}
}