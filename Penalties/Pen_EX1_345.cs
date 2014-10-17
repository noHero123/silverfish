using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_345 : PenTemplate //mindgames
	{

//    legt eine kopie eines zufälligen dieners aus dem deck eures gegners auf das schlachtfeld.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}