using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_131 : SimTemplate //Eydis Darkbane
    {

        //Whenever you target this minion with a spell, deal 3 damage to a random enemy.

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL && target!=null && target.entitiyID == triggerEffectMinion.entitiyID)
            {
                if (p.isServer)
                {
                    Minion choosen = p.getRandomMinionFromSide_SERVER(!triggerEffectMinion.own, true);
                    if (choosen != null) p.minionGetDamageOrHeal(choosen, 3);
                    return;
                }

                p.doDmgToRandomEnemyCLIENT2(3, true, triggerEffectMinion.own);
            }
        }

       

    }
}