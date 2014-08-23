using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_544 : PenTemplate //flare
	{

//    alle diener verlieren verstohlenheit/. zerstört alle feindlichen geheimnisse/. zieht eine karte.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}