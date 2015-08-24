using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_033 : SimTemplate //Burgle
    {

        //   Add 2 random class cards to your hand (from your opponent's class)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.isServer)
            {
                //TODO
                p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
                p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
                return;
            }
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);

        }


    }

}