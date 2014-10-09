// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_004.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_004.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_004.
    /// </summary>
    class Sim_FP1_004 : SimTemplate
    {
        // Mad Scientist
        // <deDE>&lt;b&gt;TodesrÃ¶cheln:&lt;/b&gt; Legt ein &lt;b&gt;Geheimnis&lt;/b&gt; aus Eurem Deck auf das Schlachtfeld.</deDE>

        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
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
                        SecretItem si = Probabilitymaker.Instance.getNewSecretGuessedItem(p.nextEntity, p.enemyHeroName);
                        if (p.enemyHeroName == HeroEnum.pala)
                        {
                            si.canBe_redemption = false;
                        }

                        if (Settings.Instance.useSecretsPlayArround)
                        {
                            p.enemySecretList.Add(si);
                        }

                        p.nextEntity++;
                    }
                }
            }
            
        }
    }

}
