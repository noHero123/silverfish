// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_108.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_108.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_108.
    /// </summary>
    class Sim_CS2_108 : SimTemplate
	{
	    // execute

// vernichtet einen verletzten feindlichen diener.
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
		}

	}
}