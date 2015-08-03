using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_030 : SimTemplate //Nefarian
    {
        //TODO
        //   Add 2 random spells to your hand (from your opponent's class).
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                p.drawACard(CardDB.cardIDEnum.BRM_030t, own.own, true);
                p.drawACard(CardDB.cardIDEnum.BRM_030t, own.own, true);
                return;
            }

            if (own.own)
            {
                /*if (p.enemyHeroName == HeroEnum.druid)
                {
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                }
                if (p.enemyHeroName == HeroEnum.hunter)
                {
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                }
                if (p.enemyHeroName == HeroEnum.mage)
                {
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                }
                if (p.enemyHeroName == HeroEnum.pala)
                {
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                }
                if (p.enemyHeroName == HeroEnum.priest)
                {
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                }
                if (p.enemyHeroName == HeroEnum.shaman)
                {
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                }
                if (p.enemyHeroName == HeroEnum.thief)
                {
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                }
                if (p.enemyHeroName == HeroEnum.warlock || p.enemyHeroName == HeroEnum.lordjaraxxus)
                {
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                }
                if (p.enemyHeroName == HeroEnum.warrior)
                {
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                    p.drawACard(CardDB.cardIDEnum.None, true, true);
                }*/
                p.drawACard(CardDB.cardIDEnum.BRM_030t, true, true);
                p.drawACard(CardDB.cardIDEnum.BRM_030t, true, true);
                
            }
            else
            {
                p.drawACard(CardDB.cardIDEnum.None, false, true);
                p.drawACard(CardDB.cardIDEnum.None, false, true);
            }
        }

    }
}