using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_558 : PenTemplate //harrisonjones
	{

//    kampfschrei:/ zerstört die waffe eures gegners. zieht ihrer haltbarkeit entsprechend karten.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}