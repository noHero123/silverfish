// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_FP1_018.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ f p 1_018.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ f p 1_018.
    /// </summary>
    class Pen_FP1_018 : PenTemplate
	{
	    // duplicate

// geheimnis:/ wenn ein befreundeter diener stirbt, erhaltet ihr 2 kopien dieses dieners auf eure hand.
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