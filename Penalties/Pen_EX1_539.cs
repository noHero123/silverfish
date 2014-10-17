using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_539 : PenTemplate //killcommand
	{

//    verursacht $3 schaden. verursacht stattdessen $5 schaden, wenn ihr ein wildtier besitzt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}