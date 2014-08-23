using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_584 : PenTemplate //ancientmage
	{

//    kampfschrei:/ verleiht benachbarten dienern zauberschaden +1/.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}