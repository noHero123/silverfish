using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_237 : PenTemplate //starvingbuzzard
	{

//    zieht jedes mal eine karte, wenn ihr ein wildtier herbeiruft.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}