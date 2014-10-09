// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_GAME_005.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ gam e_005.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ gam e_005.
    /// </summary>
    internal class Pen_GAME_005 : PenTemplate
    {
        // thecoin

        // erhaltet 1 manakristall nur für diesen zug.
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