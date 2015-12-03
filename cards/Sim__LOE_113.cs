using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_113 : SimTemplate //everyfinisawesome
    {

        //   give your minions +2/+2, costs less for each murloc you control

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    p.minionGetBuffed(mnn, 2, 2);
                }
            }
            else
            {
                foreach (Minion mnn in p.enemyMinions)
                {
                    p.minionGetBuffed(mnn, 2, 2);
                }
            }
        }


    }

}