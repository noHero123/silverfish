using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_027 : PenTemplate //stoneskingargoyle
	{

//    stellt zu beginn eures zuges das volle leben dieses dieners wieder her.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}