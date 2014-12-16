using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_025 : SimTemplate //One-eyed Cheat
    {

        //    Whenever you summon a Pirate, gain Stealth.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if ((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.PIRATE)
            {
                triggerEffectMinion.stealth = true;
            }
        }


    }

}