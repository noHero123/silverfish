using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_595 : PenTemplate //cultmaster
	{

//    zieht jedes mal eine karte, wenn einer eurer anderen diener stirbt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}