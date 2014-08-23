using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_306 : SimTemplate //succubus
	{

//    kampfschrei:/ werft eine zufällige karte ab.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.owncarddraw -= Math.Min(1, p.owncards.Count);
                p.owncards.RemoveRange(0, Math.Min(1, p.owncards.Count));
            }
            else
            {
                p.enemycarddraw--;
                p.enemyAnzCards--;
            }
		}

	}
}