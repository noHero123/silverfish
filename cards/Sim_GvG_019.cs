using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_019 : SimTemplate //Demonheart
    {

        //    Deal $5 damage to a minion.  If it's a friendly Demon, give it +5/+5 instead.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target.own == ownplay && (TAG_RACE)target.handcard.card.race == TAG_RACE.DEMON)
            {
                //give it +5/+5
                p.minionGetBuffed(target, 5, 5);
            }
            else
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);

                p.minionGetDamageOrHeal(target, dmg);
            }
        }


    }

}