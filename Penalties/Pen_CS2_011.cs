// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_CS2_011.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ c s 2_011.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ c s 2_011.
    /// </summary>
    class Pen_CS2_011 : PenTemplate
	{
	    // savageroar

// verleiht euren charakteren +2 angriff in diesem zug.
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

                if (p.ownHero.Ready || p.ownHero.numAttacksThisTurn == 0) targets++;

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