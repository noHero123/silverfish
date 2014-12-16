using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_030 : SimTemplate //Anodized Robo Cub
    {

        //    Taunt. Choose One - +1 Attack; or +1 Health.

           public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (choice == 1)
            {
                p.minionGetBuffed(own, 1, 0);
            }
            if (choice == 2)
            {
                p.minionGetBuffed(own, 0, 1);
            }
		}


    }

}