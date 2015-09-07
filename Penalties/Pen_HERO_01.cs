using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_HERO_01 : PenTemplate //garroshhellscream
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
			return 0;
		}
	}
}
