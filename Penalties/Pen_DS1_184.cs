using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_DS1_184 : PenTemplate //tracking
	{

//    schaut euch die drei obersten karten eures decks an. zieht eine davon und werft die anderen beiden ab.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}