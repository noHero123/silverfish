using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_106 : SimTemplate//Light's Champion
    {
        //Battlecry: Silence a Demon
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (target != null)
            {
                p.minionGetSilenced(target);
            }
        }

    }
}
