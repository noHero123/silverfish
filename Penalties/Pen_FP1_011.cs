using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_011 : PenTemplate //webspinner
	{

//    todesröcheln:/ fügt eurer hand ein zufälliges wildtier hinzu.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}