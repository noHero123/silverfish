// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_033.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_033.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_033.
    /// </summary>
    internal class Sim_NEW1_033 : SimTemplate
    {
        // leokk

        // andere befreundete diener haben +1 angriff.
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
                p.anzOwnRaidleader--;
                foreach (Minion m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, 0);
                    }
                }
            }
            else
            {
                p.anzEnemyRaidleader--;
                foreach (Minion m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, 0);
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
                p.anzOwnRaidleader++;
                foreach (Minion m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 0);
                    }
                }
            }
            else
            {
                p.anzEnemyRaidleader++;
                foreach (Minion m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 0);
                    }
                }
            }
        }

        #endregion
    }
}