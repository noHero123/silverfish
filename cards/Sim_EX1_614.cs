using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_614 : SimTemplate //illidanstormrage
	{
        CardDB.Card d = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_614t);//flameofazzinoth
//    beschwört jedes mal eine flamme von azzinoth (2/1), wenn ihr eine karte ausspielt.

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (wasOwnCard == triggerEffectMinion.own)
            {
                    p.callKid(d, triggerEffectMinion.zonepos, triggerEffectMinion.own);

            }
        }

	}
}