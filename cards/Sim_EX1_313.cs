using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_313 : SimTemplate //pitlord
    {

        //    kampfschrei:/ fügt eurem helden 5 schaden zu.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, 5);
        }


    }
}