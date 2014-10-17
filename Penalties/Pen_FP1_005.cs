using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_005 : PenTemplate //shadeofnaxxramas
	{

//    verstohlenheit/. erhält zu beginn eures zuges +1/+1.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}