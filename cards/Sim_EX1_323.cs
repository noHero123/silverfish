using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_323 : SimTemplate //lordjaraxxus
	{
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk33);
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_323w);
        
//    kampfschrei:/ vernichtet euren helden und ersetzt ihn durch lord jaraxxus.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.ownHeroAblility.card = card;
                p.ownHeroName = HeroEnum.lordjaraxxus;
                p.ownHero.Hp = own.Hp;
                p.ownHero.maxHp = own.maxHp;

                p.equipWeapon(weapon, own.own);
                p.ownAbilityReady = true;
            }
            else 
            {
                p.enemyHeroAblility.card = card;
                p.enemyHeroName = HeroEnum.lordjaraxxus;
                p.enemyHero.Hp = own.Hp;
                p.enemyHero.maxHp = own.maxHp;

                p.equipWeapon(weapon, own.own);
                p.enemyAbilityReady = true;
            }
            p.heroPowerActivationsThisTurn = 0;
		}

	}
}