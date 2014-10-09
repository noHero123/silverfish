// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_CS2_046.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ c s 2_046.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ c s 2_046.
    /// </summary>
    class Pen_CS2_046 : PenTemplate
	{
	    // bloodlust

// verleiht euren dienern +3 angriff in diesem zug.
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
            if (!isLethal)
            {
                int targets = 0;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.Ready) targets++;
                }

                if (targets <= 1)
                {
                    return 40;
                }

                if (targets <= 2)
                {
                    return 20;
                }
            }

            return 0;
		}

	}
}