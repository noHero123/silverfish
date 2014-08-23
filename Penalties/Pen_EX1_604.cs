using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_604 : PenTemplate //frothingberserker
	{

//    erhält jedes mal +1 angriff, wenn ein diener schaden erleidet.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}