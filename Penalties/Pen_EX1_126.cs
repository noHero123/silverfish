using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_126 : PenTemplate //betrayal
	{

//    zwingt einen feindlichen diener, seinen schaden benachbarten dienern zuzufügen.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}