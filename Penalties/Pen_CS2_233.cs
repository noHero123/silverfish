using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_233 : PenTemplate //bladeflurry
	{

//    zerstört eure waffe und fügt allen feinden den schaden dieser waffe zu.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}