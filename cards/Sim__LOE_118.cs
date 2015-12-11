using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_118 : SimTemplate //assassinsblade
	{


        //      double all damage dealt to your hero
        //effect done in Minion-> getDamageOrHeal
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_118);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }

	}
}