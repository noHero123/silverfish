using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_350 : SimTemplate //prophetvelen
	{

//    verdoppelt den schaden und die heilung eurer zauber und heldenfähigkeiten.
		public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own)
            {
                p.doublepriest++;
            }
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.doublepriest--;
            }
        }

	}
}