using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_075 : SimTemplate //Warhorse Trainer
	{

        //    Your Silver Hand Recruits have +1 Attack.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnWarhorseTrainer++;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.name == CardDB.cardName.silverhandrecruit) p.minionGetBuffed(m, 1, 0);
                }
            }
            else
            {
                p.anzEnemyWarhorseTrainer++;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.name == CardDB.cardName.silverhandrecruit) p.minionGetBuffed(m, 1, 0);
                }
            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnWarhorseTrainer--;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.name == CardDB.cardName.silverhandrecruit) p.minionGetBuffed(m, -1, 0);
                }
            }
            else
            {
                p.anzEnemyWarhorseTrainer--;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.name == CardDB.cardName.silverhandrecruit) p.minionGetBuffed(m, -1, 0);
                }
            }
        }

	}
}