using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_128 : SimTemplate //conceal
	{

//    verleiht euren dienern bis zu eurem nächsten zug verstohlenheit/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (!m.stealth)
                    {
                        m.stealth = true;
                        m.concedal = true;
                    }
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (!m.stealth)
                    {
                        m.stealth = true;
                        m.concedal = true;
                    }
                }
            }
		}

	}

}