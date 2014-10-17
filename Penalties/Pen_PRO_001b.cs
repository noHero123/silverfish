using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_PRO_001b : PenTemplate //roguesdoit
	{

//    verursacht $4 schaden. zieht eine karte.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}