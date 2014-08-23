using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_155 : SimTemplate //markofnature
	{

//    wählt aus:/ verleiht einem diener +4 angriff; oder +4 leben und spott/.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (choice == 1)
            {
                p.minionGetBuffed(target, 4, 0);
            }
            if (choice == 2)
            {
                p.minionGetBuffed(target, 0, 4);
                target.taunt = true;
            }
		}

	}
}