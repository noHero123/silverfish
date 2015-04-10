using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_008: SimTemplate//ancient of lore
    {

        //Zieht 2 Karten; oder stellt 5 Leben wieder her
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 2)
            {
                int heal = (own.own) ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);
                p.minionGetDamageOrHeal(target, -heal);
            }
            else
            {
                p.drawACard(CardDB.cardIDEnum.None, own.own);
                p.drawACard(CardDB.cardIDEnum.None, own.own);
            }
        }

    }
}
