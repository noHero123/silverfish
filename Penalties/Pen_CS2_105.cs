using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_105 : PenTemplate //heroicstrike
	{

//    verleiht eurem helden +4 angriff in diesem zug.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            if (!p.ownHero.Ready)
            {
                return 100;
            }

            return 0;

		}

	}
}