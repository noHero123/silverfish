using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_154 : PenTemplate //wrath
	{

//    wählt aus:/ fügt einem diener $3 schaden zu; oder fügt einem diener $1 schaden zu und zieht eine karte.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}