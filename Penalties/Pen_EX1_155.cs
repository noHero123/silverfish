// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_155.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_155.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_155.
    /// </summary>
    class Pen_EX1_155 : PenTemplate
	{
	    // markofnature

// wählt aus:/ verleiht einem diener +4 angriff; oder +4 leben und spott/.
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
            if (choice == 1)
            {
                if (target.own)
                {
                    if (!m.Ready)
                    {
                        return 50;
                    }

                    if (m.Hp == 1 && !m.divineshild)
                    {
                        return 10;
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
            }

            if (choice == 2)
            {
                bool enemyHasTaunts = false;
                foreach (Minion e in p.enemyMinions)
                {
                    if (e.taunt) enemyHasTaunts = true;
                }

                if (!target.taunt && !target.silenced && target.handcard.card.targetPriority >= 1 && enemyHasTaunts)
                {
                    return 0;
                }

                return 500;
            }

            return 0;
		}

	}
}