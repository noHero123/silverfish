using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_536 : SimTemplate //eaglehornbow
	{

//    erhält jedes mal +1 haltbarkeit, wenn ein eigenes geheimnis/ aufgedeckt wird.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_536);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
		}

	}
}