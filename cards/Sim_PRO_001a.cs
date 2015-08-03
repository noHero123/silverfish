using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_PRO_001a : SimTemplate//I Am Murloc
    {
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.PRO_001at);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count ;

            if (p.isServer)
            {
                
                int random1 = p.getRandomNumber_SERVER(3, 5);
                for (int i = 0; i < random1; i++)
                {
                    p.callKid(kid, posi, ownplay);
                }
                return;
            }

            p.callKid(kid, posi, ownplay);
            p.callKid(kid, posi, ownplay);
            p.callKid(kid, posi, ownplay);
            p.callKid(kid, posi, ownplay);
        }

    }
}
