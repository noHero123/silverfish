using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_334 : PenTemplate //shadowmadness
	{

//    übernehmt bis zum ende des zuges die kontrolle über einen feindlichen diener mit max. 3 angriff.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}