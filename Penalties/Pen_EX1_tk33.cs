using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_tk33 : PenTemplate //inferno
	{

//    heldenfähigkeit/\nbeschwört eine höllenbestie (6/6).
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}