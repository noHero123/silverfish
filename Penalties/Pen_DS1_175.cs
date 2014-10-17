using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_DS1_175 : PenTemplate //timberwolf
	{

//    eure anderen wildtiere haben +1 angriff.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}