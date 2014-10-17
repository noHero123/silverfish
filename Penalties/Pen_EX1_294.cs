using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_294 : PenTemplate //mirrorentity
	{

//    geheimnis:/ wenn euer gegner einen diener ausspielt, beschwört ihr eine kopie desselben herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}