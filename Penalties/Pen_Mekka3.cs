using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_Mekka3 : PenTemplate //emboldener3000
	{

//    verleiht am ende eures zuges einem zufälligen diener +1/+1.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}