using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_166 : SimTemplate //keeperofthegrove
	{

//    wählt aus:/ verursacht 2 schaden; oder bringt einen diener zum schweigen/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
            {
                if (choice == 1)
                {
                    p.minionGetDamageOrHeal(target, 2);
                }

                if (choice == 2)
                {
                    p.minionGetSilenced(target);
                }
            }
		}


	}
}