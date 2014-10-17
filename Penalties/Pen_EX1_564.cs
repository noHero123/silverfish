using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_564 : PenTemplate //facelessmanipulator
	{

//    kampfschrei:/ wählt einen diener aus, um gesichtsloser manipulator in eine kopie desselben zu verwandeln.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}