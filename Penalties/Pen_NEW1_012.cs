using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_012 : PenTemplate //manawyrm
	{

//    erhält jedes mal +1 angriff, wenn ihr einen zauber wirkt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}