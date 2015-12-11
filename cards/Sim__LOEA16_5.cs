using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOEA16_5 : SimTemplate //Mirror of Doom
    {
        //Fill your board with 3/3 Mummy Zombies.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOEA16_5t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay)? p.ownMinions.Count : p.enemyMinions.Count;
            int anz = 7 - pos;
            for (int i = 0; i < anz; i++)
            {
                p.callKid(kid, pos+i, ownplay);
            }

        }


    }
}