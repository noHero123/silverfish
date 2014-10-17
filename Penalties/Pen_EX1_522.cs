using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_522 : PenTemplate //patientassassin
	{

//    verstohlenheit/. vernichtet jeden diener, der von diesem diener verletzt wurde.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}