using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_065 : SimTemplate //King's Defender
    {

        //Battlecry: If you have a minion with Taunt gain +1 Durability.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_034);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);

            bool hasTnt = false;
            foreach (Minion m in (ownplay) ? p.ownMinions : p.enemyMinions)
            {
                if (m.taunt) hasTnt = true;
            }

            if (hasTnt)
            {
                p.lowerWeaponDurability(-1, ownplay);//-1 = raise dura :D
            }
        }


       

    }
}