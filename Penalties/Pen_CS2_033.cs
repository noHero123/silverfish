using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_033 : PenTemplate //waterelemental
	{

//    friert/ jeden charakter ein, der von diesem diener verletzt wurde.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}