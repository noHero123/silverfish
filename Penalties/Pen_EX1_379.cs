using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_379 : PenTemplate //repentance
	{

//    geheimnis:/ wenn euer gegner einen diener ausspielt, wird dessen leben auf 1 verringert.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}