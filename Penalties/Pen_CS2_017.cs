using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_017 : PenTemplate //shapeshift
	{

//    heldenfähigkeit/\n+1 angriff in diesem zug.\n+1 rüstung.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}