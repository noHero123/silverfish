using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_036 : SimTemplate //Powermace
    {
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_036);

        //    &gt;Deathrattle&lt;/b&gt;: Give a random friendly Mech +2/+2.</Tag>
        // DR handled in lowerWeaponDurability()

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }


    }

}