using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_DREAM_05 : SimTemplate//Nightmare
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 4, 4);
            if (ownplay)
            {
                target.destroyOnOwnTurnStart = true;
            }
            else
            {
                target.destroyOnEnemyTurnStart = true;
            }
        }

    }
}
