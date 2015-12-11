using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_119 : SimTemplate //animated armor
	{

        //    Your hero can only take 1 damage at a time.

        

        public override void onAuraStarts(Playfield p, Minion own)
        {
            
            if (own.own)
            {
                p.anzOwnAnimatedArmor++;
            }
            else
            {
                p.anzEnemyAnimatedArmor++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnAnimatedArmor--;
            }
            else
            {
                p.anzEnemyAnimatedArmor--;
            }
        }
	}
}