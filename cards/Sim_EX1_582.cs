using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_582 : SimTemplate //dalaranmage
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