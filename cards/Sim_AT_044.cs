using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_044 : SimTemplate //Mulch
    {

        //   Destroy a minion. Add a random minion to your opponent's hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            if (target != null)
            {
                p.minionGetDestroyed(target);
            }
            if (p.isServer)
            {
                //TODO
                p.drawACard(CardDB.cardIDEnum.None, !ownplay, true);
                return;
            }
            p.drawACard(CardDB.cardIDEnum.None, !ownplay, true);
        }

       


    }

}