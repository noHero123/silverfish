using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_080 : PenTemplate //secretkeeper
	{

//    erhält jedes mal +1/+1, wenn ein geheimnis/ ausgespielt wird.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}