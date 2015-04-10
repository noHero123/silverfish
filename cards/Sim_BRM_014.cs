using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_014 : SimTemplate //Core Rager
    {


        //    Battlecry: If your hand is empty, gain +3/+3

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.owncards.Count==0)
            {
                p.minionGetBuffed(own, 3, 3);
            }
            if (!own.own && p.enemyAnzCards == 0)
            {
                p.minionGetBuffed(own, 3, 3);
            }
        }

    }
}