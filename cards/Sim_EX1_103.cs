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

            for (int i = 0; i < temp.Count; i++)
            {
                if((TAG_RACE)temp[i].handcard.card.race == TAG_RACE.MURLOC) p.minionGetBuffed(temp[i], 0, 2);
            }
        }
    }
}
