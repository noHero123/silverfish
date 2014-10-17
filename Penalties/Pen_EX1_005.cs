using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_005 : PenTemplate //biggamehunter
	{

//    kampfschrei:/ vernichtet einen diener mit mind. 7 angriff.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}