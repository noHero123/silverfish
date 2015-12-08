using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_015 : SimTemplate //Revenge
    {


        //    Deal $1 damage to all minions. If you have 12 or less Health, deal $3 damage instead.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            if (ownplay && p.ownHero.Hp <= 12) dmg = p.getSpellDamageDamage(3);
            if (!ownplay && p.enemyHero.Hp <= 12) dmg = p.getEnemySpellDamageDamage(3);

            p.allMinionsGetDamage(dmg);
        }

    }
}