using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_016 : SimTemplate //Fel Reaver
    {

        //    Whenever your opponent plays a card, discard the top 3 cards of your deck.

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (wasOwnCard == triggerEffectMinion.own) return; //owner of card = owner of minion -> no effect

            if (triggerEffectMinion.own)
            {
                p.ownDeckSize = Math.Max(0, p.ownDeckSize - 3);
            }
            else
            {
                p.enemyDeckSize = Math.Max(0, p.enemyDeckSize - 3);
            }
        }


    }

}