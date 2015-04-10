using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_235 : SimTemplate //northshirecleric
	{

//    zieht jedes mal eine karte, wenn ein diener geheilt wird.

        public override void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfMinionGotHealed)
        {
            p.drawACard(CardDB.cardIDEnum.None, triggerEffectMinion.own);
        }

	}
}