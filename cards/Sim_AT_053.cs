using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_053 : SimTemplate //Ancestral Knowledge
    {

        //    Draw 2 cards. Overload: (2)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.changeRecall(ownplay, 2);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            
        }

    }
}