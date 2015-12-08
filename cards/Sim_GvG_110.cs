using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_110 : SimTemplate //Dr. Boom
    {

        //  Battlecry: Summon two 1/1 Boom Bots. WARNING: Bots may explode. 

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_110t);//chillwind

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            /*int pos = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, own.own);
            pos = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, own.own);*/
            int pos = own.zonepos;
            p.callKid(kid, pos, own.own, true);
            p.callKid(kid, pos, own.own, true);
            own.zonepos++;  // move Boom to the middle of our bots
        }


    }

}