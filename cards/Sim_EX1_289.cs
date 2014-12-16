using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_289 : SimTemplate //icebarrier
	{

        //todo secret
//    geheimnis:/ wenn euer held angegriffen wird, erhält er 8 rüstung.
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            
            p.minionGetArmor(target, 8);
        }

	}

}