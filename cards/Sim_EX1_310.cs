using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_310 : SimTemplate //doomguard
	{

//    ansturm/. kampfschrei:/ werft zwei zufällige karten ab.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.owncarddraw -= Math.Min(2, p.owncards.Count);
                p.owncards.RemoveRange(0, Math.Min(2, p.owncards.Count));
            }
		}

	}
}