// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_093.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_093.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ e x 1_093.
    /// </summary>
    internal class Pen_EX1_093 : PenTemplate
    {
        // defenderofargus

        // kampfschrei:/ verleiht benachbarten dienern +1/+1 und spott/.
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