// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_332.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_332.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_332.
    /// </summary>
    class Sim_EX1_332 : SimTemplate
	{
	    // silence

// bringt einen diener zum schweigen/.

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
            p.minionGetSilenced(target);
		}

	}
}