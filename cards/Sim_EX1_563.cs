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
            p.spellpower = 5;
            if (own.own)
            {
                p.spellpower+=5;
            }
            else
            {
                p.enemyspellpower+=5;
            }
		}



	}
}