using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_003 : SimTemplate//Mind Vision
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int anz = (ownplay) ? p.enemyAnzCards : p.owncards.Count;
            if (anz >= 1)
            {
                p.drawACard(CardDB.cardName.unknown, ownplay,true);
            }
        }

    }
}
