using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_284 : PenTemplate //azuredrake
	{

//    zauberschaden +1/. kampfschrei:/ zieht eine karte.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}