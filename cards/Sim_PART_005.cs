using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_PART_005 : SimTemplate //Emergency Coolant
    {

        //  Freeze a minion. 


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.frozen = true;
        }


    }

}