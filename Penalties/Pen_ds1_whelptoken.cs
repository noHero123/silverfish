using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_ds1_whelptoken : PenTemplate //whelp
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
			return 0;
		}
	}
}
