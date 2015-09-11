using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_AT_063t : PenTemplate //acidmaw the small one
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
			return 0;
		}
	}
}
