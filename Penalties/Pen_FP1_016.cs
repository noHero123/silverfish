// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_FP1_016.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ f p 1_016.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ f p 1_016.
    /// </summary>
    internal class Pen_FP1_016 : PenTemplate
    {
        // wailingsoul

        // kampfschrei:/ bringt eure anderen diener zum schweigen/.
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