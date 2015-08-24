using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_096 : SimTemplate //Clockwork Knight
    {

        //   Battlecry: Give a friendly Mech +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (target == null) return;
            p.minionGetBuffed(target, 1, 1);
        }


    }

}