using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_DREAM_05 : PenTemplate //nightmare
	{

//    verleiht einem diener +5/+5. zu beginn eures nächsten zuges wird er vernichtet.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 500;
                }
                return 0;
            }
            else
            {
                if (target.frozen) return 0;

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.biggamehunter || hc.card.name == CardDB.cardName.shadowworddeath) return 0;
                }
                return 20;
            }
            return 0;
		}

	}
}