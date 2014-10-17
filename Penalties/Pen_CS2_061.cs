using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_061 : PenTemplate //drainlife
	{

//    verursacht $2 schaden. stellt bei eurem helden #2 leben wieder her.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}