// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_227.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_227.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_227.
    /// </summary>
    internal class Sim_CS2_227 : SimTemplate
    {
        // venturecomercenary

        // eure diener kosten (3) mehr.
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
                p.soeldnerDerVenture--;
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
                p.soeldnerDerVenture++;
            }
        }

        #endregion
    }
}