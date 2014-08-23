using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_005 : PenTemplate //claw
	{

//    verleiht eurem helden +2 angriff in diesem zug und 2 rüstung.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}