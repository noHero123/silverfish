using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_234 : SimTemplate //shadowwordpain
	{

//    vernichtet einen diener mit max. 3 angriff.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDestroyed(target);
		}


	}
}