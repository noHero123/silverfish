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
                    if (p.ownMaxMana >= 10)
                    {
                        //p.drawACard(CardDB.cardName.excessmana, true);
                        if (p.mana < 10) p.mana++;
                    }
                    else
                    {
                        p.ownMaxMana++;
                        p.mana++;
                    }
                    if (p.ownMaxMana >= 10)
                    {
                        //this.owncarddraw++;
                        //p.drawACard(CardDB.cardName.excessmana, true);
                        if (p.mana < 10) p.mana++;
                    }
                    else
                    {
                        p.ownMaxMana++;
                        p.mana++;
                    }
                }
                else
                {
                    if (p.enemyMaxMana == 10)
                    {
                        //p.drawACard(CardDB.cardName.excessmana, false);
                        if (p.mana < 10) p.mana++;
                    }
                    else
                    {
                        p.enemyMaxMana++;
                        p.mana++;
                    }
                    if (p.enemyMaxMana == 10)
                    {
                        //this.owncarddraw++;
                        //p.drawACard(CardDB.cardName.excessmana, false);
                        if (p.mana < 10) p.mana++;
                    }
                    else
                    {
                        p.enemyMaxMana++;
                        p.mana++;
                    }
                }
            }
            if (choice == 2)
            {
                //this.owncarddraw+=3;
                p.drawACard(CardDB.cardName.unknown, ownplay);
                p.drawACard(CardDB.cardName.unknown, ownplay);
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }
        }

    }


}