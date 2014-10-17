using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_160 : PenTemplate //powerofthewild
	{

//    wählt aus:/ verleiht euren dienern +1/+1; oder ruft einen panther (3/2) herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}