using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_561 : SimTemplate //alexstrasza
	{

//    kampfschrei:/ setzt das verbleibende leben eines helden auf 15.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            target.Hp = 15;
		}


	}
}