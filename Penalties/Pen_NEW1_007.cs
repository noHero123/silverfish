using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_007 : PenTemplate //starfall
	{

//    wählt aus:/ fügt einem diener $5 schaden zu; oder fügt allen feindlichen dienern $2 schaden zu.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}