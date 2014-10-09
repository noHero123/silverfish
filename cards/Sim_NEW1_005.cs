// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_005.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_005.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_005.
    /// </summary>
    class Sim_NEW1_005 : SimTemplate
	{
	    // kidnapper

// combo:/ lasst einen diener auf die hand seines besitzers zurückkehren.
        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1) p.minionReturnToHand(target, target.own, 0);
		}


	}
}