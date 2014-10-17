using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_NEW1_029 : PenTemplate //millhousemanastorm
	{

//    kampfschrei:/ im nächsten zug kosten zauber für euren gegner (0) mana.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}