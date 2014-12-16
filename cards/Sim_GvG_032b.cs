using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_032b : SimTemplate //Grove Tender
    {

        //    Give each player a Mana Crystal.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

                p.drawACard(CardDB.cardName.unknown, true);
                p.drawACard(CardDB.cardName.unknown, false);
           
        }


    }

}