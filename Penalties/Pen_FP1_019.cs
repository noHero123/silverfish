using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_019 : PenTemplate //poisonseeds
	{

//    vernichtet alle diener und ruft für jeden einen treant (2/2) als ersatz herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}