using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_349 : PenTemplate //divinefavor
	{

//    zieht so viele karten, bis ihr genauso viele karten auf eurer hand habt wie euer gegner.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}