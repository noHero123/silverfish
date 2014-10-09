// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_NEW1_029.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ ne w 1_029.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ ne w 1_029.
    /// </summary>
    class Pen_NEW1_029 : PenTemplate
	{
	    // millhousemanastorm

// kampfschrei:/ im nächsten zug kosten zauber für euren gegner (0) mana.
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