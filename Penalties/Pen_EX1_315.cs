// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_315.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_315.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ e x 1_315.
    /// </summary>
    internal class Pen_EX1_315 : PenTemplate
    {
        // summoningportal

        // eure diener kosten (2) weniger, aber nicht weniger als (1).
        #region Public Methods and Operators

        /// <summary>
        /// The get play penalty.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        /// <param name="isLethal">
        /// The is lethal.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }

        #endregion
    }
}