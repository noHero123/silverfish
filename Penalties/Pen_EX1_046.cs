// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_046.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_046.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_046.
    /// </summary>
    class Pen_EX1_046 : PenTemplate
	{
	    // darkirondwarf

// kampfschrei:/ verleiht einem diener +2 angriff in diesem zug.
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
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 50;
                }
            }
            else
            {
                if (m.handcard.card.type == CardDB.cardtype.MOB && p.ownMinions.Count == 0)
                {
                    return 0;
                }

                // allow it if you have biggamehunter
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.biggamehunter || hc.card.name == CardDB.cardName.shadowworddeath)
                    {
                        return 0;
                    }
                }

                return 500;
            }

            return 0;
		}

	}
}