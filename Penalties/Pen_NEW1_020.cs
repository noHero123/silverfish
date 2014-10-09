// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_NEW1_020.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ ne w 1_020.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ ne w 1_020.
    /// </summary>
    class Pen_NEW1_020 : PenTemplate
	{
	    // wildpyromancer

// fügt allen dienern 1 schaden zu, nachdem ihr einen zauber gewirkt habt.
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