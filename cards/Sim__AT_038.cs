using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

    class Sim_AT_038 : SimTemplate//Darnassus Aspirant
    {
        //Battlecry: Gain an empty Mana Crystal. Deathrattle: Lose a Mana Crystal.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.ownMaxMana < 10)
                {
                    p.ownMaxMana++;
                }

            }
            else
            {
                if (p.enemyMaxMana < 10)
                {
                    p.enemyMaxMana++;
                }
            }
        }


        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownMaxMana--;
                if(p.isOwnTurn)p.mana--;

            }
            else
            {
                p.enemyMaxMana--;
                if (!p.isOwnTurn) p.mana--;
            }
        }


    }

    
}
