using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_112 : SimTemplate//Master Jouster
    {
        //Battlecry: Reveal a minion in each deck. If yours costs more, gain Taunt and Divine Shield
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (p.isServer)
            {
                //TODO
                own.taunt = true;
                own.divineshild = true;
                return;
            }

            own.taunt = true;
            own.divineshild = true;
        }

    }
}
