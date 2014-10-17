using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_301 : PenTemplate //felguard
	{

//    spott/. kampfschrei:/ zerstört einen eurer manakristalle.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}