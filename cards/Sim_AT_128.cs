using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_128 : SimTemplate //The Skeleton Knight
    {

        //Deathrattle: Reveal a minion in each deck. If yours costs more, return this to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.isServer)
            {
                //TODO
                p.drawACard(CardDB.cardIDEnum.AT_128, m.own, true);
                return;
            }

            p.drawACard(CardDB.cardIDEnum.AT_128, m.own, true);
        }

       

    }
}