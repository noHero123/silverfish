using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_007 : PenTemplate //acolyteofpain
	{

//    zieht jedes mal eine karte, wenn dieser diener schaden erleidet.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}