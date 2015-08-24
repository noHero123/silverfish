using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_049 : SimTemplate //Thunder Bluff Valiant
    {

        //insprire: Give your Totems +2 Attack

        public override void onInspire(Playfield p, Minion m)
        {
            foreach (Minion min in (m.own) ? p.ownMinions : p.enemyMinions)
            {
                if (min.handcard.card.race == TAG_RACE.TOTEM) p.minionGetBuffed(min, 2, 0);
            }
        }



    }

}