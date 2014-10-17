using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_026 : PenTemplate //violetteacher
	{

//    ruft jedes mal einen violetten lehrling (1/1) herbei, wenn ihr einen zauber wirkt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}