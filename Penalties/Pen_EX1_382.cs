using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_382 : PenTemplate //aldorpeacekeeper
	{

//    kampfschrei:/ setzt den angriff eines feindlichen dieners auf 1.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}