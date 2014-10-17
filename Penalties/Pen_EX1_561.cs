using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_561 : PenTemplate //alexstrasza
	{

//    kampfschrei:/ setzt das verbleibende leben eines helden auf 15.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}