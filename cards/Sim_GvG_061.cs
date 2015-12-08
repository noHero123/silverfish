using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_061 : SimTemplate //Muster for Battle
    {

        //   Summon three 1/1 Silver Hand Recruits. Equip a 1/4 Weapon.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_091);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);

            for (int i = 0; i < 2; i++)
            {
                pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, pos + 1, ownplay, true);  // spawnkid
            }
            p.equipWeapon(w, ownplay);
        }


    }

}