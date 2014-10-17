using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_302 : PenTemplate //mortalcoil
	{

//    fügt einem diener $1 schaden zu. zieht eine karte, wenn er dadurch vernichtet wird.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}