// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_DREAM_05.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ drea m_05.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ drea m_05.
    /// </summary>
    internal class Pen_DREAM_05 : PenTemplate
    {
        // nightmare

        // verleiht einem diener +5/+5. zu beginn eures nächsten zuges wird er vernichtet.
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
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 500;
                }

                return 0;
            }

            if (target.frozen)
            {
                return 0;
            }

            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.name == CardDB.cardName.biggamehunter || hc.card.name == CardDB.cardName.shadowworddeath)
                {
                    return 0;
                }
            }

            return 20;
            return 0;
        }

        #endregion
    }
}