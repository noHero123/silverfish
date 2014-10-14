// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_316.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_316.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ e x 1_316.
    /// </summary>
    internal class Pen_EX1_316 : PenTemplate
    {
        // poweroverwhelming

        // verleiht einem befreundeten diener bis zum ende des zuges +4/+4. dann stirbt er. auf schreckliche art und weise.
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
            if (!m.Ready)
            {
                return 500;
            }

            return 0;
        }

        #endregion
    }
}