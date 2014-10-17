using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_556 : PenTemplate //harvestgolem
	{

//    todesröcheln:/ ruft einen beschädigten golem (2/1) herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}