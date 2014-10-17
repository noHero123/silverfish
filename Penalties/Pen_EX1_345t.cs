using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_345t : PenTemplate //shadowofnothing
	{

//    gedankenspiele verpufft! euer gegner hat keine diener!
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}