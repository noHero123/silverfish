using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_037 : PenTemplate //masterswordsmith
	{

//    verleiht am ende eures zuges einem anderen zufälligen befreundeten diener +1 angriff.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}