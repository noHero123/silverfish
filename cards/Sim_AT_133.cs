using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_133 : SimTemplate //Gadgetzan Jouster
    {

        //Battlecry: Reveal a minion in each deck. If yours costs more, gain +1/+1.


        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            //Random minion!


            if (p.isServer)
            {
                //TODO
                p.minionGetBuffed(own, 1, 1);
        
                return;
            }
            //we assume we get the buff!
            p.minionGetBuffed(own, 1, 1);
        }

    }
}