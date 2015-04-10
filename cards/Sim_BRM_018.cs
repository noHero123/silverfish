using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_018 : SimTemplate //Dragon Consort
    {


        //    Battlecry: The next Dragon you play costs (2) less.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.ownDragonConsort++;
            }
            else
            {
                p.enemyDragonConsort++;
            }
            
        }

    }
}