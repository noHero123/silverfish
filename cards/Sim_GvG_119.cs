using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_119 : SimTemplate //Blingtron 3000
    {

        //   Battlecry: Equip a random weapon for each player.
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_080);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(w, true);
            p.equipWeapon(w, false);
        }


    }

}