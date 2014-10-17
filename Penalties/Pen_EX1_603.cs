using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_603 : PenTemplate //crueltaskmaster
	{

//    kampfschrei:/ fügt einem diener 1 schaden zu und verleiht ihm +2 angriff.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            if (target.own)
            {
                if (m.Hp == 1) return 50;
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

                if (m.Hp == 1)
                {
                    return 0;
                }

                if (!m.wounded && (m.Angr >= 4 || m.Hp >= 5))
                {
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardDB.cardName.execute) return 0;
                    }
                }
                return base.getValueOfMinion(4,5);
            }
            return 0;
		}

	}
}