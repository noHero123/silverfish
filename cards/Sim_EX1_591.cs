// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_591.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_591.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_591.
    /// </summary>
    class Sim_EX1_591 : SimTemplate
	{
	    // auchenaisoulpriest

// eure karten und fähigkeiten, die leben wiederherstellen, verursachen stattdessen nun schaden.
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
                p.anzOwnAuchenaiSoulpriest++;
            }
            else
            {
                p.anzEnemyAuchenaiSoulpriest++;
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
                p.anzOwnAuchenaiSoulpriest--;
            }
            else
            {
                p.anzEnemyAuchenaiSoulpriest--;
            }
        }


	}
}