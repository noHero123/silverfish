using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS1_113 : PenTemplate //mindcontrol
	{

//    übernehmt die kontrolle über einen feindlichen diener.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}