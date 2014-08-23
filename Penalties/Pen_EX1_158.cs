using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_158 : PenTemplate //souloftheforest
	{

//    verleiht euren dienern „todesröcheln:/ ruft einen treant (2/2) herbei.“
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}