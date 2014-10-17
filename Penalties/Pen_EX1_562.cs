using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_562 : PenTemplate //onyxia
	{

//    kampfschrei:/ ruft welplinge (1/1) herbei, bis eure seite des schlachtfelds voll ist.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}