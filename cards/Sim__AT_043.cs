using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_043 : SimTemplate //Astral Communion
    {

        //   Gain 10 Mana Crystals. Discard your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {

                if (p.ownMaxMana == 10)
                {
                    discardHand(p, ownplay);
                    p.drawACard(CardDB.cardIDEnum.CS2_013t, ownplay);
                }
                else
                {
                    discardHand(p, ownplay);
                    p.ownMaxMana = 10;
                }

            }
            else
            {
                if (p.enemyMaxMana == 10)
                {
                    discardHand(p, ownplay);
                    p.drawACard(CardDB.cardIDEnum.CS2_013t, ownplay);
                }
                else
                {
                    discardHand(p,ownplay);
                    p.enemyMaxMana = 10;
                }
            }
            
        }

        private void discardHand(Playfield p, bool own)
        {
            int anz = (own) ? p.owncards.Count : p.enemyAnzCards;
            if (own)
            {
                p.owncards.Clear();
            }
            else
            {
                p.enemyAnzCards = 0;
            }

            for (int i = 0; i < anz; i++)
            {
                p.triggerACardWasDiscarded(own);
            }
        }


    }

}