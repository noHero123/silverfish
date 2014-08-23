using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_613 : PenTemplate //edwinvancleef
	{

//    combo:/ erhält für jede in diesem zug bereits ausgespielte karte +2/+2.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}