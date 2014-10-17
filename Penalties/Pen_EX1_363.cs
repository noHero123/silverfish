using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_363 : PenTemplate //blessingofwisdom
	{

//    wählt einen diener aus. zieht jedes mal eine karte, wenn er angreift.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}