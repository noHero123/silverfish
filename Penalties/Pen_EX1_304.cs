using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_304 : PenTemplate //voidterror
	{

//    kampfschrei:/ vernichtet die benachbarten diener und verleiht ihm deren angriff und leben.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}