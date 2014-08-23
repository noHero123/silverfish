using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_411 : PenTemplate //gorehowl
	{

//    angriffe gegen diener kosten 1 angriff anstatt 1 haltbarkeit.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}