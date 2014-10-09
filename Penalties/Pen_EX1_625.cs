// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_625.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_625.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_625.
    /// </summary>
    class Pen_EX1_625 : PenTemplate
	{
	    // shadowform

// eure heldenfähigkeit wird zu „verursacht 2 schaden“. wenn euer held bereits schattengestalt angenommen hat: 3 schaden.
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