using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_Mekka3 : PenTemplate //emboldener3000
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
			return 0;
		}
	}
}
