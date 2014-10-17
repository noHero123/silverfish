using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_049 : PenTemplate //youthfulbrewmaster
	{

//    kampfschrei:/ lasst einen befreundeten diener vom schlachtfeld auf eure hand zurückkehren.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}