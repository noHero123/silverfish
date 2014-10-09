// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_008a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_008 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_008 a.
    /// </summary>
    class Sim_NEW1_008a : SimTemplate
	{
	    // ancientteachings

// zieht 2 karten.
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
            p.drawACard(CardDB.cardName.unknown, own.own);
		}
	}
}