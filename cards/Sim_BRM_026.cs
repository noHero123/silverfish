using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_026 : SimTemplate //Hungry Dragon
    {

        //   Battlecry: Summon a random 1-Cost minion for your opponent.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS1_042);



        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            int pos = (own.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, pos, !own.own);
        }


    }

}