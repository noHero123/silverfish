using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_007 : SimTemplate //Gang Up
    {

        //    Choose a minion. Shuffle 3 copies of it into your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) 
            { 
                p.ownDeckSize += 3; 
            }
            else
            {
                p.enemyDeckSize += 3;
            }
        }

    }
}