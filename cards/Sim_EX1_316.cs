using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_316 : SimTemplate //poweroverwhelming
	{

//    verleiht einem befreundeten diener bis zum ende des zuges +4/+4. dann stirbt er. auf schreckliche art und weise.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 4, 4);
            if (ownplay)
            {
                target.destroyOnOwnTurnEnd = true;
            }
            else
            {
                target.destroyOnEnemyTurnEnd = true;
            }

		}

	}
}