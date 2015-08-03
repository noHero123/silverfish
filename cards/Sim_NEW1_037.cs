using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_037 : SimTemplate //masterswordsmith
	{

//    verleiht am ende eures zuges einem anderen zufälligen befreundeten diener +1 angriff.
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                if (p.isServer)
                {
                    Minion randomguy = p.getRandomCharOfASideExcept_SERVER(triggerEffectMinion, triggerEffectMinion.own, false);
                    if (randomguy != null) p.minionGetBuffed(randomguy, 1, 0);
                    return;
                }

                List<Minion> temp2 = new List<Minion>(p.ownMinions);
                temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));//buff the weakest
                foreach (Minion mins in temp2)
                {
                    if (triggerEffectMinion.zonepos == mins.zonepos) continue;
                    p.minionGetBuffed(mins, 1, 0);
                    break;
                }
            }
        }

	}
}