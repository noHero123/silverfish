using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_051 : SimTemplate //Both players have Spell Damage +2 .
	{

		public override void  onAuraStarts(Playfield p, Minion m)
        {
            m.spellpower = 2;
            p.enemyspellpower += 2;
            p.spellpower += 2;

        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            //end spellpower of enemy
            if (m.own)
            {
                p.enemyspellpower -= 2;
                
            }
            else
            {
                p.spellpower -= 2;
            }
        }

        

	}
}