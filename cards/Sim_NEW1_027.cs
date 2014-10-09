// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_027.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_027.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_027.
    /// </summary>
    internal class Sim_NEW1_027 : SimTemplate
    {
        // southseacaptain

        // eure anderen piraten haben +1/+1.
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
                p.anzOwnSouthseacaptain--;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE && own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, -1);
                    }
                }
            }
            else
            {
                p.anzEnemySouthseacaptain--;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE && own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, -1);
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
                p.anzOwnSouthseacaptain++;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE && own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 1);
                    }
                }
            }
            else
            {
                p.anzEnemySouthseacaptain++;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE && own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 1);
                    }
                }
            }
        }

        #endregion
    }
}