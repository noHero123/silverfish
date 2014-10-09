// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_155.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_155.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_155.
    /// </summary>
    class Sim_CS2_155 : SimTemplate
	{
	    // archmage

// zauberschaden +1/
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
                p.spellpower++;
            }
            else
            {
                p.enemyspellpower++;
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

            if (m.own)
            {
                p.spellpower--;
            }
            else
            {
                p.enemyspellpower--;
            }
        }


	}
}