using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_110t : SimTemplate //Ancient Curse
    {

        //shouldnt happen.. but if we have this on hand.. draw a card

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
        }



    }
}