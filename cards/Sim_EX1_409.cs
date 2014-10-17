using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_409 : SimTemplate //upgrade
	{
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_409t);//heavyaxe
//    wenn ihr eine waffe habt, erhält sie +1/+1. legt anderenfalls eine waffe (1/3) an.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                if (p.ownWeaponName != CardDB.cardName.unknown)
                {
                    p.ownWeaponAttack++;
                    p.ownWeaponDurability++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
                else
                {

                    p.equipWeapon(wcard, true);
                }
            }
            else
            {
                if (p.enemyWeaponName != CardDB.cardName.unknown)
                {
                    p.enemyWeaponAttack++;
                    p.enemyWeaponDurability++;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
                else
                {

                    p.equipWeapon(wcard, false);
                }
            }
		}

	}

}