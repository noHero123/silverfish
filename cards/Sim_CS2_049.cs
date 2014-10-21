using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_049 : SimTemplate //totemiccall
    {

        //    heldenfähigkeit/\nbeschwört ein zufälliges totem.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_050);//
        CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_052);//
        //    heldenfähigkeit/\nruft einen rekruten der silbernen hand (1/1) herbei.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            bool spawnspellpower = true;
            foreach (Minion m in (ownplay) ? p.ownMinions : p.enemyMinions)
            {
                if (m.handcard.card.cardIDenum == CardDB.cardIDEnum.CS2_052)
                {
                    spawnspellpower = false;
                    break;
                }
            }
            p.callKid((spawnspellpower) ? kid2 : kid, posi, ownplay);
        }
    }

}