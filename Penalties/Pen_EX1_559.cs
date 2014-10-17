using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_559 : PenTemplate //archmageantonidas
	{

//    erhaltet jedes mal einen „feuerball“-zauber auf eure hand, wenn ihr einen zauber wirkt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}