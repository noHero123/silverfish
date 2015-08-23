using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_178 : SimTemplate //ancientofwar
    {

        //    wählt aus:/ +5 angriff; oder +5 leben und spott/.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            //These seem to have been mistakenly/maybe purposely, flipped, always causing the unfavourable +5 attack option to be chosen
            if (choice == 1)
            {
                p.minionGetBuffed(own, 5, 0);
            }
            if (choice == 2)
            {
                p.minionGetBuffed(own, 0, 5);
                own.taunt = true;
            }
        }


    }

}
