// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_Mekka4t.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ mekka 4 t.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ mekka 4 t.
    /// </summary>
    internal class Pen_Mekka4t : PenTemplate
    {
        // chicken

        // i&gt;put, put, put!/i&gt;
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