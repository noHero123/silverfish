// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_623.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_623.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ e x 1_623.
    /// </summary>
    internal class Pen_EX1_623 : PenTemplate
    {
        // templeenforcer

        // kampfschrei:/ verleiht einem befreundeten diener +3 leben.
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