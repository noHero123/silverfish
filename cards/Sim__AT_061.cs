using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_061 : SimTemplate //Lock and Load
    {

        //   Each time you cast a spell this turn, add a random Hunter card to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            p.lockAndLoads++;
        }


    }

}