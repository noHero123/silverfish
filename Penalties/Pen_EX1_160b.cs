using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_160b : PenTemplate //leaderofthepack
	{

//    verleiht euren dienern +1/+1.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}