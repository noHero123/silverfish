using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_PART_007 : SimTemplate //Whirling Blades
    {

        //Give a minion +1 Attack.   


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 1, 0);
        }


    }

}