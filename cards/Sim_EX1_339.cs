// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_339.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_339.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_339.
    /// </summary>
    class Sim_EX1_339 : SimTemplate
	{
	    // thoughtsteal

// kopiert 2 karten aus dem deck eures gegners und fügt sie eurer hand hinzu.
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
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
		}

	}
}