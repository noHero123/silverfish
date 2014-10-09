// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_DS1h_292.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ d s 1 h_292.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ d s 1 h_292.
    /// </summary>
    class Pen_DS1h_292 : PenTemplate
	{
	    // steadyshot

// heldenfähigkeit/\nfügt dem feindlichen helden 2 schaden zu.
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