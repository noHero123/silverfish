using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_384 : PenTemplate //avengingwrath
	{

//    verursacht $8 schaden, der zufällig auf feindliche charaktere verteilt wird.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}