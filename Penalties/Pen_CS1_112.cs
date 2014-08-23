using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS1_112 : PenTemplate //holynova
	{

//    fügt allen feinden $2 schaden zu. stellt bei allen befreundeten charakteren #2 leben wieder her.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}