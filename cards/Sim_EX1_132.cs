using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_132 : SimTemplate //eyeforaneye
	{
        //todo secret
//    geheimnis:/ wenn euer held schaden erleidet, wird dem feindlichen helden ebenso viel schaden zugefügt.
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(number) : p.getEnemySpellDamageDamage(number);

            if (ownplay)
            {
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
            else
            {
                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }
        }

	}

}