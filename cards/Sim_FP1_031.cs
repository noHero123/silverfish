// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_031.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_031.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_031.
    /// </summary>
    class Sim_FP1_031 : SimTemplate
	{
	    // baronrivendare

// die todesröcheln/-effekte eurer diener werden 2-mal ausgelöst.
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
            if (own.own) p.ownBaronRivendare++;
            else p.enemyBaronRivendare++;
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
                p.ownBaronRivendare--;
            }
            else
            {
                p.enemyBaronRivendare--;
            }
        }

	}
}