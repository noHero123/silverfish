using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_DREAM_02 : PenTemplate //yseraawakens
	{

//    fügt allen charakteren mit ausnahme von ysera $5 schaden zu.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}