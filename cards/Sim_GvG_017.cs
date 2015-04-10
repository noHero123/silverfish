using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_017 : SimTemplate //Call Pet
    {

        //    Draw a card. If it's a Beast, it costs (4) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.evaluatePenality += (ownplay) ? -10 : 10;
        }


    }

}