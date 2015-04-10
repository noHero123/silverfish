using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_595 : SimTemplate //cultmaster
	{

//    zieht jedes mal eine karte, wenn einer eurer anderen diener stirbt.

        public override void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            if (triggerEffectMinion.own == diedMinion.own)
            {
                p.drawACard(CardDB.cardIDEnum.None, triggerEffectMinion.own);
            }
        }

	}
}