// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_144.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_144.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_144.
    /// </summary>
    class Sim_EX1_144 : SimTemplate
	{
	    // shadowstep

// lasst einen befreundeten diener auf eure hand zurückkehren. der diener kostet (2) weniger.

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
            p.minionReturnToHand(target, ownplay, target.handcard.card.cost - 2);
		}

	}
}