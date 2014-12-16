using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_108 : SimTemplate //Recombobulator
    {

        //   Battlecry: Transform a friendly minion into a random minion with the same Cost.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if(target == null) return;
            p.minionTransform(target, target.handcard.card);
        }

    }

}