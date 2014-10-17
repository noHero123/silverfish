using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_022 : PenTemplate //voidcaller
	{

//    todesröcheln:/ legt einen zufälligen dämon aus eurer hand auf das schlachtfeld.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}