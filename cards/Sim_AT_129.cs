using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_129 : SimTemplate //Fjola Lightbane
    {

        //Whenever you target this minion with a spell, gain Divine Shield

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL && target!=null && target.entitiyID == triggerEffectMinion.entitiyID)
            {
                triggerEffectMinion.divineshild = true;
            }
        }

       

    }
}