// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_CS2_092.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ c s 2_092.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ c s 2_092.
    /// </summary>
    class Pen_CS2_092 : PenTemplate
	{
	    // blessingofkings

// verleiht einem diener +4/+4. i&gt;(+4 angriff/+4 leben)/i&gt;
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
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.biggamehunter || hc.card.name == CardDB.cardName.shadowworddeath) return 0;
                }

                return 500;
            }

            return 0;
		}

	}
}