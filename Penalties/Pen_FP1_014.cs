using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_014 : PenTemplate //stalagg
	{

//    todesröcheln:/ ruft thaddius herbei, wenn feugen in diesem duell bereits gestorben ist.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}