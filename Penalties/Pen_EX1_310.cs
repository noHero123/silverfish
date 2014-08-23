using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_310 : PenTemplate //doomguard
	{

//    ansturm/. kampfschrei:/ werft zwei zufällige karten ab.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}