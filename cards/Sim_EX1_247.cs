using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_247 : SimTemplate //stormforgedaxe
	{
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_247);
        //
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(card,ownplay);
            if (ownplay) p.ueberladung ++;
        }

	}
}