using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_391 : PenTemplate //slam
	{

//    fügt einem diener $2 schaden zu. zieht eine karte, wenn er überlebt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}