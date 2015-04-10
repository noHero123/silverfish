using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_013 : SimTemplate //Quick Shot
    {


        //    Deal $3 damage. If your hand is empty, draw a card


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay && p.owncards.Count==0)
            {
                p.drawACard(CardDB.cardIDEnum.None, ownplay);
            }
            if (!ownplay && p.enemyAnzCards == 0)
            {
                p.drawACard(CardDB.cardIDEnum.None, ownplay);
            }
        }

    }
}