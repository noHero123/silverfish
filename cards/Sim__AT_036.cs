using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

    class Sim_AT_036 : SimTemplate//Anub'arak
    {
        //Deathrattle: Return this to your hand and summon a 4/4 Nerubian.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_036t);//nerub

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, m.own);
            p.drawACard(CardDB.cardIDEnum.AT_036, m.own, true);
        }


    }

    
}
