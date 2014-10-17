using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_258 : PenTemplate //unboundelemental
	{

//    erhält jedes mal +1/+1, wenn ihr eine karte mit überladung/ ausspielt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}