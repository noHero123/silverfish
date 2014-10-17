using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_610 : PenTemplate //explosivetrap
	{

//    geheimnis:/ wenn euer held angegriffen wird, erleiden alle feinde $2 schaden.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}