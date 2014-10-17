using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_226 : PenTemplate //frostwolfwarlord
	{

//    kampfschrei:/ erhält +1/+1 für jeden anderen befreundeten diener auf dem schlachtfeld.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}