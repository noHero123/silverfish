using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_411 : SimTemplate//Gorehowl
    {
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_411);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(wcard, ownplay);
        }

    }
}
