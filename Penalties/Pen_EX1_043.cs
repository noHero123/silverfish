using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_043 : PenTemplate //twilightdrake
	{

//    kampfschrei:/ erhält +1 leben für jede karte auf eurer hand.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}