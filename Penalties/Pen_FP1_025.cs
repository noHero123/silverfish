using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_025 : PenTemplate //reincarnate
	{

//    vernichtet einen diener und bringt ihn dann mit vollem leben wieder auf das schlachtfeld zurück.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}