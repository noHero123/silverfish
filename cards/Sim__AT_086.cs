using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_086 : SimTemplate //Saboteur
    {

        //Battlecry: Your opponent's Hero Power costs (5) more next turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ownSaboteur++;
            else p.enemySaboteur++;
        }

        



    }

}