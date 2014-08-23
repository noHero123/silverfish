using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_133 : PenTemplate //perditionsblade
	{

//    kampfschrei:/ verursacht 1 schaden. combo:/ verursacht stattdessen 2 schaden.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}