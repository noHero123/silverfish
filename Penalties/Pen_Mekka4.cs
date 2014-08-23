using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_Mekka4 : PenTemplate //poultryizer
	{

//    verwandelt zu beginn eures zuges einen zufälligen diener in ein huhn (1/1).
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}