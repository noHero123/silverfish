using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_409 : PenTemplate //upgrade
	{

//    wenn ihr eine waffe habt, erhält sie +1/+1. legt anderenfalls eine waffe (1/3) an.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}