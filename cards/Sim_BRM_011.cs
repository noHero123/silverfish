using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_011 : SimTemplate //Lava Shock
    {


        //    Deal 2 damage. Unlock your Overloaded Mana Crystals.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay)
            {
                p.owedRecall = 0;
                p.mana += p.currentRecall;
                p.currentRecall = 0;
            }
            else
            {
                p.enemyRecall = 0;
                p.mana += p.enemyCurrentRecall;
                p.enemyCurrentRecall = 0;
            }
        }

    }
}