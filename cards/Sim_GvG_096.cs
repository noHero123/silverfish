using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_096 : SimTemplate //Piloted Shredder
    {

        //   Deathrattle: Summon a random 2-Cost minion.

        CardDB.Card bloodfen = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_172);
        CardDB.Card treant = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            
            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid((m.own ? treant : bloodfen), pos, m.own);
        }


    }

}