using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_028 : PenTemplate //blizzard
	{

//    fügt allen feindlichen dienern $2 schaden zu und friert/ sie ein.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}