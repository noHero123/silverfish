using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_055 : SimTemplate //Flash Heal
    {

        //   Restore #5 Health
    

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            int heal = (ownplay) ? p.getSpellHeal(5) : p.getEnemySpellHeal(5);
            p.minionGetDamageOrHeal(target, -heal);
        }


    }

}