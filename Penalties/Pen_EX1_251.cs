// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_251.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_251.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_251.
    /// </summary>
    class Pen_EX1_251 : PenTemplate
	{
	    // forkedlightning

// fügt zwei zufälligen feindlichen dienern $2 schaden zu. überladung:/ (2)
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

	}
}