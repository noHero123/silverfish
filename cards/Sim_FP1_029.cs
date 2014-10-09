// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_029.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_029.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_029.
    /// </summary>
    class Sim_FP1_029 : SimTemplate
	{
	    // dancingswords

// todesröcheln:/ euer gegner zieht eine karte.

        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, !m.own);
        }

	}
}