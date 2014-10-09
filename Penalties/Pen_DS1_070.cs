// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_DS1_070.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ d s 1_070.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ d s 1_070.
    /// </summary>
    class Pen_DS1_070 : PenTemplate
	{
	    // houndmaster

// kampfschrei:/ verleiht einem befreundeten wildtier +2/+2 und spott/.
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