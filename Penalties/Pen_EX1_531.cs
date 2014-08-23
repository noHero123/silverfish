using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_531 : PenTemplate //scavenginghyena
	{

//    erhält jedes mal +2/+1, wenn ein befreundetes wildtier stirbt.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}