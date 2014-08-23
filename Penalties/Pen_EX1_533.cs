using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_533 : PenTemplate //misdirection
	{

//    geheimnis:/ wenn ein charakter euren helden angreift, greift er stattdessen einen zufälligen anderen charakter an.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}