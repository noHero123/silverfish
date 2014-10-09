// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_134.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_134.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_134.
    /// </summary>
    class Sim_EX1_134 : SimTemplate
	{
	    // si7agent

// combo:/ verursacht 2 schaden.
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
            if ( p.cardsPlayedThisTurn >= 1)
            {
                p.minionGetDamageOrHeal(target, 2);
            }
		}

	}
}