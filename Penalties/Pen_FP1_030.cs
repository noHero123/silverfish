using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_030 : PenTemplate //loatheb
	{

//    kampfschrei:/ im nächsten zug kosten zauber für euren gegner (5) mehr.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}