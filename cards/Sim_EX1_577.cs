using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_577 : SimTemplate //thebeast
	{

//    todesröcheln:/ ruft finkle einhorn (3/3) für euren gegner herbei.
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_finkle);//finkleeinhorn
        public override void onDeathrattle(Playfield p, Minion m)
        {

            int place = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(c, place, !m.own);
        }

	}
}