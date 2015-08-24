using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_197 : SimTemplate //ogremagi
	{

//    zauberschaden +1/
        public override void onAuraStarts(Playfield p, Minion own)
		{
            own.spellpower = 1;
            if (own.own)
            {
                p.spellpower++;
            }
            else
            {
                p.enemyspellpower++;
            }
		}


        
	}
}