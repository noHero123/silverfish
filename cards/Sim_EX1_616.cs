// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_616.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_616.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_616.
    /// </summary>
    internal class Sim_EX1_616 : SimTemplate
    {
        // manawraith

        // alle diener kosten (1) mehr.
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
            p.managespenst--;
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
            p.managespenst ++;
        }

        #endregion
    }
}