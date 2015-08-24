using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_079 : SimTemplate//Mysterious Challenger
    {
        //Battlecry: Put one of each Secret from your deck into the battlefield

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            //if(p.isServer) 
            //TODO

            if (own.own)
            {
                if (p.ownHeroName == HeroEnum.mage)
                {
                    p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_289);
                }
                if (p.ownHeroName == HeroEnum.hunter)
                {
                    p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_554);
                }
                if (p.ownHeroName == HeroEnum.pala)
                {
                    p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_130);
                }
            }
            else
            {
                if (p.enemyHeroName == HeroEnum.mage || p.enemyHeroName == HeroEnum.hunter || p.enemyHeroName == HeroEnum.pala)
                {
                    if (p.enemySecretCount <= 4)
                    {
                        p.enemySecretCount++;
                        SecretItem si = Probabilitymaker.Instance.getNewSecretGuessedItem(p.getNextEntity(), p.enemyHeroName);
                        if (p.enemyHeroName == HeroEnum.pala)
                        {
                            si.canBe_redemption = false;
                        }
                        if (Settings.Instance.useSecretsPlayArround)
                        {
                            p.enemySecretList.Add(si);
                        }
                    }
                }
            }
            
        }
    }

}
