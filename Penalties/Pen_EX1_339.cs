using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_339 : PenTemplate //thoughtsteal
	{

//    kopiert 2 karten aus dem deck eures gegners und fügt sie eurer hand hinzu.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}