using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_020 : PenTemplate //wildpyromancer
	{

//    fügt allen dienern 1 schaden zu, nachdem ihr einen zauber gewirkt habt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}