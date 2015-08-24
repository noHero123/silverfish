using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_069 : SimTemplate //Sparring Partner
    {

        //Taunt , Battlecry:Give a minion Taunt

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) target.taunt = true;
        }

       

    }
}