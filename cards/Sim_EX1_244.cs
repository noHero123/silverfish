using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_244 : SimTemplate//totemic might
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion t in temp)
            {
                if (t.handcard.card.race == 21) // if minion is a totem, buff it
                {
                    p.minionGetBuffed(t, 0, 2);
                }
            }
        }

    }
}
