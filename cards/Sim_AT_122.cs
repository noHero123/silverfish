using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_122 : SimTemplate //Gormok the Impaler
    {

        //Battlecry: If you have at least 4 other minions, deal 4 damage

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (target != null)
            {
                int count = 0;
                if (own.own) count = p.ownMinions.Count;
                else count = p.enemyMinions.Count;
                if (count >= 4)
                {
                    p.minionGetDamageOrHeal(target, 4);
                }
            }

        }

       

    }
}