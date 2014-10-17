using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_178 : PenTemplate //ancientofwar
	{

//    wählt aus:/ +5 angriff; oder +5 leben und spott/.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}