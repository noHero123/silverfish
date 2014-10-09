// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_015.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_015.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_015.
    /// </summary>
    class Sim_EX1_015 : SimTemplate
	{
	    // noviceengineer

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