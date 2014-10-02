using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_009 : PenTemplate //markofthewild
	{

//    verleiht einem diener spott/ und +2/+2.i&gt; (+2 angriff/+2 leben)/i&gt;
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
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
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.biggamehunter || hc.card.name == CardDB.cardName.shadowworddeath) return 0;
                }
                bool enemyHasTaunts = false;
                foreach (Minion e in p.enemyMinions)
                {
                    if (e.taunt) enemyHasTaunts = true;
                }
                if (!target.taunt && !target.silenced && target.handcard.card.targetPriority >= 1 && enemyHasTaunts)
                {
                    return 0;
                }
                return 500;
            }
            return 0;
		}

	}

}