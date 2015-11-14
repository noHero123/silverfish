using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_118 : SimTemplate //Grand Crusader
    {

        //Battlecry: Add a random Paladin card to your hand

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (p.isServer)
            {
                //TODO
                p.drawACard(CardDB.cardIDEnum.CS2_093, own.own, true); //consecration
                return;
            }

            p.drawACard(CardDB.cardIDEnum.CS2_093, own.own, true); //consecration

        }

       

    }
}