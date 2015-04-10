using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_029 : SimTemplate //Rend Blackhand
    {

        //    If you're holding a Dragon, destroy a Legendary minion.
        //todo: if holding a dragon has to be done in carddb!
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null && target.handcard.card.rarity >= 5) //requires legendary target
            {
                p.minionGetDestroyed(target);
            }
        }

    }
}