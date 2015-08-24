using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_037b : SimTemplate //Living Roots
    {

        //   Choose One - Deal $2 damage; or Summon two 1/1 Saplings..
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_037t);//sapp
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
           
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, pos, ownplay);
            
        }

    }


}