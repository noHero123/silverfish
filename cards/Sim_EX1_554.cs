using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_554 : SimTemplate //snaketrap
	{
        //todo secret
//    geheimnis:/ wenn einer eurer diener angegriffen wird, ruft ihr drei schlangen (1/1) herbei.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t);//snake

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            if (ownplay)
            {
                int posi = p.ownMinions.Count;
                p.callKid(kid, posi, true);
                p.callKid(kid, posi, true);
                p.callKid(kid, posi, true);
            }
            else
            {
                int posi = p.enemyMinions.Count;
                p.callKid(kid, posi, false);
                p.callKid(kid, posi, false);
                p.callKid(kid, posi, false);
            }
        }

	}

}