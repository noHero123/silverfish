// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_059.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_059.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_059.
    /// </summary>
    class Sim_EX1_059 : SimTemplate
	{
	    // crazedalchemist

// kampfschrei:/ vertauscht angriff und leben eines dieners.
        // todo: use buffs after that
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
            if (target != null) p.minionSwapAngrAndHP(target);
		}

	}
}