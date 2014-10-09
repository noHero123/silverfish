// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_DREAM_01.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ drea m_01.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ drea m_01.
    /// </summary>
    class Pen_DREAM_01 : PenTemplate
	{
	    // laughingsister

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