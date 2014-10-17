using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_091 : PenTemplate //cabalshadowpriest
	{

//    kampfschrei:/ übernehmt die kontrolle über einen feindlichen diener mit max. 2 angriff.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}