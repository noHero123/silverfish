using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_227 : SimTemplate //venturecomercenary
	{

//    eure diener kosten (3) mehr.
        public override void onAuraStarts(Playfield p, Minion own)
		{
           if(own.own) p.soeldnerDerVenture++;
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
           if(own.own) p.soeldnerDerVenture--;
        }

	}
}