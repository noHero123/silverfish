using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_047 : SimTemplate //Draenei Totemcarver
    {

        //   btlcry: Gain +1/+1 for each friendly Totem
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_050);//searing
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int totems = 0;
            foreach (Minion m in (own.own) ? p.ownMinions : p.enemyMinions)
            {
                if (m.handcard.card.race == TAG_RACE.TOTEM) totems++;
            }
            if (totems >= 1) p.minionGetBuffed(own, totems, totems);
        }


    }


}