// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_GAME_005.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ gam e_005.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ gam e_005.
    /// </summary>
    class Sim_GAME_005 : SimTemplate
	{
	    // thecoin

// erhaltet 1 manakristall nur für diesen zug.
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
            if (ownplay)
            {
                p.mana++;
            }
            else
            {
                p.mana++;
            }
        }

	}
}