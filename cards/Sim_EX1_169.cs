// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_169.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_169.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_169.
    /// </summary>
    class Sim_EX1_169 : SimTemplate
	{
	    // innervate

// erhaltet 2 manakristalle nur für diesen zug.

        /// <summary>
        /// The on card play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.mana = Math.Min(p.mana + 2, 10);
		}

	}
}