using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_298 : PenTemplate //ragnarosthefirelord
	{

//    kann nicht angreifen. fügt am ende eures zuges einem zufälligen feind 8 schaden zu.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}