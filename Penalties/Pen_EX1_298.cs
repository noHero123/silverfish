// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_298.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_298.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ e x 1_298.
    /// </summary>
    internal class Pen_EX1_298 : PenTemplate
    {
        // ragnarosthefirelord

        // kann nicht angreifen. fügt am ende eures zuges einem zufälligen feind 8 schaden zu.
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