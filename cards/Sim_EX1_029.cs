// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_029.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_029.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_029.
    /// </summary>
    class Sim_EX1_029 : SimTemplate
	{
	    // lepergnome

// todesröcheln:/ fügt dem feindlichen helden 2 schaden zu.
        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.minionGetDamageOrHeal(p.enemyHero, 2);
            }
            else
            {
                p.minionGetDamageOrHeal(p.ownHero, 2);
            }
        }

	}
}