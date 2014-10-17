using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_323 : PenTemplate //lordjaraxxus
	{

//    kampfschrei:/ vernichtet euren helden und ersetzt ihn durch lord jaraxxus.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}