using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_076 : PenTemplate //pintsizedsummoner
	{

//    der erste diener, den ihr in einem zug ausspielt, kostet (1) weniger.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}