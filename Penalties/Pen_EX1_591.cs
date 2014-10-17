using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_591 : PenTemplate //auchenaisoulpriest
	{

//    eure karten und fähigkeiten, die leben wiederherstellen, verursachen stattdessen nun schaden.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}