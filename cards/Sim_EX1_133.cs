using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

    class Sim_EX1_133 : SimTemplate//pertitions blade
    {
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_133);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            if (p.cardsPlayedThisTurn >= 1) dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            p.equipWeapon(w, ownplay);
        }

    }

    
}
