using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_103 : SimTemplate//Coldlight Seer
    {

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;

            foreach (Minion t in temp)
            {
                if ((TAG_RACE)t.handcard.card.race == TAG_RACE.MURLOC) p.minionGetBuffed(t, 0, 2);
            }
        }
    }
}
