// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_NEW1_007a.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ ne w 1_007 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ ne w 1_007 a.
    /// </summary>
    internal class Pen_NEW1_007a : PenTemplate
    {
        // starfall

        // fügt allen feindlichen dienern $2 schaden zu.
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