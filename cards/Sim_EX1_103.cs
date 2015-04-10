using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_103 : SimTemplate//Coldlight Seer
    {
        // Battlecry:: Give ALL other Murlocs +2 Health.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            foreach (Minion t in p.ownMinions)
            {
                if ((TAG_RACE)t.handcard.card.race == TAG_RACE.MURLOC) p.minionGetBuffed(t, 0, 2);
            }

            foreach (Minion t in p.enemyMinions)
            {
                if ((TAG_RACE)t.handcard.card.race == TAG_RACE.MURLOC) p.minionGetBuffed(t, 0, 2);
            }
        }
    }
}
