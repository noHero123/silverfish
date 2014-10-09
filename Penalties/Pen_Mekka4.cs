// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_Mekka4.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ mekka 4.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ mekka 4.
    /// </summary>
    class Pen_Mekka4 : PenTemplate
	{
	    // poultryizer

// verwandelt zu beginn eures zuges einen zufälligen diener in ein huhn (1/1).
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