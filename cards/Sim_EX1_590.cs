// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_590.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_590.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_590.
    /// </summary>
    class Sim_EX1_590 : SimTemplate
	{
	    // bloodknight

// kampfschrei:/ alle diener verlieren gottesschild/. erhält +3/+3 für jeden verlorenen schild.
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
            int shilds = 0;
            foreach (Minion m in p.ownMinions)
            {
                if (m.divineshild)
                {
                    m.divineshild = false;
                    shilds++;
                }
            }

            foreach (Minion m in p.enemyMinions)
            {
                if (m.divineshild)
                {
                    m.divineshild = false;
                    shilds++;
                }
            }

            p.minionGetBuffed(own, 3 * shilds, 3 * shilds);
		}


	}
}