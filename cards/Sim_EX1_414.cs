// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_414.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_414.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_414.
    /// </summary>
    internal class Sim_EX1_414 : SimTemplate
    {
        // grommashhellscream

        // ansturm/, wutanfall:/ +6 angriff
        #region Public Methods and Operators

        /// <summary>
        /// The on enrage start.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr += 6;
        }

        /// <summary>
        /// The on enrage stop.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr -= 6;
        }

        #endregion
    }
}