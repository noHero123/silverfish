// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_608.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_608.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_608.
    /// </summary>
    class Sim_EX1_608 : SimTemplate
	{
	    // sorcerersapprentice

// eure zauber kosten (1) weniger.
        /// <summary>
        /// The on aura starts.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnsorcerersapprentice++;
            }
            else
            {
                p.anzEnemysorcerersapprentice++;
                
            }

        }

        /// <summary>
        /// The on aura ends.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnsorcerersapprentice--;
            }
            else
            {
                p.anzEnemysorcerersapprentice--;
            }
        }
	}
}