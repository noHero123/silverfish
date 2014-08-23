using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_558 : SimTemplate //harrisonjones
	{
        //todo enemy
//    kampfschrei:/ zerstört die waffe eures gegners. zieht ihrer haltbarkeit entsprechend karten.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.enemyWeaponAttack = 0;
            //this.owncarddraw += enemyWeaponDurability;
            for (int i = 0; i < p.enemyWeaponDurability; i++)
            {
                p.drawACard(CardDB.cardName.unknown, true);
            }
            p.enemyWeaponDurability = 0;
            p.enemyWeaponName = CardDB.cardName.unknown;
		}


	}
}