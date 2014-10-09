// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_102.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_102.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_102.
    /// </summary>
    class Sim_CS2_102 : SimTemplate
	{
	    // armorup

// heldenfähigkeit/\nerhaltet 2 rüstung.

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
                p.ownHero.armor += 2;
            }
            else
            {
                p.enemyHero.armor += 2;
            }
		}

	}
}