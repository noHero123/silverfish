using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_050 : PenTemplate //coldlightoracle
	{

//    kampfschrei:/ jeder spieler zieht 2 karten.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}