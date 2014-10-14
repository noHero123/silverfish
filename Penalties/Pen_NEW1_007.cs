// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_NEW1_007.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ ne w 1_007.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ ne w 1_007.
    /// </summary>
    internal class Pen_NEW1_007 : PenTemplate
    {
        // starfall

        // wählt aus:/ fügt einem diener $5 schaden zu; oder fügt allen feindlichen dienern $2 schaden zu.
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