using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_565 : PenTemplate //flametonguetotem
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
            if (p.enemyMinions.Count == 0)
                return 20;


			return 0;
		}
	}
}
