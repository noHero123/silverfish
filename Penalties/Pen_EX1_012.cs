using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_012 : PenTemplate //bloodmagethalnos
	{

//    zauberschaden +1/. todesröcheln:/ zieht eine karte.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}