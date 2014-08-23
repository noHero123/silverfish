using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_031 : PenTemplate //baronrivendare
	{

//    die todesröcheln/-effekte eurer diener werden 2-mal ausgelöst.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}