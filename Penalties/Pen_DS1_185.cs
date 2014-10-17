using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_DS1_185 : PenTemplate //arcaneshot
	{

//    verursacht $2 schaden.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}