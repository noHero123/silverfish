using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_050 : SimTemplate //mounted raptor
    {

        //   Deathrattle: Summon a random 1-Cost minion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_133); //gad. jouster, a 1/2 minion with btlcry (will not trigger)

        public override void onDeathrattle(Playfield p, Minion m)
        {
            
            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, m.own);
        }


    }

}