using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_020 : PenTemplate //avenge
	{

//    geheimnis:/ wenn einer eurer diener stirbt, erhält ein zufälliger befreundeter diener +3/+2.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}