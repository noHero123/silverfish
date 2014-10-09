// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_587.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_587.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_587.
    /// </summary>
    class Pen_EX1_587 : PenTemplate
	{
	    // windspeaker

// kampfschrei:/ verleiht einem befreundeten diener windzorn/.
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