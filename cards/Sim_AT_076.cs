using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_076 : SimTemplate //Murloc Knight
    {

        //insprire: Summon a random Murloc.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_050); //coldlight oracle
        CardDB.Card warleader = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_507); //murloc warleader

        public override void onInspire(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;

            if (p.isServer)
            {
                //TODO
                p.callKid(kid, pos, m.own);
                return;
            }

            p.callKid((m.own ? kid : warleader), pos, m.own);  // assume worse scenario (warleader) for enemy vs average scenario (oracle) for us
        }



    }

}