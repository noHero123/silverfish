using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

    class Sim_AT_050 : SimTemplate//Charged Hammer
    {
        //deathrattle Your Hero Power becomes 'Deal 2 damage.'
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_050);
        CardDB.Card hp = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_050t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }

        //deathrattle is done in lowerWeaponDurability (not here)
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownHeroAblility = new Handmanager.Handcard(hp);
                p.ownAbilityReady = true;
            }
            else
            {
                p.enemyHeroAblility = new Handmanager.Handcard(hp);
                p.enemyAbilityReady = true;
            }

            if (m.own == p.isOwnTurn) p.heroPowerActivationsThisTurn = 0;
        }

    }

    
}
