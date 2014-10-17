using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_596 : PenTemplate //demonfire
	{

//    fügt einem diener $2 schaden zu. wenn das ziel ein verbündeter dämon ist, erhält er stattdessen +2/+2.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}