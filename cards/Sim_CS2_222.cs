// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_222.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_222.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_222.
    /// </summary>
    internal class Sim_CS2_222 : SimTemplate
    {
        // stormwindchampion

        // eure anderen diener haben +1/+1.
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
                p.anzOwnStormwindChamps--;
                foreach (Minion m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, -1);
                    }
                }
            }
            else
            {
                p.anzEnemyStormwindChamps--;
                foreach (Minion m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID)
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
                p.anzOwnStormwindChamps++;
                foreach (Minion m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 1);
                    }
                }
            }
            else
            {
                p.anzEnemyStormwindChamps++;
                foreach (Minion m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 1);
                    }
                }
            }
        }

        #endregion
    }
}