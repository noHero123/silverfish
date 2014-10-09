// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_017.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_017.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_017.
    /// </summary>
    class Sim_FP1_017 : SimTemplate
	{
	    // nerubarweblord

// diener mit kampfschrei/ kosten (2) mehr.
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
            p.nerubarweblord++;
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
            p.nerubarweblord--;
        }


	}
}