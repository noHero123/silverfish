using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_024 : PenTemplate //captaingreenskin
	{

//    kampfschrei:/ verleiht eurer waffe +1/+1.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}