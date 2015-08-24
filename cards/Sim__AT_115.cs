using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_115 : SimTemplate //Fencing Coach
    {

        //Battlecry: The next time you use your Hero Power, it costs (2) less.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (own.own) p.anzOwnFencingCoach++;
            else p.anzEnemyFencingCoach++;

        }

       

    }
}