using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_001 : SimTemplate //lightwarden
	{

//    erhält jedes mal +2 angriff, wenn ein charakter geheilt wird.
        public override void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfHeroGotHealed)
        {
            p.minionGetBuffed(triggerEffectMinion, 2, 0);
        }

        public override void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfMinionGotHealed)
        {
            p.minionGetBuffed(triggerEffectMinion, 2, 0);
        }

	}
}