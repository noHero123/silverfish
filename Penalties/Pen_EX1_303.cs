using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_303 : PenTemplate //shadowflame
	{

//    vernichtet einen befreundeten diener und fügt allen feindlichen dienern schaden zu, der seinem angriff entspricht.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}