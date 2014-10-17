using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_004 : PenTemplate //madscientist
	{

//    todesröcheln:/ legt ein geheimnis/ aus eurem deck auf das schlachtfeld.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}