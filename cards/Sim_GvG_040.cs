using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_040 : SimTemplate //Siltfin Spiritwalker
    {

        //    Whenever another friendly Murloc dies, draw a card. Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.changeRecall(own.own, 1);
        }
        // death-effect is handled in playfield -> triggerAMinionDied

    }

}