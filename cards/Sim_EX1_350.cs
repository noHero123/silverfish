// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_350.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_350.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_350.
    /// </summary>
    class Sim_EX1_350 : SimTemplate
	{
	    // prophetvelen

// verdoppelt den schaden und die heilung eurer zauber und heldenfähigkeiten.
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
                p.doublepriest++;
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
                p.doublepriest--;
            }
        }

	}
}