using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_023 : PenTemplate //faeriedragon
	{

//    kann nicht als ziel von zaubern oder heldenfähigkeiten gewählt werden.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}