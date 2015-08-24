using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_072 : SimTemplate //Shadowboxer
    {

        // Whenever a character is healed, deal 1 damage to a random enemy.  

        public override void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfHeroGotHealed)
        {
            if (p.isServer)
            {
                
                Minion choosen = p.getRandomMinionFromSide_SERVER(!triggerEffectMinion.own, true);
                if (choosen != null) p.minionGetDamageOrHeal(choosen, 1);
            }
            else
            {
                Minion t = p.searchRandomMinion((triggerEffectMinion.own) ? p.enemyMinions : p.ownMinions, Playfield.searchmode.searchHighestHP);
                if (t != null)
                {
                    p.minionGetDamageOrHeal(t, 1);
                }
                else
                {
                    p.minionGetDamageOrHeal((triggerEffectMinion.own) ? p.enemyHero : p.ownHero, 1);
                }
            }
        }

    }

}