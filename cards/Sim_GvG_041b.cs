using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

    class Sim_GVG_041b : SimTemplate //Dark Wispers
    {

        //   Summon 5 Wisps;

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            for (int i = 0; i < 5; i++)
            {
                int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, posi, ownplay);
            }

        }


    }

}