// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_080.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_080.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ e x 1_080.
    /// </summary>
    internal class Pen_EX1_080 : PenTemplate
    {
        // secretkeeper

        // erhält jedes mal +1/+1, wenn ein geheimnis/ ausgespielt wird.
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