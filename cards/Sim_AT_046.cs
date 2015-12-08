using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_046 : SimTemplate //Tuskarr Totemic
    {

        //   btlcry: Summon ANY random Totem.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_050);//searing
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int pos = own.zonepos;
            if (p.isServer)
            {
                //TODO
                p.callKid(kid, pos, own.own, true);
                return;
            }
            p.callKid(kid, pos, own.own, true);
        }


    }


}