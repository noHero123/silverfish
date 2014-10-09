// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DREAM_04.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ drea m_04.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ drea m_04.
    /// </summary>
    class Sim_DREAM_04 : SimTemplate
	{
	    // dream

// lasst einen diener auf die hand seines besitzers zurückkehren.

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
            p.minionReturnToHand(target, target.own, 0);
		}


	}
}