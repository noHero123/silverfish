using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_274 : PenTemplate //etherealarcanist
	{

//    erhält +2/+2, wenn ihr am ende eures zuges über ein aktives geheimnis/ verfügt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}