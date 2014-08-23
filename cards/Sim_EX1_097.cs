using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_097 : SimTemplate //abomination
	{

//    spott/. todesröcheln:/ fügt allen charakteren 2 schaden zu.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allCharsGetDamage(2);
        }

	}
}