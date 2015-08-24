using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_109 : SimTemplate //Mini-Mage
    {

        //   Stealth Spell Damage +1
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