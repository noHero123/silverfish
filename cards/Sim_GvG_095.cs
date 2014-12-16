using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_095 : SimTemplate //Goblin Sapper
    {

        //  Has +4 Attack while your opponent has 6 or more cards in hand. 

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int anz = (own.own) ? p.enemyAnzCards : p.owncards.Count;
            if (anz >= 6)
            {
                p.minionGetBuffed(own, 4, 0);
            }
        }

    }

}