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
                p.mana = Math.Min(10, p.mana + 1);
                p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
                p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 1);
            }

            if (choice == 2)
            {
                p.drawACard(CardDB.cardIDEnum.None, true);
                p.drawACard(CardDB.cardIDEnum.None, false);
            }
        }


    }

}