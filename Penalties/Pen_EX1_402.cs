using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_402 : PenTemplate //armorsmith
	{

//    erhaltet jedes mal 1 rüstung, wenn ein befreundeter diener schaden erleidet.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}