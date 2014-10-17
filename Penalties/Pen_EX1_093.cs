using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_093 : PenTemplate //defenderofargus
	{

//    kampfschrei:/ verleiht benachbarten dienern +1/+1 und spott/.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}