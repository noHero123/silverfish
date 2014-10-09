// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_DS1_184.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ d s 1_184.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ d s 1_184.
    /// </summary>
    class Pen_DS1_184 : PenTemplate
	{
	    // tracking

// schaut euch die drei obersten karten eures decks an. zieht eine davon und werft die anderen beiden ab.
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