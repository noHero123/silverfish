// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_014t.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_014 t.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_014 t.
    /// </summary>
    class Sim_EX1_014t : SimTemplate
	{
	    // bananas

// verleiht einem diener +1/+1.

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
            p.minionGetBuffed(target, 1, 1);
		}

	}
}