using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

    class Sim_AT_034 : SimTemplate//Poisoned Blade
    {
        //our Hero Power gives this weapon +1 Attack instead of replacing it.
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_034);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }

    }

    
}
