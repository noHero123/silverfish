using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_016 : SimTemplate //captainsparrot
	{

//    kampfschrei:/ fügt eurer hand einen zufälligen piraten aus eurem deck hinzu.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, true, true);
		}


	}
}