using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_059 : PenTemplate //bloodimp
	{

//    verstohlenheit/. verleiht am ende eures zuges einem anderen zufälligen befreundeten diener +1 leben.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}