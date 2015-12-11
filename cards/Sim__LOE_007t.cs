using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_007t : SimTemplate //Cursed!
    {

        //While this is in your hand, take 2 damage at the start of your turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (!ownplay)
            {
                p.anzEnemyCursed--;
            }
        }


    }
}