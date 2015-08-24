using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_284 : SimTemplate //azuredrake
	{

//    zauberschaden +1/. kampfschrei:/ zieht eine karte.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
           
            p.drawACard(CardDB.cardIDEnum.None, own.own);
		}

        public override void onAuraStarts(Playfield p, Minion m)
        {
            m.spellpower = 1;
            if (m.own)
            {
                p.spellpower++;
            }
            else
            {
                p.enemyspellpower++;
            }
        }

      

	}
}