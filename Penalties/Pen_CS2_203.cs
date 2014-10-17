using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_203 : PenTemplate //ironbeakowl
	{

//    kampfschrei:/ bringt einen diener zum schweigen/.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}