// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_NEW1_023.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ ne w 1_023.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ ne w 1_023.
    /// </summary>
    class Pen_NEW1_023 : PenTemplate
	{
	    // faeriedragon

// kann nicht als ziel von zaubern oder heldenfähigkeiten gewählt werden.
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