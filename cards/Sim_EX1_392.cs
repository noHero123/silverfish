// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_392.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_392.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_392.
    /// </summary>
    class Sim_EX1_392 : SimTemplate
	{
	    // battlerage

// zieht eine karte für jeden verletzten befreundeten charakter.

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
            List<Minion> temp = ownplay? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp )
            {
                if (mnn.wounded)
                {
                    p.drawACard(CardDB.cardName.unknown, ownplay);
                }
            }

            if (ownplay && p.ownHero.Hp < 30) p.drawACard(CardDB.cardName.unknown, true);
            if (!ownplay && p.enemyHero.Hp < 30) p.drawACard(CardDB.cardName.unknown, false);

		}

	}
}