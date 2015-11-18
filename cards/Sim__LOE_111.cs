using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_111 : SimTemplate //Excavated Evil
    {

        //Deal $3 damage to all minions.Shuffle this card into your opponent's deck.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionsGetDamage(dmg);

            if (p.isServer)
            {
                //TODO
                return;
            }

            if (ownplay)
            {
                p.enemyDeckSize++;
                
            }
            else
            {
                p.ownDeckSize++;
            }
        }


       

    }
}