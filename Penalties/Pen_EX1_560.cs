// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_560.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_560.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_560.
    /// </summary>
    class Pen_EX1_560 : PenTemplate
	{
	    // nozdormu

// spieler haben nur jeweils 15 sekunden für ihren zug.
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