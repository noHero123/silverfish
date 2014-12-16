using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_039 : SimTemplate //Vitality Totem
    {

        //    At the end of your turn, restore 4 Health to your hero.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                
                if (triggerEffectMinion.own)
                {
                    int heal = p.getMinionHeal(4);
                    p.minionGetDamageOrHeal(p.ownHero, -heal, true);
                }
                else
                {
                    int heal =  p.getEnemyMinionHeal(4);
                    p.minionGetDamageOrHeal(p.enemyHero, -heal, true);
                }

            }
        }


    }

}