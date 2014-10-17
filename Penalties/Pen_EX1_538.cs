using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_538 : PenTemplate //unleashthehounds
	{

//    ruft für jeden feindlichen diener einen jagdhund (1/1) mit ansturm/ herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}