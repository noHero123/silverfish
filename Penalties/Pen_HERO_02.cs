using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_HERO_02 : PenTemplate //thrall
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
			return 0;
		}
	}
}
