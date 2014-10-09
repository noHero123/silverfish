// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_FP1_006.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ f p 1_006.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ f p 1_006.
    /// </summary>
    class Pen_FP1_006 : PenTemplate
	{
	    // deathcharger

// ansturm. todesröcheln:/ fügt eurem helden 3 schaden zu.
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