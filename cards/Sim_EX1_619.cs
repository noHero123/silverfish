// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_619.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_619.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_619.
    /// </summary>
    class Sim_EX1_619 : SimTemplate
	{
	    // equality

// setzt das leben aller diener auf 1.

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
            foreach (Minion m in p.ownMinions)
            {
                p.minionSetLifetoOne(m);
            }

            foreach (Minion m in p.enemyMinions)
            {
                p.minionSetLifetoOne(m);
            }
		}

	}
}