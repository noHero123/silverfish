// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_CS1h_001.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ c s 1 h_001.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ c s 1 h_001.
    /// </summary>
    class Pen_CS1h_001 : PenTemplate
	{
	    // lesserheal

// heldenfähigkeit/\nstellt 2 leben wieder her.
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