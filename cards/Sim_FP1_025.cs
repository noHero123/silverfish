// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_025.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_025.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_025.
    /// </summary>
    class Sim_FP1_025 : SimTemplate
	{
	    // reincarnate

// vernichtet einen diener und bringt ihn dann mit vollem leben wieder auf das schlachtfeld zurück.

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
            bool own = target.own;
            int place = target.zonepos;
            CardDB.Card d = target.handcard.card;
            p.minionGetDestroyed(target);
            p.callKid(d, place, own);
		}

	}
}