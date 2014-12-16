using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_310 : SimTemplate //doomguard
	{

//    ansturm/. kampfschrei:/ werft zwei zufällige karten ab.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                int anz = Math.Min(2, p.owncards.Count);
                p.owncarddraw -= anz;
                p.owncards.RemoveRange(0, anz);
                if (anz >= 1)
                {
                    p.triggerCardsChanged(true);
                }

            }
            else
            {
                if (p.enemyAnzCards >= 1)
                {
                    p.enemycarddraw--;
                    p.enemyAnzCards--;
                    p.triggerCardsChanged(false);
                }
                if (p.enemyAnzCards >= 1)
                {
                    p.enemycarddraw--;
                    p.enemyAnzCards--;
                    p.triggerCardsChanged(false);
                }
            }


		}

	}
}