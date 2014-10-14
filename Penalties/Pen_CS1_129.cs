// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_CS1_129.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ c s 1_129.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ c s 1_129.
    /// </summary>
    internal class Pen_CS1_129 : PenTemplate
    {
        // innerfire

        // setzt den angriff eines dieners auf einen wert, der seinem leben entspricht.
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