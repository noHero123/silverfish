using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_076 : SimTemplate //Explosive Sheep
    {

        //  Deathrattle: Deal 2 damage to all minions. 

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(2);
        }


    }

}