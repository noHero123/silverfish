using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_028 : PenTemplate //undertaker
	{

//    erhält jedes mal +1/+1, wenn ihr einen diener mit todesröcheln/ herbeiruft.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}