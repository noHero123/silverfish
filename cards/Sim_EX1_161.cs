// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_161.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_161.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_161.
    /// </summary>
    class Sim_EX1_161 : SimTemplate
	{
	    // naturalize

// vernichtet einen diener. euer gegner zieht 2 karten.

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
            p.minionGetDestroyed(target);
            p.drawACard(CardDB.cardName.unknown, !ownplay);
            p.drawACard(CardDB.cardName.unknown, !ownplay);
		}

	}
}