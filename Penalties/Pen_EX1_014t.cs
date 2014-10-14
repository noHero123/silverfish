// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_014t.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_014 t.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen_ e x 1_014 t.
    /// </summary>
    internal class Pen_EX1_014t : PenTemplate
    {
        // bananas

        // verleiht einem diener +1/+1.
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
                    return 50;
                }

                if (m.Hp == 1 && !m.divineshild)
                {
                    return 10;
                }
            }
            else
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.biggamehunter || hc.card.name == CardDB.cardName.shadowworddeath)
                    {
                        return 0;
                    }
                }

                return 500;
            }

            return 0;
        }

        #endregion
    }
}