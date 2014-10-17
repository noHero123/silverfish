using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_030 : PenTemplate //deathwing
	{

//    kampfschrei:/ vernichtet alle anderen diener und werft eure hand ab.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}