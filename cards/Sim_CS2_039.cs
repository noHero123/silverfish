// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_039.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_039.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_039.
    /// </summary>
    class Sim_CS2_039 : SimTemplate
	{
	    // windfury

// verleiht einem diener windzorn/.
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
            p.minionGetWindfurry(target);
		}

	}
}