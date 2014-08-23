using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_006 : PenTemplate //alarmobot
	{

//    tauscht zu beginn eures zuges diesen diener gegen einen zufälligen diener auf eurer hand aus.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}