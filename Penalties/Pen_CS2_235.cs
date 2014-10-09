// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_CS2_235.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ c s 2_235.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ c s 2_235.
    /// </summary>
    class Pen_CS2_235 : PenTemplate
	{
	    // northshirecleric

// zieht jedes mal eine karte, wenn ein diener geheilt wird.
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