// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_DS1_055.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ d s 1_055.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ d s 1_055.
    /// </summary>
    internal class Pen_DS1_055 : PenTemplate
    {
        // darkscalehealer

        // kampfschrei:/ stellt bei allen befreundeten charakteren 2 leben wieder her.
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