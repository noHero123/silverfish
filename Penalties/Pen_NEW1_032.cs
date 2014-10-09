// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_NEW1_032.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ ne w 1_032.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ ne w 1_032.
    /// </summary>
    internal class Pen_NEW1_032 : PenTemplate
    {
        // misha

        // spott/
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