using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_013 : PenTemplate //kelthuzad
	{

//    ruft am ende jedes zuges alle befreundeten diener herbei, die in diesem zug gestorben sind.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}