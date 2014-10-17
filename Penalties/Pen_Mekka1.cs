using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_Mekka1 : PenTemplate //homingchicken
	{

//    vernichtet zu beginn eures zuges diesen diener und zieht 3 karten.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}