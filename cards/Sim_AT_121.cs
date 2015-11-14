using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_121 : SimTemplate //Crowd Favorite
    {

        //Whenever you play a card with Battlecry, gain +1/+1.


        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                if (c.battlecry)
                {
                    p.minionGetBuffed(triggerEffectMinion, 1, 1);
                }
            }
        }


    }

}