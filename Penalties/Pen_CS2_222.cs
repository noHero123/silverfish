using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_222 : PenTemplate //stormwindchampion
	{

//    eure anderen diener haben +1/+1.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}