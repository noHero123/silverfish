using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_018 : SimTemplate //duplicate
	{
        //todo secret
//    geheimnis:/ wenn ein befreundeter diener stirbt, erhaltet ihr 2 kopien dieses dieners auf eure hand.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            if (ownplay)
            {
                p.drawACard(p.revivingOwnMinion, ownplay, true);
                p.drawACard(p.revivingOwnMinion, ownplay, true);
            }
            else
            {
                p.drawACard(p.revivingEnemyMinion, ownplay, true);
                p.drawACard(p.revivingEnemyMinion, ownplay, true);
            }

        }

	}

}