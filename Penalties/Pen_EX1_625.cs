using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_625 : PenTemplate //shadowform
	{

//    eure heldenfähigkeit wird zu „verursacht 2 schaden“. wenn euer held bereits schattengestalt angenommen hat: 3 schaden.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}