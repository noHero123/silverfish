// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_408.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_408.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ e x 1_408.
    /// </summary>
    internal class Pen_EX1_408 : PenTemplate
    {
        // mortalstrike

        // verursacht $4 schaden. verursacht stattdessen $6 schaden, wenn euer held max. 12 leben hat.
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