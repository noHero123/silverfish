using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_040 : SimTemplate //Wildwalker
    {

        //Battlecry: Give a friendly Beast +3 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null && target.handcard.card.race == TAG_RACE.PET)
            {
                p.minionGetBuffed(target, 3, 3);
            }
        }

       

    }
}