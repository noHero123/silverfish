using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_614 : PenTemplate //illidanstormrage
	{

//    beschwört jedes mal eine flamme von azzinoth (2/1), wenn ihr eine karte ausspielt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}