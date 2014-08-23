using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_101 : PenTemplate //reinforce
	{

//    heldenfähigkeit/\nruft einen rekruten der silbernen hand (1/1) herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}