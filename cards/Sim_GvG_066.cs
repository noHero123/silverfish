using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_066 : SimTemplate //Dunemaul Shaman
    {

        //   Windfury, Overload: (1)&lt;/b&gt

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ueberladung++;
        }


    }

}