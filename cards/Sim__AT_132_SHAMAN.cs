using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_132_SHAMAN : SimTemplate //totemiccall
    {

        //    heldenfähigkeit/\nbeschwört ein zufälliges totem.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_SHAMANa);// Healing Totem
        CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_SHAMANb);//Searing Totem
        CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_SHAMANc);//Stoneclaw Totem
        CardDB.Card kid4 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_SHAMANd);//Wrath of Air Totem

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (!ownplay)
            {
                p.callKid(kid3, posi, ownplay);
                return;
            }
            

            if (choice == 1)
            {
                p.callKid(kid, posi, ownplay);
                return;
            }

            if (choice == 2)
            {
                p.callKid(kid2, posi, ownplay);
                return;
            }

            if (choice == 3)
            {
                p.callKid(kid3, posi, ownplay);
                
                return;
            }

            if (choice == 4)
            {
                p.callKid(kid4, posi, ownplay);
                return;
            }
            
        }
    }

}