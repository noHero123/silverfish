using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_004 : PenTemplate //youngpriestess
	{

//    verleiht am ende eures zuges einem anderen zufälligen befreundeten diener +1 leben.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}