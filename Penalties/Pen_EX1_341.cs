using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_341 : PenTemplate //lightwell
	{

//    stellt zu beginn eures zuges bei einem verletzten befreundeten charakter 3 leben wieder her.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}