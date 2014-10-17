using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_612 : PenTemplate //kirintormage
	{

//    kampfschrei:/ das nächste geheimnis/, das ihr in diesem zug ausspielt, kostet (0).
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}