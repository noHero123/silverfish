using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_041b : SimTemplate //Dark Wispers
    {

        //   Give a minion +5/+5 and Taunt&lt.

        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 5, 5);
            target.taunt = true;
        }


    }

}