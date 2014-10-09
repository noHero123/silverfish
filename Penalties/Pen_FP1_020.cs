// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_FP1_020.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ f p 1_020.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ f p 1_020.
    /// </summary>
    class Pen_FP1_020 : PenTemplate
	{
	    // avenge

// geheimnis:/ wenn einer eurer diener stirbt, erhält ein zufälliger befreundeter diener +3/+2.
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