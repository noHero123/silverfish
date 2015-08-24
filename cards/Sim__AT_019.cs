using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_019 : SimTemplate //Dreadsteed
    {

        //Deathrattle: Summon a Dreadsteed.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_019); //captain greenskin

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, pos, m.own);
        }

       

    }
}