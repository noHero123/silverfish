using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_DREAM_04 : PenTemplate //dream
	{

//    lasst einen diener auf die hand seines besitzers zurückkehren.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}