using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_366 : PenTemplate //swordofjustice
	{

//    jedes mal, wenn ihr einen diener herbeiruft, erhält dieser +1/+1 und diese waffe verliert 1 haltbarkeit.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}