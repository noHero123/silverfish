using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_021 : PenTemplate //doomsayer
	{

//    vernichtet zu beginn eures zuges alle diener.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}