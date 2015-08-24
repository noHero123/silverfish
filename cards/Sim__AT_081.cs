using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_081 : SimTemplate //Eadric the Pure
    {

        //Battlecry: Change all enemy minions' Attack to 1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            foreach(Minion m in (own.own)? p.enemyMinions : p.ownMinions)
            {
                p.minionSetAngrToOne(m);
            }
        }

       

    }
}