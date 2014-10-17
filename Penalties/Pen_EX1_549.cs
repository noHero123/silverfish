using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_549 : PenTemplate //bestialwrath
	{

//    verleiht einem wildtier +2 angriff und immunität/ in diesem zug.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            {
                if (target.own)
                {
                    if (!m.Ready)
                    {
                        return 50;
                    }
                    if (m.Hp == 1 && !m.divineshild)
                    {
                        return 10;
                    }
                }
                else
                {
                    return 500;
                }
                return 0;
            }
		}

	}
}