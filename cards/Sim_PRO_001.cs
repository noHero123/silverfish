using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_PRO_001 : SimTemplate //elitetaurenchieftain
	{

//    kampfschrei:/ verleiht beiden spielern die macht des rock! (durch eine powerakkordkarte)
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.isServer)
            {
                bool chooser = true;
                int random = p.getRandomNumber_SERVER(0, 2);

                if (random == 0) p.drawACard(CardDB.cardIDEnum.PRO_001a, chooser, true);
                if (random == 1) p.drawACard(CardDB.cardIDEnum.PRO_001b, chooser, true);
                if (random == 2) p.drawACard(CardDB.cardIDEnum.PRO_001c, chooser, true);

                chooser = false;
                random = p.getRandomNumber_SERVER(0, 2);
                if (random == 0) p.drawACard(CardDB.cardIDEnum.PRO_001a, chooser, true);
                if (random == 1) p.drawACard(CardDB.cardIDEnum.PRO_001b, chooser, true);
                if (random == 2) p.drawACard(CardDB.cardIDEnum.PRO_001c, chooser, true);
                return;
            }
            p.drawACard(CardDB.cardIDEnum.PRO_001b, true, true);
            p.drawACard(CardDB.cardIDEnum.PRO_001b, false, true);
		}

	}
}