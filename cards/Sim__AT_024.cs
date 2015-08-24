using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_024 : SimTemplate //Demonfuse
    {

        //   Give a Demon +3/+3. Give your opponent a Mana Crystal.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            if (target != null)
            {
                p.minionGetBuffed(target, 3, 3);
            }

            if (ownplay)
            {
                p.enemyMaxMana++;
                if (p.enemyMaxMana > 10) p.enemyMaxMana = 10;
            }
            else
            {
                p.ownMaxMana++;
                if (p.ownMaxMana > 10) p.ownMaxMana = 10;
            }
        }


    }

}