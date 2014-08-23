using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_064 : SimTemplate //dreadinfernal
	{

//    kampfschrei:/ fügt allen anderen charakteren 1 schaden zu.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 1;
            p.allCharsGetDamage(dmg); // dreadinfernal is not on board yet!
		}
	}
}