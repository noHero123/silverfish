using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_004 : SimTemplate //Twilight Whelp
    {

        //Battlecry: If you're holding a Dragon, gain +2 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Handmanager.Handcard> temp = p.owncards;

            bool owndragons = (own.own) ? false : true;
            foreach (Handmanager.Handcard hc in temp)
            {
                if (hc.card.race == TAG_RACE.DRAGON) owndragons = true;
            }
            if (owndragons) p.minionGetBuffed(own, 0, 2);
        }

    }
}