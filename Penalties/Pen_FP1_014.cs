// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_FP1_014.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ f p 1_014.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ f p 1_014.
    /// </summary>
    internal class Pen_FP1_014 : PenTemplate
    {
        // stalagg

        // todesröcheln:/ ruft thaddius herbei, wenn feugen in diesem duell bereits gestorben ist.
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