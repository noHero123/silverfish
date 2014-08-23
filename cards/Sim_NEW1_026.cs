using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_026 : SimTemplate//Violet Teacher
    {
        public CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_026t);
        
        public virtual void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own)
            {
                int place = (wasOwnCard)? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(card, place, wasOwnCard);
            }
        }

    }
}
