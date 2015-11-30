using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_027 : SimTemplate //Majordomo Executus
    {

        //   Deathrattle: Replace your hero with Ragnaros, the Firelord.

        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_027p);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownHeroAblility.card = card;
                p.ownHeroName = HeroEnum.ragnarosthefirelord;
                p.ownHero.Hp = 8;
                p.ownHero.maxHp = 8;
                p.ownAbilityReady = true;
            }
            else
            {
                p.enemyHeroAblility.card = card;
                p.enemyHeroName = HeroEnum.ragnarosthefirelord;
                p.enemyHero.Hp = 8;
                p.enemyHero.maxHp = 8;
                p.enemyAbilityReady = true;

            }
            if(m.own == p.isOwnTurn) p.heroPowerActivationsThisTurn = 0;
        }




    }

}