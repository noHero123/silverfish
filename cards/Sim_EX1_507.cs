// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_507.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_507.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_507.
    /// </summary>
    internal class Sim_EX1_507 : SimTemplate
    {
        // murlocwarleader

        // alle anderen murlocs haben +2/+1.
        #region Public Methods and Operators

        /// <summary>
        /// The on aura ends.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.anzMurlocWarleader--;
            foreach (Minion mn in p.ownMinions)
            {
                if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.MURLOC && mn.entitiyID != m.entitiyID)
                {
                    p.minionGetBuffed(m, -2, -1);
                }
            }

            foreach (Minion mn in p.enemyMinions)
            {
                if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.MURLOC && mn.entitiyID != m.entitiyID)
                {
                    p.minionGetBuffed(m, -2, -1);
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
            p.anzMurlocWarleader++;
            foreach (Minion m in p.ownMinions)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC && own.entitiyID != m.entitiyID)
                {
                    p.minionGetBuffed(m, 2, 1);
                }
            }

            foreach (Minion m in p.enemyMinions)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC && own.entitiyID != m.entitiyID)
                {
                    p.minionGetBuffed(m, 2, 1);
                }
            }
        }

        #endregion
    }
}