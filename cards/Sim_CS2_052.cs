using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_052 : SimTemplate //wrathofairtotem
	{

//    zauberschaden +1/
		public override void  onAuraStarts(Playfield p, Minion m)
        {
            m.spellpower = 1;
            if (m.own)
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