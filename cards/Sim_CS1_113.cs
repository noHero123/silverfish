// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS1_113.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 1_113.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 1_113.
    /// </summary>
    class Sim_CS1_113 : SimTemplate
	{
	    // mindcontrol

// übernehmt die kontrolle über einen feindlichen diener.
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
            p.minionGetControlled(target, ownplay, false);
		}

	}
}