using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_557 : PenTemplate //natpagle
	{

//    zu beginn eures zuges besteht eine chance von 50%, dass ihr eine zusätzliche karte zieht.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}