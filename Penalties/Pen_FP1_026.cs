using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_026 : PenTemplate //anubarambusher
	{

//    todesröcheln:/ lasst einen zufälligen befreundeten diener auf eure hand zurückkehren.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}