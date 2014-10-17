using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_583 : PenTemplate //priestessofelune
	{

//    kampfschrei:/ stellt bei eurem helden 4 leben wieder her.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}