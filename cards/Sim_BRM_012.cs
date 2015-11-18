using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_012 : SimTemplate //Fireguard Destroyer
	{

        //    Battlecry: Gain 1-4 Attack. &lt;b&gt;Overload:&lt;/b&gt; (1)
       
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.changeRecall(own.own, 1);
            if (p.isServer)
            {
                int random = p.getRandomNumber_SERVER(1, 4);
                p.minionGetBuffed(own, random, 0);
                return;
            }

            p.minionGetBuffed(own, 2, 0);
		}

	}
}