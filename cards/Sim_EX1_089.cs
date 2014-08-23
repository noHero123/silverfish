using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_089 : SimTemplate //arcanegolem
	{

//    ansturm/. kampfschrei:/ gebt eurem gegner 1 manakristall.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.enemyMaxMana++;
            }
            else
            {
                p.ownMaxMana++;
            }
		}


	}
}