// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_NEW1_021.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ ne w 1_021.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ ne w 1_021.
    /// </summary>
    class Pen_NEW1_021 : PenTemplate
	{
	    // doomsayer

// vernichtet zu beginn eures zuges alle diener.
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