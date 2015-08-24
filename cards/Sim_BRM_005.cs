using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_005 : SimTemplate //Demonwrath
    {

        //  Deal $2 damage to all non-Demon minions.

        

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            foreach (Minion m in p.ownMinions)
            {
                if (m.handcard.card.race != TAG_RACE.DEMON)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.handcard.card.race != TAG_RACE.DEMON)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
        }


    }

}