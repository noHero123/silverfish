// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_603.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_603.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_603.
    /// </summary>
    class Sim_EX1_603 : SimTemplate
	{
	    // crueltaskmaster

// kampfschrei:/ fügt einem diener 1 schaden zu und verleiht ihm +2 angriff.
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
            if (target != null)
            {
                p.minionGetDamageOrHeal(target, 1);
                p.minionGetTempBuff(target, 2, 0);
            }

		}

	}
}