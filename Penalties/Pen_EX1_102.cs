using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_102 : PenTemplate //demolisher
	{

//    fügt zu beginn eures zuges einem zufälligen feind 2 schaden zu.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}