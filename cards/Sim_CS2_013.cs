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
                p.ownMaxMana++;
            }
            else
            {
                p.enemyMaxMana++;
            }
		}

	}
}