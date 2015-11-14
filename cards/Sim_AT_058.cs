using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_058 : SimTemplate //Spellslinger
    {

        //Battlecry: Reveal a minion in each deck. If yours costs more, draw it.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                //TODO
                p.drawACard(CardDB.cardIDEnum.None, own.own, true);
                return;
            }

            p.drawACard(CardDB.cardIDEnum.None, own.own, true);
        }

       

    }
}