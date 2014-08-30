using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_354 : SimTemplate//lay on hands
    {

        //Stellt #8 Leben wieder her. Zieht 3 Karten.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = (ownplay) ? p.getSpellHeal(8) : p.getEnemySpellHeal(8);
            p.minionGetDamageOrHeal(target, -heal);
            for (int i = 0; i < 3; i++)
            {
                //this.owncarddraw++;
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }
            
        }

    }
}
