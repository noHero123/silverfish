using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_018 : SimTemplate //Confessor Paletress
    {

        //Inspire: Summon a random Legendary minion

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_024); //captain greenskin

        public override void onInspire(Playfield p, Minion m)
        {

            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;

            if (p.isServer)
            {
                //TODO
                p.callKid(kid, pos, m.own);
                return;
            }

            p.callKid(kid, pos, m.own);
        }


    }
}