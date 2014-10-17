using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_594 : PenTemplate //vaporize
	{

//    geheimnis:/ wenn ein diener euren helden angreift, wird er vernichtet.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}