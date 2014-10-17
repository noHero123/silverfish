using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_tt_004 : PenTemplate //flesheatingghoul
	{

//    erhält jedes mal +1 angriff, wenn ein diener stirbt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}