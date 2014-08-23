using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_GAME_002 : PenTemplate //avatarofthecoin
	{

//    i&gt;ihr habt den münzwurf verloren, aber einen freund gewonnen./i&gt;
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}