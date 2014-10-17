using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_025 : PenTemplate //bloodsailcorsair
	{

//    kampfschrei:/ zieht 1 haltbarkeit von der waffe eures gegners ab.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}