using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_091 : SimTemplate //lightsjustice
	{

//
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_091);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }
	}
}