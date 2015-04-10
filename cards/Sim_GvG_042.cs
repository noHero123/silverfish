using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_042 : SimTemplate //Neptulon
    {

        // Battlecry: Add 4 random Murlocs to your hand. Overload: (3)
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_168);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            
            for (int i = 0; i < 4; i++)
            {
                int posi = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, posi, own.own);
            }
            if (own.own) { p.owedRecall += 3; } else { p.enemyRecall += 3; };
        }


    }

}