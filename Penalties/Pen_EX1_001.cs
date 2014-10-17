using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_001 : PenTemplate //lightwarden
	{

//    erhält jedes mal +2 angriff, wenn ein charakter geheilt wird.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}