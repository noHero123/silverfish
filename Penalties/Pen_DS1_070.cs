using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_DS1_070 : PenTemplate //houndmaster
	{

//    kampfschrei:/ verleiht einem befreundeten wildtier +2/+2 und spott/.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}