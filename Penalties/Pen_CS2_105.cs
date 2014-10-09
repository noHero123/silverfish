// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_CS2_105.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ c s 2_105.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ c s 2_105.
    /// </summary>
    internal class Pen_CS2_105 : PenTemplate
    {
        // heroicstrike

        // verleiht eurem helden +4 angriff in diesem zug.
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
            if (!p.ownHero.Ready)
            {
                return 100;
            }

            return 0;
        }

        #endregion
    }
}