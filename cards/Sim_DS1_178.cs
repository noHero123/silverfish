// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DS1_178.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ d s 1_178.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ d s 1_178.
    /// </summary>
    internal class Sim_DS1_178 : SimTemplate
    {
        // tundrarhino

        // eure wildtiere haben ansturm/.
        // todo charge?
        #region Public Methods and Operators

        /// <summary>
        /// The on aura ends.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnTundrarhino--;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                    {
                        p.minionLostCharge(m);
                    }
                }
            }
            else
            {
                p.anzEnemyTundrarhino--;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                    {
                        p.minionLostCharge(m);
                    }
                }
            }
        }

        /// <summary>
        /// The on aura starts.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnTundrarhino++;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                    {
                        p.minionGetCharge(m);
                    }
                }
            }
            else
            {
                p.anzEnemyTundrarhino++;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                    {
                        p.minionGetCharge(m);
                    }
                }
            }
        }

        #endregion
    }
}