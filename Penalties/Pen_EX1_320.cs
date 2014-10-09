// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_320.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_320.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_320.
    /// </summary>
    class Pen_EX1_320 : PenTemplate
	{
	    // baneofdoom

// fügt einem charakter $2 schaden zu. beschwört einen zufälligen dämon, wenn der schaden tödlich ist.
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