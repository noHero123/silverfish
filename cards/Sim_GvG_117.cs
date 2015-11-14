using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_117 : SimTemplate //Gazlowe
    {

        //   Whenever you cast a 1-mana spell, add a random Mech to your hand.
        //todo: do it right (not card.cost, we have to use current cost)
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                if (c.type == CardDB.cardtype.SPELL && c.cost == 1)
                {
                    p.drawACard(CardDB.cardIDEnum.GVG_058, wasOwnCard, true);
                }
            }
        }


    }

}