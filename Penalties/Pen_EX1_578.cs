using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_578 : PenTemplate //savagery
	{

//    fügt einem diener schaden zu, der dem angriff eures helden entspricht.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}