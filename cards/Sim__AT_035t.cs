using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

    class Sim_AT_035t : SimTemplate//Ambush!
    {
        //>When you draw this, summon a 4/4 Nerubian for your opponent. Draw a card.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_007t);//nerub

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
        }

    }

    
}
