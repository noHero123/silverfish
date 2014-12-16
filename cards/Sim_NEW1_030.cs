using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_030 : SimTemplate //deathwing
	{

//    kampfschrei:/ vernichtet alle anderen diener und werft eure hand ab.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.allMinionsGetDestroyed();
            if (own.own)
            {
                p.owncards.Clear();
                p.triggerCardsChanged(true);
            }
            else
            {
                p.enemycarddraw = 0;
                p.enemyAnzCards = 0;
                p.triggerCardsChanged(false);
            }
		}

	

	}
}