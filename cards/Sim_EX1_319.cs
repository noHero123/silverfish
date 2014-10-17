using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_319 : SimTemplate //flameimp
    {

        //    kampfschrei:/ fügt eurem helden 3 schaden zu.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, 3);
        }


    }
}