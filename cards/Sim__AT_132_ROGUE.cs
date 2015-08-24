using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_132_ROGUE : SimTemplate //daggermastery
	{

        //    heldenfähigkeit/ Equip a 2/2 Weapon.
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_082);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay && p.ownWeaponDurability >= 1 && p.ownWeaponName == CardDB.cardName.poisonedblade)
            {
                p.ownWeaponAttack++;
                return;
            }
            if (!ownplay && p.enemyWeaponDurability >= 1 && p.enemyWeaponName == CardDB.cardName.poisonedblade)
            {
                p.enemyWeaponAttack++;
                return;
            }
            p.equipWeapon(weapon, ownplay);
        }

	}
}