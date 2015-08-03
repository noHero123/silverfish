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
            if (p.isServer)
            {
                if (own.own) { p.owedRecall += 1; } else { p.enemyRecall += 1; };
                int random = p.getRandomNumber_SERVER(1, 4);
                p.minionGetBuffed(own, random, 0);
                return;
            }

            if (own.own) { p.owedRecall += 1; } else { p.enemyRecall += 1; };
            p.minionGetBuffed(own, 2, 0);
		}

	}
}