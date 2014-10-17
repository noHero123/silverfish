using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_130 : PenTemplate //noblesacrifice
	{

//    geheimnis:/ wenn ein feind angreift, ruft ihr einen verteidiger (2/1) als neues ziel herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}