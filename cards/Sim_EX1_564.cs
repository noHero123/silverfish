using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_564 : SimTemplate //facelessmanipulator
    {

        //    kampfschrei:/ wählt einen diener aus, um gesichtsloser manipulator in eine kopie desselben zu verwandeln.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                //p.copyMinion(own, target);
                bool source = own.own;
                own.setMinionTominion(target);
                own.own = source;
                own.handcard.card.sim_card.onAuraStarts(p, own);
            }
        }


    }
}