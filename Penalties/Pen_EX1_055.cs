using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_055 : PenTemplate //manaaddict
	{

//    erhält jedes mal +2 angriff in diesem zug, wenn ihr einen zauber wirkt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}