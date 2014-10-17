using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_009 : SimTemplate//Mark of the Wild
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.taunt = true;
            p.minionGetBuffed(target, 2, 2);
        }

    }
}
