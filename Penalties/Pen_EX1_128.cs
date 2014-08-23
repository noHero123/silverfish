using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_128 : PenTemplate //conceal
	{

//    verleiht euren dienern bis zu eurem nächsten zug verstohlenheit/.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}