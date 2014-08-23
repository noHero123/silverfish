using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_009 : PenTemplate //deathlord
	{

//    spott. todesröcheln:/ euer gegner legt einen diener aus seinem deck auf das schlachtfeld.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}