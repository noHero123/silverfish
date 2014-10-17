using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_144 : PenTemplate //shadowstep
	{

//    lasst einen befreundeten diener auf eure hand zurückkehren. der diener kostet (2) weniger.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}