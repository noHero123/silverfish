// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_274.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_274.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_274.
    /// </summary>
    class Pen_EX1_274 : PenTemplate
	{
	    // etherealarcanist

// erhält +2/+2, wenn ihr am ende eures zuges über ein aktives geheimnis/ verfügt.
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