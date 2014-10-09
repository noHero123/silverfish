// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DS1_184.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ d s 1_184.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ d s 1_184.
    /// </summary>
    class Sim_DS1_184 : SimTemplate
	{
	    // tracking

// schaut euch die drei obersten karten eures decks an. zieht eine davon und werft die anderen beiden ab.

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
            // TODO NOT SUPPORTED YET
            // p.drawACard(CardDB.cardName.unknown, ownplay);
            p.evaluatePenality += 100;
		}

	}
}