using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_Mekka4t : PenTemplate //chicken
	{

//    i&gt;put, put, put!/i&gt;
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}