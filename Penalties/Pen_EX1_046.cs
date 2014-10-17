using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_046 : PenTemplate //darkirondwarf
	{

//    kampfschrei:/ verleiht einem diener +2 angriff in diesem zug.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 50;
                }
            }
            else
            {
                if (m.handcard.card.type == CardDB.cardtype.MOB && p.ownMinions.Count == 0) return 0;
                //allow it if you have biggamehunter
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.biggamehunter || hc.card.name == CardDB.cardName.shadowworddeath) return 0;
                }
                return 500;
            }
            return 0;
		}

	}
}