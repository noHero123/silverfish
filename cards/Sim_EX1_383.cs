using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_383 : SimTemplate //tirionfordring
	{
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_383t);
//    gottesschild/. spott/. todesröcheln:/ legt einen aschenbringer (5/3) an.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.equipWeapon(card,m.own);
        }

	}
}