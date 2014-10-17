using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_097 : PenTemplate //truesilverchampion
	{

//    stellt bei eurem helden jedes mal 2 leben wieder her, wenn er angreift.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}