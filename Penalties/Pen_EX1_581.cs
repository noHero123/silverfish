using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_581 : PenTemplate //sap
	{

//    lasst einen feindlichen diener auf die hand eures gegners zurückkehren.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}