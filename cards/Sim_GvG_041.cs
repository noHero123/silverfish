using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_041 : SimTemplate //Dark Wispers
    {

        //   Choose One - Summon 5 Wisps; or Give a minion +5/+5 and Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                    p.callKid(kid, posi, ownplay);
                }
            }
            if (choice == 2)
            {
                if (target != null)
                {
                    p.minionGetBuffed(target, 5, 5);
                    target.taunt = true;
                }
            }
        }


    }

}