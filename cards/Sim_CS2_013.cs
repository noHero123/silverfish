using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_013 : SimTemplate //wildgrowth
	{

//    erhaltet einen leeren manakristall.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                if (p.ownMaxMana < 10)
                {
                    p.ownMaxMana++;
                }
                else
                {
                    p.drawACard(CardDB.cardName.excessmana, true, true);
                }

            }
            else
            {
                if (p.enemyMaxMana < 10)
                {
                    p.enemyMaxMana++;
                }
                else
                {
                    p.drawACard(CardDB.cardName.excessmana, false, true);
                }
            }
		}

	}
}