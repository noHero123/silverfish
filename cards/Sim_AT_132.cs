using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_132 : SimTemplate //Spellslinger
    {

        //Battlecry: Add a random spell to each player's hand.

        CardDB.Card drui = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_DRUID);
        CardDB.Card hunti = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_HUNTER);
        CardDB.Card magi = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_MAGE);
        CardDB.Card pali = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_PALADIN);
        CardDB.Card pipi = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_PRIEST);
        CardDB.Card rogi = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_ROGUE);
        CardDB.Card shami = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_SHAMAN);
        CardDB.Card warli = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_WARLOCK);
        CardDB.Card warri = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_WARRIOR);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.heroPowerActivationsThisTurn = 0;
            if (own.own)
            {
                p.ownAbilityReady = true;
                if (p.ownHeroName == HeroEnum.druid)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(drui);
                }

                if (p.ownHeroName == HeroEnum.hunter)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(hunti);
                }

                if (p.ownHeroName == HeroEnum.mage)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(magi);
                }

                if (p.ownHeroName == HeroEnum.pala)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(pali);
                }

                if (p.ownHeroName == HeroEnum.priest)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(pipi);
                }

                if (p.ownHeroName == HeroEnum.thief)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(rogi);
                }

                if (p.ownHeroName == HeroEnum.shaman)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(shami);
                }

                if (p.ownHeroName == HeroEnum.warlock)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(warli);
                }

                if (p.ownHeroName == HeroEnum.warrior)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(warri);
                }

                if (p.ownHeroName == HeroEnum.lordjaraxxus)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(warli);//hightes possibility :D
                }

                

            }
            else
            {

                p.enemyAbilityReady = true;
                if (p.enemyHeroName == HeroEnum.druid)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(drui);
                }

                if (p.enemyHeroName == HeroEnum.hunter)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(hunti);
                }

                if (p.enemyHeroName == HeroEnum.mage)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(magi);
                }

                if (p.enemyHeroName == HeroEnum.pala)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(pali);
                }

                if (p.enemyHeroName == HeroEnum.priest)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(pipi);
                }

                if (p.enemyHeroName == HeroEnum.thief)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(rogi);
                }

                if (p.enemyHeroName == HeroEnum.shaman)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(shami);
                }

                if (p.enemyHeroName == HeroEnum.warlock)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(warli);
                }

                if (p.enemyHeroName == HeroEnum.warrior)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(warri);
                }

                if (p.enemyHeroName == HeroEnum.lordjaraxxus)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(warli);
                }
            }

        }

       

    }
}