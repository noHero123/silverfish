using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_015 : SimTemplate //feugen
	{

//    todesröcheln:/ ruft thaddius herbei, wenn stalagg in diesem duell bereits gestorben ist.
        CardDB.Card thaddius = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_014t);
        //    todesröcheln:/ ruft thaddius herbei, wenn feugen in diesem duell bereits gestorben ist.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.stalaggDead)
            {
                p.callKid(thaddius, m.zonepos - 1, m.own);
            }
        }

	}
}