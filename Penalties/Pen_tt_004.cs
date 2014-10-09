// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_tt_004.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_tt_004.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_tt_004.
    /// </summary>
    internal class Pen_tt_004 : PenTemplate
    {
        // flesheatingghoul

        // erhält jedes mal +1 angriff, wenn ein diener stirbt.
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