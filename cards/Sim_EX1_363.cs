// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_363.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_363.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_363.
    /// </summary>
    class Sim_EX1_363 : SimTemplate
	{
	    // blessingofwisdom

// wählt einen diener aus. zieht jedes mal eine karte, wenn er angreift.

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
            if (ownplay)
            {
                target.ownBlessingOfWisdom++;
            }
            else
            {
                target.enemyBlessingOfWisdom++;
            }

		}

	}
}