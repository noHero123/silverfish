using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_164 : SimTemplate //nourish
    {

        //    wählt aus:/ erhaltet 2 manakristalle; oder zieht 3 karten.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1)
            {
                if (ownplay)
                {
                    p.mana = Math.Min(10, p.mana + 2);
                    p.ownMaxMana = Math.Min(10, p.ownMaxMana + 2);
                }
                else
                {
                    p.mana = Math.Min(10, p.mana + 2);
                    p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 2);
                }
            }
            if (choice == 2)
            {
                //this.owncarddraw+=3;
                p.drawACard(CardDB.cardIDEnum.None, ownplay);
                p.drawACard(CardDB.cardIDEnum.None, ownplay);
                p.drawACard(CardDB.cardIDEnum.None, ownplay);
            }
        }

    }


}