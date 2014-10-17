using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_315 : PenTemplate //summoningportal
	{

//    eure diener kosten (2) weniger, aber nicht weniger als (1).
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}