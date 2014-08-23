using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_043 : SimTemplate //twilightdrake
	{

//    kampfschrei:/ erhält +1 leben für jede karte auf eurer hand.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetBuffed(own, 0, (own.own) ? p.owncards.Count : p.enemyAnzCards);
		}


	}
}