using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_613: SimTemplate//edwin van cleefe
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            p.minionGetBuffed(own, p.cardsPlayedThisTurn * 2, p.cardsPlayedThisTurn * 2);
        }

    }
}
