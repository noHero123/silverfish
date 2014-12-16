using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_062 : SimTemplate //Cobalt Guardian
    {

        //   Whenever you summon a Mech, gain Divine Shield.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own==summonedMinion.own && (TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.MECHANICAL)
            {
                triggerEffectMinion.divineshild = true;
            }
        }



    }

}