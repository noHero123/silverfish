using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_609 : PenTemplate //snipe
	{

//    geheimnis:/ wenn euer gegner einen diener ausspielt, werden diesem $4 schaden zugefügt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}