// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_147.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_147.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_147.
    /// </summary>
    class Sim_CS2_147 : SimTemplate
	{
	    // gnomishinventor

// kampfschrei:/ zieht eine karte.
        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, own.own);
		}


	}
}