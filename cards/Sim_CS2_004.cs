// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_004.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_004.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_004.
    /// </summary>
    class Sim_CS2_004 : SimTemplate
	{
	    // powerwordshield

// verleiht einem diener +2 leben.\nzieht eine karte.
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
            p.minionGetBuffed(target, 0, 2);
            p.drawACard(CardDB.cardName.unknown, ownplay);
		}

	}
}