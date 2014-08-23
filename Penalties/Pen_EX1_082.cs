using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_082 : PenTemplate //madbomber
	{

//    kampfschrei:/ verursacht 3 schaden, der zufällig auf alle anderen charaktere aufgeteilt wird.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}