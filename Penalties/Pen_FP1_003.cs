using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_003 : PenTemplate //echoingooze
	{

//    kampfschrei:/ beschwört am ende des zuges eine exakte kopie dieses dieners.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}