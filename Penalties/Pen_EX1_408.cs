using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_408 : PenTemplate //mortalstrike
	{

//    verursacht $4 schaden. verursacht stattdessen $6 schaden, wenn euer held max. 12 leben hat.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}