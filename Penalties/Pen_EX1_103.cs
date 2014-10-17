using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_103 : PenTemplate //coldlightseer
	{

//    kampfschrei:/ verleiht allen anderen murlocs +2 leben.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}