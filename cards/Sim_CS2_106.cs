using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_106 : SimTemplate //fierywaraxe
	{
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_106);
//
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(card,ownplay);
		}

	}
}