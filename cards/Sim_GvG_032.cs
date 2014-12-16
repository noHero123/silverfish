using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_032 : SimTemplate //Grove Tender
    {

        //    Choose One - Give each player a Mana Crystal; or Each player draws a card.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 1)
            {
                p.mana++;
                p.ownMaxMana++;
                p.enemyMaxMana++;
            }

            if (choice == 2)
            {
                p.drawACard(CardDB.cardName.unknown, true);
                p.drawACard(CardDB.cardName.unknown, false);
            }
        }


    }

}