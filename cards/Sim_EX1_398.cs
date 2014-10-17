using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_398 : SimTemplate//Arathi Weaponsmith
    {
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_398t);//battleaxe

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(wcard,own.own);

        }

    }
}
