using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_012 : SimTemplate// tomb pillager
    {
        //Deathrattle: Add a Coin to your hand.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.GAME_005, m.own, true);
        }
        

            
    }
}
