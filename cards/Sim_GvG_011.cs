using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_011 : SimTemplate //Shrinkmeister
    {

        //    Your Mechs cost (1) less.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetTempBuff(target, -2, 0);
            }
        }


    }

}