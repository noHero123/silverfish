// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DS1_175.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ d s 1_175.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ d s 1_175.
    /// </summary>
    class Sim_DS1_175 : SimTemplate
	{
	    // timberwolf

// eure anderen wildtiere haben +1 angriff.
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
                p.anzOwnTimberWolfs++;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET && m.entitiyID != own.entitiyID) p.minionGetBuffed(m, 1, 0);
                }
            }
            else
            {
                p.anzEnemyTimberWolfs++;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET && m.entitiyID != own.entitiyID) p.minionGetBuffed(m, 1, 0);
                }
            }

        }

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
                p.anzOwnTimberWolfs--;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET && m.entitiyID != own.entitiyID) p.minionGetBuffed(m, -1, 0);
                }
            }
            else
            {
                p.anzEnemyTimberWolfs--;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET && m.entitiyID != own.entitiyID) p.minionGetBuffed(m, -1, 0);
                }
            }
        }

	}
}