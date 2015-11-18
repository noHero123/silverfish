using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_052 : SimTemplate //Totem Golem
    {

        //Overload: (1).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.changeRecall(own.own, 1);
        }

       

    }
}