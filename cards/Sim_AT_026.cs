using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_026 : SimTemplate //Wrathguard
    {

        //Whenever this minion takes damage, also deal that amount to your hero.

        public override void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, bool ownDmgdMinion)
        {
            if (triggerEffectMinion.anzGotDmg >= 1)
            {
                p.minionGetDamageOrHeal((triggerEffectMinion.own)? p.ownHero : p.enemyHero, triggerEffectMinion.gotDmgRaw );
            }
        }

       

    }
}