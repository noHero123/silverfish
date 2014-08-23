using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_084 : PenTemplate //warsongcommander
	{

//    jedes mal, wenn ihr einen diener mit max. 3 angriff herbeiruft, erhält dieser ansturm/.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}