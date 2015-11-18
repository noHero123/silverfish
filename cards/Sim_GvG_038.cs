using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_038 : SimTemplate //Crackle
    {

        //    Deal $3-$6 damage.Overload: (1)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.changeRecall(ownplay, 1);
            if (p.isServer)
            {
                int random = p.getRandomNumber_SERVER(3, 6);
                int dmgS = (ownplay) ? p.getSpellDamageDamage(random) : p.getEnemySpellDamageDamage(random);
                p.minionGetDamageOrHeal(target, dmgS);
                
                return;
            }

            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
        }


    }

}