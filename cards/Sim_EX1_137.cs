using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_137 : SimTemplate //headcrack
    {

        //    fügt dem feindlichen helden $2 schaden zu. combo:/ lasst die karte in eurem nächsten zug wieder auf eure hand zurückkehren.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);

            if (p.cardsPlayedThisTurn >= 1) p.evaluatePenality -= 5;
        }

    }
}