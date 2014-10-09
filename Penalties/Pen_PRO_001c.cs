// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_PRO_001c.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ pr o_001 c.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ pr o_001 c.
    /// </summary>
    internal class Pen_PRO_001c : PenTemplate
    {
        // powerofthehorde

        // beschwört einen zufälligen krieger der horde.
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