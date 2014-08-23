using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_277 : PenTemplate //arcanemissiles
	{

//    verursacht $3 schaden, der zufällig auf feindliche charaktere verteilt wird.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}