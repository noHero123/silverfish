using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_136 : PenTemplate //redemption
	{

//    geheimnis:/ wenn einer eurer diener stirbt, wird er mit 1 leben wiederbelebt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}