using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_597 : PenTemplate //impmaster
	{

//    fügt am ende eures zuges diesem diener 1 schaden zu und beschwört einen wichtel (1/1).
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}