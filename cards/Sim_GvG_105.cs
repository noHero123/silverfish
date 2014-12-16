using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_105 : SimTemplate //Piloted Sky Golem
    {

        // Deathrattle: Summon a random 4-Cost minion.  

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_182);//chillwind

        public override void onDeathrattle(Playfield p, Minion m)
        {

            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, m.own);
        }


    }

}