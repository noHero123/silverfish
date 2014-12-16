using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_089 : SimTemplate //Illuminator
    {

        //  if you control a Secret at the end of your turn, restore 4 health to your hero. 

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                if (((turnEndOfOwner) ? p.ownSecretsIDList.Count : p.enemySecretList.Count) >= 1)
                {
                    int heal = (turnEndOfOwner) ? p.getMinionHeal(4) : p.getEnemyMinionHeal(4);
                    p.minionGetDamageOrHeal(((turnEndOfOwner) ? p.ownHero : p.enemyHero), -heal, true);
                }
            }
        }

    }

}