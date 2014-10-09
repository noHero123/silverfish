// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_309.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_309.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_309.
    /// </summary>
    class Pen_EX1_309 : PenTemplate
	{
	    // siphonsoul

// vernichtet einen diener. stellt bei eurem helden #3 leben wieder her.
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