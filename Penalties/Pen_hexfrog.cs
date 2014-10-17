using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_hexfrog : PenTemplate //frog
	{

//    spott/
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}