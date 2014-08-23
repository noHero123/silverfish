using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_023 : PenTemplate //darkcultist
	{

//    todesröcheln:/ verleiht einem zufälligen befreundeten diener +3 leben.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}