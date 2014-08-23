using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_145 : PenTemplate //preparation
	{

//    der nächste zauber, den ihr in diesem zug wirkt, kostet (3) weniger.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}