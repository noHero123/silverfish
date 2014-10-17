using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DS1_188 : SimTemplate //gladiatorslongbow
	{
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.DS1_188);
//    euer held ist immun/, während er angreift.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(c,ownplay);
		}

	}
}