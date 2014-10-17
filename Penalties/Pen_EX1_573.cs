using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_573 : PenTemplate //cenarius
	{

//    wählt aus:/ verleiht euren anderen dienern +2/+2; oder ruft zwei treants (2/2) mit spott/ herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}