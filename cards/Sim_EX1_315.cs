// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_315.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_315.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_315.
    /// </summary>
    class Sim_EX1_315 : SimTemplate
	{
	    // summoningportal

// eure diener kosten (2) weniger, aber nicht weniger als (1).
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
            if (own.own) p.beschwoerungsportal++;
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
            if (m.own) p.beschwoerungsportal--;
        }


	}
}