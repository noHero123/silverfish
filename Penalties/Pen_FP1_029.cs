using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_029 : PenTemplate //dancingswords
	{

//    todesröcheln:/ euer gegner zieht eine karte.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}