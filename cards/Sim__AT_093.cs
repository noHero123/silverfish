using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_093 : SimTemplate //Frigid Snobold
    {

        //insprire: gain Spell Damage +1

        public override void onInspire(Playfield p, Minion m)
        {
            m.spellpower++;
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