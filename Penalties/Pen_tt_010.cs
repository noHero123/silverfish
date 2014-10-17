using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_tt_010 : PenTemplate //spellbender
	{

//    geheimnis:/ wenn ein feind einen zauber auf einen diener wirkt, ruft ihr einen diener (1/3) als neues ziel herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}