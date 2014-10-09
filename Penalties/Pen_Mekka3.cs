// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_Mekka3.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ mekka 3.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ mekka 3.
    /// </summary>
    class Pen_Mekka3 : PenTemplate
	{
	    // emboldener3000

// verleiht am ende eures zuges einem zufälligen diener +1/+1.
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