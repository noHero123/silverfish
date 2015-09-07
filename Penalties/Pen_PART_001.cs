using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_PART_001 : PenTemplate //armorplating
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
			return 0;
		}
	}
}
