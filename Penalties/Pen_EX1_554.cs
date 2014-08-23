using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_554 : PenTemplate //snaketrap
	{

//    geheimnis:/ wenn einer eurer diener angegriffen wird, ruft ihr drei schlangen (1/1) herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}