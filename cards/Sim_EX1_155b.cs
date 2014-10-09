// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_155b.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_155 b.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_155 b.
    /// </summary>
    class Sim_EX1_155b : SimTemplate
	{
	    // markofnature

// +4 leben und spott/.

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
            p.minionGetBuffed(target, 0, 4);
            target.taunt = true;
		}

	}
}