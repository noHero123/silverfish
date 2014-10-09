// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_NEW1_004.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ ne w 1_004.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ ne w 1_004.
    /// </summary>
    class Pen_NEW1_004 : PenTemplate
	{
	    // vanish

// lasst alle diener auf die hand ihrer besitzer zurückkehren.
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