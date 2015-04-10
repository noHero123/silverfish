using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_024 : SimTemplate //Drakonid Crusher
    {

        //   Battlecry: If your opponent has 15 or less Health, gain +3/+3.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Handmanager.Handcard> temp =  p.owncards;

            bool opponentbelow15 = false;
            if (own.own && p.enemyHero.Hp <= 15) opponentbelow15 = true;
            if (!own.own && p.ownHero.Hp <= 15) opponentbelow15 = true;
            if (opponentbelow15) p.minionGetBuffed(own, 3, 3);
        }


    }

}