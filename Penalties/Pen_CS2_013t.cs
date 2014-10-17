using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_013t : PenTemplate //excessmana
	{

//    zieht eine karte. i&gt;(ihr könnt nur 10 mana in eurer leiste haben.)/i&gt;
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}