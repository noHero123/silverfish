// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_508.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_508.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_508.
    /// </summary>
    class Sim_EX1_508 : SimTemplate
    {
        // Grimscale Oracle
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
            p.anzGrimscaleOracle++;
            foreach (Minion m in p.ownMinions)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 1, 0);
            }

            foreach (Minion m in p.enemyMinions)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 1, 0);
            }
        }

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
            p.anzGrimscaleOracle--;
            foreach (Minion mn in p.ownMinions)
            {
                if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.MURLOC && mn.entitiyID != m.entitiyID) p.minionGetBuffed(m, -1, 0);
            }

            foreach (Minion mn in p.enemyMinions)
            {
                if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.MURLOC && mn.entitiyID != m.entitiyID) p.minionGetBuffed(m, -1, 0);
            }
        }
    }
}
