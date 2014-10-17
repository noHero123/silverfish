using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_316 : PenTemplate //poweroverwhelming
	{

//    verleiht einem befreundeten diener bis zum ende des zuges +4/+4. dann stirbt er. auf schreckliche art und weise.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            if (!m.Ready) return 500;
		return 0;
		}

	}
}