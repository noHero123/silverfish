using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_399 : PenTemplate //gurubashiberserker
	{

//    erhält jedes mal +3 angriff, wenn dieser diener schaden erleidet.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}