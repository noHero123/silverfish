using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_414 : SimTemplate //grommashhellscream
	{

//    ansturm/, wutanfall:/ +6 angriff
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr+=6;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr-=6;
        }

	}
}