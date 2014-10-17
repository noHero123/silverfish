using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_124 : PenTemplate //eviscerate
	{

//    verursacht $2 schaden. combo:/ verursacht stattdessen $4 schaden.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}