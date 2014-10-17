using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_563 : SimTemplate //malygos
	{

//    zauberschaden +5/
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own)
            {
                p.spellpower+=5;
            }
            else
            {
                p.enemyspellpower+=5;
            }
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower-=5;
            }
            else
            {
                p.enemyspellpower-=5;
            }
        }

	}
}