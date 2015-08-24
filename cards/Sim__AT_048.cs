using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_048 : SimTemplate //Healing Wave
    {

        //   Restore #7 Health. Reveal a minion in each deck. If yours costs more, Restore #14 instead.
    

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            if (p.isServer)
            {
                //TODO
                int heal2 = (ownplay) ? p.getSpellHeal(7) : p.getEnemySpellHeal(7);
                p.minionGetDamageOrHeal(target, -heal2);
                return;
            }

            int heal = (ownplay) ? p.getSpellHeal(11) : p.getEnemySpellHeal(11);
            p.minionGetDamageOrHeal(target, -heal);
        }


    }

}