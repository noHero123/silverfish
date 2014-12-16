using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_092 : SimTemplate //Gnomish Experimenter
    {

        //  Battlecry: Draw a card. If it's a minion, transform it into a Chicken. 

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, own.own);
        }

    }

}