using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_289 : PenTemplate //icebarrier
	{

//    geheimnis:/ wenn euer held angegriffen wird, erhält er 8 rüstung.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}