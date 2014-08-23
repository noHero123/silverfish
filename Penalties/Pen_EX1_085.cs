using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_085 : PenTemplate //mindcontroltech
	{

//    kampfschrei:/ falls euer gegner mind. 4 diener hat, übernehmt zufällig die kontrolle über einen davon.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}