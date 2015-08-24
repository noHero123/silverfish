using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_077 : SimTemplate //Argent Lance
    {

        //Battlecry: Reveal a minion in each deck. If yours costs more, +1 Durability.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_034);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);

            if (p.isServer)
            {
                //TODO
                p.lowerWeaponDurability(-1, ownplay);//-1 = raise dura :D
                return;
            }

            p.lowerWeaponDurability(-1, ownplay);//-1 = raise dura :D
        }


       

    }
}